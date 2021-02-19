
#region "Screen Comments"

// #> PROGRAM-ID.     M090F.QKS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : MAINTENANCE of values in Constants Mstr Rec #6
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 92/JAN/02 R.A.         - ORIGINAL
// 1999/Jan/15 S.B.      - Recompile for Y2K 
// - Fix alignment  

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
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Controls;

namespace rma.Views
{

    partial class M080 : BasePage
    {

        #region " Form Designer Generated Code "





        public M080()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M080";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;

            fldF080_BANK_MSTR_BANK_NUMBER.Input += FldF080_BANK_MSTR_BANK_NUMBER_Input;
            fldF080_BANK_MSTR_BRANCH_NUMBER.Input += FldF080_BANK_MSTR_BRANCH_NUMBER_Input;

            fldF080_BANK_MSTR_BANK_POSTAL.Input += FldF080_BANK_MSTR_BANK_POSTAL_Input;


           

        }
        


        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();


            base.Page_Load();

        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF080_BANK_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F080_BANK_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF080_BANK_MSTR.SetItemFinals += FleF080_BANK_MSTR_SetItemFinals;

            T_BANK_NUMBER = new CoreCharacter("T_BANK_NUMBER", 4, this, Common.cEmptyString);
            T_BRANCH_NUMBER = new CoreCharacter("T_BRANCH_NUMBER", 5, this, Common.cEmptyString);
            T_POSTAL = new CoreCharacter("T_POSTAL", 7, this, Common.cEmptyString);

        }



        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;

            fleF080_BANK_MSTR.SetItemFinals -= FleF080_BANK_MSTR_SetItemFinals;
            fldF080_BANK_MSTR_BANK_NUMBER.Input -= FldF080_BANK_MSTR_BANK_NUMBER_Input;
            fldF080_BANK_MSTR_BRANCH_NUMBER.Input -= FldF080_BANK_MSTR_BRANCH_NUMBER_Input;
            fldF080_BANK_MSTR_BANK_POSTAL.Input -= FldF080_BANK_MSTR_BANK_POSTAL_Input;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF080_BANK_MSTR;

        private void FleF080_BANK_MSTR_SetItemFinals()
        {
            fleF080_BANK_MSTR.set_SetValue("BANK_CD", T_BANK_NUMBER.Value + T_BRANCH_NUMBER.Value);
            fleF080_BANK_MSTR.set_SetValue("BANK_PC1", T_POSTAL.Value.PadLeft(7, ' ').Substring(0, 1));
            fleF080_BANK_MSTR.set_SetValue("BANK_PC2", T_POSTAL.Value.PadLeft(7, ' ').Substring(1, 1));
            fleF080_BANK_MSTR.set_SetValue("BANK_PC3", T_POSTAL.Value.PadLeft(7, ' ').Substring(2, 1));
            fleF080_BANK_MSTR.set_SetValue("BANK_PC4", T_POSTAL.Value.PadLeft(7, ' ').Substring(3, 1));
            fleF080_BANK_MSTR.set_SetValue("BANK_PC5", T_POSTAL.Value.PadLeft(7, ' ').Substring(4, 1));
            fleF080_BANK_MSTR.set_SetValue("BANK_PC6", T_POSTAL.Value.PadLeft(7, ' ').Substring(5, 1));

        }

        private CoreCharacter T_BANK_NUMBER;
        private CoreCharacter T_BRANCH_NUMBER;
        private CoreCharacter T_POSTAL;

        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:16 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:16 AM

        //# No code was generated or needed for this region.

        #endregion

        #region "Transaction Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:16 AM

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
            fleF080_BANK_MSTR.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:16 AM

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
                fleF080_BANK_MSTR.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:16 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:16 AM
                Display(ref fldF080_BANK_MSTR_BANK_NUMBER);
                Display(ref fldF080_BANK_MSTR_BRANCH_NUMBER);
                Display(ref fldF080_BANK_MSTR_BANK_NAME);
                Display(ref fldF080_BANK_MSTR_BANK_ADDRESS_1);
                Display(ref fldF080_BANK_MSTR_BANK_ADDRESS_2);
                Display(ref fldF080_BANK_MSTR_BANK_CITY);
                Display(ref fldF080_BANK_MSTR_BANK_PROV);
                Display(ref fldF080_BANK_MSTR_BANK_POSTAL);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:14:16 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldF080_BANK_MSTR_BANK_NUMBER.Bind(T_BANK_NUMBER);
                fldF080_BANK_MSTR_BRANCH_NUMBER.Bind(T_BRANCH_NUMBER);
                fldF080_BANK_MSTR_BANK_NAME.Bind(fleF080_BANK_MSTR);
                fldF080_BANK_MSTR_BANK_ADDRESS_1.Bind(fleF080_BANK_MSTR);
                fldF080_BANK_MSTR_BANK_ADDRESS_2.Bind(fleF080_BANK_MSTR);
                fldF080_BANK_MSTR_BANK_CITY.Bind(fleF080_BANK_MSTR);
                fldF080_BANK_MSTR_BANK_PROV.Bind(fleF080_BANK_MSTR);
                fldF080_BANK_MSTR_BANK_POSTAL.Bind(T_POSTAL);

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

        #endregion

        #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                fleF080_BANK_MSTR.GetData("", GetDataOptions.CreateSubSelect);

                m_strOrderBy = new StringBuilder("ORDER BY ");
                m_strOrderBy.Append(fleF080_BANK_MSTR.ElementOwner("BANK_CD"));

                switch (m_intPath)
                {

                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF080_BANK_MSTR.ElementOwner("BANK_CD"), (T_BANK_NUMBER.Value + T_BRANCH_NUMBER.Value), ref blnAddWhere));
                        fleF080_BANK_MSTR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect); break;

                    case 0:
                        fleF080_BANK_MSTR.GetData("", m_strOrderBy.ToString(), GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

        protected override bool PostFind()
        {


            try
            {
                T_BANK_NUMBER.Value = fleF080_BANK_MSTR.GetStringValue("BANK_CD").Substring(0, 4);
                T_BRANCH_NUMBER.Value = fleF080_BANK_MSTR.GetStringValue("BANK_CD").Substring(4, 5);
                T_POSTAL.Value = fleF080_BANK_MSTR.GetStringValue("BANK_PC1").Trim() + fleF080_BANK_MSTR.GetStringValue("BANK_PC2").Trim() + fleF080_BANK_MSTR.GetStringValue("BANK_PC3").Trim() + fleF080_BANK_MSTR.GetStringValue("BANK_PC4").Trim() + fleF080_BANK_MSTR.GetStringValue("BANK_PC5").Trim() + fleF080_BANK_MSTR.GetStringValue("BANK_PC6").Trim();

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
                if (m_intPath == 0)
                {
                    RequestPrompt(ref fldF080_BANK_MSTR_BANK_NUMBER);
                    if (m_blnPromptOK)
                    {
                        RequestPrompt(ref fldF080_BANK_MSTR_BRANCH_NUMBER);
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
                Page.PageTitle = "BANK MASTER MAINTENANCE";



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

        private void FldF080_BANK_MSTR_BRANCH_NUMBER_Input()
        {
            try
            {
                if (FieldText.Length > 0)
                    FieldText = FieldText.PadLeft(5, '0');



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

        private void FldF080_BANK_MSTR_BANK_POSTAL_Input()
        {
            try
            {

                string _caZipRegEx = @"^([ABCEGHJKLMNPRSTVXY]\d[ABCEGHJKLMNPRSTVWXYZ])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZ]\d)$";
                if (!Regex.Match(FieldText, _caZipRegEx).Success)
                {
                    ErrorMessage("Invalid Postal Code");
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

        private void FldF080_BANK_MSTR_BANK_NUMBER_Input()
        {
            try
            {
                if (FieldText.Length > 0 || fleF080_BANK_MSTR.NewRecord)
                    FieldText = FieldText.PadLeft(4, '0');



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:15 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:15 AM
                Accept(ref fldF080_BANK_MSTR_BANK_NUMBER);
                Accept(ref fldF080_BANK_MSTR_BRANCH_NUMBER);
                Accept(ref fldF080_BANK_MSTR_BANK_NAME);
                Accept(ref fldF080_BANK_MSTR_BANK_ADDRESS_1);
                Accept(ref fldF080_BANK_MSTR_BANK_ADDRESS_2);
                Accept(ref fldF080_BANK_MSTR_BANK_CITY);
                Accept(ref fldF080_BANK_MSTR_BANK_PROV);
                Accept(ref fldF080_BANK_MSTR_BANK_POSTAL);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:16 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:16 AM
                fleF080_BANK_MSTR.PutData(false, PutTypes.New);
                fleF080_BANK_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:14:16 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:14:16 AM
                fleF080_BANK_MSTR.DeletedRecord = true;
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
