
#region "Screen Comments"

// Program: costing2_noweb.qts
// Purpose: - creates files for costing the RAT REJECTION Charges
// Note that MANUAL rejections are processed in costing3.qts
// DATE     BY WHOM     DESCRIPTION
// 99/mar/28  YASEMIN     ORIGINAL
// 00/feb/03  B.E. - rat error `40` now charged against doctor
// 00/aug/08  B.E. - select now based upon being within current costing period and
// having the `charge flag` field set to  Y es
// **   CHANGE COSTING.COM MACRO AND run this program FOR DOCTORS WHO DOES BOTH
// WEB AND MANUAL BILLING this will report only the manual billing so Leena
// can charge them differently
// 03/dec/19  A.A. - alpha doctor nbr
// 15/Jul/16  MC1         - correct select if with select file if
// - change from select  on  clmhdr-date-period-end to select on ped
// as clmhdr-date-period-end = clmhdr-date-period-end of the claim,
// ped = clmhdr-date-period-end of the current run
// costing is selected for the current  fiscal period  range
// 16/Nov/28  MC2  - use set lock record update
// MC2
// set lock file update


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class COSTING2_NOWEB : BaseClassControl
{

    private COSTING2_NOWEB m_COSTING2_NOWEB;

    public COSTING2_NOWEB(string Name, int Level)
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

    public COSTING2_NOWEB(string Name, int Level, bool Request)
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
        if ((m_COSTING2_NOWEB != null))
        {
            m_COSTING2_NOWEB.CloseTransactionObjects();
            m_COSTING2_NOWEB = null;
        }
    }

    public COSTING2_NOWEB GetCOSTING2_NOWEB(int Level)
    {
        if (m_COSTING2_NOWEB == null)
        {
            m_COSTING2_NOWEB = new COSTING2_NOWEB("COSTING2_NOWEB", Level);
        }
        else
        {
            m_COSTING2_NOWEB.ResetValues();
        }
        return m_COSTING2_NOWEB;
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

            COSTING2_NOWEB_COSTING1_GET_REC_7_1 COSTING1_GET_REC_7_1 = new COSTING2_NOWEB_COSTING1_GET_REC_7_1(Name, Level);
            COSTING1_GET_REC_7_1.Run();
            COSTING1_GET_REC_7_1.Dispose();
            COSTING1_GET_REC_7_1 = null;

            COSTING2_NOWEB_COSTING2_1_2 COSTING2_1_2 = new COSTING2_NOWEB_COSTING2_1_2(Name, Level);
            COSTING2_1_2.Run();
            COSTING2_1_2.Dispose();
            COSTING2_1_2 = null;

            COSTING2_NOWEB_COSTING2_2_3 COSTING2_2_3 = new COSTING2_NOWEB_COSTING2_2_3(Name, Level);
            COSTING2_2_3.Run();
            COSTING2_2_3.Dispose();
            COSTING2_2_3 = null;

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



public class COSTING2_NOWEB_COSTING1_GET_REC_7_1 : COSTING2_NOWEB
{

    public COSTING2_NOWEB_COSTING1_GET_REC_7_1(string Name, int Level)
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
        fleCONSTANTS_MSTR_REC_7 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F090_CONSTANTS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(COSTING2_NOWEB_COSTING1_GET_REC_7_1)"

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


    #region "Standard Generated Procedures(COSTING2_NOWEB_COSTING1_GET_REC_7_1)"


    #region "Automatic Item Initialization(COSTING2_NOWEB_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(COSTING2_NOWEB_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:14 PM

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


    #region "FILE Management Procedures(COSTING2_NOWEB_COSTING1_GET_REC_7_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:14 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING2_NOWEB_COSTING1_GET_REC_7_1)"


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
                    W_CURRENT_FISCAL_START_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_FISCAL_START_YYMMDD");
                    W_CURRENT_FISCAL_END_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_FISCAL_END_YYMMDD");
                    W_CURRENT_COSTING_CUTOFF_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_COSTING_CUTOFF_YYMMDD");
                    W_CURRENT_COSTING_PED.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_COSTING_PED");
                    W_CURRENT_COSTING_PED_YYMM.Value = (int)fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("CURRENT_COSTING_PED") / 100;
                    W_PREVIOUS_FISCAL_START_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("PREVIOUS_FISCAL_START_YYMMDD");
                    W_PREVIOUS_FISCAL_END_YYMMDD.Value = fleCONSTANTS_MSTR_REC_7.GetNumericDateValue("PREVIOUS_FISCAL_END_YYMMDD");
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



public class COSTING2_NOWEB_COSTING2_1_2 : COSTING2_NOWEB
{

    public COSTING2_NOWEB_COSTING2_1_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF088RATREJECTEDCLAIMSHISTHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF096_OHIP_PAY_CODE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F096_OHIP_PAY_CODE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleCOSTING2A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING2A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        DOC_START_YYMM.GetValue += DOC_START_YYMM_GetValue;
        X_CLAIM_ID.GetValue += X_CLAIM_ID_GetValue;

        fleF088RATREJECTEDCLAIMSHISTHDR.SelectIf += fleF088RATREJECTEDCLAIMSHISTHDR_SelectIf;
        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;
        fleF020_DOCTOR_MSTR.SelectIf += fleF020_DOCTOR_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(COSTING2_NOWEB_COSTING2_1_2)"

    private SqlFileObject fleF088RATREJECTEDCLAIMSHISTHDR;

    private void fleF088RATREJECTEDCLAIMSHISTHDR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (  ").Append(GetWhereClauseString(fleF088RATREJECTEDCLAIMSHISTHDR.ElementOwner("PED"), ">=", W_CURRENT_FISCAL_START_YYMMDD.Value)).Append(" AND ");
            strSQL.Append("  ").Append(GetWhereClauseString(fleF088RATREJECTEDCLAIMSHISTHDR.ElementOwner("PED"), "<=", W_CURRENT_COSTING_CUTOFF_YYMMDD.Value)).Append(" AND ");
            strSQL.Append("    ").Append(fleF088RATREJECTEDCLAIMSHISTHDR.ElementOwner("CHARGE_STATUS")).Append(" =  'Y')");


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


    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_ADJ_CD_SUB_TYPE")).Append(" <>  'W' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_ADJ_CD_SUB_TYPE")).Append(" <>  'D' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_ADJ_CD_SUB_TYPE")).Append(" <>  'C')");


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

    private SqlFileObject fleF096_OHIP_PAY_CODE;
    private DDecimal DOC_START_YYMM = new DDecimal("DOC_START_YYMM", 6);
    private void DOC_START_YYMM_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

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
    private DCharacter X_CLAIM_ID = new DCharacter("X_CLAIM_ID", 10);
    private void X_CLAIM_ID_GetValue(ref string Value)
    {

        try
        {
            Value = fleF088RATREJECTEDCLAIMSHISTHDR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF088RATREJECTEDCLAIMSHISTHDR.GetDecimalValue("CLMHDR_CLAIM_NBR"));


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



    private SqlFileObject fleCOSTING2A;


    #endregion


    #region "Standard Generated Procedures(COSTING2_NOWEB_COSTING2_1_2)"


    #region "Automatic Item Initialization(COSTING2_NOWEB_COSTING2_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(COSTING2_NOWEB_COSTING2_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:14 PM

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
        fleF088RATREJECTEDCLAIMSHISTHDR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF096_OHIP_PAY_CODE.Transaction = m_trnTRANS_UPDATE;
        fleCOSTING2A.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(COSTING2_NOWEB_COSTING2_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:14 PM

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
            fleF088RATREJECTEDCLAIMSHISTHDR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF096_OHIP_PAY_CODE.Dispose();
            fleCOSTING2A.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING2_NOWEB_COSTING2_1_2)"


    public void Run()
    {

        try
        {
            Request("COSTING2_1_2");

            while (fleF088RATREJECTEDCLAIMSHISTHDR.QTPForMissing())
            {
                // --> GET F088RATREJECTEDCLAIMSHISTHDR <--

                fleF088RATREJECTEDCLAIMSHISTHDR.GetData();
                // --> End GET F088RATREJECTEDCLAIMSHISTHDR <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF088RATREJECTEDCLAIMSHISTHDR.GetStringValue("CLMHDR_DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF002_CLAIMS_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF088RATREJECTEDCLAIMSHISTHDR.GetStringValue("CLMHDR_BATCH_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((fleF088RATREJECTEDCLAIMSHISTHDR.GetDecimalValue("CLMHDR_CLAIM_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("00000"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("0"));

                        fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F002_CLAIMS_MSTR <--

                        while (fleF096_OHIP_PAY_CODE.QTPForMissing("3"))
                        {
                            // --> GET F096_OHIP_PAY_CODE <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF096_OHIP_PAY_CODE.ElementOwner("RAT_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF088RATREJECTEDCLAIMSHISTHDR.GetStringValue("OHIP_ERR_CODE")));

                            fleF096_OHIP_PAY_CODE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F096_OHIP_PAY_CODE <--


                            if (Transaction())
                            {



                                SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING2A, SubFileType.Keep, fleF088RATREJECTEDCLAIMSHISTHDR, "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED", "CLMHDR_DATE_PERIOD_END", W_CURRENT_FISCAL_START_YYMMDD, W_CURRENT_COSTING_CUTOFF_YYMMDD,
                                fleF020_DOCTOR_MSTR, "DOC_NBR", "DOC_NAME", "DOC_INITS", "DOC_DEPT", "DOC_CLINIC_NBR", X_CLAIM_ID, fleF088RATREJECTEDCLAIMSHISTHDR, "OHIP_ERR_CODE");



                            }

                        }

                    }

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
            EndRequest("COSTING2_1_2");

        }

    }




    #endregion


}
//COSTING2_1_2



public class COSTING2_NOWEB_COSTING2_2_3 : COSTING2_NOWEB
{

    public COSTING2_NOWEB_COSTING2_2_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCOSTING2A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING2A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        NBR_REJECT = new CoreDecimal("NBR_REJECT", 4, this);
        fleCOSTING2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        NBR_SVC.GetValue += NBR_SVC_GetValue;
        NBR_CLM.GetValue += NBR_CLM_GetValue;
        NBR_DTL.GetValue += NBR_DTL_GetValue;
        AMT_YTD.GetValue += AMT_YTD_GetValue;
        MISC_AMT_YTD.GetValue += MISC_AMT_YTD_GetValue;
        MOHR_AMT_YTD.GetValue += MOHR_AMT_YTD_GetValue;
        TOTAL_AMT_YTD.GetValue += TOTAL_AMT_YTD_GetValue;
        MAN_REJECT.GetValue += MAN_REJECT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(COSTING2_NOWEB_COSTING2_2_3)"

    private SqlFileObject fleCOSTING2A;
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
    private CoreDecimal NBR_REJECT;
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



    private SqlFileObject fleCOSTING2;


    #endregion


    #region "Standard Generated Procedures(COSTING2_NOWEB_COSTING2_2_3)"


    #region "Automatic Item Initialization(COSTING2_NOWEB_COSTING2_2_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(COSTING2_NOWEB_COSTING2_2_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:14 PM

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
        fleCOSTING2A.Transaction = m_trnTRANS_UPDATE;
        fleCOSTING2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(COSTING2_NOWEB_COSTING2_2_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:14 PM

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
            fleCOSTING2A.Dispose();
            fleCOSTING2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING2_NOWEB_COSTING2_2_3)"


    public void Run()
    {

        try
        {
            Request("COSTING2_2_3");

            while (fleCOSTING2A.QTPForMissing())
            {
                // --> GET COSTING2A <--

                fleCOSTING2A.GetData();
                // --> End GET COSTING2A <--


                if (Transaction())
                {

                    Sort(fleCOSTING2A.GetSortValue("DOC_NBR"), fleCOSTING2A.GetSortValue("X_CLAIM_ID"));



                }

            }

            while (Sort(fleCOSTING2A))
            {
                NBR_REJECT.Value = NBR_REJECT.Value + 1;




                SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING2, fleCOSTING2A.At("DOC_NBR"), SubFileType.Keep, fleCOSTING2A, "DOC_NBR", "DOC_NAME", "DOC_INITS", "DOC_DEPT", "DOC_CLINIC_NBR",
                NBR_SVC, NBR_CLM, NBR_DTL, NBR_REJECT, AMT_YTD, MISC_AMT_YTD, MOHR_AMT_YTD, TOTAL_AMT_YTD, MAN_REJECT);



                Reset(ref NBR_REJECT, fleCOSTING2A.At("DOC_NBR"));

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
            EndRequest("COSTING2_2_3");

        }

    }




    #endregion


}
//COSTING2_2_3




