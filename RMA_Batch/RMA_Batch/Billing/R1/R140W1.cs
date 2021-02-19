
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class R140W1 : BaseClassControl
{

    private R140W1 m_R140W1;

    public R140W1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public R140W1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_R140W1 != null))
        {
            m_R140W1.CloseTransactionObjects();
            m_R140W1 = null;
        }
    }

    public R140W1 GetR140W1(int Level)
    {
        if (m_R140W1 == null)
        {
            m_R140W1 = new R140W1("R140W1", Level);
        }
        else
        {
            m_R140W1.ResetValues();
        }
        return m_R140W1;
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

            R140W1_R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1 R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1 = new R140W1_R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1(Name, Level);
            R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1.Run();
            R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1.Dispose();
            R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1 = null;

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



public class R140W1_R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1 : R140W1
{

    public R140W1_R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleAFP_A2S_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "AFP_A2S_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleTMP_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "TMP_GOVERNANCE_PAYMENTS_FILE", "TMP_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_ADD.SetItemFinals += fleTMP_ADD_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(R140W1_R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1)"

    private SqlFileObject fleAFP_A2S_FILE;
    private SqlFileObject fleTMP_ADD;

    private void fleTMP_ADD_SetItemFinals()
    {

        try
        {
            fleTMP_ADD.set_SetValue("DOC_OHIP_NBR", QDesign.NConvert(fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_SOLO")));
            fleTMP_ADD.set_SetValue("AFP_SOLO_NAME", fleAFP_A2S_FILE.GetStringValue("AFP_SOLO_NAME"));
            fleTMP_ADD.set_SetValue("DOC_AFP_PAYM_GROUP", fleAFP_A2S_FILE.GetStringValue("DOC_AFP_PAYM_GROUP"));


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


    #region "Standard Generated Procedures(R140W1_R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1)"


    #region "Automatic Item Initialization(R140W1_R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R140W1_R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:37 PM

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
        fleAFP_A2S_FILE.Transaction = m_trnTRANS_UPDATE;
        fleTMP_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R140W1_R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:37 PM

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
            fleAFP_A2S_FILE.Dispose();
            fleTMP_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R140W1_R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1)"


    public void Run()
    {

        try
        {
            Request("R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1");

            while (fleAFP_A2S_FILE.QTPForMissing())
            {
                // --> GET AFP_A2S_FILE <--

                fleAFP_A2S_FILE.GetData();
                // --> End GET AFP_A2S_FILE <--


                if (Transaction())
                {

                    Sort(fleAFP_A2S_FILE.GetSortValue("DOC_AFP_PAYM_GROUP"), fleAFP_A2S_FILE.GetSortValue("DOC_AFP_PAYM_SOLO"));



                }

            }

            while (Sort(fleAFP_A2S_FILE))
            {
                fleTMP_ADD.OutPut(OutPutType.Add, fleAFP_A2S_FILE.At("DOC_AFP_PAYM_GROUP") || fleAFP_A2S_FILE.At("DOC_AFP_PAYM_SOLO"), null);

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
            EndRequest("R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1");

        }

    }







    #endregion


}
//R140W_PUT_1_REC_IN_TMP_FILE_FOR_EACH_DOC_1




