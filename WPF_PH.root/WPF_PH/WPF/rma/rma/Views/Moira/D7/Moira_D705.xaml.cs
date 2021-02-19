
#region "Screen Comments"

// #> program-id.     d705.qks
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : TO ALLOW CORRECTIONS TO SUSPENDED CLAIM HEADER/DETAIL/ADDRESS RECS
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 90/JUN/13 D.B.         - ORIGINAL
// 90/OCT/02 B.E.         - ADDED OHIP CODE/SUFFIX, ADJ CD/SUB-TYPE FIELDS TO SCREEN
// 90/OCT/22 D.B.         - ADDED EDITS
// 91/FEB/15 B.E.         - ADDED  ADD  DESIGNER RTN TO ACCESS SUSPENDED ADDRESS RECORDS
// 91/OCT/29 M.C.         - CORRECT THE ACCESS STMT IN F091-DIAG-CODEa
// 98/aug/19 B.E.         - added new edits for hospital code
// 98/aug/20 B.E.         - re-added clinic/doc # fields
// 98/oct/05 B.E.         - re-added manual-review-flag field
// 1998/Nov/11 S.B.   - Added file  F002-SUSPEND-HDR  to the passing
// list of the DESIGNER DTL procedure.
// - Put a  refresh  on the fields  clmdtl-fee-oma 
// and  clmdtl-fee-ohip .
// 1999/jan/26 B.E        - error that patient Ikey/acronym don`t match
// changed to a warning message (Kathy K request)
// 1999/jan/28 B.E   - y2k
// 1999/Mar/09 M.C.     - edit check on clinic nbr and specialty cd  
// 1999/jul/06 B.E.       - access f020 via doc-nbr instead of doc-ohip-nbr
// - changed get in Edit procedure of clmhdr-loc
// 2000/Feb/03 B.A.       - add code to set an update flag
// 2000/Feb/08 B.A.       - added a confidental-flag field
// 2000/Apr/18 B.A.       - Re-aranged last three fields
// - Added an `I`gnor and and an unignore designer proc
// 2000/jun/05 B.E.   - added clmhdr-fee-tech and rearranged fields on 
// fields
// 00/sep/14 B.E. - added call to d705c to maintain  manual review  records
// - added field clmhdr-nbr-suspend-desc-recs
// 00/sep/18 B.E. - removed hospital field since it`s now calculated using
// location and need not be entered
// 00/sep/21 B.E. - add clmhdr-adj-cd-sub-type to f002_suspend_hdr to
// contain indicator as to whether the claim came from `W`eb
// or `D`iskette upload
// 00/sep/22 B.E. - display patient`s HCN and version code
// 00/sep/22 B.E. - if diag-cd changed, updated into all details records
// 00/sep/25 B.E. - added warning if description text longer than what fits    
// into 5 claim description recs
// 00/oct/04 M.C. - transfer initialize to postfind for saving old diag-cd
// 00/oct/10 B.E. - update status of detail recs to `updated` when the
// diagnosis is changed due to change in header`s diag-cd
// 00/oct/20 B.E. - limit values of clmhdr-adj-cd-sub-type to  W  and  D 
// - added f073 to verify values entered into this field
// 00/oct/20 B.E. - clmhdr-adj-cd-sub-type made display only - not to be changed
// 02/jan/14 M.C. - when user changes doc-nbr, set dept from doc-dept , also
// validate doc-ohip-nbr and doc-spec-cd
// 02/may/03 M.C. - include payroll flag next to  clinic/doc # fields
// 2003/dec/10 A.A. - alpha doctor nbr
// 2008/sep/05 brad1 - allow user to change doctor dept
// 2008/oct/30 M.C. - undo what Brad has done above with brad1, instead add a new designer `PASS`
// to allow Yasemin to change doc-dept
// 2010/aug/11 MC1 - access f002-suspend-hdr by new index suspend-hdr-acr as default index
// 2010/sep/20 MC2 - reset patient info (health nbr, version, prov & acronym) when user changes ikey
// 2012/Jan/10 MC3 - use clmhdr-date-admit-num instead of clmhdr-date-admit
// 2012/Oct/02 MC4 - add new temp item x-clinic-status and include display on line 3 next to clinic
// - add f020-doctor-extra to extract clinic status
// 2012/Nov/05 MC5 - correct where is applicable for direct bill claim as suggested by Yasemin
// 2013/Mar/19 MC6 - add `diag` designer procedure to allow user to change header diag code and update
// all detail with the same diag code
// , delete 

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
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;

namespace rma.Views
{

    partial class Moira_D705 : BasePage
    {

        #region " Form Designer Generated Code "





        public Moira_D705()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D705";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.UseAcceptProcessing = true;
        }

        #endregion

        RoutedCommand dsrDTL = new RoutedCommand();
        RoutedCommand dsrADD = new RoutedCommand();
        RoutedCommand dsrDES = new RoutedCommand();
        RoutedCommand dsrIGN = new RoutedCommand();
        RoutedCommand dsrUNIGN = new RoutedCommand();
        RoutedCommand dsrIKEY = new RoutedCommand();
        RoutedCommand dsrSTATUS = new RoutedCommand();

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_DTL.Click += dsrDesigner_DTL_Click;
            dsrDesigner_CORE_ADD.Click += dsrDesigner_CORE_ADD_Click;
            dsrDesigner_DES.Click += dsrDesigner_DES_Click;
            dsrDesigner_IGN.Click += dsrDesigner_IGN_Click;
            dsrDesigner_UNIGN.Click += dsrDesigner_UNIGN_Click;
            dsrDesigner_IKEY.Click += dsrDesigner_IKEY_Click;
            dsrDesigner_STATUS.Click += dsrDesigner_STATUS_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_27.Click += dsrDesigner_27_Click;
            dsrDesigner_15.Click += dsrDesigner_15_Click;
            dsrDesigner_DTL.KeyUp += dsrDesigner_DTL_KeyUp;
            dsrDesigner_CORE_ADD.KeyUp += dsrDesigner_CORE_ADD_KeyUp;
            dsrDesigner_DES.KeyUp += dsrDesigner_DES_KeyUp;
            dsrDesigner_IGN.KeyUp += dsrDesigner_IGN_KeyUp;
            dsrDesigner_UNIGN.KeyUp += dsrDesigner_UNIGN_KeyUp;
            dsrDesigner_IKEY.KeyUp += dsrDesigner_IKEY_KeyUp;
            dsrDesigner_STATUS.KeyUp += dsrDesigner_STATUS_KeyUp;
            fldF002_SUSPEND_HDR_CLMHDR_DIAG_CD_ALPHA.LookupOn += fldF002_SUSPEND_HDR_CLMHDR_DIAG_CD_ALPHA_LookupOn;
            fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR.LookupOn += fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_LookupOn;
            fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2.Edit += fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR.Edit += fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_DOC_SPEC_CD.Edit += fldF002_SUSPEND_HDR_CLMHDR_DOC_SPEC_CD_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_LOC.Edit += fldF002_SUSPEND_HDR_CLMHDR_LOC_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_DOC_DEPT_ALPHA.Edit += fldF002_SUSPEND_HDR_CLMHDR_DOC_DEPT_ALPHA_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR.Input += fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR_Input;
            fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR.Edit += fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_REPRINT_FLAG.Input += fldF002_SUSPEND_HDR_CLMHDR_REPRINT_FLAG_Input;
            fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR.Input += fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR_Input;
            fldF002_SUSPEND_HDR_CLMHDR_AUTO_LOGOUT.Input += fldF002_SUSPEND_HDR_CLMHDR_AUTO_LOGOUT_Input;
            fldF002_SUSPEND_HDR_CLMHDR_FEE_COMPLEX.Input += fldF002_SUSPEND_HDR_CLMHDR_FEE_COMPLEX_Input;
            fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA.Edit += fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2.Process += fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2_Process;
            fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR.Process += fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_Process;
            fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR.Process += fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR_Process;
            fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA.Process += fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA_Process;
            fldF002_SUSPEND_HDR_CLMHDR_ADJ_CD_SUB_TYPE.Process += fldF002_SUSPEND_HDR_CLMHDR_ADJ_CD_SUB_TYPE_Process;

