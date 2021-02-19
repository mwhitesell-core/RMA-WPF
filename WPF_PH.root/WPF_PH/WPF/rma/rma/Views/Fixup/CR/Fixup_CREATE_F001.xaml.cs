
#region "Screen Comments"


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

    partial class Fixup_CREATE_F001 : BasePage
    {

        #region " Form Designer Generated Code "





        public Fixup_CREATE_F001()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "CREATE_F001";

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
            fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR.LookupNotOn += fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR_LookupNotOn;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR.Process += fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR_Process;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_ACT.Process += fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_ACT_Process;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_AR_DUE.Process += fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_AR_DUE_Process;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_ACT.Process += fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_ACT_Process;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_LAST_CLAIM_NBR.Process += fldF001_BATCH_CONTROL_FILE_BATCTRL_LAST_CLAIM_NBR_Process;
            base.Page_Load();

        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_cnnQUERY");

          
            fleF020_DOCTOR_MSTR.Access += fleF020_DOCTOR_MSTR_Access;
            fleICONST_MSTR_REC.Access += fleICONST_MSTR_REC_Access;
            fleF001_BATCH_CONTROL_FILE.InitializeItems += fleF001_BATCH_CONTROL_FILE_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF020_DOCTOR_MSTR.Access -= fleF020_DOCTOR_MSTR_Access;
            fleICONST_MSTR_REC.Access -= fleICONST_MSTR_REC_Access;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR.LookupNotOn -= fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR_LookupNotOn;
            fleF001_BATCH_CONTROL_FILE.InitializeItems -= fleF001_BATCH_CONTROL_FILE_InitializeItems;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR.Process -= fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR_Process;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_ACT.Process -= fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_ACT_Process;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_AR_DUE.Process -= fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_AR_DUE_Process;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_ACT.Process -= fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_ACT_Process;
            fldF001_BATCH_CONTROL_FILE_BATCTRL_LAST_CLAIM_NBR.Process -= fldF001_BATCH_CONTROL_FILE_BATCTRL_LAST_CLAIM_NBR_Process;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF001_BATCH_CONTROL_FILE;

        private void fleF001_BATCH_CONTROL_FILE_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_TYPE", true, "C");
                if (!Fixed)
                    fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AGENT_CD", true, 1);
                if (!Fixed)
                    fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_BATCH_ENTERED", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY)));
                if (!Fixed)
                    fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_STATUS", true, "1");
                if (!Fixed)
                    fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD_SUB_TYPE", true, "S");


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

                strText.Append(" WHERE ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField((QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 3, 3))));

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

        private SqlFileObject fleICONST_MSTR_REC;

        private void fleICONST_MSTR_REC_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ").Append((QDesign.NConvert(QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 1, 2))));

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:32:24 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:32:24 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:32:24 AM

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
            fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:32:24 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF020_DOCTOR_MSTR.Connection = m_cnnQUERY;
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
                fleF001_BATCH_CONTROL_FILE.Dispose();
                fleF020_DOCTOR_MSTR.Dispose();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:32:24 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:32:24 AM
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_DOC_NBR_OHIP);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CLINIC_NBR);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_DATE_PERIOD_END);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CYCLE_NBR);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_DATE_BATCH_ENTERED);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_TYPE);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_LOC);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_AGENT_CD);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_ADJ_CD);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_I_O_PAT_IND);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_HOSP);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_ACT);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_EST);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_AR_DUE);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_TOT_REV);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_LAST_CLAIM_NBR);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_NBR_CLAIMS_IN_BATCH);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_ACT);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_EST);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_MANUAL_PAY_TOT);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_STATUS);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_ADJ_CD_SUB_TYPE);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:32:24 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:32:24 AM
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_DATE_BATCH_ENTERED);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_TYPE);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_AGENT_CD);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_STATUS);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_ADJ_CD_SUB_TYPE);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:32:24 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_DOC_NBR_OHIP.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_CLINIC_NBR.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_DATE_PERIOD_END.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_CYCLE_NBR.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_DATE_BATCH_ENTERED.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_TYPE.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_LOC.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_AGENT_CD.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_ADJ_CD.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_I_O_PAT_IND.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_HOSP.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_ACT.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_EST.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_AR_DUE.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_TOT_REV.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_LAST_CLAIM_NBR.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_NBR_CLAIMS_IN_BATCH.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_ACT.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_EST.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_MANUAL_PAY_TOT.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_STATUS.Bind(fleF001_BATCH_CONTROL_FILE);
                fldF001_BATCH_CONTROL_FILE_BATCTRL_ADJ_CD_SUB_TYPE.Bind(fleF001_BATCH_CONTROL_FILE);

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



        private void fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF001_BATCH_CONTROL_FILE.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR")).Append(" = ").Append(Common.StringToField(FieldText));

                if (!LookupNotOn(strSQL, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR", FieldText))
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



        private void fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR_Process()
        {

            try
            {

                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData(GetDataOptions.IsOptional);
                // --> End GET F020_DOCTOR_MSTR <--
                if (AccessOk)
                {
                    fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DOC_NBR_OHIP", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
                }
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData(GetDataOptions.IsOptional);
                // --> End GET ICONST_MSTR_REC <--
                if (AccessOk)
                {
                    fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_PERIOD_END", QDesign.ASCII(fleICONST_MSTR_REC.GetNumericDateValue("ICONST_DATE_PERIOD_END")));
                    fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CYCLE_NBR", fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_CYCLE_NBR"));
                    fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CLINIC_NBR", fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_NBR"));
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



        private void fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_ACT_Process()
        {

            try
            {

                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT"));
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_EST);


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



        private void fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_AR_DUE_Process()
        {

            try
            {

                if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) != QDesign.NULL("P"))
                {
                    fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_TOT_REV", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE"));
                    Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_TOT_REV);
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



        private void fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_ACT_Process()
        {

            try
            {

                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_ACT"));
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_EST);


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



        private void fldF001_BATCH_CONTROL_FILE_BATCTRL_LAST_CLAIM_NBR_Process()
        {

            try
            {

                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_NBR_CLAIMS_IN_BATCH", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_LAST_CLAIM_NBR"));
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_NBR_CLAIMS_IN_BATCH);


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
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR"), fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), ref blnAddWhere));
                        fleF001_BATCH_CONTROL_FILE.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF001_BATCH_CONTROL_FILE.GetData(GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR);
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
                Page.PageTitle = "????";
                // TODO: Replace ???? with proper title.



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:32:24 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:32:24 AM
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_NBR);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_DOC_NBR_OHIP);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CLINIC_NBR);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_DATE_PERIOD_END);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CYCLE_NBR);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_DATE_BATCH_ENTERED);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_TYPE);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_LOC);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_AGENT_CD);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_ADJ_CD);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_I_O_PAT_IND);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_HOSP);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_ACT);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_AMT_EST);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_AR_DUE);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_CALC_TOT_REV);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_LAST_CLAIM_NBR);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_NBR_CLAIMS_IN_BATCH);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_ACT);
                Display(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_SVC_EST);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_MANUAL_PAY_TOT);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_BATCH_STATUS);
                Accept(ref fldF001_BATCH_CONTROL_FILE_BATCTRL_ADJ_CD_SUB_TYPE);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:32:24 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:32:24 AM
                fleF001_BATCH_CONTROL_FILE.PutData(false, PutTypes.New);
                fleF001_BATCH_CONTROL_FILE.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:32:24 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:32:24 AM
                fleF001_BATCH_CONTROL_FILE.DeletedRecord = true;
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
