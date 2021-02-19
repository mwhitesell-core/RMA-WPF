
#region "Screen Comments"

// #> PROGRAM-ID.     Billing_U112.QTS
// ? ??????????????????
// THIS PGMS USES CURRENT-EP + OR - 1.. WILL IT WORK FOR 9101 WHERE -1 = 9100 ????????????????
// ((C)) Dyad Technologies
// PURPOSE: Ensure that a CURRENT EP record exists in the
// PAYCODE/CEILINGS file for all physicians before starting
// calcuations for this EP.  If record hasn`t already been
// manually created by the User then automatically generate
// one using the values from the most recent EP record as
// defaults (if no previous EP record then zero`s will be used
// thus defaulting the physician onto PAY CODE 0.
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/JAN/01  ____   R.A.     - original
// 1999/JAN/15  ----   S.B.     - Checked for Y2K.
// 2003/dec/24         A.A.  - alpha doctor nbr


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Billing_U112 : BaseClassControl
{

    private Billing_U112 m_Billing_U112;

    public Billing_U112(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);


    }

    public Billing_U112(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_Billing_U112 != null))
        {
            m_Billing_U112.CloseTransactionObjects();
            m_Billing_U112 = null;
        }
    }

    public Billing_U112 GetBilling_U112(int Level)
    {
        if (m_Billing_U112 == null)
        {
            m_Billing_U112 = new Billing_U112("Billing_U112", Level);
        }
        else
        {
            m_Billing_U112.ResetValues();
        }
        return m_Billing_U112;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_EP_NBR;

    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            Billing_U112_CONST_MSTR_GET_EP_NBR_1 CONST_MSTR_GET_EP_NBR_1 = new Billing_U112_CONST_MSTR_GET_EP_NBR_1(Name, Level);
            CONST_MSTR_GET_EP_NBR_1.Run();
            CONST_MSTR_GET_EP_NBR_1.Dispose();
            CONST_MSTR_GET_EP_NBR_1 = null;

            Billing_U112_RUN_0_2 RUN_0_2 = new Billing_U112_RUN_0_2(Name, Level);
            RUN_0_2.Run();
            RUN_0_2.Dispose();
            RUN_0_2 = null;

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



public class Billing_U112_CONST_MSTR_GET_EP_NBR_1 : Billing_U112
{

    public Billing_U112_CONST_MSTR_GET_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_U112_CONST_MSTR_GET_EP_NBR_1)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;

    private void fleCONSTANTS_MSTR_REC_6_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleCONSTANTS_MSTR_REC_6.ElementOwner("CONST_REC_NBR")).Append(" = ");
            strSQL.Append(6);


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


    #region "Standard Generated Procedures(Billing_U112_CONST_MSTR_GET_EP_NBR_1)"


    #region "Automatic Item Initialization(Billing_U112_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_U112_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:23 PM

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
        fleCONSTANTS_MSTR_REC_6.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_U112_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:23 PM

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
            fleCONSTANTS_MSTR_REC_6.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_U112_CONST_MSTR_GET_EP_NBR_1)"


    public void Run()
    {

        try
        {
            Request("CONST_MSTR_GET_EP_NBR_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                if (Transaction())
                {
                    W_CURRENT_EP_NBR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR");
                    W_CURRENT_EP_NBR_MINUS1.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1;

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
            EndRequest("CONST_MSTR_GET_EP_NBR_1");

        }

    }







    #endregion


}
//CONST_MSTR_GET_EP_NBR_1



public class Billing_U112_RUN_0_2 : Billing_U112
{

    public Billing_U112_RUN_0_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_CURRENT_EP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "F112_CURRENT_EP", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_OUTPUT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "F112_OUTPUT", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF112_CURRENT_EP.InitializeItems += fleF112_CURRENT_EP_AutomaticItemInitialization;
        fleF112_OUTPUT.InitializeItems += fleF112_OUTPUT_AutomaticItemInitialization;

        fleF112_PYCDCEILINGS.SelectIf += fleF112_PYCDCEILINGS_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_U112_RUN_0_2)"

    private SqlFileObject fleF112_PYCDCEILINGS;

    private void fleF112_PYCDCEILINGS_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" =  ").Append(W_CURRENT_EP_NBR_MINUS1.Value).Append(" )");


            SelectIfClause = strSQL.ToString();


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

    private SqlFileObject fleF112_CURRENT_EP;
    private SqlFileObject fleF112_OUTPUT;


    #endregion


    #region "Standard Generated Procedures(Billing_U112_RUN_0_2)"


    #region "Automatic Item Initialization(Billing_U112_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:24 PM

    //#-----------------------------------------
    //# fleF112_CURRENT_EP_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:23 PM
    //#-----------------------------------------
    private void fleF112_CURRENT_EP_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF112_CURRENT_EP.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF112_CURRENT_EP.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF112_CURRENT_EP.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF112_CURRENT_EP.set_SetValue("DOC_PAY_CODE", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));
            fleF112_CURRENT_EP.set_SetValue("DOC_PAY_SUB_CODE", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));
            fleF112_CURRENT_EP.set_SetValue("RETRO_TO_EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_CEILING", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_CEILING_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_ADJUSTED"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_EXPENSE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_EXPENSE_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_ADJUSTED"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_CEIL_GUAR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEIL_GUAR"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_CEILING_GUAR_PERC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_GUAR_PERC"));
            fleF112_CURRENT_EP.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF112_CURRENT_EP.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF112_CURRENT_EP.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            fleF112_CURRENT_EP.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF112_CURRENT_EP.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF112_CURRENT_EP.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF112_CURRENT_EP.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_REQREV", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_REQREV_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_ADJUSTED"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_REQREV_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_COMPUTED"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_TARREV", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_TARREV_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_ADJUSTED"));
            fleF112_CURRENT_EP.set_SetValue("DOC_YRLY_TARREV_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_COMPUTED"));
            fleF112_CURRENT_EP.set_SetValue("RETRO_TO_EP_NBR_REQ", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ"));
            fleF112_CURRENT_EP.set_SetValue("RETRO_TO_EP_NBR_TAR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR"));

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
    //# fleF112_OUTPUT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:23 PM
    //#-----------------------------------------
    private void fleF112_OUTPUT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF112_OUTPUT.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF112_OUTPUT.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF112_OUTPUT.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF112_OUTPUT.set_SetValue("DOC_PAY_CODE", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));
            fleF112_OUTPUT.set_SetValue("DOC_PAY_SUB_CODE", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));
            fleF112_OUTPUT.set_SetValue("RETRO_TO_EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_CEILING", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_CEILING_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_ADJUSTED"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_EXPENSE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_EXPENSE_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_ADJUSTED"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_EXPN_ALLOC_PERS", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_CEIL_GUAR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEIL_GUAR"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_CEILING_GUAR_PERC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_GUAR_PERC"));
            fleF112_OUTPUT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF112_OUTPUT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF112_OUTPUT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            fleF112_OUTPUT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF112_OUTPUT.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF112_OUTPUT.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF112_OUTPUT.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_REQREV", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_REQREV_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_ADJUSTED"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_REQREV_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV_COMPUTED"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_TARREV", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_TARREV_ADJUSTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_ADJUSTED"));
            fleF112_OUTPUT.set_SetValue("DOC_YRLY_TARREV_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV_COMPUTED"));
            fleF112_OUTPUT.set_SetValue("RETRO_TO_EP_NBR_REQ", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_REQ"));
            fleF112_OUTPUT.set_SetValue("RETRO_TO_EP_NBR_TAR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("RETRO_TO_EP_NBR_TAR"));

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


    #region "Transaction Management Procedures(Billing_U112_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:23 PM

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
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF112_CURRENT_EP.Transaction = m_trnTRANS_UPDATE;
        fleF112_OUTPUT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_U112_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:23 PM

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
            fleF112_PYCDCEILINGS.Dispose();
            fleF112_CURRENT_EP.Dispose();
            fleF112_OUTPUT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_U112_RUN_0_2)"


    public void Run()
    {

        try
        {
            Request("RUN_0_2");

            while (fleF112_PYCDCEILINGS.QTPForMissing())
            {
                // --> GET F112_PYCDCEILINGS <--

                fleF112_PYCDCEILINGS.GetData();
                // --> End GET F112_PYCDCEILINGS <--

                while (fleF112_CURRENT_EP.QTPForMissing("1"))
                {
                    // --> GET F112_CURRENT_EP <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF112_CURRENT_EP.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                    m_strWhere.Append(" And ").Append(fleF112_CURRENT_EP.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((W_CURRENT_EP_NBR.Value));

                    fleF112_CURRENT_EP.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F112_CURRENT_EP <--


                    if (Transaction())
                    {

                        fleF112_OUTPUT.set_SetValue("DOC_NBR", fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));


                        fleF112_OUTPUT.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                        fleF112_OUTPUT.set_SetValue("DOC_PAY_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE"));


                        fleF112_OUTPUT.set_SetValue("DOC_PAY_SUB_CODE", fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_SUB_CODE"));


                        fleF112_OUTPUT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                        fleF112_OUTPUT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                        fleF112_OUTPUT.set_SetValue("LAST_MOD_USER_ID", "Billing_U112      Gen`d");

                        fleF112_OUTPUT.OutPut(OutPutType.Add, !fleF112_CURRENT_EP.Exists());

                    }

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
            EndRequest("RUN_0_2");

        }

    }







    #endregion


}
//RUN_0_2




