
#region "Screen Comments"

// #> program-id.     u085.qts
// ((C)) Dyad Technologies
// program purpose : determine how records in ohip-run-dates file
// MODIFICATION HISTORY
// 11/Mar/08 MC   -  original  


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U085 : BaseClassControl
{

    private U085 m_U085;

    public U085(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U085(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U085 != null))
        {
            m_U085.CloseTransactionObjects();
            m_U085 = null;
        }
    }

    public U085 GetU085(int Level)
    {
        if (m_U085 == null)
        {
            m_U085 = new U085("U085", Level);
        }
        else
        {
            m_U085.ResetValues();
        }
        return m_U085;
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

            U085_NBR_OF_RECORDS_1 NBR_OF_RECORDS_1 = new U085_NBR_OF_RECORDS_1(Name, Level);
            NBR_OF_RECORDS_1.Run();
            NBR_OF_RECORDS_1.Dispose();
            NBR_OF_RECORDS_1 = null;

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



public class U085_NBR_OF_RECORDS_1 : U085
{

    public U085_NBR_OF_RECORDS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleOHIP_RUN_DATES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "OHIP_RUN_DATES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        REC_COUNT = new CoreDecimal("REC_COUNT", 6, this);
        fleTMP_COUNTERS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_COUNTERS.SetItemFinals += fleTMP_COUNTERS_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U085_NBR_OF_RECORDS_1)"

    private SqlFileObject fleOHIP_RUN_DATES;
    private CoreDecimal REC_COUNT;
    private SqlFileObject fleTMP_COUNTERS;

    private void fleTMP_COUNTERS_SetItemFinals()
    {

        try
        {
            fleTMP_COUNTERS.set_SetValue("TMP_COUNTER_KEY", 1);
            fleTMP_COUNTERS.set_SetValue("TMP_COUNTER_1", REC_COUNT.Value - 1);


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


    #region "Standard Generated Procedures(U085_NBR_OF_RECORDS_1)"


    #region "Automatic Item Initialization(U085_NBR_OF_RECORDS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U085_NBR_OF_RECORDS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:03 PM

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
        fleOHIP_RUN_DATES.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U085_NBR_OF_RECORDS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:03 PM

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
            fleOHIP_RUN_DATES.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U085_NBR_OF_RECORDS_1)"


    public void Run()
    {

        try
        {
            Request("NBR_OF_RECORDS_1");

            while (fleOHIP_RUN_DATES.QTPForMissing())
            {
                // --> GET OHIP_RUN_DATES <--

                fleOHIP_RUN_DATES.GetData();
                // --> End GET OHIP_RUN_DATES <--


                if (Transaction())
                {
                    REC_COUNT.Value = REC_COUNT.Value + 1;
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
            EndRequest("NBR_OF_RECORDS_1");

        }

    }







    #endregion


}
//NBR_OF_RECORDS_1




