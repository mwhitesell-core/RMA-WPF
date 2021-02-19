
#region "Screen Comments"

// #> PROGRAM-ID.     D705A.QKS 
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : TO ALLOW CORRECTIONS TO SUSPENDED **DETAIL**  RECORDS
// MODIFICATION HISTORY
// DATE    WHO         DESCRIPTION
// 90/JUN/13  D.B.        - ORIGINAL
// 90/OCT/23  D.B.        - ADDED EDITS
// 90/NOV/22  D.B.        - ADDED FEE CALCULATION
// 91/MAR/01  B.E.        - ADDED DIAGNOSTIC CODE TO DETAIL RECORD
// 93/JUL/14  M.C.      - SMS 142
// - USE CLMDTL-DIAG-CD-ALPHA
// - USE CLMDTL-NBR-SERV-ALPHA
// 96/05/10   YAS         - ALLOW ACTIVITIES ADD AND DELETE
// 96/MAY/15  M.C.      - PDR 648, ALLOW ENTRY, INITIALIZE ITEMS
// CLMDTL-DOC-OHIP-NBR/ACCOUNTING-NBR
// PLUS SOME EDITS
// 1998/11/11   S.B.      - ADDED FILE  F002-SUSPEND-HDR  AS A MASTER.
// - ADDED THE ITEMS  CLMDTL-FEE-OMA  AND
// -  CLMDTL-FEE-OHIP  TO FILE  F002-SUSPEND-DTL .
// 1998/11/20   S.B.        - ADDED A PROCESS PROCEDURE FOR FIELD
//  clmdtl-amt-tech-billed  THAT POPULATES
// FIELDS  clmdtl-fee-oma  AND
//  clmdtl-fee-ohip  WITH THE VALUE ENTERED
// IN  clmdtl-amt-tech-billed .
// 1999/jan/28 B.E.           - y2k 
// 1999/11/08  M.C.      - initialize clmdtl-batch-nbr to be clmhdr-batch-nbr
// 1999/12/14  M.C.      - use clmdtl-nbr-serv instead of clmdtl-nbr-serv-alpha
// 2000/02/03  B.A.      - added code to set flags for new, altered or 
// canceled records (disabled delete activity) 
// 2000/02/15  B.A.           - adjusted subtotals of f002-suspend-hdr in
// del and undel designer proc.
// 2000/04/18  B.E./B.A.      - Modification to suspend records that were 
// uploaded from the RMA WEB system are tracked
// and when the actual claims (f002) are created,
// these modifications are sent back to the WEB
// to keep it in sync.
// Since the web  visits  are designed to have 
// happened on a single day, the date of the service
// is stored in the visit header. When the suspend
// detail records were created this service date
// was written into each detail record matching
// the flexibility that d001 allows within a claim
// of having several different service dates.
// In order to pass back the modifications made to
// to suspend details no changes are allowed to
// the service date.
// Code could be written that would take a date
// change on one detail and update all other details
// but it's not worth the effort -delete the 
// suspend claim and re-enter on web if wrong date).
// - note that web claims are identified by using
// the 3 digit doctor nbr in the header 
// (CLMHDR-DOC-NBR OF F002-SUSPEND-HDR) to 
// access f073-client-doc-mstr and testing if
// client-id =  WEB  
// 2000/04/18 B.E      - removed  consecutive services  cluster
// 2000/05/26 B.A.       - Added use file confidentially_check.use
// 2000/06/08 B.A.      - Added logic to subtotal amt-tech-billed from
// f002-suspend-dtl to f002-suspend-hdr
// 2000/06/12 B.E. - now allow change to date. The new data is then
// updated into all other details to keep them 
// consistent(WEB claims only). Diskette claims can
// have difference dates)
// 2000/06/13 B.E. - default OHIP amount to OMA amount entered
// 2000/06/14 M.C.       - set clmdtl-batch-nbr equal to clmhdr-batch-nbr 
// when user creates a new claim detail record
// 2000/06/21 B.E. - update of other details when service date changed
// fixed on 'newrecord' condition.    
// 2000/06/28 B.E. - added display of first 2 bytes of consecutive dates
// which can contains  BI  or  OP 
// 00/sep/12 B.E. - status made display only field.
// 00/sep/18 B.E. - add 'rep' designer routine to allow rapid change of 
// either diag-code or svc-date in all details recs
// 00/sep/14 B.E. - added 'des' call to d705c to maintain  manual review  records
// 00/sep/20 B.E. - as per yas's request, removed OK flag - automatically run
// update
// - added w-rep-oma-cd
// - added 'auto' to all input fields to speed up entry
// - reversed sequence of oma/ohip fees on screen
// 00/sep/25 B.E. - added warning if description text longer than what fits    
// into 5 claim description recs
// 00/sep/25 B.E. - don't allow changes to logically deleted records
// 00/oct/19 B.E. - changed logic that tested if the claim was a  WEB  claim.
// Originally it used f073 to read client-id. Now the value
// is tested in field clmhdr-adj-cd-sub-type of the header
// record (W=web, D=diskette)
// - f073 removed from pgm
// 2003/dec/10 A.A. - alpha doctor nbr
// 2011/jul/27 MC1  - transfer the codes from preupdate into postupdate for service date change
// so that you will not get 'record has been changed since you found it' and
// also it will save whatever user changes  in oma cd/diag cd/service date together
// 2012/jan/16 MC2  - do the correct pricing based on the service date
// - convert internal price_oma_cd subroutine to call price_previous or price_current
// - add x-sv-date for checking in price_oma_cd
// 2012/feb/09 MC3  - use clmdtl-sv-yy/mm/dd instead of clmdtl-sv-yy/mm/dd-alpha
// 2012/feb/15 MC4  - add w-nbr-serv in set_all_det_recs_to_same_svc_date subroutine
// 2000/02/03 begin
// ACTIVITIES FIND,CHANGE,ENTRY,DELETE

#endregion



using System;
using System.IO;
using System.Text;
using System.Windows;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;
using System.Data.SqlClient;
using System.Windows.Input;

namespace rma.Views
{

    partial class Billing_D705A : BasePage
    {

        #region " Form Designer Generated Code "

        RoutedCommand dsrDEL = new RoutedCommand();
        RoutedCommand dsrUNDEL = new RoutedCommand();
        RoutedCommand dsrREP = new RoutedCommand();
        RoutedCommand dsrDES = new RoutedCommand();

        public Billing_D705A()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D705A";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
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
            dsrDesigner_DEL.Click += dsrDesigner_DEL_Click;
            dsrDesigner_UNDEL.Click += dsrDesigner_UNDEL_Click;
            dsrDesigner_REP.Click += dsrDesigner_REP_Click;
            dsrDesigner_DES.Click += dsrDesigner_DES_Click;
            dsrDesigner_DEL.KeyUp += dsrDesigner_DEL_KeyUp;
            dsrDesigner_UNDEL.KeyUp += dsrDesigner_UNDEL_KeyUp;
            dsrDesigner_REP.KeyUp += dsrDesigner_REP_KeyUp;
            dsrDesigner_DES.KeyUp += dsrDesigner_DES_KeyUp;

            fldW_REP_OMA_CD.LookupOn += fldW_REP_OMA_CD_LookupOn;
            fldW_REP_DIAG_CD.LookupOn += fldW_REP_DIAG_CD_LookupOn;
            dtlF002_SUSPEND_DTL.EditClick += dtlF002_SUSPEND_DTL_EditClick;


            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       CONSTANTS_MSTR_REC_2.CONST_WCB_CURR InputScale: 5 OutputScale: 0


        }

