#region "Screen Comments"

// Program: costing1.qts
// Purpose: - creates files for costing the KEYING Charges
// 99/06/02 M. Chan - Yasemin to increase the size of nbr-svc,
// nbr-dtl, nbr-clm  from 4 to 6
// 99/06/08 M. Chan - Yasemin to apply tech-ind <> `Y` for clinic
// 60 to 65 claims only  , add a new column man reject
// - add request seven to extract man reject from manual
// rejected claims history file
// 99/07/20  B.E.  - added qualification of clinic nbr in request 4
// 00/01/07  B.E.  - added copy books to remove hard coding of 
//  miscellenous  billing codes 
// 2003/dec/11 A.A. - alpha doctor nbr
// 2003/sep/17 b.e. - correction on alpha doctor nbr conversion - request
// costing1_1 variable x-claims and request 
// costing1_2a variable x-claim-nbr-only size needed to
// be reduced by 1 due to change of doc-nbr from 9(4)
// to x(3).
// 2015/Jul/15 MC1       - add the same prepass (first request) as costing1_noweb.qts
// 2016/Nov/28 MC2 - change to set lock record update
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

public class COSTING1 : BaseClassControl
{
    private COSTING1 m_COSTING1;

    public COSTING1(string Name, int Level)
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

    public COSTING1(string Name, int Level, bool Request)
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
        if ((m_COSTING1 != null))
        {
            m_COSTING1.CloseTransactionObjects();
            m_COSTING1 = null;
        }
    }

    public COSTING1 GetCOSTING1(int Level)
    {
        if (m_COSTING1 == null)
        {
            m_COSTING1 = new COSTING1("COSTING1", Level);
        }
        else
        {
            m_COSTING1.ResetValues();
        }

        return m_COSTING1;
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
            COSTING1_COSTING_2 COSTING_2 = new COSTING1_COSTING_2(Name, Level);
            COSTING_2.Run();
            COSTING_2.Dispose();
            COSTING_2 = null;

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

public class COSTING1_COSTING_2 : COSTING1
{
    public COSTING1_COSTING_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    #region "Declarations (Variables, Files and Transactions)(COSTING1_COSTING_2)"

    //private SqlFileObject fleF002_CLAIMS_MSTR;
    //private SqlFileObject fleF020_DOCTOR_MSTR;

    //private void fleF020_DOCTOR_MSTR_SelectIf(ref string SelectIfClause)
    //{
    //    try
    //    {
    //        StringBuilder strSQL = new StringBuilder("");

    //        strSQL.Append("(").Append("CONVERT(int, (REPLICATE('0', 4 - LEN(DOC_DATE_FAC_START_YY)) + CONVERT(varchar(4), DOC_DATE_FAC_START_YY)) + ");
    //        strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_START_MM)) + CONVERT(varchar(2), DOC_DATE_FAC_START_MM)) + ");
    //        strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_START_DD)) + CONVERT(varchar(2), DOC_DATE_FAC_START_DD))) = 0 OR ");
    //        strSQL.Append("CONVERT(int, (REPLICATE('0', 4 - LEN(DOC_DATE_FAC_START_YY)) + CONVERT(varchar(4), DOC_DATE_FAC_START_YY)) + ");
    //        strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_START_MM)) + CONVERT(varchar(2), DOC_DATE_FAC_START_MM))) <= ").Append(W_CURRENT_COSTING_PED_YYMM.Value).Append(") AND ");
    //        strSQL.Append("(").Append("CONVERT(int, (REPLICATE('0', 4 - LEN(DOC_DATE_FAC_TERM_YY)) + CONVERT(varchar(4), DOC_DATE_FAC_TERM_YY)) + ");
    //        strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_TERM_MM)) + CONVERT(varchar(2), DOC_DATE_FAC_TERM_MM)) + ");
    //        strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_TERM_DD)) + CONVERT(varchar(2), DOC_DATE_FAC_TERM_DD))) = 0 OR ");
    //        strSQL.Append("CONVERT(int, (REPLICATE('0', 4 - LEN(DOC_DATE_FAC_TERM_YY)) + CONVERT(varchar(4), DOC_DATE_FAC_TERM_YY)) + ");
    //        strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_TERM_MM)) + CONVERT(varchar(2), DOC_DATE_FAC_TERM_MM)) + ");
    //        strSQL.Append("(REPLICATE('0', 2 - LEN(DOC_DATE_FAC_TERM_DD)) + CONVERT(varchar(2), DOC_DATE_FAC_TERM_DD))) >= ").Append(W_CURRENT_FISCAL_START_YYMMDD.Value).Append(")");

    //        SelectIfClause = strSQL.ToString();
    //    }

    //    catch (CustomApplicationException ex)
    //    {
    //        WriteError(ex);
    //    }

    //    catch (Exception ex)
    //    {
    //        WriteError(ex);
    //    }
    //}


    //private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    //{
    //    try
    //    {
    //        StringBuilder strSQL = new StringBuilder("");

    //        strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
    //        strSQL.Append(Common.StringToField("B"));

    //        strSQL.Append(" AND ");
    //        strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
    //        strSQL.Append(Common.StringToField("00000"));

    //        strSQL.Append(" AND ");
    //        strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
    //        strSQL.Append(Common.StringToField("0"));

    //        ChooseClause = strSQL.ToString();
    //    }

    //    catch (CustomApplicationException ex)
    //    {
    //        WriteError(ex);
    //    }

    //    catch (Exception ex)
    //    {
    //        WriteError(ex);
    //    }
    //}

    //private DDecimal DOC_START_YYMM = new DDecimal("DOC_START_YYMM", 6);
    //private void DOC_START_YYMM_GetValue(ref decimal Value)
    //{
    //    try
    //    {
    //        Value = QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_YY"), 4) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_MM"), 2) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_START_DD"), 2)) / 100;
    //    }

    //    catch (CustomApplicationException ex)
    //    {
    //        WriteError(ex);
    //    }

    //    catch (Exception ex)
    //    {
    //        WriteError(ex);
    //    }
    //}

    //private SqlFileObject fleCOSTING;

    #endregion

    #region "Standard Generated Procedures(COSTING1_COSTING_2)"


    #region "Automatic Item Initialization(COSTING1_COSTING_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(COSTING1_COSTING_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:28 PM

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
        //fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        //fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        //fleCOSTING.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(COSTING1_COSTING_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:28 PM

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
            //fleF002_CLAIMS_MSTR.Dispose();
            //fleF020_DOCTOR_MSTR.Dispose();
            //fleCOSTING.Dispose();


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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING1_COSTING_2)"

    public void Run()
    {
        Int64 COSTING_COUNT = 0;
        Int64 COSTING1_COUNT = 0;
        Int64 COSTING1B_COUNT = 0;
        Int64 COSTING2_COUNT = 0;

        try
        {
            Request("COSTING_2");

            //Write output to log file
            if (File.Exists(Directory.GetCurrentDirectory() + "\\COSTING1.log"))
            {
                File.Delete(Directory.GetCurrentDirectory() + "\\COSTING1.log");
            }

            using (SqlConnection conn = new SqlConnection(Common.GetSqlConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("INDEXED.sp_COSTING1", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@outCOSTING_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outCOSTING1_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outCOSTING1B_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@outCOSTING2_COUNT", SqlDbType.BigInt).Direction = ParameterDirection.Output;
                    cmd.CommandTimeout = 0;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    COSTING_COUNT =  (Int64)cmd.Parameters["@outCOSTING_COUNT"].Value;
                    COSTING1_COUNT = (Int64)cmd.Parameters["@outCOSTING1_COUNT"].Value;
                    COSTING1B_COUNT = (Int64)cmd.Parameters["@outCOSTING1B_COUNT"].Value;
                    COSTING2_COUNT = (Int64)cmd.Parameters["@outCOSTING2_COUNT"].Value;

                    StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory() + "\\COSTING1.log", true, System.Text.Encoding.Default);
                    sw.WriteLine("Request COSTING" + Environment.NewLine);
                    sw.WriteLine("                         Added     Updated     Unchanged     Deleted");
                    sw.WriteLine("  COSTING" + " ".PadLeft(21 - COSTING_COUNT.ToString().Trim().Length, ' ') + COSTING_COUNT.ToString().Trim() + " ".PadLeft(11, ' ') + "0" + " ".PadLeft(13, ' ') + "0" + " ".PadLeft(11, ' ') + "0" + Environment.NewLine + Environment.NewLine);
                    sw.WriteLine("Request COSTING1_1" + Environment.NewLine);
                    sw.WriteLine("                         Added     Updated     Unchanged     Deleted");
                    sw.WriteLine("  COSTING1" + " ".PadLeft(20 - COSTING1_COUNT.ToString().Trim().Length, ' ') + COSTING1_COUNT.ToString().Trim() + " ".PadLeft(11, ' ') + "0" + " ".PadLeft(13, ' ') + "0" + " ".PadLeft(11, ' ') + "0" + Environment.NewLine + Environment.NewLine);
                    sw.WriteLine("Request COSTING1_2A" + Environment.NewLine);
                    sw.WriteLine("                         Added     Updated     Unchanged     Deleted");
                    sw.WriteLine("  COSTING1B" + " ".PadLeft(19 - COSTING1B_COUNT.ToString().Trim().Length, ' ') + COSTING1B_COUNT.ToString().Trim() + " ".PadLeft(11, ' ') + "0" + " ".PadLeft(13, ' ') + "0" + " ".PadLeft(11, ' ') + "0" + Environment.NewLine + Environment.NewLine);
                    sw.WriteLine("Request COSTING1_2B" + Environment.NewLine);
                    sw.WriteLine("                         Added     Updated     Unchanged     Deleted");
                    sw.WriteLine("  COSTING2" + " ".PadLeft(20 - COSTING2_COUNT.ToString().Trim().Length, ' ') + COSTING2_COUNT.ToString().Trim() + " ".PadLeft(11, ' ') + "0" + " ".PadLeft(13, ' ') + "0" + " ".PadLeft(11, ' ') + "0" + Environment.NewLine + Environment.NewLine);
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
            }

            //while (fleF002_CLAIMS_MSTR.QTPForMissing())
            //{
            //    // --> GET F002_CLAIMS_MSTR <--
            //    fleF002_CLAIMS_MSTR.GetData();
            //    // --> End GET F002_CLAIMS_MSTR <--

            //    while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
            //    {
            //        // --> GET F020_DOCTOR_MSTR <--
            //        m_strWhere = new StringBuilder(" WHERE ");
            //        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
            //        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR"), 3, 3)));
            //        //Parent:CLMHDR_CLAIM_ID

            //        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
            //        // --> End GET F020_DOCTOR_MSTR <--

            //        if (Transaction())
            //        {
            //            SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING, SubFileType.Keep, fleF002_CLAIMS_MSTR, "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR");
            //        }
            //    }
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
            EndRequest("COSTING_2");
        }
    }

    #endregion
}
//COSTING_2

public class COSTING1_1_3 : COSTING1
{
    public COSTING1_1_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCOSTING = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_NBR_SVCS = new CoreDecimal("X_NBR_SVCS", 4, this);
        fleCOSTING1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_SV_NBR1.GetValue += X_SV_NBR1_GetValue;
        X_SV_NBR2.GetValue += X_SV_NBR2_GetValue;
        X_SV_NBR3.GetValue += X_SV_NBR3_GetValue;
        X_SV_NBR4.GetValue += X_SV_NBR4_GetValue;
        X_CLAIMS.GetValue += X_CLAIMS_GetValue;
        CLMDTL_ID.GetValue += CLMDTL_ID_GetValue;
        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;
    }

    #region "Declarations (Variables, Files and Transactions)(COSTING1_1_3)"

    private SqlFileObject fleCOSTING;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_DATE_PERIOD_END")).Append(" >= ").Append(Common.StringToField(QDesign.ASCII(W_CURRENT_FISCAL_START_YYMMDD.Value)));
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_DATE_PERIOD_END")).Append(" <= ").Append(Common.StringToField(QDesign.ASCII(W_CURRENT_COSTING_CUTOFF_YYMMDD.Value)));
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'0000'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'ZZZZ'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'PAID'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICM'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MISJ'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MISC'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICV'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MISP'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICB'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MIBR'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MINH'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MHSC'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'DHSC'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MOHR'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'AGEP'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICA'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICC'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICD'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICE'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICF'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICG'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICH'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICJ'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICK'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append(" <> ").Append("'MICL'");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_ADJ_NBR")).Append(" = ").Append("0");
            strSQL.Append(" AND SUBSTRING(").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_BATCH_NBR")).Append(", 1, 1) <> ").Append("'6'");
            strSQL.Append(" AND SUBSTRING(").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_BATCH_NBR")).Append(", 1, 2) <> ").Append("'71'");
            strSQL.Append(" AND SUBSTRING(").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_BATCH_NBR")).Append(", 1, 2) <> ").Append("'72'");
            strSQL.Append(" AND SUBSTRING(").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_BATCH_NBR")).Append(", 1, 2) <> ").Append("'73'");
            strSQL.Append(" AND SUBSTRING(").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_BATCH_NBR")).Append(", 1, 2) <> ").Append("'74'");
            strSQL.Append(" AND SUBSTRING(").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_BATCH_NBR")).Append(", 1, 2) <> ").Append("'75'");

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
    private SqlFileObject fleF020C_DOC_CLINIC_NEXT_BATCH_NBR;
    private SqlFileObject fleF040_OMA_FEE_MSTR;

    private DDecimal X_SV_NBR1 = new DDecimal("X_SV_NBR1", 2);
    private void X_SV_NBR1_GetValue(ref decimal Value)
    {
        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV");
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

    private DDecimal X_SV_NBR2 = new DDecimal("X_SV_NBR2", 2);
    private void X_SV_NBR2_GetValue(ref decimal Value)
    {
        try
        {
            decimal CurrentValue = 0m;

            if (QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "OP" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "MR" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "BI" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != QDesign.NULL("  ") & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "00" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "0 " & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != " 0")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 1));
            }
            else
            {
                CurrentValue = 0;
            }

            Value = CurrentValue;
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

    private DDecimal X_SV_NBR3 = new DDecimal("X_SV_NBR3", 2);
    private void X_SV_NBR3_GetValue(ref decimal Value)
    {
        try
        {
            decimal CurrentValue = 0m;

            if (QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "OP" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "MR" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "BI" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 5, 2)) != QDesign.NULL("  ") & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 5, 2)) != "0 " & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 5, 2)) != " 0" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 5, 2)) != "00")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 4, 1));
            }
            else
            {
                CurrentValue = 0;
            }

            Value = CurrentValue;
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

    private DDecimal X_SV_NBR4 = new DDecimal("X_SV_NBR4", 2);
    private void X_SV_NBR4_GetValue(ref decimal Value)
    {
        try
        {
            decimal CurrentValue = 0m;

            if (QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "OP" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "MR" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "BI" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 8, 2)) != QDesign.NULL("  ") & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 8, 2)) != "0 " & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 8, 2)) != " 0" & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 8, 2)) != "00")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 7, 1));
            }
            else
            {
                CurrentValue = 0;
            }

            Value = CurrentValue;
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

    private DCharacter X_CLAIMS = new DCharacter("X_CLAIMS", 15);
    private void X_CLAIMS_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR"), 1), 1, 15);
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

    private DCharacter CLMDTL_ID = new DCharacter("CLMDTL_ID", 15);
    private void CLMDTL_ID_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR"), 1), 1, 15);
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

    private CoreDecimal X_NBR_SVCS;

    private SqlFileObject fleCOSTING1;

    #endregion
    
    #region "Standard Generated Procedures(COSTING1_1_3)"

    #region "Automatic Item Initialization(COSTING1_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(COSTING1_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:28 PM

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
        fleCOSTING.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleCOSTING1.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(COSTING1_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:28 PM

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
            fleCOSTING.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.Dispose();
            fleF040_OMA_FEE_MSTR.Dispose();
            fleCOSTING1.Dispose();
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
    
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING1_1_3)"

    public void Run()
    {
        try
        {
            Request("1_3");

            while (fleCOSTING.QTPForMissing())
            {
                // --> GET COSTING <--
                fleCOSTING.GetData();
                // --> End GET COSTING <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleCOSTING.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleCOSTING.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_BATCH_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_CLAIM_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD"));
                    m_strOrderBy.Append(", ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_SUFF"));
                    m_strOrderBy.Append(", ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_ADJ_NBR"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_BATCH_NBR"), 3, 3)));
                        //Parent:CLMHDR_CLAIM_ID

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.QTPForMissing("3"))
                        {
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" AND ").Append(fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.ElementOwner("SEQ_NO")).Append(" = 1");

                            fleF020C_DOC_CLINIC_NEXT_BATCH_NBR.GetData(m_strWhere.ToString());

                            while (fleF040_OMA_FEE_MSTR.QTPForMissing("4"))
                            {
                                // --> GET F040_OMA_FEE_MSTR <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(0, 1)));

                                m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(1, 1)));

                                fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F040_OMA_FEE_MSTR <--

                                if (Transaction())
                                {
                                    //Sort(X_CLAIMS.Value);
                                    X_NBR_SVCS.Value = X_NBR_SVCS.Value + X_SV_NBR1.Value + X_SV_NBR2.Value + X_SV_NBR3.Value + X_SV_NBR4.Value;

                                    SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING1, At(X_CLAIMS), SubFileType.Keep, fleF020_DOCTOR_MSTR, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR, "DOC_CLINIC_NBR", X_CLAIMS, CLMDTL_ID, X_NBR_SVCS);

                                    Reset(ref X_NBR_SVCS, At(X_CLAIMS));
                                }
                            }
                        }
                    }
                }
            }

            //while (Sort(fleCOSTING, fleF002_CLAIMS_MSTR, fleF020_DOCTOR_MSTR, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR, fleF040_OMA_FEE_MSTR))
            //{
            //    X_NBR_SVCS.Value = X_NBR_SVCS.Value + X_SV_NBR1.Value + X_SV_NBR2.Value + X_SV_NBR3.Value + X_SV_NBR4.Value;

            //    SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING1, At(X_CLAIMS), SubFileType.Keep, fleF020_DOCTOR_MSTR, fleF020C_DOC_CLINIC_NEXT_BATCH_NBR, "DOC_CLINIC_NBR", X_CLAIMS, CLMDTL_ID, X_NBR_SVCS);

            //    Reset(ref X_NBR_SVCS, At(X_CLAIMS));
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
            EndRequest("1_3");
        }
    }

    #endregion
}
//1_3

