
#region "Screen Comments"

// doc     : leena_claims   
// purpose : create report by month for the year, dollar amount and # of claims
// july2005 to yearend2006, just claims batches no payment or adj batch
// NOTE: batch-sub-type =  +  is web so web amount against r001 will be
// high by  +  amount          
// who     : import into excell and e-mail to Leena  quarterly    
// *************************************************************
// Date  Who  Description
// 2005/10/26 Yasemin         original


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class LEENACLAIMS : BaseClassControl
{

    private LEENACLAIMS m_LEENACLAIMS;

    public LEENACLAIMS(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public LEENACLAIMS(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_LEENACLAIMS != null))
        {
            m_LEENACLAIMS.CloseTransactionObjects();
            m_LEENACLAIMS = null;
        }
    }

    public LEENACLAIMS GetLEENACLAIMS(int Level)
    {
        if (m_LEENACLAIMS == null)
        {
            m_LEENACLAIMS = new LEENACLAIMS("LEENACLAIMS", Level);
        }
        else
        {
            m_LEENACLAIMS.ResetValues();
        }
        return m_LEENACLAIMS;
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

            LEENACLAIMS_ONE_1 ONE_1 = new LEENACLAIMS_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

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



public class LEENACLAIMS_ONE_1 : LEENACLAIMS
{

    public LEENACLAIMS_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_JUL_M_CLMS = new CoreDecimal("X_JUL_M_CLMS", 9, this);
        X_JUL_W_CLMS = new CoreDecimal("X_JUL_W_CLMS", 9, this);
        X_JUL_M_AMT = new CoreDecimal("X_JUL_M_AMT", 9, this);
        X_JUL_W_AMT = new CoreDecimal("X_JUL_W_AMT", 9, this);
        X_AUG_M_CLMS = new CoreDecimal("X_AUG_M_CLMS", 9, this);
        X_AUG_W_CLMS = new CoreDecimal("X_AUG_W_CLMS", 9, this);
        X_AUG_M_AMT = new CoreDecimal("X_AUG_M_AMT", 9, this);
        X_AUG_W_AMT = new CoreDecimal("X_AUG_W_AMT", 9, this);
        X_SEP_M_CLMS = new CoreDecimal("X_SEP_M_CLMS", 9, this);
        X_SEP_W_CLMS = new CoreDecimal("X_SEP_W_CLMS", 9, this);
        X_SEP_M_AMT = new CoreDecimal("X_SEP_M_AMT", 9, this);
        X_SEP_W_AMT = new CoreDecimal("X_SEP_W_AMT", 9, this);
        X_OCT_M_CLMS = new CoreDecimal("X_OCT_M_CLMS", 9, this);
        X_OCT_W_CLMS = new CoreDecimal("X_OCT_W_CLMS", 9, this);
        X_OCT_M_AMT = new CoreDecimal("X_OCT_M_AMT", 9, this);
        X_OCT_W_AMT = new CoreDecimal("X_OCT_W_AMT", 9, this);
        X_NOV_M_CLMS = new CoreDecimal("X_NOV_M_CLMS", 9, this);
        X_NOV_W_CLMS = new CoreDecimal("X_NOV_W_CLMS", 9, this);
        X_NOV_M_AMT = new CoreDecimal("X_NOV_M_AMT", 9, this);
        X_NOV_W_AMT = new CoreDecimal("X_NOV_W_AMT", 9, this);
        X_DEC_M_CLMS = new CoreDecimal("X_DEC_M_CLMS", 9, this);
        X_DEC_W_CLMS = new CoreDecimal("X_DEC_W_CLMS", 9, this);
        X_DEC_M_AMT = new CoreDecimal("X_DEC_M_AMT", 9, this);
        X_DEC_W_AMT = new CoreDecimal("X_DEC_W_AMT", 9, this);
        X_JAN_M_CLMS = new CoreDecimal("X_JAN_M_CLMS", 9, this);
        X_JAN_W_CLMS = new CoreDecimal("X_JAN_W_CLMS", 9, this);
        X_JAN_M_AMT = new CoreDecimal("X_JAN_M_AMT", 9, this);
        X_JAN_W_AMT = new CoreDecimal("X_JAN_W_AMT", 9, this);
        X_FEB_M_CLMS = new CoreDecimal("X_FEB_M_CLMS", 9, this);
        X_FEB_W_CLMS = new CoreDecimal("X_FEB_W_CLMS", 9, this);
        X_FEB_M_AMT = new CoreDecimal("X_FEB_M_AMT", 9, this);
        X_FEB_W_AMT = new CoreDecimal("X_FEB_W_AMT", 9, this);
        X_MAR_M_CLMS = new CoreDecimal("X_MAR_M_CLMS", 9, this);
        X_MAR_W_CLMS = new CoreDecimal("X_MAR_W_CLMS", 9, this);
        X_MAR_M_AMT = new CoreDecimal("X_MAR_M_AMT", 9, this);
        X_MAR_W_AMT = new CoreDecimal("X_MAR_W_AMT", 9, this);
        X_APR_M_CLMS = new CoreDecimal("X_APR_M_CLMS", 9, this);
        X_APR_W_CLMS = new CoreDecimal("X_APR_W_CLMS", 9, this);
        X_APR_M_AMT = new CoreDecimal("X_APR_M_AMT", 9, this);
        X_APR_W_AMT = new CoreDecimal("X_APR_W_AMT", 9, this);
        X_MAY_M_CLMS = new CoreDecimal("X_MAY_M_CLMS", 9, this);
        X_MAY_W_CLMS = new CoreDecimal("X_MAY_W_CLMS", 9, this);
        X_MAY_M_AMT = new CoreDecimal("X_MAY_M_AMT", 9, this);
        X_MAY_W_AMT = new CoreDecimal("X_MAY_W_AMT", 9, this);
        X_JUN_M_CLMS = new CoreDecimal("X_JUN_M_CLMS", 9, this);
        X_JUN_W_CLMS = new CoreDecimal("X_JUN_W_CLMS", 9, this);
        X_JUN_M_AMT = new CoreDecimal("X_JUN_M_AMT", 9, this);
        X_JUN_W_AMT = new CoreDecimal("X_JUN_W_AMT", 9, this);
        X_TOT_M_CLMS = new CoreDecimal("X_TOT_M_CLMS", 9, this);
        X_TOT_W_CLMS = new CoreDecimal("X_TOT_W_CLMS", 9, this);
        X_TOT_M_AMT = new CoreDecimal("X_TOT_M_AMT", 9, this);
        X_TOT_W_AMT = new CoreDecimal("X_TOT_W_AMT", 9, this);
        X_TOT_CLMS = new CoreDecimal("X_TOT_CLMS", 9, this);
        X_TOT_AMT = new CoreDecimal("X_TOT_AMT", 9, this);
        fleLEENACLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "LEENACLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_TYPE.GetValue += X_TYPE_GetValue;
        X_MM.GetValue += X_MM_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(LEENACLAIMS_ONE_1)"

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;
    private SqlFileObject fleICONST_MSTR_REC;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD_SUB_TYPE")) == "C" | QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD_SUB_TYPE")) == "D" | QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD_SUB_TYPE")) == "W" | QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD_SUB_TYPE")) == "S")
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

    private DCharacter X_TYPE = new DCharacter("X_TYPE", 3);
    private void X_TYPE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD_SUB_TYPE")) == "S")
            {
                CurrentValue = "CLM";
            }
            else
            {
                CurrentValue = "WEB";
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
            Value= QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_DATE_PERIOD_END"), 5, 2);


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
    private CoreDecimal X_JUL_M_CLMS;
    private CoreDecimal X_JUL_W_CLMS;
    private CoreDecimal X_JUL_M_AMT;
    private CoreDecimal X_JUL_W_AMT;
    private CoreDecimal X_AUG_M_CLMS;
    private CoreDecimal X_AUG_W_CLMS;
    private CoreDecimal X_AUG_M_AMT;
    private CoreDecimal X_AUG_W_AMT;
    private CoreDecimal X_SEP_M_CLMS;
    private CoreDecimal X_SEP_W_CLMS;
    private CoreDecimal X_SEP_M_AMT;
    private CoreDecimal X_SEP_W_AMT;
    private CoreDecimal X_OCT_M_CLMS;
    private CoreDecimal X_OCT_W_CLMS;
    private CoreDecimal X_OCT_M_AMT;
    private CoreDecimal X_OCT_W_AMT;
    private CoreDecimal X_NOV_M_CLMS;
    private CoreDecimal X_NOV_W_CLMS;
    private CoreDecimal X_NOV_M_AMT;
    private CoreDecimal X_NOV_W_AMT;
    private CoreDecimal X_DEC_M_CLMS;
    private CoreDecimal X_DEC_W_CLMS;
    private CoreDecimal X_DEC_M_AMT;
    private CoreDecimal X_DEC_W_AMT;
    private CoreDecimal X_JAN_M_CLMS;
    private CoreDecimal X_JAN_W_CLMS;
    private CoreDecimal X_JAN_M_AMT;
    private CoreDecimal X_JAN_W_AMT;
    private CoreDecimal X_FEB_M_CLMS;
    private CoreDecimal X_FEB_W_CLMS;
    private CoreDecimal X_FEB_M_AMT;
    private CoreDecimal X_FEB_W_AMT;
    private CoreDecimal X_MAR_M_CLMS;
    private CoreDecimal X_MAR_W_CLMS;
    private CoreDecimal X_MAR_M_AMT;
    private CoreDecimal X_MAR_W_AMT;
    private CoreDecimal X_APR_M_CLMS;
    private CoreDecimal X_APR_W_CLMS;
    private CoreDecimal X_APR_M_AMT;
    private CoreDecimal X_APR_W_AMT;
    private CoreDecimal X_MAY_M_CLMS;
    private CoreDecimal X_MAY_W_CLMS;
    private CoreDecimal X_MAY_M_AMT;
    private CoreDecimal X_MAY_W_AMT;
    private CoreDecimal X_JUN_M_CLMS;
    private CoreDecimal X_JUN_W_CLMS;
    private CoreDecimal X_JUN_M_AMT;
    private CoreDecimal X_JUN_W_AMT;
    private CoreDecimal X_TOT_M_CLMS;
    private CoreDecimal X_TOT_W_CLMS;
    private CoreDecimal X_TOT_M_AMT;
    private CoreDecimal X_TOT_W_AMT;
    private CoreDecimal X_TOT_CLMS;
    private CoreDecimal X_TOT_AMT;
    private DCharacter COMMA = new DCharacter("COMMA", 1);
    private void COMMA_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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
    private SqlFileObject fleLEENACLAIMS;


    #endregion


    #region "Standard Generated Procedures(LEENACLAIMS_ONE_1)"


    #region "Automatic Item Initialization(LEENACLAIMS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(LEENACLAIMS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:50 PM

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
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleLEENACLAIMS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(LEENACLAIMS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:36:50 PM

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
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleLEENACLAIMS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(LEENACLAIMS_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF001_BATCH_CONTROL_FILE.QTPForMissing())
            {
                // --> GET F001_BATCH_CONTROL_FILE <--

                fleF001_BATCH_CONTROL_FILE.GetData();
                // --> End GET F001_BATCH_CONTROL_FILE <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append(((QDesign.NConvert(QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 1, 2)))));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET ICONST_MSTR_REC <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleF001_BATCH_CONTROL_FILE.GetSortValue("BATCTRL_CLINIC_NBR"));



                        }

                    }

                }

            }

            while (Sort(fleF001_BATCH_CONTROL_FILE, fleICONST_MSTR_REC))
            {
                if ((QDesign.NULL(X_MM.Value) == "07" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_JUL_M_CLMS.Value = X_JUL_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "07" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_JUL_W_CLMS.Value = X_JUL_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "07" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_JUL_M_AMT.Value = X_JUL_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "07" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_JUL_W_AMT.Value = X_JUL_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "08" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_AUG_M_CLMS.Value = X_AUG_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "08" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_AUG_W_CLMS.Value = X_AUG_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "08" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_AUG_M_AMT.Value = X_AUG_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "08" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_AUG_W_AMT.Value = X_AUG_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "09" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_SEP_M_CLMS.Value = X_SEP_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "09" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_SEP_W_CLMS.Value = X_SEP_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "09" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_SEP_M_AMT.Value = X_SEP_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "09" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_SEP_W_AMT.Value = X_SEP_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "10" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_OCT_M_CLMS.Value = X_OCT_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "10" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_OCT_W_CLMS.Value = X_OCT_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "10" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_OCT_M_AMT.Value = X_OCT_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "10" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_OCT_W_AMT.Value = X_OCT_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "11" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_NOV_M_CLMS.Value = X_NOV_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "11" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_NOV_W_CLMS.Value = X_NOV_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "11" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_NOV_M_AMT.Value = X_NOV_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "11" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_NOV_W_AMT.Value = X_NOV_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "12" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_DEC_M_CLMS.Value = X_DEC_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "12" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_DEC_W_CLMS.Value = X_DEC_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "12" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_DEC_M_AMT.Value = X_DEC_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "12" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_DEC_W_AMT.Value = X_DEC_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "01" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_JAN_M_CLMS.Value = X_JAN_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "01" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_JAN_W_CLMS.Value = X_JAN_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "01" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_JAN_M_AMT.Value = X_JAN_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "01" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_JAN_W_AMT.Value = X_JAN_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "02" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_FEB_M_CLMS.Value = X_FEB_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "02" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_FEB_W_CLMS.Value = X_FEB_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "02" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_FEB_M_AMT.Value = X_FEB_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "02" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_FEB_W_AMT.Value = X_FEB_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "03" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_MAR_M_CLMS.Value = X_MAR_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "03" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_MAR_W_CLMS.Value = X_MAR_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "03" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_MAR_M_AMT.Value = X_MAR_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "03" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_MAR_W_AMT.Value = X_MAR_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "04" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_APR_M_CLMS.Value = X_APR_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "04" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_APR_W_CLMS.Value = X_APR_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "04" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_APR_M_AMT.Value = X_APR_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "04" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_APR_W_AMT.Value = X_APR_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "05" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_MAY_M_CLMS.Value = X_MAY_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "05" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_MAY_W_CLMS.Value = X_MAY_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "05" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_MAY_M_AMT.Value = X_MAY_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "05" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_MAY_W_AMT.Value = X_MAY_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "06" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_JUN_M_CLMS.Value = X_JUN_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "06" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_JUN_W_CLMS.Value = X_JUN_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if ((QDesign.NULL(X_MM.Value) == "06" & QDesign.NULL(X_TYPE.Value) == "CLM"))
                {
                    X_JUN_M_AMT.Value = X_JUN_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if ((QDesign.NULL(X_MM.Value) == "06" & QDesign.NULL(X_TYPE.Value) == "WEB"))
                {
                    X_JUN_W_AMT.Value = X_JUN_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if (QDesign.NULL(X_TYPE.Value) == "CLM")
                {
                    X_TOT_M_CLMS.Value = X_TOT_M_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if (QDesign.NULL(X_TYPE.Value) == "WEB")
                {
                    X_TOT_W_CLMS.Value = X_TOT_W_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                }
                if (QDesign.NULL(X_TYPE.Value) == "CLM")
                {
                    X_TOT_M_AMT.Value = X_TOT_M_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                if (QDesign.NULL(X_TYPE.Value) == "WEB")
                {
                    X_TOT_W_AMT.Value = X_TOT_W_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);
                }
                X_TOT_CLMS.Value = X_TOT_CLMS.Value + fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH");
                X_TOT_AMT.Value = X_TOT_AMT.Value + QDesign.Round(fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_AR_DUE") / 100, 0, RoundOptionTypes.Near);

                SubFile(ref m_trnTRANS_UPDATE, ref fleLEENACLAIMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"), SubFileType.Portable, fleF001_BATCH_CONTROL_FILE, "BATCTRL_CLINIC_NBR", COMMA, fleICONST_MSTR_REC, X_JUL_M_CLMS, X_JUL_W_CLMS,
                X_JUL_M_AMT, X_JUL_W_AMT, X_AUG_M_CLMS, X_AUG_W_CLMS, X_AUG_M_AMT, X_AUG_W_AMT, X_SEP_M_CLMS, X_SEP_W_CLMS, X_SEP_M_AMT, X_SEP_W_AMT,
                X_OCT_M_CLMS, X_OCT_W_CLMS, X_OCT_M_AMT, X_OCT_W_AMT, X_NOV_M_CLMS, X_NOV_W_CLMS, X_NOV_M_AMT, X_NOV_W_AMT, X_DEC_M_CLMS, X_DEC_W_CLMS,
                X_DEC_M_AMT, X_DEC_W_AMT, X_JAN_M_CLMS, X_JAN_W_CLMS, X_JAN_M_AMT, X_JAN_W_AMT, X_FEB_M_CLMS, X_FEB_W_CLMS, X_FEB_M_AMT, X_FEB_W_AMT,
                X_MAR_M_CLMS, X_MAR_W_CLMS, X_MAR_M_AMT, X_MAR_W_AMT, X_APR_M_CLMS, X_APR_W_CLMS, X_APR_M_AMT, X_APR_W_AMT, X_MAY_M_CLMS, X_MAY_W_CLMS,
                X_MAY_M_AMT, X_MAY_W_AMT, X_JUN_M_CLMS, X_JUN_W_CLMS, X_JUN_M_AMT, X_JUN_W_AMT, X_TOT_M_CLMS, X_TOT_W_CLMS, X_TOT_M_AMT, X_TOT_W_AMT,
                X_TOT_CLMS, X_TOT_AMT, X_CR);


                Reset(ref X_JUL_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JUL_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JUL_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JUL_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_AUG_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_AUG_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_AUG_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_AUG_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_SEP_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_SEP_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_SEP_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_SEP_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_OCT_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_OCT_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_OCT_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_OCT_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_NOV_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_NOV_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_NOV_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_NOV_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_DEC_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_DEC_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_DEC_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_DEC_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JAN_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JAN_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JAN_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JAN_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_FEB_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_FEB_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_FEB_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_FEB_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_MAR_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_MAR_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_MAR_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_MAR_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_APR_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_APR_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_APR_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_APR_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_MAY_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_MAY_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_MAY_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_MAY_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JUN_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JUN_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JUN_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_JUN_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_TOT_M_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_TOT_W_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_TOT_M_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_TOT_W_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_TOT_CLMS, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));
                Reset(ref X_TOT_AMT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_CLINIC_NBR"));

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




