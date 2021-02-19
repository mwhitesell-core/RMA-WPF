
#region "Screen Comments"

// #> PROGRAM-ID.     M191.QKS
// ((C)) Dyad Technologies
// PURPOSE: MAINTENANCE OF THE EARNINGS PERIOD MASTER
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/JAN/01  ____   M.C.     - original
// ???? !!!! ERROR CHECKS MUST USE `DO APPEND` CHECKING NOT IN PREUPDATE !!!!
// 1999/Jan/19   S.B.     - Reset the alignment for the details
// and the titles for Y2K compliance.
// 1999/Jun/07         S.B.     - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 2002/May/28  M.C. - add process procedure to set ped-yyyymm
// from iconst-date-period-end
// 2014/May/20  MC1 - change ep-date-closed to be an enterable field
// - this field is never USED and have the value of ZEROES
// - now use this field for paycode 7 INVOICE date

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

    partial class Billing_M191 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_M191()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "M191";

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
            dtlF191_EARNINGS_PERIOD.EditClick += dtlF191_EARNINGS_PERIOD_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Primary, 13, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_trnTRANS_UPDATE");

           
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;
            dtlF191_EARNINGS_PERIOD.EditClick -= dtlF191_EARNINGS_PERIOD_EditClick;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
          


        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF191_EARNINGS_PERIOD;
        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {

                // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

                Value = "EARNINGS PERIOD (E/P) Maintenance";


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:28 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:28 AM

        protected TextBox fldF191_EARNINGS_PERIOD_EP_NBR;
        protected TextBox fldF191_EARNINGS_PERIOD_EP_FISCAL_NBR;
        private DateControl fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END;
        protected DateControl fldF191_EARNINGS_PERIOD_EP_DATE_START;
        protected TextBox fldF191_EARNINGS_PERIOD_EP_DATE_END;
        protected DateControl fldF191_EARNINGS_PERIOD_DATE_EFT_DEPOSIT;
        protected TextBox fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_NBR;
        protected DateControl fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_DATE_END;

        protected DateControl fldF191_EARNINGS_PERIOD_EP_DATE_CLOSED;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:28 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF191_EARNINGS_PERIOD_EP_NBR":
                        fldF191_EARNINGS_PERIOD_EP_NBR = (TextBox)DataListField;

                        fldF191_EARNINGS_PERIOD_EP_NBR.LookupNotOn -= fldF191_EARNINGS_PERIOD_EP_NBR_LookupNotOn;
                        fldF191_EARNINGS_PERIOD_EP_NBR.LookupNotOn += fldF191_EARNINGS_PERIOD_EP_NBR_LookupNotOn;
                        CoreField = fldF191_EARNINGS_PERIOD_EP_NBR;
                        fldF191_EARNINGS_PERIOD_EP_NBR.Bind(fleF191_EARNINGS_PERIOD);
                        break;
                    case "FLDGRDF191_EARNINGS_PERIOD_EP_FISCAL_NBR":
                        fldF191_EARNINGS_PERIOD_EP_FISCAL_NBR = (TextBox)DataListField;
                        CoreField = fldF191_EARNINGS_PERIOD_EP_FISCAL_NBR;
                        fldF191_EARNINGS_PERIOD_EP_FISCAL_NBR.Bind(fleF191_EARNINGS_PERIOD);
                        break;
                    case "FLDGRDF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END":
                        fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END = (DateControl)DataListField;
                        fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END.Process -= fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END_Process;
                        fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END.Process += fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END_Process;
                        CoreField = fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END;
                        fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END.Bind(fleF191_EARNINGS_PERIOD);
                        break;
                    case "FLDGRDF191_EARNINGS_PERIOD_EP_DATE_START":
                        fldF191_EARNINGS_PERIOD_EP_DATE_START = (DateControl)DataListField;
                        CoreField = fldF191_EARNINGS_PERIOD_EP_DATE_START;
                        fldF191_EARNINGS_PERIOD_EP_DATE_START.Bind(fleF191_EARNINGS_PERIOD);
                        break;
                    case "FLDGRDF191_EARNINGS_PERIOD_EP_DATE_END":
                        fldF191_EARNINGS_PERIOD_EP_DATE_END = (TextBox)DataListField;
                        CoreField = fldF191_EARNINGS_PERIOD_EP_DATE_END;
                        fldF191_EARNINGS_PERIOD_EP_DATE_END.Bind(fleF191_EARNINGS_PERIOD);
                        break;
                    case "FLDGRDF191_EARNINGS_PERIOD_DATE_EFT_DEPOSIT":
                        fldF191_EARNINGS_PERIOD_DATE_EFT_DEPOSIT = (DateControl)DataListField;
                        CoreField = fldF191_EARNINGS_PERIOD_DATE_EFT_DEPOSIT;
                        fldF191_EARNINGS_PERIOD_DATE_EFT_DEPOSIT.Bind(fleF191_EARNINGS_PERIOD);
                        break;
                    case "FLDGRDF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_NBR":
                        fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_NBR = (TextBox)DataListField;
                        CoreField = fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_NBR;
                        fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_NBR.Bind(fleF191_EARNINGS_PERIOD);
                        break;
                    case "FLDGRDF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_DATE_END":
                        fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_DATE_END = (DateControl)DataListField;
                        CoreField = fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_DATE_END;
                        fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_DATE_END.Bind(fleF191_EARNINGS_PERIOD);
                        break;
                    case "FLDGRDF191_EARNINGS_PERIOD_EP_DATE_CLOSED":
                        fldF191_EARNINGS_PERIOD_EP_DATE_CLOSED = (DateControl)DataListField;
                        CoreField = fldF191_EARNINGS_PERIOD_EP_DATE_CLOSED;
                        fldF191_EARNINGS_PERIOD_EP_DATE_CLOSED.Bind(fleF191_EARNINGS_PERIOD);
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
                dtlF191_EARNINGS_PERIOD.OccursWithFile = fleF191_EARNINGS_PERIOD;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:28 AM

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
            fleF191_EARNINGS_PERIOD.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:28 AM

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
                fleF191_EARNINGS_PERIOD.Dispose();


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:15:28 AM



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



        private void fldF191_EARNINGS_PERIOD_EP_NBR_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF191_EARNINGS_PERIOD.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ").Append((FieldValue));

                if (!LookupNotOn(strSQL, fleF191_EARNINGS_PERIOD, "EP_NBR", FieldValue.ToString()))
                {
                    blnAlreadyExists = true;
                }

                if (blnAlreadyExists)
                {
                    ErrorMessage("Error - This EARNINGS PERIOD has already been defined.");
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



        private void fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END_Process()
        {

            try
            {

                fleF191_EARNINGS_PERIOD.set_SetValue("PED_YYYYMM", fleF191_EARNINGS_PERIOD.GetNumericDateValue("ICONST_DATE_PERIOD_END") / 100);


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

                if (QDesign.NULL(fleF191_EARNINGS_PERIOD.GetDecimalValue("EP_DATE_END")) < QDesign.NULL(fleF191_EARNINGS_PERIOD.GetNumericDateValue("EP_DATE_START")))
                {
                    ErrorMessage("Error - EARNings Period Date Start must preceed Date End.");
                }
                if (QDesign.NULL(fleF191_EARNINGS_PERIOD.GetDecimalValue("EP_DATE_END")) < QDesign.NULL(fleF191_EARNINGS_PERIOD.GetNumericDateValue("ICONST_DATE_PERIOD_END")) | QDesign.NULL(fleF191_EARNINGS_PERIOD.GetNumericDateValue("EP_DATE_START")) > QDesign.NULL(fleF191_EARNINGS_PERIOD.GetNumericDateValue("ICONST_DATE_PERIOD_END")))
                {
                    ErrorMessage("Error -  Billing PED doesn`t fall within EARNing Period`s Start/End dates");
                }
                fleF191_EARNINGS_PERIOD.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleF191_EARNINGS_PERIOD.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleF191_EARNINGS_PERIOD.set_SetValue("LAST_MOD_USER_ID", UserID);

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
                m_strOrderBy = new StringBuilder(" ORDER BY ");
                m_strOrderBy.Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(", ");
                m_strOrderBy.Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_FISCAL_NBR")).Append(", ");
                m_strOrderBy.Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_DATE_START"));
                bool blnAddWhere = true;
                switch (m_intPath)
                {
                    case 1:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR"), fleF191_EARNINGS_PERIOD.GetDecimalValue("EP_NBR"), ref blnAddWhere));
                        fleF191_EARNINGS_PERIOD.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    case 2:
                        m_strWhere = new StringBuilder(GetWhereCondition(fleF191_EARNINGS_PERIOD.ElementOwner("PED_YYYYMM"), fleF191_EARNINGS_PERIOD.GetDecimalValue("PED_YYYYMM"), ref blnAddWhere));
                        fleF191_EARNINGS_PERIOD.GetData(m_strWhere.ToString(), m_strOrderBy.ToString(), GetDataOptions.CreateSubSelect);
                        break;
                    default:
                        fleF191_EARNINGS_PERIOD.GetData("", m_strOrderBy.ToString(), GetDataOptions.Sequential | GetDataOptions.CreateSubSelect);
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

                RequestPrompt(ref fldF191_EARNINGS_PERIOD_EP_NBR);
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
        //# Append Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:28 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:28 AM
                Accept(ref fldF191_EARNINGS_PERIOD_EP_NBR);
                Accept(ref fldF191_EARNINGS_PERIOD_EP_FISCAL_NBR);
                Accept(ref fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END);
                Accept(ref fldF191_EARNINGS_PERIOD_EP_DATE_START);
                Accept(ref fldF191_EARNINGS_PERIOD_EP_DATE_END);
                Accept(ref fldF191_EARNINGS_PERIOD_DATE_EFT_DEPOSIT);
                Accept(ref fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_NBR);
                Accept(ref fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_DATE_END);
                Accept(ref fldF191_EARNINGS_PERIOD_EP_DATE_CLOSED);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:28 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:28 AM
                while (fleF191_EARNINGS_PERIOD.For())
                {
                    fleF191_EARNINGS_PERIOD.PutData(false, PutTypes.Deleted);
                }
                while (fleF191_EARNINGS_PERIOD.For())
                {
                    fleF191_EARNINGS_PERIOD.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:28 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:28 AM
                fleF191_EARNINGS_PERIOD.DeletedRecord = true;
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
        //# dtlF191_EARNINGS_PERIOD_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:28 AM
        //#-----------------------------------------
        private void dtlF191_EARNINGS_PERIOD_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:28 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:15:28 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:15:28 AM
                Accept(ref fldF191_EARNINGS_PERIOD_EP_NBR);
                Accept(ref fldF191_EARNINGS_PERIOD_EP_FISCAL_NBR);
                Accept(ref fldF191_EARNINGS_PERIOD_ICONST_DATE_PERIOD_END);
                Accept(ref fldF191_EARNINGS_PERIOD_EP_DATE_START);
                Accept(ref fldF191_EARNINGS_PERIOD_EP_DATE_END);
                Accept(ref fldF191_EARNINGS_PERIOD_DATE_EFT_DEPOSIT);
                Accept(ref fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_NBR);
                Accept(ref fldF191_EARNINGS_PERIOD_ACCOUNTING_PERIOD_DATE_END);
                Accept(ref fldF191_EARNINGS_PERIOD_EP_DATE_CLOSED);
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