            base.Page_Load();

            dsrIKEY.InputGestures.Add(new KeyGesture(Key.F7));
            CommandBindings.Add(new CommandBinding(dsrIKEY, dsrDesigner_IKEY_Click));
            dsrSTATUS.InputGestures.Add(new KeyGesture(Key.F8));
            CommandBindings.Add(new CommandBinding(dsrSTATUS, dsrDesigner_STATUS_Click));

            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F002_SUSPEND_HDR.CLMHDR_PAT_ACRONYM


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            SCHEMA = new CoreCharacter("SCHEMA", 20, this, Environment.GetEnvironmentVariable("VS_DIRECTORY"));
            X_FIND_INVALID_FLAG = new CoreCharacter("X_FIND_INVALID_FLAG", 1, this, Common.cEmptyString);
            X_OLD_DIAG = new CoreDecimal("X_OLD_DIAG", 3, this);
            X_NBR_DESC_RECS = new CoreDecimal("X_NBR_DESC_RECS", 6, this);
            X_WARN_FLAG = new CoreCharacter("X_WARN_FLAG", 1, this, Common.cEmptyString);
            X_PASSWORD = new CoreCharacter("X_PASSWORD", 5, this, Common.cEmptyString);
            X_CLINIC_STATUS = new CoreCharacter("X_CLINIC_STATUS", 1, this, Common.cEmptyString);
            fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE2");
            fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Delete, 0, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE2");
            fleF002_DTL_UPDATE = new SqlFileObject(this, FileTypes.Designer, 0, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_DTL", "F002_DTL_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE2");
            fleF002_DESC_VERIFY = new SqlFileObject(this, FileTypes.Designer, 0, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_DESC", "F002_DESC_VERIFY", false, false, false, 0, "m_trnTRANS_UPDATE2");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_cnnQUERY");
            fleF073_CLIENT_DOC_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F073_CLIENT_DOC_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF091_DIAG_CODES_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F091_DIAG_CODES_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF094_MSG_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F094_MSG_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            W_CLMHDR_DOC_OHIP_NBR = new CoreDecimal("W_CLMHDR_DOC_OHIP_NBR", 6, this);
            W_CLMHDR_ACCOUNTING_NBR = new CoreCharacter("W_CLMHDR_ACCOUNTING_NBR", 8, this, Common.cEmptyString);
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleDOC_CLINICS = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "DOC_CLINICS", false, false, false, 0, "m_cnnQUERY");
            fleF020L_DOC_LOCATIONS = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F020L_DOC_LOCATIONS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            CLMHDR_PAT_ACRONYM = new CoreCharacter("CLMHDR_PAT_ACRONYM", 9, this, Common.cEmptyString);
            CLMHDR_DOC_NBR = new CoreCharacter("CLMHDR_DOC_NBR", 3, this, Common.cEmptyString);
            CLMHDR_CLINIC_NBR_1_2 = new CoreDecimal("CLMHDR_CLINIC_NBR_1_2", 3, this);

            CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
            CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
            CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
            CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
            CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
            CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
            CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
            UPDATED.GetValue += UPDATED_GetValue;
            CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;
            CLMDTL_STATUS_DELETE.GetValue += CLMDTL_STATUS_DELETE_GetValue;
            CLMDTL_STATUS_NEW.GetValue += CLMDTL_STATUS_NEW_GetValue;
            CLMDTL_STATUS_ACTIVE.GetValue += CLMDTL_STATUS_ACTIVE_GetValue;
            CLMDTL_STATUS_UPDATED.GetValue += CLMDTL_STATUS_UPDATED_GetValue;
            fleF002_DTL_UPDATE.Access += fleF002_DTL_UPDATE_Access;
            fleF002_DESC_VERIFY.Access += fleF002_DESC_VERIFY_Access;
            fleF020_DOCTOR_MSTR.Access += fleF020_DOCTOR_MSTR_Access;
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Access += fleF020C_DOC_CLINIC_NEXT_BATCH_NBR_Access;
            fleF020L_DOC_LOCATIONS.Access += fleF020L_DOC_LOCATIONS_Access;
            fleF020_DOCTOR_EXTRA.Access += fleF020_DOCTOR_EXTRA_Access;
            fleF073_CLIENT_DOC_MSTR.Access += fleF073_CLIENT_DOC_MSTR_Access;
            fleF091_DIAG_CODES_MSTR.Access += fleF091_DIAG_CODES_MSTR_Access;
            fleF002_SUSPEND_HDR.InitializeItems += fleF002_SUSPEND_HDR_InitializeItems;
            fleF002_SUSPEND_HDR.SetItemFinals += fleF002_SUSPEND_HDR_SetItemFinals;
        }

      

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            CLMHDR_STATUS_COMPLETE.GetValue -= CLMHDR_STATUS_COMPLETE_GetValue;
            CLMHDR_STATUS_DELETE.GetValue -= CLMHDR_STATUS_DELETE_GetValue;
            CLMHDR_STATUS_CANCEL.GetValue -= CLMHDR_STATUS_CANCEL_GetValue;
            CLMHDR_STATUS_RESUBMIT.GetValue -= CLMHDR_STATUS_RESUBMIT_GetValue;
            CLMHDR_STATUS_ERROR.GetValue -= CLMHDR_STATUS_ERROR_GetValue;
            CLMHDR_STATUS_NOT_COMPLETE.GetValue -= CLMHDR_STATUS_NOT_COMPLETE_GetValue;
            CLMHDR_STATUS_DEFAULT.GetValue -= CLMHDR_STATUS_DEFAULT_GetValue;
            UPDATED.GetValue -= UPDATED_GetValue;
            CLMHDR_STATUS_IGNOR.GetValue -= CLMHDR_STATUS_IGNOR_GetValue;
            CLMDTL_STATUS_DELETE.GetValue -= CLMDTL_STATUS_DELETE_GetValue;
            CLMDTL_STATUS_NEW.GetValue -= CLMDTL_STATUS_NEW_GetValue;
            CLMDTL_STATUS_ACTIVE.GetValue -= CLMDTL_STATUS_ACTIVE_GetValue;
            CLMDTL_STATUS_UPDATED.GetValue -= CLMDTL_STATUS_UPDATED_GetValue;
            fleF002_DTL_UPDATE.Access -= fleF002_DTL_UPDATE_Access;
            fleF002_DESC_VERIFY.Access -= fleF002_DESC_VERIFY_Access;
            fleF020_DOCTOR_MSTR.Access -= fleF020_DOCTOR_MSTR_Access;
            fleF020_DOCTOR_EXTRA.Access -= fleF020_DOCTOR_EXTRA_Access;
            fleF073_CLIENT_DOC_MSTR.Access -= fleF073_CLIENT_DOC_MSTR_Access;
            fleF091_DIAG_CODES_MSTR.Access -= fleF091_DIAG_CODES_MSTR_Access;
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Access -= fleF020C_DOC_CLINIC_NEXT_BATCH_NBR_Access;
            fleF020L_DOC_LOCATIONS.Access -= fleF020L_DOC_LOCATIONS_Access;
            fldF002_SUSPEND_HDR_CLMHDR_DIAG_CD_ALPHA.LookupOn -= fldF002_SUSPEND_HDR_CLMHDR_DIAG_CD_ALPHA_LookupOn;
            fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR.LookupOn -= fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_LookupOn;
            fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2.Edit -= fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR.Edit -= fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_DOC_SPEC_CD.Edit -= fldF002_SUSPEND_HDR_CLMHDR_DOC_SPEC_CD_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_LOC.Edit -= fldF002_SUSPEND_HDR_CLMHDR_LOC_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_DOC_DEPT_ALPHA.Edit -= fldF002_SUSPEND_HDR_CLMHDR_DOC_DEPT_ALPHA_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR.Input -= fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR_Input;
            fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR.Edit -= fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR_Edit;
            fldF002_SUSPEND_HDR_CLMHDR_REPRINT_FLAG.Input -= fldF002_SUSPEND_HDR_CLMHDR_REPRINT_FLAG_Input;
            fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR.Input -= fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR_Input;
            fldF002_SUSPEND_HDR_CLMHDR_AUTO_LOGOUT.Input -= fldF002_SUSPEND_HDR_CLMHDR_AUTO_LOGOUT_Input;
            fldF002_SUSPEND_HDR_CLMHDR_FEE_COMPLEX.Input -= fldF002_SUSPEND_HDR_CLMHDR_FEE_COMPLEX_Input;
            fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA.Edit -= fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA_Edit;
            fleF002_SUSPEND_HDR.InitializeItems -= fleF002_SUSPEND_HDR_InitializeItems;
            dsrDesigner_DTL.Click -= dsrDesigner_DTL_Click;
            dsrDesigner_CORE_ADD.Click -= dsrDesigner_CORE_ADD_Click;
            dsrDesigner_DES.Click -= dsrDesigner_DES_Click;
            dsrDesigner_IGN.Click -= dsrDesigner_IGN_Click;
            dsrDesigner_UNIGN.Click -= dsrDesigner_UNIGN_Click;
            dsrDesigner_IKEY.Click -= dsrDesigner_IKEY_Click;
            dsrDesigner_STATUS.Click -= dsrDesigner_STATUS_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_27.Click -= dsrDesigner_27_Click;
            dsrDesigner_15.Click -= dsrDesigner_15_Click;
            dsrDesigner_DTL.KeyUp -= dsrDesigner_DTL_KeyUp;
            dsrDesigner_CORE_ADD.KeyUp -= dsrDesigner_CORE_ADD_KeyUp;
            dsrDesigner_DES.KeyUp -= dsrDesigner_DES_KeyUp;
            dsrDesigner_IGN.KeyUp -= dsrDesigner_IGN_KeyUp;
            dsrDesigner_UNIGN.KeyUp -= dsrDesigner_UNIGN_KeyUp;
            dsrDesigner_IKEY.KeyUp -= dsrDesigner_IKEY_KeyUp;
            dsrDesigner_STATUS.KeyUp -= dsrDesigner_STATUS_KeyUp;
            fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2.Process -= fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2_Process;
            fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR.Process -= fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_Process;
            fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR.Process -= fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR_Process;
            fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA.Process -= fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA_Process;
            fldF002_SUSPEND_HDR_CLMHDR_ADJ_CD_SUB_TYPE.Process -= fldF002_SUSPEND_HDR_CLMHDR_ADJ_CD_SUB_TYPE_Process;

            CommandBindings.Remove(new CommandBinding(dsrDTL));
            CommandBindings.Remove(new CommandBinding(dsrADD));
            CommandBindings.Remove(new CommandBinding(dsrDES));
            CommandBindings.Remove(new CommandBinding(dsrIGN));
            CommandBindings.Remove(new CommandBinding(dsrUNIGN));
            CommandBindings.Remove(new CommandBinding(dsrIKEY));
            CommandBindings.Remove(new CommandBinding(dsrSTATUS));

            Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        private int recCount = 0;
        private int recCountHDR = 0;
        private int recCountDESC = 0;
        private int recCountDTL = 0;
        private int recCountADDR = 0;

        //private string inputFileLocation = System.Configuration.ConfigurationManager.AppSettings["WEB11Path"].ToString();
        private string suspendFileName = string.Empty;

        private CoreCharacter CLMHDR_DOC_NBR;
        private CoreDecimal CLMHDR_CLINIC_NBR_1_2;

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE2 = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlTransaction m_trnTRANS_UPDATE2;
        //#CORE_BEGIN_INCLUDE: DEF_CLMHDR_STATUS"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:32 AM

        private CoreCharacter SCHEMA;

        private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter(1);
        private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
        {

            try
            {
                Value = "C";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter CLMHDR_STATUS_DELETE = new DCharacter(1);
        private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
        {

            try
            {
                Value = "D";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter(1);
        private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
        {

            try
            {
                Value = "Y";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter(1);
        private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
        {

            try
            {
                Value = "R";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter CLMHDR_STATUS_ERROR = new DCharacter(1);
        private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
        {

            try
            {
                Value = "X";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter(1);
        private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
        {

            try
            {
                Value = "N";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter(1);
        private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
        {

            try
            {
                Value = " ";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter UPDATED = new DCharacter(1);
        private void UPDATED_GetValue(ref string Value)
        {

            try
            {
                Value = "U";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter(1);
        private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
        {

            try
            {
                Value = "I";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        //#CORE_END_INCLUDE: DEF_CLMHDR_STATUS"

        //#CORE_BEGIN_INCLUDE: DEF_CLMDTL_STATUS"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:32 AM

        private DCharacter CLMDTL_STATUS_DELETE = new DCharacter(1);
        private void CLMDTL_STATUS_DELETE_GetValue(ref string Value)
        {

            try
            {
                Value = "D";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter CLMDTL_STATUS_NEW = new DCharacter(1);
        private void CLMDTL_STATUS_NEW_GetValue(ref string Value)
        {

            try
            {
                Value = "N";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter CLMDTL_STATUS_ACTIVE = new DCharacter(1);
        private void CLMDTL_STATUS_ACTIVE_GetValue(ref string Value)
        {

            try
            {
                Value = " ";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter CLMDTL_STATUS_UPDATED = new DCharacter(1);
        private void CLMDTL_STATUS_UPDATED_GetValue(ref string Value)
        {

            try
            {
                Value = "U";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        //#CORE_END_INCLUDE: DEF_CLMDTL_STATUS"

        private CoreCharacter CLMHDR_PAT_ACRONYM;

        private CoreCharacter X_FIND_INVALID_FLAG;
        private CoreDecimal X_OLD_DIAG;
        private CoreDecimal X_NBR_DESC_RECS;
        private CoreCharacter X_WARN_FLAG;
        private CoreCharacter X_PASSWORD;
        private CoreCharacter X_CLINIC_STATUS;
        private SqlFileObject fleF002_SUSPEND_HDR;
        
        private void fleF002_SUSPEND_HDR_SetItemFinals()
        {
            try
            {

                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_PAT_ACRONYM6", CLMHDR_PAT_ACRONYM.Value.PadRight(9, ' ').Substring(0, 6));
                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_PAT_ACRONYM3", CLMHDR_PAT_ACRONYM.Value.PadRight(9, ' ').Substring(6));

                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_BATCH_NBR", CLMHDR_CLINIC_NBR_1_2.Value.ToString().PadLeft(2,'0') + CLMHDR_DOC_NBR.Value + fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR").Substring(5));

            

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }
        }

        private void fleF002_SUSPEND_HDR_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", true, " ");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private SqlFileObject fleF002_SUSPEND_DTL;
        private SqlFileObject fleF002_DTL_UPDATE;

        private void fleF002_DTL_UPDATE_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002_DTL_UPDATE.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ").Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_NBR_OHIP")));
                strText.Append(" AND ").Append(fleF002_DTL_UPDATE.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ").Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                strText.Append(" ORDER BY ").Append(fleF002_DTL_UPDATE.ElementOwner("CLMDTL_DOC_OHIP_NBR"));
                strText.Append(", ").Append(fleF002_DTL_UPDATE.ElementOwner("CLMDTL_ACCOUNTING_NBR"));
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

        private SqlFileObject fleF002_DESC_VERIFY;

        private void fleF002_DESC_VERIFY_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ").Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_NBR_OHIP")));
                strText.Append(" AND ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ").Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                strText.Append(" ORDER BY ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_DOC_OHIP_NBR"));
                strText.Append(", ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_ACCOUNTING_NBR"));
                strText.Append(", ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_LINE_NO"));
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

        private SqlFileObject fleF020C_DOC_CLINIC_NEXT_BATCH_NBR;

        private void fleF020C_DOC_CLINIC_NEXT_BATCH_NBR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                strText.Append(" ORDER BY ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(", ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("SEQ_NO"));
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

        private SqlFileObject fleDOC_CLINICS;
        private SqlFileObject fleF020L_DOC_LOCATIONS;

        private void fleF020L_DOC_LOCATIONS_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF020L_DOC_LOCATIONS.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                strText.Append(" ORDER BY ").Append(fleF020L_DOC_LOCATIONS.ElementOwner("DOC_NBR")).Append(", ").Append(fleF020L_DOC_LOCATIONS.ElementOwner("SEQ_NO"));
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

        private void fleF020_DOCTOR_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(CLMHDR_DOC_NBR.Value));

                strText.Append(" ORDER BY ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR"));
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

        private void fleF020_DOCTOR_EXTRA_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(CLMHDR_DOC_NBR.Value));

                strText.Append(" ORDER BY ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR"));
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

        private SqlFileObject fleF073_CLIENT_DOC_MSTR;

        private void fleF073_CLIENT_DOC_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF073_CLIENT_DOC_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 3, 3)));

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

        private SqlFileObject fleF091_DIAG_CODES_MSTR;

        private void fleF091_DIAG_CODES_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF091_DIAG_CODES_MSTR.ElementOwner("DIAG_CD")).Append(" = ").Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DIAG_CD_ALPHA")));

                strText.Append(" ORDER BY ").Append(fleF091_DIAG_CODES_MSTR.ElementOwner("DIAG_CD"));
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

        private SqlFileObject fleF094_MSG_MSTR;
        private SqlFileObject fleF010_PAT_MSTR;
        private CoreDecimal W_CLMHDR_DOC_OHIP_NBR;

        private CoreCharacter W_CLMHDR_ACCOUNTING_NBR;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:33 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:33 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:33 AM

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
                m_cnnTRANS_UPDATE2 = new SqlConnection(Common.ConnectionStringDecrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString10"]));
                m_cnnTRANS_UPDATE2.Open();
                m_trnTRANS_UPDATE2 = m_cnnTRANS_UPDATE2.BeginTransaction();
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
                if ((m_trnTRANS_UPDATE2 != null))
                    m_trnTRANS_UPDATE2.Dispose();
                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Close();
                if ((m_cnnTRANS_UPDATE != null))
                    m_cnnTRANS_UPDATE.Dispose();
                if ((m_cnnTRANS_UPDATE2 != null))
                    m_cnnTRANS_UPDATE2.Close();
                if ((m_cnnTRANS_UPDATE2 != null))
                    m_cnnTRANS_UPDATE2.Dispose();
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
                m_trnTRANS_UPDATE2.Rollback();
            }
            else
            {
                m_trnTRANS_UPDATE.Commit();
                m_trnTRANS_UPDATE2.Commit();
            }

            m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
            m_trnTRANS_UPDATE2 = m_cnnTRANS_UPDATE2.BeginTransaction();
            Initialize_TRANS_UPDATE();

        }


        private void Initialize_TRANS_UPDATE()
        {
            fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE2;
            fleF002_SUSPEND_DTL.Transaction = m_trnTRANS_UPDATE2;
            fleF002_DTL_UPDATE.Transaction = m_trnTRANS_UPDATE2;
            fleF002_DESC_VERIFY.Transaction = m_trnTRANS_UPDATE2;
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
            fleF020L_DOC_LOCATIONS.Transaction = m_trnTRANS_UPDATE;

        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:33 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF020_DOCTOR_MSTR.Connection = m_cnnQUERY;
                fleF020_DOCTOR_EXTRA.Connection = m_cnnQUERY;
                fleF073_CLIENT_DOC_MSTR.Connection = m_cnnQUERY;
                fleF091_DIAG_CODES_MSTR.Connection = m_cnnQUERY;
                fleF094_MSG_MSTR.Connection = m_cnnQUERY;
                fleF010_PAT_MSTR.Connection = m_cnnQUERY;
                fleDOC_CLINICS.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF002_SUSPEND_HDR.Dispose();
                fleF002_SUSPEND_DTL.Dispose();
                fleF002_DTL_UPDATE.Dispose();
                fleF002_DESC_VERIFY.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleF020_DOCTOR_EXTRA.Dispose();
                fleF073_CLIENT_DOC_MSTR.Dispose();
                fleF091_DIAG_CODES_MSTR.Dispose();
                fleF094_MSG_MSTR.Dispose();
                fleF010_PAT_MSTR.Dispose();
                fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Dispose();
                fleF020L_DOC_LOCATIONS.Dispose();
                fleDOC_CLINICS.Dispose();

            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:32 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:32 AM
                Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_DOC_NBR);
                Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_CLINIC_NBR);
                Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_ACRONYM);
                Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_ACCOUNTING_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_OHIP);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_ACCOUNTING_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2);
                Display(ref fldX_CLINIC_STATUS);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_PAYROLL);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_SPEC_CD);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_REFER_DOC_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DIAG_CD_ALPHA);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_LOC);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_AGENT_CD_ALPHA);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_TAPE_SUBMIT_IND);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_I_O_PAT_IND);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DATE_ADMIT_NUM);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_REPRINT_FLAG);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_ADJ_CD_SUB_TYPE);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_TYPE);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_VER);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_PAT_ACRONYM);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_PROV);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_DEPT_ALPHA);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_AUTO_LOGOUT);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_FEE_COMPLEX);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DATE_SYS);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_AMT_TECH_BILLED);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_TOT_CLAIM_AR_OMA);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_TOT_CLAIM_AR_OHIP);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_CONFIDENTIAL_FLAG);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_MANUAL_REVIEW);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_NBR_SUSPEND_DESC_RECS);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_STATUS);
                Display(ref fldX_PASSWORD);
                Display(ref fldSCHEMA);
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

        private void dsrDesigner_DTL_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_DTL.OnBlur(dsrDesigner_DTL, null);
                }
            }
            catch (Exception ex) { }
        }

        private void dsrDesigner_CORE_ADD_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_CORE_ADD.OnBlur(dsrDesigner_CORE_ADD, null);
                }
            }
            catch (Exception ex) { }
        }

        private void dsrDesigner_DES_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_DES.OnBlur(dsrDesigner_DES, null);
                }
            }
            catch (Exception ex) { }
        }

        private void dsrDesigner_IGN_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_IGN.OnBlur(dsrDesigner_IGN, null);
                }
            }
            catch (Exception ex) { }
        }

        private void dsrDesigner_UNIGN_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_UNIGN.OnBlur(dsrDesigner_UNIGN, null);
                }
            }
            catch (Exception ex) { }
        }

        private void dsrDesigner_IKEY_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_IKEY.OnBlur(dsrDesigner_UNIGN, null);
                }
            }
            catch (Exception ex) { }
        }

        private void dsrDesigner_STATUS_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_STATUS.OnBlur(dsrDesigner_UNIGN, null);
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region "Update Validation"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion


        #region "RecordBuffer Events"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:33 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF002_SUSPEND_HDR_SUSP_HDR_DOC_NBR.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_SUSP_HDR_CLINIC_NBR.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_SUSP_HDR_ACRONYM.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_SUSP_HDR_ACCOUNTING_NBR.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_OHIP.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_ACCOUNTING_NBR.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2.Bind(CLMHDR_CLINIC_NBR_1_2);
                fldX_CLINIC_STATUS.Bind(X_CLINIC_STATUS);
                fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR.Bind(CLMHDR_DOC_NBR);
                fldF002_SUSPEND_HDR_CLMHDR_PAYROLL.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_DOC_SPEC_CD.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_REFER_DOC_NBR.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_DIAG_CD_ALPHA.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_LOC.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_AGENT_CD_ALPHA.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_TAPE_SUBMIT_IND.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_I_O_PAT_IND.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_DATE_ADMIT_NUM.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_REPRINT_FLAG.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_ADJ_CD_SUB_TYPE.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_TYPE.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_NBR.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_VER.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_PAT_ACRONYM.Bind(CLMHDR_PAT_ACRONYM);
                fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_PROV.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_DOC_DEPT_ALPHA.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_AUTO_LOGOUT.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_FEE_COMPLEX.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_DATE_SYS.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_AMT_TECH_BILLED.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_TOT_CLAIM_AR_OMA.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_TOT_CLAIM_AR_OHIP.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_CONFIDENTIAL_FLAG.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_MANUAL_REVIEW.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_NBR_SUSPEND_DESC_RECS.Bind(fleF002_SUSPEND_HDR);
                fldF002_SUSPEND_HDR_CLMHDR_STATUS.Bind(fleF002_SUSPEND_HDR);
                fldX_PASSWORD.Bind(X_PASSWORD);
                fldSCHEMA.Bind(SCHEMA);

            }
            catch (CustomApplicationException ex)
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

        private void fldF002_SUSPEND_HDR_CLMHDR_DIAG_CD_ALPHA_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF091_DIAG_CODES_MSTR.ElementOwner("DIAG_CD")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF091_DIAG_CODES_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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




        private void fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF020_DOCTOR_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Doctor nbr does not exist");
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

        //#CORE_BEGIN_INCLUDE: D705_VERIFY_DESC_LENGTH"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:32 AM


        private bool Internal_WARN_DESC_MAX_LENGTH()
        {


            try
            {

                X_NBR_DESC_RECS.Value = 0;
                X_WARN_FLAG.Value = "N";
                while (fleF002_DESC_VERIFY.WhileRetrieving())
                {
                    X_NBR_DESC_RECS.Value = X_NBR_DESC_RECS.Value + 1;
                    if (QDesign.NULL(X_NBR_DESC_RECS.Value) == 2)
                    {
                        if (39 < (QDesign.Length(QDesign.RTrim(QDesign.Pack(fleF002_DESC_VERIFY.GetStringValue("CLMDTL_SUSPEND_DESC"))))))
                        {
                            X_WARN_FLAG.Value = "Y";
                        }
                    }
                    if (QDesign.NULL(X_NBR_DESC_RECS.Value) == 3 | QDesign.NULL(X_NBR_DESC_RECS.Value) == 4)
                    {
                        if (QDesign.NULL(fleF002_DESC_VERIFY.GetStringValue("CLMDTL_SUSPEND_DESC")) != QDesign.NULL(" "))
                        {
                            X_WARN_FLAG.Value = "Y";
                        }
                    }
                }
                if (QDesign.NULL(X_WARN_FLAG.Value) == QDesign.NULL("Y"))
                {
                    Information("\aWARNING! There are comments longer than 110 characters that will be ignored");
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

        //#CORE_END_INCLUDE: D705_VERIFY_DESC_LENGTH"



        private bool Internal_EXTRACT_CLINIC_STATUS()
        {


            try
            {

                // --> GET F020_DOCTOR_EXTRA <--

                fleF020_DOCTOR_EXTRA.GetData(GetDataOptions.IsOptional);
                // --> End GET F020_DOCTOR_EXTRA <--

                while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.WhileRetrieving())
                {
                    if (QDesign.NULL(CLMHDR_CLINIC_NBR_1_2.Value) == QDesign.NULL(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_CLINIC_NBR")))
                    {
                        X_CLINIC_STATUS.Value = fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetStringValue("DOC_CLINIC_NBR_STATUS");
                        break;
                    }
                }
                    


                Display(ref fldX_CLINIC_STATUS);

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



        private void fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2_Edit()
        {

            try
            {
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleDOC_CLINICS.ElementOwner("DOC_NBR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                m_strWhere.Append(" AND ").Append(fleDOC_CLINICS.ElementOwner("DOC_CLINIC_NBR")).Append(" <> 0");

                m_strOrderBy = new StringBuilder(" ORDER BY ");
                m_strOrderBy.Append("SEQ_NO");

                fleDOC_CLINICS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.IsOptional);

                bool clinic_found = false;
                while (fleDOC_CLINICS.WhileRetrieving())
                {
                    if (QDesign.NULL(FieldValue) == QDesign.NULL(fleDOC_CLINICS.GetDecimalValue("DOC_CLINIC_NBR")))
                    {
                        clinic_found = true;
                        break;
                    }
                }

                if (!clinic_found)
                {
                    ErrorMessage("INVALID CLINIC NBR for doctor");
                }



                //m_strWhere = new StringBuilder(" WHERE ");
                //m_strWhere.Append(" ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ");
                //m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                //m_strWhere.Append(" AND ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_CLINIC_NBR")).Append(" <> 0");

                //m_strOrderBy = new StringBuilder(" ORDER BY ");
                //m_strOrderBy.Append("SEQ_NO");

                //if (GetData(ref fleF020C_DOC_CLINIC_NEXT_BATCH_NBR, m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.IsOptional))
                //{
                //    bool clinic_found = false;
                //    while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.WhileRetrieving())
                //    {
                //        if (QDesign.NULL(FieldValue) == QDesign.NULL(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetDecimalValue("DOC_CLINIC_NBR")))
                //        {
                //            clinic_found = true;
                //            break;
                //        }
                //    }
                //    if (!clinic_found)
                //    {
                //        ErrorMessage("INVALID CLINIC NBR for doctor");
                //    }

                //}
//                fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.IsOptional);

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2_Process()
        {

            try
            {

                fleF002_SUSPEND_HDR.set_SetValue("SUSP_HDR_CLINIC_NBR", CLMHDR_CLINIC_NBR_1_2.Value);
                Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_CLINIC_NBR);
                Internal_EXTRACT_CLINIC_STATUS();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private void fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")) != QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_NBR_OHIP")))
                {
                    ErrorMessage("Entered doc nbr does not have the same doc ohip nbr");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_Process()
        {

            try
            {

                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_DOC_DEPT_ALPHA", QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"), 2));
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_DEPT_ALPHA);
                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_SPEC_CD")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD")) & QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_SPEC_CD")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2")) & QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_SPEC_CD")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3")))
                {
                    ErrorMessage("INVALID SPECIALTY CODE for doctor");
                }
                fleF002_SUSPEND_HDR.set_SetValue("SUSP_HDR_DOC_NBR", CLMHDR_DOC_NBR.Value);
                Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_DOC_NBR);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF002_SUSPEND_HDR_CLMHDR_DOC_SPEC_CD_Edit()
        {

            try
            {

                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData(GetDataOptions.IsOptional);
                // --> End GET F020_DOCTOR_MSTR <--
                if (QDesign.NULL(FieldValue) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD")) & QDesign.NULL(FieldValue) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_2")) & QDesign.NULL(FieldValue) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD_3")))
                {
                    ErrorMessage("INVALID SPECIALTY CODE for doctor");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_LOC_Edit()
        {

            try
            {
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF020L_DOC_LOCATIONS.ElementOwner("DOC_NBR")).Append(" = ");
                m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                m_strOrderBy = new StringBuilder(" ORDER BY ");
                m_strOrderBy.Append("SEQ_NO");

                fleF020L_DOC_LOCATIONS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.IsOptional);

                bool loc_found = false;
                while (fleF020L_DOC_LOCATIONS.WhileRetrieving())
                {
                    if (QDesign.NULL(FieldText) == QDesign.NULL(fleF020L_DOC_LOCATIONS.GetStringValue("DOC_LOC")))
                    {
                        loc_found = true;
                        break;
                    }
                }
                if (!loc_found)
                {
                    ErrorMessage("INVALID LOCATION CODE for doctor");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_DOC_DEPT_ALPHA_Edit()
        {

            try
            {

                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData(GetDataOptions.IsOptional);
                // --> End GET F020_DOCTOR_MSTR <--
                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DOC_DEPT_ALPHA")) != QDesign.NULL(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"), 2)))
                {
                    ErrorMessage("Wrong dept nbr for the doctor");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR_Input()
        {

            try
            {

                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 & 0 != (FieldText.Length))
                {
                    ErrorMessage("Cannot change MSG NBR for OHIP agent");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_MSG_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) != 0 & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_MSG_NBR")) != QDesign.NULL("00"))
                {
                    // --> GET F094_MSG_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF094_MSG_MSTR.ElementOwner("MSG_SUB_KEY_1")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("M"));
                    m_strWhere.Append(" And ").Append(fleF094_MSG_MSTR.ElementOwner("MSG_SUB_KEY_23")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_MSG_NBR")));

                    fleF094_MSG_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F094_MSG_MSTR <--
                    if (!AccessOk)
                    {
                        ErrorMessage("INVALID MSG NUMBER");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_REPRINT_FLAG_Input()
        {

            try
            {

                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 & 0 != FieldText.Length)
                {
                    ErrorMessage("Cannot change REPRINT FLAG for OHIP agent");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR_Input()
        {

            try
            {

                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 & 0 != FieldText.Length)
                {
                    ErrorMessage("Cannot change SUB NBR for OHIP agent");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_SUB_NBR_Process()
        {

            try
            {

                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_SUB_NBR")) == QDesign.NULL("0"))
                {
                    fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_FEE_COMPLEX", "0");
                }
                else
                {
                    if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_SUB_NBR")) == QDesign.NULL("1 "))
                    {
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_FEE_COMPLEX", "L");
                    }
                    else
                    {
                        if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_SUB_NBR")) == QDesign.NULL("2") | QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_SUB_NBR")) == QDesign.NULL("3"))
                        {
                            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_FEE_COMPLEX", "H");
                        }
                    }
                }
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_FEE_COMPLEX);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF002_SUSPEND_HDR_CLMHDR_AUTO_LOGOUT_Input()
        {

            try
            {

                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 & 0 != FieldText.Length)
                {
                    ErrorMessage("Cannot change AUTO LOGOUT for OHIP agent");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_FEE_COMPLEX_Input()
        {

            try
            {

                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 & 0 != FieldText.Length)
                {
                    ErrorMessage("CANNOT CHANGE FEE COMPLEX FOR OHIP AGENT");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA_Edit()
        {

            try
            {

                // --> GET F010_PAT_MSTR <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("KEY_PAT_MSTR")).Append(" = ");
                m_strWhere.Append(Common.StringToField((fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA"))));

                fleF010_PAT_MSTR.GetData(m_strWhere.ToString());
                // --> End GET F010_PAT_MSTR <--
                //Parent:CLMHDR_PAT_ACRONYM    'Parent:PAT_ACRONYM
                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_ACRONYM6") + fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_ACRONYM3")) != QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3")))
                {
                    Warning("CLMHDR and PATIENT ACRONYM are DIFFERENT");
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



        private void fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA_Process()
        {

            try
            {

                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_HEALTH_CARE_NBR", QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR")));
                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_HEALTH_CARE_VER", fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD"));
                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_HEALTH_CARE_PROV", fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD"));
                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_PAT_ACRONYM6", (fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3")).PadRight(9).Substring(0, 6));
                //Parent:CLMHDR_PAT_ACRONYM    'Parent:PAT_ACRONYM
                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_PAT_ACRONYM3", (fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3")).PadRight(9).Substring(6, 3));
                //Parent:CLMHDR_PAT_ACRONYM    'Parent:PAT_ACRONYM
                fleF002_SUSPEND_HDR.set_SetValue("SUSP_HDR_ACRONYM", fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3"));
                //Parent:PAT_ACRONYM
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_VER);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_PROV);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_PAT_ACRONYM);
                Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_ACRONYM);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_DTL_Click(object sender, System.EventArgs e)
        {

            try
            {
                CommandBindings.Remove(new CommandBinding(dsrDTL));
                CommandBindings.Remove(new CommandBinding(dsrADD));
                CommandBindings.Remove(new CommandBinding(dsrDES));
                CommandBindings.Remove(new CommandBinding(dsrIGN));
                CommandBindings.Remove(new CommandBinding(dsrUNIGN));
                CommandBindings.Remove(new CommandBinding(dsrIKEY));
                CommandBindings.Remove(new CommandBinding(dsrSTATUS));

                W_CLMHDR_DOC_OHIP_NBR.Value = fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_NBR_OHIP");
                W_CLMHDR_ACCOUNTING_NBR.Value = fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR");
                object[] arrRunscreen = { W_CLMHDR_DOC_OHIP_NBR, W_CLMHDR_ACCOUNTING_NBR, fleF002_SUSPEND_HDR };
                RunScreen(new Billing_D705A(), RunScreenModes.Find, ref arrRunscreen);
                fleF002_SUSPEND_HDR.PutData();
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_TOT_CLAIM_AR_OHIP);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_TOT_CLAIM_AR_OMA);

                Display(ref fldF002_SUSPEND_HDR_CLMHDR_MANUAL_REVIEW);

                dsrDTL.InputGestures.Add(new KeyGesture(Key.F2));
                CommandBindings.Add(new CommandBinding(dsrDTL, dsrDesigner_DTL_Click));
                dsrADD.InputGestures.Add(new KeyGesture(Key.F3));
                CommandBindings.Add(new CommandBinding(dsrADD, dsrDesigner_CORE_ADD_Click));
                dsrDES.InputGestures.Add(new KeyGesture(Key.F4));
                CommandBindings.Add(new CommandBinding(dsrDES, dsrDesigner_DES_Click));
                dsrIGN.InputGestures.Add(new KeyGesture(Key.F5));
                CommandBindings.Add(new CommandBinding(dsrIGN, dsrDesigner_IGN_Click));
                dsrUNIGN.InputGestures.Add(new KeyGesture(Key.F6));
                CommandBindings.Add(new CommandBinding(dsrUNIGN, dsrDesigner_UNIGN_Click));
                dsrIKEY.InputGestures.Add(new KeyGesture(Key.F7));
                CommandBindings.Add(new CommandBinding(dsrIKEY, dsrDesigner_IKEY_Click));
                dsrSTATUS.InputGestures.Add(new KeyGesture(Key.F8));
                CommandBindings.Add(new CommandBinding(dsrSTATUS, dsrDesigner_STATUS_Click));
            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_CORE_ADD_Click(object sender, System.EventArgs e)
        {

            try
            {
                CommandBindings.Remove(new CommandBinding(dsrDTL));
                CommandBindings.Remove(new CommandBinding(dsrADD));
                CommandBindings.Remove(new CommandBinding(dsrDES));
                CommandBindings.Remove(new CommandBinding(dsrIGN));
                CommandBindings.Remove(new CommandBinding(dsrUNIGN));
                CommandBindings.Remove(new CommandBinding(dsrIKEY));
                CommandBindings.Remove(new CommandBinding(dsrSTATUS));

                W_CLMHDR_DOC_OHIP_NBR.Value = fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_NBR_OHIP");
                W_CLMHDR_ACCOUNTING_NBR.Value = fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR");
                object[] arrRunscreen = { W_CLMHDR_DOC_OHIP_NBR, W_CLMHDR_ACCOUNTING_NBR };
                RunScreen(new Billing_D705B(), RunScreenModes.Find, ref arrRunscreen);

                dsrDTL.InputGestures.Add(new KeyGesture(Key.F2));
                CommandBindings.Add(new CommandBinding(dsrDTL, dsrDesigner_DTL_Click));
                dsrADD.InputGestures.Add(new KeyGesture(Key.F3));
                CommandBindings.Add(new CommandBinding(dsrADD, dsrDesigner_CORE_ADD_Click));
                dsrDES.InputGestures.Add(new KeyGesture(Key.F4));
                CommandBindings.Add(new CommandBinding(dsrDES, dsrDesigner_DES_Click));
                dsrIGN.InputGestures.Add(new KeyGesture(Key.F5));
                CommandBindings.Add(new CommandBinding(dsrIGN, dsrDesigner_IGN_Click));
                dsrUNIGN.InputGestures.Add(new KeyGesture(Key.F6));
                CommandBindings.Add(new CommandBinding(dsrUNIGN, dsrDesigner_UNIGN_Click));
                dsrIKEY.InputGestures.Add(new KeyGesture(Key.F7));
                CommandBindings.Add(new CommandBinding(dsrIKEY, dsrDesigner_IKEY_Click));
                dsrSTATUS.InputGestures.Add(new KeyGesture(Key.F8));
                CommandBindings.Add(new CommandBinding(dsrSTATUS, dsrDesigner_STATUS_Click));
            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_DES_Click(object sender, System.EventArgs e)
        {

            try
            {
                CommandBindings.Remove(new CommandBinding(dsrDTL));
                CommandBindings.Remove(new CommandBinding(dsrADD));
                CommandBindings.Remove(new CommandBinding(dsrDES));
                CommandBindings.Remove(new CommandBinding(dsrIGN));
                CommandBindings.Remove(new CommandBinding(dsrUNIGN));
                CommandBindings.Remove(new CommandBinding(dsrIKEY));
                CommandBindings.Remove(new CommandBinding(dsrSTATUS));

                W_CLMHDR_DOC_OHIP_NBR.Value = fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_NBR_OHIP");
                W_CLMHDR_ACCOUNTING_NBR.Value = fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR");
                object[] arrRunscreen = { W_CLMHDR_DOC_OHIP_NBR, W_CLMHDR_ACCOUNTING_NBR, fleF002_SUSPEND_HDR };
                RunScreen(new Billing_D705C(), RunScreenModes.Find, ref arrRunscreen);
                fleF002_SUSPEND_HDR.PutData();

                Display(ref fldF002_SUSPEND_HDR_CLMHDR_MANUAL_REVIEW);

                dsrDTL.InputGestures.Add(new KeyGesture(Key.F2));
                CommandBindings.Add(new CommandBinding(dsrDTL, dsrDesigner_DTL_Click));
                dsrADD.InputGestures.Add(new KeyGesture(Key.F3));
                CommandBindings.Add(new CommandBinding(dsrADD, dsrDesigner_CORE_ADD_Click));
                dsrDES.InputGestures.Add(new KeyGesture(Key.F4));
                CommandBindings.Add(new CommandBinding(dsrDES, dsrDesigner_DES_Click));
                dsrIGN.InputGestures.Add(new KeyGesture(Key.F5));
                CommandBindings.Add(new CommandBinding(dsrIGN, dsrDesigner_IGN_Click));
                dsrUNIGN.InputGestures.Add(new KeyGesture(Key.F6));
                CommandBindings.Add(new CommandBinding(dsrUNIGN, dsrDesigner_UNIGN_Click));
                dsrIKEY.InputGestures.Add(new KeyGesture(Key.F7));
                CommandBindings.Add(new CommandBinding(dsrIKEY, dsrDesigner_IKEY_Click));
                dsrSTATUS.InputGestures.Add(new KeyGesture(Key.F6));
                CommandBindings.Add(new CommandBinding(dsrSTATUS, dsrDesigner_STATUS_Click));

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_IGN_Click(object sender, System.EventArgs e)
        {

            try
            {

                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", CLMHDR_STATUS_IGNOR.Value);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_STATUS);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_UNIGN_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) == QDesign.NULL(CLMHDR_STATUS_IGNOR.Value))
                {
                    fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", UPDATED.Value);
                    Display(ref fldF002_SUSPEND_HDR_CLMHDR_STATUS);
                }
                else
                {
                    Warning("No `I`gnore flag has been set for this record");
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

        private void dsrDesigner_DEPT_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldX_PASSWORD);
                if (QDesign.NULL(X_PASSWORD.Value) == QDesign.NULL("yas") | QDesign.NULL(X_PASSWORD.Value) == QDesign.NULL("YAS"))
                {
                    Accept(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_DEPT_ALPHA);
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

        private void dsrDesigner_IKEY_Click(object sender, System.EventArgs e)
        {
            string sql = string.Empty;
            decimal recCount = 0;

            try
            {
                //Check if there are records
                sql = "SELECT COUNT(1) COUNT FROM " + SCHEMA.Value.Trim() + ".F002_SUSPEND_HDR WHERE CLMHDR_PAT_KEY_TYPE IN ('', 'O', '0')";
                fleF002_SUSPEND_HDR.GetData(true, sql, GetDataOptions.None);
                recCount = fleF002_SUSPEND_HDR.GetDecimalValue("COUNT");

                if (fleF002_SUSPEND_HDR.GetDecimalValue("COUNT") > 1)
                {
                    m_intPath = 6;
                    Mode = PageModeTypes.Find;
                    Find();
                    ApplicationState.Current.CorePage.CurrentRecordNumber = m_intCurrentRecordNumber;
                    PostFind();
                    DisplayFormatting();
                    Mode = PageModeTypes.Change;
                    ApplicationState.Current.CorePage.Page_Load();
                }
                else
                {
                    RaiseClearControls();
                    MessageBox.Show("No Records Found.");
                    ApplicationState.Current.CorePage.Mode = PageModeTypes.NoMode;
                    ApplicationState.Current.CorePage.Page_Load();
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

        private void dsrDesigner_STATUS_Click(object sender, System.EventArgs e)
        {
            string sql = string.Empty;
            decimal recCount = 0;

            try
            {
                //Check if there are records
                sql = "SELECT COUNT(1) COUNT FROM " + SCHEMA.Value.Trim() + ".F002_SUSPEND_HDR WHERE CLMHDR_STATUS = 'D'";
                fleF002_SUSPEND_HDR.GetData(true, sql, GetDataOptions.None);
                recCount = fleF002_SUSPEND_HDR.GetDecimalValue("COUNT");

                if (recCount >= 1)
                {
                    m_intPath = 7;
                    ApplicationState.Current.CorePage.Mode = PageModeTypes.Find;
                    Find();
                }
                else
                {
                    RaiseClearControls();
                    MessageBox.Show("No Records Found.");
                    ApplicationState.Current.CorePage.Mode = PageModeTypes.NoMode;
                    ApplicationState.Current.CorePage.Page_Load();
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

        private void fldF002_SUSPEND_HDR_CLMHDR_ADJ_CD_SUB_TYPE_Process()
        {

            try
            {

                // --> GET F073_CLIENT_DOC_MSTR <--

                fleF073_CLIENT_DOC_MSTR.GetData(GetDataOptions.IsOptional);
                // --> End GET F073_CLIENT_DOC_MSTR <--
                if (QDesign.NULL(fleF073_CLIENT_DOC_MSTR.GetStringValue("CLIENT_ID")) == QDesign.NULL("WEB") & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE")) != QDesign.NULL("W"))
                {
                    Warning("WARNING - f073 indicates doctor is `WEB`- this Source Code doesn`t match");
                }
                if (QDesign.NULL(fleF073_CLIENT_DOC_MSTR.GetStringValue("CLIENT_ID")) != QDesign.NULL("WEB") & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE")) == QDesign.NULL("W"))
                {
                    Warning("WARNING - f073 DOESN`T indicate doctor is `WEB`- this Source Code doesn`t match");
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

                if (AlteredRecord() & !NewRecord() & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_DELETE.Value) & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_IGNOR.Value))
                {
                    fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", UPDATED.Value);
                    Display(ref fldF002_SUSPEND_HDR_CLMHDR_STATUS);
                }
                if (QDesign.NULL(X_OLD_DIAG.Value) != QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DIAG_CD")))
                {
                    while (fleF002_DTL_UPDATE.WhileRetrieving())
                    {
                        fleF002_DTL_UPDATE.set_SetValue("CLMDTL_DIAG_CD", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DIAG_CD"));
                        fleF002_DTL_UPDATE.set_SetValue("CLMDTL_STATUS", CLMDTL_STATUS_UPDATED.Value);
                        fleF002_DTL_UPDATE.PutData();
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



        private void dsrDesigner_DIAG_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldF002_SUSPEND_HDR_CLMHDR_DIAG_CD_ALPHA);
                while (fleF002_DTL_UPDATE.WhileRetrieving())
                {
                    fleF002_DTL_UPDATE.set_SetValue("CLMDTL_DIAG_CD", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DIAG_CD"));
                    fleF002_DTL_UPDATE.set_SetValue("CLMDTL_STATUS", CLMDTL_STATUS_UPDATED.Value);
                    fleF002_DTL_UPDATE.PutData();
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


        protected override bool PostFind()
        {


            try
            {
                CLMHDR_DOC_NBR.Value = fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR").Substring(2,3);
                CLMHDR_CLINIC_NBR_1_2.Value = QDesign.NConvert(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR").Substring(0, 2));
                CLMHDR_PAT_ACRONYM.Value = fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_ACRONYM6") + fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_ACRONYM3");

                Internal_WARN_DESC_MAX_LENGTH();
                X_OLD_DIAG.Value = fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DIAG_CD");
                Internal_EXTRACT_CLINIC_STATUS();

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
                RequestPrompt(ref fldF002_SUSPEND_HDR_SUSP_HDR_DOC_NBR);
                if (m_blnPromptOK)
                {
                    RequestPrompt(ref fldF002_SUSPEND_HDR_SUSP_HDR_CLINIC_NBR);
                }
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF002_SUSPEND_HDR_SUSP_HDR_DOC_NBR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_OHIP);
                    if (m_blnPromptOK)
                    {
                        RequestPrompt(ref fldF002_SUSPEND_HDR_CLMHDR_ACCOUNTING_NBR);
                    }
                    if (m_blnPromptOK)
                    {
                        m_intPath = 3;
                    }
                    if (m_intPath == 0)
                    {
                        RequestPrompt(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_OHIP);
                        if (m_blnPromptOK)
                        {
                            m_intPath = 4;
                        }
                    }
                }
                if (m_intPath == 0)
                {
                    m_intPath = 5;
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
                Environment.SetEnvironmentVariable("LastConnectionString", Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings.ToString());
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString10";

                if (m_intPath == 1)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF002_SUSPEND_HDR.ElementOwner("SUSP_HDR_CLINIC_NBR"), fleF002_SUSPEND_HDR.GetDecimalValue("SUSP_HDR_CLINIC_NBR"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF002_SUSPEND_HDR.ElementOwner("SUSP_HDR_DOC_NBR"), fleF002_SUSPEND_HDR.GetDecimalValue("SUSP_HDR_DOC_NBR"), ref blnAddWhere));
                    m_strOrderBy = new StringBuilder(" ORDER BY CLMHDR_DOC_NBR, CLMHDR_PATIENT_SURNAME");
                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);

                }
                if (m_intPath == 2)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF002_SUSPEND_HDR.ElementOwner("SUSP_HDR_DOC_NBR"), fleF002_SUSPEND_HDR.GetStringValue("SUSP_HDR_DOC_NBR"), ref blnAddWhere));
                    m_strOrderBy = new StringBuilder(" ORDER BY CLMHDR_DOC_NBR, CLMHDR_PATIENT_SURNAME");
                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);

                }
                if (m_intPath == 3)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR"), fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_NBR_OHIP"), fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DOC_NBR_OHIP"), ref blnAddWhere));
                    m_strOrderBy = new StringBuilder(" ORDER BY CLMHDR_DOC_NBR, CLMHDR_PATIENT_SURNAME");
                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);

                }
                if (m_intPath == 4)
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_NBR_OHIP"), fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_NBR_OHIP"), ref blnAddWhere));
                    m_strOrderBy = new StringBuilder(" ORDER BY CLMHDR_DOC_NBR, CLMHDR_PATIENT_SURNAME");
                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);

                }
                if (m_intPath == 5)
                {
                    m_strWhere = new StringBuilder("");
                    m_strOrderBy = new StringBuilder(" ORDER BY CLMHDR_DOC_NBR, CLMHDR_PATIENT_SURNAME");
                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);
                    //fleF002_SUSPEND_HDR.GetData(GetDataOptions.CreateSubSelect | GetDataOptions.Sequential);
                }

                //Core 2020/02/11 - Called from dsrDesigner_IKEY_Click
                if (m_intPath == 6)
                {
                    m_strWhere = new StringBuilder(" WHERE CLMHDR_PAT_KEY_TYPE IN ('','O','0')");
                    m_strOrderBy = new StringBuilder(" ORDER BY CLMHDR_DOC_NBR, CLMHDR_PATIENT_SURNAME");
                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);
                }

                //Core 2020/02/11 - Called from dsrDesigner_STATUS_Click
                if (m_intPath == 7)
                {
                    m_strWhere = new StringBuilder(" WHERE CLMHDR_STATUS = 'D'");
                    m_strOrderBy = new StringBuilder(" ORDER BY CLMHDR_DOC_NBR, CLMHDR_PATIENT_SURNAME");
                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);
                }

                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");

                dsrDTL.InputGestures.Add(new KeyGesture(Key.F2));
                CommandBindings.Add(new CommandBinding(dsrDTL, dsrDesigner_DTL_Click));
                dsrADD.InputGestures.Add(new KeyGesture(Key.F3));
                CommandBindings.Add(new CommandBinding(dsrADD, dsrDesigner_CORE_ADD_Click));
                dsrDES.InputGestures.Add(new KeyGesture(Key.F4));
                CommandBindings.Add(new CommandBinding(dsrDES, dsrDesigner_DES_Click));
                dsrIGN.InputGestures.Add(new KeyGesture(Key.F5));
                CommandBindings.Add(new CommandBinding(dsrIGN, dsrDesigner_IGN_Click));
                dsrUNIGN.InputGestures.Add(new KeyGesture(Key.F6));
                CommandBindings.Add(new CommandBinding(dsrUNIGN, dsrDesigner_UNIGN_Click));
                dsrIKEY.InputGestures.Add(new KeyGesture(Key.F7));
                CommandBindings.Add(new CommandBinding(dsrIKEY, dsrDesigner_IKEY_Click));
                dsrSTATUS.InputGestures.Add(new KeyGesture(Key.F8));
                CommandBindings.Add(new CommandBinding(dsrSTATUS, dsrDesigner_STATUS_Click));

                return true;


            }
            catch (CustomApplicationException ex)
            {
                CommandBindings.Remove(new CommandBinding(dsrDTL));
                CommandBindings.Remove(new CommandBinding(dsrADD));
                CommandBindings.Remove(new CommandBinding(dsrDES));
                CommandBindings.Remove(new CommandBinding(dsrIGN));
                CommandBindings.Remove(new CommandBinding(dsrUNIGN));
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");

                throw ex;


            }
            catch (Exception ex)
            {
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }




        public override void PagePostProcess(PageArgs e)
        {

            try
            {
                Page.PageTitle = "Suspended **HEADER** Maintenance";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:32 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:32 AM
                fleF002_SUSPEND_DTL.PutData();
                //fleF002_SUSPEND_DTL.PutData();
                fleF002_SUSPEND_HDR.PutData();
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
        //# dsrDesigner_01_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:33 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:33 AM
                if (!fleF002_SUSPEND_HDR.NewRecord)
                {
                    Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_DOC_NBR);
                }
                else
                {
                    Accept(ref fldF002_SUSPEND_HDR_SUSP_HDR_DOC_NBR);
                }
                if (!fleF002_SUSPEND_HDR.NewRecord)
                {
                    Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_CLINIC_NBR);
                }
                else
                {
                    Accept(ref fldF002_SUSPEND_HDR_SUSP_HDR_CLINIC_NBR);
                }
                if (!fleF002_SUSPEND_HDR.NewRecord)
                {
                    Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_ACRONYM);
                }
                else
                {
                    Accept(ref fldF002_SUSPEND_HDR_SUSP_HDR_ACRONYM);
                }
                if (!fleF002_SUSPEND_HDR.NewRecord)
                {
                    Display(ref fldF002_SUSPEND_HDR_SUSP_HDR_ACCOUNTING_NBR);
                }
                else
                {
                    Accept(ref fldF002_SUSPEND_HDR_SUSP_HDR_ACCOUNTING_NBR);
                }
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
        //# dsrDesigner_03_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:33 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:33 AM
                Accept(ref fldF002_SUSPEND_HDR_CLMHDR_CLINIC_NBR_1_2);
                Display(ref fldX_CLINIC_STATUS);
                Accept(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR);
                Accept(ref fldF002_SUSPEND_HDR_CLMHDR_PAYROLL);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:33 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:33 AM
                if (!fleF002_SUSPEND_HDR.NewRecord)
                {
                    Display(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_OHIP);
                }
                else
                {
                    Accept(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_NBR_OHIP);
                }
                if (!fleF002_SUSPEND_HDR.NewRecord)
                {
                    Display(ref fldF002_SUSPEND_HDR_CLMHDR_ACCOUNTING_NBR);
                }
                else
                {
                    Accept(ref fldF002_SUSPEND_HDR_CLMHDR_ACCOUNTING_NBR);
                }
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
        //# dsrDesigner_27_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:33 AM
        //#-----------------------------------------
        private void dsrDesigner_27_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:33 AM
                Accept(ref fldF002_SUSPEND_HDR_CLMHDR_STATUS);
                Display(ref fldX_PASSWORD);
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
        //# dsrDesigner_15_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:33 AM
        //#-----------------------------------------
        private void dsrDesigner_15_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:33 AM
                Accept(ref fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_TYPE);
                Accept(ref fldF002_SUSPEND_HDR_CLMHDR_PAT_KEY_DATA);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_VER);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_PAT_ACRONYM);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_HEALTH_CARE_PROV);
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
