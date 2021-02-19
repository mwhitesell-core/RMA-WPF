
#region "Screen Comments"

// Program: costing5.qts
// Purpose: - creates files for costing the MANUAL REJECTION Charges
// (RAT rejections processed in costing2.qts)
// DATE       BY WHOM      DESCRIPTION
// 99/03/28   YASEMIN      ORIGINAL
// 02/07/30   M.C. - increase the record count for manual rejection by patient by ohip-err-code
// 03/dec/17  A.A. - alpha doctor nbr
// 04/may/10  M.C. - access f087-submitted-rejected-claims-hdr instead
// - change sort statement
// 04/jul/29  b.e. - changed selection criteria to select only SERVICE 
// and ELIGIBILTY errors that are marked as chargeable
// Made the selection consistent with costing6
// 2015/Jul/16 MC1        - change from select  on  ped  to select on edt-process-date
// as ped = clmhdr-date-period-end of the claim, edt-process-date = date stamp from the incoming
// file from MOH,  claims can be resubmitted and returned with different edt-process-date.
// costing is selected for the current  fiscal period  range
// 2016/Nov/28 MC2 - use set lock record update
// MC2
// set lock file update


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;



public class COSTING5 : BaseClassControl
{

    private COSTING5 m_COSTING5;

    public COSTING5(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_FISCAL_START_YYMMDD = new CoreDecimal("W_CURRENT_FISCAL_START_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_FISCAL_END_YYMMDD = new CoreDecimal("W_CURRENT_FISCAL_END_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_CUTOFF_YYMMDD = new CoreDecimal("W_CURRENT_COSTING_CUTOFF_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED = new CoreDecimal("W_CURRENT_COSTING_PED", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED_YYMM = new CoreDecimal("W_CURRENT_COSTING_PED_YYMM", 6, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_START_YYMMDD = new CoreDecimal("W_PREVIOUS_FISCAL_START_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_END_YYMMDD = new CoreDecimal("W_PREVIOUS_FISCAL_END_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_EP_YR = new CoreDecimal("W_EP_YR", 2, this, ResetTypes.ResetAtStartup);


    }

    public COSTING5(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_FISCAL_START_YYMMDD = new CoreDecimal("W_CURRENT_FISCAL_START_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_FISCAL_END_YYMMDD = new CoreDecimal("W_CURRENT_FISCAL_END_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_CUTOFF_YYMMDD = new CoreDecimal("W_CURRENT_COSTING_CUTOFF_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED = new CoreDecimal("W_CURRENT_COSTING_PED", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED_YYMM = new CoreDecimal("W_CURRENT_COSTING_PED_YYMM", 6, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_START_YYMMDD = new CoreDecimal("W_PREVIOUS_FISCAL_START_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_END_YYMMDD = new CoreDecimal("W_PREVIOUS_FISCAL_END_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_EP_YR = new CoreDecimal("W_EP_YR", 2, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_COSTING5 != null))
        {
            m_COSTING5.CloseTransactionObjects();
            m_COSTING5 = null;
        }
    }

    public COSTING5 GetCOSTING5(int Level)
    {
        if (m_COSTING5 == null)
        {
            m_COSTING5 = new COSTING5("COSTING5", Level);
        }
        else
        {
            m_COSTING5.ResetValues();
        }
        return m_COSTING5;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_FISCAL_START_YYMMDD;
    protected CoreDecimal W_CURRENT_FISCAL_END_YYMMDD;
    protected CoreDecimal W_CURRENT_COSTING_CUTOFF_YYMMDD;
    protected CoreDecimal W_CURRENT_COSTING_PED;
    protected CoreDecimal W_CURRENT_COSTING_PED_YYMM;
    protected CoreDecimal W_PREVIOUS_FISCAL_START_YYMMDD;
    protected CoreDecimal W_PREVIOUS_FISCAL_END_YYMMDD;

    protected CoreDecimal W_EP_YR;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

//            COSTING5_COSTING1_GET_REC_7_1 COSTING1_GET_REC_7_1 = new COSTING5_COSTING1_GET_REC_7_1(Name, Level);
//            COSTING1_GET_REC_7_1.Run();
//            COSTING1_GET_REC_7_1.Dispose();
//            COSTING1_GET_REC_7_1 = null;

            COSTING5_1_2 C1_2 = new COSTING5_1_2(Name, Level);
            C1_2.Run();
            C1_2.Dispose();
            C1_2 = null;

            return true;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;


        }
        catch (Exception ex)
        {
            WriteError(ex);
            return false;

        }

    }







    #endregion

    #endregion

}



public class COSTING5_COSTING1_GET_REC_7_1 : COSTING5
{

    public COSTING5_COSTING1_GET_REC_7_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_FISCAL_START_YYMMDD = new CoreDecimal("W_CURRENT_FISCAL_START_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_FISCAL_END_YYMMDD = new CoreDecimal("W_CURRENT_FISCAL_END_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_CUTOFF_YYMMDD = new CoreDecimal("W_CURRENT_COSTING_CUTOFF_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED = new CoreDecimal("W_CURRENT_COSTING_PED", 8, this, ResetTypes.ResetAtStartup);
        W_CURRENT_COSTING_PED_YYMM = new CoreDecimal("W_CURRENT_COSTING_PED_YYMM", 6, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_START_YYMMDD = new CoreDecimal("W_PREVIOUS_FISCAL_START_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_PREVIOUS_FISCAL_END_YYMMDD = new CoreDecimal("W_PREVIOUS_FISCAL_END_YYMMDD", 8, this, ResetTypes.ResetAtStartup);
        W_EP_YR = new CoreDecimal("W_EP_YR", 2, this, ResetTypes.ResetAtStartup);
        fleCONSTANTS_MSTR_REC_7 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_7", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(COSTING5_COSTING1_GET_REC_7_1)"

    protected CoreDecimal W_CURRENT_FISCAL_START_YYMMDD;
    protected CoreDecimal W_CURRENT_FISCAL_END_YYMMDD;
    protected CoreDecimal W_CURRENT_COSTING_CUTOFF_YYMMDD;
    protected CoreDecimal W_CURRENT_COSTING_PED;
    protected CoreDecimal W_CURRENT_COSTING_PED_YYMM;
    protected CoreDecimal W_PREVIOUS_FISCAL_START_YYMMDD;
    protected CoreDecimal W_PREVIOUS_FISCAL_END_YYMMDD;
    protected CoreDecimal W_EP_YR;
    private SqlFileObject fleCONSTANTS_MSTR_REC_7;


    #endregion


    #region "Standard Generated Procedures(COSTING5_COSTING1_GET_REC_7_1)"


    #region "Automatic Item Initialization(COSTING5_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(COSTING5_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:06 PM

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
        fleCONSTANTS_MSTR_REC_7.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(COSTING5_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:06 PM

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
            fleCONSTANTS_MSTR_REC_7.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING5_COSTING1_GET_REC_7_1)"


    public void Run()
    {

        try
        {
            Request("COSTING1_GET_REC_7_1");

            while (fleCONSTANTS_MSTR_REC_7.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_7 <--

                fleCONSTANTS_MSTR_REC_7.GetData();
                // --> End GET CONSTANTS_MSTR_REC_7 <--

                if (Transaction())
                {
                    W_CURRENT_FISCAL_START_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetDecimalValue("CURRENT_FISCAL_START_YYMMDD");
                    W_CURRENT_FISCAL_END_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetDecimalValue("CURRENT_FISCAL_END_YYMMDD");
                    W_CURRENT_COSTING_CUTOFF_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetDecimalValue("CURRENT_COSTING_CUTOFF_YYMMDD");
                    W_CURRENT_COSTING_PED.Value = fleCONSTANTS_MSTR_REC_7.GetDecimalValue("CURRENT_COSTING_PED");
                    W_CURRENT_COSTING_PED_YYMM.Value = (int)fleCONSTANTS_MSTR_REC_7.GetDecimalValue("CURRENT_COSTING_PED") / 100;
                    W_PREVIOUS_FISCAL_START_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetDecimalValue("PREVIOUS_FISCAL_START_YYMMDD");
                    W_PREVIOUS_FISCAL_END_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetDecimalValue("PREVIOUS_FISCAL_END_YYMMDD");
                    W_EP_YR.Value = fleCONSTANTS_MSTR_REC_7.GetDecimalValue("EP_YR");

                }

            }



        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);


        }
        finally
        {
            EndRequest("COSTING1_GET_REC_7_1");

        }

    }







    #endregion


}
//COSTING1_GET_REC_7_1



public class COSTING5_1_2 : COSTING5
{

    public COSTING5_1_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        //fleF087SUBMITTEDREJECTEDCLAIMSHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        //fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        //fleF020C_DOC_CLINIC_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        //fleF093_OHIP_ERROR_MSG_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F093_OHIP_ERROR_MSG_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        //fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        //MAN_REJECT = new CoreDecimal("MAN_REJECT", 6, this);
        //fleCOSTING2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        //PED_YYMM.GetValue += PED_YYMM_GetValue;
        //DOC_START_YYMM.GetValue += DOC_START_YYMM_GetValue;
        //NBR_SVC.GetValue += NBR_SVC_GetValue;
        //NBR_CLM.GetValue += NBR_CLM_GetValue;
        //NBR_DTL.GetValue += NBR_DTL_GetValue;
        //NBR_REJECT.GetValue += NBR_REJECT_GetValue;
        //AMT_YTD.GetValue += AMT_YTD_GetValue;
        //MISC_AMT_YTD.GetValue += MISC_AMT_YTD_GetValue;
        //MOHR_AMT_YTD.GetValue += MOHR_AMT_YTD_GetValue;
        //TOTAL_AMT_YTD.GetValue += TOTAL_AMT_YTD_GetValue;
        //DOC_INITS.GetValue += DOC_INITS_GetValue;
        //CLMHDR_PAT_OHIP_ID_OR_CHART.GetValue += CLMHDR_PAT_OHIP_ID_OR_CHART_GetValue;

        //fleF093_OHIP_ERROR_MSG_MSTR.InitializeItems += fleF093_OHIP_ERROR_MSG_MSTR_AutomaticItemInitialization;
        //fleF020_DOCTOR_MSTR.SelectIf += fleF020_DOCTOR_MSTR_SelectIf;
    }

    #region "Declarations (Variables, Files and Transactions)(COSTING5_1_2)"

    private SqlFileObject fleF087SUBMITTEDREJECTEDCLAIMSHDR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private void fleF020_DOCTOR_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append("(").Append("CONVERT(int, (REPLICATE('0', 4 - LEN(DOC_DATE_FAC_START_YY)) + CONVERT(varchar(4), DOC_DATE_FAC_START_YY)) + ");
            strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_START_MM)) + CONVERT(varchar(2), DOC_DATE_FAC_START_MM)) + ");
            strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_START_DD)) + CONVERT(varchar(2), DOC_DATE_FAC_START_DD))) = 0 OR ");
            strSQL.Append("CONVERT(int, (REPLICATE('0', 4 - LEN(DOC_DATE_FAC_START_YY)) + CONVERT(varchar(4), DOC_DATE_FAC_START_YY)) + ");
            strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_START_MM)) + CONVERT(varchar(2), DOC_DATE_FAC_START_MM))) <= ").Append(W_CURRENT_COSTING_PED_YYMM.Value).Append(") AND ");
            strSQL.Append("(").Append("CONVERT(int, (REPLICATE('0', 4 - LEN(DOC_DATE_FAC_TERM_YY)) + CONVERT(varchar(4), DOC_DATE_FAC_TERM_YY)) + ");
            strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_TERM_MM)) + CONVERT(varchar(2), DOC_DATE_FAC_TERM_MM)) + ");
            strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_TERM_DD)) + CONVERT(varchar(2), DOC_DATE_FAC_TERM_DD))) = 0 OR ");
            strSQL.Append("CONVERT(int, (REPLICATE('0', 4 - LEN(DOC_DATE_FAC_TERM_YY)) + CONVERT(varchar(4), DOC_DATE_FAC_TERM_YY)) + ");
            strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_TERM_MM)) + CONVERT(varchar(2), DOC_DATE_FAC_TERM_MM)) + ");
            strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_TERM_DD)) + CONVERT(varchar(2), DOC_DATE_FAC_TERM_DD))) >= ").Append(W_CURRENT_FISCAL_START_YYMMDD.Value).Append(")");

            SelectIfClause = strSQL.ToString();
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }

        catch (Exception ex)
        {
            WriteError(ex);
        }
    }


    private SqlFileObject fleF020C_DOC_CLINIC_NEXT_BATCH_NBR;
    private SqlFileObject fleF093_OHIP_ERROR_MSG_MSTR;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private DDecimal PED_YYMM = new DDecimal("PED_YYMM", 6);
    private void PED_YYMM_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetNumericDateValue("EDT_PROCESS_DATE") / 100;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }

    public override bool SelectIf()
    {


        try
        {
            if ((fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("EDT_PROCESS_DATE") >= W_CURRENT_FISCAL_START_YYMMDD.Value & PED_YYMM.Value <= W_CURRENT_COSTING_PED_YYMM.Value) & (QDesign.NULL(fleF093_OHIP_ERROR_MSG_MSTR.GetStringValue("OHIP_ERR_CAT_CODE")) == "S" | QDesign.NULL(fleF093_OHIP_ERROR_MSG_MSTR.GetStringValue("OHIP_ERR_CAT_CODE")) == "E") & (QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("CHARGE_STATUS")) == "Y"))
            {
                return true;
            }

            return false;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);
            return false;


        }
        catch (Exception ex)
        {
            WriteError(ex);
            return false;

        }

    }

    private DDecimal DOC_START_YYMM = new DDecimal("DOC_START_YYMM", 6);
    private void DOC_START_YYMM_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"), 4) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"), 2) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"), 2)) / 100;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal NBR_SVC = new DDecimal("NBR_SVC", 6);
    private void NBR_SVC_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal NBR_CLM = new DDecimal("NBR_CLM", 6);
    private void NBR_CLM_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal NBR_DTL = new DDecimal("NBR_DTL", 6);
    private void NBR_DTL_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal NBR_REJECT = new DDecimal("NBR_REJECT", 4);
    private void NBR_REJECT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal AMT_YTD = new DDecimal("AMT_YTD", 8);
    private void AMT_YTD_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal MISC_AMT_YTD = new DDecimal("MISC_AMT_YTD", 8);
    private void MISC_AMT_YTD_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal MOHR_AMT_YTD = new DDecimal("MOHR_AMT_YTD", 8);
    private void MOHR_AMT_YTD_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }
    private DDecimal TOTAL_AMT_YTD = new DDecimal("TOTAL_AMT_YTD", 8);
    private void TOTAL_AMT_YTD_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);

        }



    }

    private CoreDecimal MAN_REJECT;



    private SqlFileObject fleCOSTING2;

    private DCharacter DOC_INITS = new DCharacter("DOC_INITS", 3);
    private void DOC_INITS_GetValue(ref string Value)
    {
        try
        {
            Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3");
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }

        catch (Exception ex)
        {
            WriteError(ex);
        }
    }

    private DCharacter CLMHDR_PAT_OHIP_ID_OR_CHART = new DCharacter("CLMHDR_PAT_OHIP_ID_OR_CHART", 16);
    private void CLMHDR_PAT_OHIP_ID_OR_CHART_GetValue(ref string Value)
    {
        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATE");
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }

        catch (Exception ex)
        {
            WriteError(ex);
        }
    }

    #endregion


    #region "Standard Generated Procedures(COSTING5_1_2)"


    #region "Automatic Item Initialization(COSTING5_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:08 PM

    //#-----------------------------------------
    //# fleF093_OHIP_ERROR_MSG_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:06 PM
    //#-----------------------------------------
    private void fleF093_OHIP_ERROR_MSG_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF093_OHIP_ERROR_MSG_MSTR.set_SetValue("OHIP_ERR_CODE", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("OHIP_ERR_CODE"));
            fleF093_OHIP_ERROR_MSG_MSTR.set_SetValue("ENTRY_DATE", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("ENTRY_DATE"));
            fleF093_OHIP_ERROR_MSG_MSTR.set_SetValue("ENTRY_USER_ID", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("ENTRY_USER_ID"));
            fleF093_OHIP_ERROR_MSG_MSTR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("LAST_MOD_DATE"));
            fleF093_OHIP_ERROR_MSG_MSTR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("LAST_MOD_TIME"));
            fleF093_OHIP_ERROR_MSG_MSTR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("LAST_MOD_USER_ID"));

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


    #region "Transaction Management Procedures(COSTING5_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:06 PM

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
        //fleF087SUBMITTEDREJECTEDCLAIMSHDR.Transaction = m_trnTRANS_UPDATE;
        //fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        //fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
        //fleF093_OHIP_ERROR_MSG_MSTR.Transaction = m_trnTRANS_UPDATE;
        //fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        //fleCOSTING2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(COSTING5_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:06 PM

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
            //fleF087SUBMITTEDREJECTEDCLAIMSHDR.Dispose();
            //fleF020_DOCTOR_MSTR.Dispose();
            //fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Dispose();
            //fleF093_OHIP_ERROR_MSG_MSTR.Dispose();
            //fleF002_CLAIMS_MSTR.Dispose();
            //fleCOSTING2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING5_1_2)"


    public void Run()
    {
        Int64 COSTING2_COUNT = 0;

        try
        {
            Request("1_2");

            using (SqlConnection conn = new SqlConnection(Common.GetSqlConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("INDEXED.sp_COSTING5", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@outCOSTING2_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.CommandTimeout = 0;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    COSTING2_COUNT = (Int64)cmd.Parameters["@outCOSTING2_COUNT"].Value;

                    //Write output to log file
                    if (File.Exists(Directory.GetCurrentDirectory() + "\\COSTING5.log"))
                    {
                        File.Delete(Directory.GetCurrentDirectory() + "\\COSTING5.log");
                    }

                    StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\COSTING5.log", true, System.Text.Encoding.Default);
                    sw.WriteLine("Request COSTING5_1" + Environment.NewLine);
                    sw.WriteLine("                         Added     Updated     Unchanged     Deleted");
                    sw.WriteLine("  COSTING2" + " ".PadLeft(20 - COSTING2_COUNT.ToString().Trim().Length, ' ') + COSTING2_COUNT.ToString().Trim() + " ".PadLeft(11, ' ') + "0" + " ".PadLeft(13, ' ') + "0" + " ".PadLeft(11, ' ') + "0" + Environment.NewLine + Environment.NewLine);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }

            //while (fleF087SUBMITTEDREJECTEDCLAIMSHDR.QTPForMissing())
            //{
            //    // --> GET F087SUBMITTEDREJECTEDCLAIMSHDR <--

            //    fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetData();
            //    // --> End GET F087SUBMITTEDREJECTEDCLAIMSHDR <--

            //    while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
            //    {
            //        // --> GET F020_DOCTOR_MSTR <--
            //        m_strWhere = new StringBuilder(" WHERE ");
            //        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
            //        m_strWhere.Append(Common.StringToField(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("CLMHDR_DOC_NBR")));

            //        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
            //        // --> End GET F020_DOCTOR_MSTR <--

            //        while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.QTPForMissing("2"))
            //        {
            //            m_strWhere = new StringBuilder(" WHERE ");
            //            m_strWhere.Append(" ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ");
            //            m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
            //            m_strWhere.Append(" AND ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("SEQ_NO")).Append(" = 1");

            //            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetData(m_strWhere.ToString());

            //            while (fleF093_OHIP_ERROR_MSG_MSTR.QTPForMissing("3"))
            //            {
            //                // --> GET F093_OHIP_ERROR_MSG_MSTR <--
            //                m_strWhere = new StringBuilder(" WHERE ");
            //                m_strWhere.Append(" ").Append(fleF093_OHIP_ERROR_MSG_MSTR.ElementOwner("OHIP_ERR_CODE")).Append(" = ");
            //                m_strWhere.Append(Common.StringToField(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("OHIP_ERR_CODE")));

            //                fleF093_OHIP_ERROR_MSG_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
            //                // --> End GET F093_OHIP_ERROR_MSG_MSTR <--

            //                while (fleF002_CLAIMS_MSTR.QTPForMissing("4"))
            //                {
            //                    // --> GET F002_CLAIMS_MSTR <--
            //                    m_strWhere = new StringBuilder(" WHERE ");
            //                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            //                    m_strWhere.Append(Common.StringToField("B"));
            //                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
            //                    m_strWhere.Append(Common.StringToField(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("CLMHDR_BATCH_NBR")));
            //                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
            //                    m_strWhere.Append((fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("CLMHDR_CLAIM_NBR")));
            //                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            //                    m_strWhere.Append(Common.StringToField("00000"));
            //                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
            //                    m_strWhere.Append(Common.StringToField("0"));

            //                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
            //                    // --> End GET F002_CLAIMS_MSTR <--


            //                    if (Transaction())
            //                    {

            //                        if (Select_If())
            //                        {

            //                            Sort(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetSortValue("CLMHDR_DOC_NBR"), fleF093_OHIP_ERROR_MSG_MSTR.GetSortValue("OHIP_ERR_CAT_CODE"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_PAT_KEY_TYPE"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_PAT_KEY_DATA"), fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetSortValue("OHIP_ERR_CODE"));
            //                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART



            //                        }

            //                    }

            //                }

            //            }

            //        }
            //    }
            //}

            //while (Sort(fleF087SUBMITTEDREJECTEDCLAIMSHDR, fleF020_DOCTOR_MSTR, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR, fleF093_OHIP_ERROR_MSG_MSTR, fleF002_CLAIMS_MSTR))
            //{
            //    if (fleF087SUBMITTEDREJECTEDCLAIMSHDR.At("CLMHDR_DOC_NBR") || fleF093_OHIP_ERROR_MSG_MSTR.At("OHIP_ERR_CAT_CODE") || At(CLMHDR_PAT_OHIP_ID_OR_CHART) || fleF087SUBMITTEDREJECTEDCLAIMSHDR.At("OHIP_ERR_CODE"))
            //    {
            //        MAN_REJECT.Value = MAN_REJECT.Value + 1;
            //    }


            //    SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING2, fleF087SUBMITTEDREJECTEDCLAIMSHDR.At("CLMHDR_DOC_NBR"), SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_NBR", "DOC_NAME", DOC_INITS, "DOC_DEPT", fleF020C_DOC_CLINIC_NEXT_BATCH_NBR, "DOC_CLINIC_NBR",
            //    NBR_SVC, NBR_CLM, NBR_DTL, NBR_REJECT, AMT_YTD, MISC_AMT_YTD, MOHR_AMT_YTD, TOTAL_AMT_YTD, MAN_REJECT);



            //    Reset(ref MAN_REJECT, fleF087SUBMITTEDREJECTEDCLAIMSHDR.At("CLMHDR_DOC_NBR"));

            //}



        }
        catch (CustomApplicationException ex)
        {
            WriteError(ex);


        }
        catch (Exception ex)
        {
            WriteError(ex);


        }
        finally
        {
            EndRequest("1_2");

        }

    }




    #endregion
}
//1_2




