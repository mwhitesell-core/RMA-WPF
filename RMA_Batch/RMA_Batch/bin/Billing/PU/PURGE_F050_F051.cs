
#region "Screen Comments"

// DOC: PURGE_F050_F051.QTS
// DOC:
// DOC: RUN FOR: OPERATIONS
// PROGRAM PURPOSE : PURGE F050 F051 AT YEAREND ALL CLINICS
// EXCEPT 83 TO BE PURGES
// DATE       WHO       DESCRIPTION
// 97/09/03   YASEMIN   ORIGINAL
// 2003/may/03 yas      add clinics 91,92,93,94,96
// 2004/mar/03 yas      add clinics 43 and 84          
// 2004/mar/17 M.C.     rewrite the program
// 2006/may/19 yas      modify to include clinic 83


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class PURGE_F050_F051 : BaseClassControl
{

    private PURGE_F050_F051 m_PURGE_F050_F051;

    public PURGE_F050_F051(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public PURGE_F050_F051(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_PURGE_F050_F051 != null))
        {
            m_PURGE_F050_F051.CloseTransactionObjects();
            m_PURGE_F050_F051 = null;
        }
    }

    public PURGE_F050_F051 GetPURGE_F050_F051(int Level)
    {
        if (m_PURGE_F050_F051 == null)
        {
            m_PURGE_F050_F051 = new PURGE_F050_F051("PURGE_F050_F051", Level);
        }
        else
        {
            m_PURGE_F050_F051.ResetValues();
        }
        return m_PURGE_F050_F051;
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

            PURGE_F050_F051_PURGE_F050_1 PURGE_F050_1 = new PURGE_F050_F051_PURGE_F050_1(Name, Level);
            PURGE_F050_1.Run();
            PURGE_F050_1.Dispose();
            PURGE_F050_1 = null;

            PURGE_F050_F051_PURGE_F050TP_2 PURGE_F050TP_2 = new PURGE_F050_F051_PURGE_F050TP_2(Name, Level);
            PURGE_F050TP_2.Run();
            PURGE_F050TP_2.Dispose();
            PURGE_F050TP_2 = null;

            PURGE_F050_F051_PURGE_F051_3 PURGE_F051_3 = new PURGE_F050_F051_PURGE_F051_3(Name, Level);
            PURGE_F051_3.Run();
            PURGE_F051_3.Dispose();
            PURGE_F051_3 = null;

            PURGE_F050_F051_PURGE_F051TP_4 PURGE_F051TP_4 = new PURGE_F050_F051_PURGE_F051TP_4(Name, Level);
            PURGE_F051TP_4.Run();
            PURGE_F051TP_4.Dispose();
            PURGE_F051TP_4 = null;

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



public class PURGE_F050_F051_PURGE_F050_1 : PURGE_F050_F051
{

    public PURGE_F050_F051_PURGE_F050_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(PURGE_F050_F051_PURGE_F050_1)"

    private SqlFileObject fleF050_DOC_REVENUE_MSTR;


    #endregion


    #region "Standard Generated Procedures(PURGE_F050_F051_PURGE_F050_1)"


    #region "Automatic Item Initialization(PURGE_F050_F051_PURGE_F050_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(PURGE_F050_F051_PURGE_F050_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:04 PM

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
        fleF050_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(PURGE_F050_F051_PURGE_F050_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
            fleF050_DOC_REVENUE_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PURGE_F050_F051_PURGE_F050_1)"


    public void Run()
    {

        try
        {
            Request("PURGE_F050_1");

            while (fleF050_DOC_REVENUE_MSTR.QTPForMissing())
            {
                // --> GET F050_DOC_REVENUE_MSTR <--

                fleF050_DOC_REVENUE_MSTR.GetData();
                // --> End GET F050_DOC_REVENUE_MSTR <--


                if (Transaction())
                {
                    fleF050_DOC_REVENUE_MSTR.OutPut(OutPutType.Delete);

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
            EndRequest("PURGE_F050_1");

        }

    }







    #endregion


}
//PURGE_F050_1



public class PURGE_F050_F051_PURGE_F050TP_2 : PURGE_F050_F051
{

    public PURGE_F050_F051_PURGE_F050TP_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050TP_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(PURGE_F050_F051_PURGE_F050TP_2)"

    private SqlFileObject fleF050TP_DOC_REVENUE_MSTR;


    #endregion


    #region "Standard Generated Procedures(PURGE_F050_F051_PURGE_F050TP_2)"


    #region "Automatic Item Initialization(PURGE_F050_F051_PURGE_F050TP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(PURGE_F050_F051_PURGE_F050TP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
        fleF050TP_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(PURGE_F050_F051_PURGE_F050TP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
            fleF050TP_DOC_REVENUE_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PURGE_F050_F051_PURGE_F050TP_2)"


    public void Run()
    {

        try
        {
            Request("PURGE_F050TP_2");

            while (fleF050TP_DOC_REVENUE_MSTR.QTPForMissing())
            {
                // --> GET F050TP_DOC_REVENUE_MSTR <--

                fleF050TP_DOC_REVENUE_MSTR.GetData();
                // --> End GET F050TP_DOC_REVENUE_MSTR <--


                if (Transaction())
                {
                    fleF050TP_DOC_REVENUE_MSTR.OutPut(OutPutType.Delete);

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
            EndRequest("PURGE_F050TP_2");

        }

    }







    #endregion


}
//PURGE_F050TP_2



public class PURGE_F050_F051_PURGE_F051_3 : PURGE_F050_F051
{

    public PURGE_F050_F051_PURGE_F051_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF051_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(PURGE_F050_F051_PURGE_F051_3)"

    private SqlFileObject fleF051_DOC_CASH_MSTR;


    #endregion


    #region "Standard Generated Procedures(PURGE_F050_F051_PURGE_F051_3)"


    #region "Automatic Item Initialization(PURGE_F050_F051_PURGE_F051_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(PURGE_F050_F051_PURGE_F051_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
        fleF051_DOC_CASH_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(PURGE_F050_F051_PURGE_F051_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
            fleF051_DOC_CASH_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PURGE_F050_F051_PURGE_F051_3)"


    public void Run()
    {

        try
        {
            Request("PURGE_F051_3");

            while (fleF051_DOC_CASH_MSTR.QTPForMissing())
            {
                // --> GET F051_DOC_CASH_MSTR <--

                fleF051_DOC_CASH_MSTR.GetData();
                // --> End GET F051_DOC_CASH_MSTR <--


                if (Transaction())
                {
                    fleF051_DOC_CASH_MSTR.OutPut(OutPutType.Delete);

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
            EndRequest("PURGE_F051_3");

        }

    }







    #endregion


}
//PURGE_F051_3



public class PURGE_F050_F051_PURGE_F051TP_4 : PURGE_F050_F051
{

    public PURGE_F050_F051_PURGE_F051TP_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF051TP_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051TP_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(PURGE_F050_F051_PURGE_F051TP_4)"

    private SqlFileObject fleF051TP_DOC_CASH_MSTR;


    #endregion


    #region "Standard Generated Procedures(PURGE_F050_F051_PURGE_F051TP_4)"


    #region "Automatic Item Initialization(PURGE_F050_F051_PURGE_F051TP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(PURGE_F050_F051_PURGE_F051TP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
        fleF051TP_DOC_CASH_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(PURGE_F050_F051_PURGE_F051TP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
            fleF051TP_DOC_CASH_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PURGE_F050_F051_PURGE_F051TP_4)"


    public void Run()
    {

        try
        {
            Request("PURGE_F051TP_4");

            while (fleF051TP_DOC_CASH_MSTR.QTPForMissing())
            {
                // --> GET F051TP_DOC_CASH_MSTR <--

                fleF051TP_DOC_CASH_MSTR.GetData();
                // --> End GET F051TP_DOC_CASH_MSTR <--


                if (Transaction())
                {
                    fleF051TP_DOC_CASH_MSTR.OutPut(OutPutType.Delete);

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
            EndRequest("PURGE_F051TP_4");

        }

    }







    #endregion


}
//PURGE_F051TP_4




