
#region "Screen Comments"

// program: utl1002.qks
// purpose: allow user to change the patient that the claim belongs to by
// changing the ikey
// 97/sep/22  - orig
// 01/jan/29 B.E. - changed pgm name, added logic same as fixf002_hdr.qks
// 01/jun/04 B.E. - removed file f086 - if changing Ikey no need to process
// it as if patient data was `corrected`. f086a file still
// used as a driver file to change ALL records from old
// patient to new patient
// 01/jun/17 B.E. - renamed from fixf002_ikey to utl1002
// 2003/dec/10 A.A. - alpha doctor nbr

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

    partial class Billing_UTL1002 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_UTL1002()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "UTL1002";

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
            fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART.Edit += fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART_Edit;
            fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART.Process += fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART_Process;

          
            base.Page_Load();

            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F010_PAT_MSTR.PAT_ACRONYM
            //       F002_CLAIMS_MSTR.CLMHDR_PAT_ACRONYM
            //       F002_CLAIMS_MSTR.CLMHDR_PAT_OHIP_ID_OR_CHART


        }

        private void FldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (Page.Mode == PageModeTypes.Find && fldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR.Text.Length >= 2)
                {
                    fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART.Focus();
                }
            }
            catch (Exception ex) { }
        }

        private void FldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (Page.Mode == PageModeTypes.Find && fldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR.Text.Length >= 8)
                {
                    fldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR.Focus();
                }
            }
            catch (Exception ex) { }
        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Secondary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF086_PAT_ID = new SqlFileObject(this, FileTypes.Designer, 0, "SEQUENTIAL", "F086_PAT_ID", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SequentialDataBase);
            fleF086A_ORIG_NEW_PAT_IDS = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F086A_ORIG_NEW_PAT_IDS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            F086_2B_UPDATED = new CoreCharacter("F086_2B_UPDATED", 1, this, Common.cEmptyString);
            F086_A_2B_UPDATED = new CoreCharacter("F086_A_2B_UPDATED", 1, this, Common.cEmptyString);
            W_OLD_KEY_PAT_MSTR = new CoreCharacter("W_OLD_KEY_PAT_MSTR", 18, this, Common.cEmptyString);
            W_ORIG_KEY_PAT_MSTR = new CoreCharacter("W_ORIG_KEY_PAT_MSTR", 18, this, Common.cEmptyString);
            W_OLD_BIRTH_DATE = new CoreDate("W_OLD_BIRTH_DATE", this);
            W_OLD_VERSION_CD = new CoreCharacter("W_OLD_VERSION_CD", 2, this, Common.cEmptyString);
            W_OLD_HEALTH_NBR = new CoreDecimal("W_OLD_HEALTH_NBR", 10, this);
            W_OLD_SURNAME = new CoreCharacter("W_OLD_SURNAME", 15, this, Common.cEmptyString);
            W_ORIG_SURNAME = new CoreCharacter("W_ORIG_SURNAME", 15, this, Common.cEmptyString);
            W_OLD_GIVEN_NAME = new CoreCharacter("W_OLD_GIVEN_NAME", 12, this, Common.cEmptyString);
            W_ORIG_GIVEN_NAME = new CoreCharacter("W_ORIG_GIVEN_NAME", 12, this, Common.cEmptyString);
            W_OLD_CHART_NBR = new CoreCharacter("W_OLD_CHART_NBR", 12, this, Common.cEmptyString);
            W_OLD_ADDR1 = new CoreCharacter("W_OLD_ADDR1", 21, this, Common.cEmptyString);
            W_OLD_ADDR2 = new CoreCharacter("W_OLD_ADDR2", 21, this, Common.cEmptyString);
            W_OLD_ADDR3 = new CoreCharacter("W_OLD_ADDR3", 21, this, Common.cEmptyString);
            W_OLD_PAT_OHIP_MMYY = new CoreCharacter("W_OLD_PAT_OHIP_MMYY", 15, this, Common.cEmptyString);
            W_OLD_PAT_DIRECT = new CoreCharacter("W_OLD_PAT_DIRECT", 15, this, Common.cEmptyString);

            CLMHDR_PAT_OHIP_ID_OR_CHART = new CoreCharacter("CLMHDR_PAT_OHIP_ID_OR_CHART", 16, this, Common.cEmptyString);
            CLMHDR_PAT_ACRONYM = new CoreCharacter("CLMHDR_PAT_ACRONYM", 9, this, Common.cEmptyString);
            PAT_ACRONYM = new CoreCharacter("PAT_ACRONYM", 9, this, Common.cEmptyString);

            fleF001_BATCH_CONTROL_FILE.Access += fleF001_BATCH_CONTROL_FILE_Access;
            fleF010_PAT_MSTR.Access += fleF010_PAT_MSTR_Access;
            BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
            BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
            BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
            BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
            BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
            fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
            fldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR.KeyUp += FldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR_KeyUp;
            fldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR.KeyUp += FldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR_KeyUp;
        }



        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF001_BATCH_CONTROL_FILE.Access -= fleF001_BATCH_CONTROL_FILE_Access;
            fleF010_PAT_MSTR.Access -= fleF010_PAT_MSTR_Access;
            BATCTRL_BATCH_STATUS_UNBALANCED.GetValue -= BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
            BATCTRL_BATCH_STATUS_BALANCED.GetValue -= BATCTRL_BATCH_STATUS_BALANCED_GetValue;
            BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue -= BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
            BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue -= BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
            BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue -= BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
            fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART.Edit -= fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART_Edit;
            fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART.Process -= fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART_Process;
            fldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR.KeyUp -= FldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR_KeyUp;
            fldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR.KeyUp -= FldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR_KeyUp;


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
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_KEY_TYPE", CLMHDR_PAT_OHIP_ID_OR_CHART.Value.PadRight(16, ' ').Substring(0, 1));
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_KEY_DATA", CLMHDR_PAT_OHIP_ID_OR_CHART.Value.PadRight(16, ' ').Substring(1, 15));

                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_ACRONYM6", CLMHDR_PAT_ACRONYM.Value.PadRight(9, ' ').Substring(0, 6));
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_ACRONYM3", CLMHDR_PAT_ACRONYM.Value.PadRight(9, ' ').Substring(6, 3));
                
            }
            catch (CustomApplicationException ex)
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

        private SqlFileObject fleF010_PAT_MSTR;

        private void fleF010_PAT_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ").Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ").Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ").Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ").Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

                strText.Append(" ORDER BY ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(", ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(", ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(", ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4"));
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

        private SqlFileObject fleF086_PAT_ID;
        private SqlFileObject fleF086A_ORIG_NEW_PAT_IDS;
        //#CORE_BEGIN_INCLUDE: F086_TEMP_FIELDS"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:56 AM

        private CoreCharacter F086_2B_UPDATED;
        private CoreCharacter F086_A_2B_UPDATED;
        private CoreCharacter W_OLD_KEY_PAT_MSTR;
        private CoreCharacter W_ORIG_KEY_PAT_MSTR;
        private CoreDate W_OLD_BIRTH_DATE;
        private CoreCharacter W_OLD_VERSION_CD;
        private CoreDecimal W_OLD_HEALTH_NBR;
        private CoreCharacter W_OLD_SURNAME;
        private CoreCharacter W_ORIG_SURNAME;
        private CoreCharacter W_OLD_GIVEN_NAME;
        private CoreCharacter W_ORIG_GIVEN_NAME;
        private CoreCharacter W_OLD_CHART_NBR;
        private CoreCharacter W_OLD_ADDR1;
        private CoreCharacter W_OLD_ADDR2;
        private CoreCharacter W_OLD_ADDR3;
        private CoreCharacter W_OLD_PAT_OHIP_MMYY;

        private CoreCharacter W_OLD_PAT_DIRECT;
        private CoreCharacter CLMHDR_PAT_OHIP_ID_OR_CHART;
        private CoreCharacter CLMHDR_PAT_ACRONYM;
        private CoreCharacter PAT_ACRONYM;
        //#CORE_END_INCLUDE: F086_TEMP_FIELDS"

        //#CORE_BEGIN_INCLUDE: DEF_BATCTRL_BATCH_STATUS"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:56 AM

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

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:57 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:57 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:57 AM

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
            fleF086_PAT_ID.Transaction = m_trnTRANS_UPDATE;
            fleF086A_ORIG_NEW_PAT_IDS.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:57 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF010_PAT_MSTR.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF010_PAT_MSTR.Dispose();
                fleF086_PAT_ID.Dispose();
                fleF086A_ORIG_NEW_PAT_IDS.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:17:56 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:17:56 AM
                Display(ref fldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR);
                Display(ref fldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART);
                Display(ref fldF086_A_2B_UPDATED);
                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM);
                Display(ref fldF010_PAT_MSTR_PAT_ACRONYM);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:57 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF002_CLAIMS_MSTR_KEY_CLM_BATCH_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_KEY_CLM_CLAIM_NBR.Bind(fleF002_CLAIMS_MSTR);
                fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART.Bind(CLMHDR_PAT_OHIP_ID_OR_CHART);
                fldF086_A_2B_UPDATED.Bind(F086_A_2B_UPDATED);
                fldF002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM.Bind(CLMHDR_PAT_ACRONYM);
                fldF010_PAT_MSTR_PAT_ACRONYM.Bind(PAT_ACRONYM);

            }
            catch (CustomApplicationException ex)
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


        protected override object SetFieldDefaults(string Name)
        {


            try
            {
                switch (Name)
                {
                    case "F086_A_2B_UPDATED":
                        return "N";
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


        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

        //#CORE_BEGIN_INCLUDE: F086_SET_OLD_PAT_VALUES"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:56 AM

        private bool Internal_SET_OLD_PAT_VALUES()
        {


            try
            {

                W_ORIG_KEY_PAT_MSTR.Value = W_OLD_KEY_PAT_MSTR.Value;
                W_ORIG_SURNAME.Value = W_OLD_SURNAME.Value;
                W_ORIG_GIVEN_NAME.Value = W_OLD_GIVEN_NAME.Value;
                W_OLD_KEY_PAT_MSTR.Value = fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4");
                //Parent:KEY_PAT_MSTR
                W_OLD_BIRTH_DATE.Value = Convert.ToDecimal(fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_YY").ToString().PadLeft(4, '0') + fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_MM").ToString().PadLeft(2, '0') + fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_DD").ToString().PadLeft(2, '0'));
                W_OLD_VERSION_CD.Value = fleF010_PAT_MSTR.GetStringValue("PAT_VERSION_CD");
                W_OLD_HEALTH_NBR.Value = fleF010_PAT_MSTR.GetDecimalValue("PAT_HEALTH_NBR");
                W_OLD_SURNAME.Value = fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22");
                //Parent:PAT_SURNAME
                W_OLD_GIVEN_NAME.Value = fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST1") + fleF010_PAT_MSTR.GetStringValue("FILLER3");
                //Parent:PAT_GIVEN_NAME
                W_OLD_CHART_NBR.Value = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR");
                W_OLD_ADDR1.Value = fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR1");
                W_OLD_ADDR2.Value = fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR2");
                W_OLD_ADDR3.Value = fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR3");

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

        //#CORE_END_INCLUDE: F086_SET_OLD_PAT_VALUES"




        private void fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART_Edit()
        {

            try
            {

                //#CORE_BEGIN_INCLUDE: F086_EDIT_CLMHDR_PAT_OHIP_ID_OR_CHART"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:56 AM

                // --> GET F010_PAT_MSTR <--

                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_KEY_TYPE", CLMHDR_PAT_OHIP_ID_OR_CHART.Value.PadRight(16, ' ').Substring(0, 1));
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_KEY_DATA", CLMHDR_PAT_OHIP_ID_OR_CHART.Value.PadRight(16, ' ').Substring(1, 15));

                fleF010_PAT_MSTR.GetData(GetDataOptions.IsOptional);
                // --> End GET F010_PAT_MSTR <--
                if (!AccessOk)
                {
                    ErrorMessage("\a\a\aThe Patient I-Key you entered is not valid!");

                    //#CORE_END_INCLUDE: F086_EDIT_CLMHDR_PAT_OHIP_ID_OR_CHART"


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



        private void fldF002_CLAIMS_MSTR_CLMHDR_PAT_OHIP_ID_OR_CHART_Process()
        {

            try
            {

                //#CORE_BEGIN_INCLUDE: F086_PROCESS_CLMHDR_PAT_OHIP_ID_OR_CHART"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:56 AM

                F086_2B_UPDATED.Value = "N";
                Internal_SET_OLD_PAT_VALUES();
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_ACRONYM6", (fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3")).PadRight(9).Substring(0, 6));
                //Parent:CLMHDR_PAT_ACRONYM    'Parent:PAT_ACRONYM
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_ACRONYM3", (fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3")).PadRight(9).Substring(6, 3));
                //Parent:CLMHDR_PAT_ACRONYM    'Parent:PAT_ACRONYM
                PAT_ACRONYM.Value = fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3");
                Display(ref fldF010_PAT_MSTR_PAT_ACRONYM);
                if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR")) != QDesign.NULL(" ") & string.Compare(QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS")), QDesign.NULL(BATCTRL_BATCH_STATUS_OHIP_SENT.Value)) < 0)
                {
                    fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", " ");
                }
                else
                {
                    if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SUBMIT_DATE")) == 0)
                    {
                        fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", "X");
                    }
                    else
                    {
                        fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", "R");
                    }
                }
                Accept(ref fldF086_A_2B_UPDATED);

                //#CORE_END_INCLUDE: F086_PROCESS_CLMHDR_PAT_OHIP_ID_OR_CHART"


                Display(ref fldF002_CLAIMS_MSTR_CLMHDR_PAT_ACRONYM);


            }
            catch (CustomApplicationException ex)
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

                CLMHDR_PAT_OHIP_ID_OR_CHART.Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA");
                CLMHDR_PAT_ACRONYM.Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_ACRONYM6") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_ACRONYM3");

                PAT_ACRONYM.Value = fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_ACRONYM_LAST3");

                //#CORE_BEGIN_INCLUDE: F086_POSTFIND"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:56 AM

                Internal_SET_OLD_PAT_VALUES();
                F086_2B_UPDATED.Value = "N";

                //#CORE_END_INCLUDE: F086_POSTFIND"



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

                //#CORE_BEGIN_INCLUDE: F086_PREUPDATE"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:56 AM

                if (AlteredRecord() & ChangeMode)
                {
                    fleF002_CLAIMS_MSTR.set_SetValue("KEY_P_CLM_TYPE", "P");
                    fleF002_CLAIMS_MSTR.set_SetValue("KEY_P_CLM_DATA", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA"));
                    if (QDesign.NULL(F086_2B_UPDATED.Value) == QDesign.NULL("Y"))
                    {
                        fleF086_PAT_ID.set_SetValue("CLMHDR_PAT_OHIP_ID_OR_CHART", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA"));
                        //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART
                        fleF086_PAT_ID.set_SetValue("PAT_LAST_BIRTH_DATE", W_OLD_BIRTH_DATE.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_LAST_VERSION_CD", W_OLD_VERSION_CD.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_SURNAME", W_OLD_SURNAME.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_GIVEN_NAME", W_OLD_GIVEN_NAME.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_HEALTH_NBR", W_OLD_HEALTH_NBR.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_CHART_NBR", W_OLD_CHART_NBR.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_ADDR1", W_OLD_ADDR1.Value);
                        fleF086_PAT_ID.set_SetValue("PAT_OLD_ADDR2", W_OLD_ADDR2.Value);
                    }
                    if (QDesign.NULL(F086_A_2B_UPDATED.Value) == QDesign.NULL("Y"))
                    {
                        fleF086A_ORIG_NEW_PAT_IDS.set_SetValue("ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART", W_ORIG_KEY_PAT_MSTR.Value);
                        fleF086A_ORIG_NEW_PAT_IDS.set_SetValue("ORIG_PAT_OLD_SURNAME", W_ORIG_SURNAME.Value);
                        fleF086A_ORIG_NEW_PAT_IDS.set_SetValue("ORIG_PAT_OLD_GIVEN_NAME", W_ORIG_GIVEN_NAME.Value);
                        fleF086A_ORIG_NEW_PAT_IDS.set_SetValue("CLMHDR_PAT_OHIP_ID_OR_CHART", W_OLD_KEY_PAT_MSTR.Value);
                        fleF086A_ORIG_NEW_PAT_IDS.set_SetValue("PAT_OLD_SURNAME", W_OLD_SURNAME.Value);
                        fleF086A_ORIG_NEW_PAT_IDS.set_SetValue("PAT_OLD_GIVEN_NAME", W_OLD_GIVEN_NAME.Value);
                    }

                    //#CORE_END_INCLUDE: F086_PREUPDATE"


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


        protected override bool Update()
        {


            try
            {

                //#CORE_BEGIN_INCLUDE: F086_UPDATE"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 5/29/2017 10:17:56 AM

                fleF002_CLAIMS_MSTR.PutData();
                if (QDesign.NULL(F086_2B_UPDATED.Value) == QDesign.NULL("Y"))
                {
                    fleF086_PAT_ID.PutData();
                }
                if (QDesign.NULL(F086_A_2B_UPDATED.Value) == QDesign.NULL("Y"))
                {
                    fleF086A_ORIG_NEW_PAT_IDS.PutData();

                    //#CORE_END_INCLUDE: F086_UPDATE"


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


                if (m_intPath != 1)
                {
                    ErrorMessage("Key/Index required.");
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
                Page.PageTitle = "Transfer Claim between Patients";


            }
            catch (CustomApplicationException ex)
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
