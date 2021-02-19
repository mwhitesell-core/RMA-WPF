
#region "Screen Comments"

// ------------------------------------------------------------------
// #> PROGRAM-ID.     H020A.QKS
// ((C)) Dyad Technologies
// PURPOSE: Display of YTD system maintained values
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 95/JUL/19  ____   B.M.L.   - original copied from D020A
// 95/NOV/07  ----   M.C.  - USE T-DOC-EP-NBR INSTEAD OF
// T-DOC-EP-YR
// 95/NOV/17  ----   M.C.     - INCLUDE FIELDS FROM F020-DOCTOR-EXTRA
// 1996/NOV/26  ----   M.C.     - PDR 643 - ALLOW USER TO CHANGE
// 1999/jan/31         B.E.     - y2k
// 1999/Jun/07         S.B.     - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 2001/jul/09 B.E. - realignment of fields to match d020a.qks
// 2003/nov/10 b.e. - alpha doctor nbr
// 2004/sep/02 b.e.      - made all fields display so that data can`t be 
// accidently changed
// - added new designer procedcure FIX to allow change
// of each field only after a `secret` password has
// been entered
// ------------------------------------------------------------------

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

    partial class Billing_H020A : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_H020A()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "H020A";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.UseAcceptProcessing = true;








        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_FIX.Click += dsrDesigner_FIX_Click;
            dsrDesigner_11.Click += dsrDesigner_11_Click;
            dsrDesigner_10.Click += dsrDesigner_10_Click;
            dsrDesigner_08.Click += dsrDesigner_08_Click;
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_03.Click += dsrDesigner_03_Click;
            dsrDesigner_05.Click += dsrDesigner_05_Click;
            dsrDesigner_07.Click += dsrDesigner_07_Click;
            dsrDesigner_04.Click += dsrDesigner_04_Click;
            dsrDesigner_12.Click += dsrDesigner_12_Click;
            dsrDesigner_06.Click += dsrDesigner_06_Click;
            dsrDesigner_09.Click += dsrDesigner_09_Click;
            base.Page_Load();

            // TODO: The following elements have Input/Output Scaling defined in the Dictionary or Screen.  Manual steps may be required:
            //       F020_DOC_MSTR_HISTORY.DOC_YRLY_CEILING_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOC_MSTR_HISTORY.DOC_YRLY_EXPENSE_COMPUTED InputScale: 2 OutputScale: 0
            //       F020_DOC_MSTR_HISTORY.DOC_YTDINC_G InputScale: 2 OutputScale: 0


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            T_DOC_NBR = new CoreCharacter("T_DOC_NBR", 3, this, Common.cEmptyString);
            T_DOC_EP_NBR = new CoreDecimal("T_DOC_EP_NBR", 6, this);
            T_PASSWORD = new CoreDate("T_PASSWORD", this);
            T_SYSDATE = new CoreDate("T_SYSDATE", this);
            fleF020_DOC_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOC_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");

          

            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;

            dsrDesigner_FIX.Click -= dsrDesigner_FIX_Click;
            dsrDesigner_11.Click -= dsrDesigner_11_Click;
            dsrDesigner_10.Click -= dsrDesigner_10_Click;
            dsrDesigner_08.Click -= dsrDesigner_08_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_03.Click -= dsrDesigner_03_Click;
            dsrDesigner_05.Click -= dsrDesigner_05_Click;
            dsrDesigner_07.Click -= dsrDesigner_07_Click;
            dsrDesigner_04.Click -= dsrDesigner_04_Click;
            dsrDesigner_12.Click -= dsrDesigner_12_Click;
            dsrDesigner_06.Click -= dsrDesigner_06_Click;
            dsrDesigner_09.Click -= dsrDesigner_09_Click;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter T_DOC_NBR;
        private CoreDecimal T_DOC_EP_NBR;
        private CoreDate T_PASSWORD;
        private CoreDate T_SYSDATE;
        private SqlFileObject fleF020_DOC_MSTR_HISTORY;
        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "EARNINGS - System TOTAL Values";


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
        //#CORE_BEGIN_INCLUDE: SCRTITLE"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:54 AM

        private DCharacter X_SCR_NAME = new DCharacter(55);
        private void X_SCR_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = QDesign.RightJustify(X_SCREEN_NAME.Value);


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

        //#CORE_END_INCLUDE: SCRTITLE"


        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:54 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:54 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:54 AM

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
            fleF020_DOC_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:54 AM

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
                fleF020_DOC_MSTR_HISTORY.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDEAR);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDINC);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDINC_G);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDCEA);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_CEICEA);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDCEX);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_CEICEX);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_CEILING_COMPUTED);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_TOTINC);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_EXPENSE_COMPUTED);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_TOTINC_G);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUA);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUC);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUB);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUD);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_REQUIRE_REVENUE);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_TARGET_REVENUE);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDREQ);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDTAR);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_CEIREQ);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_CEITAR);
                Display(ref fldT_PASSWORD);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_PAYEFT);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_EP_DATE_DEPOSIT);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:54 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF020_DOC_MSTR_HISTORY_DOC_YTDEAR.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YTDINC.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YTDINC_G.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YTDCEA.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_CEICEA.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YTDCEX.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_CEICEX.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YRLY_CEILING_COMPUTED.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_TOTINC.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YRLY_EXPENSE_COMPUTED.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_TOTINC_G.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YTDGUA.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YTDGUC.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YTDGUB.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YTDGUD.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YRLY_REQUIRE_REVENUE.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YRLY_TARGET_REVENUE.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YTDREQ.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_YTDTAR.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_CEIREQ.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_CEITAR.Bind(fleF020_DOC_MSTR_HISTORY);
                fldT_PASSWORD.Bind(T_PASSWORD);
                fldF020_DOC_MSTR_HISTORY_DOC_PAYEFT.Bind(fleF020_DOC_MSTR_HISTORY);
                fldF020_DOC_MSTR_HISTORY_DOC_EP_DATE_DEPOSIT.Bind(fleF020_DOC_MSTR_HISTORY);

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



        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(T_DOC_NBR, T_DOC_EP_NBR);


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
                Receiving(T_DOC_NBR, T_DOC_EP_NBR);


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



        private void dsrDesigner_FIX_Click(object sender, System.EventArgs e)
        {

            try
            {

                T_SYSDATE.Value = QDesign.SysDate(ref m_cnnQUERY);
                Accept(ref fldT_PASSWORD);
                if (QDesign.NULL(T_PASSWORD.Value) == QDesign.NULL(T_SYSDATE.Value))
                {
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDEAR);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDINC);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDINC_G);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDCEA);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_CEICEA);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDCEX);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_CEICEX);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_CEILING_COMPUTED);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_TOTINC);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_EXPENSE_COMPUTED);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_TOTINC_G);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUA);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUC);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUB);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUD);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_REQUIRE_REVENUE);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_TARGET_REVENUE);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDREQ);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDTAR);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_CEIREQ);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_CEITAR);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_PAYEFT);
                    Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_EP_DATE_DEPOSIT);
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
                m_strWhere = new StringBuilder(GetWhereCondition(fleF020_DOC_MSTR_HISTORY.ElementOwner("DOC_NBR"), T_DOC_NBR.Value, ref blnAddWhere));
                m_strWhere.Append(GetWhereCondition(fleF020_DOC_MSTR_HISTORY.ElementOwner("EP_NBR"), T_DOC_EP_NBR.Value, ref blnAddWhere));
                fleF020_DOC_MSTR_HISTORY.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);


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
                Page.PageTitle = X_SCR_NAME.Value;



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                fleF020_DOC_MSTR_HISTORY.PutData();
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
        //# dsrDesigner_11_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_11_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_CEIREQ);
                Display(ref fldF020_DOC_MSTR_HISTORY_DOC_CEITAR);
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
        //# dsrDesigner_10_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_10_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDREQ);
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDTAR);
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
        //# dsrDesigner_08_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_08_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUB);
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUD);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDINC);
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDINC_G);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_03_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDCEA);
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_CEICEA);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_05_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_CEILING_COMPUTED);
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_TOTINC);
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
        //# dsrDesigner_07_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_07_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUA);
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDGUC);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_04_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YTDCEX);
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_CEICEX);
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
        //# dsrDesigner_12_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_12_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_PAYEFT);
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_EP_DATE_DEPOSIT);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_06_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_EXPENSE_COMPUTED);
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_TOTINC_G);
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
        //# dsrDesigner_09_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:54 AM
        //#-----------------------------------------
        private void dsrDesigner_09_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:54 AM
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_REQUIRE_REVENUE);
                Accept(ref fldF020_DOC_MSTR_HISTORY_DOC_YRLY_TARGET_REVENUE);
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
