
#region "Screen Comments"

// -----------------------------------------------------------------------
// /T/ YEAREND PURGE PART 2 (UPLOAD)
// /A/ 
// /P/ Dyad Systems Inc.
// /Q/ QTP
// /M/ Modification History
// /M/ --------------------
// /M/ Date Programmer Description
// /M/
// /M/ 950627 B. LANGENDOCK Creation
// /M/ 1999/May/16 S.Bachmann Y2K checked.
// /M/ 2006/Jul/17 M. Chan        zero out require and target revenue fields when
// /M/    roll over f112 file
// /M/ 2006/Jul/20 M. Chan        zero out require and target revenue fields in f020-doctor-extra
// /M/ 2012/Jun/19 M. Chan        add `set lock record update` and `on calculation errors report on edit errors report`
// -----------------------------------------------------------------------
// /D/                       TRADE SECRET NOTICE
// /D/
// /D/  The techniques, algorithms, and processes contained herein, or
// /D/  any modification, extraction, or extrapolation thereof, are the
// /D/  proprietary property and trade secrets of Dyad Systems Inc.
// /D/  and except as provided for by a License Agreement, shall not be
// /D/  duplicated, used, or disclosed for any purpose, in whole or part
// /D/  without the express written permission of Dyad Systems Inc.
// -----------------------------------------------------------------------
// -----------------------------------------------------------------------


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class YEAREND_2 : BaseClassControl
{

    private YEAREND_2 m_YEAREND_2;

    public YEAREND_2(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public YEAREND_2(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_YEAREND_2 != null))
        {
            m_YEAREND_2.CloseTransactionObjects();
            m_YEAREND_2 = null;
        }
    }

    public YEAREND_2 GetYEAREND_2(int Level)
    {
        if (m_YEAREND_2 == null)
        {
            m_YEAREND_2 = new YEAREND_2("YEAREND_2", Level);
        }
        else
        {
            m_YEAREND_2.ResetValues();
        }
        return m_YEAREND_2;
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

            YEAREND_2_UPLOAD_F113_HISTORY_1 UPLOAD_F113_HISTORY_1 = new YEAREND_2_UPLOAD_F113_HISTORY_1(Name, Level);
            UPLOAD_F113_HISTORY_1.Run();
            UPLOAD_F113_HISTORY_1.Dispose();
            UPLOAD_F113_HISTORY_1 = null;

            YEAREND_2_UPLOAD_F113_CURRENT_2 UPLOAD_F113_CURRENT_2 = new YEAREND_2_UPLOAD_F113_CURRENT_2(Name, Level);
            UPLOAD_F113_CURRENT_2.Run();
            UPLOAD_F113_CURRENT_2.Dispose();
            UPLOAD_F113_CURRENT_2 = null;

            YEAREND_2_UPLOAD_F112_HISTORY_3 UPLOAD_F112_HISTORY_3 = new YEAREND_2_UPLOAD_F112_HISTORY_3(Name, Level);
            UPLOAD_F112_HISTORY_3.Run();
            UPLOAD_F112_HISTORY_3.Dispose();
            UPLOAD_F112_HISTORY_3 = null;

            YEAREND_2_UPLOAD_F112_CURRENT_4 UPLOAD_F112_CURRENT_4 = new YEAREND_2_UPLOAD_F112_CURRENT_4(Name, Level);
            UPLOAD_F112_CURRENT_4.Run();
            UPLOAD_F112_CURRENT_4.Dispose();
            UPLOAD_F112_CURRENT_4 = null;

            YEAREND_2_UPDATE_F020_EXTRA_5 UPDATE_F020_EXTRA_5 = new YEAREND_2_UPDATE_F020_EXTRA_5(Name, Level);
            UPDATE_F020_EXTRA_5.Run();
            UPDATE_F020_EXTRA_5.Dispose();
            UPDATE_F020_EXTRA_5 = null;

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



public class YEAREND_2_UPLOAD_F113_HISTORY_1 : YEAREND_2
{

    public YEAREND_2_UPLOAD_F113_HISTORY_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF113_YEAREND_OLD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F113_YEAREND_OLD", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF113_DEFAULT_COMP_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEF_COMP_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(YEAREND_2_UPLOAD_F113_HISTORY_1)"

    private SqlFileObject fleF113_YEAREND_OLD;
    private SqlFileObject fleF113_DEFAULT_COMP_HISTORY;


    #endregion


    #region "Standard Generated Procedures(YEAREND_2_UPLOAD_F113_HISTORY_1)"


    #region "Automatic Item Initialization(YEAREND_2_UPLOAD_F113_HISTORY_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(YEAREND_2_UPLOAD_F113_HISTORY_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:00 PM

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
        fleF113_YEAREND_OLD.Transaction = m_trnTRANS_UPDATE;
        fleF113_DEFAULT_COMP_HISTORY.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(YEAREND_2_UPLOAD_F113_HISTORY_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:00 PM

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
            fleF113_YEAREND_OLD.Dispose();
            fleF113_DEFAULT_COMP_HISTORY.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(YEAREND_2_UPLOAD_F113_HISTORY_1)"


    public void Run()
    {

        try
        {
            Request("UPLOAD_F113_HISTORY_1");

            while (fleF113_YEAREND_OLD.QTPForMissing())
            {
                // --> GET F113_YEAREND_OLD <--

                fleF113_YEAREND_OLD.GetData();
                // --> End GET F113_YEAREND_OLD <--


                if (Transaction())
                {
                    fleF113_DEFAULT_COMP_HISTORY.OutPut(OutPutType.Add);

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
            EndRequest("UPLOAD_F113_HISTORY_1");

        }

    }







    #endregion


}
//UPLOAD_F113_HISTORY_1



public class YEAREND_2_UPLOAD_F113_CURRENT_2 : YEAREND_2
{

    public YEAREND_2_UPLOAD_F113_CURRENT_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF113_YEAREND_NEW = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F113_YEAREND_NEW", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF113_DEFAULT_COMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(YEAREND_2_UPLOAD_F113_CURRENT_2)"

    private SqlFileObject fleF113_YEAREND_NEW;
    private SqlFileObject fleF113_DEFAULT_COMP;


    #endregion


    #region "Standard Generated Procedures(YEAREND_2_UPLOAD_F113_CURRENT_2)"


    #region "Automatic Item Initialization(YEAREND_2_UPLOAD_F113_CURRENT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(YEAREND_2_UPLOAD_F113_CURRENT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:00 PM

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
        fleF113_YEAREND_NEW.Transaction = m_trnTRANS_UPDATE;
        fleF113_DEFAULT_COMP.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(YEAREND_2_UPLOAD_F113_CURRENT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:00 PM

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
            fleF113_YEAREND_NEW.Dispose();
            fleF113_DEFAULT_COMP.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(YEAREND_2_UPLOAD_F113_CURRENT_2)"


    public void Run()
    {

        try
        {
            Request("UPLOAD_F113_CURRENT_2");

            while (fleF113_YEAREND_NEW.QTPForMissing())
            {
                // --> GET F113_YEAREND_NEW <--

                fleF113_YEAREND_NEW.GetData();
                // --> End GET F113_YEAREND_NEW <--


                if (Transaction())
                {
                    fleF113_DEFAULT_COMP.OutPut(OutPutType.Add);

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
            EndRequest("UPLOAD_F113_CURRENT_2");

        }

    }







    #endregion


}
//UPLOAD_F113_CURRENT_2



public class YEAREND_2_UPLOAD_F112_HISTORY_3 : YEAREND_2
{

    public YEAREND_2_UPLOAD_F112_HISTORY_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF112_YEAREND_OLD = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F112_YEAREND_OLD", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF112_PYCDCEILINGS_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(YEAREND_2_UPLOAD_F112_HISTORY_3)"

    private SqlFileObject fleF112_YEAREND_OLD;
    private SqlFileObject fleF112_PYCDCEILINGS_HISTORY;


    #endregion


    #region "Standard Generated Procedures(YEAREND_2_UPLOAD_F112_HISTORY_3)"


    #region "Automatic Item Initialization(YEAREND_2_UPLOAD_F112_HISTORY_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(YEAREND_2_UPLOAD_F112_HISTORY_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:00 PM

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
        fleF112_YEAREND_OLD.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS_HISTORY.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(YEAREND_2_UPLOAD_F112_HISTORY_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:01 PM

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
            fleF112_YEAREND_OLD.Dispose();
            fleF112_PYCDCEILINGS_HISTORY.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(YEAREND_2_UPLOAD_F112_HISTORY_3)"


    public void Run()
    {

        try
        {
            Request("UPLOAD_F112_HISTORY_3");

            while (fleF112_YEAREND_OLD.QTPForMissing())
            {
                // --> GET F112_YEAREND_OLD <--

                fleF112_YEAREND_OLD.GetData();
                // --> End GET F112_YEAREND_OLD <--


                if (Transaction())
                {
                    fleF112_PYCDCEILINGS_HISTORY.OutPut(OutPutType.Add);

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
            EndRequest("UPLOAD_F112_HISTORY_3");

        }

    }







    #endregion


}
//UPLOAD_F112_HISTORY_3



public class YEAREND_2_UPLOAD_F112_CURRENT_4 : YEAREND_2
{

    public YEAREND_2_UPLOAD_F112_CURRENT_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF112_YEAREND_NEW = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F112_YEAREND_NEW", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF112_PYCDCEILINGS.SetItemFinals += fleF112_PYCDCEILINGS_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(YEAREND_2_UPLOAD_F112_CURRENT_4)"

    private SqlFileObject fleF112_YEAREND_NEW;
    private SqlFileObject fleF112_PYCDCEILINGS;

    private void fleF112_PYCDCEILINGS_SetItemFinals()
    {

        try
        {
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_REQREV", 0);
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_REQREV_ADJUSTED", 0);
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_REQREV_COMPUTED", 0);
            fleF112_PYCDCEILINGS.set_SetValue("RETRO_TO_EP_NBR_REQ", 0);
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_TARREV", 0);
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_TARREV_ADJUSTED", 0);
            fleF112_PYCDCEILINGS.set_SetValue("DOC_YRLY_TARREV_COMPUTED", 0);
            fleF112_PYCDCEILINGS.set_SetValue("RETRO_TO_EP_NBR_TAR", 0);


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


    #region "Standard Generated Procedures(YEAREND_2_UPLOAD_F112_CURRENT_4)"


    #region "Automatic Item Initialization(YEAREND_2_UPLOAD_F112_CURRENT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(YEAREND_2_UPLOAD_F112_CURRENT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:01 PM

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
        fleF112_YEAREND_NEW.Transaction = m_trnTRANS_UPDATE;
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(YEAREND_2_UPLOAD_F112_CURRENT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:01 PM

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
            fleF112_YEAREND_NEW.Dispose();
            fleF112_PYCDCEILINGS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(YEAREND_2_UPLOAD_F112_CURRENT_4)"


    public void Run()
    {

        try
        {
            Request("UPLOAD_F112_CURRENT_4");

            while (fleF112_YEAREND_NEW.QTPForMissing())
            {
                // --> GET F112_YEAREND_NEW <--

                fleF112_YEAREND_NEW.GetData();
                // --> End GET F112_YEAREND_NEW <--


                if (Transaction())
                {
                    fleF112_PYCDCEILINGS.OutPut(OutPutType.Add);

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
            EndRequest("UPLOAD_F112_CURRENT_4");

        }

    }







    #endregion


}
//UPLOAD_F112_CURRENT_4



public class YEAREND_2_UPDATE_F020_EXTRA_5 : YEAREND_2
{

    public YEAREND_2_UPDATE_F020_EXTRA_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF020_DOCTOR_EXTRA.SetItemFinals += fleF020_DOCTOR_EXTRA_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(YEAREND_2_UPDATE_F020_EXTRA_5)"

    private SqlFileObject fleF020_DOCTOR_EXTRA;

    private void fleF020_DOCTOR_EXTRA_SetItemFinals()
    {

        try
        {
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YRLY_REQUIRE_REVENUE", 0);
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YRLY_TARGET_REVENUE", 0);
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YTDREQ", 0);
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_YTDTAR", 0);
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_CEIREQ", 0);
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_CEITAR", 0);


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


    #region "Standard Generated Procedures(YEAREND_2_UPDATE_F020_EXTRA_5)"


    #region "Automatic Item Initialization(YEAREND_2_UPDATE_F020_EXTRA_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(YEAREND_2_UPDATE_F020_EXTRA_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:01 PM

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
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(YEAREND_2_UPDATE_F020_EXTRA_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:01 PM

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
            fleF020_DOCTOR_EXTRA.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(YEAREND_2_UPDATE_F020_EXTRA_5)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F020_EXTRA_5");

            while (fleF020_DOCTOR_EXTRA.QTPForMissing())
            {
                // --> GET F020_DOCTOR_EXTRA <--

                fleF020_DOCTOR_EXTRA.GetData();
                // --> End GET F020_DOCTOR_EXTRA <--


                if (Transaction())
                {
                    fleF020_DOCTOR_EXTRA.OutPut(OutPutType.Update);

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
            EndRequest("UPDATE_F020_EXTRA_5");

        }

    }







    #endregion


}
//UPDATE_F020_EXTRA_5