        private void FldF002_SUSPEND_DTL_CLMDTL_OMA_CD_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry)  && fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.Text.Length >= 4)
                {
                    fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.Text.Length >= 1)
                {
                    fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.Text.Length >= 3)
                {
                    fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_NBR_SERV_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.Text.Length >= 2)
                {
                    fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_SV_YY_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (Page.Mode == PageModeTypes.Entry)
                    fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Text = "";
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_SV_YY_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Text.Length >= 4)
                {
                    fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_SV_MM_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (Page.Mode == PageModeTypes.Entry)
                    fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Text = "";
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_SV_MM_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Text.Length >= 2)
                {
                    fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_SV_DD_GotFocus(object sender, EventArgs e)
        {
            try
            {
                if (Page.Mode == PageModeTypes.Entry)
                    fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Text = "";
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_SV_DD_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Text.Length >= 2)
                {
                    fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED.Text.Length >= 6)
                {
                    fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP.Text.Length >= 7)
                {
                    fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldF002_SUSPEND_DTL_CLMDTL_FEE_OMA_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA.Text.Length >= 7)
                {
                    fldW_CLMDTL_SV_DAY_1.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldW_CLMDTL_SV_DAY_1_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if ((IsAppend || Page.Mode == PageModeTypes.Entry) && fldW_CLMDTL_SV_DAY_1.Text.Length >= 2)
                {
                    fldF002_SUSPEND_DTL_CLMDTL_STATUS.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void dsrDesigner_DEL_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_DEL.OnBlur(dsrDesigner_DEL, null);
                }
            }
            catch (Exception ex) { }
        }

        private void dsrDesigner_UNDEL_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_UNDEL.OnBlur(dsrDesigner_UNDEL, null);
                }
            }
            catch (Exception ex) { }
        }

        private void dsrDesigner_REP_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_REP.OnBlur(dsrDesigner_REP, null);
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

        private void FldF002_SUSPEND_DTL_CLMDTL_NBR_SERV_Input()
        {
            try
            {
                if ((Page.Mode == PageModeTypes.Change || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.Text.Length == 0)
                {
                    ErrorMessage("This field is Required", MessageTypes.Error);
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

        private void FldF002_SUSPEND_DTL_CLMDTL_SV_YY_Input()
        {
            try
            {
                if ((Page.Mode == PageModeTypes.Change || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Text.Length == 0)
                {
                    ErrorMessage("This field is Required", MessageTypes.Error);
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

        private void FldF002_SUSPEND_DTL_CLMDTL_SV_MM_Input()
        {
            try
            {
                if ((Page.Mode == PageModeTypes.Change || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Text.Length == 0)
                {
                    ErrorMessage("This field is Required", MessageTypes.Error);
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

        private void FldF002_SUSPEND_DTL_CLMDTL_SV_DD_Input()
        {
            try
            {
                if ((Page.Mode == PageModeTypes.Change || Page.Mode == PageModeTypes.Entry) && fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Text.Length == 0)
                {
                    ErrorMessage("This field is Required", MessageTypes.Error);
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

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_CLMHDR_DOC_OHIP_NBR = new CoreDecimal("W_CLMHDR_DOC_OHIP_NBR", 6, this);
            W_CLMHDR_ACCOUNTING_NBR = new CoreCharacter("W_CLMHDR_ACCOUNTING_NBR", 8, this, Common.cEmptyString);
            W_NBR_SERV = new CoreDecimal("W_NBR_SERV", 6, this);
            W_AMT = new CoreDecimal("W_AMT", 6, this);
            W_CONST = new CoreDecimal("W_CONST", 6, this);
            W_OMA_FEE = new CoreDecimal("W_OMA_FEE", 6, this);
            W_OHIP_FEE = new CoreDecimal("W_OHIP_FEE", 6, this);
            W_AMT_TECH = new CoreDecimal("W_AMT_TECH", 6, this);
            W_AMT_OMA = new CoreDecimal("W_AMT_OMA", 6, this);
            W_AMT_OHIP = new CoreDecimal("W_AMT_OHIP", 6, this);
            W_CHANGED_DATE = new CoreCharacter("W_CHANGED_DATE", 8, this, Common.cEmptyString);
            W_CHANGED_DATE_YY = new CoreCharacter("W_CHANGED_DATE_YY", 4, this, Common.cEmptyString);
            W_CHANGED_DATE_MM = new CoreCharacter("W_CHANGED_DATE_MM", 2, this, Common.cEmptyString);
            W_CHANGED_DATE_DD = new CoreCharacter("W_CHANGED_DATE_DD", 2, this, Common.cEmptyString);
            T_COUNT = new CoreDecimal("T_COUNT", 6, this);
            W_REP_OK = new CoreCharacter("W_REP_OK", 1, this, Common.cEmptyString);
            W_REP_DIAG_CD = new CoreCharacter("W_REP_DIAG_CD", 3, this, Common.cEmptyString);
            W_REP_SV_DATE = new CoreDate("W_REP_SV_DATE", this);
            W_REP_OMA_CD = new CoreCharacter("W_REP_OMA_CD", 4, this, Common.cEmptyString);
            W_OMA_CD = new CoreCharacter("W_OMA_CD", 4, this, Common.cEmptyString);
            W_REP_OMA_SUFF = new CoreCharacter("W_REP_OMA_SUFF", 1, this, Common.cEmptyString);
            W_OMA_SUFF = new CoreCharacter("W_OMA_SUFF", 1, this, Common.cEmptyString);
            X_NBR_DESC_RECS = new CoreDecimal("X_NBR_DESC_RECS", 6, this);
            X_WARN_FLAG = new CoreCharacter("X_WARN_FLAG", 1, this, Common.cEmptyString);
            X_OCC = new CoreDecimal("X_OCC", 6, this);
            X_REC_STATUS = new CoreCharacter("X_REC_STATUS", 1, this, Common.cEmptyString);
            X_MODE = new CoreCharacter("X_MODE", 9, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            DUMMY_CHECK_CHANGED_DATE = new CoreCharacter("DUMMY_CHECK_CHANGED_DATE", 1, this, Common.cEmptyString);
            X_SV_DATE = new CoreCharacter("X_SV_DATE", 8, this, Common.cEmptyString);
            fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Master, 0, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE2");
            fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 11, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE2");
            W_CLMDTL_SV_DAY_1 = new CoreCharacter("W_CLMDTL_SV_DAY_1", 2, this, fleF002_SUSPEND_DTL, Common.cEmptyString);
            fleF002_DESC_VERIFY = new SqlFileObject(this, FileTypes.Designer, 0, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_DESC", "F002_DESC_VERIFY", false, false, false, 0, "m_trnTRANS_UPDATE2");
            fleSUSP_DTL = new SqlFileObject(this, FileTypes.Designer, 0, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_DTL", "SUSP_DTL", false, false, false, 0, "m_trnTRANS_UPDATE2");
            fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF040_PRICING = new SqlFileObject(this, FileTypes.Designer, 0, "[101C].INDEXED", "F040_OMA_FEE_MSTR", "F040_PRICING", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCONSTANTS_MSTR_REC_2 = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "CONSTANTS_MSTR_REC_2", "", false, false, false, 0, "m_cnnQUERY");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF091_DIAG_CODES_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F091_DIAG_CODES_MSTR", "", false, false, false, 0, "m_cnnQUERY");

            CLMDTL_SV_DAY_1 = new CoreDecimal("CLMDTL_SV_DAY_1", 2, this, fleF002_SUSPEND_DTL, 0m);
            CLMDTL_SV_DAY_2 = new CoreDecimal("CLMDTL_SV_DAY_2", 2, this, fleF002_SUSPEND_DTL, 0m);
            CLMDTL_SV_DAY_3 = new CoreDecimal("CLMDTL_SV_DAY_3", 2, this, fleF002_SUSPEND_DTL, 0m);
            CLMDTL_SV_NBR_1 = new CoreDecimal("CLMDTL_SV_NBR_1", 1, this, fleF002_SUSPEND_DTL, 0m);
            CLMDTL_SV_NBR_2 = new CoreDecimal("CLMDTL_SV_NBR_2", 1, this, fleF002_SUSPEND_DTL, 0m);
            CLMDTL_SV_NBR_3 = new CoreDecimal("CLMDTL_SV_NBR_3", 1, this, fleF002_SUSPEND_DTL, 0m);

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
            fleF002_DESC_VERIFY.Access += fleF002_DESC_VERIFY_Access;            
            D_CONFID_FLAG.GetValue += D_CONFID_FLAG_GetValue;
            fleF040_OMA_FEE_MSTR.Access += fleF040_OMA_FEE_MSTR_Access;
            fleCONSTANTS_MSTR_REC_2.Access += fleCONSTANTS_MSTR_REC_2_Access;
            fleF020_DOCTOR_MSTR.Access += fleF020_DOCTOR_MSTR_Access;
            fleF091_DIAG_CODES_MSTR.Access += fleF091_DIAG_CODES_MSTR_Access;
            fleF002_SUSPEND_DTL.InitializeItems += fleF002_SUSPEND_DTL_InitializeItems;

            fleF002_SUSPEND_DTL.SetItemFinals += fleF002_SUSPEND_DTL_SetItemFinals;
            fleF002_SUSPEND_DTL.SumInto += fleF002_SUSPEND_DTL_SumInto;

            fleF020_DOCTOR_MSTR.AccessIsOptional = true;

            fleF002_SUSPEND_DTL.SumIntoFields = "CLMDTL_AMT_TECH_BILLED,CLMDTL_FEE_OMA,CLMDTL_FEE_OHIP";
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
            fleF002_DESC_VERIFY.Access -= fleF002_DESC_VERIFY_Access;
            D_CONFID_FLAG.GetValue -= D_CONFID_FLAG_GetValue;
            fleF040_OMA_FEE_MSTR.Access -= fleF040_OMA_FEE_MSTR_Access;
            fleCONSTANTS_MSTR_REC_2.Access -= fleCONSTANTS_MSTR_REC_2_Access;
            fleF020_DOCTOR_MSTR.Access -= fleF020_DOCTOR_MSTR_Access;
            fleF091_DIAG_CODES_MSTR.Access -= fleF091_DIAG_CODES_MSTR_Access;
            fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.LookupOn -= fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_LookupOn;
            fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.LookupOn -= fldF002_SUSPEND_DTL_CLMDTL_OMA_CD_LookupOn;
            fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.Output -= fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_Output;
            fldW_REP_OMA_CD.LookupOn -= fldW_REP_OMA_CD_LookupOn;
            fldW_REP_DIAG_CD.LookupOn -= fldW_REP_DIAG_CD_LookupOn;
            fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Edit -= fldF002_SUSPEND_DTL_CLMDTL_SV_YY_Edit;

            // GW2020 Jan 30
            fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Input -= fldF002_SUSPEND_DTL_CLMDTL_SV_DD_Input;

            fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Edit -= fldF002_SUSPEND_DTL_CLMDTL_SV_MM_Edit;
            fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Edit -= fldF002_SUSPEND_DTL_CLMDTL_SV_DD_Edit;
            fldDUMMY_CHECK_CHANGED_DATE.Edit -= fldDUMMY_CHECK_CHANGED_DATE_Edit;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_DEL.Click -= dsrDesigner_DEL_Click;
            dsrDesigner_UNDEL.Click -= dsrDesigner_UNDEL_Click;
            dsrDesigner_REP.Click -= dsrDesigner_REP_Click;
            dsrDesigner_DES.Click -= dsrDesigner_DES_Click;
            dtlF002_SUSPEND_DTL.EditClick -= dtlF002_SUSPEND_DTL_EditClick;
            fleF002_SUSPEND_DTL.InitializeItems -= fleF002_SUSPEND_DTL_InitializeItems;
            fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.Process -= fldF002_SUSPEND_DTL_CLMDTL_OMA_CD_Process;
            fldW_CLMDTL_SV_DAY_1.Process -= fldW_CLMDTL_SV_DAY_1_Process;
            fleF002_SUSPEND_DTL.SetItemFinals -= fleF002_SUSPEND_DTL_SetItemFinals;
            fleF002_SUSPEND_DTL.SumInto -= fleF002_SUSPEND_DTL_SumInto;

            fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_OMA_CD_KeyUp;
            fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF_KeyUp;
            fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_KeyUp;
            fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_NBR_SERV_KeyUp;
            fldF002_SUSPEND_DTL_CLMDTL_SV_YY.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_SV_YY_KeyUp;
            fldF002_SUSPEND_DTL_CLMDTL_SV_MM.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_SV_MM_KeyUp;
            fldF002_SUSPEND_DTL_CLMDTL_SV_DD.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_SV_DD_KeyUp;
            fldF002_SUSPEND_DTL_CLMDTL_SV_YY.GotFocus -= FldF002_SUSPEND_DTL_CLMDTL_SV_YY_GotFocus;
            fldF002_SUSPEND_DTL_CLMDTL_SV_MM.GotFocus -= FldF002_SUSPEND_DTL_CLMDTL_SV_MM_GotFocus;
            fldF002_SUSPEND_DTL_CLMDTL_SV_DD.GotFocus -= FldF002_SUSPEND_DTL_CLMDTL_SV_DD_GotFocus;
            fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED_KeyUp;
            fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP_KeyUp;
            fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_FEE_OMA_KeyUp;
            fldW_CLMDTL_SV_DAY_1.KeyUp -= FldW_CLMDTL_SV_DAY_1_KeyUp;
            fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.Input -= FldF002_SUSPEND_DTL_CLMDTL_NBR_SERV_Input;
            fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Input -= FldF002_SUSPEND_DTL_CLMDTL_SV_YY_Input;
            fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Input -= FldF002_SUSPEND_DTL_CLMDTL_SV_MM_Input;
            fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Input -= FldF002_SUSPEND_DTL_CLMDTL_SV_DD_Input;
            dsrDesigner_DEL.KeyUp -= dsrDesigner_DEL_KeyUp;
            dsrDesigner_UNDEL.KeyUp -= dsrDesigner_UNDEL_KeyUp;
            dsrDesigner_REP.KeyUp -= dsrDesigner_REP_KeyUp;
            dsrDesigner_DES.KeyUp -= dsrDesigner_DES_KeyUp;
            DisableFunctionKeys();

            Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE2 = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlTransaction m_trnTRANS_UPDATE2;
        private CoreDecimal W_CLMHDR_DOC_OHIP_NBR;
        private CoreCharacter W_CLMHDR_ACCOUNTING_NBR;
        private CoreDecimal W_NBR_SERV;
        private CoreDecimal W_AMT;
        private CoreDecimal W_CONST;
        private CoreDecimal W_OMA_FEE;
        private CoreDecimal W_OHIP_FEE;
        private CoreDecimal W_AMT_TECH;
        private CoreDecimal W_AMT_OMA;
        private CoreDecimal W_AMT_OHIP;
        private CoreCharacter W_CHANGED_DATE;
        private CoreCharacter W_CHANGED_DATE_YY;
        private CoreCharacter W_CHANGED_DATE_MM;
        private CoreCharacter W_CHANGED_DATE_DD;
        private CoreDecimal T_COUNT;
        private CoreCharacter W_REP_OK;
        private CoreCharacter W_REP_DIAG_CD;
        private CoreDate W_REP_SV_DATE;
        private CoreCharacter W_REP_OMA_CD;
        private CoreCharacter W_OMA_CD;
        private CoreCharacter W_REP_OMA_SUFF;
        private CoreCharacter W_OMA_SUFF;
        private CoreDecimal X_NBR_DESC_RECS;
        private CoreCharacter X_WARN_FLAG;
        private CoreDecimal X_OCC;
        private CoreCharacter X_REC_STATUS;
        private CoreCharacter X_MODE;
        private CoreCharacter DUMMY_CHECK_CHANGED_DATE;
        private CoreCharacter X_SV_DATE;

        private CoreDecimal CLMDTL_SV_DAY_1;
        private CoreDecimal CLMDTL_SV_DAY_2;
        private CoreDecimal CLMDTL_SV_DAY_3;
        private CoreDecimal CLMDTL_SV_NBR_1;
        private CoreDecimal CLMDTL_SV_NBR_2;
        private CoreDecimal CLMDTL_SV_NBR_3;

        //#CORE_BEGIN_INCLUDE: DEF_CLMHDR_STATUS"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:37 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:37 AM

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

        private SqlFileObject fleF002_SUSPEND_HDR;
        private SqlFileObject fleF002_SUSPEND_DTL;

        private void fleF002_SUSPEND_DTL_SetItemFinals()
        {
            try
            {
                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_CONSEC_DATES_R", CLMDTL_SV_NBR_1.Value.ToString() 
                    + CLMDTL_SV_DAY_1.Value.ToString().PadLeft(2, '0')
                    + CLMDTL_SV_NBR_2.Value.ToString()
                    + CLMDTL_SV_DAY_2.Value.ToString().PadLeft(2, '0')
                    + CLMDTL_SV_NBR_3.Value.ToString()
                    + CLMDTL_SV_DAY_3.Value.ToString().PadLeft(2, '0'));
                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_OMA_CD", fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.Text);
                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_OMA_SUFF", fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.Text);
                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_DIAG_CD", fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.Text);
            }
            catch (CustomApplicationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private void fleF002_SUSPEND_DTL_InitializeItems(bool Fixed)
        {

            try
            {
                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_DOC_OHIP_NBR", !Fixed, W_CLMHDR_DOC_OHIP_NBR.Value);
                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_ACCOUNTING_NBR", !Fixed, W_CLMHDR_ACCOUNTING_NBR.Value);
                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_BATCH_NBR", !Fixed, fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR"));
                if (!Fixed)
                    fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_STATUS", true, " ");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleF002_SUSPEND_DTL_SumInto(string Field, decimal Value, decimal OldValue)
        {

            try
            {
                switch (Field)
                {
                    case "CLMDTL_AMT_TECH_BILLED":
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_AMT_TECH_BILLED", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") + (Value - OldValue));
                        break;
                    case "CLMDTL_FEE_OMA":
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") + (Value - OldValue));
                        break;
                    case "CLMDTL_FEE_OHIP":
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + (Value - OldValue));
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

        private CoreCharacter W_CLMDTL_SV_DAY_1;
        private SqlFileObject fleF002_DESC_VERIFY;

        private void fleF002_DESC_VERIFY_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ").Append((W_CLMHDR_DOC_OHIP_NBR.Value));
                strText.Append(" AND ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ").Append(Common.StringToField(W_CLMHDR_ACCOUNTING_NBR.Value));

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

  

        private SqlFileObject fleSUSP_DTL;
        //#CORE_BEGIN_INCLUDE: CONFIDENTIALLY_CHECK"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:37 AM

        private DCharacter D_CONFID_FLAG = new DCharacter(1);
        private void D_CONFID_FLAG_GetValue(ref string Value)
        {

            try
            {
                string CurrentValue = string.Empty;
                if (((QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("632") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("302")) | (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("G362"))))
                {
                    CurrentValue = "Y";
                }
                else if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_CONFIDENTIAL_FLAG")) != QDesign.NULL("Y") & ((QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("099") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("290") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("291") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("292") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("295") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("296") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("297") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("298") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("299") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("634") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("635") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("640") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DIAG_CD")) == QDesign.NULL("895")) | (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("A777") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("A902") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("C777") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("E108") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("E753") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K015") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K018") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K021") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K051") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K052") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K053") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K061") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K620") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K623") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K624") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("K629") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("G100") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("R200") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("R872") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("S274") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("S436") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("S626") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("S738") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("S741") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("S752") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("S756") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("S768") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("S783") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("S785") | QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL("W777"))))
                {
                    CurrentValue = "R";
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

        //#CORE_END_INCLUDE: CONFIDENTIALLY_CHECK"

        private SqlFileObject fleF040_OMA_FEE_MSTR;

        private void fleF040_OMA_FEE_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("")).Append(" = ").Append(Common.StringToField(W_REP_OMA_CD.Value));


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

        private SqlFileObject fleF040_PRICING;
        private SqlFileObject fleCONSTANTS_MSTR_REC_2;

        private void fleCONSTANTS_MSTR_REC_2_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCONSTANTS_MSTR_REC_2.ElementOwner("CONST_REC_NBR")).Append(" = ").Append(("2"));

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

                strText.Append(" WHERE ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_DOC_OHIP_NBR")));

                strText.Append(" ORDER BY ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_OHIP_NBR"));
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

                strText.Append(" WHERE ").Append(fleF091_DIAG_CODES_MSTR.ElementOwner("")).Append(" = ").Append(Common.StringToField(W_REP_DIAG_CD.Value));


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


        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:38 AM

        protected TextBox fldF002_SUSPEND_DTL_CLMDTL_OMA_CD;
        protected TextBox fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF;
        protected TextBox fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA;
        protected TextBox fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV;
        protected TextBox fldF002_SUSPEND_DTL_CLMDTL_SV_YY;
        protected TextBox fldF002_SUSPEND_DTL_CLMDTL_SV_MM;
        protected TextBox fldF002_SUSPEND_DTL_CLMDTL_SV_DD;
        protected TextBox fldDUMMY_CHECK_CHANGED_DATE;
        protected TextBox fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED;
        protected TextBox fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP;
        protected TextBox fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA;
        protected TextBox fldW_CLMDTL_SV_DAY_1;

        protected ComboBox fldF002_SUSPEND_DTL_CLMDTL_STATUS;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:38 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {
         
            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_OMA_CD":
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_CD = (TextBox)DataListField;
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.LookupOn -= fldF002_SUSPEND_DTL_CLMDTL_OMA_CD_LookupOn;
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.LookupOn += fldF002_SUSPEND_DTL_CLMDTL_OMA_CD_LookupOn;
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.Process -= fldF002_SUSPEND_DTL_CLMDTL_OMA_CD_Process;
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.Process += fldF002_SUSPEND_DTL_CLMDTL_OMA_CD_Process;
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_OMA_CD_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.KeyUp += FldF002_SUSPEND_DTL_CLMDTL_OMA_CD_KeyUp;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_OMA_CD;
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.Bind(fleF002_SUSPEND_DTL);
                        break;
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_OMA_SUFF":
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF = (TextBox)DataListField;
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.KeyUp += FldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF_KeyUp;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF;
                        fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.Bind(fleF002_SUSPEND_DTL);
                        break;
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA":
                        fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA = (TextBox)DataListField;
                        fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.LookupOn -= fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_LookupOn;
                        fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.LookupOn += fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_LookupOn;
                        fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.KeyUp += FldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.Output -= fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_Output;
                        fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.Output += fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_Output;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA;
                        fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.Bind(fleF002_SUSPEND_DTL);
                        break;
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_NBR_SERV":
                        fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV = (TextBox)DataListField;
                        fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.Input -= FldF002_SUSPEND_DTL_CLMDTL_NBR_SERV_Input;
                        fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.Input += FldF002_SUSPEND_DTL_CLMDTL_NBR_SERV_Input;
                        fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_NBR_SERV_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.KeyUp += FldF002_SUSPEND_DTL_CLMDTL_NBR_SERV_KeyUp;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV;
                        fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.Bind(fleF002_SUSPEND_DTL);
                        break;
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_SV_YY":
                        fldF002_SUSPEND_DTL_CLMDTL_SV_YY = (TextBox)DataListField;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Input -= FldF002_SUSPEND_DTL_CLMDTL_SV_YY_Input;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Input += FldF002_SUSPEND_DTL_CLMDTL_SV_YY_Input;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Edit -= fldF002_SUSPEND_DTL_CLMDTL_SV_YY_Edit;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Edit += fldF002_SUSPEND_DTL_CLMDTL_SV_YY_Edit;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_YY.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_SV_YY_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_YY.KeyUp += FldF002_SUSPEND_DTL_CLMDTL_SV_YY_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_YY.GotFocus -= FldF002_SUSPEND_DTL_CLMDTL_SV_YY_GotFocus;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_YY.GotFocus += FldF002_SUSPEND_DTL_CLMDTL_SV_YY_GotFocus;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_SV_YY;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Bind(fleF002_SUSPEND_DTL);
                        break;
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_SV_MM":
                        fldF002_SUSPEND_DTL_CLMDTL_SV_MM = (TextBox)DataListField;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Input -= FldF002_SUSPEND_DTL_CLMDTL_SV_MM_Input;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Input += FldF002_SUSPEND_DTL_CLMDTL_SV_MM_Input;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Edit -= fldF002_SUSPEND_DTL_CLMDTL_SV_MM_Edit;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Edit += fldF002_SUSPEND_DTL_CLMDTL_SV_MM_Edit;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_MM.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_SV_MM_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_MM.KeyUp += FldF002_SUSPEND_DTL_CLMDTL_SV_MM_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_MM.GotFocus -= FldF002_SUSPEND_DTL_CLMDTL_SV_MM_GotFocus;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_MM.GotFocus += FldF002_SUSPEND_DTL_CLMDTL_SV_MM_GotFocus;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_SV_MM;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Bind(fleF002_SUSPEND_DTL);
                        break;
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_SV_DD":
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD = (TextBox)DataListField;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Input -= FldF002_SUSPEND_DTL_CLMDTL_SV_DD_Input;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Input += FldF002_SUSPEND_DTL_CLMDTL_SV_DD_Input;

                        // GW2020 Jan 30
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Input -= fldF002_SUSPEND_DTL_CLMDTL_SV_DD_Input;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Input += fldF002_SUSPEND_DTL_CLMDTL_SV_DD_Input;

                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Edit -= fldF002_SUSPEND_DTL_CLMDTL_SV_DD_Edit;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Edit += fldF002_SUSPEND_DTL_CLMDTL_SV_DD_Edit;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_SV_DD_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.KeyUp += FldF002_SUSPEND_DTL_CLMDTL_SV_DD_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.GotFocus -= FldF002_SUSPEND_DTL_CLMDTL_SV_DD_GotFocus;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.GotFocus += FldF002_SUSPEND_DTL_CLMDTL_SV_DD_GotFocus;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_SV_DD;
                        fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Bind(fleF002_SUSPEND_DTL);
                        break;
                    case "FLDGRDDUMMY_CHECK_CHANGED_DATE":
                        fldDUMMY_CHECK_CHANGED_DATE = (TextBox)DataListField;

                        // GW2020. Jan 29. Commenrted out
                        fldDUMMY_CHECK_CHANGED_DATE.Edit -= fldDUMMY_CHECK_CHANGED_DATE_Edit;
                        fldDUMMY_CHECK_CHANGED_DATE.Edit += fldDUMMY_CHECK_CHANGED_DATE_Edit;

                        CoreField = fldDUMMY_CHECK_CHANGED_DATE;
                        fldDUMMY_CHECK_CHANGED_DATE.Bind(DUMMY_CHECK_CHANGED_DATE);
                        break;
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED":
                        fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED = (TextBox)DataListField;
                        fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED.KeyUp += FldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED_KeyUp;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED;
                        fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED.Bind(fleF002_SUSPEND_DTL);
                        break;
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_FEE_OHIP":
                        fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP = (TextBox)DataListField;
                        fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP.KeyUp += FldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP_KeyUp;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP;
                        fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP.Bind(fleF002_SUSPEND_DTL);
                        break;
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_FEE_OMA":
                        fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA = (TextBox)DataListField;
                        fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA.KeyUp -= FldF002_SUSPEND_DTL_CLMDTL_FEE_OMA_KeyUp;
                        fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA.KeyUp += FldF002_SUSPEND_DTL_CLMDTL_FEE_OMA_KeyUp;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA;
                        fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA.Bind(fleF002_SUSPEND_DTL);
                        break;
                    case "FLDGRDW_CLMDTL_SV_DAY_1":
                        fldW_CLMDTL_SV_DAY_1 = (TextBox)DataListField;
                        fldW_CLMDTL_SV_DAY_1.Process -= fldW_CLMDTL_SV_DAY_1_Process;
                        fldW_CLMDTL_SV_DAY_1.Process += fldW_CLMDTL_SV_DAY_1_Process;
                        fldW_CLMDTL_SV_DAY_1.KeyUp -= FldW_CLMDTL_SV_DAY_1_KeyUp;
                        fldW_CLMDTL_SV_DAY_1.KeyUp += FldW_CLMDTL_SV_DAY_1_KeyUp;
                        CoreField = fldW_CLMDTL_SV_DAY_1;
                        fldW_CLMDTL_SV_DAY_1.Bind(W_CLMDTL_SV_DAY_1);
                        break;
                    case "FLDGRDF002_SUSPEND_DTL_CLMDTL_STATUS":
                        fldF002_SUSPEND_DTL_CLMDTL_STATUS = (ComboBox)DataListField;
                        CoreField = fldF002_SUSPEND_DTL_CLMDTL_STATUS;
                        fldF002_SUSPEND_DTL_CLMDTL_STATUS.Bind(fleF002_SUSPEND_DTL);
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
                dtlF002_SUSPEND_DTL.OccursWithFile = fleF002_SUSPEND_DTL;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:38 AM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {

            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.GetSqlConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_cnnTRANS_UPDATE2 = new SqlConnection(Common.ConnectionStringDecrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString10"]));
                m_cnnTRANS_UPDATE2.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
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
            fleF002_DESC_VERIFY.Transaction = m_trnTRANS_UPDATE2;
            fleSUSP_DTL.Transaction = m_trnTRANS_UPDATE2;
            fleF040_PRICING.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:38 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF040_OMA_FEE_MSTR.Connection = m_cnnQUERY;
                fleCONSTANTS_MSTR_REC_2.Connection = m_cnnQUERY;
                fleF020_DOCTOR_MSTR.Connection = m_cnnQUERY;
                fleF091_DIAG_CODES_MSTR.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF002_DESC_VERIFY.Dispose();
                fleSUSP_DTL.Dispose();
                fleF040_OMA_FEE_MSTR.Dispose();
                fleF040_PRICING.Dispose();
                fleCONSTANTS_MSTR_REC_2.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
                fleF091_DIAG_CODES_MSTR.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:37 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:37 AM
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_OHIP_NBR);
                Display(ref fldW_REP_DIAG_CD);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_ACCOUNTING_NBR);
                Display(ref fldW_REP_SV_DATE);
                Display(ref fldW_REP_OMA_CD);
                Display(ref fldW_REP_OMA_SUFF);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:37 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:37 AM
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_OHIP_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_ACCOUNTING_NBR);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:38 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF002_SUSPEND_HDR_CLMHDR_DOC_OHIP_NBR.Bind(fleF002_SUSPEND_HDR);
                fldW_REP_DIAG_CD.Bind(W_REP_DIAG_CD);
                fldF002_SUSPEND_HDR_CLMHDR_ACCOUNTING_NBR.Bind(fleF002_SUSPEND_HDR);
                fldW_REP_SV_DATE.Bind(W_REP_SV_DATE);
                fldW_REP_OMA_CD.Bind(W_REP_OMA_CD);
                fldW_REP_OMA_SUFF.Bind(W_REP_OMA_SUFF);

            }
            catch (CustomApplicationException ex)
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



        private void fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_LookupOn()
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




        private void fldF002_SUSPEND_DTL_CLMDTL_OMA_CD_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ").Append(Common.StringToField(QDesign.Substring(FieldText, 1, 1)));
                strSQL.Append(" AND ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ").Append(Common.StringToField(QDesign.Substring(FieldText, 2, 3)));

                fleF040_OMA_FEE_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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




        private void fldW_REP_OMA_CD_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ").Append(Common.StringToField(QDesign.Substring(FieldText, 1, 1)));
                strSQL.Append(" AND ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ").Append(Common.StringToField(QDesign.Substring(FieldText, 2, 3)));

                fleF040_OMA_FEE_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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




        private void fldW_REP_DIAG_CD_LookupOn()
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



        protected override object SetFieldDefaults(string Name)
        {


            try
            {
                switch (Name)
                {
                    case "W_REP_OMA_SUFF":
                        return " ";
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
                SaveReceivingParams(W_CLMHDR_DOC_OHIP_NBR, W_CLMHDR_ACCOUNTING_NBR, fleF002_SUSPEND_HDR);


            }
            catch (CustomApplicationException ex)
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
                Receiving(W_CLMHDR_DOC_OHIP_NBR, W_CLMHDR_ACCOUNTING_NBR, fleF002_SUSPEND_HDR);


            }
            catch (CustomApplicationException ex)
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


        private void fldF002_SUSPEND_DTL_CLMDTL_OMA_CD_Process()
        {

            try
            {

                if (NewRecord())
                {
                    fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_STATUS", CLMDTL_STATUS_NEW.Value);
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



        private void fldW_CLMDTL_SV_DAY_1_Process()
        {

            try
            {

                if (QDesign.NULL(W_CLMDTL_SV_DAY_1.Value) != QDesign.NULL("  "))
                {
                    if (QDesign.NULL(W_CLMDTL_SV_DAY_1.Value) != QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_SV_DAY_ALPHA_1")))
                    {
                        fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_SV_DAY_ALPHA_1", W_CLMDTL_SV_DAY_1.Value);
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


        private bool Internal_PRICE_PREVIOUS()
        {
            try
            {
                W_OMA_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_PREV_A_FEE_1") / 10;
                W_OHIP_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_PREV_H_FEE_1") / 10;
                W_AMT_TECH.Value = 0;
                if (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("CV") | ((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("NM") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DR") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("PF") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DU")) & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("B")) | (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP") & (QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("A") | QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("M"))) | (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("CP") & (QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("A") | QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("M"))) | (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DT") & (QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("A") | QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("M"))))
                {
                    W_OMA_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_PREV_A_FEE_1") / 10;
                    W_OHIP_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_PREV_H_FEE_1") / 10;
                }
                if (((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("NM") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DR") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("PF") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DU")) & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("C")))
                {
                    W_OMA_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_PREV_A_FEE_2") / 10;
                    W_OHIP_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_PREV_H_FEE_2") / 10;
                }
                if (((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("NM") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DR") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("PF") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DU")) & (QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("A") | QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("M"))))
                {
                    W_OMA_FEE.Value = (fleF040_PRICING.GetDecimalValue("FEE_PREV_A_FEE_1") + fleF040_PRICING.GetDecimalValue("FEE_PREV_A_FEE_2")) / 10;
                    W_OHIP_FEE.Value = (fleF040_PRICING.GetDecimalValue("FEE_PREV_H_FEE_1") + fleF040_PRICING.GetDecimalValue("FEE_PREV_H_FEE_2")) / 10;
                }
                if (((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("CP") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DT") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP")) & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("C") & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD")) == 0))
                {
                    W_OMA_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_REG_A_PREV");
                    W_OHIP_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_REG_H_PREV");

                    //Core Added 2020/03/16 - Multiply value by .50 (E400) or .75 (E401)
                    if (W_OMA_CD.Value == "E400")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .5m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .5m;
                    }
                    else if (W_OMA_CD.Value == "E401")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .75m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .75m;
                    }
                }

                if (((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("CP") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DT") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP")) & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("C") & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD")) != 0))
                {
                    W_OMA_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_CERT_A_PREV");
                    W_OHIP_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_CERT_H_PREV");

                    //Core Added 2020/03/16 - Multiply value by .50 (E400) or .75 (E401)
                    if (W_OMA_CD.Value == "E400")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .5m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .5m;
                    }
                    else if (W_OMA_CD.Value == "E401")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .75m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .75m;
                    }
                }

                if (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP") & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("B"))
                {
                    W_OMA_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_ASST_A_PREV");
                    W_OHIP_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_ASST_H_PREV");

                    //Core Added 2020/03/16 - Multiply value by .50 (E400) or .75 (E401)
                    if (W_OMA_CD.Value == "E400")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .5m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .5m;
                    }
                    else if (W_OMA_CD.Value == "E401")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .75m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .75m;
                    }
                }

                if (((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("CP") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DT") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP")) & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("C")))
                {
                    W_OMA_FEE.Value = W_OMA_FEE.Value + (W_OMA_FEE.Value * fleF040_PRICING.GetDecimalValue("FEE_PREV_A_ANAE"));
                    W_OHIP_FEE.Value = W_OHIP_FEE.Value + (W_OHIP_FEE.Value * fleF040_PRICING.GetDecimalValue("FEE_PREV_H_ANAE"));
                }
                if (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP") & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("B"))
                {
                    W_OMA_FEE.Value = W_OMA_FEE.Value + (W_OMA_FEE.Value * fleF040_PRICING.GetDecimalValue("FEE_PREV_A_ASST")) / 10;
                    W_OHIP_FEE.Value = W_OHIP_FEE.Value + (W_OHIP_FEE.Value * fleF040_PRICING.GetDecimalValue("FEE_PREV_H_ASST")) / 10;
                }
                W_AMT_OMA.Value = W_OMA_FEE.Value * W_NBR_SERV.Value;
                W_AMT_OHIP.Value = W_OHIP_FEE.Value * W_NBR_SERV.Value;
                if (QDesign.NULL(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AGENT_CD")) == 9)
                {
                    W_AMT_OHIP.Value = W_AMT_OHIP.Value * fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_WCB_PREV");
                    W_AMT_OMA.Value = W_AMT_OHIP.Value * fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_WCB_PREV");
                }
                if (QDesign.NULL(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AGENT_CD")) == 4 | QDesign.NULL(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AGENT_CD")) == 6)
                {
                    W_AMT_OHIP.Value = W_AMT_OMA.Value;
                }
                if ((W_OMA_CD.Value != "E400" && W_OMA_CD.Value != "E401") && QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_TECH_IND")) == QDesign.NULL("Y") | QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("B"))
                {
                    W_AMT_TECH.Value = W_AMT_OHIP.Value;
                }
                if ((W_OMA_CD.Value != "E400" && W_OMA_CD.Value != "E401") && QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("NM") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DR") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DU") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("PF"))
                {
                    W_AMT_TECH.Value = (fleF040_PRICING.GetDecimalValue("FEE_PREV_A_FEE_1") / 10) * (W_AMT_OHIP.Value / (fleF040_PRICING.GetDecimalValue("FEE_PREV_A_FEE_1") + fleF040_PRICING.GetDecimalValue("FEE_PREV_A_FEE_2")) / 10);
                }
                if (QDesign.NULL(D_CONFID_FLAG.Value) == QDesign.NULL("Y"))
                {
                    fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_CONFIDENTIAL_FLAG", "Y");
                }
                if (QDesign.NULL(D_CONFID_FLAG.Value) == QDesign.NULL("R") & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_CONFIDENTIAL_FLAG")) != QDesign.NULL("Y"))
                {
                    fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_CONFIDENTIAL_FLAG", "R");
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


        private bool Internal_PRICE_CURRENT()
        {


            try
            {
                W_OMA_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_CURR_A_FEE_1") / 10;
                W_OHIP_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_CURR_H_FEE_1") / 10;
                W_AMT_TECH.Value = 0;

                if (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("CV") | ((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("NM") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DR") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("PF") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DU")) & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("B")) | (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP") & (QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("A") | QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("M"))) | (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("CP") & (QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("A") | QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("M"))) | (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DT") & (QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("A") | QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("M"))))
                {
                    W_OMA_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_CURR_A_FEE_1") / 10;
                    W_OHIP_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_CURR_H_FEE_1") / 10;
                }

                if (((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("NM") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DR") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("PF") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DU")) & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("C")))
                {
                    W_OMA_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_CURR_A_FEE_2") / 10;
                    W_OHIP_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_CURR_H_FEE_2") / 10;
                }

                if (((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("NM") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DR") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("PF") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DU")) & (QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("A") | QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("M"))))
                {
                    W_OMA_FEE.Value = (fleF040_PRICING.GetDecimalValue("FEE_CURR_A_FEE_1") + fleF040_PRICING.GetDecimalValue("FEE_CURR_A_FEE_2")) / 10;
                    W_OHIP_FEE.Value = (fleF040_PRICING.GetDecimalValue("FEE_CURR_H_FEE_1") + fleF040_PRICING.GetDecimalValue("FEE_CURR_H_FEE_2")) / 10;
                }

                if (((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("CP") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DT") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP")) & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("C") & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD")) == 0))
                {
                    W_OMA_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_REG_A_CURR");
                    W_OHIP_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_REG_H_CURR");

                    //Core Added 2020/03/16 - Multiply value by .50 (E400) or .75 (E401)
                    if (W_OMA_CD.Value == "E400")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .5m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .5m;
                    }
                    else if (W_OMA_CD.Value == "E401")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .75m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .75m;
                    }
                }

                if (((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("CP") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DT") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP")) & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("C") & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SPEC_CD")) != 0))
                {
                    W_OMA_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_CERT_A_CURR");
                    W_OHIP_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_CERT_H_CURR");

                    //Core Added 2020/03/16 - Multiply value by .50 (E400) or .75 (E401)
                    if (W_OMA_CD.Value == "E400")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .5m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .5m;
                    }
                    else if (W_OMA_CD.Value == "E401")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .75m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .75m;
                    }
                }

                if (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP") & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("B"))
                {
                    W_OMA_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_ASST_A_CURR");
                    W_OHIP_FEE.Value = fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_ASST_H_CURR");

                    //Core Added 2020/03/16 - Multiply value by .50 (E400) or .75 (E401)
                    if (W_OMA_CD.Value == "E400")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .5m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .5m;
                    }
                    else if (W_OMA_CD.Value == "E401")
                    {
                        W_OMA_FEE.Value = W_OMA_FEE.Value * .75m;
                        W_OHIP_FEE.Value = W_OHIP_FEE.Value * .75m;
                    }
                }

                if (((QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("CP") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DT") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP")) & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("C")))
                {
                    W_OMA_FEE.Value = W_OMA_FEE.Value + (W_OMA_FEE.Value * fleF040_PRICING.GetDecimalValue("FEE_CURR_A_ANAE"));
                    W_OHIP_FEE.Value = W_OHIP_FEE.Value + (W_OHIP_FEE.Value * fleF040_PRICING.GetDecimalValue("FEE_CURR_H_ANAE"));
                }

                if (QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("SP") & QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("B"))
                {
                    W_OMA_FEE.Value = W_OMA_FEE.Value + (W_OMA_FEE.Value * fleF040_PRICING.GetDecimalValue("FEE_CURR_A_ASST")) / 10;
                    W_OHIP_FEE.Value = W_OHIP_FEE.Value + (W_OHIP_FEE.Value * fleF040_PRICING.GetDecimalValue("FEE_CURR_H_ASST")) / 10;
                }

                W_AMT_OMA.Value = W_OMA_FEE.Value * W_NBR_SERV.Value;
                W_AMT_OHIP.Value = W_OHIP_FEE.Value * W_NBR_SERV.Value;

                if (QDesign.NULL(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AGENT_CD")) == 9)
                {
                    W_AMT_OHIP.Value = W_AMT_OHIP.Value * fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_WCB_CURR");
                    W_AMT_OMA.Value = W_AMT_OHIP.Value * fleCONSTANTS_MSTR_REC_2.GetDecimalValue("CONST_WCB_CURR");
                }

                if (QDesign.NULL(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AGENT_CD")) == 4 | QDesign.NULL(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AGENT_CD")) == 6)
                {
                    W_AMT_OHIP.Value = W_AMT_OMA.Value;
                }

                //Core 2020/04/03 - According to RMA, the technical amount should be zero for all OMA codes.
                //if ((W_OMA_CD.Value != "E400" && W_OMA_CD.Value != "E401") && QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_TECH_IND")) == QDesign.NULL("Y") | QDesign.NULL(W_OMA_SUFF.Value) == QDesign.NULL("B"))
                //{
                //    W_AMT_TECH.Value = W_AMT_OHIP.Value;
                //}

                //if ((W_OMA_CD.Value != "E400" && W_OMA_CD.Value != "E401") && QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("NM") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DR") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DU") | QDesign.NULL(fleF040_PRICING.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("PF"))
                //{
                //    W_AMT_TECH.Value = (fleF040_PRICING.GetDecimalValue("FEE_CURR_A_FEE_1") / 10) * (W_AMT_OHIP.Value / (fleF040_PRICING.GetDecimalValue("FEE_CURR_A_FEE_1") + fleF040_PRICING.GetDecimalValue("FEE_CURR_A_FEE_2")) / 10);
                //}

                if (QDesign.NULL(D_CONFID_FLAG.Value) == QDesign.NULL("Y"))
                {
                    fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_CONFIDENTIAL_FLAG", "Y");
                }

                if (QDesign.NULL(D_CONFID_FLAG.Value) == QDesign.NULL("R") & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_CONFIDENTIAL_FLAG")) != QDesign.NULL("Y"))
                {
                    fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_CONFIDENTIAL_FLAG", "R");
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

        private bool Internal_E400_E401(string OMA_CODE, bool CURRENT)
        {
            decimal percentage = 1;
            try
            {
                if (OMA_CODE == "E400")
                {
                    percentage = 0.5m;
                }
                else
                {
                    percentage = .75m;
                }

                if (fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.Text == "A" || fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.Text == "C")
                {
                    if (CURRENT == true)
                    {
                        W_OMA_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_CURR_A_FEE_1") / 10;
                        W_OHIP_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_CURR_H_FEE_1") / 10;
                    }
                    else
                    {
                        W_OMA_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_PREV_A_FEE_1") / 10;
                        W_OHIP_FEE.Value = fleF040_PRICING.GetDecimalValue("FEE_PREV_H_FEE_1") / 10;
                    }
                }

                //W_AMT_OMA.Value = W_OMA_FEE.Value * W_NBR_SERV.Value * percentage;
                //W_AMT_OHIP.Value = W_OHIP_FEE.Value * W_NBR_SERV.Value * percentage;
                W_AMT_TECH.Value = 0;

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

        private bool Internal_PRICE_OMA_CD()
        {


            try
            {

                // --> GET F040_PRICING <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF040_PRICING.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                m_strWhere.Append(Common.StringToField(W_OMA_CD.Value.PadRight(4,' ').Substring(0,1)));
                m_strWhere.Append(" AND  ").Append(fleF040_PRICING.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                m_strWhere.Append(Common.StringToField(W_OMA_CD.Value.PadRight(4, ' ').Substring(1)));

                fleF040_PRICING.GetData(m_strWhere.ToString());
                // --> End GET F040_PRICING <--
                if (string.Compare(QDesign.NULL(X_SV_DATE.Value), QDesign.NULL(fleF040_PRICING.GetDecimalValue("FEE_DATE_YY").ToString().PadLeft(4, '0') + fleF040_PRICING.GetDecimalValue("FEE_DATE_MM").ToString().PadLeft(2, '0') + fleF040_PRICING.GetDecimalValue("FEE_DATE_DD").ToString().PadLeft(2, '0'))) < 0)
                {
                    Internal_PRICE_PREVIOUS();

                    ////Core Added 2020/03/12
                    //if (W_OMA_CD.Value == "E400" || W_OMA_CD.Value == "E401")
                    //{
                    //    Internal_E400_E401(W_OMA_CD.Value, false);
                    //}
                }
                else
                {
                    Internal_PRICE_CURRENT();

                    ////Core Added 2020/03/12
                    //if (W_OMA_CD.Value == "E400" || W_OMA_CD.Value == "E401")
                    //{
                    //    Internal_E400_E401(W_OMA_CD.Value, true);
                    //}
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


        private bool Internal_SET_ALL_DET_RECS_TO_REP_VALUES()
        {


            try
            {
                while (fleF002_SUSPEND_DTL.For())
                {
                    if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_DELETE.Value))
                    {
                        if (QDesign.NULL(W_REP_DIAG_CD.Value) != QDesign.NULL(" "))
                        {
                            fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA.Text = W_REP_DIAG_CD.Value;
                        }
                        if (QDesign.NULL(W_REP_SV_DATE.Value) != 0)
                        {
                            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_SV_YY", (QDesign.ASCII(W_REP_SV_DATE.Value, 8)).PadRight(8).Substring(0, 4));
                            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_SV_MM", (QDesign.ASCII(W_REP_SV_DATE.Value, 8)).PadRight(8).Substring(4, 2));
                            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_SV_DD", (QDesign.ASCII(W_REP_SV_DATE.Value, 8)).PadRight(8).Substring(6, 2));
                        }
                        if (QDesign.NULL(W_REP_OMA_CD.Value) != QDesign.NULL(" "))
                        {
                            fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.Text = W_REP_OMA_CD.Value;

                            if (QDesign.NULL(W_REP_OMA_SUFF.Value) != QDesign.NULL(" "))
                            {
                                fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.Text = W_REP_OMA_SUFF.Value;
                            }

                            W_OMA_CD.Value = W_REP_OMA_CD.Value;
                            W_NBR_SERV.Value = fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_NBR_SERV") + CLMDTL_SV_NBR_1.Value + CLMDTL_SV_NBR_2.Value + CLMDTL_SV_NBR_3.Value;
                            W_OMA_SUFF.Value = fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_SUFF");
                            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") - fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
                            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") - fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OMA"));
                            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_AMT_TECH_BILLED", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") - fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));
                            X_SV_DATE.Value = QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2);
                            //Parent:CLMDTL_SV_DATE
                            Internal_PRICE_OMA_CD();
                            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", W_AMT_TECH.Value);
                            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_FEE_OMA", W_AMT_OMA.Value);
                            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_FEE_OHIP", W_AMT_OHIP.Value);
                            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
                            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OMA"));
                            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_AMT_TECH_BILLED", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));
                        }
                        if (QDesign.NULL(W_REP_DIAG_CD.Value) != QDesign.NULL(" ") | QDesign.NULL(W_REP_SV_DATE.Value) != 0 | QDesign.NULL(W_REP_OMA_CD.Value) != QDesign.NULL(" "))
                        {
                            if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_NEW.Value))
                            {
                                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_STATUS", CLMDTL_STATUS_UPDATED.Value);
                            }
                        }
                        if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) != QDesign.NULL(""))
                        {
                            fleF002_SUSPEND_DTL.PutData();

                            Display(ref fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA);
                            Display(ref fldF002_SUSPEND_DTL_CLMDTL_SV_YY);
                            Display(ref fldF002_SUSPEND_DTL_CLMDTL_SV_MM);
                            Display(ref fldF002_SUSPEND_DTL_CLMDTL_SV_DD);
                            Display(ref fldF002_SUSPEND_DTL_CLMDTL_OMA_CD);
                            Display(ref fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF);
                            Display(ref fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED);
                            Display(ref fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA);
                            Display(ref fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP);
                        }
                    }
                }

                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", UPDATED.Value);
                fleF002_SUSPEND_HDR.PutData();
                W_REP_DIAG_CD.Value = " ";
                W_REP_SV_DATE.Value = 0;
                W_REP_OMA_CD.Value = " ";
                W_REP_OMA_SUFF.Value = " ";

                fldW_REP_DIAG_CD.Display = BehaviorTypes.ChangeEntryFind;
                fldW_REP_SV_DATE.Display = BehaviorTypes.ChangeEntryFind;
                fldW_REP_OMA_CD.Display = BehaviorTypes.ChangeEntryFind;
                fldW_REP_OMA_SUFF.Display = BehaviorTypes.ChangeEntryFind;

                Display(ref fldW_REP_DIAG_CD);
                Display(ref fldW_REP_SV_DATE);
                Display(ref fldW_REP_OMA_CD);
                Display(ref fldW_REP_OMA_SUFF);


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


        private bool Internal_SETALLDETRECSTOSAMESVCDATE()
        {


            try
            {

                while (fleF002_SUSPEND_DTL.For())
                {
                    //Parent:CLMDTL_SV_DATE
                    if (QDesign.NULL(W_CHANGED_DATE.Value) != QDesign.NULL(" ") & QDesign.NULL(W_CHANGED_DATE.Value) != QDesign.NULL(QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2)))
                    {
                        fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_SV_YY", (W_CHANGED_DATE.Value).PadRight(8).Substring(0, 4));
                        //Parent:CLMDTL_SV_DATE
                        fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_SV_MM", (W_CHANGED_DATE.Value).PadRight(8).Substring(4, 2));
                        //Parent:CLMDTL_SV_DATE
                        fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_SV_DD", (W_CHANGED_DATE.Value).PadRight(8).Substring(6, 2));
                        //Parent:CLMDTL_SV_DATE
                        if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_NEW.Value))
                        {
                            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_STATUS", CLMDTL_STATUS_UPDATED.Value);
                        }
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") - fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") - fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OMA"));
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_AMT_TECH_BILLED", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") - fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));
                        X_SV_DATE.Value = QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2);
                        //Parent:CLMDTL_SV_DATE
                        W_OMA_CD.Value = fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD");
                        W_NBR_SERV.Value = fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_NBR_SERV") + QDesign.NConvert(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 1))  + QDesign.NConvert(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 4, 1)) + QDesign.NConvert(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 7, 1));
                        Internal_PRICE_OMA_CD();
                        fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", W_AMT_TECH.Value);
                        fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_FEE_OMA", W_AMT_OMA.Value);
                        fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_FEE_OHIP", W_AMT_OHIP.Value);
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OMA"));
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_AMT_TECH_BILLED", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));
                        fleF002_SUSPEND_DTL.PutData();
                    }
                }
                //fleF002_SUSPEND_HDR.PutData();
                W_CHANGED_DATE.Value = " ";

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

                X_OCC.Value = Occurrence;
                if (ChangeMode & QDesign.NULL(X_REC_STATUS.Value) == QDesign.NULL(CLMDTL_STATUS_DELETE.Value))
                {
                    ErrorMessage("\a\aERROR - you can't change Deleted records");
                }
                else
                {
                    Accept(ref fldF002_SUSPEND_DTL_CLMDTL_OMA_CD);
                    Accept(ref fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF);
                    Accept(ref fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA);
                    Accept(ref fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV);
                    Accept(ref fldF002_SUSPEND_DTL_CLMDTL_SV_YY);
                    Accept(ref fldF002_SUSPEND_DTL_CLMDTL_SV_MM);
                    Accept(ref fldF002_SUSPEND_DTL_CLMDTL_SV_DD);
                    //Edit(ref fldDUMMY_CHECK_CHANGED_DATE);
                    Accept(ref fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED);
                    Accept(ref fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP);
                    Accept(ref fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA);
                    Accept(ref fldW_CLMDTL_SV_DAY_1);
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



        private void dsrDesigner_DEL_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (!NewRecord())
                {
                    if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_DELETE.Value))
                    {
                        fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_STATUS", CLMDTL_STATUS_DELETE.Value);
                        Display(ref fldF002_SUSPEND_DTL_CLMDTL_STATUS);
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") - fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") - fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OMA"));
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_AMT_TECH_BILLED", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") - fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));
                    }
                    else
                    {
                        Warning("This record has already been marked for deletion");
                    }
                }
                else
                {
                    Warning("You can't delete a record you haven't 'U'pdated into database");
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


        // GW2020. Jan 30 Added
        private void fldF002_SUSPEND_DTL_CLMDTL_SV_DD_Input()
        {
            fldDUMMY_CHECK_CHANGED_DATE_Edit();
        }

        private void fldF002_SUSPEND_DTL_CLMDTL_SV_YY_Edit()
        {

            try
            {

//                if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE")) == QDesign.NULL("W") & 
//                    (NewRecord() | QDesign.NULL(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY")) != QDesign.NULL(OldValue(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_SV_YY"), 
//                    fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY")))))
//                {
                    W_CHANGED_DATE_YY.Value = FieldText;
                    W_CHANGED_DATE.Value = W_CHANGED_DATE_YY.Value + W_CHANGED_DATE_MM.Value + W_CHANGED_DATE_DD.Value;
//                }


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF002_SUSPEND_DTL_CLMDTL_SV_MM_Edit()
        {

            try
            {

                //if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE")) == QDesign.NULL("W") & (NewRecord() | 
                //    QDesign.NULL(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM")) != QDesign.NULL(OldValue(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_SV_MM"), 
                //    fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM")))))
                //{
                    W_CHANGED_DATE_MM.Value = FieldText;
                    W_CHANGED_DATE.Value = W_CHANGED_DATE_YY.Value + W_CHANGED_DATE_MM.Value + W_CHANGED_DATE_DD.Value;
                //}


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF002_SUSPEND_DTL_CLMDTL_SV_DD_Edit()
        {

            try
            {
                //if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE")) == QDesign.NULL("W") 
                //    & (NewRecord() | QDesign.NULL(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD")) != QDesign.NULL(OldValue(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_SV_DD"), 
                //    fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD")))))
                //{
                    W_CHANGED_DATE_DD.Value = FieldText;
                    W_CHANGED_DATE.Value = W_CHANGED_DATE_YY.Value + W_CHANGED_DATE_MM.Value + W_CHANGED_DATE_DD.Value;
                //}

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private void fldDUMMY_CHECK_CHANGED_DATE_Edit()
        {
            try
                    {
                if (QDesign.NULL(W_CHANGED_DATE.Value) != QDesign.NULL(" "))
                {
                    if (QDesign.NULL(W_CHANGED_DATE_YY.Value) == QDesign.NULL(" "))
                    {
                        W_CHANGED_DATE.Value = QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.Substring(W_CHANGED_DATE.Value, 5, 4);
                    }
                    if (QDesign.NULL(W_CHANGED_DATE_MM.Value) == QDesign.NULL(" "))
                    {
                        W_CHANGED_DATE.Value = QDesign.Substring(W_CHANGED_DATE.Value, 1, 4) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.Substring(W_CHANGED_DATE.Value, 7, 2);
                    }
                    if (QDesign.NULL(W_CHANGED_DATE_DD.Value) == QDesign.NULL(" "))
                    {
                        W_CHANGED_DATE.Value = QDesign.Substring(W_CHANGED_DATE.Value, 1, 6) + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2);
                    }
                }
                if (string.Compare(QDesign.NULL(W_CHANGED_DATE.Value), QDesign.NULL(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY)))) > 0)
                {
                    ErrorMessage(QDesign.NULL("Service date is greater than System Date"));
                    // TODO: May need to fix manually
                }

                if (fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD").Trim() != "")
                {
                    W_OMA_CD.Value = fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD");
                }
                else
                {
                    W_OMA_CD.Value = fldF002_SUSPEND_DTL_CLMDTL_OMA_CD.Text;

                }

                W_NBR_SERV.Value = QDesign.NConvert(fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV.Text) + CLMDTL_SV_NBR_1.Value + CLMDTL_SV_NBR_2.Value + CLMDTL_SV_NBR_3.Value;

                if (fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_SUFF").Trim() != "")
                {
                    W_OMA_SUFF.Value = fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_SUFF");
                }
                else
                {
                    W_OMA_SUFF.Value = fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF.Text;
                }

                //X_SV_DATE.Value = QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_SV_YY") + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_SV_MM") + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2) + fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_SV_DD");
                X_SV_DATE.Value = QDesign.ASCII(fldF002_SUSPEND_DTL_CLMDTL_SV_YY.Text) + QDesign.ASCII(fldF002_SUSPEND_DTL_CLMDTL_SV_MM.Text) + QDesign.ASCII(fldF002_SUSPEND_DTL_CLMDTL_SV_DD.Text);

                //Parent:CLMDTL_SV_DATE
                Internal_PRICE_OMA_CD();
                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", W_AMT_TECH.Value);
                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_FEE_OHIP", W_AMT_OHIP.Value);
                fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_FEE_OMA", W_AMT_OMA.Value);
                Display(ref fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED);
                Display(ref fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP);
                Display(ref fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_UNDEL_Click(object sender, System.EventArgs e)
        {

            try
            {

                if (!NewRecord())
                {
                    if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) == QDesign.NULL(CLMDTL_STATUS_DELETE.Value))
                    {
                        fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_STATUS", CLMDTL_STATUS_UPDATED.Value);
                        Display(ref fldF002_SUSPEND_DTL_CLMDTL_STATUS);
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OMA"));
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_AMT_TECH_BILLED", fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));
                    }
                    else
                    {
                        Warning("This record has not been flagged for deletion");
                    }
                }
                else
                {
                    Warning("You can't undelete a record you haven't 'U'pdated into database");
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


        private void fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA_Output()
        {
            try
            {
                FieldText = FieldText.PadLeft(3, '0');
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        private void Pressed_F2_Key(object sender, RoutedEventArgs e)
        {
            try
            {
                dsrDesigner_DEL.Focus();
                dsrDesigner_DEL.OnBlur(dsrDesigner_DEL, null);
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        private void Pressed_F3_Key(object sender, RoutedEventArgs e)
        {
            try
            {
                dsrDesigner_UNDEL.Focus();
                dsrDesigner_UNDEL.OnBlur(dsrDesigner_UNDEL, null);
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        private void Pressed_F4_Key(object sender, RoutedEventArgs e)
        {
            try
            {
                dsrDesigner_REP.Focus();
                dsrDesigner_REP.OnBlur(dsrDesigner_REP, null);
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        private void Pressed_F5_Key(object sender, RoutedEventArgs e)
        {
            try
            {
                dsrDesigner_DES.Focus();
                dsrDesigner_DES.OnBlur(dsrDesigner_DES, null);
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        private void dsrDesigner_REP_Click(object sender, System.EventArgs e)
        {

            try
            {
                ApplicationState.Current.CorePage.DisableUpdate = true;

                fldW_REP_DIAG_CD.Display = BehaviorTypes.NotSet;
                fldW_REP_SV_DATE.Display = BehaviorTypes.NotSet;
                fldW_REP_OMA_CD.Display = BehaviorTypes.NotSet;
                fldW_REP_OMA_SUFF.Display = BehaviorTypes.NotSet;

                Accept(ref fldW_REP_DIAG_CD);
                Accept(ref fldW_REP_SV_DATE);
                Accept(ref fldW_REP_OMA_CD);
                Accept(ref fldW_REP_OMA_SUFF);
                if (QDesign.NULL(W_REP_DIAG_CD.Value) != QDesign.NULL(" ") | QDesign.NULL(W_REP_SV_DATE.Value) != 0 | QDesign.NULL(W_REP_OMA_CD.Value) != QDesign.NULL(" "))
                {
                    W_REP_OK.Value = "Y";
                    Internal_SET_ALL_DET_RECS_TO_REP_VALUES();
                }

                ApplicationState.Current.CorePage.DisableUpdate = false;

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        //#CORE_BEGIN_INCLUDE: D705_VERIFY_DESC_LENGTH"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:37 AM


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




        private void dsrDesigner_DES_Click(object sender, System.EventArgs e)
        {

            try
            {
                DisableFunctionKeys();

                W_CLMHDR_DOC_OHIP_NBR.Value = fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR");
                W_CLMHDR_ACCOUNTING_NBR.Value = fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR");
                object[] arrRunscreen = { W_CLMHDR_DOC_OHIP_NBR, W_CLMHDR_ACCOUNTING_NBR, fleF002_SUSPEND_HDR };
                RunScreen(new Billing_D705C(), RunScreenModes.Find, ref arrRunscreen);
                Internal_WARN_DESC_MAX_LENGTH();

                EnableFunctionKeys();
            }
            catch (CustomApplicationException ex)
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
                while (fleF002_SUSPEND_DTL.For())
                {
                    if (fleF002_SUSPEND_DTL.AlteredRecord & QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_DELETE.Value) & QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_NEW.Value))
                    {
                        fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_STATUS", UPDATED.Value);
                        Display(ref fldF002_SUSPEND_DTL_CLMDTL_STATUS);
                    }
                }
                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", UPDATED.Value);
                //fleF002_SUSPEND_HDR.PutData();

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


        protected override bool Initialize()
        {


            try
            {

                W_CHANGED_DATE.Value = " ";
                Internal_WARN_DESC_MAX_LENGTH();

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

                while (fleF002_SUSPEND_DTL.For())
                {

                    CLMDTL_SV_NBR_1.Value = Convert.ToDecimal(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(0, 1).Trim().PadLeft(1, '0'));
                    CLMDTL_SV_DAY_1.Value = Convert.ToDecimal(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(2, 2).Trim().PadLeft(2, '0'));
                    CLMDTL_SV_NBR_2.Value = Convert.ToDecimal(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(3, 1).Trim().PadLeft(1, '0'));
                    CLMDTL_SV_DAY_2.Value = Convert.ToDecimal(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(4, 2).Trim().PadLeft(2, '0'));
                    CLMDTL_SV_NBR_3.Value = Convert.ToDecimal(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(6, 1).Trim().PadLeft(1, '0'));
                    CLMDTL_SV_DAY_3.Value = Convert.ToDecimal(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(7, 2).Trim().PadLeft(2, '0'));


                    if (QDesign.NULL(QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2).Trim().PadLeft(2, '0')) != QDesign.NULL("00"))
                    {
                        W_CLMDTL_SV_DAY_1.Value = QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2);
                    }
                    else
                    {
                        W_CLMDTL_SV_DAY_1.Value = " ";
                    }
                }

                fldW_REP_DIAG_CD.Display = BehaviorTypes.ChangeEntryFind;
                fldW_REP_SV_DATE.Display = BehaviorTypes.ChangeEntryFind;
                fldW_REP_OMA_CD.Display = BehaviorTypes.ChangeEntryFind;
                fldW_REP_OMA_SUFF.Display = BehaviorTypes.ChangeEntryFind;

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


        protected override bool PostUpdate()
        {
            try
            {

                if (QDesign.NULL(W_CHANGED_DATE.Value) != QDesign.NULL(" "))
                {
                    if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE")) == QDesign.NULL("W"))
                    {
                        Internal_SETALLDETRECSTOSAMESVCDATE();
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
                Environment.SetEnvironmentVariable("LastConnectionString", Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings.ToString());
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString10";

                bool blnAddWhere = true;
                while (fleF002_SUSPEND_DTL.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_DOC_OHIP_NBR"), W_CLMHDR_DOC_OHIP_NBR.Value, ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_ACCOUNTING_NBR"), W_CLMHDR_ACCOUNTING_NBR.Value, ref blnAddWhere));
                    fleF002_SUSPEND_DTL.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                }

                EnableFunctionKeys();
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");

                return true;


            }
            catch (CustomApplicationException ex)
            {
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
                DisableFunctionKeys();
                throw ex;


            }
            catch (Exception ex)
            {
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
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
                Page.PageTitle = "Suspended **DETAIL** Maintenance";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:37 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:37 AM
                Accept(ref fldF002_SUSPEND_DTL_CLMDTL_OMA_CD);
                Accept(ref fldF002_SUSPEND_DTL_CLMDTL_OMA_SUFF);
                Accept(ref fldF002_SUSPEND_DTL_CLMDTL_DIAG_CD_ALPHA);
                Accept(ref fldF002_SUSPEND_DTL_CLMDTL_NBR_SERV);
                Accept(ref fldF002_SUSPEND_DTL_CLMDTL_SV_YY);
                Accept(ref fldF002_SUSPEND_DTL_CLMDTL_SV_MM);
                Accept(ref fldF002_SUSPEND_DTL_CLMDTL_SV_DD);
                Edit(ref fldDUMMY_CHECK_CHANGED_DATE);
                Accept(ref fldF002_SUSPEND_DTL_CLMDTL_AMT_TECH_BILLED);
                Accept(ref fldF002_SUSPEND_DTL_CLMDTL_FEE_OHIP);
                Accept(ref fldF002_SUSPEND_DTL_CLMDTL_FEE_OMA);
                Accept(ref fldW_CLMDTL_SV_DAY_1);
                Display(ref fldF002_SUSPEND_DTL_CLMDTL_STATUS);
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
        //# Entry Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:37 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:37 AM
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_DOC_OHIP_NBR);
                Display(ref fldF002_SUSPEND_HDR_CLMHDR_ACCOUNTING_NBR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:37 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:37 AM
                //fleF002_SUSPEND_HDR.PutData(false, PutTypes.New);
                while (fleF002_SUSPEND_DTL.For())
                {
                    fleF002_SUSPEND_DTL.PutData();
                }
                //fleF002_SUSPEND_HDR.PutData();
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
        //# dtlF002_SUSPEND_DTL_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:38 AM
        //#-----------------------------------------
        private void dtlF002_SUSPEND_DTL_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:38 AM
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

        private void EnableFunctionKeys()
        {
            try
            {
                dsrDEL.InputGestures.Add(new KeyGesture(Key.F2));
                CommandBindings.Add(new CommandBinding(dsrDEL, Pressed_F2_Key));
                dsrUNDEL.InputGestures.Add(new KeyGesture(Key.F3));
                CommandBindings.Add(new CommandBinding(dsrUNDEL, Pressed_F3_Key));
                dsrREP.InputGestures.Add(new KeyGesture(Key.F4));
                CommandBindings.Add(new CommandBinding(dsrREP, Pressed_F4_Key));
                dsrDES.InputGestures.Add(new KeyGesture(Key.F5));
                CommandBindings.Add(new CommandBinding(dsrDES, Pressed_F5_Key));
            }

            catch (CustomApplicationException ex)
            {
                throw ex;
            }

            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;
            }
        }

        private void DisableFunctionKeys()
        {
            try
            {
                CommandBindings.Remove(new CommandBinding(dsrDEL));
                CommandBindings.Remove(new CommandBinding(dsrUNDEL));
                CommandBindings.Remove(new CommandBinding(dsrREP));
                CommandBindings.Remove(new CommandBinding(dsrDES));
            }

            catch (CustomApplicationException ex)
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

