
#region "Screen Comments"

// #> program-id.     d705c.qks
// ((C)) Dyad Technologies
// program purpose : to allow entry/correction of web  manual review 
// comments (placed into claim  description  records)
// MODIFICATION HISTORY
// DATE   WHO  DESCRIPTION
// 00/sep/14 B.E. - original
// 00/sep/25 B.E. - added warning if description text longer than what fits
// into 5 claim description recs
// 00/oct/13 B.E. - clmdtl-line-no made display field, added designer procedure
// `line` to allow input of clmdtl-line-no
// - if any description records found, then clmhdr-manual-review
// flag set to `y`es

#endregion



using System;
using System.IO;
using System.Text;
using System.Windows;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;
using System.Data.SqlClient;
using System.Windows.Input;

namespace rma.Views
{

    partial class Billing_D705C : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D705C()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D705C";

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


        RoutedCommand dsrLINE = new RoutedCommand();

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_LINE.Click += dsrDesigner_LINE_Click;
            dsrDesigner_LINE.KeyUp += dsrDesigner_LINE_KeyUp;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF002_SUSPEND_DESC.EditClick += dtlF002_SUSPEND_DESC_EditClick;

            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_CLMHDR_DOC_OHIP_NBR = new CoreDecimal("W_CLMHDR_DOC_OHIP_NBR", 6, this);
            W_CLMHDR_ACCOUNTING_NBR = new CoreCharacter("W_CLMHDR_ACCOUNTING_NBR", 8, this, Common.cEmptyString);
            X_NBR_DESC_RECS = new CoreDecimal("X_NBR_DESC_RECS", 6, this);
            X_WARN_FLAG = new CoreCharacter("X_WARN_FLAG", 1, this, Common.cEmptyString);
            X_UNIQUE_INDEX_FLAG = new CoreCharacter("X_UNIQUE_INDEX_FLAG", 1, this, Common.cEmptyString);
            fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Master, 0, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF002_SUSPEND_DESC = new SqlFileObject(this, FileTypes.Primary, 4, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF002_DESC_VERIFY = new SqlFileObject(this, FileTypes.Designer, 0, Environment.GetEnvironmentVariable("VS_DIRECTORY"), "F002_SUSPEND_DESC", "F002_DESC_VERIFY", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCONSTANTS_MSTR_REC_2 = new SqlFileObject(this, FileTypes.Reference, 0, "INDEXED", "CONSTANTS_MSTR_REC_2", "", false, false, false, 0, "m_cnnQUERY");

          
            CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
            CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
            CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
            CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
            CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
            CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
            CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
            UPDATED.GetValue += UPDATED_GetValue;
            CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;
            CLMDTL_STATUS_DELETE.GetValue += CLMDTL_STATUS_DELETE_GetValue;
            CLMDTL_STATUS_NEW.GetValue += CLMDTL_STATUS_NEW_GetValue;
            CLMDTL_STATUS_ACTIVE.GetValue += CLMDTL_STATUS_ACTIVE_GetValue;
            CLMDTL_STATUS_UPDATED.GetValue += CLMDTL_STATUS_UPDATED_GetValue;
            fleF002_DESC_VERIFY.Access += fleF002_DESC_VERIFY_Access;
            fleCONSTANTS_MSTR_REC_2.Access += fleCONSTANTS_MSTR_REC_2_Access;
            fleF002_SUSPEND_DESC.InitializeItems += fleF002_SUSPEND_DESC_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            CLMHDR_STATUS_COMPLETE.GetValue -= CLMHDR_STATUS_COMPLETE_GetValue;
            CLMHDR_STATUS_DELETE.GetValue -= CLMHDR_STATUS_DELETE_GetValue;
            CLMHDR_STATUS_CANCEL.GetValue -= CLMHDR_STATUS_CANCEL_GetValue;
            CLMHDR_STATUS_RESUBMIT.GetValue -= CLMHDR_STATUS_RESUBMIT_GetValue;
            CLMHDR_STATUS_ERROR.GetValue -= CLMHDR_STATUS_ERROR_GetValue;
            CLMHDR_STATUS_NOT_COMPLETE.GetValue -= CLMHDR_STATUS_NOT_COMPLETE_GetValue;
            CLMHDR_STATUS_DEFAULT.GetValue -= CLMHDR_STATUS_DEFAULT_GetValue;
            UPDATED.GetValue -= UPDATED_GetValue;
            CLMHDR_STATUS_IGNOR.GetValue -= CLMHDR_STATUS_IGNOR_GetValue;
            CLMDTL_STATUS_DELETE.GetValue -= CLMDTL_STATUS_DELETE_GetValue;
            CLMDTL_STATUS_NEW.GetValue -= CLMDTL_STATUS_NEW_GetValue;
            CLMDTL_STATUS_ACTIVE.GetValue -= CLMDTL_STATUS_ACTIVE_GetValue;
            CLMDTL_STATUS_UPDATED.GetValue -= CLMDTL_STATUS_UPDATED_GetValue;
            fleF002_DESC_VERIFY.Access -= fleF002_DESC_VERIFY_Access;
            fleCONSTANTS_MSTR_REC_2.Access -= fleCONSTANTS_MSTR_REC_2_Access;

            dsrDesigner_LINE.Click -= dsrDesigner_LINE_Click;
            dsrDesigner_LINE.KeyUp -= dsrDesigner_LINE_KeyUp;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF002_SUSPEND_DESC.EditClick -= dtlF002_SUSPEND_DESC_EditClick;
            fleF002_SUSPEND_DESC.InitializeItems -= fleF002_SUSPEND_DESC_InitializeItems;

            CommandBindings.Remove(new CommandBinding(dsrLINE));
            Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreDecimal W_CLMHDR_DOC_OHIP_NBR;
        private CoreCharacter W_CLMHDR_ACCOUNTING_NBR;
        private CoreDecimal X_NBR_DESC_RECS;
        private CoreCharacter X_WARN_FLAG;
        private CoreCharacter X_UNIQUE_INDEX_FLAG;
        //#CORE_BEGIN_INCLUDE: DEF_CLMHDR_STATUS"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:20 AM

        private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter(1);
        private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
        {

            try
            {
                Value = "C";


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

        private DCharacter CLMHDR_STATUS_DELETE = new DCharacter(1);
        private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
        {

            try
            {
                Value = "D";


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

        private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter(1);
        private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
        {

            try
            {
                Value = "Y";


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

        private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter(1);
        private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
        {

            try
            {
                Value = "R";


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

        private DCharacter CLMHDR_STATUS_ERROR = new DCharacter(1);
        private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
        {

            try
            {
                Value = "X";


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

        private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter(1);
        private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
        {

            try
            {
                Value = "N";


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

        private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter(1);
        private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
        {

            try
            {
                Value = " ";


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

        private DCharacter UPDATED = new DCharacter(1);
        private void UPDATED_GetValue(ref string Value)
        {

            try
            {
                Value = "U";


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

        private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter(1);
        private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
        {

            try
            {
                Value = "I";


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

        //#CORE_END_INCLUDE: DEF_CLMHDR_STATUS"

        //#CORE_BEGIN_INCLUDE: DEF_CLMDTL_STATUS"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:20 AM

        private DCharacter CLMDTL_STATUS_DELETE = new DCharacter(1);
        private void CLMDTL_STATUS_DELETE_GetValue(ref string Value)
        {

            try
            {
                Value = "D";


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

        private DCharacter CLMDTL_STATUS_NEW = new DCharacter(1);
        private void CLMDTL_STATUS_NEW_GetValue(ref string Value)
        {

            try
            {
                Value = "N";


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

        private DCharacter CLMDTL_STATUS_ACTIVE = new DCharacter(1);
        private void CLMDTL_STATUS_ACTIVE_GetValue(ref string Value)
        {

            try
            {
                Value = " ";


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

        private DCharacter CLMDTL_STATUS_UPDATED = new DCharacter(1);
        private void CLMDTL_STATUS_UPDATED_GetValue(ref string Value)
        {

            try
            {
                Value = "U";


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

        //#CORE_END_INCLUDE: DEF_CLMDTL_STATUS"

        private SqlFileObject fleF002_SUSPEND_HDR;

        private void fleF002_SUSPEND_HDR_SetItemFinals()
        {
            try
            {
                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_RELATIONSHIP", "Y");
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

        private SqlFileObject fleF002_SUSPEND_DESC;

        private void fleF002_SUSPEND_DESC_InitializeItems(bool Fixed)
        {

            try
            {
                fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_DOC_OHIP_NBR", !Fixed, W_CLMHDR_DOC_OHIP_NBR.Value);
                fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_ACCOUNTING_NBR", !Fixed, W_CLMHDR_ACCOUNTING_NBR.Value);
                if (!Fixed)
                    fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_STATUS", true, " ");


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

        private SqlFileObject fleF002_DESC_VERIFY;

        private void fleF002_DESC_VERIFY_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ").Append((W_CLMHDR_DOC_OHIP_NBR.Value));
                strText.Append(" AND ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ").Append(Common.StringToField(W_CLMHDR_ACCOUNTING_NBR.Value));

                strText.Append(" ORDER BY ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_DOC_OHIP_NBR"));
                strText.Append(", ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_ACCOUNTING_NBR"));
                strText.Append(", ").Append(fleF002_DESC_VERIFY.ElementOwner("CLMDTL_LINE_NO"));
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

        private SqlFileObject fleCONSTANTS_MSTR_REC_2;

        private void fleCONSTANTS_MSTR_REC_2_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleCONSTANTS_MSTR_REC_2.ElementOwner("CONST_REC_NBR")).Append(" = ").Append(("2"));

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

        private void dsrDesigner_LINE_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    dsrDesigner_LINE.OnBlur(dsrDesigner_LINE, null);
                }
            }
            catch (Exception ex) { }
        }


        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:20 AM

        protected TextBox fldF002_SUSPEND_DESC_CLMDTL_LINE_NO;
        protected TextBox fldF002_SUSPEND_DESC_CLMDTL_SUSPEND_DESC;

        protected ComboBox fldF002_SUSPEND_DESC_CLMDTL_STATUS;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:20 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF002_SUSPEND_DESC_CLMDTL_LINE_NO":
                        fldF002_SUSPEND_DESC_CLMDTL_LINE_NO = (TextBox)DataListField;
                        CoreField = fldF002_SUSPEND_DESC_CLMDTL_LINE_NO;
                        fldF002_SUSPEND_DESC_CLMDTL_LINE_NO.Bind(fleF002_SUSPEND_DESC);
                        break;
                    case "FLDGRDF002_SUSPEND_DESC_CLMDTL_SUSPEND_DESC":
                        fldF002_SUSPEND_DESC_CLMDTL_SUSPEND_DESC = (TextBox)DataListField;
                        CoreField = fldF002_SUSPEND_DESC_CLMDTL_SUSPEND_DESC;
                        fldF002_SUSPEND_DESC_CLMDTL_SUSPEND_DESC.Bind(fleF002_SUSPEND_DESC);
                        break;
                    case "FLDGRDF002_SUSPEND_DESC_CLMDTL_STATUS":
                        fldF002_SUSPEND_DESC_CLMDTL_STATUS = (ComboBox)DataListField;
                        CoreField = fldF002_SUSPEND_DESC_CLMDTL_STATUS;
                        fldF002_SUSPEND_DESC_CLMDTL_STATUS.Bind(fleF002_SUSPEND_DESC);
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
                dtlF002_SUSPEND_DESC.OccursWithFile = fleF002_SUSPEND_DESC;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:20 AM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {

            try
            {
                m_cnnTRANS_UPDATE = new SqlConnection(Common.ConnectionStringDecrypt(System.Configuration.ConfigurationManager.AppSettings["ConnectionString10"]));
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
            fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
            fleF002_SUSPEND_DESC.Transaction = m_trnTRANS_UPDATE;
            fleF002_DESC_VERIFY.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:20 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleCONSTANTS_MSTR_REC_2.Connection = m_cnnQUERY;


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
                fleF002_SUSPEND_HDR.Dispose();
                fleF002_SUSPEND_DESC.Dispose();
                fleF002_DESC_VERIFY.Dispose();
                fleCONSTANTS_MSTR_REC_2.Dispose();


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:20 AM



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
                SaveReceivingParams(W_CLMHDR_DOC_OHIP_NBR, W_CLMHDR_ACCOUNTING_NBR, fleF002_SUSPEND_HDR);


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
                Receiving(W_CLMHDR_DOC_OHIP_NBR, W_CLMHDR_ACCOUNTING_NBR, fleF002_SUSPEND_HDR);


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

        //#CORE_BEGIN_INCLUDE: D705_VERIFY_DESC_LENGTH"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:08:20 AM


        private bool Internal_WARN_DESC_MAX_LENGTH()
        {


            try
            {

                X_NBR_DESC_RECS.Value = 0;
                X_WARN_FLAG.Value = "N";
                while (fleF002_DESC_VERIFY.WhileRetrieving())
                {
                    X_NBR_DESC_RECS.Value = X_NBR_DESC_RECS.Value + 1;
                    if (QDesign.NULL(X_NBR_DESC_RECS.Value) == 2)
                    {
                        if (39 < (QDesign.Length(QDesign.RTrim(QDesign.Pack(fleF002_DESC_VERIFY.GetStringValue("CLMDTL_SUSPEND_DESC"))))))
                        {
                            X_WARN_FLAG.Value = "Y";
                        }
                    }
                    if (QDesign.NULL(X_NBR_DESC_RECS.Value) == 3 | QDesign.NULL(X_NBR_DESC_RECS.Value) == 4)
                    {
                        if (QDesign.NULL(fleF002_DESC_VERIFY.GetStringValue("CLMDTL_SUSPEND_DESC")) != QDesign.NULL(" "))
                        {
                            X_WARN_FLAG.Value = "Y";
                        }
                    }
                }
                if (QDesign.NULL(X_WARN_FLAG.Value) == QDesign.NULL("Y"))
                {
                    Information("\aWARNING! There are comments longer than 110 characters that will be ignored");
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

        //#CORE_END_INCLUDE: D705_VERIFY_DESC_LENGTH"

        private void Pressed_F2_Key(object sender, RoutedEventArgs e)
        {
            try
            {
                dsrDesigner_LINE.Focus();
                dsrDesigner_LINE.OnBlur(dsrDesigner_LINE, null);
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


        private void dsrDesigner_LINE_Click(object sender, System.EventArgs e)
        {

            try
            {

                while (fleF002_SUSPEND_DESC.For())
                {
                    Accept(ref fldF002_SUSPEND_DESC_CLMDTL_LINE_NO);
                    fleF002_SUSPEND_DESC.PutData();
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


        protected override bool PreUpdate()
        {


            try
            {

                X_NBR_DESC_RECS.Value = 0;
                while (fleF002_SUSPEND_DESC.For())
                {
                    if (QDesign.NULL(fleF002_SUSPEND_DESC.GetDecimalValue("CLMDTL_LINE_NO")) == 0)
                    {
                        //Core Added - Check if the Occurrence value is already used. If so, throw Unique Index Error
                        X_UNIQUE_INDEX_FLAG.Value = "N";
                        while (fleF002_DESC_VERIFY.WhileRetrieving())
                        {
                            if (fleF002_DESC_VERIFY.GetDecimalValue("CLMDTL_LINE_NO") == Occurrence)
                            {
                                X_UNIQUE_INDEX_FLAG.Value = "Y";
                            }
                        }

                        if (X_UNIQUE_INDEX_FLAG.Value == "N")
                        {
                            fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_LINE_NO", Occurrence);
                        }
                        else
                        {
                            ErrorMessage("Attempt to add a duplicate value when UNIQUE KEY/INDEX was specified. (F002-SUSPEND-DESC*" + Occurrence.ToString().PadLeft(2,'0') + ")");
                        }
                    }
                    if (QDesign.NULL(fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_DELETE.Value) & AlteredRecord())
                    {
                        fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_STATUS", CLMDTL_STATUS_UPDATED.Value);
                        Display(ref fldF002_SUSPEND_DESC_CLMDTL_STATUS);
                    }
                    if (QDesign.NULL(fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_DELETE.Value) & NewRecord())
                    {
                        fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_STATUS", CLMDTL_STATUS_NEW.Value);
                        Display(ref fldF002_SUSPEND_DESC_CLMDTL_STATUS);
                    }
                    if (QDesign.NULL(fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_SUSPEND_DESC")) != QDesign.NULL(" ") & QDesign.NULL(fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_STATUS")) != QDesign.NULL(CLMDTL_STATUS_DELETE.Value) & !DeletedRecord())
                    {
                        X_NBR_DESC_RECS.Value = Occurrence;
                    }
                }
                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_NBR_SUSPEND_DESC_RECS", 1);
                if (QDesign.NULL(X_NBR_DESC_RECS.Value) > 0)
                {
                    if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_RELATIONSHIP")) != QDesign.NULL("Y"))
                    {
                        Information(QDesign.NULL("\a\a*WARNING* - setting `manual review` flag to `Y`es"));
                        // TODO: May need to fix manually
                        fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_RELATIONSHIP", "Y");
                    }
                }
                fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", UPDATED.Value);

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


        protected override bool Initialize()
        {


            try
            {

                Internal_WARN_DESC_MAX_LENGTH();

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
                Environment.SetEnvironmentVariable("LastConnectionString", Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings.ToString());
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = "ConnectionString10";

                bool blnAddWhere = true;
                while (fleF002_SUSPEND_DESC.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_DOC_OHIP_NBR"), W_CLMHDR_DOC_OHIP_NBR.Value, ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_ACCOUNTING_NBR"), W_CLMHDR_ACCOUNTING_NBR.Value, ref blnAddWhere));
                    fleF002_SUSPEND_DESC.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
                }

                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
                dsrLINE.InputGestures.Add(new KeyGesture(Key.F2));
                CommandBindings.Add(new CommandBinding(dsrLINE, Pressed_F2_Key));

                return true;


            }
            catch (CustomApplicationException ex)
            {
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
                CommandBindings.Remove(new CommandBinding(dsrLINE));

                throw ex;
            }
            catch (Exception ex)
            {
                Core.Framework.Core.Windows.Framework.ApplicationState.Current.CurrentConnectionStrings = Environment.GetEnvironmentVariable("LastConnectionString");
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
                Page.PageTitle = "Suspended **DESC** Maintenance";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:20 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:20 AM
                Display(ref fldF002_SUSPEND_DESC_CLMDTL_LINE_NO);
                Accept(ref fldF002_SUSPEND_DESC_CLMDTL_SUSPEND_DESC);
                Display(ref fldF002_SUSPEND_DESC_CLMDTL_STATUS);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:20 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:20 AM
                while (fleF002_SUSPEND_DESC.For())
                {
                    fleF002_SUSPEND_DESC.PutData();
                }

                fleF002_SUSPEND_HDR.PutData();

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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:20 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:20 AM
                fleF002_SUSPEND_DESC.DeletedRecord = true;
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
        //# dtlF002_SUSPEND_DESC_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:20 AM
        //#-----------------------------------------
        private void dtlF002_SUSPEND_DESC_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:20 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:08:20 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:08:20 AM
                Display(ref fldF002_SUSPEND_DESC_CLMDTL_LINE_NO);
                Accept(ref fldF002_SUSPEND_DESC_CLMDTL_SUSPEND_DESC);
                Display(ref fldF002_SUSPEND_DESC_CLMDTL_STATUS);
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
