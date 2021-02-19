
#region "Screen Comments"

// Program: utl1001.qks
// used to allow `administrator` to change fields on claims detail recs
// 1998/Jul/13 B.E.      - original - cloned from fixf002_hdr
// NEEDS ABILITY TO ADD new records - doesn`t update  orig  etc key
// stuff and when entry made the records  disappeared  and couldn`t
// be displayed again by this pgm
// 2000/jun/13 B.E.      - removed code that re-priced line
// 2000/jul/05 M.C. - receiving f001 as master, add sum into for
// clmdtl amount and nbr of svc into f001 besides f002
// 2000/nov/22 M.C. - allow user to add new records with basic pricing
// 2001/jun/17 B.E. - renamed from fixf002_dtl.qks to utl1001.qks
// 2002/mar/01 M.C. - do not allow user to add or delete records,
// allow user to change from oma cd and onward
// - do not allow user to change if batch status > 2
// - if batch status = 2 and user changes oma cd or amt or svc
// reverse from f050 and f051 or tp  accordingly
// - add designer files f002-dtl-before and 
// f002-dtl-after when there are changes
// in oma cd, svc or amount with batch status = 2
// 2002/may/23 M.C. - allow user to change the record regardless of the batch status
// - store batch-status in f002-dtl-before/after files
// - if batch status = 3 , do the same as batch status 2
// - if batch status = 4, update YTD figures in f050 or f051 or tp files
// and update MTD & YTD in f050 history if applicable
// - store batch-status in f002-dtl-before/after files
// 2002/may/29 M.C. - store clmdtl-date-period-end in f002-dtl-before/after files
// 2003/dec/10 A.A. - alpha doctor nbr
// 2006/feb/17 b.e. - allow oma/ohip fees to be changed
// 2006/feb/17 b.e. - undid above change - use PRIC designer routine
// 2011/jul/18 MC1  - create new designer DATE to allow user to change service date
// 2012/Aug/08 MC2  - when user changes date, recalculate the clmhdr-serv-date      
// 2013/Jun/10 MC3 - allow delete activity and sum into amt field of f001
// 2002/03/01 - MC
// screen $pb_obj/utl1001 receiving f002-claims-mstr, f001-batch-control-file
// 2013/06/10 - MC3
// screen $pb_obj/utl1001  activities find, change   &
// 2013/06/10 - end

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

    partial class Billing_UTL1001 : BasePage
    {

        #region " Form Designer Generated Code "





        public Billing_UTL1001()
        {
            base.LoadBase();
            //CODEGEN: This method call is required by the Web Form Designer
            //Do not modify it using the code editor.
            InitializeComponent();
            Loaded += Page_Load;
            Unloaded += Page_Unloaded;

            this.FormName = "UTL1001";

            //# Set the ACTIVITIES for the screen.
            this.ChangeActivity = true;
            this.FindActivity = true;
            this.DeleteActivity = true;
            this.EntryActivity = false;
            this.DisableAppend = true;
            this.UseAcceptProcessing = true;


            this.GridDesigner = "dsrDesigner_01";


            dsrDesigner_01.DefaultFirstRowInGrid = true;

        }

        #endregion

        private void Page_Load(object sender, RoutedEventArgs e)
        {
            SetVariables();
            dsrDesigner_CORE_DATE.Click += dsrDesigner_CORE_DATE_Click;
            dsrDesigner_PRICE.Click += dsrDesigner_PRICE_Click;
            dsrDesigner_TECH.Click += dsrDesigner_TECH_Click;
            dsrDesigner_01.Click += dsrDesigner_01_Click;
            dtlF002_DTL.EditClick += dtlF002_DTL_EditClick;

            base.Page_Load();

            // TODO: If any DESIGNER procedures function on occurring FILES or TEMPORARIES, set the grid's AllowSelectRowButton property to TRUE.



            // TODO: The following FIELD(S) on the form are redefine elements.  Manual steps may be required:
            //       F002_DTL.CLMDTL_SV_DATE


        }

        protected override void SetVariables()
        {
            //Put user code to initialize the page here
            fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Master, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
            fleF002_DTL = new SqlFileObject(this, FileTypes.Primary, 10, "INDEXED", "F002_CLAIMS_MSTR_DTL", "F002_DTL", true, false, false, 0, "m_trnTRANS_UPDATE");
            T_TECH_PROF_FEE = new CoreDecimal("T_TECH_PROF_FEE", 6, this, fleF002_DTL, 0m);
            CLMDTL_SV_DATE = new CoreDecimal("CLMDTL_SV_DATE", 8, this, fleF002_DTL, 0m);
            CLMDTL_SV_DAY_1 = new CoreDecimal("CLMDTL_SV_DAY_1", 2, this, fleF002_DTL, 0m);
            CLMDTL_SV_DAY_2 = new CoreDecimal("CLMDTL_SV_DAY_2", 2, this, fleF002_DTL, 0m);
            CLMDTL_SV_DAY_3 = new CoreDecimal("CLMDTL_SV_DAY_3", 2, this, fleF002_DTL, 0m);
            CLMDTL_SV_NBR_1 = new CoreDecimal("CLMDTL_SV_NBR_1", 1, this, fleF002_DTL, 0m);
            CLMDTL_SV_NBR_2 = new CoreDecimal("CLMDTL_SV_NBR_2", 1, this, fleF002_DTL, 0m);
            CLMDTL_SV_NBR_3 = new CoreDecimal("CLMDTL_SV_NBR_3", 1, this, fleF002_DTL, 0m);
            TOT_NBR_SERV = new CoreDecimal("TOT_NBR_SERV", 6, this, fleF002_DTL, 0m);
            T_SILENT = new CoreCharacter("T_SILENT", 1, this, fleF002_DTL, Common.cEmptyString);
            OLD_OMA_CD = new CoreCharacter("OLD_OMA_CD", 5, this, fleF002_DTL, Common.cEmptyString);
            OLD_NBR_SERV = new CoreDecimal("OLD_NBR_SERV", 2, this, fleF002_DTL, 0m);
            OLD_FEE_OHIP = new CoreDecimal("OLD_FEE_OHIP", 7, this, fleF002_DTL, 0m);
            OLD_AMT_TECH_BILLED = new CoreDecimal("OLD_AMT_TECH_BILLED", 7, this, fleF002_DTL, 0m);
            CHANGE_FLAG = new CoreCharacter("CHANGE_FLAG", 1, this, fleF002_DTL, Common.cEmptyString);
            X_SV_DATE = new CoreCharacter("X_SV_DATE", 8, this, Common.cEmptyString);
            fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Reference, 0, "[101C].INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_cnnQUERY");
            fleF002_DTL_BEFORE = new SqlFileObject(this, FileTypes.Designer, fleF002_DTL, "SEQUENTIAL", "F002_DTL_BEFORE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SequentialDataBase);
            fleF002_DTL_AFTER = new SqlFileObject(this, FileTypes.Designer, fleF002_DTL, "SEQUENTIAL", "F002_DTL_AFTER", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SequentialDataBase);

            fleF002_DTL.SumIntoFields = "CLMDTL_FEE_OMA,CLMDTL_FEE_OHIP,CLMDTL_NBR_SERV,CLMDTL_SV_NBR_1,CLMDTL_SV_NBR_2,CLMDTL_SV_NBR_3,CLMDTL_AMT_TECH_BILLED";

            fleF002_DTL.SetItemFinals += fleF002_DTL_SetItemFinals;
            fleF040_OMA_FEE_MSTR.Access += fleF040_OMA_FEE_MSTR_Access;
            fleF002_DTL.SelectIf += fleF002_DTL_SelectIf;
            fleF002_DTL.SumInto += fleF002_DTL_SumInto;
        }

        void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Loaded -= Page_Load;
            Unloaded -= Page_Unloaded;
            fleF040_OMA_FEE_MSTR.Access -= fleF040_OMA_FEE_MSTR_Access;
            fldF002_DTL_KEY_CLM_SERV_CODE.LookupOn -= fldF002_DTL_KEY_CLM_SERV_CODE_LookupOn;
            fldT_SILENT.Edit -= fldT_SILENT_Edit;

            dsrDesigner_CORE_DATE.Click -= dsrDesigner_CORE_DATE_Click;
            dsrDesigner_PRICE.Click -= dsrDesigner_PRICE_Click;
            dsrDesigner_TECH.Click -= dsrDesigner_TECH_Click;
            dsrDesigner_01.Click -= dsrDesigner_01_Click;
            dtlF002_DTL.EditClick -= dtlF002_DTL_EditClick;
            fleF002_DTL.SelectIf -= fleF002_DTL_SelectIf;
            fldF002_DTL_KEY_CLM_SERV_CODE.Process -= fldF002_DTL_KEY_CLM_SERV_CODE_Process;
            fldF002_DTL_CLMDTL_NBR_SERV.Process -= fldF002_DTL_CLMDTL_NBR_SERV_Process;
            fldF002_DTL_CLMDTL_SV_NBR_1.Process -= fldF002_DTL_CLMDTL_SV_NBR_1_Process;
            fldF002_DTL_CLMDTL_SV_NBR_2.Process -= fldF002_DTL_CLMDTL_SV_NBR_2_Process;
            fldF002_DTL_CLMDTL_SV_NBR_3.Process -= fldF002_DTL_CLMDTL_SV_NBR_3_Process;
        }

        #region "Renaissance Architect Migration Services Default Regions"

        #region "Declarations (Variables, Files and Transactions)"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.
        private SqlConnection m_cnnQUERY = new SqlConnection();
        private SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
        private SqlTransaction m_trnTRANS_UPDATE;
        private SqlFileObject fleF002_CLAIMS_MSTR;
        private SqlFileObject fleF001_BATCH_CONTROL_FILE;
        private SqlFileObject fleF002_DTL;

        private void fleF002_DTL_SelectIf(ref string SelectIfClause)
        {


            try
            {
                StringBuilder strSQL = new StringBuilder("");

                strSQL.Append(" (    ").Append(fleF002_DTL.ElementOwner("KEY_CLM_SERV_CODE")).Append(" <>  '00000' AND ");
                strSQL.Append("  Substring (   ").Append(fleF002_DTL.ElementOwner("KEY_CLM_SERV_CODE")).Append(" ,  1 ,  4 ) <>  'ZZZZ')");


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



        private void fleF002_DTL_SetItemFinals()
        {

            try
            {
                fleF002_DTL.set_SetValue("CLMDTL_OMA_CD", QDesign.Substring(fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE"), 1, 4));
                fleF002_DTL.set_SetValue("CLMDTL_OMA_SUFF", QDesign.Substring(fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE"), 5, 1));


                fleF002_DTL.set_SetValue("CLMDTL_SV_YY", CLMDTL_SV_DATE.Value.ToString().PadLeft(8, '0').Substring(0, 4));
                fleF002_DTL.set_SetValue("CLMDTL_SV_MM", CLMDTL_SV_DATE.Value.ToString().PadLeft(8, '0').Substring(4, 2));
                fleF002_DTL.set_SetValue("CLMDTL_SV_DD", CLMDTL_SV_DATE.Value.ToString().PadLeft(8, '0').Substring(6, 2));

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



        private void fleF002_DTL_SumInto(string Field, decimal Value, decimal OldValue)
        {

            try
            {
                switch (Field)
                {
                    case "CLMDTL_FEE_OMA":
                        fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") + (Value - OldValue));
                        break;
                    case "CLMDTL_FEE_OHIP":
                        fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_EST") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_ACT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_TOT_REV", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_TOT_REV") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_AR_DUE", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") + (Value - OldValue));
                        break;
                    case "CLMDTL_NBR_SERV":
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_ACT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_ACT") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_EST") + (Value - OldValue));
                        break;
                    case "CLMDTL_SV_NBR_1":
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_ACT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_ACT") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_EST") + (Value - OldValue));
                        break;
                    case "CLMDTL_SV_NBR_2":
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_ACT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_ACT") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_EST") + (Value - OldValue));
                        break;
                    case "CLMDTL_SV_NBR_3":
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_ACT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_ACT") + (Value - OldValue));
                        fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_SVC_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_SVC_EST") + (Value - OldValue));
                        break;
                    case "CLMDTL_AMT_TECH_BILLED":
                        fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_AMT_TECH_BILLED", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") + (Value - OldValue));
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
        private CoreDecimal CLMDTL_SV_DAY_1;
        private CoreDecimal CLMDTL_SV_DAY_2;
        private CoreDecimal CLMDTL_SV_DAY_3;
        private CoreDecimal CLMDTL_SV_NBR_1;
        private CoreDecimal CLMDTL_SV_NBR_2;
        private CoreDecimal CLMDTL_SV_NBR_3;
        private CoreDecimal CLMDTL_SV_DATE;
        private CoreDecimal T_TECH_PROF_FEE;
        private CoreDecimal TOT_NBR_SERV;
        private CoreCharacter T_SILENT;
        private CoreCharacter OLD_OMA_CD;
        private CoreDecimal OLD_NBR_SERV;
        private CoreDecimal OLD_FEE_OHIP;
        private CoreDecimal OLD_AMT_TECH_BILLED;
        private CoreCharacter CHANGE_FLAG;
        private CoreCharacter X_SV_DATE;
        private SqlFileObject fleF040_OMA_FEE_MSTR;

        private void fleF040_OMA_FEE_MSTR_Access(ref string AccessClause)
        {


            try
            {
                StringBuilder strText = new StringBuilder("");

                strText.Append(" WHERE ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ").Append(Common.StringToField(QDesign.Substring(fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE"), 1, 1)));
                strText.Append(" AND ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ").Append(Common.StringToField(QDesign.Substring(fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE"), 2, 3)));

                strText.Append(" ORDER BY ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(", ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC"));
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

        private SqlFileObject fleF002_DTL_BEFORE;
        private SqlFileObject fleF002_DTL_AFTER;
        #endregion

        #region "Standard Generated Procedures"

        #region "Grid Field Declarations"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:03 AM

        protected TextBox fldT_SILENT;
        protected TextBox fldF002_DTL_CLMDTL_AMT_TECH_BILLED;
        protected TextBox fldF002_DTL_KEY_CLM_BATCH_NBR;
        protected TextBox fldF002_DTL_KEY_CLM_CLAIM_NBR;
        protected TextBox fldF002_DTL_KEY_CLM_SERV_CODE;
        protected TextBox fldF002_DTL_KEY_CLM_ADJ_NBR;
        protected TextBox fldF002_DTL_CLMDTL_SV_DATE;
        protected TextBox fldF002_DTL_CLMDTL_NBR_SERV;
        protected TextBox fldF002_DTL_CLMDTL_FEE_OMA;
        protected TextBox fldF002_DTL_CLMDTL_FEE_OHIP;
        protected TextBox fldF002_DTL_CLMDTL_LINE_NO;
        protected TextBox fldF002_DTL_CLMDTL_DIAG_CD;
        protected TextBox fldF002_DTL_CLMDTL_SV_DAY_1;
        protected TextBox fldF002_DTL_CLMDTL_SV_NBR_1;
        protected TextBox fldF002_DTL_CLMDTL_SV_DAY_2;
        protected TextBox fldF002_DTL_CLMDTL_SV_NBR_2;
        protected TextBox fldF002_DTL_CLMDTL_SV_DAY_3;
        protected TextBox fldF002_DTL_CLMDTL_SV_NBR_3;

        #endregion

        #region "Grid Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:03 AM

        //#-----------------------------------------
        //# GetGridFieldObject Procedure.
        //#-----------------------------------------

        protected override void GetGridFieldObject(object DataListField, ref object CoreField, string Name)
        {


            try
            {
                switch (Name.ToUpper())
                {
                    case "FLDGRDT_SILENT":
                        fldT_SILENT = (TextBox)DataListField;

                        fldT_SILENT.Edit -= fldT_SILENT_Edit;
                        fldT_SILENT.Edit += fldT_SILENT_Edit;
                        CoreField = fldT_SILENT;
                        fldT_SILENT.Bind(T_SILENT);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_AMT_TECH_BILLED":
                        fldF002_DTL_CLMDTL_AMT_TECH_BILLED = (TextBox)DataListField;
                        CoreField = fldF002_DTL_CLMDTL_AMT_TECH_BILLED;
                        fldF002_DTL_CLMDTL_AMT_TECH_BILLED.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_KEY_CLM_BATCH_NBR":
                        fldF002_DTL_KEY_CLM_BATCH_NBR = (TextBox)DataListField;
                        CoreField = fldF002_DTL_KEY_CLM_BATCH_NBR;
                        fldF002_DTL_KEY_CLM_BATCH_NBR.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_KEY_CLM_CLAIM_NBR":
                        fldF002_DTL_KEY_CLM_CLAIM_NBR = (TextBox)DataListField;
                        CoreField = fldF002_DTL_KEY_CLM_CLAIM_NBR;
                        fldF002_DTL_KEY_CLM_CLAIM_NBR.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_KEY_CLM_SERV_CODE":
                        fldF002_DTL_KEY_CLM_SERV_CODE = (TextBox)DataListField;

                        fldF002_DTL_KEY_CLM_SERV_CODE.LookupOn -= fldF002_DTL_KEY_CLM_SERV_CODE_LookupOn;
                        fldF002_DTL_KEY_CLM_SERV_CODE.LookupOn += fldF002_DTL_KEY_CLM_SERV_CODE_LookupOn;
                        fldF002_DTL_KEY_CLM_SERV_CODE.Process -= fldF002_DTL_KEY_CLM_SERV_CODE_Process;
                        fldF002_DTL_KEY_CLM_SERV_CODE.Process += fldF002_DTL_KEY_CLM_SERV_CODE_Process;
                        CoreField = fldF002_DTL_KEY_CLM_SERV_CODE;
                        fldF002_DTL_KEY_CLM_SERV_CODE.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_KEY_CLM_ADJ_NBR":
                        fldF002_DTL_KEY_CLM_ADJ_NBR = (TextBox)DataListField;
                        CoreField = fldF002_DTL_KEY_CLM_ADJ_NBR;
                        fldF002_DTL_KEY_CLM_ADJ_NBR.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_SV_DATE":
                        fldF002_DTL_CLMDTL_SV_DATE = (TextBox)DataListField;
                        CoreField = fldF002_DTL_CLMDTL_SV_DATE;
                        fldF002_DTL_CLMDTL_SV_DATE.Bind(CLMDTL_SV_DATE);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_NBR_SERV":
                        fldF002_DTL_CLMDTL_NBR_SERV = (TextBox)DataListField;
                        fldF002_DTL_CLMDTL_NBR_SERV.Process -= fldF002_DTL_CLMDTL_NBR_SERV_Process;
                        fldF002_DTL_CLMDTL_NBR_SERV.Process += fldF002_DTL_CLMDTL_NBR_SERV_Process;
                        CoreField = fldF002_DTL_CLMDTL_NBR_SERV;
                        fldF002_DTL_CLMDTL_NBR_SERV.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_FEE_OMA":
                        fldF002_DTL_CLMDTL_FEE_OMA = (TextBox)DataListField;
                        CoreField = fldF002_DTL_CLMDTL_FEE_OMA;
                        fldF002_DTL_CLMDTL_FEE_OMA.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_FEE_OHIP":
                        fldF002_DTL_CLMDTL_FEE_OHIP = (TextBox)DataListField;
                        CoreField = fldF002_DTL_CLMDTL_FEE_OHIP;
                        fldF002_DTL_CLMDTL_FEE_OHIP.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_LINE_NO":
                        fldF002_DTL_CLMDTL_LINE_NO = (TextBox)DataListField;
                        CoreField = fldF002_DTL_CLMDTL_LINE_NO;
                        fldF002_DTL_CLMDTL_LINE_NO.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_DIAG_CD":
                        fldF002_DTL_CLMDTL_DIAG_CD = (TextBox)DataListField;
                        CoreField = fldF002_DTL_CLMDTL_DIAG_CD;
                        fldF002_DTL_CLMDTL_DIAG_CD.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_SV_DAY_1":
                        fldF002_DTL_CLMDTL_SV_DAY_1 = (TextBox)DataListField;
                        CoreField = fldF002_DTL_CLMDTL_SV_DAY_1;
                        fldF002_DTL_CLMDTL_SV_DAY_1.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_SV_NBR_1":
                        fldF002_DTL_CLMDTL_SV_NBR_1 = (TextBox)DataListField;
                        fldF002_DTL_CLMDTL_SV_NBR_1.Process -= fldF002_DTL_CLMDTL_SV_NBR_1_Process;
                        fldF002_DTL_CLMDTL_SV_NBR_1.Process += fldF002_DTL_CLMDTL_SV_NBR_1_Process;
                        CoreField = fldF002_DTL_CLMDTL_SV_NBR_1;
                        fldF002_DTL_CLMDTL_SV_NBR_1.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_SV_DAY_2":
                        fldF002_DTL_CLMDTL_SV_DAY_2 = (TextBox)DataListField;
                        CoreField = fldF002_DTL_CLMDTL_SV_DAY_2;
                        fldF002_DTL_CLMDTL_SV_DAY_2.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_SV_NBR_2":
                        fldF002_DTL_CLMDTL_SV_NBR_2 = (TextBox)DataListField;
                        fldF002_DTL_CLMDTL_SV_NBR_2.Process -= fldF002_DTL_CLMDTL_SV_NBR_2_Process;
                        fldF002_DTL_CLMDTL_SV_NBR_2.Process += fldF002_DTL_CLMDTL_SV_NBR_2_Process;
                        CoreField = fldF002_DTL_CLMDTL_SV_NBR_2;
                        fldF002_DTL_CLMDTL_SV_NBR_2.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_SV_DAY_3":
                        fldF002_DTL_CLMDTL_SV_DAY_3 = (TextBox)DataListField;
                        CoreField = fldF002_DTL_CLMDTL_SV_DAY_3;
                        fldF002_DTL_CLMDTL_SV_DAY_3.Bind(fleF002_DTL);
                        break;
                    case "FLDGRDF002_DTL_CLMDTL_SV_NBR_3":
                        fldF002_DTL_CLMDTL_SV_NBR_3 = (TextBox)DataListField;
                        fldF002_DTL_CLMDTL_SV_NBR_3.Process -= fldF002_DTL_CLMDTL_SV_NBR_3_Process;
                        fldF002_DTL_CLMDTL_SV_NBR_3.Process += fldF002_DTL_CLMDTL_SV_NBR_3_Process;
                        CoreField = fldF002_DTL_CLMDTL_SV_NBR_3;
                        fldF002_DTL_CLMDTL_SV_NBR_3.Bind(fleF002_DTL);
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
                dtlF002_DTL.OccursWithFile = fleF002_DTL;

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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:03 AM

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
            fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
            fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
            fleF002_DTL.Transaction = m_trnTRANS_UPDATE;
            fleF002_DTL_BEFORE.Transaction = m_trnTRANS_UPDATE;
            fleF002_DTL_AFTER.Transaction = m_trnTRANS_UPDATE;


        }



        #endregion

        #region "FILE Management Procedures"

        //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:03 AM

        //#-----------------------------------------
        //# InitializeFiles Procedure.
        //#-----------------------------------------

        protected override void InitializeFiles()
        {

            try
            {
                Initialize_TRANS_UPDATE();
                fleF040_OMA_FEE_MSTR.Connection = m_cnnQUERY;


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
                fleF002_CLAIMS_MSTR.Dispose();
                fleF001_BATCH_CONTROL_FILE.Dispose();
                fleF002_DTL.Dispose();
                fleF040_OMA_FEE_MSTR.Dispose();
                fleF002_DTL_BEFORE.Dispose();
                fleF002_DTL_AFTER.Dispose();


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
        //# Do not delete, modify or move it.  Updated: 5/29/2017 10:18:03 AM



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



        private void fldF002_DTL_KEY_CLM_SERV_CODE_LookupOn()
        {

            try
            {
                StringBuilder strSQL = new StringBuilder(" WHERE ");
                strSQL.Append("     ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ").Append(Common.StringToField(QDesign.Substring(FieldText, 1, 1)));
                strSQL.Append("     ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ").Append(Common.StringToField(QDesign.Substring(FieldText, 2, 3)));

                fleF040_OMA_FEE_MSTR.GetData(strSQL.ToString(), GetDataOptions.IsOptional);
                if (!AccessOk)
                {
                    ErrorMessage("Record not found on lookup table");
                    // Record not found on lookup table.
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



        protected override object SetFieldDefaults(string Name)
        {


            try
            {
                switch (Name)
                {
                    case "F002_DTL_KEY_CLM_ADJ_NBR":
                        return "0";
                    case "F002_DTL_CLMDTL_NBR_SERV":
                        return 1;
                    default:
                        return "";
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
                SaveReceivingParams(fleF002_CLAIMS_MSTR, fleF001_BATCH_CONTROL_FILE);


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
                Receiving(fleF002_CLAIMS_MSTR, fleF001_BATCH_CONTROL_FILE);


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


        private void fldF002_DTL_KEY_CLM_SERV_CODE_Process()
        {

            try
            {

                if (QDesign.NULL(QDesign.Substring(fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE"), 5, 1)) != QDesign.NULL("C"))
                {
                    fleF002_DTL.set_SetValue("CLMDTL_FEE_OMA", fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_A_FEE_1") / 10);
                    fleF002_DTL.set_SetValue("CLMDTL_FEE_OHIP", fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_FEE_1") / 10);
                }
                else
                {
                    fleF002_DTL.set_SetValue("CLMDTL_FEE_OMA", fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_A_FEE_2") / 10);
                    fleF002_DTL.set_SetValue("CLMDTL_FEE_OHIP", fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_FEE_2") / 10);
                }
                Display(ref fldF002_DTL_CLMDTL_FEE_OMA);
                Display(ref fldF002_DTL_CLMDTL_FEE_OHIP);
                CHANGE_FLAG.Value = "Y";


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



        private void fldF002_DTL_CLMDTL_NBR_SERV_Process()
        {

            try
            {

                CHANGE_FLAG.Value = "Y";


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



        private void fldF002_DTL_CLMDTL_SV_NBR_1_Process()
        {

            try
            {

                CHANGE_FLAG.Value = "Y";


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



        private void fldF002_DTL_CLMDTL_SV_NBR_2_Process()
        {

            try
            {

                CHANGE_FLAG.Value = "Y";


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



        private void fldF002_DTL_CLMDTL_SV_NBR_3_Process()
        {

            try
            {

                CHANGE_FLAG.Value = "Y";


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



        private void fldT_SILENT_Edit()
        {

            try
            {

                if (QDesign.NULL(CHANGE_FLAG.Value) == QDesign.NULL("Y"))
                {
                    TOT_NBR_SERV.Value = fleF002_DTL.GetDecimalValue("CLMDTL_NBR_SERV") + CLMDTL_SV_NBR_1.Value + CLMDTL_SV_NBR_2.Value + CLMDTL_SV_NBR_3.Value;
                    if (QDesign.NULL(QDesign.Substring(fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE"), 5, 1)) != QDesign.NULL("C"))
                    {
                        fleF002_DTL.set_SetValue("CLMDTL_FEE_OMA", fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_A_FEE_1") * TOT_NBR_SERV.Value / 10);
                        fleF002_DTL.set_SetValue("CLMDTL_FEE_OHIP", fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_FEE_1") * TOT_NBR_SERV.Value / 10);
                    }
                    else
                    {
                        fleF002_DTL.set_SetValue("CLMDTL_FEE_OMA", fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_A_FEE_2") * TOT_NBR_SERV.Value / 10);
                        fleF002_DTL.set_SetValue("CLMDTL_FEE_OHIP", fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_FEE_2") * TOT_NBR_SERV.Value / 10);
                    }
                    Display(ref fldF002_DTL_CLMDTL_FEE_OMA);
                    Display(ref fldF002_DTL_CLMDTL_FEE_OHIP);
                    if (QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_TECH_IND")) == QDesign.NULL("Y") | QDesign.NULL(QDesign.Substring(fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE"), 5, 1)) == QDesign.NULL("B"))
                    {
                        fleF002_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", fleF002_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
                    }
                    else
                    {
                        if (QDesign.NULL(QDesign.Substring(fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE"), 5, 1)) == QDesign.NULL("C"))
                        {
                            fleF002_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", 0);
                        }
                        else
                        {
                            if (QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("NM") | QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DR") | QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("DU") | QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == QDesign.NULL("PF"))
                            {
                                T_TECH_PROF_FEE.Value = (fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_A_FEE_1") + fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_A_FEE_2")) / 10;
                                if (QDesign.NULL(T_TECH_PROF_FEE.Value) == 0)
                                {
                                    fleF002_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", 0);
                                }
                                else
                                {
                                    fleF002_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", (fleF002_DTL.GetDecimalValue("CLMDTL_FEE_OMA")) * (fleF002_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / T_TECH_PROF_FEE.Value));
                                }
                            }
                            else
                            {
                                fleF002_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", 0);
                            }
                        }
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



        private void dsrDesigner_CORE_DATE_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldF002_DTL_CLMDTL_SV_DATE);


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



        private void dsrDesigner_PRICE_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldF002_DTL_CLMDTL_FEE_OMA);
                Accept(ref fldF002_DTL_CLMDTL_FEE_OHIP);
                CHANGE_FLAG.Value = "Y";


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



        private void dsrDesigner_TECH_Click(object sender, System.EventArgs e)
        {

            try
            {

                Accept(ref fldF002_DTL_CLMDTL_AMT_TECH_BILLED);
                CHANGE_FLAG.Value = "Y";


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

               

                CHANGE_FLAG.Value = "N";
                X_SV_DATE.Value = "20991231";
                if (string.Compare(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS"), "2") >= 0)
                {
                    while (fleF002_DTL.For())
                    {
                        CLMDTL_SV_DATE.Value = Convert.ToDecimal(fleF002_DTL.GetDecimalValue("CLMDTL_SV_YY").ToString().PadLeft(4, '0') + fleF002_DTL.GetDecimalValue("CLMDTL_SV_MM").ToString().PadLeft(2, '0') + fleF002_DTL.GetDecimalValue("CLMDTL_SV_DD").ToString().PadLeft(2, '0'));
                        CLMDTL_SV_NBR_1.Value = Convert.ToDecimal(fleF002_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(0, 1).Trim().PadLeft(1, '0'));
                        CLMDTL_SV_DAY_1.Value = Convert.ToDecimal(fleF002_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(2, 2).Trim().PadLeft(1, '0'));
                        CLMDTL_SV_NBR_2.Value = Convert.ToDecimal(fleF002_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(3, 1).Trim().PadLeft(1, '0'));
                        CLMDTL_SV_DAY_2.Value = Convert.ToDecimal(fleF002_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(4, 2).Trim().PadLeft(1, '0'));
                        CLMDTL_SV_NBR_3.Value = Convert.ToDecimal(fleF002_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(6, 1).Trim().PadLeft(1, '0'));
                        CLMDTL_SV_DAY_3.Value = Convert.ToDecimal(fleF002_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R").Substring(7, 2).Trim().PadLeft(1, '0'));

                        CHANGE_FLAG.Value = "N";
                        OLD_OMA_CD.Value = fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE");
                        OLD_NBR_SERV.Value = fleF002_DTL.GetDecimalValue("CLMDTL_NBR_SERV") + CLMDTL_SV_DAY_1.Value + CLMDTL_SV_DAY_2.Value + CLMDTL_SV_DAY_3.Value;
                        OLD_FEE_OHIP.Value = fleF002_DTL.GetDecimalValue("CLMDTL_FEE_OHIP");
                        OLD_AMT_TECH_BILLED.Value = fleF002_DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED");
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


        protected override bool PreUpdate()
        {


            try
            {

                while (fleF002_DTL.For())
                {
                    //Parent:CLMDTL_SV_DATE
                    if (string.Compare(QDesign.NULL(QDesign.ASCII(fleF002_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2)), QDesign.NULL(X_SV_DATE.Value)) < 0)
                    {
                        X_SV_DATE.Value = QDesign.ASCII(fleF002_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2);
                        //Parent:CLMDTL_SV_DATE
                    }
                }
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_SERV_DATE", QDesign.NConvert(X_SV_DATE.Value));
                if (string.Compare(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS"), "2") >= 0)
                {
                    while (fleF002_DTL.For())
                    {
                        if (QDesign.NULL(CHANGE_FLAG.Value) == QDesign.NULL("Y"))
                        {
                            fleF002_DTL_BEFORE.set_SetValue("BATCTRL_BATCH_STATUS", fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS"));
                            fleF002_DTL_BEFORE.set_SetValue("BATCTRL_BATCH_TYPE", fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE"));
                            fleF002_DTL_BEFORE.set_SetValue("BATCTRL_ADJ_CD", fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_CLINIC_NBR_1_2", QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), 1, 2)));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_BATCH_NBR", fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_CLAIM_NBR", fleF002_CLAIMS_MSTR.GetDecimalValue("KEY_CLM_CLAIM_NBR"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_DOC_NBR", QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), 3, 3));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_DOC_DEPT", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_LOC", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_LOC"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_AGENT_CD", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_AMT_TECH_PAID", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AMT_TECH_PAID"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_I_O_PAT_IND", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_I_O_PAT_IND"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_ADJ_CD_SUB_TYPE", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_ADJ_CD", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_CD"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMHDR_PAYROLL", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_HOSP"));
                            fleF002_DTL_BEFORE.set_SetValue("CLMDTL_OMA_CD", QDesign.Substring(OLD_OMA_CD.Value, 1, 4));
                            fleF002_DTL_BEFORE.set_SetValue("CLMDTL_OMA_SUFF", QDesign.Substring(OLD_OMA_CD.Value, 5, 1));
                            fleF002_DTL_BEFORE.set_SetValue("CLMDTL_FEE_OHIP", OLD_FEE_OHIP.Value);
                            fleF002_DTL_BEFORE.set_SetValue("CLMDTL_NBR_SERV", OLD_NBR_SERV.Value);
                            fleF002_DTL_BEFORE.set_SetValue("CLMDTL_AMT_TECH_BILLED", OLD_AMT_TECH_BILLED.Value);
                            fleF002_DTL_BEFORE.set_SetValue("CLMDTL_DATE_PERIOD_END", fleF002_DTL.GetStringValue("CLMDTL_DATE_PERIOD_END"));
                            fleF002_DTL_BEFORE.PutData();
                            fleF002_DTL_AFTER.set_SetValue("BATCTRL_BATCH_STATUS", fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS"));
                            fleF002_DTL_AFTER.set_SetValue("BATCTRL_BATCH_TYPE", fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE"));
                            fleF002_DTL_AFTER.set_SetValue("BATCTRL_ADJ_CD", fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_CLINIC_NBR_1_2", QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), 1, 2)));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_BATCH_NBR", fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_CLAIM_NBR", fleF002_CLAIMS_MSTR.GetDecimalValue("KEY_CLM_CLAIM_NBR"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_DOC_NBR", QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), 3, 3));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_DOC_DEPT", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_LOC", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_LOC"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_AGENT_CD", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_AMT_TECH_PAID", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AMT_TECH_PAID"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_I_O_PAT_IND", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_I_O_PAT_IND"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_ADJ_CD_SUB_TYPE", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_ADJ_CD", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_CD"));
                            fleF002_DTL_AFTER.set_SetValue("CLMHDR_PAYROLL", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_HOSP"));
                            fleF002_DTL_AFTER.set_SetValue("CLMDTL_OMA_CD", QDesign.Substring(fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE"), 1, 4));
                            fleF002_DTL_AFTER.set_SetValue("CLMDTL_OMA_SUFF", QDesign.Substring(fleF002_DTL.GetStringValue("KEY_CLM_SERV_CODE"), 5, 1));
                            fleF002_DTL_AFTER.set_SetValue("CLMDTL_FEE_OHIP", fleF002_DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));
                            fleF002_DTL_AFTER.set_SetValue("CLMDTL_NBR_SERV", TOT_NBR_SERV.Value);
                            fleF002_DTL_AFTER.set_SetValue("CLMDTL_AMT_TECH_BILLED", fleF002_DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));
                            fleF002_DTL_AFTER.set_SetValue("CLMDTL_DATE_PERIOD_END", fleF002_DTL.GetStringValue("CLMDTL_DATE_PERIOD_END"));
                            fleF002_DTL_AFTER.PutData();
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
                while (fleF002_DTL.ForMissing())
                {
                    m_strWhere = new StringBuilder(GetWhereCondition(fleF002_DTL.ElementOwner("KEY_CLM_TYPE"), "B", ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF002_DTL.ElementOwner("KEY_CLM_BATCH_NBR"), fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR"), ref blnAddWhere));
                    m_strWhere.Append(GetWhereCondition(fleF002_DTL.ElementOwner("KEY_CLM_CLAIM_NBR"), fleF002_CLAIMS_MSTR.GetDecimalValue("KEY_CLM_CLAIM_NBR"), ref blnAddWhere));
                    fleF002_DTL.GetData(m_strWhere.ToString(), GetDataOptions.CreateSubSelect);
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
                Page.PageTitle = "Detail record";



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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:18:03 AM
        //#-----------------------------------------
        protected override bool Append()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:18:03 AM
                Edit(ref fldT_SILENT);
                Display(ref fldF002_DTL_KEY_CLM_BATCH_NBR);
                Display(ref fldF002_DTL_KEY_CLM_CLAIM_NBR);
                Accept(ref fldF002_DTL_KEY_CLM_SERV_CODE);
                Accept(ref fldF002_DTL_KEY_CLM_ADJ_NBR);
                Accept(ref fldF002_DTL_CLMDTL_SV_DATE);
                Accept(ref fldF002_DTL_CLMDTL_NBR_SERV);
                Display(ref fldF002_DTL_CLMDTL_FEE_OMA);
                Display(ref fldF002_DTL_CLMDTL_FEE_OHIP);
                Accept(ref fldF002_DTL_CLMDTL_LINE_NO);
                Accept(ref fldF002_DTL_CLMDTL_DIAG_CD);
                Accept(ref fldF002_DTL_CLMDTL_SV_DAY_1);
                Accept(ref fldF002_DTL_CLMDTL_SV_NBR_1);
                Accept(ref fldF002_DTL_CLMDTL_SV_DAY_2);
                Accept(ref fldF002_DTL_CLMDTL_SV_NBR_2);
                Accept(ref fldF002_DTL_CLMDTL_SV_DAY_3);
                Accept(ref fldF002_DTL_CLMDTL_SV_NBR_3);
                Accept(ref fldF002_DTL_CLMDTL_AMT_TECH_BILLED);
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:18:03 AM
        //#-----------------------------------------
        protected override bool Update()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:18:03 AM
                fleF002_CLAIMS_MSTR.PutData();
                fleF001_BATCH_CONTROL_FILE.PutData();
                while (fleF002_DTL.For())
                {
                    fleF002_DTL.PutData(false, PutTypes.Deleted);
                }
                while (fleF002_DTL.For())
                {
                    fleF002_DTL.PutData();
                }
                fleF001_BATCH_CONTROL_FILE.PutData();
                fleF002_CLAIMS_MSTR.PutData();
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:18:03 AM
        //#-----------------------------------------
        protected override bool Delete()
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:18:03 AM
                fleF002_DTL.DeletedRecord = true;
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
        //# dtlF002_DTL_EditClick Procedure
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:18:03 AM
        //#-----------------------------------------
        private void dtlF002_DTL_EditClick(DataList source, GridButtonEventArgs GridButtonEventArgs)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:18:03 AM
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
        //# Precompiler Ver.: 1.0.6353.18277  Generated on: 5/29/2017 10:18:03 AM
        //#-----------------------------------------
        private void dsrDesigner_01_Click(object sender, System.EventArgs e)
        {
            try
            {
                //#BEGIN STANDARD PROCEDURE CONTENT
                //# Precompiler Ver.: 1.0.6353.18277 Generated on: 5/29/2017 10:18:03 AM
                Edit(ref fldT_SILENT);
                Display(ref fldF002_DTL_KEY_CLM_BATCH_NBR);
                Display(ref fldF002_DTL_KEY_CLM_CLAIM_NBR);
                Accept(ref fldF002_DTL_KEY_CLM_SERV_CODE);
                Accept(ref fldF002_DTL_KEY_CLM_ADJ_NBR);
                Accept(ref fldF002_DTL_CLMDTL_SV_DATE);
                Accept(ref fldF002_DTL_CLMDTL_NBR_SERV);
                Display(ref fldF002_DTL_CLMDTL_FEE_OMA);
                Display(ref fldF002_DTL_CLMDTL_FEE_OHIP);
                Accept(ref fldF002_DTL_CLMDTL_LINE_NO);
                Accept(ref fldF002_DTL_CLMDTL_DIAG_CD);
                Accept(ref fldF002_DTL_CLMDTL_SV_DAY_1);
                Accept(ref fldF002_DTL_CLMDTL_SV_NBR_1);
                Accept(ref fldF002_DTL_CLMDTL_SV_DAY_2);
                Accept(ref fldF002_DTL_CLMDTL_SV_NBR_2);
                Accept(ref fldF002_DTL_CLMDTL_SV_DAY_3);
                Accept(ref fldF002_DTL_CLMDTL_SV_NBR_3);
                Accept(ref fldF002_DTL_CLMDTL_AMT_TECH_BILLED);
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

