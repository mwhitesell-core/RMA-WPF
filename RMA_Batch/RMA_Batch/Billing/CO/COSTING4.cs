
#region "Screen Comments"

// Program: costing4.qts
// Purpose: - get clinic 22 regular/miscellaneous/MOHR revenue from 
// f050 revenue history file for doctors `active` during 
// current costing analysis period
// - if a doctor is a `clinic 22 doctor` then any revenue entered
// into OTHER clinics is RE-ENTERED INTO CLINIC 22. Therefore
// the other clinic revenue MUST BE IGNORED UNLESS IT`S that other
// clinic is an  AFP clinic  (designed with iconst-clinic-card-colour
// =  Y  in constants master) in which case claims entered into these
// clinics must be counted. Those doctors
// who bill ONLY IN NON-22 CLINICS must have their revenue
// picked up from these non-22 clinics. Costing3 has pre-determined
// doctors that bill in clinic 22 and placed their nbrs into the
// file doc-totals-tmp so that this pgm can check this file
// and make the appropriate selection of revenue .
// DATE       BY WHOM      DESCRIPTION
// 99/03/28   YASEMIN      ORIGINAL
// 03/dec/17  A.A.  alpha doctor nbr
// 05/jul/11  b.e.  when ignoring non-22 clinics don`t do is if the clinic
// is designated as an AFP clinic as the 22 doctors may
// bill in these clinics and the revenue is not also
// entered into 22 and thus must counted.
// 12/jan/18  MC1   include the clinic 23 & 24 to be the same as clinic 22
// 12/jun/20  MC2   include the clinic 25 to be the same as clinic 22
// 15/mar/10  MC3   include the clinic 26 to be the same as clinic 22


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



public class COSTING4 : BaseClassControl
{

    private COSTING4 m_COSTING4;

    public COSTING4(string Name, int Level)
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

