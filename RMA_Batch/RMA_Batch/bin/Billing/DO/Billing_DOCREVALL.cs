
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Billing_DOCREVALL : BaseClassControl
{

    private Billing_DOCREVALL m_Billing_DOCREVALL;

    public Billing_DOCREVALL(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        TOT_AMT_YTD = new CoreDecimal("TOT_AMT_YTD", 10, this);
        TOT_MISC = new CoreDecimal("TOT_MISC", 10, this);
        TOTALS = new CoreDecimal("TOTALS", 10, this);
        fleBilling_DOCREVALL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "Billing_DOCREVALL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        IN_AMT_YTD.GetValue += IN_AMT_YTD_GetValue;
        OUT_AMT_YTD.GetValue += OUT_AMT_YTD_GetValue;
        IN_MISC.GetValue += IN_MISC_GetValue;
        OUT_MISC.GetValue += OUT_MISC_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }

    public Billing_DOCREVALL(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        TOT_AMT_YTD = new CoreDecimal("TOT_AMT_YTD", 10, this);
        TOT_MISC = new CoreDecimal("TOT_MISC", 10, this);
        TOTALS = new CoreDecimal("TOTALS", 10, this);
        fleBilling_DOCREVALL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "Billing_DOCREVALL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        IN_AMT_YTD.GetValue += IN_AMT_YTD_GetValue;
        OUT_AMT_YTD.GetValue += OUT_AMT_YTD_GetValue;
        IN_MISC.GetValue += IN_MISC_GetValue;
        OUT_MISC.GetValue += OUT_MISC_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

    }

    public override void Dispose()
    {
        if ((m_Billing_DOCREVALL != null))
        {
            m_Billing_DOCREVALL.CloseTransactionObjects();
            m_Billing_DOCREVALL = null;
        }
    }

    public Billing_DOCREVALL GetBilling_DOCREVALL(int Level)
    {
        if (m_Billing_DOCREVALL == null)
        {
            m_Billing_DOCREVALL = new Billing_DOCREVALL("Billing_DOCREVALL", Level);
        }
        else
        {
            m_Billing_DOCREVALL.ResetValues();
        }
        return m_Billing_DOCREVALL;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleF050_DOC_REVENUE_MSTR_HISTORY;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("EP_YR")) == 2015 & QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetNumericDateValue("ICONST_DATE_PERIOD_END")) == 20160630)
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

    private DDecimal IN_AMT_YTD = new DDecimal("IN_AMT_YTD", 10);
    private void IN_AMT_YTD_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION")) != "MISC")
            {
                CurrentValue = fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_IN_REC");
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
    private DDecimal OUT_AMT_YTD = new DDecimal("OUT_AMT_YTD", 10);
    private void OUT_AMT_YTD_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION")) != "MISC")
            {
                CurrentValue = fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_OUT_REC");
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
    private CoreDecimal TOT_AMT_YTD;
    private DDecimal IN_MISC = new DDecimal("IN_MISC", 10);
    private void IN_MISC_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION")) == "MISC")
            {
                CurrentValue = fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_IN_REC");
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
    private DDecimal OUT_MISC = new DDecimal("OUT_MISC", 10);
    private void OUT_MISC_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF050_DOC_REVENUE_MSTR_HISTORY.GetStringValue("DOCREV_LOCATION")) == "MISC")
            {
                CurrentValue = fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_OUT_REC");
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
    private CoreDecimal TOT_MISC;
    private CoreDecimal TOTALS;
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
    private SqlFileObject fleBilling_DOCREVALL;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("Billing_DOCREVALL");

            while (fleF050_DOC_REVENUE_MSTR_HISTORY.QTPForMissing())
            {
                // --> GET F050_DOC_REVENUE_MSTR_HISTORY <--

                fleF050_DOC_REVENUE_MSTR_HISTORY.GetData();
                // --> End GET F050_DOC_REVENUE_MSTR_HISTORY <--


                if (Transaction())
                {

                     if (Select_If())
                    {

                        Sort(fleF050_DOC_REVENUE_MSTR_HISTORY.GetSortValue("DOCREV_CLINIC_1_2"));



                    }

                }

            }

            while (Sort(fleF050_DOC_REVENUE_MSTR_HISTORY))
            {
                TOT_AMT_YTD.Value = TOT_AMT_YTD.Value + IN_AMT_YTD.Value + OUT_AMT_YTD.Value;
                TOT_MISC.Value = TOT_MISC.Value + IN_MISC.Value + OUT_MISC.Value;
                TOTALS.Value = TOTALS.Value + fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_OUT_REC") + fleF050_DOC_REVENUE_MSTR_HISTORY.GetDecimalValue("DOCREV_YTD_IN_REC");

                SubFile(ref m_trnTRANS_UPDATE, ref fleBilling_DOCREVALL, fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_CLINIC_1_2"), SubFileType.Keep, fleF050_DOC_REVENUE_MSTR_HISTORY, "DOCREV_CLINIC_1_2", COMMA, TOT_AMT_YTD, TOT_MISC, TOTALS,
                X_CR);


                Reset(ref TOT_AMT_YTD, fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_CLINIC_1_2"));
                Reset(ref TOT_MISC, fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_CLINIC_1_2"));
                Reset(ref TOTALS, fleF050_DOC_REVENUE_MSTR_HISTORY.At("DOCREV_CLINIC_1_2"));

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
            EndRequest("Billing_DOCREVALL");

        }

    }


    #region "Standard Generated Procedures(Billing_DOCREVALL_Billing_DOCREVALL)"

    #region "Transaction Management Procedures(Billing_DOCREVALL_Billing_DOCREVALL)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:58 PM

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
        fleF050_DOC_REVENUE_MSTR_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleBilling_DOCREVALL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_DOCREVALL_Billing_DOCREVALL)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:58 PM

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
            fleF050_DOC_REVENUE_MSTR_HISTORY.Dispose();
            fleBilling_DOCREVALL.Dispose();


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


    public override bool RunQTP()
    {


        try
        {

            Run();

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

