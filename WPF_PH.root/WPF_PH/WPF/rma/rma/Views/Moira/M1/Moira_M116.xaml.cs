
#region "Screen Comments"

// #> PROGRAM-ID.     m116.qks
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : maintenance of f116-dept-expense-rules-hdr
// MODIFICATION HISTORY
// DATE   WHO DESCRIPTION
// 2008/jun/04 M.C. - original
// 2008/oct/30 M.C. - add upshift to doc-nbr field
// 2015/Jun/24 MC1  - allow entry of doc-nbr
// 2016/Feb/09 MC2       - add designer `EXCL` to populate the excluded tithe doctors records in f116-dtl

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

    partial class Moira_M116 : BasePage
    {

        #region " Form Designer Generated Code "





        public Moira_M116()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M116";

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
            dsrDesigner_DTL.Click += dsrDesigner_DTL_Click;
            dsrDesigner_EXCLUDE.Click += dsrDesigner_EXCLUDE_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF116_DEPT_EXPENSE_RULES_HDR.EditClick += dtlF116_DEPT_EXPENSE_RULES_HDR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF116_DEPT_EXPENSE_RULES_HDR = new SqlFileObject(this, FileTypes.Primary, 15, "INDEXED", "F116_DEPT_EXPENSE_RULES_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF115_DEPT_EXPENSE_CALC_CODES = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F115_DEPT_EXPENSE_CALC_CODES", "", false, false, false, 0, "m_cnnQUERY");
            fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            W_CHECK = new CoreDecimal("W_CHECK", 6, this, fleF116_DEPT_EXPENSE_RULES_HDR, 0m);
            COMLINE = new CoreCharacter("COMLINE", 256, this, Common.cEmptyString);

           
            fleF115_DEPT_EXPENSE_CALC_CODES.Access += fleF115_DEPT_EXPENSE_CALC_CODES_Access;
            fleF070_DEPT_MSTR.Access += fleF070_DEPT_MSTR_Access;
            fleF020_DOCTOR_MSTR.Access += fleF020_DOCTOR_MSTR_Access;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF115_DEPT_EXPENSE_CALC_CODES.Access -= fleF115_DEPT_EXPENSE_CALC_CODES_Access;
            fleF070_DEPT_MSTR.Access -= fleF070_DEPT_MSTR_Access;
            fleF020_DOCTOR_MSTR.Access -= fleF020_DOCTOR_MSTR_Access;
            fldW_CHECK.LookupNotOn -= fldW_CHECK_LookupNotOn;
            fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR.LookupOn -= fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR_LookupOn;
            fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE.LookupOn -= fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE_LookupOn;
            fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR.Edit -= fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR_Edit;

            dsrDesigner_DTL.Click -= dsrDesigner_DTL_Click;
            dsrDesigner_EXCLUDE.Click -= dsrDesigner_EXCLUDE_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF116_DEPT_EXPENSE_RULES_HDR.EditClick -= dtlF116_DEPT_EXPENSE_RULES_HDR_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF116_DEPT_EXPENSE_RULES_HDR;

        private void fleF116_DEPT_EXPENSE_RULES_HDR_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF116_DEPT_EXPENSE_RULES_HDR.set_SetValue("DOC_NBR", true, "000");


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }

        private SqlFileObject fleF115_DEPT_EXPENSE_CALC_CODES;

        private void fleF115_DEPT_EXPENSE_CALC_CODES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF115_DEPT_EXPENSE_CALC_CODES.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DEPT_EXPENSE_CALC_CODE")));

                strText.Append(" ORDER BY ").Append(fleF115_DEPT_EXPENSE_CALC_CODES.ElementOwner("DEPT_EXPENSE_CALC_CODE"));
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

                strText.Append(" WHERE ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ").Append((fleF116_DEPT_EXPENSE_RULES_HDR.GetDecimalValue("DEPT_NBR")));

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

        private SqlFileObject fleF020_DOCTOR_MSTR;

        private void fleF020_DOCTOR_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_NBR")));

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

        private CoreDecimal W_CHECK;

        private CoreCharacter COMLINE;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:47 PM

        protected TextBox fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE;
        protected TextBox fldW_CHECK;
        protected TextBox fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR;
        protected TextBox fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP;
        protected TextBox fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR;

        protected TextBox fldF116_DEPT_EXPENSE_RULES_HDR_TITHE_IN_EX_CLUDE_FLAG;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:47 PM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE":
                        fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE = (TextBox)DataListField;

                        fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE.LookupOn -= fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE_LookupOn;
                        fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE.LookupOn += fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE_LookupOn;
                        CoreField = fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE;
                        fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE.Bind(fleF116_DEPT_EXPENSE_RULES_HDR);
                        break;
                    case "FLDGRDW_CHECK":
                        fldW_CHECK = (TextBox)DataListField;

                        fldW_CHECK.LookupNotOn -= fldW_CHECK_LookupNotOn;
                        fldW_CHECK.LookupNotOn += fldW_CHECK_LookupNotOn;
                        CoreField = fldW_CHECK;
                        fldW_CHECK.Bind(W_CHECK);
                        break;
                    case "FLDGRDF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR":
                        fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR = (TextBox)DataListField;

                        fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR.LookupOn -= fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR_LookupOn;
                        fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR.LookupOn += fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR_LookupOn;
                        CoreField = fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR;
                        fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR.Bind(fleF116_DEPT_EXPENSE_RULES_HDR);
                        break;
                    case "FLDGRDF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP":
                        fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP = (TextBox)DataListField;
                        CoreField = fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP;
                        fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP.Bind(fleF116_DEPT_EXPENSE_RULES_HDR);
                        break;
                    case "FLDGRDF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR":
                        fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR = (TextBox)DataListField;

                        fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR.Edit -= fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR_Edit;
                        fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR.Edit += fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR_Edit;
                        CoreField = fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR;
                        fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR.Bind(fleF116_DEPT_EXPENSE_RULES_HDR);
                        break;
                    case "FLDGRDF116_DEPT_EXPENSE_RULES_HDR_TITHE_IN_EX_CLUDE_FLAG":
                        fldF116_DEPT_EXPENSE_RULES_HDR_TITHE_IN_EX_CLUDE_FLAG = (TextBox)DataListField;
                        CoreField = fldF116_DEPT_EXPENSE_RULES_HDR_TITHE_IN_EX_CLUDE_FLAG;
                        fldF116_DEPT_EXPENSE_RULES_HDR_TITHE_IN_EX_CLUDE_FLAG.Bind(fleF116_DEPT_EXPENSE_RULES_HDR);
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
                dtlF116_DEPT_EXPENSE_RULES_HDR.OccursWithFile = fleF116_DEPT_EXPENSE_RULES_HDR;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:47 PM

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


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:47 PM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF115_DEPT_EXPENSE_CALC_CODES.Connection = m_cnnQUERY;
                fleF070_DEPT_MSTR.Connection = m_cnnQUERY;
                fleF020_DOCTOR_MSTR.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF115_DEPT_EXPENSE_CALC_CODES.Dispose();
                fleF070_DEPT_MSTR.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();


            }
            catch (CustomApplicationException ex)
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

        #endregion

        #region "Update Validation"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.

        #endregion


        #region "RecordBuffer Events"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 7/10/2017 3:57:47 PM



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



        private void fldW_CHECK_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DOC_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF116_DEPT_EXPENSE_RULES_HDR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_NBR")));
                strSQL.Append(" And ").Append(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DEPT_EXPENSE_CALC_CODE")));
                strSQL.Append(" And ").Append(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DEPT_NBR")).Append(" = ").Append((fleF116_DEPT_EXPENSE_RULES_HDR.GetDecimalValue("DEPT_NBR")));
                strSQL.Append(" And ").Append(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ").Append(Common.StringToField(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_AFP_PAYM_GROUP")));

                if (!LookupNotOn(strSQL, fleF116_DEPT_EXPENSE_RULES_HDR, new string[] { "DOC_NBR", "DEPT_EXPENSE_CALC_CODE", "DEPT_NBR", "DOC_AFP_PAYM_GROUP" }, new Object[] { fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_NBR"), fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DEPT_EXPENSE_CALC_CODE"), fleF116_DEPT_EXPENSE_RULES_HDR.GetDecimalValue("DEPT_NBR"), fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_AFP_PAYM_GROUP") }))
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




        private void fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ").Append((FieldText));

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




        private void fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF115_DEPT_EXPENSE_CALC_CODES.ElementOwner("DEPT_EXPENSE_CALC_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF115_DEPT_EXPENSE_CALC_CODES.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
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


        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"



        private void fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_NBR")) != QDesign.NULL("000"))
                {
                    // --> GET F020_DOCTOR_MSTR <--

                    fleF020_DOCTOR_MSTR.GetData(GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--
                    if (!AccessOk)
                    {
                        ErrorMessage("Doctor nbr is not defined in doctor mstr");
                    }
                    if (QDesign.NULL(fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_AFP_PAYM_GROUP")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")))
                    {
                        ErrorMessage("Afp payment group entered is not the same for the doctor in doctor mstr");
                    }
                    if (QDesign.NULL(fleF116_DEPT_EXPENSE_RULES_HDR.GetDecimalValue("DEPT_NBR")) != QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")))
                    {
                        ErrorMessage("Dept entered is not the same for the doctor in doctor mstr");
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



        private void dsrDesigner_DTL_Click(object sender, System.EventArgs e)
        {

            try
            {

                object[] arrRunscreen = { fleF116_DEPT_EXPENSE_RULES_HDR };
                RunScreen(new Moira_M116B(), RunScreenModes.Find, ref arrRunscreen);


            }
            catch (CustomApplicationException ex)
            {
                throw ex;


            }
            catch (Exception ex)
            {
                ExceptionManager.Publish(ex);
                throw ex;

            }

        }



        private void dsrDesigner_EXCLUDE_Click(object sender, System.EventArgs e)
        {

            try
            {

                COMLINE.Value = "$cmd/populate_exclude_dtl " + " " + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"), 2) + " " + fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_AFP_PAYM_GROUP");
                m_blnCommandOK = RunCommand(COMLINE.Value);
                // TODO: Check source code.  Manual process may be required.
                Information(QDesign.NULL("populate excluded doctors for selected dept/paym group in f116-dtl file "));
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




        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DEPT_EXPENSE_CALC_CODE"), fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DEPT_EXPENSE_CALC_CODE"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DEPT_NBR"), fleF116_DEPT_EXPENSE_RULES_HDR.GetDecimalValue("DEPT_NBR"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DOC_AFP_PAYM_GROUP"), fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_AFP_PAYM_GROUP"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF116_DEPT_EXPENSE_RULES_HDR.ElementOwner("DOC_NBR"), fleF116_DEPT_EXPENSE_RULES_HDR.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        fleF116_DEPT_EXPENSE_RULES_HDR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF116_DEPT_EXPENSE_RULES_HDR.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE);
                if (m_blnPromptOK)
                {
                    RequestPrompt(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR);
                    if (m_blnPromptOK)
                    {
                        RequestPrompt(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP);
                        if (m_blnPromptOK)
                        {
                            m_intPath = 1;
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




        public override void PagePostProcess(PageArgs e)
        {

            try
            {
                Page.PageTitle = "Dept Expense Rules";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:47 PM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:47 PM
                Accept(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE);
                Edit(ref fldW_CHECK);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_HDR_TITHE_IN_EX_CLUDE_FLAG);
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:47 PM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:47 PM
                while (fleF116_DEPT_EXPENSE_RULES_HDR.For())
                {
                    fleF116_DEPT_EXPENSE_RULES_HDR.PutData(false, PutTypes.Deleted);
                }
                while (fleF116_DEPT_EXPENSE_RULES_HDR.For())
                {
                    fleF116_DEPT_EXPENSE_RULES_HDR.PutData();
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:47 PM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:47 PM
                fleF116_DEPT_EXPENSE_RULES_HDR.DeletedRecord = true;
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
        //# dtlF116_DEPT_EXPENSE_RULES_HDR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:47 PM
        //#-----------------------------------------
        private void dtlF116_DEPT_EXPENSE_RULES_HDR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:47 PM
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
        //# Precompiler Ver.: 1.0.6387.27217  Generated on: 7/10/2017 3:57:47 PM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6387.27217 Generated on: 7/10/2017 3:57:47 PM
                if (!fleF116_DEPT_EXPENSE_RULES_HDR.NewRecord)
                {
                    Display(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE);
                }
                else
                {
                    Accept(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_EXPENSE_CALC_CODE);
                }
                Edit(ref fldW_CHECK);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_HDR_DEPT_NBR);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_AFP_PAYM_GROUP);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_HDR_DOC_NBR);
                Accept(ref fldF116_DEPT_EXPENSE_RULES_HDR_TITHE_IN_EX_CLUDE_FLAG);
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

