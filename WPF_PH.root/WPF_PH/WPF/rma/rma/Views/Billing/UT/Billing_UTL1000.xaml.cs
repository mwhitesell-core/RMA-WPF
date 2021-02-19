
#region "Screen Comments"

// program: utl1000.qks
// purpose: used to correct key fields and other fields not normally changeable 
// on claims master
// 1998/Jul/13 B.E.      - original
// 1999/feb/16 B.E. - addess f010, update p-key fields in pre-update
// 1999/mar/10 B.E. - added $ fields
// 1999/dev/08 B.E.  - y2k update of key-p-clm... fields
// 2000/Feb/10 M.C. - add dtl designer procedure
// - update p key correctly
// 2000/Jul/05 M.C.  - include f001 file as well
// - sum amount into f001, display the fields
// 2000/dec/20 B.E. - added update of f086pat if ikey field 
// (clmhdr-pat-ohip-id-or-chart) is changed
// 2001/jan/09 B.E. - if ikey of patient changed, then verify that
// ikey is valid and use found patient`s acronym
// to update f002 acronym fields, redisplay acronym
// of patient pointed to by new ikey
// 2001/jan/24 BE/MC - major rearrangement of code to ensure that f086
// is updated with the new patient when the
// i-key of the claim (field clmhdr-pat-ohip-id-or-chart)
// is changed to point to a new patient. 
// 2001/feb/02 B.E. - added updated of f086a- to allow transfer of all
// claims of patient
// 2001/jun/17 B.E. - eliminated option to tranfer claim from one patient
// to another patient by changing I-key. You must fix
// the  utl1002  program. This ensures that if
// eligbility information is changed the proper 
// processing is performed.
// 2002/feb/28 M.C. - on this screen users only can change the amount fields, all   
// other fields are display  fields only
// - add to display the batch status  
// - comment out related to f010 and f086
// - do not allow user to change if batch status > 2
// 2002/may/23 M.C. - allow user to change any record regardless of the batch status
// 2003/dec/10 A.A. - alpha doctor nbr
// 2006/feb/18 b.e. - made fields 28 thru 33 updateable
// - made all fields EXCEPT 1-6, 8-9, and 15-18 updateable
// 2011/sep/26 b.e. - added doc-dept in f002 header as changeable field
// 2012/aug/21 MC1  - added clmhdr-serv-date as changeable field

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

    partial class Billing_UTL1000 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_UTL1000()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "UTL1000";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.UseAcceptProcessing = true;



            this.HasPathRequestFields = true;


        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_DTL.Click += dsrDesigner_DTL_Click;
            dsrDesigner_07.Click += dsrDesigner_07_Click;
            base.Page_Load();

            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F002_CLAIMS_MSTR.CLMHDR_PAT_ACRONYM


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Secondary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            SUBMIT_STATUS = new CoreCharacter("SUBMIT_STATUS", 1, this, Common.cEmptyString);

            fleF002_CLAIMS_MSTR.SumIntoFields = "CLMHDR_TOT_CLAIM_AR_OHIP,CLMHDR_MANUAL_AND_TAPE_PAYMENTS";


            fleF001_BATCH_CONTROL_FILE.Access += fleF001_BATCH_CONTROL_FILE_Access;
            BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
            BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
            BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
            BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
            BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
            CLMHDR_PAT_ACRONYM = new CoreCharacter("CLMHDR_PAT_ACRONYM", 9, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        }

     

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF001_BATCH_CONTROL_FILE.Access -= fleF001_BATCH_CONTROL_FILE_Access;
            BATCTRL_BATCH_STATUS_UNBALANCED.GetValue -= BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
            BATCTRL_BATCH_STATUS_BALANCED.GetValue -= BATCTRL_BATCH_STATUS_BALANCED_GetValue;
            BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue -= BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
            BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue -= BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
            BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue -= BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;

            dsrDesigner_DTL.Click -= dsrDesigner_DTL_Click;
            dsrDesigner_07.Click -= dsrDesigner_07_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF002_CLAIMS_MSTR;

        private void fleF002_CLAIMS_MSTR_SetItemFinals()
        {
            try
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_ACRONYM6", CLMHDR_PAT_ACRONYM.Value.PadRight(9, ' ').Substring(0, 6));
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_ACRONYM3", CLMHDR_PAT_ACRONYM.Value.PadRight(9, ' ').Substring(6));

            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }
        }

        private CoreCharacter CLMHDR_PAT_ACRONYM;

        private void fleF002_CLAIMS_MSTR_SumInto(string Field, decimal Value, decimal OldValue)
        {

            try
            {
                switch (Field)
                {
                    case "CLMHDR_TOT_CLAIM_AR_OHIP":
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_AR_DUE", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_TOT_REV", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_TOT_REV") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_ACT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_EST") + (Value - OldValue));
                        break;
                    case "CLMHDR_MANUAL_AND_TAPE_PAYMENTS":
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_MANUAL_PAY_TOT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_MANUAL_PAY_TOT") + (Value - OldValue));
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

        private SqlFileObject fleF001_BATCH_CONTROL_FILE;

        private void fleF001_BATCH_CONTROL_FILE_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR")).Append(" = ").Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR")));

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

        //#CORE_BEGIN_INCLUDE: DEF_BATCTRL_BATCH_STATUS"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:09 AM

        private DCharacter BATCTRL_BATCH_STATUS_UNBALANCED = new DCharacter(1);
        private void BATCTRL_BATCH_STATUS_UNBALANCED_GetValue(ref string Value)
        {

            try
            {
                Value = "0";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter BATCTRL_BATCH_STATUS_BALANCED = new DCharacter(1);
        private void BATCTRL_BATCH_STATUS_BALANCED_GetValue(ref string Value)
        {

            try
            {
                Value = "1";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter BATCTRL_BATCH_STATUS_REV_UPDATED = new DCharacter(1);
        private void BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue(ref string Value)
        {

            try
            {
                Value = "2";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter BATCTRL_BATCH_STATUS_OHIP_SENT = new DCharacter(1);
        private void BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue(ref string Value)
        {

            try
            {
                Value = "3";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        private DCharacter BATCTRL_BATCH_STATUS_MONTHEND_DONE = new DCharacter(1);
        private void BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue(ref string Value)
        {

            try
            {
                Value = "4";


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }


        }

        //#CORE_END_INCLUDE: DEF_BATCTRL_BATCH_STATUS"


        private CoreCharacter SUBMIT_STATUS;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:09 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:09 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:09 AM

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
            fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:09 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();


            }
            catch (CustomApplicationException ex)
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
                fleF002_CLAIMS_MSTR.Dispose();
                fleF001_BATCH_CONTROL_FILE.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:18:09 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:18:09 AM
                Display(ref fldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR);
                Display(ref fldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR);
                Display(ref fldF002_CLAIMS_MSTR_KEY_CLM_SERV_CODE);
                Display(ref fldF002_CLAIMS_MSTR_KEY_CLM_ADJ_NBR);
                Display(ref fldF002_CLAIMS_MSTR_KEY_P_CLM_TYPE);
                Display(ref fldF002_CLAIMS_MSTR_KEY_P_CLM_DATA);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_TOT_CLAIM_AR_OMA);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_TOT_CLAIM_AR_OHIP);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_CURR_PAYMENT);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_AMT_TECH_BILLED);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_AMT_TECH_PAID);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_BATCH_TYPE);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_ADJ_CD);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_I_O_PAT_IND);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_SUBMIT_DATE);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_DATE_SYS);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_DATE_PERIOD_END);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_CYCLE_NBR);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_BATCH_NBR);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_CLAIM_NBR);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_SERV_DATE);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_ORIG_BATCH_NBR);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_ORIG_CLAIM_NBR);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_ADJ_OMA_CD);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_ADJ_OMA_SUFF);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_ADJ_ADJ_NBR);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_TAPE_SUBMIT_IND);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_REFERENCE);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_STATUS_OHIP);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_DOC_DEPT);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_ACT);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_EST);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_AR_DUE);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_TOT_REV);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_ACT);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_EST);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_MANUAL_PAY_TOT);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_STATUS);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:09 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_KEY_CLM_SERV_CODE.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_KEY_CLM_ADJ_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_KEY_P_CLM_TYPE.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_KEY_P_CLM_DATA.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_TOT_CLAIM_AR_OMA.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_TOT_CLAIM_AR_OHIP.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_MANUAL_AND_TAPE_PAYMENTS.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_CURR_PAYMENT.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_AMT_TECH_BILLED.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_AMT_TECH_PAID.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_BATCH_TYPE.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_ADJ_CD.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_I_O_PAT_IND.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_SUBMIT_DATE.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_DATE_SYS.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_DATE_PERIOD_END.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_CYCLE_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_BATCH_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_CLAIM_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_SERV_DATE.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_ORIG_BATCH_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_ORIG_CLAIM_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_ADJ_OMA_CD.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_ADJ_OMA_SUFF.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_ADJ_ADJ_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_TAPE_SUBMIT_IND.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_REFERENCE.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_STATUS_OHIP.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM.Bind(CLMHDR_PAT_ACRONYM);
                fldF002_CLAIMS_MSTR_CLMHDR_DOC_DEPT.Bind(fleF002_CLAIMS_MSTR);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_ACT.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_EST.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_AR_DUE.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_TOT_REV.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_ACT.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_EST.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_MANUAL_PAY_TOT.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_STATUS.Bind(fleF001_BATCH_CONTROL_FILE);

            }
            catch (CustomApplicationException ex)
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

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"



        private void dsrDesigner_DTL_Click(object sender, System.EventArgs e)
        {

            try
            {

                object[] arrRunscreen = { fleF002_CLAIMS_MSTR, fleF001_BATCH_CONTROL_FILE };
                RunScreen(new Billing_UTL1001(), RunScreenModes.Find, ref arrRunscreen);
                DisplayFormatting();

            }
            catch (CustomApplicationException ex)
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
                CLMHDR_PAT_ACRONYM.Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_ACRONYM6") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_ACRONYM3");



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
                m_strWhere = new StringBuilder(GetWhereCondition(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE"), "B", ref blnAddWhere));
                m_strWhere.Append(GetWhereCondition(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR"), fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), ref blnAddWhere));
                m_strWhere.Append(GetWhereCondition(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR"), fleF002_CLAIMS_MSTR.GetDecimalValue("KEY_CLM_CLAIM_NBR"), ref blnAddWhere));
                m_strWhere.Append(GetWhereCondition(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE"), "00000", ref blnAddWhere));
                m_strWhere.Append(GetWhereCondition(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR"), "0", ref blnAddWhere));
                fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                fleF001_BATCH_CONTROL_FILE.GetData();


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
                RequestPrompt(ref fldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR);
                if (m_blnPromptOK)
                {
                    RequestPrompt(ref fldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 1;
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
                Page.PageTitle = "Fix Claim Header/Detail record";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:18:09 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:18:09 AM
                fleF001_BATCH_CONTROL_FILE.PutData();
                fleF002_CLAIMS_MSTR.PutData();
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
        //# dsrDesigner_07_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:18:09 AM
        //#-----------------------------------------
        private void dsrDesigner_07_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:18:09 AM
                Accept(ref fldF002_CLAIMS_MSTR_CLMHDR_TOT_CLAIM_AR_OMA);
                Accept(ref fldF002_CLAIMS_MSTR_CLMHDR_TOT_CLAIM_AR_OHIP);
                Accept(ref fldF002_CLAIMS_MSTR_CLMHDR_MANUAL_AND_TAPE_PAYMENTS);
                Accept(ref fldF002_CLAIMS_MSTR_CLMHDR_CURR_PAYMENT);
                Accept(ref fldF002_CLAIMS_MSTR_CLMHDR_AMT_TECH_BILLED);
                Accept(ref fldF002_CLAIMS_MSTR_CLMHDR_AMT_TECH_PAID);
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