public class COSTING1_2A_4 : COSTING1
{
    public COSTING1_2A_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCOSTING1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        C_NBR_SVC = new CoreDecimal("C_NBR_SVC", 6, this);
        C_NBR_CLM = new CoreDecimal("C_NBR_CLM", 6, this);
        C_NBR_DTL = new CoreDecimal("C_NBR_DTL", 6, this);
        DTL_AMT = new CoreDecimal("DTL_AMT", 6, this);
        C_NBR_DTL_LESS_THAN_MIN_AMT = new CoreDecimal("C_NBR_DTL_LESS_THAN_MIN_AMT", 6, this);
        fleCOSTING1B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING1B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_CLAIM_NBR_ONLY.GetValue += X_CLAIM_NBR_ONLY_GetValue;
        NBR_REJECT.GetValue += NBR_REJECT_GetValue;
        AMT_YTD.GetValue += AMT_YTD_GetValue;
        MISC_AMT_YTD.GetValue += MISC_AMT_YTD_GetValue;
        MOHR_AMT_YTD.GetValue += MOHR_AMT_YTD_GetValue;
        TOTAL_AMT_YTD.GetValue += TOTAL_AMT_YTD_GetValue;
        MAN_REJECT.GetValue += MAN_REJECT_GetValue;
        DOC_INITS.GetValue += DOC_INITS_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(COSTING1_2A_4)"

