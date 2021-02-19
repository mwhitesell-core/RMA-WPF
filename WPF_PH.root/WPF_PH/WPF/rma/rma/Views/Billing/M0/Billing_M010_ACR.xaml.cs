
#region "Screen Comments"

// #>  PROGRAM-ID.      M010.QKS
// ((C)) DYAD TECHNOLOGIES
// PROGRAM PURPOSE : LOOKUP TABLE FOR M010.QKS
// MODIFICATION HISTORY
// DATE          WHO           DESCRIPTION
// 91/09/23       K.S.           CREATION
// 02/11/20   M.C.    - exceed the screen limit when recompile, modify title and align
// statement

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

    partial class Billing_M010_ACR : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M010_ACR()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M010_ACR";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = false;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = false;
            this.DisableAppend = true;
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
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dtlF010_PAT_MSTR.EditClick += dtlF010_PAT_MSTR_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F010_PAT_MSTR.PAT_SURNAME
            //       F010_PAT_MSTR.PAT_GIVEN_NAME
            //       F010_PAT_MSTR.PAT_BIRTH_DATE


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            PAT_MSTR_TEMP = new CoreCharacter("PAT_MSTR_TEMP", 16, this, Common.cEmptyString);
            PAT_ACRONYM_T = new CoreCharacter("PAT_ACRONYM_T", 9, this, Common.cEmptyString);
            fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 7, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            CHART_NUM_TEMP = new CoreCharacter("CHART_NUM_TEMP", 10, this, fleF010_PAT_MSTR, Common.cEmptyString);
            PAT_OHIP_TEMP = new CoreCharacter("PAT_OHIP_TEMP", 12, this, fleF010_PAT_MSTR, Common.cEmptyString);
            PAT_SURNAME = new CoreCharacter("PAT_SURNAME", 25, this, fleF010_PAT_MSTR,Common.cEmptyString);
            PAT_GIVEN_NAME = new CoreCharacter("PAT_GIVEN_NAME", 17, this, fleF010_PAT_MSTR,Common.cEmptyString);
            PAT_BIRTH_DATE = new CoreDecimal("PAT_GIVEN_NAME", 8,  this, fleF010_PAT_MSTR);

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dtlF010_PAT_MSTR.EditClick -= dtlF010_PAT_MSTR_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter PAT_MSTR_TEMP;
        private CoreCharacter PAT_ACRONYM_T;
        private SqlFileObject fleF010_PAT_MSTR;
        private CoreCharacter CHART_NUM_TEMP;

        private CoreCharacter PAT_OHIP_TEMP;
        private CoreCharacter PAT_SURNAME;
        private CoreCharacter PAT_GIVEN_NAME;
        private CoreDecimal PAT_BIRTH_DATE;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:40 AM

        protected TextBox fldF010_PAT_MSTR_PAT_SURNAME;
        protected TextBox fldF010_PAT_MSTR_PAT_GIVEN_NAME;
        protected ComboBox fldF010_PAT_MSTR_PAT_SEX;
        protected DateControl fldF010_PAT_MSTR_PAT_BIRTH_DATE;
        protected TextBox fldF010_PAT_MSTR_PAT_HEALTH_NBR;
        protected TextBox fldCHART_NUM_TEMP;

        protected TextBox fldPAT_OHIP_TEMP;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:40 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF010_PAT_MSTR_PAT_SURNAME":
                        fldF010_PAT_MSTR_PAT_SURNAME = (TextBox)DataListField;
                        CoreField = fldF010_PAT_MSTR_PAT_SURNAME;
                        fldF010_PAT_MSTR_PAT_SURNAME.Bind(PAT_SURNAME);
                        break;
                    case "FLDGRDF010_PAT_MSTR_PAT_GIVEN_NAME":
                        fldF010_PAT_MSTR_PAT_GIVEN_NAME = (TextBox)DataListField;
                        CoreField = fldF010_PAT_MSTR_PAT_GIVEN_NAME;
                        fldF010_PAT_MSTR_PAT_GIVEN_NAME.Bind(PAT_GIVEN_NAME);
                        break;
                    case "FLDGRDF010_PAT_MSTR_PAT_SEX":
                        fldF010_PAT_MSTR_PAT_SEX = (ComboBox)DataListField;
                        CoreField = fldF010_PAT_MSTR_PAT_SEX;
                        fldF010_PAT_MSTR_PAT_SEX.Bind(fleF010_PAT_MSTR);
                        break;
                    case "FLDGRDF010_PAT_MSTR_PAT_BIRTH_DATE":
                        fldF010_PAT_MSTR_PAT_BIRTH_DATE = (DateControl)DataListField;
                        CoreField = fldF010_PAT_MSTR_PAT_BIRTH_DATE;
                        fldF010_PAT_MSTR_PAT_BIRTH_DATE.Bind(PAT_BIRTH_DATE);
                        break;
                    case "FLDGRDF010_PAT_MSTR_PAT_HEALTH_NBR":
                        fldF010_PAT_MSTR_PAT_HEALTH_NBR = (TextBox)DataListField;
                        CoreField = fldF010_PAT_MSTR_PAT_HEALTH_NBR;
                        fldF010_PAT_MSTR_PAT_HEALTH_NBR.Bind(fleF010_PAT_MSTR);
                        break;
                    case "FLDGRDCHART_NUM_TEMP":
                        fldCHART_NUM_TEMP = (TextBox)DataListField;
                        CoreField = fldCHART_NUM_TEMP;
                        fldCHART_NUM_TEMP.Bind(CHART_NUM_TEMP);
                        break;
                    case "FLDGRDPAT_OHIP_TEMP":
                        fldPAT_OHIP_TEMP = (TextBox)DataListField;
                        CoreField = fldPAT_OHIP_TEMP;
                        fldPAT_OHIP_TEMP.Bind(PAT_OHIP_TEMP);
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
                dtlF010_PAT_MSTR.OccursWithFile = fleF010_PAT_MSTR;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:40 AM

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
            fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:40 AM

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
                fleF010_PAT_MSTR.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:10:40 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:10:40 AM
                Display(ref fldPAT_ACRONYM_T);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:10:40 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldPAT_ACRONYM_T.Bind(PAT_ACRONYM_T);

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
                SaveReceivingParams(PAT_MSTR_TEMP);


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
                Receiving(PAT_MSTR_TEMP);


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


        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {

            try
            {

                PAT_MSTR_TEMP.Value = fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4");
                //Parent:KEY_PAT_MSTR
                ReturnAndClose();
                // RETURN


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


        protected override bool PostFind()
        {


            try
            {

                while (fleF010_PAT_MSTR.For())
                {
                    PAT_SURNAME.Value = fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_FIRST3") + fleF010_PAT_MSTR.GetStringValue("PAT_SURNAME_LAST22");
                    PAT_GIVEN_NAME.Value = fleF010_PAT_MSTR.GetStringValue("PAT_GIVEN_NAME_FIRST1") + fleF010_PAT_MSTR.GetStringValue("FILLER3");
                    PAT_BIRTH_DATE.Value = Convert.ToDecimal(fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_YY").ToString().PadLeft(4, '0') + fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_MM").ToString().PadLeft(2, '0') + fleF010_PAT_MSTR.GetDecimalValue("PAT_BIRTH_DATE_DD").ToString().PadLeft(2, '0'));


                    CHART_NUM_TEMP.Value = QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR"), 1, 10);
                    PAT_OHIP_TEMP.Value = fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_ALPHA").Trim() +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_YY").PadLeft(2, ' ').Trim() +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_MM").PadLeft(2, ' ').Trim() +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_DD").PadLeft(2, ' ').Trim() +
                    fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_LAST_6").Trim();
                    //Parent:PAT_OHIP_MMYY
                    Display(ref fldCHART_NUM_TEMP);
                    Display(ref fldPAT_OHIP_TEMP);
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
                bool blnAddWhere = true;
                while (fleF010_PAT_MSTR.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_ACRONYM_FIRST6"), PAT_ACRONYM_T.Value.PadRight(9, ' ').Substring(0, 6), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF010_PAT_MSTR.ElementOwner("PAT_ACRONYM_LAST3"), PAT_ACRONYM_T.Value.PadRight(9, ' ').Substring(6, 3), ref blnAddWhere));

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
                RequestPrompt(ref fldPAT_ACRONYM_T);
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
                Page.PageTitle = "";



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
        //# dtlF010_PAT_MSTR_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:10:40 AM
        //#-----------------------------------------
        private void dtlF010_PAT_MSTR_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:10:40 AM
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
        //# dsrDesigner_02_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:10:40 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:10:40 AM
                Display(ref fldF010_PAT_MSTR_PAT_HEALTH_NBR);
                Display(ref fldCHART_NUM_TEMP);
                Display(ref fldPAT_OHIP_TEMP);
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
