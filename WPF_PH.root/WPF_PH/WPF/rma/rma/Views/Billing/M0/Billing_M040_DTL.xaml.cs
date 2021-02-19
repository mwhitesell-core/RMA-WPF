
#region "Screen Comments"

// #>  PROGRAM-ID.      M040_DTL.QKS
// ((C)) DYAD INFOSYS LTD  
// PROGRAM PURPOSE : OMA CD /DEPT detail maintenance  
// this program is called from m100.qks
// MODIFICATION HISTORY
// DATE          WHO           DESCRIPTION
// 2015/Mar/17    M.C.     original
// 2017/Feb/13   MC1    include doc-nbr in the file as suggested by Brad

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

    partial class Billing_M040_DTL : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M040_DTL()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M040_DTL";

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
            dtlF040_DTL.EditClick += dtlF040_DTL_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF040_DTL = new SqlFileObject(this, FileTypes.Primary, 20, "INDEXED", "F040_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_cnnQUERY");

           
            fleF040_OMA_FEE_MSTR.Access += fleF040_OMA_FEE_MSTR_Access;
            fleF070_DEPT_MSTR.Access += fleF070_DEPT_MSTR_Access;
            fleF020_DOCTOR_MSTR.Access += fleF020_DOCTOR_MSTR_Access;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF040_OMA_FEE_MSTR.Access -= fleF040_OMA_FEE_MSTR_Access;
            fleF070_DEPT_MSTR.Access -= fleF070_DEPT_MSTR_Access;
            fleF020_DOCTOR_MSTR.Access -= fleF020_DOCTOR_MSTR_Access;
            fldF040_DTL_DOC_NBR.LookupNotOn -= fldF040_DTL_DOC_NBR_LookupNotOn;
            fldF040_DTL_DEPT_NBR.LookupOn -= fldF040_DTL_DEPT_NBR_LookupOn;
            fldF040_DTL_FEE_OMA_CD.LookupOn -= fldF040_DTL_FEE_OMA_CD_LookupOn;
            fldF040_DTL_DOC_NBR.Edit -= fldF040_DTL_DOC_NBR_Edit;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF040_DTL.EditClick -= dtlF040_DTL_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF040_DTL;
        private SqlFileObject fleF040_OMA_FEE_MSTR;

        private void fleF040_OMA_FEE_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ").Append(Common.StringToField((fleF040_DTL.GetStringValue("FEE_OMA_CD")).PadRight(4).Substring(0, 1)));
                //Parent:FEE_OMA_CD
                strText.Append(" AND ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ").Append(Common.StringToField((fleF040_DTL.GetStringValue("FEE_OMA_CD")).PadRight(4).Substring(1, 1)));
                //Parent:FEE_OMA_CD

                strText.Append(" ORDER BY ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD"));
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

                strText.Append(" WHERE ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ").Append((fleF040_DTL.GetDecimalValue("DEPT_NBR")));

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

                strText.Append(" WHERE ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF040_DTL.GetStringValue("DOC_NBR")));

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

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:50 AM

        protected TextBox fldF040_DTL_FEE_OMA_CD;
        protected TextBox fldF040_DTL_DEPT_NBR;
        protected TextBox fldF040_DTL_DOC_NBR;

        protected ComboBox fldF040_DTL_DATA_ENTRY_FLAG;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:50 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF040_DTL_FEE_OMA_CD":
                        fldF040_DTL_FEE_OMA_CD = (TextBox)DataListField;

                        fldF040_DTL_FEE_OMA_CD.LookupOn -= fldF040_DTL_FEE_OMA_CD_LookupOn;
                        fldF040_DTL_FEE_OMA_CD.LookupOn += fldF040_DTL_FEE_OMA_CD_LookupOn;
                        CoreField = fldF040_DTL_FEE_OMA_CD;
                        fldF040_DTL_FEE_OMA_CD.Bind(fleF040_DTL);
                        break;
                    case "FLDGRDF040_DTL_DEPT_NBR":
                        fldF040_DTL_DEPT_NBR = (TextBox)DataListField;

                        fldF040_DTL_DEPT_NBR.LookupOn -= fldF040_DTL_DEPT_NBR_LookupOn;
                        fldF040_DTL_DEPT_NBR.LookupOn += fldF040_DTL_DEPT_NBR_LookupOn;
                        CoreField = fldF040_DTL_DEPT_NBR;
                        fldF040_DTL_DEPT_NBR.Bind(fleF040_DTL);
                        break;
                    case "FLDGRDF040_DTL_DOC_NBR":
                        fldF040_DTL_DOC_NBR = (TextBox)DataListField;

                        fldF040_DTL_DOC_NBR.LookupNotOn -= fldF040_DTL_DOC_NBR_LookupNotOn;
                        fldF040_DTL_DOC_NBR.LookupNotOn += fldF040_DTL_DOC_NBR_LookupNotOn;

                        fldF040_DTL_DOC_NBR.Edit -= fldF040_DTL_DOC_NBR_Edit;
                        fldF040_DTL_DOC_NBR.Edit += fldF040_DTL_DOC_NBR_Edit;
                        CoreField = fldF040_DTL_DOC_NBR;
                        fldF040_DTL_DOC_NBR.Bind(fleF040_DTL);
                        break;
                    case "FLDGRDF040_DTL_DATA_ENTRY_FLAG":
                        fldF040_DTL_DATA_ENTRY_FLAG = (ComboBox)DataListField;
                        CoreField = fldF040_DTL_DATA_ENTRY_FLAG;
                        fldF040_DTL_DATA_ENTRY_FLAG.Bind(fleF040_DTL);
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
                dtlF040_DTL.OccursWithFile = fleF040_DTL;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:50 AM

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
            fleF040_DTL.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:50 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF040_OMA_FEE_MSTR.Connection = m_cnnQUERY;
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
                fleF040_DTL.Dispose();
                fleF040_OMA_FEE_MSTR.Dispose();
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:11:50 AM



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



        private void fldF040_DTL_DOC_NBR_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF040_DTL.ElementOwner("FEE_OMA_CD"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF040_DTL.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF040_DTL.ElementOwner("FEE_OMA_CD")).Append(" = ").Append(Common.StringToField(fleF040_DTL.GetStringValue("FEE_OMA_CD")));
                strSQL.Append(" And ").Append(fleF040_DTL.ElementOwner("DEPT_NBR")).Append(" = ").Append((fleF040_DTL.GetDecimalValue("DEPT_NBR")));
                strSQL.Append(" And ").Append(fleF040_DTL.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF040_DTL, new string[] { "FEE_OMA_CD", "DEPT_NBR", "DOC_NBR" }, new Object[] { fleF040_DTL.GetStringValue("FEE_OMA_CD"), fleF040_DTL.GetDecimalValue("DEPT_NBR"), FieldText }))
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




        private void fldF040_DTL_DEPT_NBR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ").Append((FieldValue));

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




        private void fldF040_DTL_FEE_OMA_CD_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ").Append(Common.StringToField(FieldText.PadLeft(1,' ').Substring(0,1)));
               

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


        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"



        private void fldF040_DTL_DOC_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(FieldText) != QDesign.NULL("   ") & QDesign.NULL(FieldText) != QDesign.NULL("000"))
                {
                    // --> GET F020_DOCTOR_MSTR <--

                    fleF020_DOCTOR_MSTR.GetData(GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--
                    if (!AccessOk)
                    {
                        ErrorMessage("Doctor nbr does not exist in doctor mstr\a");
                    }
                    else
                    {
                        if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) != QDesign.NULL(fleF040_DTL.GetDecimalValue("DEPT_NBR")))
                        {
                            ErrorMessage("Dept is not the same as doctor`s dept\a");
                        }
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




        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF040_DTL.ElementOwner("FEE_OMA_CD"), fleF040_DTL.GetStringValue("FEE_OMA_CD"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF040_DTL.ElementOwner("DEPT_NBR"), fleF040_DTL.GetDecimalValue("DEPT_NBR"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF040_DTL.ElementOwner("DOC_NBR"), fleF040_DTL.GetStringValue("DOC_NBR"), ref blnAddWhere));
                        fleF040_DTL.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF040_DTL.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF040_DTL_FEE_OMA_CD);
                if (m_blnPromptOK)
                {
                    RequestPrompt(ref fldF040_DTL_DEPT_NBR);
                    if (m_blnPromptOK)
                    {
                        RequestPrompt(ref fldF040_DTL_DOC_NBR);
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
                Page.PageTitle = "OMA CD / DEPT / DOC  detail maintenance";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:50 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:50 AM
                Accept(ref fldF040_DTL_FEE_OMA_CD);
                Accept(ref fldF040_DTL_DEPT_NBR);
                Accept(ref fldF040_DTL_DOC_NBR);
                Accept(ref fldF040_DTL_DATA_ENTRY_FLAG);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:50 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:50 AM
                while (fleF040_DTL.For())
                {
                    fleF040_DTL.PutData(false, PutTypes.Deleted);
                }
                while (fleF040_DTL.For())
                {
                    fleF040_DTL.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:50 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:50 AM
                fleF040_DTL.DeletedRecord = true;
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
        //# dtlF040_DTL_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:50 AM
        //#-----------------------------------------
        private void dtlF040_DTL_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:50 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:11:50 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:11:50 AM
                if (!fleF040_DTL.NewRecord)
                {
                    Display(ref fldF040_DTL_FEE_OMA_CD);
                }
                else
                {
                    Accept(ref fldF040_DTL_FEE_OMA_CD);
                }
                if (!fleF040_DTL.NewRecord)
                {
                    Display(ref fldF040_DTL_DEPT_NBR);
                }
                else
                {
                    Accept(ref fldF040_DTL_DEPT_NBR);
                }
                if (!fleF040_DTL.NewRecord)
                {
                    Display(ref fldF040_DTL_DOC_NBR);
                }
                else
                {
                    Accept(ref fldF040_DTL_DOC_NBR);
                }
                Accept(ref fldF040_DTL_DATA_ENTRY_FLAG);
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