    private SqlFileObject fleCOSTING1;

    private DCharacter X_CLAIM_NBR_ONLY = new DCharacter("X_CLAIM_NBR_ONLY", 10);
    private void X_CLAIM_NBR_ONLY_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleCOSTING1.GetStringValue("X_CLAIMS"), 1, 10);
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

    private CoreDecimal C_NBR_SVC;
    private CoreDecimal C_NBR_CLM;
    private CoreDecimal C_NBR_DTL;
    private CoreDecimal DTL_AMT;
    private CoreDecimal C_NBR_DTL_LESS_THAN_MIN_AMT;

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

    private SqlFileObject fleCOSTING1B;

    private DCharacter DOC_INITS = new DCharacter("DOC_INITS", 3);
    private void DOC_INITS_GetValue(ref string Value)
    {
        try
        {
            Value = fleCOSTING1.GetStringValue("DOC_INIT1") + fleCOSTING1.GetStringValue("DOC_INIT2") + fleCOSTING1.GetStringValue("DOC_INIT3");
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

    #region "Standard Generated Procedures(COSTING1_2A_4)"

    #region "Automatic Item Initialization(COSTING1_2A_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(COSTING1_2A_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:28 PM

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
        fleCOSTING1.Transaction = m_trnTRANS_UPDATE;
        fleCOSTING1B.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(COSTING1_2A_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:28 PM

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
            fleCOSTING1.Dispose();
            fleCOSTING1B.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING1_2A_4)"

    public void Run()
    {
        try
        {
            Request("2A_4");

            while (fleCOSTING1.QTPForMissing())
            {
                m_strWhere = new StringBuilder("");

                m_strOrderBy = new StringBuilder(" ORDER BY ");
                m_strOrderBy.Append(fleCOSTING1.ElementOwner("DOC_NBR"));
                m_strOrderBy.Append(", SUBSTRING(").Append(fleCOSTING1.ElementOwner("X_CLAIMS")).Append(", 1, 10");

                // --> GET COSTING1 <--
                fleCOSTING1.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                // --> End GET COSTING1 <--


                if (Transaction())
                {
                    //Sort(fleCOSTING1.GetSortValue("DOC_NBR"), X_CLAIM_NBR_ONLY.Value);

                    C_NBR_SVC.Value = C_NBR_SVC.Value + fleCOSTING1.GetDecimalValue("X_NBR_SVCS");

                    if (fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY))
                    {
                        C_NBR_CLM.Value = C_NBR_CLM.Value + 1;
                    }

                    C_NBR_DTL.Value = C_NBR_DTL.Value + 1;
                    DTL_AMT.Value = 1000;

                    if (QDesign.NULL(DTL_AMT.Value) < 300)
                    {
                        C_NBR_DTL_LESS_THAN_MIN_AMT.Value = C_NBR_DTL_LESS_THAN_MIN_AMT.Value + 1;
                    }

                    SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING1B, fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY), SubFileType.Keep, X_CLAIM_NBR_ONLY, fleCOSTING1, "DOC_NBR", "DOC_NAME", DOC_INITS, "DOC_DEPT",
                    "DOC_CLINIC_NBR", C_NBR_SVC, C_NBR_CLM, C_NBR_DTL, C_NBR_DTL_LESS_THAN_MIN_AMT, NBR_REJECT, AMT_YTD, MISC_AMT_YTD, MOHR_AMT_YTD, TOTAL_AMT_YTD,
                    MAN_REJECT);

                    Reset(ref C_NBR_SVC, fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY));
                    Reset(ref C_NBR_CLM, fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY));
                    Reset(ref C_NBR_DTL, fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY));
                    Reset(ref C_NBR_DTL_LESS_THAN_MIN_AMT, fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY));
                }
            }

            //while (Sort(fleCOSTING1))
            //{
            //    C_NBR_SVC.Value = C_NBR_SVC.Value + fleCOSTING1.GetDecimalValue("X_NBR_SVCS");

            //    if (fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY))
            //    {
            //        C_NBR_CLM.Value = C_NBR_CLM.Value + 1;
            //    }

            //    C_NBR_DTL.Value = C_NBR_DTL.Value + 1;
            //    DTL_AMT.Value = 1000;

            //    if (QDesign.NULL(DTL_AMT.Value) < 300)
            //    {
            //        C_NBR_DTL_LESS_THAN_MIN_AMT.Value = C_NBR_DTL_LESS_THAN_MIN_AMT.Value + 1;
            //    }

            //    SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING1B, fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY), SubFileType.Keep, X_CLAIM_NBR_ONLY, fleCOSTING1, "DOC_NBR", "DOC_NAME", DOC_INITS, "DOC_DEPT",
            //    "DOC_CLINIC_NBR", C_NBR_SVC, C_NBR_CLM, C_NBR_DTL, C_NBR_DTL_LESS_THAN_MIN_AMT, NBR_REJECT, AMT_YTD, MISC_AMT_YTD, MOHR_AMT_YTD, TOTAL_AMT_YTD,
            //    MAN_REJECT);

            //    Reset(ref C_NBR_SVC, fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY));
            //    Reset(ref C_NBR_CLM, fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY));
            //    Reset(ref C_NBR_DTL, fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY));
            //    Reset(ref C_NBR_DTL_LESS_THAN_MIN_AMT, fleCOSTING1.At("DOC_NBR") || At(X_CLAIM_NBR_ONLY));
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
            EndRequest("2A_4");
        }
    }

    #endregion
}
//2A_4

