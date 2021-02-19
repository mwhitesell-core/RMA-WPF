
#region "Screen Comments"

// ---------------------------------------------------------------:
// :
// system:       Holiday Property Bond                         :
// :
// program:      ACCTMOVE                                      :
// :f
// task:         Show all transactions against a particular user
// :
// files:        INVESTOR-TRANS      Primary                   :
// :
// screens                                                     :
// called by:    IVST0000    Main investor driving screen      :
// calling:      xxxxxxxx    xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx  :
// :
// subprograms:  xxxxxxxx                                      :
// :
// ---------------------------------------------------------------:
// 24/05/96 - Year 200: t-year char*4
// ----------------------------------------------------------------
// 20.06.03 - add trans-ym to investor-trans
// ----------------------------------------------------------------
// 22.02.06 - put signonuser into trans-spare of investor-trans
// ----------------------------------------------------------------
// 10.06.10 - IM - Expanded field sizes for HWH points
// ----------------------------------------------------------------
// 21.05.12 - RC - Upshift t-year (for the special reserve year RESV)
// ----------------------------------------------------------------
// 18.09.12 RM  Add scrnvst to record visit to this screen
// ----------------------------------------------------------------
// screen positioning

#endregion



using System;
using System.Text;
using System.Windows;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.ExceptionManagement;
using Core.Windows.UI.Core.Windows;
using Core.Windows.UI.Core.Windows.UI;
using System.Data.OracleClient;

namespace rma.Views
{

    partial class ACCTMOVE : BasePage
    {

        #region " Form Designer Generated Code "





