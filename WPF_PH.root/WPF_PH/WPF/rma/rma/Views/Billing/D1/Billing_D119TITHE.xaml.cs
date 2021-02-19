
#region "Screen Comments"

// #> program-id.     d119tithe.qks
// ((C)) Dyad Technologies
// PURPOSE: Query/modifications to Physician Tithe Calculations `D` type transaction
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 2008/may/21 M.C.      - original, cloned from d119.qks

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

    partial class Billing_D119TITHE : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_D119TITHE()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "D119TITHE";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;












            this.GridDesigner = "dsrDesigner_02";


            dsrDesigner_02.DefaultFirstRowInGrid = true;



        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_02.Click += dsrDesigner_02_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF119_DOCTOR_YTD.EditClick += dtlF119_DOCTOR_YTD_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            X_SRCH_CODE = new CoreCharacter("X_SRCH_CODE", 6, this, Common.cEmptyString);
            fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 14, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF119_SUMMARY = new SqlFileObject(this, FileTypes.Designer, fleF119_DOCTOR_YTD, "INDEXED", "F119_DOCTOR_YTD", "F119_SUMMARY", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_cnnQUERY");
            OLD_AMT_MTD = new CoreDecimal("OLD_AMT_MTD", 8, this, fleF119_DOCTOR_YTD, 0m);
            OLD_AMT_YTD = new CoreDecimal("OLD_AMT_YTD", 8, this, fleF119_DOCTOR_YTD, 0m);

          
            fleF119_SUMMARY.Access += fleF119_SUMMARY_Access;
            fleF190_COMP_CODES.Access += fleF190_COMP_CODES_Access;
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
            fleF119_DOCTOR_YTD.SelectIf += fleF119_DOCTOR_YTD_SelectIf;
            fleF119_DOCTOR_YTD.InitializeItems += fleF119_DOCTOR_YTD_InitializeItems;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF119_SUMMARY.Access -= fleF119_SUMMARY_Access;
            fleF190_COMP_CODES.Access -= fleF190_COMP_CODES_Access;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;
          
            fleF119_DOCTOR_YTD.SelectIf -= fleF119_DOCTOR_YTD_SelectIf;
            fleF119_DOCTOR_YTD.InitializeItems -= fleF119_DOCTOR_YTD_InitializeItems;

            dsrDesigner_02.Click -= dsrDesigner_02_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF119_DOCTOR_YTD.EditClick -= dtlF119_DOCTOR_YTD_EditClick;
          

        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF020_DOCTOR_MSTR;
        private SqlFileObject fleCONSTANTS_MSTR_REC_6;
        private CoreCharacter W_DOC_NBR;
        private CoreCharacter X_SRCH_CODE;
        private SqlFileObject fleF119_DOCTOR_YTD;

        private void fleF119_DOCTOR_YTD_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleF119_DOCTOR_YTD.ElementOwner("REC_TYPE")).Append(" =  'D' AND ");
                strSQL.Append(" (    ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR")).Append(" =  ").Append(Common.StringToField(W_DOC_NBR.Value)).Append("  OR ");
                strSQL.Append("    ").Append(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR")).Append(" =  '000' ))");
                

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
                    fleF119_DOCTOR_YTD.set_SetValue("DOC_NBR", true, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("DOC_OHIP_NBR", true, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("REC_TYPE", true, "D");
                fleF119_DOCTOR_YTD.set_SetValue("DOC_NBR", !Fixed, "000");
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("DOC_OHIP_NBR", true, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("COMP_CODE", true, fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE"));
                if (!Fixed)
                    fleF119_DOCTOR_YTD.set_SetValue("REC_TYPE", true, "D");


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

        private SqlFileObject fleF119_SUMMARY;

        private void fleF119_SUMMARY_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF119_SUMMARY.ElementOwner("DOC_NBR")).Append(" = ").Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_OHIP_NBR")));
                strText.Append(" AND ").Append(fleF119_SUMMARY.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField("000"));
                strText.Append(" AND ").Append(fleF119_SUMMARY.ElementOwner("REC_TYPE")).Append(" = ").Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")));
                strText.Append(" AND ").Append(fleF119_SUMMARY.ElementOwner("DOC_OHIP_NBR")).Append(" = ").Append(("D"));

                strText.Append(" ORDER BY ").Append(fleF119_SUMMARY.ElementOwner("DOC_OHIP_NBR"));
                strText.Append(", ").Append(fleF119_SUMMARY.ElementOwner("DOC_NBR"));
                strText.Append(", ").Append(fleF119_SUMMARY.ElementOwner("COMP_CODE"));
                strText.Append(", ").Append(fleF119_SUMMARY.ElementOwner("REC_TYPE"));
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

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")));

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

        private CoreDecimal OLD_AMT_MTD;
        private CoreDecimal OLD_AMT_YTD;
        private DCharacter X_SCREEN_NAME = new DCharacter(44);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "Earnings - Tithe Calculation transactions";


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:53 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:53 AM

        protected TextBox fldF119_DOCTOR_YTD_DOC_OHIP_NBR;
        protected TextBox fldF119_DOCTOR_YTD_DOC_NBR;
        protected TextBox fldF119_DOCTOR_YTD_COMP_CODE;
        protected TextBox fldF190_COMP_CODES_DESC_SHORT;
        protected TextBox fldF119_DOCTOR_YTD_COMP_CODE_GROUP;
        protected TextBox fldF119_DOCTOR_YTD_PROCESS_SEQ;
        protected TextBox fldF119_DOCTOR_YTD_AMT_MTD;
        protected TextBox fldF119_DOCTOR_YTD_AMT_YTD;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:53 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF119_DOCTOR_YTD_DOC_OHIP_NBR":
                        fldF119_DOCTOR_YTD_DOC_OHIP_NBR = (TextBox)DataListField;
                        CoreField = fldF119_DOCTOR_YTD_DOC_OHIP_NBR;
                        fldF119_DOCTOR_YTD_DOC_OHIP_NBR.Bind(fleF119_DOCTOR_YTD);
                        break;
                    case "FLDGRDF119_DOCTOR_YTD_DOC_NBR":
                        fldF119_DOCTOR_YTD_DOC_NBR = (TextBox)DataListField;
                        CoreField = fldF119_DOCTOR_YTD_DOC_NBR;
                        fldF119_DOCTOR_YTD_DOC_NBR.Bind(fleF119_DOCTOR_YTD);
                        break;
                    case "FLDGRDF119_DOCTOR_YTD_COMP_CODE":
                        fldF119_DOCTOR_YTD_COMP_CODE = (TextBox)DataListField;

                        fldF119_DOCTOR_YTD_COMP_CODE.LookupOn -= fldF119_DOCTOR_YTD_COMP_CODE_LookupOn;
                        fldF119_DOCTOR_YTD_COMP_CODE.LookupOn += fldF119_DOCTOR_YTD_COMP_CODE_LookupOn;

                        fldF119_DOCTOR_YTD_COMP_CODE.Input -= fldF119_DOCTOR_YTD_COMP_CODE_Input;
                        fldF119_DOCTOR_YTD_COMP_CODE.Input += fldF119_DOCTOR_YTD_COMP_CODE_Input;
                        fldF119_DOCTOR_YTD_COMP_CODE.Process -= fldF119_DOCTOR_YTD_COMP_CODE_Process;
                        fldF119_DOCTOR_YTD_COMP_CODE.Process += fldF119_DOCTOR_YTD_COMP_CODE_Process;
                        CoreField = fldF119_DOCTOR_YTD_COMP_CODE;
                        fldF119_DOCTOR_YTD_COMP_CODE.Bind(fleF119_DOCTOR_YTD);
                        break;
                    case "FLDGRDF190_COMP_CODES_DESC_SHORT":
                        fldF190_COMP_CODES_DESC_SHORT = (TextBox)DataListField;
                        CoreField = fldF190_COMP_CODES_DESC_SHORT;
                        fldF190_COMP_CODES_DESC_SHORT.Bind(fleF190_COMP_CODES);
                        break;
                    case "FLDGRDF119_DOCTOR_YTD_COMP_CODE_GROUP":
                        fldF119_DOCTOR_YTD_COMP_CODE_GROUP = (TextBox)DataListField;
                        CoreField = fldF119_DOCTOR_YTD_COMP_CODE_GROUP;
                        fldF119_DOCTOR_YTD_COMP_CODE_GROUP.Bind(fleF119_DOCTOR_YTD);
                        break;
                    case "FLDGRDF119_DOCTOR_YTD_PROCESS_SEQ":
                        fldF119_DOCTOR_YTD_PROCESS_SEQ = (TextBox)DataListField;
                        CoreField = fldF119_DOCTOR_YTD_PROCESS_SEQ;
                        fldF119_DOCTOR_YTD_PROCESS_SEQ.Bind(fleF119_DOCTOR_YTD);
                        break;
                    case "FLDGRDF119_DOCTOR_YTD_AMT_MTD":
                        fldF119_DOCTOR_YTD_AMT_MTD = (TextBox)DataListField;

                        fldF119_DOCTOR_YTD_AMT_MTD.Edit -= fldF119_DOCTOR_YTD_AMT_MTD_Edit;
                        fldF119_DOCTOR_YTD_AMT_MTD.Edit += fldF119_DOCTOR_YTD_AMT_MTD_Edit;
                        CoreField = fldF119_DOCTOR_YTD_AMT_MTD;
                        fldF119_DOCTOR_YTD_AMT_MTD.Bind(fleF119_DOCTOR_YTD);
                        break;
                    case "FLDGRDF119_DOCTOR_YTD_AMT_YTD":
                        fldF119_DOCTOR_YTD_AMT_YTD = (TextBox)DataListField;

                        fldF119_DOCTOR_YTD_AMT_YTD.Edit -= fldF119_DOCTOR_YTD_AMT_YTD_Edit;
                        fldF119_DOCTOR_YTD_AMT_YTD.Edit += fldF119_DOCTOR_YTD_AMT_YTD_Edit;
                        CoreField = fldF119_DOCTOR_YTD_AMT_YTD;
                        fldF119_DOCTOR_YTD_AMT_YTD.Bind(fleF119_DOCTOR_YTD);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:53 AM

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
            fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;
            fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;
            fleF119_SUMMARY.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:53 AM

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
                fleCONSTANTS_MSTR_REC_6.Dispose();
                fleF119_DOCTOR_YTD.Dispose();
                fleF119_SUMMARY.Dispose();
                fleF190_COMP_CODES.Dispose();


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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:56 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:07:53 AM
                
                Display(ref fldW_DOC_NBR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:07:53 AM
        //#-----------------------------------------
        protected override void PreDisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:07:53 AM
                
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:07:53 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                
                fldW_DOC_NBR.Bind(W_DOC_NBR);

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



        private void fldF119_DOCTOR_YTD_COMP_CODE_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(FieldText));

                fleF190_COMP_CODES.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Error -  Invalid COMPENSATION Code.\a");
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




        protected override void SaveParamsReceived()
        {

            try
            {
                SaveReceivingParams(W_DOC_NBR, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


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
                Receiving(W_DOC_NBR, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


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



        private void fldF119_DOCTOR_YTD_COMP_CODE_Input()
        {

            try
            {

                if (QDesign.NULL(FieldText) == QDesign.NULL("."))
                {
                    X_SRCH_CODE.Value = " ";
                    object[] arrRunscreen = { X_SRCH_CODE };
                    RunScreen(new Billing_SY033(), RunScreenModes.Find, ref arrRunscreen);
                    if (QDesign.NULL(X_SRCH_CODE.Value) != QDesign.NULL(" "))
                    {
                        FieldText = X_SRCH_CODE.Value;
                    }
                    else
                    {
                        ErrorMessage("Error - A Compensation Code is required.\a\a");
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



        private void fldF119_DOCTOR_YTD_COMP_CODE_Process()
        {

            try
            {

                Display(ref fldF190_COMP_CODES_DESC_SHORT);
                fleF119_DOCTOR_YTD.set_SetValue("PROCESS_SEQ", fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ"));
                Display(ref fldF119_DOCTOR_YTD_PROCESS_SEQ);
                fleF119_DOCTOR_YTD.set_SetValue("COMP_CODE_GROUP", fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP"));
                Display(ref fldF119_DOCTOR_YTD_COMP_CODE_GROUP);


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



        private void fldF119_DOCTOR_YTD_AMT_MTD_Edit()
        {

            try
            {

                if (ChangeMode)
                {
                    OLD_AMT_MTD.Value = OldValue(fleF119_DOCTOR_YTD.ElementOwner("AMT_MTD"), fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD"));
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



        private void fldF119_DOCTOR_YTD_AMT_YTD_Edit()
        {

            try
            {

                if (ChangeMode)
                {
                    OLD_AMT_YTD.Value = OldValue(fleF119_DOCTOR_YTD.ElementOwner("AMT_YTD"), fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD"));
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

                while (fleF119_DOCTOR_YTD.For())
                {
                    if (NewRecord())
                    {
                        // --> GET F119_SUMMARY <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF119_SUMMARY.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_OHIP_NBR")));
                        m_strWhere.Append(" And ").Append(fleF119_SUMMARY.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                        m_strWhere.Append(("D"));
                        m_strWhere.Append(" And ").Append(fleF119_SUMMARY.ElementOwner("REC_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")));
                        m_strWhere.Append(" And ").Append(fleF119_SUMMARY.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("000"));

                        fleF119_SUMMARY.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F119_SUMMARY <--
                        if (!AccessOk)
                        {
                            fleF119_SUMMARY.set_SetValue("DOC_OHIP_NBR", fleF119_DOCTOR_YTD.GetDecimalValue("DOC_OHIP_NBR"));
                            fleF119_SUMMARY.set_SetValue("DOC_NBR", "000");
                            fleF119_SUMMARY.set_SetValue("REC_TYPE", "D");
                            fleF119_SUMMARY.set_SetValue("COMP_CODE", fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE"));
                            fleF119_SUMMARY.set_SetValue("PROCESS_SEQ", fleF119_DOCTOR_YTD.GetDecimalValue("PROCESS_SEQ"));
                            fleF119_SUMMARY.set_SetValue("COMP_CODE_GROUP", fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE_GROUP"));
                            fleF119_SUMMARY.set_SetValue("AMT_MTD", fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD"));
                            fleF119_SUMMARY.set_SetValue("AMT_YTD", fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD"));
                        }
                        else
                        {
                            fleF119_SUMMARY.set_SetValue("AMT_MTD", fleF119_SUMMARY.GetDecimalValue("AMT_MTD") + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD"));
                            fleF119_SUMMARY.set_SetValue("AMT_YTD", fleF119_SUMMARY.GetDecimalValue("AMT_YTD") + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD"));
                        }
                        fleF119_SUMMARY.PutData(true);
                    }
                    else
                    {
                        if (DeletedRecord())
                        {
                            if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("DOC_NBR")) == QDesign.NULL("000"))
                            {
                                ErrorMessage(QDesign.NULL("You cannot delete doctor summary record"));
                                // TODO: May need to fix manually
                            }
                            else
                            {
                                // --> GET F119_SUMMARY <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF119_SUMMARY.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_OHIP_NBR")));
                                m_strWhere.Append(" And ").Append(fleF119_SUMMARY.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                m_strWhere.Append(("D"));
                                m_strWhere.Append(" And ").Append(fleF119_SUMMARY.ElementOwner("REC_TYPE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")));
                                m_strWhere.Append(" And ").Append(fleF119_SUMMARY.ElementOwner("COMP_CODE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField("000"));

                                fleF119_SUMMARY.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F119_SUMMARY <--
                                if (!AccessOk)
                                {
                                    ErrorMessage(QDesign.NULL("Doctor summary record not found - cannot delete"));
                                    // TODO: May need to fix manually
                                }
                                else
                                {
                                    fleF119_SUMMARY.set_SetValue("AMT_MTD", fleF119_SUMMARY.GetDecimalValue("AMT_MTD") - fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD"));
                                    fleF119_SUMMARY.set_SetValue("AMT_YTD", fleF119_SUMMARY.GetDecimalValue("AMT_YTD") - fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD"));
                                    fleF119_SUMMARY.PutData(true);
                                }
                            }
                        }
                        else
                        {
                            if (AlteredRecord())
                            {
                                // --> GET F119_SUMMARY <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF119_SUMMARY.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("DOC_OHIP_NBR")));
                                m_strWhere.Append(" And ").Append(fleF119_SUMMARY.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                                m_strWhere.Append(("D"));
                                m_strWhere.Append(" And ").Append(fleF119_SUMMARY.ElementOwner("REC_TYPE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF119_DOCTOR_YTD.GetStringValue("COMP_CODE")));
                                m_strWhere.Append(" And ").Append(fleF119_SUMMARY.ElementOwner("COMP_CODE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField("000"));

                                fleF119_SUMMARY.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F119_SUMMARY <--
                                if (!AccessOk)
                                {
                                    ErrorMessage(QDesign.NULL("Doctor summary record does not exist"));
                                    // TODO: May need to fix manually
                                }
                                else
                                {
                                    fleF119_SUMMARY.set_SetValue("AMT_MTD", fleF119_SUMMARY.GetDecimalValue("AMT_MTD") - OLD_AMT_MTD.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_MTD"));
                                    fleF119_SUMMARY.set_SetValue("AMT_YTD", fleF119_SUMMARY.GetDecimalValue("AMT_YTD") - OLD_AMT_YTD.Value + fleF119_DOCTOR_YTD.GetDecimalValue("AMT_YTD"));
                                    fleF119_SUMMARY.PutData(true);
                                }
                            }
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




        protected override bool Find()
        {


            try
            {
                bool blnAddWhere = true;
                while (fleF119_DOCTOR_YTD.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF119_DOCTOR_YTD.ElementOwner("DOC_OHIP_NBR"), fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR"), ref blnAddWhere));
                    //m_strWhere.Append(GetWhereCondition(fleF119_DOCTOR_YTD.ElementOwner("DOC_NBR"), fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"), ref blnAddWhere));
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:56 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:04:56 AM
                Display(ref fldF119_DOCTOR_YTD_DOC_OHIP_NBR);
                Display(ref fldF119_DOCTOR_YTD_DOC_NBR);
                Accept(ref fldF119_DOCTOR_YTD_COMP_CODE);
                Display(ref fldF190_COMP_CODES_DESC_SHORT);
                Display(ref fldF119_DOCTOR_YTD_COMP_CODE_GROUP);
                Display(ref fldF119_DOCTOR_YTD_PROCESS_SEQ);
                Accept(ref fldF119_DOCTOR_YTD_AMT_MTD);
                Accept(ref fldF119_DOCTOR_YTD_AMT_YTD);
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
        //# Entry Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:56 AM
        //#-----------------------------------------
        protected override bool Entry()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:04:56 AM
                Display(ref fldW_DOC_NBR);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:56 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:04:56 AM
                fleF020_DOCTOR_MSTR.PutData(false, PutTypes.New);
                fleCONSTANTS_MSTR_REC_6.PutData(false, PutTypes.New);
                while (fleF119_DOCTOR_YTD.For())
                {
                    fleF119_DOCTOR_YTD.PutData(false, PutTypes.Deleted);
                }
                while (fleF119_DOCTOR_YTD.For())
                {
                    fleF119_DOCTOR_YTD.PutData();
                }
                fleCONSTANTS_MSTR_REC_6.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:56 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:04:56 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:56 AM
        //#-----------------------------------------
        private void dtlF119_DOCTOR_YTD_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:07:53 AM
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
        //# dsrDesigner_02_Click Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:56 AM
        //#-----------------------------------------
        private void dsrDesigner_02_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:07:53 AM
                Display(ref fldF119_DOCTOR_YTD_DOC_OHIP_NBR);
                Display(ref fldF119_DOCTOR_YTD_DOC_NBR);
                Accept(ref fldF119_DOCTOR_YTD_COMP_CODE);
                Display(ref fldF190_COMP_CODES_DESC_SHORT);
                Display(ref fldF119_DOCTOR_YTD_COMP_CODE_GROUP);
                Display(ref fldF119_DOCTOR_YTD_PROCESS_SEQ);
                Accept(ref fldF119_DOCTOR_YTD_AMT_MTD);
                Accept(ref fldF119_DOCTOR_YTD_AMT_YTD);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:04:56 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:07:53 AM
                Display(ref fldW_DOC_NBR);
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

