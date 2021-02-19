
#region "Screen Comments"

// Program r140_a1.qts
// 2007/apr/11 b.e. took logic of r140_a2.qts and merged into this pgm


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class R140_A1 : BaseClassControl
{

    private R140_A1 m_R140_A1;

    public R140_A1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleAFP_A2G_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "AFP_A2G_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_PAYMENT_AMT_SUBTOTAL = new CoreDecimal("X_PAYMENT_AMT_SUBTOTAL", 6, this);
        X_SUBMISSION_AMT_SUBTOTAL = new CoreDecimal("X_SUBMISSION_AMT_SUBTOTAL", 6, this);
        fleR140_A1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R140_A1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_COUNTERS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        X_PAYMENT_AMT.GetValue += X_PAYMENT_AMT_GetValue;
        X_SUBMISSION_AMT.GetValue += X_SUBMISSION_AMT_GetValue;
        fleTMP_COUNTERS.SetItemFinals += fleTMP_COUNTERS_SetItemFinals;

    }

    public R140_A1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleAFP_A2G_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "AFP_A2G_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_PAYMENT_AMT_SUBTOTAL = new CoreDecimal("X_PAYMENT_AMT_SUBTOTAL", 6, this);
        X_SUBMISSION_AMT_SUBTOTAL = new CoreDecimal("X_SUBMISSION_AMT_SUBTOTAL", 6, this);
        fleR140_A1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R140_A1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_COUNTERS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        X_PAYMENT_AMT.GetValue += X_PAYMENT_AMT_GetValue;
        X_SUBMISSION_AMT.GetValue += X_SUBMISSION_AMT_GetValue;
        fleTMP_COUNTERS.SetItemFinals += fleTMP_COUNTERS_SetItemFinals;

    }

    public override void Dispose()
    {
        if ((m_R140_A1 != null))
        {
            m_R140_A1.CloseTransactionObjects();
            m_R140_A1 = null;
        }
    }

    public R140_A1 GetR140_A1(int Level)
    {
        if (m_R140_A1 == null)
        {
            m_R140_A1 = new R140_A1("R140_A1", Level);
        }
        else
        {
            m_R140_A1.ResetValues();
        }
        return m_R140_A1;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleAFP_A2G_FILE;
    private DDecimal X_PAYMENT_AMT = new DDecimal("X_PAYMENT_AMT", 6);
    private void X_PAYMENT_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleAFP_A2G_FILE.GetStringValue("AFP_PAYMENT_SIGN")) == QDesign.NULL(" "))
            {
                CurrentValue = fleAFP_A2G_FILE.GetDecimalValue("AFP_PAYMENT_AMT");
            }
            else
            {
                CurrentValue = 0 - fleAFP_A2G_FILE.GetDecimalValue("AFP_PAYMENT_AMT");
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
    private DDecimal X_SUBMISSION_AMT = new DDecimal("X_SUBMISSION_AMT", 6);
    private void X_SUBMISSION_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleAFP_A2G_FILE.GetStringValue("AFP_SUBMISSION_SIGN")) == QDesign.NULL(" "))
            {
                CurrentValue = fleAFP_A2G_FILE.GetDecimalValue("AFP_SUBMISSION_AMT");
            }
            else
            {
                CurrentValue = 0 - fleAFP_A2G_FILE.GetDecimalValue("AFP_SUBMISSION_AMT");
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
    private CoreDecimal X_PAYMENT_AMT_SUBTOTAL;
    private CoreDecimal X_SUBMISSION_AMT_SUBTOTAL;
    private SqlFileObject fleR140_A1;
    private SqlFileObject fleTMP_COUNTERS;

    private void fleTMP_COUNTERS_SetItemFinals()
    {

        try
        {
            fleTMP_COUNTERS.set_SetValue("TMP_COUNTER_KEY", 1);
            fleTMP_COUNTERS.set_SetValue("TMP_COUNTER_1", X_PAYMENT_AMT.Value);
            fleTMP_COUNTERS.set_SetValue("TMP_COUNTER_2", X_SUBMISSION_AMT.Value);


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



    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("R140_A1");

            while (fleAFP_A2G_FILE.QTPForMissing())
            {
                // --> GET AFP_A2G_FILE <--

                fleAFP_A2G_FILE.GetData();
                // --> End GET AFP_A2G_FILE <--


                if (Transaction())
                {
                    X_PAYMENT_AMT_SUBTOTAL.Value = X_PAYMENT_AMT_SUBTOTAL.Value + X_PAYMENT_AMT.Value;
                    X_SUBMISSION_AMT_SUBTOTAL.Value = X_SUBMISSION_AMT_SUBTOTAL.Value + X_SUBMISSION_AMT.Value;
                    SubFile(ref m_trnTRANS_UPDATE, ref fleR140_A1, SubFileType.Keep, fleAFP_A2G_FILE, "DOC_AFP_PAYM_GROUP", "AFP_PAYMENT_PERCENTAGE", X_PAYMENT_AMT, X_PAYMENT_AMT_SUBTOTAL, X_SUBMISSION_AMT, X_SUBMISSION_AMT_SUBTOTAL);

                    fleTMP_COUNTERS.OutPut(OutPutType.Add, AtFinal(), null);

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
            EndRequest("R140_A1");

        }

    }


    #region "Standard Generated Procedures(R140_A1_R140_A1)"

    #region "Transaction Management Procedures(R140_A1_R140_A1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:39 PM

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
        fleAFP_A2G_FILE.Transaction = m_trnTRANS_UPDATE;
        fleR140_A1.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R140_A1_R140_A1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:39 PM

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
            fleAFP_A2G_FILE.Dispose();
            fleR140_A1.Dispose();
            fleTMP_COUNTERS.Dispose();


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

