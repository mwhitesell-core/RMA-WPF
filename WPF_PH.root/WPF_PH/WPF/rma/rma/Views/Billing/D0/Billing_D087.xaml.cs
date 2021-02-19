
#region "Screen Comments"

// PROGRAM: D087
// PURPOSE:
// allow the entry of claims that have been manually rejected by the
// local OHIP office. No electronic file can be obtained from OHIP so the
// claims must be entered by hand from the hard copy report.
// Note that originally only the doctor number was entered (when this database
// was kep in LOTUS 123.  Therefore the claim number entry is optional
// but the doctor number must be entered. If a claim number is entered
// the doctor number is extracted and the doctor nbr field defaulted.
// The PED is defaulted from the Constants master but can be changed since
// some entry is done after month end.
// MODIFICATION HISTORY
// WHEN        WHO WHY
// 1999/05/31  B.E. - original
// 1999/06/22  B.E. - y2k
// 1999/12/08  B.E. - changed edits on patient to warnings rather than error
// 1999/12/30  B.E. - added  EH2  as default error message
// 2000/02/07  B.E. - corrected mis-calculation of clmhdr-doc-nbr
// 2003/12/01  b.e. - alpha doctor number

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

    partial class Billing_D087 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D087()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D087";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;



            this.HasPathRequestFields = true;













            this.GridDesigner = "dsrDesigner_01";


            dsrDesigner_01.DefaultFirstRowInGrid = true;

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dtlMANUAL_REJECTED_CLAIMS_HIST.EditClick += dtlMANUAL_REJECTED_CLAIMS_HIST_EditClick;
            dsrDesigner_01.Click += dsrDesigner_01_Click;           
          
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       MANUAL_REJECTED_CLAIMS_HIST.MANUAL_REJECTED_CLAIM


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleMANUAL_REJECTED_CLAIMS_HIST = new SqlFileObject(this, FileTypes.Primary, 18, "INDEXED", "MANUAL_REJECTED_CLAIMS_HIST", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF093_OHIP_ERROR_MSG_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            X_NAME = new CoreCharacter("X_NAME", 20, this, fleMANUAL_REJECTED_CLAIMS_HIST, Common.cEmptyString);
            fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_cnnQUERY");
            fleF002FIND = new SqlFileObject(this, FileTypes.Designer, fleMANUAL_REJECTED_CLAIMS_HIST, "INDEXED", "F002_CLAIMS_MSTR", "F002FIND", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF010FIND = new SqlFileObject(this, FileTypes.Designer, fleMANUAL_REJECTED_CLAIMS_HIST, "INDEXED", "F010_PAT_MSTR", "F010FIND", false, false, false, 0, "m_trnTRANS_UPDATE");
            FOUND = new CoreCharacter("FOUND", 1, this, Common.cEmptyString);
            W_DATE = new CoreDate("W_DATE", this);

            fleF093_OHIP_ERROR_MSG_MSTR.Access += fleF093_OHIP_ERROR_MSG_MSTR_Access;
            fleF002_CLAIMS_MSTR.Access += fleF002_CLAIMS_MSTR_Access;
            fleF002FIND.Access += fleF002FIND_Access;
            fleF010_PAT_MSTR.Access += fleF010_PAT_MSTR_Access;
            fleF010FIND.Access += fleF010FIND_Access;
            fleMANUAL_REJECTED_CLAIMS_HIST.InitializeItems += fleMANUAL_REJECTED_CLAIMS_HIST_InitializeItems;
            W_DATE.GetInitialValue += W_DATE_GetInitialValue;
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
            fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE.LookupOn -= fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE_LookupOn;
            fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM.LookupNotOn -= fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_LookupNotOn;
            fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM.LookupOn -= fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_LookupOn;
            dtlMANUAL_REJECTED_CLAIMS_HIST.EditClick -= dtlMANUAL_REJECTED_CLAIMS_HIST_EditClick;
            fleMANUAL_REJECTED_CLAIMS_HIST.InitializeItems -= fleMANUAL_REJECTED_CLAIMS_HIST_InitializeItems;
            W_DATE.GetInitialValue -= W_DATE_GetInitialValue;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM.Process -= fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_Process;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleMANUAL_REJECTED_CLAIMS_HIST;

        private void fleMANUAL_REJECTED_CLAIMS_HIST_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleMANUAL_REJECTED_CLAIMS_HIST.set_SetValue("ENTRY_DATE", true, QDesign.SysDate(ref m_cnnQUERY));
                if (!Fixed)
                    fleMANUAL_REJECTED_CLAIMS_HIST.set_SetValue("ENTRY_TIME_LONG", true, QDesign.SysTime(ref m_cnnQUERY));
                if (!Fixed)
                    fleMANUAL_REJECTED_CLAIMS_HIST.set_SetValue("ENTRY_USER_ID", true, UserID);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleMANUAL_REJECTED_CLAIMS_HIST_SetItemFinals()
        {

            try
            {
                fleMANUAL_REJECTED_CLAIMS_HIST.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleMANUAL_REJECTED_CLAIMS_HIST.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleMANUAL_REJECTED_CLAIMS_HIST.set_SetValue("LAST_MOD_USER_ID", UserID);


            }
            catch (CustomApplicationException ex)
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

                strText.Append(" WHERE  ").Append(fleF093_OHIP_ERROR_MSG_MSTR.ElementOwner("OHIP_ERR_CODE")).Append(" = ").Append(Common.StringToField(fleF093_OHIP_ERROR_MSG_MSTR.GetStringValue("OHIP_ERR_CODE")));


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

        private CoreCharacter X_NAME;
        private SqlFileObject fleF002_CLAIMS_MSTR;

        private void fleF002_CLAIMS_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ").Append(Common.StringToField("B"));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ").Append(Common.StringToField(QDesign.Substring(fleMANUAL_REJECTED_CLAIMS_HIST.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleMANUAL_REJECTED_CLAIMS_HIST.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2), 1, 8)));
                //Parent:MANUAL_REJECTED_CLAIM
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append((QDesign.NConvert(QDesign.Substring(fleMANUAL_REJECTED_CLAIMS_HIST.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleMANUAL_REJECTED_CLAIMS_HIST.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2), 9, 2))));
                //Parent:MANUAL_REJECTED_CLAIM
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
                strText.Append(" AND ").Append(fleF002FIND.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ").Append(Common.StringToField(fleMANUAL_REJECTED_CLAIMS_HIST.GetStringValue("CLMHDR_BATCH_NBR")));
                strText.Append(" AND ").Append(fleF002FIND.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append((fleMANUAL_REJECTED_CLAIMS_HIST.GetDecimalValue("CLMHDR_CLAIM_NBR")));
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
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ").Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ").Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
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

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:20 AM

        protected TextBox fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM;
        protected TextBox fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE;
        protected DateControl fldMANUAL_REJECTED_CLAIMS_HIST_PED;
        protected TextBox fldMANUAL_REJECTED_CLAIMS_HIST_CLMHDR_DOC_NBR;
        protected TextBox fldX_NAME;
        protected DateControl fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_DATE;

        protected TextBox fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_TIME_LONG;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:20 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try  
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM":
                        fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM = (TextBox)DataListField;

                        fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM.LookupNotOn -= fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_LookupNotOn;
                        fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM.LookupNotOn += fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_LookupNotOn;

                        fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM.LookupOn -= fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_LookupOn;
                        fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM.LookupOn += fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_LookupOn;

                        fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM.Process -= fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_Process;
                        fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM.Process += fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_Process;

                        CoreField = fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM;
                        fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM.Bind(fleMANUAL_REJECTED_CLAIMS_HIST);
                        break;
                    case "FLDGRDMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE":
                        fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE = (TextBox)DataListField;

                        fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE.LookupOn -= fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE_LookupOn;
                        fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE.LookupOn += fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE_LookupOn;
                        CoreField = fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE;
                        fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE.Bind(fleMANUAL_REJECTED_CLAIMS_HIST);
                        break;
                    case "FLDGRDMANUAL_REJECTED_CLAIMS_HIST_PED":
                        fldMANUAL_REJECTED_CLAIMS_HIST_PED = (DateControl)DataListField;
                        CoreField = fldMANUAL_REJECTED_CLAIMS_HIST_PED;
                        fldMANUAL_REJECTED_CLAIMS_HIST_PED.Bind(fleMANUAL_REJECTED_CLAIMS_HIST);
                        break;
                    case "FLDGRDMANUAL_REJECTED_CLAIMS_HIST_CLMHDR_DOC_NBR":
                        fldMANUAL_REJECTED_CLAIMS_HIST_CLMHDR_DOC_NBR = (TextBox)DataListField;
                        CoreField = fldMANUAL_REJECTED_CLAIMS_HIST_CLMHDR_DOC_NBR;
                        fldMANUAL_REJECTED_CLAIMS_HIST_CLMHDR_DOC_NBR.Bind(fleMANUAL_REJECTED_CLAIMS_HIST);
                        break;
                    case "FLDGRDX_NAME":
                        fldX_NAME = (TextBox)DataListField;
                        CoreField = fldX_NAME;
                        fldX_NAME.Bind(X_NAME);
                        break;
                    case "FLDGRDMANUAL_REJECTED_CLAIMS_HIST_ENTRY_DATE":
                        fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_DATE = (DateControl)DataListField;
                        CoreField = fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_DATE;
                        fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_DATE.Bind(fleMANUAL_REJECTED_CLAIMS_HIST);
                        break;
                    case "FLDGRDMANUAL_REJECTED_CLAIMS_HIST_ENTRY_TIME_LONG":
                        fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_TIME_LONG = (TextBox)DataListField;
                        CoreField = fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_TIME_LONG;
                        fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_TIME_LONG.Bind(fleMANUAL_REJECTED_CLAIMS_HIST);
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
                dtlMANUAL_REJECTED_CLAIMS_HIST.OccursWithFile = fleMANUAL_REJECTED_CLAIMS_HIST;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:21 AM

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
            fleMANUAL_REJECTED_CLAIMS_HIST.Transaction = m_trnTRANS_UPDATE;
            fleF002FIND.Transaction = m_trnTRANS_UPDATE;
            fleF010FIND.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:21 AM

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
                fleMANUAL_REJECTED_CLAIMS_HIST.Dispose();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
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

        //#-----------------------------------------
        //# PreDisplayFormatting Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:21 AM

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



        private void fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF093_OHIP_ERROR_MSG_MSTR.ElementOwner("OHIP_ERR_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF093_OHIP_ERROR_MSG_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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




        private void fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleMANUAL_REJECTED_CLAIMS_HIST.ElementOwner("CLMHDR_BATCH_NBR"));
                //Parent:MANUAL_REJECTED_CLAIM
                strSQL.Append(",  ").Append(" AND ").Append(fleMANUAL_REJECTED_CLAIMS_HIST.ElementOwner("CLMHDR_CLAIM_NBR"));
                //Parent:MANUAL_REJECTED_CLAIM
                strSQL.Append(" FROM ");
                strSQL.Append(fleMANUAL_REJECTED_CLAIMS_HIST.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleMANUAL_REJECTED_CLAIMS_HIST.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ").Append(Common.StringToField((FieldText).PadRight(10).Substring(0, 8)));
                //Parent:MANUAL_REJECTED_CLAIM
                strSQL.Append(" AND ").Append("     ").Append(fleMANUAL_REJECTED_CLAIMS_HIST.ElementOwner("CLMHDR_CLAIM_NBR")).Append(" = ").Append(Common.StringToField((FieldText).PadRight(10).Substring(8, 2)));
                //Parent:MANUAL_REJECTED_CLAIM

                if (!LookupNotOn(strSQL, fleMANUAL_REJECTED_CLAIMS_HIST, "MANUAL_REJECTED_CLAIM", FieldText))
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




        private void fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ").Append(Common.StringToField("B"));
                strSQL.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ").Append(Common.StringToField(QDesign.Substring(FieldText, 1, 8)));
                strSQL.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append((QDesign.NConvert(QDesign.Substring(FieldText, 9, 2))));
                strSQL.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ").Append(Common.StringToField("00000"));
                strSQL.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ").Append(Common.StringToField("0"));

                fleF002_CLAIMS_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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
                    case "MANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE":
                        return "EH2";
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

        protected override bool PostFind()
        {


            try
            {

                while (fleMANUAL_REJECTED_CLAIMS_HIST.For())
                {
                    // --> GET F002FIND <--

                    fleF002FIND.GetData(GetDataOptions.IsOptional);
                    // --> End GET F002FIND <--
                    if (AccessOk)
                    {
                        // --> GET F010FIND <--

                        fleF010FIND.GetData(GetDataOptions.IsOptional);
                        // --> End GET F010FIND <--
                        if (AccessOk)
                        {
                            X_NAME.Value = QDesign.Pack(fleF010FIND.GetStringValue("PAT_SURNAME_FIRST6") + fleF010FIND.GetStringValue("PAT_SURNAME_LAST19") + ", " + fleF010FIND.GetStringValue("PAT_GIVEN_NAME_FIRST3") + fleF010FIND.GetStringValue("PAT_GIVEN_NAME_LAST14"));
                            //Parent:PAT_SURNAME    'Parent:PAT_GIVEN_NAME
                            Display(ref fldX_NAME);
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



        private void fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM_Process()
        {

            try
            {

                fleMANUAL_REJECTED_CLAIMS_HIST.set_SetValue("CLMHDR_DOC_NBR", QDesign.Substring(fleMANUAL_REJECTED_CLAIMS_HIST.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleMANUAL_REJECTED_CLAIMS_HIST.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2), 3, 3));
                //Parent:MANUAL_REJECTED_CLAIM
                Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_CLMHDR_DOC_NBR);
                fleMANUAL_REJECTED_CLAIMS_HIST.set_SetValue("PED", fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_DATE_PERIOD_END"));
                Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_PED);
                // --> GET F010_PAT_MSTR <--

                fleF010_PAT_MSTR.GetData(GetDataOptions.IsOptional);
                // --> End GET F010_PAT_MSTR <--
                if (!AccessOk)
                {
                    Warning("*W* Claim does NOT have Patient Id\a");
                }
                else
                {
                    if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) != QDesign.NULL("ON"))
                    {
                        Warning("*W* Patient is NOT an Ontario patient\a");
                    }
                    X_NAME.Value = QDesign.Pack(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST19") + ", " + fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_LAST14"));
                    //Parent:PAT_SURNAME    'Parent:PAT_GIVEN_NAME
                    Display(ref fldX_NAME);
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
                while (fleMANUAL_REJECTED_CLAIMS_HIST.ForMissing())
                {
                    switch (m_intPath)
                    {
                        case 1:
                            m_strWhere = new StringBuilder(GetWhereClauseString(fleMANUAL_REJECTED_CLAIMS_HIST.ElementOwner("ENTRY_DATE"), fleMANUAL_REJECTED_CLAIMS_HIST.GetDateValue("ENTRY_DATE"), blnAddWhere));
                            fleMANUAL_REJECTED_CLAIMS_HIST.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                            break;
                        case 2:
                            m_strWhere = new StringBuilder(GetWhereCondition(fleMANUAL_REJECTED_CLAIMS_HIST.ElementOwner("CLMHDR_BATCH_NBR"), (fleMANUAL_REJECTED_CLAIMS_HIST.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleMANUAL_REJECTED_CLAIMS_HIST.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2)).PadRight(10).Substring(0, 8), ref blnAddWhere));
                            //Parent:MANUAL_REJECTED_CLAIM    'Parent:MANUAL_REJECTED_CLAIM
                            m_strWhere.Append(GetWhereCondition(fleMANUAL_REJECTED_CLAIMS_HIST.ElementOwner("CLMHDR_CLAIM_NBR"), (fleMANUAL_REJECTED_CLAIMS_HIST.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleMANUAL_REJECTED_CLAIMS_HIST.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2)).PadRight(10).Substring(8, 2), ref blnAddWhere));
                            //Parent:MANUAL_REJECTED_CLAIM    'Parent:MANUAL_REJECTED_CLAIM
                            fleMANUAL_REJECTED_CLAIMS_HIST.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                            break;
                        case 3:
                            fleMANUAL_REJECTED_CLAIMS_HIST.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
                            break;
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



        protected override bool Path()
        {


            try
            {
                RequestPrompt(ref fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_DATE);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
                    }
                }
                if (m_intPath == 0)
                {
                    m_intPath = 3;
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
                Page.PageTitle = "Entry of Claims MANUALLY rejected by Ohip";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:20 AM
                Accept(ref fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM);
                Accept(ref fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE);
                Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_PED);
                Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_CLMHDR_DOC_NBR);
                Display(ref fldX_NAME);
                Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_DATE);
                Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_TIME_LONG);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
               
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:20 AM
                while (fleMANUAL_REJECTED_CLAIMS_HIST.For())
                {
                    fleMANUAL_REJECTED_CLAIMS_HIST.PutData(false, PutTypes.Deleted);
                }
                while (fleMANUAL_REJECTED_CLAIMS_HIST.For())
                {
                    fleMANUAL_REJECTED_CLAIMS_HIST.PutData();
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
        //# Delete Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:20 AM
                fleMANUAL_REJECTED_CLAIMS_HIST.DeletedRecord = true;
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
        //# dtlMANUAL_REJECTED_CLAIMS_HIST_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        private void dtlMANUAL_REJECTED_CLAIMS_HIST_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:20 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:20 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:20 AM
                if (!fleMANUAL_REJECTED_CLAIMS_HIST.NewRecord)
                {
                    Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM);
                }
                else
                {
                    Accept(ref fldMANUAL_REJECTED_CLAIMS_HIST_MANUAL_REJECTED_CLAIM);
                }
                Accept(ref fldMANUAL_REJECTED_CLAIMS_HIST_OHIP_ERR_CODE);
                Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_PED);
                Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_CLMHDR_DOC_NBR);
                Display(ref fldX_NAME);
                Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_DATE);
                Display(ref fldMANUAL_REJECTED_CLAIMS_HIST_ENTRY_TIME_LONG);
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

