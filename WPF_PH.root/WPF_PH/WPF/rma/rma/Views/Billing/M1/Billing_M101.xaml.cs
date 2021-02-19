
#region "Screen Comments"

// #> PROGRAM-ID.     M101.QKS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : CONTRACT DETAIL MAINTENANCE
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 93/MAR/17 M.C.         - ORIGINAL (SMS 140)
// 1999/Apr/23 S.B.      - Y2K checked.

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

    partial class Billing_M101 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M101()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M101";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;



            this.HasPathRequestFields = true;







            this.GridDesigner = "dsrDesigner_06";
            this.ScreenType = ScreenTypes.Composite;


            dsrDesigner_06.DefaultFirstRowInGrid = true;

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_06.Click += dsrDesigner_06_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            fldCONTRACT_MSTR_CONTRACT_CODE.LookupNotOn += fldCONTRACT_MSTR_CONTRACT_CODE_LookupNotOn;
            dtlCONTRACT_DTL.EditClick += dtlCONTRACT_DTL_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleCONTRACT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONTRACT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCONTRACT_DTL = new SqlFileObject(this, FileTypes.Detail, 10, "INDEXED", "CONTRACT_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_cnnQUERY");

           
            fleICONST_MSTR_REC.Access += fleICONST_MSTR_REC_Access;
            fleCONTRACT_DTL.InitializeItems += fleCONTRACT_DTL_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleICONST_MSTR_REC.Access -= fleICONST_MSTR_REC_Access;
            fldCONTRACT_DTL_AGENT_CD.LookupNotOn -= fldCONTRACT_DTL_AGENT_CD_LookupNotOn;
            fldCONTRACT_DTL_CLINIC_NBR.LookupOn -= fldCONTRACT_DTL_CLINIC_NBR_LookupOn;
            fldCONTRACT_MSTR_CONTRACT_CODE.LookupNotOn -= fldCONTRACT_MSTR_CONTRACT_CODE_LookupNotOn;
            fldCONTRACT_DTL_CLINIC_NBR.Edit -= fldCONTRACT_DTL_CLINIC_NBR_Edit;
            fleCONTRACT_DTL.InitializeItems -= fleCONTRACT_DTL_InitializeItems;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_06.Click -= dsrDesigner_06_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlCONTRACT_DTL.EditClick -= dtlCONTRACT_DTL_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleCONTRACT_MSTR;
        private SqlFileObject fleCONTRACT_DTL;

        private void fleCONTRACT_DTL_InitializeItems(bool Fixed)
        {

            try
            {
                fleCONTRACT_DTL.set_SetValue("CONTRACT_CODE", !Fixed, fleCONTRACT_MSTR.GetStringValue("CONTRACT_CODE"));


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

        private SqlFileObject fleICONST_MSTR_REC;

        private void fleICONST_MSTR_REC_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ").Append((fleCONTRACT_DTL.GetDecimalValue("CLINIC_NBR")));

                strText.Append(" ORDER BY ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2"));
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:52 AM

        protected TextBox fldCONTRACT_DTL_CLINIC_NBR;
        protected TextBox fldCONTRACT_DTL_AGENT_CD;
        protected ComboBox fldCONTRACT_DTL_MOH_FLAG;

        protected ComboBox fldCONTRACT_DTL_DOLLAR_FLAG;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:52 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDCONTRACT_DTL_CLINIC_NBR":
                        fldCONTRACT_DTL_CLINIC_NBR = (TextBox)DataListField;

                        fldCONTRACT_DTL_CLINIC_NBR.LookupOn -= fldCONTRACT_DTL_CLINIC_NBR_LookupOn;
                        fldCONTRACT_DTL_CLINIC_NBR.LookupOn += fldCONTRACT_DTL_CLINIC_NBR_LookupOn;

                        fldCONTRACT_DTL_CLINIC_NBR.Edit -= fldCONTRACT_DTL_CLINIC_NBR_Edit;
                        fldCONTRACT_DTL_CLINIC_NBR.Edit += fldCONTRACT_DTL_CLINIC_NBR_Edit;
                        CoreField = fldCONTRACT_DTL_CLINIC_NBR;
                        fldCONTRACT_DTL_CLINIC_NBR.Bind(fleCONTRACT_DTL);
                        break;
                    case "FLDGRDCONTRACT_DTL_AGENT_CD":
                        fldCONTRACT_DTL_AGENT_CD = (TextBox)DataListField;

                        fldCONTRACT_DTL_AGENT_CD.LookupNotOn -= fldCONTRACT_DTL_AGENT_CD_LookupNotOn;
                        fldCONTRACT_DTL_AGENT_CD.LookupNotOn += fldCONTRACT_DTL_AGENT_CD_LookupNotOn;
                        CoreField = fldCONTRACT_DTL_AGENT_CD;
                        fldCONTRACT_DTL_AGENT_CD.Bind(fleCONTRACT_DTL);
                        break;
                    case "FLDGRDCONTRACT_DTL_MOH_FLAG":
                        fldCONTRACT_DTL_MOH_FLAG = (ComboBox)DataListField;
                        CoreField = fldCONTRACT_DTL_MOH_FLAG;
                        fldCONTRACT_DTL_MOH_FLAG.Bind(fleCONTRACT_DTL);
                        break;
                    case "FLDGRDCONTRACT_DTL_DOLLAR_FLAG":
                        fldCONTRACT_DTL_DOLLAR_FLAG = (ComboBox)DataListField;
                        CoreField = fldCONTRACT_DTL_DOLLAR_FLAG;
                        fldCONTRACT_DTL_DOLLAR_FLAG.Bind(fleCONTRACT_DTL);
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
                dtlCONTRACT_DTL.OccursWithFile = fleCONTRACT_DTL;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:52 AM

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
            fleCONTRACT_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleCONTRACT_DTL.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:52 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleICONST_MSTR_REC.Connection = m_cnnQUERY;


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
                fleCONTRACT_MSTR.Dispose();
                fleCONTRACT_DTL.Dispose();
                fleICONST_MSTR_REC.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:51 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:51 AM
                Display(ref fldCONTRACT_MSTR_CONTRACT_CODE);
                Display(ref fldCONTRACT_MSTR_CONTRACT_DESC);
                Display(ref fldCONTRACT_MSTR_ADDRESS_1);
                Display(ref fldCONTRACT_MSTR_ADDRESS_2);
                Display(ref fldCONTRACT_MSTR_ADDRESS_3);
                Display(ref fldCONTRACT_MSTR_POSTAL_CODE);
                Display(ref fldCONTRACT_MSTR_CONTACT_ADMIN);
                Display(ref fldCONTRACT_MSTR_CONTACT_OPER);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:52 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldCONTRACT_MSTR_CONTRACT_CODE.Bind(fleCONTRACT_MSTR);
                fldCONTRACT_MSTR_CONTRACT_DESC.Bind(fleCONTRACT_MSTR);
                fldCONTRACT_MSTR_ADDRESS_1.Bind(fleCONTRACT_MSTR);
                fldCONTRACT_MSTR_ADDRESS_2.Bind(fleCONTRACT_MSTR);
                fldCONTRACT_MSTR_ADDRESS_3.Bind(fleCONTRACT_MSTR);
                fldCONTRACT_MSTR_POSTAL_CODE.Bind(fleCONTRACT_MSTR);
                fldCONTRACT_MSTR_CONTACT_ADMIN.Bind(fleCONTRACT_MSTR);
                fldCONTRACT_MSTR_CONTACT_OPER.Bind(fleCONTRACT_MSTR);

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



        private void fldCONTRACT_DTL_AGENT_CD_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleCONTRACT_DTL.ElementOwner("CONTRACT_CODE"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleCONTRACT_DTL.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleCONTRACT_DTL.ElementOwner("CONTRACT_CODE")).Append(" = ").Append(Common.StringToField(fleCONTRACT_DTL.GetStringValue("CLINIC_NBR")));
                strSQL.Append(" And ").Append(fleCONTRACT_DTL.ElementOwner("CLINIC_NBR")).Append(" = ").Append((FieldValue));

                if (!LookupNotOn(strSQL, fleCONTRACT_DTL, new string[] { "CONTRACT_CODE", "CLINIC_NBR" }, new Object[] { fleCONTRACT_DTL.GetDecimalValue("CLINIC_NBR"), FieldValue }))
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




        private void fldCONTRACT_DTL_CLINIC_NBR_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ").Append((FieldValue));

                fleICONST_MSTR_REC.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("CLINIC NOT DEFINED");
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




        private void fldCONTRACT_MSTR_CONTRACT_CODE_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleCONTRACT_MSTR.ElementOwner("CONTRACT_CODE"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleCONTRACT_MSTR.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleCONTRACT_MSTR.ElementOwner("CONTRACT_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleCONTRACT_MSTR, "CONTRACT_CODE", FieldText))
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


        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"



        private void fldCONTRACT_DTL_CLINIC_NBR_Edit()
        {

            try
            {

                if (QDesign.NULL(fleCONTRACT_DTL.GetDecimalValue("CLINIC_NBR")) < 22)
                {
                    ErrorMessage("CLINIC NBR MUST BE BETWEEN 22 TO 99 INCLUSIVE");
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




        protected override bool DetailFind()
        {


            try
            {
                while (fleCONTRACT_DTL.ForMissing())
                {
                    bool blnAddWhere = true;
                    m_strWhere = new StringBuilder(GetWhereCondition(fleCONTRACT_DTL.ElementOwner("CONTRACT_CODE"), fleCONTRACT_MSTR.GetStringValue("CONTRACT_CODE"), ref blnAddWhere));
                    fleCONTRACT_DTL.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect | GetDataOptions.IsOptional);

            
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
                m_strOrderBy = new StringBuilder(" ORDER BY ").Append(fleCONTRACT_MSTR.ElementOwner("CONTRACT_CODE"));
                bool blnAddWhere = true;
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleCONTRACT_MSTR.ElementOwner("CONTRACT_CODE"), fleCONTRACT_MSTR.GetStringValue("CONTRACT_CODE"), ref blnAddWhere));
                        fleCONTRACT_MSTR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleCONTRACT_MSTR.GetData("", m_strOrderBy.ToString(),GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldCONTRACT_MSTR_CONTRACT_CODE);
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
                Page.PageTitle = "CONTRACT MSTR MAINTENANCE";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:51 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:51 AM
                Accept(ref fldCONTRACT_DTL_CLINIC_NBR);
                Accept(ref fldCONTRACT_DTL_AGENT_CD);
                Accept(ref fldCONTRACT_DTL_MOH_FLAG);
                Accept(ref fldCONTRACT_DTL_DOLLAR_FLAG);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:51 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:51 AM
                Accept(ref fldCONTRACT_MSTR_CONTRACT_CODE);
                Accept(ref fldCONTRACT_MSTR_CONTRACT_DESC);
                Accept(ref fldCONTRACT_MSTR_ADDRESS_1);
                Accept(ref fldCONTRACT_MSTR_ADDRESS_2);
                Accept(ref fldCONTRACT_MSTR_ADDRESS_3);
                Accept(ref fldCONTRACT_MSTR_POSTAL_CODE);
                Accept(ref fldCONTRACT_MSTR_CONTACT_ADMIN);
                Accept(ref fldCONTRACT_MSTR_CONTACT_OPER);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:51 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:51 AM
                fleCONTRACT_MSTR.PutData(false, PutTypes.New);
                while (fleCONTRACT_DTL.For())
                {
                    fleCONTRACT_DTL.PutData(false, PutTypes.Deleted);
                }
                while (fleCONTRACT_DTL.For())
                {
                    fleCONTRACT_DTL.PutData();
                }
                fleCONTRACT_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:51 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:51 AM
                fleCONTRACT_MSTR.DeletedRecord = true;
                while (fleCONTRACT_DTL.For())
                {
                    fleCONTRACT_DTL.DeletedRecord = true;
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
        //# DetailDelete Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:51 AM
        //#-----------------------------------------
        protected override bool DetailDelete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:51 AM
                fleCONTRACT_DTL.DeletedRecord = true;
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
        //# dtlCONTRACT_DTL_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:52 AM
        //#-----------------------------------------
        private void dtlCONTRACT_DTL_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:52 AM
                dsrDesigner_06_Click(null, null);
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
        //# dsrDesigner_02_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:52 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:52 AM
                Accept(ref fldCONTRACT_MSTR_CONTRACT_DESC);
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
        //# dsrDesigner_03_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:52 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:52 AM
                Accept(ref fldCONTRACT_MSTR_ADDRESS_1);
                Accept(ref fldCONTRACT_MSTR_ADDRESS_2);
                Accept(ref fldCONTRACT_MSTR_ADDRESS_3);
                Accept(ref fldCONTRACT_MSTR_POSTAL_CODE);
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
        //# dsrDesigner_05_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:52 AM
        //#-----------------------------------------
        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:52 AM
                Accept(ref fldCONTRACT_MSTR_CONTACT_OPER);
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
        //# dsrDesigner_04_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:52 AM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:52 AM
                Accept(ref fldCONTRACT_MSTR_CONTACT_ADMIN);
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
        //# dsrDesigner_06_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:52 AM
        //#-----------------------------------------
        private void dsrDesigner_06_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:52 AM
                if (!fleCONTRACT_DTL.NewRecord)
                {
                    Display(ref fldCONTRACT_DTL_CLINIC_NBR);
                }
                else
                {
                    Accept(ref fldCONTRACT_DTL_CLINIC_NBR);
                }
                if (!fleCONTRACT_DTL.NewRecord)
                {
                    Display(ref fldCONTRACT_DTL_AGENT_CD);
                }
                else
                {
                    Accept(ref fldCONTRACT_DTL_AGENT_CD);
                }
                Accept(ref fldCONTRACT_DTL_MOH_FLAG);
                Accept(ref fldCONTRACT_DTL_DOLLAR_FLAG);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:52 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:52 AM
                if (!fleCONTRACT_MSTR.NewRecord)
                {
                    Display(ref fldCONTRACT_MSTR_CONTRACT_CODE);
                }
                else
                {
                    Accept(ref fldCONTRACT_MSTR_CONTRACT_CODE);
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

