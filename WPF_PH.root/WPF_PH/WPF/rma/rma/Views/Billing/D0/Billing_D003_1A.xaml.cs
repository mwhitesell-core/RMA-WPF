
#region "Screen Comments"

// Program: d003_1a.qks 
// Purpose: display the eligibility infor change history of the claim`s patient 
// Usage:   called from d003 passing patient ikey
// 00/jun/19 B.E. - original
// activities find 

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

    partial class Billing_D003_1A : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D003_1A()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D003_1A";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;






            this.GridDesigner = "dsrDesigner_01";


            dsrDesigner_01.DefaultFirstRowInGrid = true;





        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF011_PAT_MSTR_ELIG_HISTORY.EditClick += dtlF011_PAT_MSTR_ELIG_HISTORY_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F011_PAT_MSTR_ELIG_HISTORY.KEY_PAT_MSTR


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            X_I = new CoreCharacter("X_I", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            X_KEY = new CoreCharacter("X_KEY", 15, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
            //flePARAMETER_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PARAMETER_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
            fleF011_PAT_MSTR_ELIG_HISTORY = new SqlFileObject(this, FileTypes.Primary, 18, "INDEXED", "F011_PAT_MSTR_ELIG_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            KEY_PAT_MSTR = new CoreCharacter("KEY_PAT_MSTR", 16, this, Common.cEmptyString);


        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF011_PAT_MSTR_ELIG_HISTORY.EditClick -= dtlF011_PAT_MSTR_ELIG_HISTORY_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter X_I;
        private CoreCharacter X_KEY;
        //private SqlFileObject flePARAMETER_FILE;
        private SqlFileObject fleF011_PAT_MSTR_ELIG_HISTORY;
        private CoreCharacter KEY_PAT_MSTR;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:58:09 AM

        protected TextBox fldF011_PAT_MSTR_ELIG_HISTORY_KEY_PAT_MSTR;
        protected TextBox fldF011_PAT_MSTR_ELIG_HISTORY_PAT_DATE_LAST_MAINT;
        protected TextBox fldF011_PAT_MSTR_ELIG_HISTORY_PAT_HEALTH_NBR;
        protected TextBox fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_HEALTH_NBR;
        protected TextBox fldF011_PAT_MSTR_ELIG_HISTORY_PAT_VERSION_CD;
        protected TextBox fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_VERSION_CD;
        protected TextBox fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE;
        protected TextBox fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE_LAST;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:58:09 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF011_PAT_MSTR_ELIG_HISTORY_KEY_PAT_MSTR":
                        KEY_PAT_MSTR.Value = QDesign.NULL(fleF011_PAT_MSTR_ELIG_HISTORY.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF011_PAT_MSTR_ELIG_HISTORY.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF011_PAT_MSTR_ELIG_HISTORY.GetDecimalValue("PAT_I_NBR"), 12) + fleF011_PAT_MSTR_ELIG_HISTORY.GetStringValue("FILLER4"));

                        fldF011_PAT_MSTR_ELIG_HISTORY_KEY_PAT_MSTR = (TextBox)DataListField;
                        CoreField = fldF011_PAT_MSTR_ELIG_HISTORY_KEY_PAT_MSTR;
                        fldF011_PAT_MSTR_ELIG_HISTORY_KEY_PAT_MSTR.Bind(KEY_PAT_MSTR);
                        break;
                    case "FLDGRDF011_PAT_MSTR_ELIG_HISTORY_PAT_DATE_LAST_MAINT":
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_DATE_LAST_MAINT = (TextBox)DataListField;
                        CoreField = fldF011_PAT_MSTR_ELIG_HISTORY_PAT_DATE_LAST_MAINT;
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_DATE_LAST_MAINT.Bind(fleF011_PAT_MSTR_ELIG_HISTORY);
                        break;
                    case "FLDGRDF011_PAT_MSTR_ELIG_HISTORY_PAT_HEALTH_NBR":
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_HEALTH_NBR = (TextBox)DataListField;
                        CoreField = fldF011_PAT_MSTR_ELIG_HISTORY_PAT_HEALTH_NBR;
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_HEALTH_NBR.Bind(fleF011_PAT_MSTR_ELIG_HISTORY);
                        break;
                    case "FLDGRDF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_HEALTH_NBR":
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_HEALTH_NBR = (TextBox)DataListField;
                        CoreField = fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_HEALTH_NBR;
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_HEALTH_NBR.Bind(fleF011_PAT_MSTR_ELIG_HISTORY);
                        break;
                    case "FLDGRDF011_PAT_MSTR_ELIG_HISTORY_PAT_VERSION_CD":
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_VERSION_CD = (TextBox)DataListField;
                        CoreField = fldF011_PAT_MSTR_ELIG_HISTORY_PAT_VERSION_CD;
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_VERSION_CD.Bind(fleF011_PAT_MSTR_ELIG_HISTORY);
                        break;
                    case "FLDGRDF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_VERSION_CD":
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_VERSION_CD = (TextBox)DataListField;
                        CoreField = fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_VERSION_CD;
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_VERSION_CD.Bind(fleF011_PAT_MSTR_ELIG_HISTORY);
                        break;
                    case "FLDGRDF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE":
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE = (TextBox)DataListField;
                        CoreField = fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE;
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE.Bind(fleF011_PAT_MSTR_ELIG_HISTORY);
                        break;
                    case "FLDGRDF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE_LAST":
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE_LAST = (TextBox)DataListField;
                        CoreField = fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE_LAST;
                        fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE_LAST.Bind(fleF011_PAT_MSTR_ELIG_HISTORY);
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
                dtlF011_PAT_MSTR_ELIG_HISTORY.OccursWithFile = fleF011_PAT_MSTR_ELIG_HISTORY;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:58:09 AM

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
            //flePARAMETER_FILE.Transaction = m_trnTRANS_UPDATE;
            fleF011_PAT_MSTR_ELIG_HISTORY.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:58:09 AM

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
                //flePARAMETER_FILE.Dispose();
                fleF011_PAT_MSTR_ELIG_HISTORY.Dispose();


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 9:58:09 AM



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

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


        protected override bool Initialize()
        {


            try
            {
                X_I.Value = ApplicationState.Current.Session["PAT_MSTR_KEY"].ToString().Substring(0, 1);
                X_KEY.Value = ApplicationState.Current.Session["PAT_MSTR_KEY"].ToString().Substring(1);

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
                while (fleF011_PAT_MSTR_ELIG_HISTORY.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF011_PAT_MSTR_ELIG_HISTORY.ElementOwner("PAT_I_KEY"), X_I.Value, ref blnAddWhere));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(GetWhereCondition(fleF011_PAT_MSTR_ELIG_HISTORY.ElementOwner("PAT_CON_NBR"), (X_I.Value + X_KEY.Value).PadRight(16).Substring(1, 2), ref blnAddWhere));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(GetWhereCondition(fleF011_PAT_MSTR_ELIG_HISTORY.ElementOwner("PAT_I_NBR"), (X_I.Value + X_KEY.Value).PadRight(16).Substring(3, 12), ref blnAddWhere));
                    //Parent:KEY_PAT_MSTR
                    m_strWhere.Append(GetWhereCondition(fleF011_PAT_MSTR_ELIG_HISTORY.ElementOwner("FILLER4"), (X_I.Value + X_KEY.Value).PadRight(16).Substring(15, 1), ref blnAddWhere));
                    //Parent:KEY_PAT_MSTR
                    fleF011_PAT_MSTR_ELIG_HISTORY.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "Patient Eligibilty Related Information - Change History";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:26 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:26 AM
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_KEY_PAT_MSTR);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_DATE_LAST_MAINT);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_HEALTH_NBR);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_HEALTH_NBR);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_VERSION_CD);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_VERSION_CD);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE_LAST);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:26 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:26 AM
                while (fleF011_PAT_MSTR_ELIG_HISTORY.For())
                {
                    fleF011_PAT_MSTR_ELIG_HISTORY.PutData(false, PutTypes.Deleted);
                }
                while (fleF011_PAT_MSTR_ELIG_HISTORY.For())
                {
                    fleF011_PAT_MSTR_ELIG_HISTORY.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:26 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:56:26 AM
                fleF011_PAT_MSTR_ELIG_HISTORY.DeletedRecord = true;
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
        //# dtlF011_PAT_MSTR_ELIG_HISTORY_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:26 AM
        //#-----------------------------------------
        private void dtlF011_PAT_MSTR_ELIG_HISTORY_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:58:09 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 9:56:26 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 9:58:09 AM
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_KEY_PAT_MSTR);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_DATE_LAST_MAINT);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_HEALTH_NBR);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_HEALTH_NBR);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_VERSION_CD);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_LAST_VERSION_CD);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE);
                Accept(ref fldF011_PAT_MSTR_ELIG_HISTORY_PAT_BIRTH_DATE_LAST);
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
