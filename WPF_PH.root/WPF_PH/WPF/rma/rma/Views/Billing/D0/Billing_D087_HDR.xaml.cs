
#region "Screen Comments"

// PROGRAM: d087_hdr.qks
// PURPOSE:
// allow the update/entry of claims that have been submittedly rejected by the
// local OHIP office. This file is normally added to by the electronic file
// obtained back from OHIP after a submission.
// The PED is defaulted from the Constants master but can be changed since
// some entry is done after month end.
// MODIFICATION HISTORY
// WHEN        WHO       WHY
// 2003/sep/01 b.e.      - original
// 2003/dec/01 M.C. - switch the access for f087-hdr to prompt for
// claim#, then health# , then process-date
// instead of health#, tehn process-date, then claim#
// 2003/dec/10 b.e. - alpha doctor change
// 2013/Sep/19 MC1  - show reject PED on the screen

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

    partial class Billing_D087_HDR : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D087_HDR()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D087_HDR";

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
            dsrDesigner_DTL.Click += dsrDesigner_DTL_Click;
            dsrDesigner_17.Click += dsrDesigner_17_Click;
            dsrDesigner_23.Click += dsrDesigner_23_Click;

            base.Page_Load();

            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F010_PAT_MSTR.PAT_SURNAME
            //       F087_SUBMITTED_REJECTED_CLAIMS_HDR.SUBMITTED_REJECTED_CLAIM
            //       F010_PAT_MSTR.PAT_GIVEN_NAME


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF093_OHIP_ERROR_MSG_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            W_NAME = new CoreCharacter("W_NAME", 20, this, fleF087_SUBMITTED_REJECTED_CLAIMS_HDR, Common.cEmptyString);
            W_PED = new CoreDate("W_PED", this);
            W_EDT_PROCESS_DATE = new CoreDate("W_EDT_PROCESS_DATE", this);
            fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_cnnQUERY");
            fleF002FIND = new SqlFileObject(this, FileTypes.Designer, fleF087_SUBMITTED_REJECTED_CLAIMS_HDR, "INDEXED", "F002_CLAIMS_MSTR_DTL", "F002FIND", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF010FIND = new SqlFileObject(this, FileTypes.Designer, fleF087_SUBMITTED_REJECTED_CLAIMS_HDR, "INDEXED", "F010_PAT_MSTR", "F010FIND", false, false, false, 0, "m_trnTRANS_UPDATE");
            FOUND = new CoreCharacter("FOUND", 1, this, Common.cEmptyString);
            W_DATE = new CoreDate("W_DATE", this);
            W_CLAIM_ID = new CoreCharacter("W_CLAIM_ID", 11, this, Common.cEmptyString);
            W_BATCH_NBR = new CoreCharacter("W_BATCH_NBR", 9, this, Common.cEmptyString);
            W_CLAIM_NBR = new CoreCharacter("W_CLAIM_NBR", 2, this, Common.cEmptyString);
            SUBMITTED_REJECTED_CLAIM = new CoreCharacter("SUBMITTED_REJECTED_CLAIM", 10, this, Common.cEmptyString);
            PAT_SURNAME = new CoreCharacter("PAT_SURNAME", 25, this, Common.cEmptyString);
            PAT_GIVEN_NAME = new CoreCharacter("PAT_GIVEN_NAME", 17, this, Common.cEmptyString);



            fleF093_OHIP_ERROR_MSG_MSTR.Access += fleF093_OHIP_ERROR_MSG_MSTR_Access;
            fleF002_CLAIMS_MSTR.Access += fleF002_CLAIMS_MSTR_Access;
            fleF002FIND.Access += fleF002FIND_Access;
            fleF010_PAT_MSTR.Access += fleF010_PAT_MSTR_Access;
            fleF010FIND.Access += fleF010FIND_Access;
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.InitializeItems += fleF087_SUBMITTED_REJECTED_CLAIMS_HDR_InitializeItems;
            W_DATE.GetInitialValue += W_DATE_GetInitialValue;

            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.SetItemFinals += FleF087_SUBMITTED_REJECTED_CLAIMS_HDR_SetItemFinals;
            fleF010_PAT_MSTR.SetItemFinals += FleF010_PAT_MSTR_SetItemFinals;

            fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_SUBMITTED_REJECTED_CLAIM.Input += FldF087_SUBMITTED_REJECTED_CLAIMS_HDR_SUBMITTED_REJECTED_CLAIM_Input;
        }



        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF093_OHIP_ERROR_MSG_MSTR.Access -= fleF093_OHIP_ERROR_MSG_MSTR_Access;
            fleF002_CLAIMS_MSTR.Access -= fleF002_CLAIMS_MSTR_Access;
            fleF002FIND.Access -= fleF002FIND_Access;
            fleF010_PAT_MSTR.Access -= fleF010_PAT_MSTR_Access;
            fleF010FIND.Access -= fleF010FIND_Access;
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.InitializeItems -= fleF087_SUBMITTED_REJECTED_CLAIMS_HDR_InitializeItems;
            W_DATE.GetInitialValue -= W_DATE_GetInitialValue;
            dsrDesigner_DTL.Click -= dsrDesigner_DTL_Click;
            dsrDesigner_17.Click -= dsrDesigner_17_Click;
            dsrDesigner_23.Click -= dsrDesigner_23_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF087_SUBMITTED_REJECTED_CLAIMS_HDR;

        private void FleF087_SUBMITTED_REJECTED_CLAIMS_HDR_SetItemFinals()
        {
            try
            {
                fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("CLMHDR_BATCH_NBR", SUBMITTED_REJECTED_CLAIM.Value.PadRight(10, ' ').Substring(0, 8));

                if (SUBMITTED_REJECTED_CLAIM.Value.PadRight(10, ' ').Substring(8, 2).Trim() != "")
                {
                    fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("CLMHDR_CLAIM_NBR", SUBMITTED_REJECTED_CLAIM.Value.PadRight(10, ' ').Substring(8, 2));
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

        private void fleF087_SUBMITTED_REJECTED_CLAIMS_HDR_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("ENTRY_DATE", true, QDesign.SysDate(ref m_cnnQUERY));
                if (!Fixed)
                    fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("ENTRY_TIME_LONG", true, QDesign.SysTime(ref m_cnnQUERY));
                if (!Fixed)
                    fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("ENTRY_USER_ID", true, UserID);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private void FleF010_PAT_MSTR_SetItemFinals()
        {
            try
            {
                fleF010_PAT_MSTR.set_SetValue("PAT_SURNAME_FIRST3", PAT_SURNAME.Value.PadRight(25, ' ').Substring(0, 3));
                fleF010_PAT_MSTR.set_SetValue("PAT_SURNAME_LAST22", PAT_SURNAME.Value.PadRight(25, ' ').Substring(3, 22));


                fleF010_PAT_MSTR.set_SetValue("PAT_GIVEN_NAME_FIRST1", PAT_GIVEN_NAME.Value.PadRight(17, ' ').Substring(0, 1));
                fleF010_PAT_MSTR.set_SetValue("FILLER3", PAT_GIVEN_NAME.Value.PadRight(17, ' ').Substring(1, 16));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }
        }

        private void fleF087_SUBMITTED_REJECTED_CLAIMS_HDR_SetItemFinals()
        {

            try
            {

                fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("CLMHDR_BATCH_NBR", SUBMITTED_REJECTED_CLAIM.Value.Substring(0, 8));
                fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("CLMHDR_CLAIM_NBR", SUBMITTED_REJECTED_CLAIM.Value.Substring(2, 8));




                fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.set_SetValue("LAST_MOD_USER_ID", UserID);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private SqlFileObject fleF093_OHIP_ERROR_MSG_MSTR;

        private void fleF093_OHIP_ERROR_MSG_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF093_OHIP_ERROR_MSG_MSTR.ElementOwner("OHIP_ERR_CODE")).Append(" = ").Append(Common.StringToField(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetStringValue("EDT_ERR_H_CD_1")));

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

        private CoreCharacter W_NAME;
        private CoreDate W_PED;
        private CoreDate W_EDT_PROCESS_DATE;
        private SqlFileObject fleF002_CLAIMS_MSTR;

        private void fleF002_CLAIMS_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ").Append(Common.StringToField("B"));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ").Append(Common.StringToField(QDesign.Substring(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2), 1, 8)));
                //Parent:SUBMITTED_REJECTED_CLAIM
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append((QDesign.NConvert(QDesign.Substring(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2), 9, 2))));
                //Parent:SUBMITTED_REJECTED_CLAIM
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ").Append(Common.StringToField("00000"));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ").Append(Common.StringToField("0"));

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

        private SqlFileObject fleF002FIND;

        private void fleF002FIND_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002FIND.ElementOwner("KEY_CLM_TYPE")).Append(" = ").Append(Common.StringToField("B"));
                strText.Append(" AND ").Append(fleF002FIND.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ").Append(Common.StringToField(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetStringValue("CLMHDR_BATCH_NBR")));
                strText.Append(" AND ").Append(fleF002FIND.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append((fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR")));
                strText.Append(" AND ").Append(fleF002FIND.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ").Append(Common.StringToField("00000"));
                strText.Append(" AND ").Append(fleF002FIND.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ").Append(Common.StringToField("0"));

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
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ").Append(Convert.ToInt64((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2).Trim().PadLeft(1, '0')));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ").Append(Convert.ToInt64((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12).Trim().PadLeft(1, '0')));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ").Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

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

        private SqlFileObject fleF010FIND;

        private void fleF010FIND_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF010FIND.ElementOwner("PAT_I_KEY")).Append(" = ").Append(Common.StringToField(fleF002FIND.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010FIND.ElementOwner("PAT_CON_NBR")).Append(" = ").Append(Common.StringToField((fleF002FIND.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002FIND.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010FIND.ElementOwner("PAT_I_NBR")).Append(" = ").Append(Common.StringToField((fleF002FIND.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002FIND.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010FIND.ElementOwner("FILLER4")).Append(" = ").Append(Common.StringToField((fleF002FIND.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002FIND.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

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

        private CoreCharacter FOUND;
        private CoreDate W_DATE;
        private void W_DATE_GetInitialValue()
        {
            W_DATE.InitialValue = QDesign.SysDate(ref m_cnnQUERY);
        }
        private CoreCharacter W_CLAIM_ID;
        private CoreCharacter W_BATCH_NBR;
        private CoreCharacter SUBMITTED_REJECTED_CLAIM;
        private CoreCharacter PAT_SURNAME;
        private CoreCharacter PAT_GIVEN_NAME;


        private CoreCharacter W_CLAIM_NBR;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:19 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:19 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:19 AM

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
            fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.Transaction = m_trnTRANS_UPDATE;
            fleF002FIND.Transaction = m_trnTRANS_UPDATE;
            fleF010FIND.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:19 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF093_OHIP_ERROR_MSG_MSTR.Connection = m_cnnQUERY;
                fleF002_CLAIMS_MSTR.Connection = m_cnnQUERY;
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
                fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.Dispose();
                fleF093_OHIP_ERROR_MSG_MSTR.Dispose();
                fleF002_CLAIMS_MSTR.Dispose();
                fleF002FIND.Dispose();
                fleF010_PAT_MSTR.Dispose();
                fleF010FIND.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:19 AM

                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_SUBMITTED_REJECTED_CLAIM);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ACCOUNT_NBR);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_CLMHDR_DOC_NBR);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_PED);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PROCESS_DATE);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PAY_PROG);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PAYEE);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EFT_REFERRING_DOC_NBR);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_FACILITY_NBR);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ADMIT_DATE);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_LOCATION_CD);
                Display(ref fldF010_PAT_MSTR_PAT_SURNAME);
                Display(ref fldF010_PAT_MSTR_PAT_GIVEN_NAME);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PAT_BIRTH_DATE);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_HEALTH_NBR);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_HEALTH_VERSION_CD);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_1);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_2);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_3);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_4);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_5);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_ENTRY_DATE);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_ENTRY_USER_ID);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_LAST_MOD_DATE);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_LAST_MOD_TIME);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_LAST_MOD_USER_ID);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_CHARGE_STATUS);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_OHIP_ERR_CODE);
                Display(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_PED2);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
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

        #region "Update Validation"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion


        #region "RecordBuffer Events"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:19 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {

                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_SUBMITTED_REJECTED_CLAIM.Bind(SUBMITTED_REJECTED_CLAIM);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ACCOUNT_NBR.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_CLMHDR_DOC_NBR.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_PED.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_PED2.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PROCESS_DATE.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PAY_PROG.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PAYEE.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EFT_REFERRING_DOC_NBR.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_FACILITY_NBR.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ADMIT_DATE.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_LOCATION_CD.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF010_PAT_MSTR_PAT_SURNAME.Bind(PAT_SURNAME);
                fldF010_PAT_MSTR_PAT_GIVEN_NAME.Bind(PAT_GIVEN_NAME);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PAT_BIRTH_DATE.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_HEALTH_NBR.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_HEALTH_VERSION_CD.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_1.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_2.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_3.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_4.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_5.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_ENTRY_DATE.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_ENTRY_USER_ID.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_LAST_MOD_DATE.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_LAST_MOD_TIME.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_LAST_MOD_USER_ID.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_CHARGE_STATUS.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);
                fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_OHIP_ERR_CODE.Bind(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR);

            }
            catch (CustomApplicationException ex)
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

                W_CLAIM_ID.Value = fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2);
                W_PED.Value = fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumericDateValue("PED");
                W_EDT_PROCESS_DATE.Value = fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetNumericDateValue("EDT_PROCESS_DATE");
                object[] arrRunscreen = { W_CLAIM_ID, W_PED, W_EDT_PROCESS_DATE, fleF087_SUBMITTED_REJECTED_CLAIMS_HDR };
                RunScreen(new Billing_D087_DTL(), RunScreenModes.Same, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
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
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.ElementOwner("CLMHDR_BATCH_NBR"), SUBMITTED_REJECTED_CLAIM.Value.PadRight(8, ' ').Substring(0, 8), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.ElementOwner("CLMHDR_CLAIM_NBR"), ((SUBMITTED_REJECTED_CLAIM.Value).PadRight(10).Substring(8, 2)), ref blnAddWhere));
                        fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.ElementOwner("EDT_HEALTH_NBR"), fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetStringValue("EDT_HEALTH_NBR"), ref blnAddWhere));
                        fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 3:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.ElementOwner("EDT_PROCESS_DATE"), fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetDecimalValue("EDT_PROCESS_DATE"), ref blnAddWhere));
                        fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 4:
                        fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

        protected override bool PostFind()
        {

            try
            {
                SUBMITTED_REJECTED_CLAIM.Value = fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetStringValue("CLMHDR_BATCH_NBR").Trim() + fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.GetStringValue("CLMHDR_CLAIM_NBR").Trim().PadLeft(2, '0');

                PAT_SURNAME.Value = fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3").PadLeft(3, ' ') + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22").PadLeft(22, ' ');
                PAT_GIVEN_NAME.Value = fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST1").PadLeft(1, ' ') + fleF010_PAT_MSTR.GetStringValue("FILLER3").PadLeft(16, ' ');


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
                RequestPrompt(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_SUBMITTED_REJECTED_CLAIM);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_HEALTH_NBR);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PROCESS_DATE);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 3;
                    }
                }
                if (m_intPath == 0)
                {
                    m_intPath = 4;
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
                Page.PageTitle = "Claims rejected by Ohip at SUBMISSION Time";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:19 AM

                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_SUBMITTED_REJECTED_CLAIM);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ACCOUNT_NBR);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_CLMHDR_DOC_NBR);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_PED);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PROCESS_DATE);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PAY_PROG);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PAYEE);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EFT_REFERRING_DOC_NBR);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_FACILITY_NBR);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ADMIT_DATE);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_LOCATION_CD);
                Accept(ref fldF010_PAT_MSTR_PAT_SURNAME);
                Accept(ref fldF010_PAT_MSTR_PAT_GIVEN_NAME);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_PAT_BIRTH_DATE);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_HEALTH_NBR);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_HEALTH_VERSION_CD);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_1);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_2);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_3);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_4);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_5);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_ENTRY_DATE);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_ENTRY_USER_ID);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_LAST_MOD_DATE);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_LAST_MOD_TIME);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_LAST_MOD_USER_ID);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_CHARGE_STATUS);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_OHIP_ERR_CODE);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_PED2);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:19 AM
                fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.PutData(false, PutTypes.New);
                fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:19 AM
                fleF087_SUBMITTED_REJECTED_CLAIMS_HDR.DeletedRecord = true;
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
        //# dsrDesigner_17_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        private void dsrDesigner_17_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:19 AM
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_1);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_2);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_3);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_4);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_EDT_ERR_H_CD_5);
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
        //# dsrDesigner_23_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:19 AM
        //#-----------------------------------------
        private void dsrDesigner_23_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:19 AM
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_CHARGE_STATUS);
                Accept(ref fldF087_SUBMITTED_REJECTED_CLAIMS_HDR_OHIP_ERR_CODE);
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

        private void FldF087_SUBMITTED_REJECTED_CLAIMS_HDR_SUBMITTED_REJECTED_CLAIM_Input()
        {
            try
            {
                try
                {
                    if (FieldText.Length > 0)
                    {
                        int result = int.Parse(FieldText.PadRight(10,'0').Substring(8, 2));
                    }

                }
                catch (Exception ex)
                {
                    ErrorMessage("Please enter a valid Claim Nbr");


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

        #endregion

    }


}
