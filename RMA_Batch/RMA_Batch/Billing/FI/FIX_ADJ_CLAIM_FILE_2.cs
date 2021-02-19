
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class FIX_ADJ_CLAIM_FILE_2 : BaseClassControl
{

    private FIX_ADJ_CLAIM_FILE_2 m_FIX_ADJ_CLAIM_FILE_2;

    public FIX_ADJ_CLAIM_FILE_2(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleADJ_CLAIM_FILE_FIXED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "ADJ_CLAIM_FILE_FIXED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleADJ_CLAIM_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "ADJ_CLAIM_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleADJ_CLAIM_FILE.SetItemFinals += fleADJ_CLAIM_FILE_SetItemFinals;

    }

    public FIX_ADJ_CLAIM_FILE_2(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleADJ_CLAIM_FILE_FIXED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "ADJ_CLAIM_FILE_FIXED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleADJ_CLAIM_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "ADJ_CLAIM_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleADJ_CLAIM_FILE.SetItemFinals += fleADJ_CLAIM_FILE_SetItemFinals;

    }

    public override void Dispose()
    {
        if ((m_FIX_ADJ_CLAIM_FILE_2 != null))
        {
            m_FIX_ADJ_CLAIM_FILE_2.CloseTransactionObjects();
            m_FIX_ADJ_CLAIM_FILE_2 = null;
        }
    }

    public FIX_ADJ_CLAIM_FILE_2 GetFIX_ADJ_CLAIM_FILE_2(int Level)
    {
        if (m_FIX_ADJ_CLAIM_FILE_2 == null)
        {
            m_FIX_ADJ_CLAIM_FILE_2 = new FIX_ADJ_CLAIM_FILE_2("FIX_ADJ_CLAIM_FILE_2", Level);
        }
        else
        {
            m_FIX_ADJ_CLAIM_FILE_2.ResetValues();
        }
        return m_FIX_ADJ_CLAIM_FILE_2;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleADJ_CLAIM_FILE_FIXED;
    private SqlFileObject fleADJ_CLAIM_FILE;

    private void fleADJ_CLAIM_FILE_SetItemFinals()
    {

        try
        {
            fleADJ_CLAIM_FILE.set_SetValue("ADJ_OMA_CD_SUFF", fleADJ_CLAIM_FILE_FIXED.GetStringValue("FIXED_ADJ_OMA_CD_SUFF"));
            fleADJ_CLAIM_FILE.set_SetValue("ADJ_SERV_DATE", fleADJ_CLAIM_FILE_FIXED.GetNumericDateValue("FIXED_ADJ_SERV_DATE"));


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
            Request("FIX_ADJ_CLAIM_FILE_2");

            while (fleADJ_CLAIM_FILE_FIXED.QTPForMissing())
            {
                // --> GET ADJ_CLAIM_FILE_FIXED <--

                fleADJ_CLAIM_FILE_FIXED.GetData();
                // --> End GET ADJ_CLAIM_FILE_FIXED <--


                if (Transaction())
                {
                    fleADJ_CLAIM_FILE.OutPut(OutPutType.Add);

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
            EndRequest("FIX_ADJ_CLAIM_FILE_2");

        }

    }


    #region "Standard Generated Procedures(FIX_ADJ_CLAIM_FILE_2_FIX_ADJ_CLAIM_FILE_2)"

    #region "Transaction Management Procedures(FIX_ADJ_CLAIM_FILE_2_FIX_ADJ_CLAIM_FILE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:56 PM

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
        fleADJ_CLAIM_FILE_FIXED.Transaction = m_trnTRANS_UPDATE;
        fleADJ_CLAIM_FILE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(FIX_ADJ_CLAIM_FILE_2_FIX_ADJ_CLAIM_FILE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:56 PM

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
            fleADJ_CLAIM_FILE_FIXED.Dispose();
            fleADJ_CLAIM_FILE.Dispose();


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