    public COSTING4(string Name, int Level, bool Request)
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
        if ((m_COSTING4 != null))
        {
            m_COSTING4.CloseTransactionObjects();
            m_COSTING4 = null;
        }
    }

    public COSTING4 GetCOSTING4(int Level)
    {
        if (m_COSTING4 == null)
        {
            m_COSTING4 = new COSTING4("COSTING4", Level);
        }
        else
        {
            m_COSTING4.ResetValues();
        }
        return m_COSTING4;
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

//            COSTING4_COSTING1_GET_REC_7_1 COSTING1_GET_REC_7_1 = new COSTING4_COSTING1_GET_REC_7_1(Name, Level);
//            COSTING1_GET_REC_7_1.Run();
//            COSTING1_GET_REC_7_1.Dispose();
//            COSTING1_GET_REC_7_1 = null;

            COSTING4_1_2 C1_2 = new COSTING4_1_2(Name, Level);
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



public class COSTING4_COSTING1_GET_REC_7_1 : COSTING4
{

    public COSTING4_COSTING1_GET_REC_7_1(string Name, int Level)
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


    #region "Declarations (Variables, Files and Transactions)(COSTING4_COSTING1_GET_REC_7_1)"

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


    #region "Standard Generated Procedures(COSTING4_COSTING1_GET_REC_7_1)"


    #region "Automatic Item Initialization(COSTING4_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(COSTING4_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:09 PM

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


    #region "FILE Management Procedures(COSTING4_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:09 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING4_COSTING1_GET_REC_7_1)"


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



public class COSTING4_1_2 : COSTING4
{

    public COSTING4_1_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        //fleF050_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        //fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        //fleF020C_DOC_CLINIC_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        //fleDOC_TOTALS_TMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "DOC_TOTALS_TMP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        //fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        //AMT_YTD = new CoreDecimal("AMT_YTD", 8, this);
        //MISC_AMT_YTD = new CoreDecimal("MISC_AMT_YTD", 8, this);
        //MOHR_AMT_YTD = new CoreDecimal("MOHR_AMT_YTD", 8, this);
        //fleCOSTING2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        //DOC_START_YYMM.GetValue += DOC_START_YYMM_GetValue;
        //NBR_SVC.GetValue += NBR_SVC_GetValue;
        //NBR_CLM.GetValue += NBR_CLM_GetValue;
        //NBR_DTL.GetValue += NBR_DTL_GetValue;
        //NBR_REJECT.GetValue += NBR_REJECT_GetValue;
        //TOTAL_AMT_YTD.GetValue += TOTAL_AMT_YTD_GetValue;
        //MAN_REJECT.GetValue += MAN_REJECT_GetValue;
        //fleDOC_TOTALS_TMP.InitializeItems += fleDOC_TOTALS_TMP_AutomaticItemInitialization;
        //DOC_NBR.GetValue += DOC_NBR_GetValue;
        //DOC_INITS.GetValue += DOC_INITS_GetValue;
        //fleF020_DOCTOR_MSTR.SelectIf += fleF020_DOCTOR_MSTR_SelectIf;

    }

    #region "Declarations (Variables, Files and Transactions)(COSTING4_1_2)"

    private SqlFileObject fleF050_DOC_REVENUE_MSTR_HISTORY;
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
    private SqlFileObject fleDOC_TOTALS_TMP;
    private SqlFileObject fleICONST_MSTR_REC;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("ICONST_DATE_PERIOD_END")) == QDesign.NULL(W_CURRENT_COSTING_PED.Value) & ((QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) == "22" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) == "23" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) == "24" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) == "25" | QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) == "26") | (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) != "22" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) != "23" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) != "24" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) != "25" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2")) != "26" & (!fleDOC_TOTALS_TMP.Exists() | QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "Y"))))
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
    private CoreDecimal AMT_YTD;
    private CoreDecimal MISC_AMT_YTD;
    private CoreDecimal MOHR_AMT_YTD;
    private DDecimal TOTAL_AMT_YTD = new DDecimal("TOTAL_AMT_YTD", 8);
    private void TOTAL_AMT_YTD_GetValue(ref decimal Value)
    {

        try
        {
            Value = AMT_YTD.Value + MISC_AMT_YTD.Value + MOHR_AMT_YTD.Value;


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
    private DDecimal MAN_REJECT = new DDecimal("MAN_REJECT", 6);
    private void MAN_REJECT_GetValue(ref decimal Value)
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

    private DCharacter DOC_NBR = new DCharacter("DOC_NBR", 3);
    private void DOC_NBR_GetValue(ref string Value)
    {
        try
        {
            Value = fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR");
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



    private SqlFileObject fleCOSTING2;


    #endregion


    #region "Standard Generated Procedures(COSTING4_1_2)"


    #region "Automatic Item Initialization(COSTING4_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:11 PM

    //#-----------------------------------------
    //# fleDOC_TOTALS_TMP_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:09 PM
    //#-----------------------------------------
    private void fleDOC_TOTALS_TMP_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleDOC_TOTALS_TMP.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));

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


    #region "Transaction Management Procedures(COSTING4_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:09 PM

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
        //fleF050_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
        //fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        //fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
        //fleDOC_TOTALS_TMP.Transaction = m_trnTRANS_UPDATE;
        //fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        //fleCOSTING2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(COSTING4_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:09 PM

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
            //fleF050_DOC_REVENUE_MSTR_HISTORY.Dispose();
            //fleF020_DOCTOR_MSTR.Dispose();
            //fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Dispose();
            //fleDOC_TOTALS_TMP.Dispose();
            //fleICONST_MSTR_REC.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING4_1_2)"


    public void Run()
    {
        Int64 COSTING2_COUNT = 0;

        try
        {
            Request("1_2");

            //Write output to log file
            if (File.Exists(Directory.GetCurrentDirectory() + "\\COSTING4.log"))
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\COSTING4.log");
            }

            using (SqlConnection conn = new SqlConnection(Common.GetSqlConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("INDEXED.sp_COSTING4", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@outCOSTING2_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.CommandTimeout = 0;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    COSTING2_COUNT = (Int64)cmd.Parameters["@outCOSTING2_COUNT"].Value;

                    StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\COSTING4.log", true, System.Text.Encoding.Default);
                    sw.WriteLine("Request COSTING4_1" + Environment.NewLine);
                    sw.WriteLine("                         Added     Updated     Unchanged     Deleted");
                    sw.WriteLine("  COSTING2" + " ".PadLeft(20 - COSTING2_COUNT.ToString().Trim().Length, ' ') + COSTING2_COUNT.ToString().Trim() + " ".PadLeft(11, ' ') + "0" + " ".PadLeft(13, ' ') + "0" + " ".PadLeft(11, ' ') + "0" + Environment.NewLine + Environment.NewLine);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }

            //while (fleF050_DOC_REVENUE_MSTR_HISTORY.QTPForMissing())
            //{
            //    // --> GET F050_DOC_REVENUE_MSTR_HISTORY <--

            //    fleF050_DOC_REVENUE_MSTR_HISTORY.GetData();
            //    // --> End GET F050_DOC_REVENUE_MSTR_HISTORY <--

            //    while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
            //    {
            //        // --> GET F020_DOCTOR_MSTR <--
            //        m_strWhere = new StringBuilder(" WHERE ");
            //        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
            //        m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR")));

            //        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
            //        // --> End GET F020_DOCTOR_MSTR <--

            //        while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.QTPForMissing("2"))
            //        {
            //            m_strWhere = new StringBuilder(" WHERE ");
            //            m_strWhere.Append(" ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ");
            //            m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
            //            m_strWhere.Append(" AND ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("SEQ_NO")).Append(" = 1");

            //            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetData(m_strWhere.ToString());

            //            while (fleDOC_TOTALS_TMP.QTPForMissing("3"))
            //            {
            //                // --> GET DOC_TOTALS_TMP <--
            //                m_strWhere = new StringBuilder(" WHERE ");
            //                m_strWhere.Append(" ").Append(fleDOC_TOTALS_TMP.ElementOwner("DOC_NBR")).Append(" = ");
            //                m_strWhere.Append(Common.StringToField(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_DOC_NBR")));

            //                fleDOC_TOTALS_TMP.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
            //                // --> End GET DOC_TOTALS_TMP <--

            //                while (fleICONST_MSTR_REC.QTPForMissing("4"))
            //                {
            //                    // --> GET ICONST_MSTR_REC <--
            //                    m_strWhere = new StringBuilder(" WHERE ");
            //                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
            //                    m_strWhere.Append((QDesign.NConvert(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_CLINIC_1_2"))));

            //                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
            //                    // --> End GET ICONST_MSTR_REC <--


            //                    if (Transaction())
            //                    {

            //                        if (Select_If())
            //                        {

            //                            Sort(fleF050_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREV_CLINIC_1_2"), fleF050_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREV_DEPT"), fleF050_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREV_DOC_NBR"), fleF050_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREV_LOCATION"), fleF050_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREV_OMA_CODE"), fleF050_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREV_OMA_SUFF"));
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}

            //while (Sort(fleF050_DOC_REVENUE_MSTR_HISTORY, fleF020_DOCTOR_MSTR, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR, fleDOC_TOTALS_TMP, fleICONST_MSTR_REC))
            //{
            //    if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION")) != "MISC")
            //    {
            //        AMT_YTD.Value = AMT_YTD.Value + fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_IN_REC") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_OUT_REC");
            //    }
            //    if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) != "MOHR")
            //    {
            //        MISC_AMT_YTD.Value = MISC_AMT_YTD.Value + fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_OUT_REC");
            //    }
            //    if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION")) == "MISC" & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_OMA_CODE")) == "MOHR")
            //    {
            //        MOHR_AMT_YTD.Value = MOHR_AMT_YTD.Value + fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_OUT_REC");
            //    }

            //    SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING2, fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_DOC_NBR") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_LOCATION") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_OMA_CODE") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_OMA_SUFF"), SubFileType.Keep, DOC_NBR, fleF020_DOCTOR_MSTR, "DOC_NAME", DOC_INITS, "DOC_DEPT",
            //    fleF020C_DOC_CLINIC_NEXT_BATCH_NBR, "DOC_CLINIC_NBR", NBR_SVC, NBR_CLM, NBR_DTL, NBR_REJECT, AMT_YTD, MISC_AMT_YTD, MOHR_AMT_YTD, TOTAL_AMT_YTD, MAN_REJECT);

            //    Reset(ref AMT_YTD, fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_DOC_NBR") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_LOCATION") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_OMA_CODE") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_OMA_SUFF"));
            //    Reset(ref MISC_AMT_YTD, fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_DOC_NBR") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_LOCATION") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_OMA_CODE") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_OMA_SUFF"));
            //    Reset(ref MOHR_AMT_YTD, fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_CLINIC_1_2") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_DEPT") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_DOC_NBR") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_LOCATION") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_OMA_CODE") || fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_OMA_SUFF"));

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




