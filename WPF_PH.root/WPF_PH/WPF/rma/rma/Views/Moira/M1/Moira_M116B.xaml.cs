
#region "Screen Comments"

// #> PROGRAM-ID.     m116b.qks
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : maintenance of f116-dept-expense-rules-dtl
// MODIFICATION HISTORY
// DATE   WHO DESCRIPTION
// 2008/jun/05 M.C. - original
// 2015/Jun/24 MC1 - comment redundant codes
// predisplay

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

    partial class Moira_M116B : BasePage
    {

        #region " Form Designer Generated Code "





        public Moira_M116B()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M116B";

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
            dtlF116_DEPT_EXPENSE_RULES_DTL.EditClick += dtlF116_DEPT_EXPENSE_RULES_DTL_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF116_DEPT_EXPENSE_RULES_HDR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F116_DEPT_EXPENSE_RULES_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF116_DEPT_EXPENSE_RULES_DTL = new SqlFileObject(this, FileTypes.Primary, 15, "INDEXED", "F116_DEPT_EXPENSE_RULES_DTL", "", true, false, false, 0, "m_trnTRANS_UPDATE");
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_cnnQUERY");
            X_SRCH_CODE = new CoreCharacter("X_SRCH_CODE", 6, this, Common.cEmptyString);
            fleF116_DEPT_EXPENSE_RULES_DTL.InitializeItems += fleF116_DEPT_EXPENSE_RULES_DTL_AutomaticItemInitialization;

            fleF190_COMP_CODES.Access += fleF190_COMP_CODES_Access;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF190_COMP_CODES.Access -= fleF190_COMP_CODES_Access;
            fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.LookupOn -= fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_LookupOn;
            fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.LookupNotOn -= fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_LookupNotOn;
            fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.Input -= fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_Input;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF116_DEPT_EXPENSE_RULES_DTL.EditClick -= dtlF116_DEPT_EXPENSE_RULES_DTL_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF116_DEPT_EXPENSE_RULES_HDR;
        private SqlFileObject fleF116_DEPT_EXPENSE_RULES_DTL;

        private void fleF116_DEPT_EXPENSE_RULES_DTL_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DEPT_EXPENSE_CALC_CODE"))).Append(" AND ");
                strSQL.Append("  ").Append(fleF116_DEPT_EXPENSE_RULES_HDR.GetDecimalValue("DEPT_NBR").ToString()).Append(" =   ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DEPT_NBR")).Append(" AND ");
                strSQL.Append("  ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_AFP_PAYM_GROUP"))).Append(" =   ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" AND ");
                strSQL.Append("  ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_NBR"))).Append(" =   ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DOC_NBR")).Append(")");
                strSQL.Append(")");

                SelectIfClause = strSQL.ToString();


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void fleF116_DEPT_EXPENSE_RULES_DTL_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DEPT_EXPENSE_CALC_CODE", true, fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DEPT_EXPENSE_CALC_CODE"));
                if (!Fixed)
                    fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DEPT_NBR", true, fleF116_DEPT_EXPENSE_RULES_HDR.GetDecimalValue("DEPT_NBR"));
                if (!Fixed)
                    fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DOC_AFP_PAYM_GROUP", true, fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_AFP_PAYM_GROUP"));
                if (!Fixed)
                    fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DOC_NBR", true, fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_NBR"));
                if (!Fixed)
                    fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DESC_LONG", true, fleF190_COMP_CODES.GetStringValue("DESC_LONG"));
                if (!Fixed)
                    fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DESC_SHORT", true, fleF190_COMP_CODES.GetStringValue("DESC_SHORT"));


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("COMP_CODE")));

                strText.Append(" ORDER BY ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
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


        private CoreCharacter X_SRCH_CODE;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:46 PM

        protected TextBox fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE;
        protected TextBox fldF116_DEPT_EXPENSE_RULES_DTL_TITHE_IN_EX_CLUDE_FLAG;
        protected TextBox fldF116_DEPT_EXPENSE_RULES_DTL_FLAG_DISPLAY_HIDE;

        protected TextBox fldF116_DEPT_EXPENSE_RULES_DTL_DESC_LONG;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:46 PM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {


            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE":
                        fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE = (TextBox)DataListField;

                        fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.LookupOn -= fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_LookupOn;
                        fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.LookupOn += fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_LookupOn;

                        fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.LookupNotOn -= fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_LookupNotOn;
                        fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.LookupNotOn += fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_LookupNotOn;

                        fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.Process -= fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_Process;
                        fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.Process += fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_Process;

                        fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.Input -= fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_Input;
                        fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.Input += fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_Input;
                        CoreField = fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE;
                        fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE.Bind(fleF116_DEPT_EXPENSE_RULES_DTL);
                        break;
                    case "FLDGRDF116_DEPT_EXPENSE_RULES_DTL_TITHE_IN_EX_CLUDE_FLAG":
                        fldF116_DEPT_EXPENSE_RULES_DTL_TITHE_IN_EX_CLUDE_FLAG = (TextBox)DataListField;
                        CoreField = fldF116_DEPT_EXPENSE_RULES_DTL_TITHE_IN_EX_CLUDE_FLAG;
                        fldF116_DEPT_EXPENSE_RULES_DTL_TITHE_IN_EX_CLUDE_FLAG.Bind(fleF116_DEPT_EXPENSE_RULES_DTL);
                        break;
                    case "FLDGRDF116_DEPT_EXPENSE_RULES_DTL_FLAG_DISPLAY_HIDE":
                        fldF116_DEPT_EXPENSE_RULES_DTL_FLAG_DISPLAY_HIDE = (TextBox)DataListField;
                        CoreField = fldF116_DEPT_EXPENSE_RULES_DTL_FLAG_DISPLAY_HIDE;
                        fldF116_DEPT_EXPENSE_RULES_DTL_FLAG_DISPLAY_HIDE.Bind(fleF116_DEPT_EXPENSE_RULES_DTL);
                        break;
                    case "FLDGRDF116_DEPT_EXPENSE_RULES_DTL_DESC_LONG":
                        fldF116_DEPT_EXPENSE_RULES_DTL_DESC_LONG = (TextBox)DataListField;
                        CoreField = fldF116_DEPT_EXPENSE_RULES_DTL_DESC_LONG;
                        fldF116_DEPT_EXPENSE_RULES_DTL_DESC_LONG.Bind(fleF116_DEPT_EXPENSE_RULES_DTL);
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
                dtlF116_DEPT_EXPENSE_RULES_DTL.OccursWithFile = fleF116_DEPT_EXPENSE_RULES_DTL;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:46 PM

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
            fleF116_DEPT_EXPENSE_RULES_HDR.Transaction = m_trnTRANS_UPDATE;
            fleF116_DEPT_EXPENSE_RULES_DTL.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:46 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF190_COMP_CODES.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF116_DEPT_EXPENSE_RULES_HDR.Dispose();
                fleF116_DEPT_EXPENSE_RULES_DTL.Dispose();
                fleF190_COMP_CODES.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:46 PM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:46 PM
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE);
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR);
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP);
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR);
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

        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:46 PM
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE);
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR);
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP);
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR);
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
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:46 PM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE.Bind(fleF116_DEPT_EXPENSE_RULES_HDR);
                fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR.Bind(fleF116_DEPT_EXPENSE_RULES_HDR);
                fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP.Bind(fleF116_DEPT_EXPENSE_RULES_HDR);
                fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR.Bind(fleF116_DEPT_EXPENSE_RULES_HDR);

            }
            catch (CustomApplicationException ex)
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



        private void fleF116_DEPT_EXPENSE_RULES_DTL_AutomaticItemInitialization(bool Fixed)
        {
            try
            {
                //TODO: Manual steps may be required.
                fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DEPT_EXPENSE_CALC_CODE", !Fixed, fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DEPT_EXPENSE_CALC_CODE"));
                fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DEPT_NBR", !Fixed, fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DEPT_NBR"));
                fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_AFP_PAYM_GROUP"));
                fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DOC_NBR", !Fixed, fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_NBR"));

            }
            catch (CustomApplicationException ex)
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



        private void fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF190_COMP_CODES.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Comp Code does not exist");
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




        private void fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DEPT_EXPENSE_CALC_CODE"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF116_DEPT_EXPENSE_RULES_DTL.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DEPT_EXPENSE_CALC_CODE")));
                strSQL.Append(" And ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DEPT_NBR")).Append(" = ").Append((fleF116_DEPT_EXPENSE_RULES_DTL.GetDecimalValue("DEPT_NBR")));
                strSQL.Append(" And ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DOC_AFP_PAYM_GROUP")));
                strSQL.Append(" And ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DOC_NBR")));
                strSQL.Append(" And ").Append(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF116_DEPT_EXPENSE_RULES_DTL, new string[] { "DEPT_EXPENSE_CALC_CODE", "DEPT_NBR", "DOC_AFP_PAYM_GROUP", "DOC_NBR", "COMP_CODE" }, new Object[] { fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DEPT_EXPENSE_CALC_CODE"), fleF116_DEPT_EXPENSE_RULES_DTL.GetDecimalValue("DEPT_NBR"), fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DOC_AFP_PAYM_GROUP"), fleF116_DEPT_EXPENSE_RULES_DTL.GetStringValue("DOC_NBR"), FieldText }))
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




        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(fleF116_DEPT_EXPENSE_RULES_HDR);


            }
            catch (CustomApplicationException ex)
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
                Receiving(fleF116_DEPT_EXPENSE_RULES_HDR);


            }
            catch (CustomApplicationException ex)
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



        private void fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) == QDesign.NULL("."))
                {
                    X_SRCH_CODE.Value = " ";
                    object[] arrRunscreen = { X_SRCH_CODE };
                    RunScreen(new Billing_SY033(), RunScreenModes.Find, ref arrRunscreen);
                    if (QDesign.NULL(X_SRCH_CODE.Value) != QDesign.NULL(" "))
                    {
                        FieldText = X_SRCH_CODE.Value;
                    }
                    else
                    {
                        ErrorMessage("Error - A Compensation Code is required.^G^G");
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



        private void fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE_Process()
        {

            try
            {

                fleF116_DEPT_EXPENSE_RULES_DTL.set_SetValue("DESC_LONG", fleF190_COMP_CODES.GetStringValue("DESC_LONG"));


            }
            catch (CustomApplicationException ex)
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
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DEPT_EXPENSE_CALC_CODE"), fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DEPT_EXPENSE_CALC_CODE"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DEPT_NBR"), fleF116_DEPT_EXPENSE_RULES_HDR.GetDecimalValue("DEPT_NBR"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DOC_AFP_PAYM_GROUP"), fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_AFP_PAYM_GROUP"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF116_DEPT_EXPENSE_RULES_DTL.ElementOwner("DOC_NBR"), fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        fleF116_DEPT_EXPENSE_RULES_DTL.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF116_DEPT_EXPENSE_RULES_DTL.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "Dept Expense Rules - Dtl";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:46 PM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:46 PM
                Accept(ref fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_DTL_TITHE_IN_EX_CLUDE_FLAG);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_DTL_FLAG_DISPLAY_HIDE);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_DTL_DESC_LONG);
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:46 PM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:46 PM
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE);
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR);
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP);
                Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR);
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:46 PM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:46 PM
                fleF116_DEPT_EXPENSE_RULES_HDR.PutData(false, PutTypes.New);
                while (fleF116_DEPT_EXPENSE_RULES_DTL.For())
                {
                    fleF116_DEPT_EXPENSE_RULES_DTL.PutData(false, PutTypes.Deleted);
                }
                while (fleF116_DEPT_EXPENSE_RULES_DTL.For())
                {
                    fleF116_DEPT_EXPENSE_RULES_DTL.PutData();
                }
                fleF116_DEPT_EXPENSE_RULES_HDR.PutData();
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:46 PM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:46 PM
                fleF116_DEPT_EXPENSE_RULES_DTL.DeletedRecord = true;
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
        //# dtlF116_DEPT_EXPENSE_RULES_DTL_EditClick Procedure
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:46 PM
        //#-----------------------------------------
        private void dtlF116_DEPT_EXPENSE_RULES_DTL_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:46 PM
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:46 PM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:46 PM
                if (!fleF116_DEPT_EXPENSE_RULES_DTL.NewRecord)
                {
                    Display(ref fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE);
                }
                else
                {
                    Accept(ref fldF116_DEPT_EXPENSE_RULES_DTL_COMP_CODE);
                }
                Accept(ref fldF116_DEPT_EXPENSE_RULES_DTL_TITHE_IN_EX_CLUDE_FLAG);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_DTL_FLAG_DISPLAY_HIDE);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_DTL_DESC_LONG);
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

