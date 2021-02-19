
#region "Screen Comments"

// PROGRAM:  D713.QKS
// PURPOSE:  QUERY THE DISKETTE ACCOUNTING NUMBER BY RMA CLAIM NBR
// 93/08/31 M. CHAN  - PDR 590 (ORIGINAL)
// 93/09/16 M. CHAN  - ADDITIONAL REQUEST
// - ALSO ALLOW USER TO QUERY BY ACCOUNTING
// NBR
// 95/03/14 B.M.L.  - ADDED CHANGE OPTION TO CLIENT NBR.
// 1999/jan/13 B.E.  - y2k
// 2000/jan/18 M.C.  - include clinic nbr
// 2003/jun/10 M.C.  - include clinic nbr when accessing using claim-nbr-rma-clinic
// 2003/dec/10 A.A.  - alpha doctor nbr
// activities find, change, entry

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

    partial class Billing_D713 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D713()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D713";

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
            fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_RMA.LookupOn += fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_RMA_LookupOn;
            base.Page_Load();

        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF071_CLIENT_RMA_CLAIM_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F071_CLIENT_RMA_CLAIM_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Designer, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

            

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_RMA.LookupOn -= fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_RMA_LookupOn;



        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF071_CLIENT_RMA_CLAIM_NBR;
        private SqlFileObject fleF002_CLAIMS_MSTR;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:15 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:15 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:15 AM

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
            fleF071_CLIENT_RMA_CLAIM_NBR.Transaction = m_trnTRANS_UPDATE;
            fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:15 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();


            }
            catch (CustomApplicationException ex)
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
                fleF071_CLIENT_RMA_CLAIM_NBR.Dispose();
                fleF002_CLAIMS_MSTR.Dispose();


            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:15 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:15 AM
                Display(ref fldF071_CLIENT_RMA_CLAIM_NBR_CLINIC_NBR);
                Display(ref fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_RMA);
                Display(ref fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_CLIENT);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:15 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF071_CLIENT_RMA_CLAIM_NBR_CLINIC_NBR.Bind(fleF071_CLIENT_RMA_CLAIM_NBR);
                fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_RMA.Bind(fleF071_CLIENT_RMA_CLAIM_NBR);
                fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_CLIENT.Bind(fleF071_CLIENT_RMA_CLAIM_NBR);

            }
            catch (CustomApplicationException ex)
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



        private void fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_RMA_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ").Append(Common.StringToField("B"));
                strSQL.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ").Append(Common.StringToField(QDesign.ASCII(fleF071_CLIENT_RMA_CLAIM_NBR.GetDecimalValue("CLINIC_NBR"), 2) + QDesign.Substring(FieldText, 1, 6)));
                strSQL.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ").Append((QDesign.NConvert(QDesign.Substring(FieldText, 7, 2))));
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
                    case "F071_CLIENT_RMA_CLAIM_NBR_CLINIC_NBR":
                        return 22;
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


        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF071_CLIENT_RMA_CLAIM_NBR.ElementOwner("CLINIC_NBR"), fleF071_CLIENT_RMA_CLAIM_NBR.GetDecimalValue("CLINIC_NBR"), ref blnAddWhere));
                        m_strWhere.Append(GetWhereCondition(fleF071_CLIENT_RMA_CLAIM_NBR.ElementOwner("CLAIM_NBR_RMA"), fleF071_CLIENT_RMA_CLAIM_NBR.GetStringValue("CLAIM_NBR_RMA"), ref blnAddWhere));
                        fleF071_CLIENT_RMA_CLAIM_NBR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF071_CLIENT_RMA_CLAIM_NBR.ElementOwner("CLAIM_NBR_CLIENT"), fleF071_CLIENT_RMA_CLAIM_NBR.GetStringValue("CLAIM_NBR_CLIENT"), ref blnAddWhere));
                        fleF071_CLIENT_RMA_CLAIM_NBR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 0:
                         fleF071_CLIENT_RMA_CLAIM_NBR.GetData("", GetDataOptions.CreateSubSelect);
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
                RequestPrompt(ref fldF071_CLIENT_RMA_CLAIM_NBR_CLINIC_NBR);
                if (m_blnPromptOK)
                {
                    RequestPrompt(ref fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_RMA);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 1;
                    }
                }
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_CLIENT);
                    if (m_blnPromptOK)
                    {
                        m_intPath = 2;
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
                Page.PageTitle = "DISKETTE ACCOUNTING NUMBER QUERY";



            }
            catch (CustomApplicationException ex)
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:15 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:15 AM
                Accept(ref fldF071_CLIENT_RMA_CLAIM_NBR_CLINIC_NBR);
                Accept(ref fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_RMA);
                Accept(ref fldF071_CLIENT_RMA_CLAIM_NBR_CLAIM_NBR_CLIENT);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:15 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:15 AM
                fleF071_CLIENT_RMA_CLAIM_NBR.PutData(false, PutTypes.New);
                fleF071_CLIENT_RMA_CLAIM_NBR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:15 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:15 AM
                fleF071_CLIENT_RMA_CLAIM_NBR.DeletedRecord = true;
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

        #endregion

        #endregion

    }


}
