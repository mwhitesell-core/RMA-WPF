
#region "Screen Comments"

// doc: purge_f071.qts
// doc : purge the rma claim numbers
// doc : enter 6 digit doc number and @ sign to delete all his accounting nubmers
// if you enter 6 digit doc# and 8 digit accounting number it will only
// delete that one claim


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class PURGE_F071 : BaseClassControl
{

    private PURGE_F071 m_PURGE_F071;

    public PURGE_F071(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public PURGE_F071(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_PURGE_F071 != null))
        {
            m_PURGE_F071.CloseTransactionObjects();
            m_PURGE_F071 = null;
        }
    }

    public PURGE_F071 GetPURGE_F071(int Level)
    {
        if (m_PURGE_F071 == null)
        {
            m_PURGE_F071 = new PURGE_F071("PURGE_F071", Level);
        }
        else
        {
            m_PURGE_F071.ResetValues();
        }
        return m_PURGE_F071;
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

            PURGE_F071_UPDATE_F071_1 UPDATE_F071_1 = new PURGE_F071_UPDATE_F071_1(Name, Level);
            UPDATE_F071_1.Run();
            UPDATE_F071_1.Dispose();
            UPDATE_F071_1 = null;



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



public class PURGE_F071_UPDATE_F071_1 : PURGE_F071
{

    public PURGE_F071_UPDATE_F071_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF071_CLIENT_RMA_CLAIM_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F071_CLIENT_RMA_CLAIM_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(PURGE_F071_UPDATE_F071_1)"

    private SqlFileObject fleF071_CLIENT_RMA_CLAIM_NBR;



    #endregion


    #region "Standard Generated Procedures(PURGE_F071_UPDATE_F071_1)"


    #region "Automatic Item Initialization(PURGE_F071_UPDATE_F071_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(PURGE_F071_UPDATE_F071_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:12 PM

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
        fleF071_CLIENT_RMA_CLAIM_NBR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(PURGE_F071_UPDATE_F071_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:12 PM

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
            fleF071_CLIENT_RMA_CLAIM_NBR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PURGE_F071_UPDATE_F071_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F071_1");

            while (fleF071_CLIENT_RMA_CLAIM_NBR.QTPForMissing())
            {
                // --> GET F071_CLIENT_RMA_CLAIM_NBR <--

                fleF071_CLIENT_RMA_CLAIM_NBR.GetData();
                // --> End GET F071_CLIENT_RMA_CLAIM_NBR <--


                if (Transaction())
                {
                    fleF071_CLIENT_RMA_CLAIM_NBR.OutPut(OutPutType.Delete);

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
            EndRequest("UPDATE_F071_1");

        }

    }







    #endregion


}
//UPDATE_F071_1








