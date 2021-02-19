
#region "Screen Comments"

// #> PROGRAM-ID.     D118.QKS
// ((C)) Dyad Technologies
// PURPOSE: Query/modifications to Physician Statement of Earnings Messages
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 94/JAN/01  ____   B.E.     - original
// 94/JAN/19         M.C.     - change the access method on
// F119-DOCTOR-YTD
// 1999/Jun/07  S.B.     - Altered the call to scrtitle.use and
// stdhilite.use to be called from $use
// instead of src.
// - Removed the call to secfile.use because
// it was not doing anything.
// 2002/jan/18  B.E.  - changed `select` to look for MSG codes

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

    partial class Billing_D118 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D118()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D118";

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
            dtlF119_DOCTOR_YTD.EditClick += dtlF119_DOCTOR_YTD_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            W_EP_NBR_FROM = new CoreDecimal("W_EP_NBR_FROM", 6, this);
            W_EP_NBR_TO = new CoreDecimal("W_EP_NBR_TO", 6, this);
            X_SRCH_CODE = new CoreCharacter("X_SRCH_CODE", 6, this, Common.cEmptyString);
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_cnnQUERY");
            fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 3, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            TEXT_PART_1 = new CoreCharacter("TEXT_PART_1", 65, this, fleF119_DOCTOR_YTD, Common.cEmptyString);
            TEXT_PART_2 = new CoreCharacter("TEXT_PART_2", 65, this, fleF119_DOCTOR_YTD, Common.cEmptyString);

          
            fleF190_COMP_CODES.Access += fleF190_COMP_CODES_Access;
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
            fleF119_DOCTOR_YTD.InitializeItems += fleF119_DOCTOR_YTD_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF190_COMP_CODES.Access -= fleF190_COMP_CODES_Access;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;
            fldF119_DOCTOR_YTD_PROCESS_SEQ.LookupNotOn -= fldF119_DOCTOR_YTD_PROCESS_SEQ_LookupNotOn;
            fleF119_DOCTOR_YTD.InitializeItems -= fleF119_DOCTOR_YTD_InitializeItems;

            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF119_DOCTOR_YTD.EditClick += dtlF119_DOCTOR_YTD_EditClick;

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private CoreCharacter W_DOC_NBR;
        private CoreDecimal W_EP_NBR_FROM;
        private CoreDecimal W_EP_NBR_TO;
        private CoreCharacter X_SRCH_CODE;
        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField("MSG"));

                strText.Append(" ORDER BY ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE"));
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

        private SqlFileObject fleF119_DOCTOR_YTD;

        private void fleF119_DOCTOR_YTD_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleF119_DOCTOR_YTD.ElementOwner("REC_TYPE")).Append(" =  'B')");
                

                SelectIfClause = strSQL.ToString();


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



        private void fleF119_DOCTOR_YTD_InitializeItems(bool Fixed)
        {

            try
            {
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("REC_TYPE", true, "B");
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("COMP_CODE", true, "MSG");
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("COMP_CODE_GROUP", true, fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP"));


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

        private CoreCharacter TEXT_PART_1;
        private CoreCharacter TEXT_PART_2;
        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "Statement Messages";


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:15 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:15 AM

        protected TextBox fldF119_DOCTOR_YTD_PROCESS_SEQ;
        protected TextBox fldTEXT_PART_1;

        protected TextBox fldTEXT_PART_2;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:15 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF119_DOCTOR_YTD_PROCESS_SEQ":
                        fldF119_DOCTOR_YTD_PROCESS_SEQ = (TextBox)DataListField;

                        fldF119_DOCTOR_YTD_PROCESS_SEQ.LookupNotOn -= fldF119_DOCTOR_YTD_PROCESS_SEQ_LookupNotOn;
                        fldF119_DOCTOR_YTD_PROCESS_SEQ.LookupNotOn += fldF119_DOCTOR_YTD_PROCESS_SEQ_LookupNotOn;
                        CoreField = fldF119_DOCTOR_YTD_PROCESS_SEQ;
                        fldF119_DOCTOR_YTD_PROCESS_SEQ.Bind(fleF119_DOCTOR_YTD);
                        break;
                    case "FLDGRDTEXT_PART_1":
                        fldTEXT_PART_1 = (TextBox)DataListField;
                        CoreField = fldTEXT_PART_1;
                        fldTEXT_PART_1.Bind(TEXT_PART_1);
                        break;
                    case "FLDGRDTEXT_PART_2":
                        fldTEXT_PART_2 = (TextBox)DataListField;
                        CoreField = fldTEXT_PART_2;
                        fldTEXT_PART_2.Bind(TEXT_PART_2);
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
                dtlF119_DOCTOR_YTD.OccursWithFile = fleF119_DOCTOR_YTD;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:15 AM

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
            fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:15 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF190_COMP_CODES.Connection = m_cnnQUERY;


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
                fleF020_DOCTOR_MSTR.Dispose();
                fleF190_COMP_CODES.Dispose();
                fleF119_DOCTOR_YTD.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:07:15 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:07:15 AM
                
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:07:15 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:07:15 AM
                
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:15 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                

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



        private void fldF119_DOCTOR_YTD_PROCESS_SEQ_LookupNotOn(ref bool LookupNotOnExecuted)
        {

            try
            {
                bool blnAlreadyExists = false;
                StringBuilder strSQL = new StringBuilder("SELECT ").Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE"));
                strSQL.Append(" FROM ");
                strSQL.Append(fleF119_DOCTOR_YTD.TableNameWithAlias());
                strSQL.Append(" WHERE ");
                strSQL.Append("     ").Append(fleF119_DOCTOR_YTD.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE_GROUP")));
                strSQL.Append(" And ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")));
                strSQL.Append(" And ").Append(fleF119_DOCTOR_YTD.ElementOwner("REC_TYPE")).Append(" = ").Append(Common.StringToField(FieldValue.ToString()));

                if (!LookupNotOn(strSQL, fleF119_DOCTOR_YTD, new string[] { "COMP_CODE", "DOC_NBR", "REC_TYPE" }, new Object[] { fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE_GROUP"), fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR"), FieldValue }))
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




        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(W_DOC_NBR, W_EP_NBR_FROM, W_EP_NBR_TO, fleF020_DOCTOR_MSTR);


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
                Receiving(W_DOC_NBR, W_EP_NBR_FROM, W_EP_NBR_TO, fleF020_DOCTOR_MSTR);


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


        protected override bool PreUpdate()
        {


            try
            {

                while (fleF119_DOCTOR_YTD.For())
                {
                    fleF119_DOCTOR_YTD.set_SetValue("REC_TYPE", "B");
                    fleF119_DOCTOR_YTD.set_SetValue("TEXT", TEXT_PART_1.Value + TEXT_PART_2.Value);
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

                while (fleF119_DOCTOR_YTD.For())
                {
                    TEXT_PART_1.Value = QDesign.Substring(fleF119_DOCTOR_YTD.GetStringValue("TEXT"), 1, 65);
                    TEXT_PART_2.Value = QDesign.Substring(fleF119_DOCTOR_YTD.GetStringValue("TEXT"), 66, 65);
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
                while (fleF119_DOCTOR_YTD.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR"), W_DOC_NBR.Value, ref blnAddWhere));
                    fleF119_DOCTOR_YTD.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:58 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:04:58 AM
                Accept(ref fldF119_DOCTOR_YTD_PROCESS_SEQ);
                Accept(ref fldTEXT_PART_1);
                Accept(ref fldTEXT_PART_2);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:58 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:04:58 AM
                fleF020_DOCTOR_MSTR.PutData(false, PutTypes.New);
                while (fleF119_DOCTOR_YTD.For())
                {
                    fleF119_DOCTOR_YTD.PutData(false, PutTypes.Deleted);
                }
                while (fleF119_DOCTOR_YTD.For())
                {
                    fleF119_DOCTOR_YTD.PutData();
                }
                fleF020_DOCTOR_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:58 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:04:58 AM
                fleF119_DOCTOR_YTD.DeletedRecord = true;
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
        //# dtlF119_DOCTOR_YTD_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:58 AM
        //#-----------------------------------------
        private void dtlF119_DOCTOR_YTD_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:07:15 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:58 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:07:15 AM
                Accept(ref fldF119_DOCTOR_YTD_PROCESS_SEQ);
                Accept(ref fldTEXT_PART_1);
                Accept(ref fldTEXT_PART_2);
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

