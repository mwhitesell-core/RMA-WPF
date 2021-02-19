
#region "Screen Comments"

// 2011/Sep/13 MC - convert from u015tp.cbl
// - reset MTD figures to zero by clinic selection in f051tp & f051tp files


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U015TP : BaseClassControl
{

    private U015TP m_U015TP;

    public U015TP(string Name, int Level) : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U015TP(string Name, int Level, bool Request) : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U015TP != null))
        {
            m_U015TP.CloseTransactionObjects();
            m_U015TP = null;
        }
    }

    public U015TP GetU015TP(int Level)
    {
        if (m_U015TP == null)
        {
            m_U015TP = new U015TP("U015TP", Level);
        }
        else
        {
            m_U015TP.ResetValues();
        }
        return m_U015TP;
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

            U015TP_UPDATE_F050TP_1 UPDATE_F050TP_1 = new U015TP_UPDATE_F050TP_1(Name, Level);
            UPDATE_F050TP_1.Run();
            UPDATE_F050TP_1.Dispose();
            UPDATE_F050TP_1 = null;

            U015TP_UPDATE_F051TP_2 UPDATE_F051TP_2 = new U015TP_UPDATE_F051TP_2(Name, Level);
            UPDATE_F051TP_2.Run();
            UPDATE_F051TP_2.Dispose();
            UPDATE_F051TP_2 = null;

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



public class U015TP_UPDATE_F050TP_1 : U015TP
{

    public U015TP_UPDATE_F050TP_1(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF050TP_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF050TP_DOC_REVENUE_MSTR.SetItemFinals += fleF050TP_DOC_REVENUE_MSTR_SetItemFinals;
        fleF050TP_DOC_REVENUE_MSTR.Choose += fleF050TP_DOC_REVENUE_MSTR_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U015TP_UPDATE_F050TP_1)"

    private SqlFileObject fleF050TP_DOC_REVENUE_MSTR;

    private void fleF050TP_DOC_REVENUE_MSTR_SetItemFinals()
    {

        try
        {
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_TECH_AMT_BILLED1", 0);
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_TECH_AMT_ADJUSTS1", 0);
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_TECH_NBR_SVC1", 0);

            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_PROF_AMT_BILLED1", 0);
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_PROF_AMT_ADJUSTS1", 0);
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_IN_PROF_NBR_SVC1", 0);

            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_TECH_AMT_BILLED1", 0);
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_TECH_AMT_ADJUSTS1", 0);
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_TECH_NBR_SVC1", 0);

            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_PROF_AMT_BILLED1", 0);
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_PROF_AMT_ADJUSTS1", 0);
            fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OUT_PROF_NBR_SVC1", 0);


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


    private void fleF050TP_DOC_REVENUE_MSTR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            if ((Prompt(1).ToString() != null) && Prompt(2).ToString().Length > 0)
            {
                strSQL.Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_CLINIC_NBR"));
                strSQL.Append(" BETWEEN ");
                strSQL.Append(Common.StringToField(Prompt(1).ToString())).Append(" AND ").Append(Common.StringToField(Prompt(2).ToString()));

            }

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


    #endregion


    #region "Standard Generated Procedures(U015TP_UPDATE_F050TP_1)"


    #region "Automatic Item Initialization(U015TP_UPDATE_F050TP_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U015TP_UPDATE_F050TP_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:31 AM

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


    #region "FILE Management Procedures(U015TP_UPDATE_F050TP_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:31 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U015TP_UPDATE_F050TP_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F050TP_1");

            while (fleF050TP_DOC_REVENUE_MSTR.QTPForMissing())
            {
                // --> GET F050TP_DOC_REVENUE_MSTR <--

                fleF050TP_DOC_REVENUE_MSTR.GetData();
                // --> End GET F050TP_DOC_REVENUE_MSTR <--


                if (Transaction())
                {


                    fleF050TP_DOC_REVENUE_MSTR.OutPut(OutPutType.Update);

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
            EndRequest("UPDATE_F050TP_1");

        }

    }




    #endregion


}
//UPDATE_F050TP_1



public class U015TP_UPDATE_F051TP_2 : U015TP
{

    public U015TP_UPDATE_F051TP_2(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF051TP_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051TP_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF051TP_DOC_CASH_MSTR.SetItemFinals += fleF051TP_DOC_CASH_MSTR_SetItemFinals;
        fleF051TP_DOC_CASH_MSTR.Choose += fleF051TP_DOC_CASH_MSTR_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U015TP_UPDATE_F051TP_2)"

    private SqlFileObject fleF051TP_DOC_CASH_MSTR;

    private void fleF051TP_DOC_CASH_MSTR_SetItemFinals()
    {

        try
        {
            fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_TECH_IN_MTD", 0);
            fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_PROF_IN_MTD", 0);
            fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_TECH_OUT_MTD", 0);
            fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_PROF_OUT_MTD", 0);


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


    private void fleF051TP_DOC_CASH_MSTR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            if ((Prompt(3).ToString() != null) && Prompt(4).ToString().Length > 0)
            {
                strSQL.Append(fleF051TP_DOC_CASH_MSTR.ElementOwner("DOCASHTP_CLINIC_NBR"));
                strSQL.Append(" BETWEEN ");
                strSQL.Append(Common.StringToField(Prompt(3).ToString())).Append(" AND ").Append(Common.StringToField(Prompt(4).ToString()));

            }

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


    #endregion


    #region "Standard Generated Procedures(U015TP_UPDATE_F051TP_2)"


    #region "Automatic Item Initialization(U015TP_UPDATE_F051TP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U015TP_UPDATE_F051TP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:31 AM

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


    #region "FILE Management Procedures(U015TP_UPDATE_F051TP_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 10/12/2017 9:35:31 AM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U015TP_UPDATE_F051TP_2)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F051TP_2");

            while (fleF051TP_DOC_CASH_MSTR.QTPForMissing())
            {
                // --> GET F051TP_DOC_CASH_MSTR <--

                fleF051TP_DOC_CASH_MSTR.GetData();
                // --> End GET F051TP_DOC_CASH_MSTR <--


                if (Transaction())
                {


                    fleF051TP_DOC_CASH_MSTR.OutPut(OutPutType.Update);

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
            EndRequest("UPDATE_F051TP_2");

        }

    }




    #endregion


}
//UPDATE_F051TP_2