public class COSTING1_2B_5 : COSTING1
{
    public COSTING1_2B_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCOSTING1B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING1B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        NBR_SVC = new CoreDecimal("NBR_SVC", 6, this);
        NBR_CLM = new CoreDecimal("NBR_CLM", 6, this);
        NBR_DTL = new CoreDecimal("NBR_DTL", 6, this);
        fleCOSTING2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "COSTING2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_CLINIC.GetValue += X_CLINIC_GetValue;
        NBR_REJECT.GetValue += NBR_REJECT_GetValue;
        AMT_YTD.GetValue += AMT_YTD_GetValue;
        MISC_AMT_YTD.GetValue += MISC_AMT_YTD_GetValue;
        MOHR_AMT_YTD.GetValue += MOHR_AMT_YTD_GetValue;
        TOTAL_AMT_YTD.GetValue += TOTAL_AMT_YTD_GetValue;
        MAN_REJECT.GetValue += MAN_REJECT_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(COSTING1_2B_5)"

    private SqlFileObject fleCOSTING1B;
    private CoreDecimal NBR_SVC;
    private CoreDecimal NBR_CLM;

    private DCharacter X_CLINIC = new DCharacter("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleCOSTING1B.GetStringValue("X_CLAIM_NBR_ONLY"), 1, 2);
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

    private CoreDecimal NBR_DTL;

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

    #region "Standard Generated Procedures(COSTING1_2B_5)"
    
    #region "Automatic Item Initialization(COSTING1_2B_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion
        
    #region "Transaction Management Procedures(COSTING1_2B_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:28 PM

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
        fleCOSTING1B.Transaction = m_trnTRANS_UPDATE;
        fleCOSTING2.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion
    
    #region "FILE Management Procedures(COSTING1_2B_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:29 PM

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
            fleCOSTING1B.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(COSTING1_2B_5)"

    public void Run()
    {
        try
        {
            Request("2B_5");

            while (fleCOSTING1B.QTPForMissing())
            {
                m_strWhere = new StringBuilder("");

                m_strOrderBy = new StringBuilder(" ORDER BY ");
                m_strOrderBy.Append(fleCOSTING1B.ElementOwner("DOC_NBR"));
                m_strOrderBy.Append(", SUBSTRING(").Append(fleCOSTING1B.ElementOwner("X_CLAIMS")).Append(", 1, 10");

                // --> GET COSTING1B <--
                fleCOSTING1B.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                // --> End GET COSTING1B <--

                if (Transaction())
                {
                    //Sort(fleCOSTING1B.GetSortValue("DOC_NBR"), fleCOSTING1B.GetSortValue("X_CLAIM_NBR_ONLY"));

                    NBR_SVC.Value = NBR_SVC.Value + fleCOSTING1B.GetDecimalValue("C_NBR_SVC");

                    if (fleCOSTING1B.At("DOC_NBR") || fleCOSTING1B.At("X_CLAIM_NBR_ONLY"))
                    {
                        NBR_CLM.Value = NBR_CLM.Value + 1;
                    }

                    if (1 == 1)
                    {
                        NBR_DTL.Value = NBR_DTL.Value + fleCOSTING1B.GetDecimalValue("C_NBR_DTL");
                    }
                    else
                    {
                        NBR_DTL.Value = NBR_DTL.Value + fleCOSTING1B.GetDecimalValue("C_NBR_DTL");
                    }

                    SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING2, fleCOSTING1B.At("DOC_NBR"), SubFileType.Keep, fleCOSTING1B, "DOC_NBR", "DOC_NAME", "DOC_INITS", "DOC_DEPT", "DOC_CLINIC_NBR",
                    NBR_SVC, NBR_CLM, NBR_DTL, NBR_REJECT, AMT_YTD, MISC_AMT_YTD, MOHR_AMT_YTD, TOTAL_AMT_YTD, MAN_REJECT);

                    Reset(ref NBR_SVC, fleCOSTING1B.At("DOC_NBR"));
                    Reset(ref NBR_CLM, fleCOSTING1B.At("DOC_NBR"));
                    Reset(ref NBR_DTL, fleCOSTING1B.At("DOC_NBR"));
                }
            }

            //while (Sort(fleCOSTING1B))
            //{
            //    NBR_SVC.Value = NBR_SVC.Value + fleCOSTING1B.GetDecimalValue("C_NBR_SVC");

            //    if (fleCOSTING1B.At("DOC_NBR") || fleCOSTING1B.At("X_CLAIM_NBR_ONLY"))
            //    {
            //        NBR_CLM.Value = NBR_CLM.Value + 1;
            //    }

            //    if (1 == 1)
            //    {
            //        NBR_DTL.Value = NBR_DTL.Value + fleCOSTING1B.GetDecimalValue("C_NBR_DTL");
            //    }
            //    else
            //    {
            //        NBR_DTL.Value = NBR_DTL.Value + fleCOSTING1B.GetDecimalValue("C_NBR_DTL");
            //    }

            //    SubFile(ref m_trnTRANS_UPDATE, ref fleCOSTING2, fleCOSTING1B.At("DOC_NBR"), SubFileType.Keep, fleCOSTING1B, "DOC_NBR", "DOC_NAME", "DOC_INITS", "DOC_DEPT", "DOC_CLINIC_NBR",
            //    NBR_SVC, NBR_CLM, NBR_DTL, NBR_REJECT, AMT_YTD, MISC_AMT_YTD, MOHR_AMT_YTD, TOTAL_AMT_YTD, MAN_REJECT);

            //    Reset(ref NBR_SVC, fleCOSTING1B.At("DOC_NBR"));
            //    Reset(ref NBR_CLM, fleCOSTING1B.At("DOC_NBR"));
            //    Reset(ref NBR_DTL, fleCOSTING1B.At("DOC_NBR"));
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
            EndRequest("2B_5");
        }
    }

    #endregion
}
//2B_5