        public ACCTMOVE()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "ACCTMOVE";

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
            dtlINVESTOR_TRANS.EditClick += dtlINVESTOR_TRANS_EditClick;
            fldT_YEAR.Input += fldT_YEAR_Input;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.
            T_YEAR = new CoreCharacter("T_YEAR", 4, this, ResetTypes.ResetAtMode, Common.cEmptyString);



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            T_SCREEN_NAME = new CoreCharacter("T_SCREEN_NAME", 20, this, ResetTypes.ResetAtStartup, "acctmove.qks");
            fleM_INVESTORS = new OracleFileObject(this, FileTypes.Master, 0, "INDEXED", "M_INVESTORS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleINVESTOR_TRANS = new OracleFileObject(this, FileTypes.Primary, 15, "INDEXED", "INVESTOR_TRANS", "", true, false, true, 0, "m_trnTRANS_UPDATE");
           
            fleINVESTOR_TRANS.SetItemFinals += fleINVESTOR_TRANS_SetItemFinals;
            D_TRANS_NO.GetValue += D_TRANS_NO_GetValue;
           

        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            D_TRANS_NO.GetValue -= D_TRANS_NO_GetValue;
            fldT_YEAR.Input -= fldT_YEAR_Input;
            fleINVESTOR_TRANS.SetItemFinals -= fleINVESTOR_TRANS_SetItemFinals;


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private OracleConnection m_cnnQUERY = new OracleConnection();
        private OracleConnection m_cnnTRANS_UPDATE = new OracleConnection();
        private OracleTransaction m_trnTRANS_UPDATE;
        private CoreCharacter T_SCREEN_NAME;
        private OracleFileObject fleM_INVESTORS;
        private CoreCharacter T_YEAR;
        private OracleFileObject fleINVESTOR_TRANS;

        private void fleINVESTOR_TRANS_SetItemFinals()
        {

            try
            {
                fleINVESTOR_TRANS.set_SetValue("TRANS_YM", QDesign.Substring(QDesign.ASCII(fleINVESTOR_TRANS.GetDecimalValue("TRANSACT_DATE"), 8), 1, 6));


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

        private DCharacter D_TRANS_NO = new DCharacter(6);
        private void D_TRANS_NO_GetValue(ref string Value)
        {

            try
            {
                Value = fleINVESTOR_TRANS.GetStringValue("TRANS_NO");
               


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
        //# Do not delete, modify or move it.  Updated: 08/14/2013 8:54:27 AM

        protected DateControl fldINVESTOR_TRANS_TRANSACT_DATE;
        protected TextBox fldD_TRANS_NO;
        protected TextBox fldINVESTOR_TRANS_LINE_DESCRIPTION;
        protected TextBox fldINVESTOR_TRANS_TRANSACT_VALUE;

        protected TextBox fldINVESTOR_TRANS_RUNNING_BALANCE;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 08/14/2013 8:54:27 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDINVESTOR_TRANS_TRANSACT_DATE":
                        fldINVESTOR_TRANS_TRANSACT_DATE = (DateControl)DataListField;
                        CoreField = fldINVESTOR_TRANS_TRANSACT_DATE;
                        fldINVESTOR_TRANS_TRANSACT_DATE.Bind(fleINVESTOR_TRANS);
                        break;
                    case "FLDGRDD_TRANS_NO":
                        fldD_TRANS_NO = (TextBox)DataListField;
                        CoreField = fldD_TRANS_NO;
                        fldD_TRANS_NO.Bind(D_TRANS_NO);
                        break;
                    case "FLDGRDINVESTOR_TRANS_LINE_DESCRIPTION":
                        fldINVESTOR_TRANS_LINE_DESCRIPTION = (TextBox)DataListField;
                        CoreField = fldINVESTOR_TRANS_LINE_DESCRIPTION;
                        fldINVESTOR_TRANS_LINE_DESCRIPTION.Bind(fleINVESTOR_TRANS);
                        break;
                    case "FLDGRDINVESTOR_TRANS_TRANSACT_VALUE":
                        fldINVESTOR_TRANS_TRANSACT_VALUE = (TextBox)DataListField;
                        CoreField = fldINVESTOR_TRANS_TRANSACT_VALUE;
                        fldINVESTOR_TRANS_TRANSACT_VALUE.Bind(fleINVESTOR_TRANS);
                        break;
                    case "FLDGRDINVESTOR_TRANS_RUNNING_BALANCE":
                        fldINVESTOR_TRANS_RUNNING_BALANCE = (TextBox)DataListField;
                        CoreField = fldINVESTOR_TRANS_RUNNING_BALANCE;
                        fldINVESTOR_TRANS_RUNNING_BALANCE.Bind(fleINVESTOR_TRANS);
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
                dtlINVESTOR_TRANS.OccursWithFile = fleINVESTOR_TRANS;

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
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:40 PM

        //#-----------------------------------------
        //# InitializeTransactionObjects Procedure.
        //#-----------------------------------------

        protected override void InitializeTransactionObjects()
        {

            try
            {
                m_cnnTRANS_UPDATE = new OracleConnection(Common.GetConnectionString());
                m_cnnTRANS_UPDATE.Open();
                m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
                m_cnnQUERY = new OracleConnection(Common.GetConnectionString());


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
            fleM_INVESTORS.Transaction = m_trnTRANS_UPDATE;
            fleINVESTOR_TRANS.Transaction = m_trnTRANS_UPDATE;    
        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 07/12/2013 1:49:40 PM

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
                fleM_INVESTORS.Dispose();
                fleINVESTOR_TRANS.Dispose();
                


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
        //# Precompiler Ver.: 1.0.4941.22591  Generated on: 08/14/2013 8:54:27 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4941.22591 Generated on: 08/14/2013 8:54:27 AM
                Display(ref fldT_YEAR);
                Display(ref fldINVESTOR_TRANS_INVESTOR);
                Display(ref fldM_INVESTORS_INVESTOR_NAME);
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
        //# Precompiler Ver.: 1.0.4941.22591  Generated on: 08/14/2013 8:54:27 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4941.22591 Generated on: 08/14/2013 8:54:27 AM
                Display(ref fldINVESTOR_TRANS_INVESTOR);
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
        //# Do not delete, modify or move it.
        public override void BindFields()
        {
            try
            {
                fldT_YEAR.Bind(T_YEAR);
                fldINVESTOR_TRANS_INVESTOR.Bind(fleINVESTOR_TRANS);
                fldM_INVESTORS_INVESTOR_NAME.Bind(fleM_INVESTORS);

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
                SaveReceivingParams(fleM_INVESTORS);


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
                Receiving(fleM_INVESTORS);


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



        private void fldT_YEAR_Input()
        {

            try
            {

                //#CORE_BEGIN_INCLUDE: YEARCENT.USE"

                //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
                //# Do not delete, modify or move it.  Updated: 08/13/2013 9:10:29 AM

                if (2== FieldText.Length)
                {
                    if (string.Compare(QDesign.Substring(FieldText, 1, 2), "69") < 0)
                    {
                        FieldText = "20" + QDesign.Substring(FieldText, 1, 2);
                    }
                    else
                    {
                        FieldText = "19" + QDesign.Substring(FieldText, 1, 2);
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

        //#CORE_END_INCLUDE: YEARCENT.USE"



        protected override bool Entry()
        {


            try
            {


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

                Display(ref fldINVESTOR_TRANS_INVESTOR);
                RequestPrompt(ref fldT_YEAR);
                if (m_blnPromptOK)
                {
                    m_intPath = 1;
                }
                if (m_intPath == 0)
                {
                    ErrorMessage("52156");
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

        //#CORE_BEGIN_INCLUDE: SCRNVSTU.USE"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 08/13/2013 9:10:29 AM


        protected override bool Initialize()
        {


            try
            {
                object[] arrRunscreen = { T_SCREEN_NAME };
                RunScreen(new SCRNVST(), RunScreenModes.Entry, ref arrRunscreen);
                

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

        //#CORE_END_INCLUDE: SCRNVSTU.USE"





        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                while (fleINVESTOR_TRANS.ForMissing())
                {
                    m_strOrderBy = new StringBuilder(" ORDER BY ").Append(fleINVESTOR_TRANS.ElementOwner("TRANSACT_DATE")).Append(" DESC ").Append(", ").Append(fleINVESTOR_TRANS.ElementOwner("TRANS_NO"));
                    m_strWhere = new StringBuilder(GetWhereCondition(fleINVESTOR_TRANS.ElementOwner("FILLER_8"), fleM_INVESTORS.GetStringValue("INVESTOR"), ref blnAddWhere));
                    //Parent:INVESTOR_YEAR
                    m_strWhere.Append(GetWhereCondition(fleINVESTOR_TRANS.ElementOwner("YEAR"), T_YEAR.Value, ref blnAddWhere));
                    //Parent:INVESTOR_YEAR
                    fleINVESTOR_TRANS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "Account Movements";



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
        //# Precompiler Ver.: 1.0.4941.22591  Generated on: 08/14/2013 8:54:27 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4941.22591 Generated on: 08/14/2013 8:54:27 AM
                Display(ref fldINVESTOR_TRANS_TRANSACT_DATE);
                Display(ref fldD_TRANS_NO);
                Accept(ref fldINVESTOR_TRANS_LINE_DESCRIPTION);
                Display(ref fldINVESTOR_TRANS_TRANSACT_VALUE);
                Display(ref fldINVESTOR_TRANS_RUNNING_BALANCE);
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
        //# Precompiler Ver.: 1.0.4941.22591  Generated on: 08/14/2013 8:54:27 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4941.22591 Generated on: 08/14/2013 8:54:27 AM
                fleM_INVESTORS.PutData();
                while (fleINVESTOR_TRANS.For())
                {
                    fleINVESTOR_TRANS.PutData();
                }
                fleM_INVESTORS.PutData();
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
        //# dtlINVESTOR_TRANS_EditClick Procedure
        //# Precompiler Ver.: 1.0.4941.22591  Generated on: 08/14/2013 8:54:27 AM
        //#-----------------------------------------
        private void dtlINVESTOR_TRANS_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4941.22591 Generated on: 08/14/2013 8:54:27 AM
                dsrDesigner_02_Click(null, null);
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
        //# Precompiler Ver.: 1.0.4941.22591  Generated on: 08/14/2013 8:54:27 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4941.22591 Generated on: 08/14/2013 8:54:27 AM
                Accept(ref fldT_YEAR);
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
        //# Precompiler Ver.: 1.0.4941.22591  Generated on: 08/14/2013 8:54:27 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.4941.22591 Generated on: 08/14/2013 8:54:27 AM
                if (!fleINVESTOR_TRANS.NewRecord)
                {
                    Display(ref fldINVESTOR_TRANS_TRANSACT_DATE);
                }
                else
                {
                    Accept(ref fldINVESTOR_TRANS_TRANSACT_DATE);
                }
                Accept(ref fldD_TRANS_NO);
                Accept(ref fldINVESTOR_TRANS_LINE_DESCRIPTION);
                if (!fleINVESTOR_TRANS.NewRecord)
                {
                    Display(ref fldINVESTOR_TRANS_TRANSACT_VALUE);
                }
                else
                {
                    Accept(ref fldINVESTOR_TRANS_TRANSACT_VALUE);
                }
                if (!fleINVESTOR_TRANS.NewRecord)
                {
                    Display(ref fldINVESTOR_TRANS_RUNNING_BALANCE);
                }
                else
                {
                    Accept(ref fldINVESTOR_TRANS_RUNNING_BALANCE);
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
