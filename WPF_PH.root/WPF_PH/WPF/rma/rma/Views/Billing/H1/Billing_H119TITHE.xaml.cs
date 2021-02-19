
#region "Screen Comments"

// #> PROGRAM-ID.     H119TITHE.QKS
// ((C)) Dyad Technologies
// PURPOSE: Query Physician YTD Audit/Statements File
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 2008/OCT/06  ____   M.C.   - original  COPIED FROM H119.QKS

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

    partial class Billing_H119TITHE : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_H119TITHE()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "H119TITHE";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = false;
            this.EntryActivity = true;
            this.UseAcceptProcessing = true;










            this.GridDesigner = "dsrDesigner_01";


            dsrDesigner_01.DefaultFirstRowInGrid = true;

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_FIX.Click += dsrDesigner_FIX_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF119_DOCTOR_YTD_HISTORY.EditClick += dtlF119_DOCTOR_YTD_HISTORY_EditClick;
            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            W_DOC_NBR = new CoreCharacter("W_DOC_NBR", 3, this, Common.cEmptyString);
            W_EP_NBR_FROM = new CoreDecimal("W_EP_NBR_FROM", 6, this);
            X_SRCH_CODE = new CoreCharacter("X_SRCH_CODE", 6, this, Common.cEmptyString);
            W_PASSWORD = new CoreDate("W_PASSWORD", this);
            W_SYSDATE = new CoreDate("W_SYSDATE", this);
            fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 14, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_cnnQUERY");

           
            fleF190_COMP_CODES.Access += fleF190_COMP_CODES_Access;
            X_SCREEN_NAME.GetValue += X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue += X_SCR_NAME_GetValue;
            fleF119_DOCTOR_YTD_HISTORY.SelectIf += fleF119_DOCTOR_YTD_HISTORY_SelectIf;
            W_SYSDATE.GetInitialValue += W_SYSDATE_GetInitialValue;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF190_COMP_CODES.Access -= fleF190_COMP_CODES_Access;
            X_SCREEN_NAME.GetValue -= X_SCREEN_NAME_GetValue;
            X_SCR_NAME.GetValue -= X_SCR_NAME_GetValue;

            dsrDesigner_FIX.Click -= dsrDesigner_FIX_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF119_DOCTOR_YTD_HISTORY.EditClick -= dtlF119_DOCTOR_YTD_HISTORY_EditClick;
            fleF119_DOCTOR_YTD_HISTORY.SelectIf -= fleF119_DOCTOR_YTD_HISTORY_SelectIf;
            W_SYSDATE.GetInitialValue -= W_SYSDATE_GetInitialValue;

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
        private CoreDecimal W_EP_NBR_FROM;
        private CoreCharacter X_SRCH_CODE;
        private CoreDate W_PASSWORD;
        private CoreDate W_SYSDATE;
        private void W_SYSDATE_GetInitialValue()
        {
            W_SYSDATE.InitialValue = QDesign.SysDate(ref m_cnnQUERY);
        }
        private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;

        private void fleF119_DOCTOR_YTD_HISTORY_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("REC_TYPE")).Append(" =  'D')");
                

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

        private SqlFileObject fleF190_COMP_CODES;

        private void fleF190_COMP_CODES_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ").Append(Common.StringToField(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("COMP_CODE")));

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

        private DCharacter X_SCREEN_NAME = new DCharacter(55);
        private void X_SCREEN_NAME_GetValue(ref string Value)
        {

            try
            {
                Value = "Earnings - YTD History File";


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:13 AM

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:14 AM

        protected TextBox fldF119_DOCTOR_YTD_HISTORY_COMP_CODE;
        protected TextBox fldF190_COMP_CODES_DESC_SHORT;
        protected TextBox fldF119_DOCTOR_YTD_HISTORY_COMP_CODE_GROUP;
        protected TextBox fldF119_DOCTOR_YTD_HISTORY_PROCESS_SEQ;
        protected TextBox fldF119_DOCTOR_YTD_HISTORY_AMT_MTD;

        protected TextBox fldF119_DOCTOR_YTD_HISTORY_AMT_YTD;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:14 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {

            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDF119_DOCTOR_YTD_HISTORY_COMP_CODE":
                        fldF119_DOCTOR_YTD_HISTORY_COMP_CODE = (TextBox)DataListField;
                        CoreField = fldF119_DOCTOR_YTD_HISTORY_COMP_CODE;
                        fldF119_DOCTOR_YTD_HISTORY_COMP_CODE.Bind(fleF119_DOCTOR_YTD_HISTORY);
                        break;
                    case "FLDGRDF190_COMP_CODES_DESC_SHORT":
                        fldF190_COMP_CODES_DESC_SHORT = (TextBox)DataListField;
                        CoreField = fldF190_COMP_CODES_DESC_SHORT;
                        fldF190_COMP_CODES_DESC_SHORT.Bind(fleF190_COMP_CODES);
                        break;
                    case "FLDGRDF119_DOCTOR_YTD_HISTORY_COMP_CODE_GROUP":
                        fldF119_DOCTOR_YTD_HISTORY_COMP_CODE_GROUP = (TextBox)DataListField;
                        CoreField = fldF119_DOCTOR_YTD_HISTORY_COMP_CODE_GROUP;
                        fldF119_DOCTOR_YTD_HISTORY_COMP_CODE_GROUP.Bind(fleF119_DOCTOR_YTD_HISTORY);
                        break;
                    case "FLDGRDF119_DOCTOR_YTD_HISTORY_PROCESS_SEQ":
                        fldF119_DOCTOR_YTD_HISTORY_PROCESS_SEQ = (TextBox)DataListField;
                        CoreField = fldF119_DOCTOR_YTD_HISTORY_PROCESS_SEQ;
                        fldF119_DOCTOR_YTD_HISTORY_PROCESS_SEQ.Bind(fleF119_DOCTOR_YTD_HISTORY);
                        break;
                    case "FLDGRDF119_DOCTOR_YTD_HISTORY_AMT_MTD":
                        fldF119_DOCTOR_YTD_HISTORY_AMT_MTD = (TextBox)DataListField;
                        CoreField = fldF119_DOCTOR_YTD_HISTORY_AMT_MTD;
                        fldF119_DOCTOR_YTD_HISTORY_AMT_MTD.Bind(fleF119_DOCTOR_YTD_HISTORY);
                        break;
                    case "FLDGRDF119_DOCTOR_YTD_HISTORY_AMT_YTD":
                        fldF119_DOCTOR_YTD_HISTORY_AMT_YTD = (TextBox)DataListField;
                        CoreField = fldF119_DOCTOR_YTD_HISTORY_AMT_YTD;
                        fldF119_DOCTOR_YTD_HISTORY_AMT_YTD.Bind(fleF119_DOCTOR_YTD_HISTORY);
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
                dtlF119_DOCTOR_YTD_HISTORY.OccursWithFile = fleF119_DOCTOR_YTD_HISTORY;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:14 AM

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
            fleF119_DOCTOR_YTD_HISTORY.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:14 AM

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
                fleF119_DOCTOR_YTD_HISTORY.Dispose();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:09:13 AM
        //#-----------------------------------------
        protected override void DisplayFormatting()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:09:13 AM
                Display(ref fldW_PASSWORD);
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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:09:14 AM

        //#-----------------------------------------
        //# BindFields Procedure.
        //#-----------------------------------------

        public override void BindFields()
        {
            try
            {
                fldW_PASSWORD.Bind(W_PASSWORD);

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
                SaveReceivingParams(W_DOC_NBR, W_EP_NBR_FROM, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


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
                Receiving(W_DOC_NBR, W_EP_NBR_FROM, fleCONSTANTS_MSTR_REC_6, fleF020_DOCTOR_MSTR);


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

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    Accept(ref fldW_PASSWORD);
                }
                if (QDesign.NULL(W_PASSWORD.Value) == QDesign.NULL(W_SYSDATE.Value))
                {
                    Accept(ref fldF119_DOCTOR_YTD_HISTORY_COMP_CODE);
                    Accept(ref fldF190_COMP_CODES_DESC_SHORT);
                    Accept(ref fldF119_DOCTOR_YTD_HISTORY_COMP_CODE_GROUP);
                    Accept(ref fldF119_DOCTOR_YTD_HISTORY_PROCESS_SEQ);
                    Accept(ref fldF119_DOCTOR_YTD_HISTORY_AMT_MTD);
                    Accept(ref fldF119_DOCTOR_YTD_HISTORY_AMT_YTD);
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


        protected override bool Entry()
        {


            try
            {

                if (QDesign.NULL(W_PASSWORD.Value) != QDesign.NULL(W_SYSDATE.Value))
                {
                    Accept(ref fldW_PASSWORD);
                }
                if (QDesign.NULL(W_PASSWORD.Value) == QDesign.NULL(W_SYSDATE.Value))
                {
                    while (fleF119_DOCTOR_YTD_HISTORY.For())
                    {
                        fleF119_DOCTOR_YTD_HISTORY.set_SetValue("REC_TYPE", "D");
                    }
                    fleF119_DOCTOR_YTD_HISTORY.set_SetValue("DOC_NBR", W_DOC_NBR.Value);
                    fleF119_DOCTOR_YTD_HISTORY.set_SetValue("EP_NBR", W_EP_NBR_FROM.Value);
                    Accept(ref fldF119_DOCTOR_YTD_HISTORY_COMP_CODE);
                    Display(ref fldF190_COMP_CODES_DESC_SHORT);
                    fleF119_DOCTOR_YTD_HISTORY.set_SetValue("COMP_CODE_GROUP", fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP"));
                    Display(ref fldF119_DOCTOR_YTD_HISTORY_COMP_CODE_GROUP);
                    fleF119_DOCTOR_YTD_HISTORY.set_SetValue("PROCESS_SEQ", fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
                    Display(ref fldF119_DOCTOR_YTD_HISTORY_PROCESS_SEQ);
                    Accept(ref fldF119_DOCTOR_YTD_HISTORY_AMT_MTD);
                    Accept(ref fldF119_DOCTOR_YTD_HISTORY_AMT_YTD);
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
                while (fleF119_DOCTOR_YTD_HISTORY.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("DOC_NBR"), W_DOC_NBR.Value, ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF119_DOCTOR_YTD_HISTORY.ElementOwner("EP_NBR"), W_EP_NBR_FROM.Value, ref blnAddWhere));
                    fleF119_DOCTOR_YTD_HISTORY.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:09:13 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:09:13 AM
                Display(ref fldF119_DOCTOR_YTD_HISTORY_COMP_CODE);
                Display(ref fldF190_COMP_CODES_DESC_SHORT);
                Display(ref fldF119_DOCTOR_YTD_HISTORY_COMP_CODE_GROUP);
                Display(ref fldF119_DOCTOR_YTD_HISTORY_PROCESS_SEQ);
                Accept(ref fldF119_DOCTOR_YTD_HISTORY_AMT_MTD);
                Accept(ref fldF119_DOCTOR_YTD_HISTORY_AMT_YTD);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:09:13 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:09:13 AM
                fleF020_DOCTOR_MSTR.PutData(false, PutTypes.New);
                fleCONSTANTS_MSTR_REC_6.PutData(false, PutTypes.New);
                while (fleF119_DOCTOR_YTD_HISTORY.For())
                {
                    fleF119_DOCTOR_YTD_HISTORY.PutData();
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
        //# dtlF119_DOCTOR_YTD_HISTORY_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:09:14 AM
        //#-----------------------------------------
        private void dtlF119_DOCTOR_YTD_HISTORY_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:09:14 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:09:14 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:09:14 AM
                Display(ref fldF119_DOCTOR_YTD_HISTORY_COMP_CODE);
                Display(ref fldF190_COMP_CODES_DESC_SHORT);
                Display(ref fldF119_DOCTOR_YTD_HISTORY_COMP_CODE_GROUP);
                Display(ref fldF119_DOCTOR_YTD_HISTORY_PROCESS_SEQ);
                Accept(ref fldF119_DOCTOR_YTD_HISTORY_AMT_MTD);
                Accept(ref fldF119_DOCTOR_YTD_HISTORY_AMT_YTD);
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