
#region "Screen Comments"

// doc:     leena1_premium.qts
// For:     Leena and the Board
// Date           Who             Description
// 2001/11/21     Yasemin         Original


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class LEENA_PREMIUM : BaseClassControl
{

    private LEENA_PREMIUM m_LEENA_PREMIUM;

    public LEENA_PREMIUM(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public LEENA_PREMIUM(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_LEENA_PREMIUM != null))
        {
            m_LEENA_PREMIUM.CloseTransactionObjects();
            m_LEENA_PREMIUM = null;
        }
    }

    public LEENA_PREMIUM GetLEENA_PREMIUM(int Level)
    {
        if (m_LEENA_PREMIUM == null)
        {
            m_LEENA_PREMIUM = new LEENA_PREMIUM("LEENA_PREMIUM", Level);
        }
        else
        {
            m_LEENA_PREMIUM.ResetValues();
        }
        return m_LEENA_PREMIUM;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.


    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            LEENA_PREMIUM_ONE_1 ONE_1 = new LEENA_PREMIUM_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            LEENA_PREMIUM_TWO_2 TWO_2 = new LEENA_PREMIUM_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

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



public class LEENA_PREMIUM_ONE_1 : LEENA_PREMIUM
{

    public LEENA_PREMIUM_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleLEENA1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "LEENA1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(LEENA_PREMIUM_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (  ").Append(GetWhereClauseString(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DATE_PERIOD_END"), ">=", 20000701)).Append(" AND ");
            strSQL.Append("  ").Append(GetWhereClauseString(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DATE_PERIOD_END"), "<=", 20010630)).Append(")");


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


    private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_P_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("P"));


            ChooseClause = strSQL.ToString();


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

    private SqlFileObject fleLEENA1;


    #endregion


    #region "Standard Generated Procedures(LEENA_PREMIUM_ONE_1)"


    #region "Automatic Item Initialization(LEENA_PREMIUM_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(LEENA_PREMIUM_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:22 PM

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
        fleLEENA1.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(LEENA_PREMIUM_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:22 PM

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
            fleF002_CLAIMS_MSTR.Dispose();
            fleLEENA1.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(LEENA_PREMIUM_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleLEENA1, SubFileType.Keep, fleF002_CLAIMS_MSTR, "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR");


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
            EndRequest("ONE_1");

        }

    }







    #endregion


}
//ONE_1



public class LEENA_PREMIUM_TWO_2 : LEENA_PREMIUM
{

    public LEENA_PREMIUM_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleLEENA1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "LEENA1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_JUL_2001_P = new CoreDecimal("X_JUL_2001_P", 7, this);
        X_JUL_DAY_2001_P = new CoreDecimal("X_JUL_DAY_2001_P", 7, this);
        X_JUL_2001_A = new CoreDecimal("X_JUL_2001_A", 7, this);
        X_AUG_2001_P = new CoreDecimal("X_AUG_2001_P", 7, this);
        X_AUG_DAY_2001_P = new CoreDecimal("X_AUG_DAY_2001_P", 7, this);
        X_AUG_2001_A = new CoreDecimal("X_AUG_2001_A", 7, this);
        X_SEP_2001_P = new CoreDecimal("X_SEP_2001_P", 7, this);
        X_SEP_DAY_2001_P = new CoreDecimal("X_SEP_DAY_2001_P", 7, this);
        X_SEP_2001_A = new CoreDecimal("X_SEP_2001_A", 7, this);
        X_OCT_2001_P = new CoreDecimal("X_OCT_2001_P", 7, this);
        X_OCT_DAY_2001_P = new CoreDecimal("X_OCT_DAY_2001_P", 7, this);
        X_OCT_2001_A = new CoreDecimal("X_OCT_2001_A", 7, this);
        X_NOV_2001_P = new CoreDecimal("X_NOV_2001_P", 7, this);
        X_NOV_DAY_2001_P = new CoreDecimal("X_NOV_DAY_2001_P", 7, this);
        X_NOV_2001_A = new CoreDecimal("X_NOV_2001_A", 7, this);
        X_DEC_2001_P = new CoreDecimal("X_DEC_2001_P", 7, this);
        X_DEC_DAY_2001_P = new CoreDecimal("X_DEC_DAY_2001_P", 7, this);
        X_DEC_2001_A = new CoreDecimal("X_DEC_2001_A", 7, this);
        X_JAN_2001_P = new CoreDecimal("X_JAN_2001_P", 7, this);
        X_JAN_DAY_2001_P = new CoreDecimal("X_JAN_DAY_2001_P", 7, this);
        X_JAN_2001_A = new CoreDecimal("X_JAN_2001_A", 7, this);
        X_FEB_2001_P = new CoreDecimal("X_FEB_2001_P", 7, this);
        X_FEB_DAY_2001_P = new CoreDecimal("X_FEB_DAY_2001_P", 7, this);
        X_FEB_2001_A = new CoreDecimal("X_FEB_2001_A", 7, this);
        X_MAR_2001_P = new CoreDecimal("X_MAR_2001_P", 7, this);
        X_MAR_DAY_2001_P = new CoreDecimal("X_MAR_DAY_2001_P", 7, this);
        X_MAR_2001_A = new CoreDecimal("X_MAR_2001_A", 7, this);
        X_APR_2001_P = new CoreDecimal("X_APR_2001_P", 7, this);
        X_APR_DAY_2001_P = new CoreDecimal("X_APR_DAY_2001_P", 7, this);
        X_APR_2001_A = new CoreDecimal("X_APR_2001_A", 7, this);
        X_MAY_2001_P = new CoreDecimal("X_MAY_2001_P", 7, this);
        X_MAY_DAY_2001_P = new CoreDecimal("X_MAY_DAY_2001_P", 7, this);
        X_MAY_2001_A = new CoreDecimal("X_MAY_2001_A", 7, this);
        X_JUN_2001_P = new CoreDecimal("X_JUN_2001_P", 7, this);
        X_JUN_DAY_2001_P = new CoreDecimal("X_JUN_DAY_2001_P", 7, this);
        X_JUN_2001_A = new CoreDecimal("X_JUN_2001_A", 7, this);
        fleLEENA2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "LEENA2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        PREM_CODE.GetValue += PREM_CODE_GetValue;
        X_MM.GetValue += X_MM_GetValue;
        X_YYYY.GetValue += X_YYYY_GetValue;
        X_COMMA.GetValue += X_COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(LEENA_PREMIUM_TWO_2)"

    private SqlFileObject fleLEENA1;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_DATE_PERIOD_END")).Append(" >=  '20000701' AND ");
            strSQL.Append("    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_DATE_PERIOD_END")).Append(" <=  '20010630')");


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


    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "0000" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "ZZZZ")
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

    private DCharacter PREM_CODE = new DCharacter("PREM_CODE", 1);
    private void PREM_CODE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "E400" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "E401" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C988" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C998" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C999" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "K990" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "K991" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "K992" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "K993" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "K994" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "K995" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "K996" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "K997" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C990" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C991" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C992" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C993" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C994" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C995" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C996" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C997" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "B990" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "B992" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "B994" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "B996" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "W990" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "W992" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "W994" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "W996" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "A990" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "A994" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "A996" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "Q990" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "Q992" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "Q994" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "Q996" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C989" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C101" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "E409" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "E410" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C109" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "C110" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "E402" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "E403" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "E075" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "E411")
            {
                CurrentValue = "Y";
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
    private DCharacter X_MM = new DCharacter("X_MM", 2);
    private void X_MM_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_DATE_PERIOD_END"), 5, 2);


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
    private DCharacter X_YYYY = new DCharacter("X_YYYY", 4);
    private void X_YYYY_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_DATE_PERIOD_END"), 1, 4);


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
    private DCharacter X_COMMA = new DCharacter("X_COMMA", 1);
    private void X_COMMA_GetValue(ref string Value)
    {

        try
        {
            Value = ",";


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
    private DInteger X_NUM_CR = new DInteger("X_NUM_CR", 4);
    private void X_NUM_CR_GetValue(ref decimal Value)
    {

        try
        {
            Value = 13;


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
    private DCharacter X_CR = new DCharacter("X_CR", 2);
    private void X_CR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_CR.Value);


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
    private CoreDecimal X_JUL_2001_P;
    private CoreDecimal X_JUL_DAY_2001_P;
    private CoreDecimal X_JUL_2001_A;
    private CoreDecimal X_AUG_2001_P;
    private CoreDecimal X_AUG_DAY_2001_P;
    private CoreDecimal X_AUG_2001_A;
    private CoreDecimal X_SEP_2001_P;
    private CoreDecimal X_SEP_DAY_2001_P;
    private CoreDecimal X_SEP_2001_A;
    private CoreDecimal X_OCT_2001_P;
    private CoreDecimal X_OCT_DAY_2001_P;
    private CoreDecimal X_OCT_2001_A;
    private CoreDecimal X_NOV_2001_P;
    private CoreDecimal X_NOV_DAY_2001_P;
    private CoreDecimal X_NOV_2001_A;
    private CoreDecimal X_DEC_2001_P;
    private CoreDecimal X_DEC_DAY_2001_P;
    private CoreDecimal X_DEC_2001_A;
    private CoreDecimal X_JAN_2001_P;
    private CoreDecimal X_JAN_DAY_2001_P;
    private CoreDecimal X_JAN_2001_A;
    private CoreDecimal X_FEB_2001_P;
    private CoreDecimal X_FEB_DAY_2001_P;
    private CoreDecimal X_FEB_2001_A;
    private CoreDecimal X_MAR_2001_P;
    private CoreDecimal X_MAR_DAY_2001_P;
    private CoreDecimal X_MAR_2001_A;
    private CoreDecimal X_APR_2001_P;
    private CoreDecimal X_APR_DAY_2001_P;
    private CoreDecimal X_APR_2001_A;
    private CoreDecimal X_MAY_2001_P;
    private CoreDecimal X_MAY_DAY_2001_P;
    private CoreDecimal X_MAY_2001_A;
    private CoreDecimal X_JUN_2001_P;
    private CoreDecimal X_JUN_DAY_2001_P;
    private CoreDecimal X_JUN_2001_A;
    private SqlFileObject fleLEENA2;


    #endregion


    #region "Standard Generated Procedures(LEENA_PREMIUM_TWO_2)"


    #region "Automatic Item Initialization(LEENA_PREMIUM_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(LEENA_PREMIUM_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:22 PM

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
        fleLEENA1.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleLEENA2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(LEENA_PREMIUM_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:22 PM

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
            fleLEENA1.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleLEENA2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(LEENA_PREMIUM_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleLEENA1.QTPForMissing())
            {
                // --> GET LEENA1 <--

                fleLEENA1.GetData();
                // --> End GET LEENA1 <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleLEENA1.GetStringValue("KEY_CLM_TYPE")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "07") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_JUL_2001_P.Value = X_JUL_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "07") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_JUL_DAY_2001_P.Value = X_JUL_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "07") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_JUL_DAY_2001_P.Value = X_JUL_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "07"))
                            {
                                X_JUL_2001_A.Value = X_JUL_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "08") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_AUG_2001_P.Value = X_AUG_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "08") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_AUG_DAY_2001_P.Value = X_AUG_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "08") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_AUG_DAY_2001_P.Value = X_AUG_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "08"))
                            {
                                X_AUG_2001_A.Value = X_AUG_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "09") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_SEP_2001_P.Value = X_SEP_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "09") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_SEP_DAY_2001_P.Value = X_SEP_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "09") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_SEP_DAY_2001_P.Value = X_SEP_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "09"))
                            {
                                X_SEP_2001_A.Value = X_SEP_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "10") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_OCT_2001_P.Value = X_OCT_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "10") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_OCT_DAY_2001_P.Value = X_OCT_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "10") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_OCT_DAY_2001_P.Value = X_OCT_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "10"))
                            {
                                X_OCT_2001_A.Value = X_OCT_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "11") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_NOV_2001_P.Value = X_NOV_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "11") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_NOV_DAY_2001_P.Value = X_NOV_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "11") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_NOV_DAY_2001_P.Value = X_NOV_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "11"))
                            {
                                X_NOV_2001_A.Value = X_NOV_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "12") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_DEC_2001_P.Value = X_DEC_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "12") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_DEC_DAY_2001_P.Value = X_DEC_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "12") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_DEC_DAY_2001_P.Value = X_DEC_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2000" & QDesign.NULL(X_MM.Value) == "12"))
                            {
                                X_DEC_2001_A.Value = X_DEC_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "01") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_JAN_2001_P.Value = X_JAN_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "01") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_JAN_DAY_2001_P.Value = X_JAN_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "01") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_JAN_DAY_2001_P.Value = X_JAN_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "01"))
                            {
                                X_JAN_2001_A.Value = X_JAN_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "02") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_FEB_2001_P.Value = X_FEB_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "02") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_FEB_DAY_2001_P.Value = X_FEB_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "02") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_FEB_DAY_2001_P.Value = X_FEB_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "02"))
                            {
                                X_FEB_2001_A.Value = X_FEB_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "03") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_MAR_2001_P.Value = X_MAR_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "03") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_MAR_DAY_2001_P.Value = X_MAR_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "03") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_MAR_DAY_2001_P.Value = X_MAR_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "03"))
                            {
                                X_MAR_2001_A.Value = X_MAR_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "04") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_APR_2001_P.Value = X_APR_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "04") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_APR_DAY_2001_P.Value = X_APR_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "04") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_APR_DAY_2001_P.Value = X_APR_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "04"))
                            {
                                X_APR_2001_A.Value = X_APR_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "05") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_MAY_2001_P.Value = X_MAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "05") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_MAY_DAY_2001_P.Value = X_MAY_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "05") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_MAY_DAY_2001_P.Value = X_MAY_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "05"))
                            {
                                X_MAY_2001_A.Value = X_MAY_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "06") & QDesign.NULL(PREM_CODE.Value) == "Y")
                            {
                                X_JUN_2001_P.Value = X_JUN_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "06") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "C101")
                            {
                                X_JUN_DAY_2001_P.Value = X_JUN_DAY_2001_P.Value + 1;
                            }
                            else if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "06") & QDesign.NULL(PREM_CODE.Value) == "Y" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD" + (3).ToString())) == "C101")
                            {
                                X_JUN_DAY_2001_P.Value = X_JUN_DAY_2001_P.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (1).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (2).ToString()) + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR" + (3).ToString());
                            }
                            if ((QDesign.NULL(X_YYYY.Value) == "2001" & QDesign.NULL(X_MM.Value) == "06"))
                            {
                                X_JUN_2001_A.Value = X_JUN_2001_A.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                            }
                            SubFile(ref m_trnTRANS_UPDATE, ref fleLEENA2, AtFinal(), SubFileType.Portable, X_JUL_2001_P, X_COMMA, X_JUL_DAY_2001_P, X_JUL_2001_A, X_AUG_2001_P, X_AUG_DAY_2001_P,
                            X_AUG_2001_A, X_SEP_2001_P, X_SEP_DAY_2001_P, X_SEP_2001_A, X_OCT_2001_P, X_OCT_DAY_2001_P, X_OCT_2001_A, X_NOV_2001_P, X_NOV_DAY_2001_P, X_NOV_2001_A,
                            X_DEC_2001_P, X_DEC_DAY_2001_P, X_DEC_2001_A, X_JAN_2001_P, X_JAN_DAY_2001_P, X_JAN_2001_A, X_FEB_2001_P, X_FEB_DAY_2001_P, X_FEB_2001_A, X_MAR_2001_P,
                            X_MAR_DAY_2001_P, X_MAR_2001_A, X_APR_2001_P, X_APR_DAY_2001_P, X_APR_2001_A, X_MAY_2001_P, X_MAY_DAY_2001_P, X_MAY_2001_A, X_JUN_2001_P, X_JUN_DAY_2001_P,
                            X_JUN_2001_A);


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
            EndRequest("TWO_2");

        }

    }







    #endregion


}
//TWO_2




