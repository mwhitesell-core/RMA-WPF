
#region "Screen Comments"

// #>  PROGRAM-ID.      M010_ins.QKS
// ((C)) DYAD TECHNOLOGIES
// PROGRAM PURPOSE : patient`s claims that are possible paid by the insurance company
// this program is called from m010.qks from designer `ins`  or
// is called from d003.cbl from option `I`
// MODIFICATION HISTORY
// DATE          WHO           DESCRIPTION
// 2013/May/29    M.C.     original      

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

    partial class Moira_M010_INS : BasePage
    {

        #region " Form Designer Generated Code "





        public Moira_M010_INS()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M010_INS";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;



            fleF010_INS.SumIntoFields = "PERCENTAGE_TO_PAY";









            this.GridDesigner = "dsrDesigner_01";


            dsrDesigner_01.DefaultFirstRowInGrid = true;

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF010_INS.EditClick += dtlF010_INS_EditClick;
            fldF010_INS_INS_ACRONYM.Process += fldF010_INS_INS_ACRONYM_Process;
            fldF010_INS_PERCENTAGE_TO_PAY.Process += fldF010_INS_PERCENTAGE_TO_PAY_Process;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_PAT_IKEY = new CoreCharacter("W_PAT_IKEY", 15, this, Common.cEmptyString);
            W_BATCH_NBR = new CoreCharacter("W_BATCH_NBR", 8, this, Common.cEmptyString);
            W_CLAIM_NBR = new CoreDecimal("W_CLAIM_NBR", 2, this);
            W_CALL_PGM = new CoreCharacter("W_CALL_PGM", 4, this, Common.cEmptyString);
            W_INS_IKEY = new CoreDecimal("W_INS_IKEY", 5, this);
            W_PERCENTAGE_TOTAL = new CoreDecimal("W_PERCENTAGE_TOTAL", 3, this);
            W_PAT_NAME = new CoreCharacter("W_PAT_NAME", 30, this, Common.cEmptyString);
            fleF010_INS = new SqlFileObject(this, FileTypes.Primary, 6, "INDEXED", "F010_INS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            W_INS_ACRONYM = new CoreCharacter("W_INS_ACRONYM", 5, this, fleF010_INS, Common.cEmptyString);
            W_INS_NAME = new CoreCharacter("W_INS_NAME", 30, this, fleF010_INS, Common.cEmptyString);
            fleF010_INS_FIND = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F010_INS", "F010_INS_FIND", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF076_INSURANCE_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F076_INSURANCE_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF076_FIND = new SqlFileObject(this, FileTypes.Designer, fleF010_INS, "INDEXED", "F076_INSURANCE_MSTR", "F076_FIND", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

           
            fleF010_INS_FIND.Access += fleF010_INS_FIND_Access;
            fleF076_INSURANCE_MSTR.Access += fleF076_INSURANCE_MSTR_Access;
            fleF076_FIND.Access += fleF076_FIND_Access;
            fleF010_PAT_MSTR.Access += fleF010_PAT_MSTR_Access;
            fleF010_INS.InitializeItems += fleF010_INS_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF010_INS_FIND.Access -= fleF010_INS_FIND_Access;
            fleF076_INSURANCE_MSTR.Access -= fleF076_INSURANCE_MSTR_Access;
            fleF076_FIND.Access -= fleF076_FIND_Access;
            fleF010_PAT_MSTR.Access -= fleF010_PAT_MSTR_Access;
            fldF010_INS_INS_ACRONYM.LookupOn -= fldF010_INS_INS_ACRONYM_LookupOn;
            fldF010_INS_INS_ACRONYM.LookupNotOn -= fldF010_INS_INS_ACRONYM_LookupNotOn;
            fldF010_INS_INS_ACRONYM.Input -= fldF010_INS_INS_ACRONYM_Input;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF010_INS.EditClick -= dtlF010_INS_EditClick;
            fleF010_INS.InitializeItems -= fleF010_INS_InitializeItems;
            fldF010_INS_INS_ACRONYM.Process -= fldF010_INS_INS_ACRONYM_Process;
            fldF010_INS_PERCENTAGE_TO_PAY.Process -= fldF010_INS_PERCENTAGE_TO_PAY_Process;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_PAT_IKEY;
        private CoreCharacter W_BATCH_NBR;
        private CoreDecimal W_CLAIM_NBR;
        private CoreCharacter W_CALL_PGM;
        private CoreDecimal W_INS_IKEY;
        private CoreDecimal W_PERCENTAGE_TOTAL;
        private CoreCharacter W_PAT_NAME;
        private SqlFileObject fleF010_INS;

        private void fleF010_INS_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF010_INS.set_SetValue("KEY_PAT_MSTR", true, W_PAT_IKEY.Value);
                if (!Fixed)
                    fleF010_INS.set_SetValue("CLMHDR_BATCH_NBR", true, W_BATCH_NBR.Value);
                if (!Fixed)
                    fleF010_INS.set_SetValue("CLMHDR_CLAIM_NBR", true, W_CLAIM_NBR.Value);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleF010_INS_SumInto(string Field, decimal Value, decimal OldValue)
        {

            try
            {
                switch (Field)
                {
                    case "PERCENTAGE_TO_PAY":
                        W_PERCENTAGE_TOTAL.Value += (Value - OldValue);
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

        private CoreCharacter W_INS_ACRONYM;
        private CoreCharacter W_INS_NAME;
        private SqlFileObject fleF010_INS_FIND;

        private void fleF010_INS_FIND_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF010_INS_FIND.ElementOwner("KEY_PAT_MSTR")).Append(" = ").Append(Common.StringToField(W_PAT_IKEY.Value));

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

        private SqlFileObject fleF076_INSURANCE_MSTR;

        private void fleF076_INSURANCE_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF076_INSURANCE_MSTR.ElementOwner("INS_ACRONYM")).Append(" = ").Append(Common.StringToField(W_INS_ACRONYM.Value));

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

        private SqlFileObject fleF076_FIND;

        private void fleF076_FIND_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF076_FIND.ElementOwner("INS_ACRONYM")).Append(" = ").Append(Common.StringToField(fleF010_INS.GetStringValue("INS_ACRONYM")));

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

                strText.Append(" WHERE ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ").Append(Common.StringToField((W_PAT_IKEY.Value).PadRight(16).Substring(0, 1)));
                //Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ").Append(Common.StringToField((W_PAT_IKEY.Value).PadRight(16).Substring(1, 2)));
                //Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ").Append(Common.StringToField((W_PAT_IKEY.Value).PadRight(16).Substring(3, 12)));
                //Parent:KEY_PAT_MSTR
                strText.Append(" AND ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ").Append(Common.StringToField((W_PAT_IKEY.Value).PadRight(16).Substring(15, 1)));
                //Parent:KEY_PAT_MSTR

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:50 AM

        protected TextBox fldF010_INS_CLMHDR_BATCH_NBR;
        protected TextBox fldF010_INS_CLMHDR_CLAIM_NBR;
        protected TextBox fldF010_INS_INS_ACRONYM;
        protected TextBox fldF010_INS_PERCENTAGE_TO_PAY;
        protected TextBox fldF010_INS_POLICY_NBR;

        protected TextBox fldW_INS_NAME;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:50 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF010_INS_CLMHDR_BATCH_NBR":
                        fldF010_INS_CLMHDR_BATCH_NBR = (TextBox)DataListField;
                        CoreField = fldF010_INS_CLMHDR_BATCH_NBR;
                        fldF010_INS_CLMHDR_BATCH_NBR.Bind(fleF010_INS);
                        break;
                    case "FLDGRDF010_INS_CLMHDR_CLAIM_NBR":
                        fldF010_INS_CLMHDR_CLAIM_NBR = (TextBox)DataListField;
                        CoreField = fldF010_INS_CLMHDR_CLAIM_NBR;
                        fldF010_INS_CLMHDR_CLAIM_NBR.Bind(fleF010_INS);
                        break;
                    case "FLDGRDF010_INS_INS_ACRONYM":
                        fldF010_INS_INS_ACRONYM = (TextBox)DataListField;

                        fldF010_INS_INS_ACRONYM.LookupOn -= fldF010_INS_INS_ACRONYM_LookupOn;
                        fldF010_INS_INS_ACRONYM.LookupOn += fldF010_INS_INS_ACRONYM_LookupOn;

                        fldF010_INS_INS_ACRONYM.LookupNotOn -= fldF010_INS_INS_ACRONYM_LookupNotOn;
                        fldF010_INS_INS_ACRONYM.LookupNotOn += fldF010_INS_INS_ACRONYM_LookupNotOn;

                        fldF010_INS_INS_ACRONYM.Input -= fldF010_INS_INS_ACRONYM_Input;
                        fldF010_INS_INS_ACRONYM.Input += fldF010_INS_INS_ACRONYM_Input;
                        CoreField = fldF010_INS_INS_ACRONYM;
                        fldF010_INS_INS_ACRONYM.Bind(fleF010_INS);
                        break;
                    case "FLDGRDF010_INS_PERCENTAGE_TO_PAY":
                        fldF010_INS_PERCENTAGE_TO_PAY = (TextBox)DataListField;
                        CoreField = fldF010_INS_PERCENTAGE_TO_PAY;
                        fldF010_INS_PERCENTAGE_TO_PAY.Bind(fleF010_INS);
                        break;
                    case "FLDGRDF010_INS_POLICY_NBR":
                        fldF010_INS_POLICY_NBR = (TextBox)DataListField;
                        CoreField = fldF010_INS_POLICY_NBR;
                        fldF010_INS_POLICY_NBR.Bind(fleF010_INS);
                        break;
                    case "FLDGRDW_INS_NAME":
                        fldW_INS_NAME = (TextBox)DataListField;
                        CoreField = fldW_INS_NAME;
                        fldW_INS_NAME.Bind(W_INS_NAME);
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
                dtlF010_INS.OccursWithFile = fleF010_INS;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:50 AM

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
            fleF010_INS.Transaction = m_trnTRANS_UPDATE;
            fleF010_INS_FIND.Transaction = m_trnTRANS_UPDATE;
            fleF076_FIND.Transaction = m_trnTRANS_UPDATE;
            fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:50 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF076_INSURANCE_MSTR.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF010_INS.Dispose();
                fleF010_INS_FIND.Dispose();
                fleF076_INSURANCE_MSTR.Dispose();
                fleF076_FIND.Dispose();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:50 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:50 AM
                Display(ref fldW_PAT_IKEY);
                Display(ref fldW_PAT_NAME);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:39:50 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldW_PAT_IKEY.Bind(W_PAT_IKEY);
                fldW_PAT_NAME.Bind(W_PAT_NAME);

            }
            catch (CustomApplicationException ex)
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



        private void fldF010_INS_INS_ACRONYM_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF076_INSURANCE_MSTR.ElementOwner("INS_ACRONYM")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF076_INSURANCE_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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




        private void fldF010_INS_INS_ACRONYM_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF010_INS.ElementOwner("KEY_PAT_MSTR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF010_INS.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF010_INS.ElementOwner("KEY_PAT_MSTR")).Append(" = ").Append(Common.StringToField(W_PAT_IKEY.Value));
                strSQL.Append(" And ").Append(fleF010_INS.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ").Append(Common.StringToField(W_BATCH_NBR.Value));
                strSQL.Append(" And ").Append(fleF010_INS.ElementOwner("CLMHDR_CLAIM_NBR")).Append(" = ").Append((W_CLAIM_NBR.Value));
                strSQL.Append(" And ").Append(fleF010_INS.ElementOwner("INS_ACRONYM")).Append(" = ").Append(Common.StringToField(fleF076_INSURANCE_MSTR.GetStringValue("INS_ACRONYM")));

                if (!LookupNotOn(strSQL, fleF010_INS, new string[] { "KEY_PAT_MSTR", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "INS_ACRONYM" }, new Object[] { W_PAT_IKEY.Value, W_BATCH_NBR.Value, W_CLAIM_NBR.Value, fleF076_INSURANCE_MSTR.GetStringValue("INS_ACRONYM") }))
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



        protected override object SetFieldDefaults(string Name)
        {


            try
            {
                switch (Name)
                {
                    case "F010_INS_PERCENTAGE_TO_PAY":
                        return 100;
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
                SaveReceivingParams(W_PAT_IKEY, W_BATCH_NBR, W_CLAIM_NBR, W_CALL_PGM);


            }
            catch (CustomApplicationException ex)
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
                Receiving(W_PAT_IKEY, W_BATCH_NBR, W_CLAIM_NBR, W_CALL_PGM);


            }
            catch (CustomApplicationException ex)
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


        private void fldF010_INS_INS_ACRONYM_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) == QDesign.NULL("."))
                {
                    W_INS_ACRONYM.Value = " ";
                    object[] arrRunscreen = { W_INS_ACRONYM };
                    RunScreen(new Moira_M010_INS_F(), RunScreenModes.Find, ref arrRunscreen);
                    FieldText = W_INS_ACRONYM.Value;
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



        private void fldF010_INS_INS_ACRONYM_Process()
        {

            try
            {

                W_INS_NAME.Value = fleF076_INSURANCE_MSTR.GetStringValue("INS_FULL_NAME");
                Display(ref fldW_INS_NAME);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fldF010_INS_PERCENTAGE_TO_PAY_Process()
        {

            try
            {

                if (QDesign.NULL(W_PERCENTAGE_TOTAL.Value) > 100)
                {
                    ErrorMessage("Total percentage to pay cannot be greater than 100%");
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


        private bool Internal_GET_DISPLAY_NAME()
        {


            try
            {

                // --> GET F076_FIND <--

                fleF076_FIND.GetData(GetDataOptions.IsOptional);
                // --> End GET F076_FIND <--
                W_INS_NAME.Value = fleF076_FIND.GetStringValue("INS_FULL_NAME");
                Display(ref fldW_INS_NAME);
                W_PERCENTAGE_TOTAL.Value = W_PERCENTAGE_TOTAL.Value + fleF010_INS.GetDecimalValue("PERCENTAGE_TO_PAY");

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

                m_strWhere = new StringBuilder(" WHERE ").Append(fleF010_PAT_MSTR.ElementOwner("KEY_PAT_MSTR")).Append(" = ").Append(Common.StringToField(W_PAT_IKEY.Value));
                fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);

                W_PAT_NAME.Value = QDesign.RTrim(QDesign.Pack(fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_LAST14"))) + " " + QDesign.Pack(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST19"));
                //Parent:PAT_SURNAME    'Parent:PAT_GIVEN_NAME
                Display(ref fldW_PAT_NAME);
                Display(ref fldW_PAT_IKEY);
                if (QDesign.NULL(W_CALL_PGM.Value) == QDesign.NULL("M010"))
                {
                    while (fleF010_INS.ForMissing())
                    {
                        bool blnAddWhere = true;
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_INS.ElementOwner("KEY_PAT_MSTR"), W_PAT_IKEY.Value, ref blnAddWhere));
                        fleF010_INS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                        Internal_GET_DISPLAY_NAME();
                    }
                }
                if (QDesign.NULL(W_CALL_PGM.Value) == QDesign.NULL("D003"))
                {
                    while (fleF010_INS.ForMissing())
                    {
                        bool blnAddWhere = true;
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF010_INS.ElementOwner("KEY_PAT_MSTR"), W_PAT_IKEY.Value, ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF010_INS.ElementOwner("CLMHDR_CLAIM_NBR"), W_CLAIM_NBR.Value, ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF010_INS.ElementOwner("CLMHDR_BATCH_NBR"), W_BATCH_NBR.Value, ref blnAddWhere));
                        fleF010_INS.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);

                        Internal_GET_DISPLAY_NAME();
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


        protected override bool PreEntry()
        {


            try
            {

                // --> GET F010_PAT_MSTR <--
                m_strWhere = new StringBuilder(" WHERE ");
                m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                m_strWhere.Append(Common.StringToField((W_PAT_IKEY.Value).PadRight(16).Substring(0, 1)));
                //Parent:KEY_PAT_MSTR
                m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                m_strWhere.Append(Common.StringToField((W_PAT_IKEY.Value).PadRight(16).Substring(1, 2)));
                //Parent:KEY_PAT_MSTR
                m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                m_strWhere.Append(Common.StringToField((W_PAT_IKEY.Value).PadRight(16).Substring(3, 12)));
                //Parent:KEY_PAT_MSTR
                m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                m_strWhere.Append(Common.StringToField((W_PAT_IKEY.Value).PadRight(16).Substring(15, 1)));
                //Parent:KEY_PAT_MSTR

                fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                // --> End GET F010_PAT_MSTR <--
                W_PAT_NAME.Value = QDesign.RTrim(QDesign.Pack(fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_LAST14"))) + " " + QDesign.Pack(fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST6") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST19"));
                //Parent:PAT_SURNAME    'Parent:PAT_GIVEN_NAME
                Display(ref fldW_PAT_NAME);
                Display(ref fldW_PAT_IKEY);
                while (fleF010_INS_FIND.WhileRetrieving())
                {
                    W_PERCENTAGE_TOTAL.Value = W_PERCENTAGE_TOTAL.Value + fleF010_INS_FIND.GetDecimalValue("PERCENTAGE_TO_PAY");
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

                W_PERCENTAGE_TOTAL.Value = 0;
                while (fleF010_INS.For())
                {
                    if (!DeletedRecord())
                    {
                        W_PERCENTAGE_TOTAL.Value = W_PERCENTAGE_TOTAL.Value + fleF010_INS.GetDecimalValue("PERCENTAGE_TO_PAY");
                    }
                    if (QDesign.NULL(W_PERCENTAGE_TOTAL.Value) > 100)
                    {
                        ErrorMessage("Error-Total percentage to pay cannot be greater than 100%");
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
                Page.PageTitle = "Patient Insurance Company";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:50 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:50 AM
                Display(ref fldF010_INS_CLMHDR_BATCH_NBR);
                Display(ref fldF010_INS_CLMHDR_CLAIM_NBR);
                Accept(ref fldF010_INS_INS_ACRONYM);
                Accept(ref fldF010_INS_PERCENTAGE_TO_PAY);
                Accept(ref fldF010_INS_POLICY_NBR);
                Display(ref fldW_INS_NAME);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:50 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:50 AM
                Display(ref fldW_PAT_IKEY);
                Display(ref fldW_PAT_NAME);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:50 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:50 AM
                while (fleF010_INS.For())
                {
                    fleF010_INS.PutData(false, PutTypes.Deleted);
                }
                while (fleF010_INS.For())
                {
                    fleF010_INS.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:50 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:50 AM
                fleF010_INS.DeletedRecord = true;
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
        //# dtlF010_INS_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:50 AM
        //#-----------------------------------------
        private void dtlF010_INS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:50 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:39:50 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:39:50 AM
                Display(ref fldF010_INS_CLMHDR_BATCH_NBR);
                Display(ref fldF010_INS_CLMHDR_CLAIM_NBR);
                Accept(ref fldF010_INS_INS_ACRONYM);
                Accept(ref fldF010_INS_PERCENTAGE_TO_PAY);
                Accept(ref fldF010_INS_POLICY_NBR);
                Display(ref fldW_INS_NAME);
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

