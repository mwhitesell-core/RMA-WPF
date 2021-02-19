
#region "Screen Comments"

// this program may no longer be required
// PROGRAM D085
// PURPOSE: ALLOW ENTRY OF CLAIM NBR AND MESSAGE CODE. TRANSACTION FILE
// CREATED BY THIS PROGRAM USED TO GENERATE LETTERS TO BE SENT
// TO THE PATIENT OF THE CLAIM.  BODY OF LETTER IS DETERMINED
// BY THE MESSAGE CODE ENTERED.
// 93/03/25 m.c. - SMS 141 (ORIGINAL)
// 1999/jan/13 B.E. - y2k
// 1999/dec/09 B.E. - added screen title
// 2003/oct/20 b.e. - 3 alpha doctor nbr

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

    partial class Billing_D085 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D085()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D085";

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
            dsrDesigner_01.Click += dsrDesigner_01_Click;           
            dtlREJECTED_CLAIMS.EditClick += dtlREJECTED_CLAIMS_EditClick;           
            fldREJECTED_CLAIMS_CLAIM_NBR.Process += fldREJECTED_CLAIMS_CLAIM_NBR_Process;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleREJECTED_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 18, "INDEXED", "F085_REJECTED_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            W_DATE = new CoreDate("W_DATE", this);
            fleF002_CLAIMS_MSTR.Access += fleF002_CLAIMS_MSTR_Access;
            fleF010_PAT_MSTR.Access += fleF010_PAT_MSTR_Access;
            X_NAME.GetValue += X_NAME_GetValue;
            X_ADDRESS.GetValue += X_ADDRESS_GetValue;
            W_DATE.GetInitialValue += W_DATE_GetInitialValue;

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF002_CLAIMS_MSTR.Access -= fleF002_CLAIMS_MSTR_Access;
            fleF010_PAT_MSTR.Access -= fleF010_PAT_MSTR_Access;
            X_NAME.GetValue -= X_NAME_GetValue;
            X_ADDRESS.GetValue -= X_ADDRESS_GetValue;
            fldREJECTED_CLAIMS_CLAIM_NBR.LookupNotOn -= fldREJECTED_CLAIMS_CLAIM_NBR_LookupNotOn;
            fldREJECTED_CLAIMS_CLAIM_NBR.LookupOn -= fldREJECTED_CLAIMS_CLAIM_NBR_LookupOn;
            fldREJECTED_CLAIMS_CLAIM_NBR.Edit -= fldREJECTED_CLAIMS_CLAIM_NBR_Edit;
            W_DATE.GetInitialValue -= W_DATE_GetInitialValue;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlREJECTED_CLAIMS.EditClick -= dtlREJECTED_CLAIMS_EditClick;
            fldREJECTED_CLAIMS_CLAIM_NBR.Process -= fldREJECTED_CLAIMS_CLAIM_NBR_Process;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleREJECTED_CLAIMS;
        private SqlFileObject fleF002_CLAIMS_MSTR;

        private void fleF002_CLAIMS_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ").Append(Common.StringToField("B"));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ").Append(Common.StringToField(QDesign.Substring(fleREJECTED_CLAIMS.GetStringValue("CLAIM_NBR"), 1, 8)));
                strText.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append((QDesign.NConvert(QDesign.Substring(fleREJECTED_CLAIMS.GetStringValue("CLAIM_NBR"), 9, 2))));
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

        private DCharacter X_NAME = new DCharacter(20);
        private void X_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Pack(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST19") + ", " + fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_LAST14"));
                //Parent:PAT_SURNAME    'Parent:PAT_GIVEN_NAME


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }
        private DCharacter X_ADDRESS = new DCharacter(25);
        private void X_ADDRESS_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.Pack(fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR1") + ", " + fleF010_PAT_MSTR.GetStringValue("SUBSCR_ADDR2"));


            }
            catch (CustomApplicationException ex)
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

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:21 AM

        protected TextBox fldREJECTED_CLAIMS_CLAIM_NBR;
        protected ComboBox fldREJECTED_CLAIMS_MESS_CODE;
        protected TextBox fldF010_PAT_MSTR_PAT_HEALTH_NBR;
        protected DateControl fldREJECTED_CLAIMS_CLMHDR_SUBMIT_DATE;

        protected TextBox fldREJECTED_CLAIMS_LOGICALLY_DELETED_FLAG;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:56:21 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDREJECTED_CLAIMS_CLAIM_NBR":
                        fldREJECTED_CLAIMS_CLAIM_NBR = (TextBox)DataListField;

                        fldREJECTED_CLAIMS_CLAIM_NBR.LookupNotOn -= fldREJECTED_CLAIMS_CLAIM_NBR_LookupNotOn;
                        fldREJECTED_CLAIMS_CLAIM_NBR.LookupNotOn += fldREJECTED_CLAIMS_CLAIM_NBR_LookupNotOn;

                        fldREJECTED_CLAIMS_CLAIM_NBR.LookupOn -= fldREJECTED_CLAIMS_CLAIM_NBR_LookupOn;
                        fldREJECTED_CLAIMS_CLAIM_NBR.LookupOn += fldREJECTED_CLAIMS_CLAIM_NBR_LookupOn;

                        fldREJECTED_CLAIMS_CLAIM_NBR.Edit -= fldREJECTED_CLAIMS_CLAIM_NBR_Edit;
                        fldREJECTED_CLAIMS_CLAIM_NBR.Edit += fldREJECTED_CLAIMS_CLAIM_NBR_Edit;
                        CoreField = fldREJECTED_CLAIMS_CLAIM_NBR;
                        fldREJECTED_CLAIMS_CLAIM_NBR.Bind(fleREJECTED_CLAIMS);
                        break;
                    case "FLDGRDREJECTED_CLAIMS_MESS_CODE":
                        fldREJECTED_CLAIMS_MESS_CODE = (ComboBox)DataListField;
                        CoreField = fldREJECTED_CLAIMS_MESS_CODE;
                        fldREJECTED_CLAIMS_MESS_CODE.Bind(fleREJECTED_CLAIMS);
                        break;
                    case "FLDGRDF010_PAT_MSTR_PAT_HEALTH_NBR":
                        fldF010_PAT_MSTR_PAT_HEALTH_NBR = (TextBox)DataListField;
                        CoreField = fldF010_PAT_MSTR_PAT_HEALTH_NBR;
                        fldF010_PAT_MSTR_PAT_HEALTH_NBR.Bind(fleF010_PAT_MSTR);
                        break;
                    case "FLDGRDREJECTED_CLAIMS_CLMHDR_SUBMIT_DATE":
                        fldREJECTED_CLAIMS_CLMHDR_SUBMIT_DATE = (DateControl)DataListField;
                        CoreField = fldREJECTED_CLAIMS_CLMHDR_SUBMIT_DATE;
                        fldREJECTED_CLAIMS_CLMHDR_SUBMIT_DATE.Bind(fleREJECTED_CLAIMS);
                        break;
                    case "FLDGRDREJECTED_CLAIMS_LOGICALLY_DELETED_FLAG":
                        fldREJECTED_CLAIMS_LOGICALLY_DELETED_FLAG = (TextBox)DataListField;
                        CoreField = fldREJECTED_CLAIMS_LOGICALLY_DELETED_FLAG;
                        fldREJECTED_CLAIMS_LOGICALLY_DELETED_FLAG.Bind(fleREJECTED_CLAIMS);
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
                dtlREJECTED_CLAIMS.OccursWithFile = fleREJECTED_CLAIMS;

            }
            catch (CustomApplicationException ex)
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
            fleREJECTED_CLAIMS.Transaction = m_trnTRANS_UPDATE;


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
                fleREJECTED_CLAIMS.Dispose();
                fleF002_CLAIMS_MSTR.Dispose();
                fleF010_PAT_MSTR.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:21 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:21 AM
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



        private void fldREJECTED_CLAIMS_CLAIM_NBR_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleREJECTED_CLAIMS.ElementOwner("CLAIM_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleREJECTED_CLAIMS.TableNameWithAlias());
                strSQL.Append(" WHERE ").Append(fleREJECTED_CLAIMS.ElementOwner("CLAIM_NBR")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleREJECTED_CLAIMS, "CLAIM_NBR", FieldText))
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




        private void fldREJECTED_CLAIMS_CLAIM_NBR_LookupOn()
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
                    case "REJECTED_CLAIMS_MESS_CODE":
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

                // --> GET F010_PAT_MSTR <--

                fleF010_PAT_MSTR.GetData(GetDataOptions.IsOptional);
                // --> End GET F010_PAT_MSTR <--
                if (AccessOk)
                {
                    Display(ref fldF010_PAT_MSTR_PAT_HEALTH_NBR);
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



        private void fldREJECTED_CLAIMS_CLAIM_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) != 0 & QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) != 2 & QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) != 4)
                {
                    ErrorMessage("*E* CLAIM IS NOT AGENT 0 OR 2 OR 4\a");
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



        private void fldREJECTED_CLAIMS_CLAIM_NBR_Process()
        {

            try
            {

                // --> GET F010_PAT_MSTR <--

                fleF010_PAT_MSTR.GetData(GetDataOptions.IsOptional);
                // --> End GET F010_PAT_MSTR <--
                if (!AccessOk)
                {
                    ErrorMessage("*E* CLAIM DOES NOT HAVE PATIENT ID\a");
                }
                else
                {
                    if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) != QDesign.NULL("ON"))
                    {
                        ErrorMessage("*E* PATIENT IS NOT AN ONTARIO PATIENT\a");
                    }
                    Display(ref fldF010_PAT_MSTR_PAT_HEALTH_NBR);
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

                while (fleREJECTED_CLAIMS.For())
                {
                    fleREJECTED_CLAIMS.set_SetValue("DOC_NBR", (QDesign.Substring(fleREJECTED_CLAIMS.GetStringValue("CLAIM_NBR"), 3, 3)));
                    fleREJECTED_CLAIMS.set_SetValue("CLMHDR_PAT_OHIP_ID_OR_CHART", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA"));
                    //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART
                    fleREJECTED_CLAIMS.set_SetValue("CLMHDR_LOC", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_LOC"));
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
                        m_strWhere = new StringBuilder(GetWhereCondition(fleREJECTED_CLAIMS.ElementOwner("CLAIM_NBR"), fleREJECTED_CLAIMS.GetStringValue("CLAIM_NBR"), ref blnAddWhere));
                        fleREJECTED_CLAIMS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleREJECTED_CLAIMS.ElementOwner("CLMHDR_PAT_OHIP_ID_OR_CHART"), fleREJECTED_CLAIMS.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART"), ref blnAddWhere));
                        fleREJECTED_CLAIMS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleREJECTED_CLAIMS.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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



        protected override bool Path()
        {


            try
            {
                m_intPath = 0;

                RequestPrompt(ref fldREJECTED_CLAIMS_CLAIM_NBR);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
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
                Page.PageTitle = "Entry of Claim Nbr and Patient Message Code";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:21 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:21 AM
                Accept(ref fldREJECTED_CLAIMS_CLAIM_NBR);
                Accept(ref fldREJECTED_CLAIMS_MESS_CODE);
                Display(ref fldF010_PAT_MSTR_PAT_HEALTH_NBR);
                Accept(ref fldREJECTED_CLAIMS_CLMHDR_SUBMIT_DATE);
                Accept(ref fldREJECTED_CLAIMS_LOGICALLY_DELETED_FLAG);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:21 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:21 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:21 AM
                while (fleREJECTED_CLAIMS.For())
                {
                    fleREJECTED_CLAIMS.PutData(false, PutTypes.Deleted);
                }
                while (fleREJECTED_CLAIMS.For())
                {
                    fleREJECTED_CLAIMS.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:21 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:21 AM
                fleREJECTED_CLAIMS.DeletedRecord = true;
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
        //# dtlREJECTED_CLAIMS_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:21 AM
        //#-----------------------------------------
        private void dtlREJECTED_CLAIMS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:21 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:21 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:21 AM
                Accept(ref fldREJECTED_CLAIMS_CLAIM_NBR);
                Accept(ref fldREJECTED_CLAIMS_MESS_CODE);
                Display(ref fldF010_PAT_MSTR_PAT_HEALTH_NBR);
                Accept(ref fldREJECTED_CLAIMS_CLMHDR_SUBMIT_DATE);
                Accept(ref fldREJECTED_CLAIMS_LOGICALLY_DELETED_FLAG);
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

