
#region "Screen Comments"

// Program: m201.qks
// Purpose: Maintain the file of OMA CODE  SUFFIX  SLI                    
// 2011/jun/15 MC1 - define the values for loc-service-location-indicator to override what has defined in 
// the dictionary

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

    partial class Billing_M201 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M201()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M201";

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
            dtlF201_SLI_OMA_CODE_SUFF.EditClick += dtlF201_SLI_OMA_CODE_SUFF_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF201_SLI_OMA_CODE_SUFF = new SqlFileObject(this, FileTypes.Primary, 20, "INDEXED", "F201_SLI_OMA_CODE_SUFF", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_cnnQUERY");

           
            fleF040_OMA_FEE_MSTR.Access += fleF040_OMA_FEE_MSTR_Access;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF040_OMA_FEE_MSTR.Access -= fleF040_OMA_FEE_MSTR_Access;
            fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR.LookupNotOn -= fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR_LookupNotOn;
            fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD.LookupOn -= fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD_LookupOn;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF201_SLI_OMA_CODE_SUFF.EditClick -= dtlF201_SLI_OMA_CODE_SUFF_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF201_SLI_OMA_CODE_SUFF;
        private SqlFileObject fleF040_OMA_FEE_MSTR;

        private void fleF040_OMA_FEE_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD")).Append(" = ").Append(Common.StringToField(fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_CD")));

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


        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:25 AM

        protected TextBox fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD;
        protected ComboBox fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_SUFF;
        protected ComboBox fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR;

        protected ComboBox fldF201_SLI_OMA_CODE_SUFF_FEE_ADMIT_IND;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:25 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD":
                        fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD = (TextBox)DataListField;

                        fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD.LookupOn -= fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD_LookupOn;
                        fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD.LookupOn += fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD_LookupOn;
                        CoreField = fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD;
                        fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD.Bind(fleF201_SLI_OMA_CODE_SUFF);
                        break;
                    case "FLDGRDF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_SUFF":
                        fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_SUFF = (ComboBox)DataListField;
                        CoreField = fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_SUFF;
                        fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_SUFF.Bind(fleF201_SLI_OMA_CODE_SUFF);
                        break;
                    case "FLDGRDF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR":
                        fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR = (ComboBox)DataListField;

                        fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR.LookupNotOn -= fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR_LookupNotOn;
                        fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR.LookupNotOn += fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR_LookupNotOn;
                        CoreField = fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR;
                        fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR.Bind(fleF201_SLI_OMA_CODE_SUFF);
                        break;
                    case "FLDGRDF201_SLI_OMA_CODE_SUFF_FEE_ADMIT_IND":
                        fldF201_SLI_OMA_CODE_SUFF_FEE_ADMIT_IND = (ComboBox)DataListField;
                        CoreField = fldF201_SLI_OMA_CODE_SUFF_FEE_ADMIT_IND;
                        fldF201_SLI_OMA_CODE_SUFF_FEE_ADMIT_IND.Bind(fleF201_SLI_OMA_CODE_SUFF);
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
                dtlF201_SLI_OMA_CODE_SUFF.OccursWithFile = fleF201_SLI_OMA_CODE_SUFF;

            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:25 AM

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
            fleF201_SLI_OMA_CODE_SUFF.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:25 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF040_OMA_FEE_MSTR.Connection = m_cnnQUERY;


            }
            catch (CustomApplicationException ex)
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
                fleF201_SLI_OMA_CODE_SUFF.Dispose();
                fleF040_OMA_FEE_MSTR.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:16:25 AM



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



        private void fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("CLMDTL_OMA_CD"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF201_SLI_OMA_CODE_SUFF.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("CLMDTL_OMA_CD")).Append(" = ").Append(Common.StringToField(fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_CD")));
                strSQL.Append(" And ").Append(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("CLMDTL_OMA_SUFF")).Append(" = ").Append(Common.StringToField(fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_SUFF")));
                strSQL.Append(" And ").Append(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("LOC_SERVICE_LOCATION_INDICATOR")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF201_SLI_OMA_CODE_SUFF, new string[] { "CLMDTL_OMA_CD", "CLMDTL_OMA_SUFF", "LOC_SERVICE_LOCATION_INDICATOR" }, new Object[] { fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_CD"), fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_SUFF"), FieldText }))
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




        private void fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ").Append(Common.StringToField(FieldText.PadRight(4,' ').Substring(0,1)));
                strSQL.Append(" AND ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ").Append(Common.StringToField(FieldText.PadRight(4, ' ').Substring(1)));

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


        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("CLMDTL_OMA_CD"), fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_CD"), ref blnAddWhere));
                        fleF201_SLI_OMA_CODE_SUFF.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("CLMDTL_OMA_CD"), fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_CD"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("CLMDTL_OMA_SUFF"), fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_SUFF"), ref blnAddWhere));
                        fleF201_SLI_OMA_CODE_SUFF.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 3:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("CLMDTL_OMA_CD"), fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_CD"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("CLMDTL_OMA_SUFF"), fleF201_SLI_OMA_CODE_SUFF.GetStringValue("CLMDTL_OMA_SUFF"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF201_SLI_OMA_CODE_SUFF.ElementOwner("LOC_SERVICE_LOCATION_INDICATOR"), fleF201_SLI_OMA_CODE_SUFF.GetStringValue("LOC_SERVICE_LOCATION_INDICATOR"), ref blnAddWhere));
                        fleF201_SLI_OMA_CODE_SUFF.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF201_SLI_OMA_CODE_SUFF.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                    RequestPrompt(ref fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_SUFF);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
                        RequestPrompt(ref fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR);
                        if (m_blnPromptOK)
                        {
                            m_intPath = 3;
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
                Page.PageTitle = "SLI / OMA Code Suffix";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:25 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:25 AM
                Accept(ref fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD);
                Accept(ref fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_SUFF);
                Accept(ref fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR);
                Accept(ref fldF201_SLI_OMA_CODE_SUFF_FEE_ADMIT_IND);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:25 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:25 AM
                while (fleF201_SLI_OMA_CODE_SUFF.For())
                {
                    fleF201_SLI_OMA_CODE_SUFF.PutData(false, PutTypes.Deleted);
                }
                while (fleF201_SLI_OMA_CODE_SUFF.For())
                {
                    fleF201_SLI_OMA_CODE_SUFF.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:25 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:25 AM
                fleF201_SLI_OMA_CODE_SUFF.DeletedRecord = true;
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
        //# dtlF201_SLI_OMA_CODE_SUFF_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:25 AM
        //#-----------------------------------------
        private void dtlF201_SLI_OMA_CODE_SUFF_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:25 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:16:25 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:16:25 AM
                if (!fleF201_SLI_OMA_CODE_SUFF.NewRecord)
                {
                    Display(ref fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD);
                }
                else
                {
                    Accept(ref fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_CD);
                }
                if (!fleF201_SLI_OMA_CODE_SUFF.NewRecord)
                {
                    Display(ref fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_SUFF);
                }
                else
                {
                    Accept(ref fldF201_SLI_OMA_CODE_SUFF_CLMDTL_OMA_SUFF);
                }
                if (!fleF201_SLI_OMA_CODE_SUFF.NewRecord)
                {
                    Display(ref fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR);
                }
                else
                {
                    Accept(ref fldF201_SLI_OMA_CODE_SUFF_LOC_SERVICE_LOCATION_INDICATOR);
                }
                if (!fleF201_SLI_OMA_CODE_SUFF.NewRecord)
                {
                    Display(ref fldF201_SLI_OMA_CODE_SUFF_FEE_ADMIT_IND);
                }
                else
                {
                    Accept(ref fldF201_SLI_OMA_CODE_SUFF_FEE_ADMIT_IND);
                }
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

