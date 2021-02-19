
#region "Screen Comments"

// #> PROGRAM-ID.     U126.QTS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// UPDATE `USER DEFINED TOTALS` OF DOCTOR FOR TRANSACTIONS
// GENERATED THIS EP RUN.
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 93/JAN/01  ____   B.E.     - original
// 93/MAY/11  ____   R.A.     - Compensation records from conversion created
// for Terminated doctors, therefore removed
// SELECT if first pass to create total
// records for all doctors in F020
// 93/MAY/18  ____   B.E.     - optimize via F090
// 1999/Feb/18          S.B.     - Checked for Y2K.
// 2003/dec/24   A.A.  - alpha doctor nbr


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U126 : BaseClassControl
{

    private U126 m_U126;

    public U126(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);


    }

    public U126(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U126 != null))
        {
            m_U126.CloseTransactionObjects();
            m_U126 = null;
        }
    }

    public U126 GetU126(int Level)
    {
        if (m_U126 == null)
        {
            m_U126 = new U126("U126", Level);
        }
        else
        {
            m_U126.ResetValues();
        }
        return m_U126;
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

            U126_CONST_MSTR_GET_EP_NBR_1 CONST_MSTR_GET_EP_NBR_1 = new U126_CONST_MSTR_GET_EP_NBR_1(Name, Level);
            CONST_MSTR_GET_EP_NBR_1.Run();
            CONST_MSTR_GET_EP_NBR_1.Dispose();
            CONST_MSTR_GET_EP_NBR_1 = null;

            U126_RUN_0_2 RUN_0_2 = new U126_RUN_0_2(Name, Level);
            RUN_0_2.Run();
            RUN_0_2.Dispose();
            RUN_0_2 = null;

            U126_RUN_1_3 RUN_1_3 = new U126_RUN_1_3(Name, Level);
            RUN_1_3.Run();
            RUN_1_3.Dispose();
            RUN_1_3 = null;

            U126_RUN_3_4 RUN_3_4 = new U126_RUN_3_4(Name, Level);
            RUN_3_4.Run();
            RUN_3_4.Dispose();
            RUN_3_4 = null;

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



public class U126_CONST_MSTR_GET_EP_NBR_1 : U126
{

    public U126_CONST_MSTR_GET_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U126_CONST_MSTR_GET_EP_NBR_1)"

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


    #region "Standard Generated Procedures(U126_CONST_MSTR_GET_EP_NBR_1)"


    #region "Automatic Item Initialization(U126_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U126_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:54 PM

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


    #region "FILE Management Procedures(U126_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:54 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U126_CONST_MSTR_GET_EP_NBR_1)"


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



public class U126_RUN_0_2 : U126
{

    public U126_RUN_0_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF198_USER_DEFINED_TOTALS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F198_USER_DEFINED_TOTALS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF198_2ND_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F198_USER_DEFINED_TOTALS", "F198_2ND_REC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF198_OUTPUT_ADD_REC_1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F198_USER_DEFINED_TOTALS", "F198_OUTPUT_ADD_REC_1", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF198_OUTPUT_ADD_REC_2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F198_USER_DEFINED_TOTALS", "F198_OUTPUT_ADD_REC_2", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF198_OUTPUT_ADD_REC_1.InitializeItems += fleF198_OUTPUT_ADD_REC_1_InitializeItems;
        fleF198_OUTPUT_ADD_REC_2.InitializeItems += fleF198_OUTPUT_ADD_REC_2_InitializeItems;
        fleF198_2ND_REC.InitializeItems += fleF198_2ND_REC_AutomaticItemInitialization;
        //fleF198_OUTPUT_ADD_REC_1.InitializeItems += fleF198_OUTPUT_ADD_REC_1_AutomaticItemInitialization;
        //fleF198_OUTPUT_ADD_REC_2.InitializeItems += fleF198_OUTPUT_ADD_REC_2_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U126_RUN_0_2)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF198_USER_DEFINED_TOTALS;
    private SqlFileObject fleF198_2ND_REC;
    private SqlFileObject fleF198_OUTPUT_ADD_REC_1;

    private void fleF198_OUTPUT_ADD_REC_1_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF198_OUTPUT_ADD_REC_1.set_SetValue("RECORD_ID", true, "A");
            if (!Fixed)
                fleF198_OUTPUT_ADD_REC_1.set_SetValue("UDT_KEY", true, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));


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

    private SqlFileObject fleF198_OUTPUT_ADD_REC_2;

    private void fleF198_OUTPUT_ADD_REC_2_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF198_OUTPUT_ADD_REC_2.set_SetValue("RECORD_ID", true, "B");
            if (!Fixed)
                fleF198_OUTPUT_ADD_REC_2.set_SetValue("UDT_KEY", true, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));


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


    #region "Standard Generated Procedures(U126_RUN_0_2)"


    #region "Automatic Item Initialization(U126_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:55 PM

    //#-----------------------------------------
    //# fleF198_2ND_REC_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:55 PM
    //#-----------------------------------------
    private void fleF198_2ND_REC_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF198_2ND_REC.set_SetValue("RECORD_ID", !Fixed, fleF198_USER_DEFINED_TOTALS.GetStringValue("RECORD_ID"));
            fleF198_2ND_REC.set_SetValue("UDT_KEY", !Fixed, fleF198_USER_DEFINED_TOTALS.GetStringValue("UDT_KEY"));
            fleF198_2ND_REC.set_SetValue("USER_TOTAL1", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL1"));
            fleF198_2ND_REC.set_SetValue("USER_TOTAL2", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL2"));
            fleF198_2ND_REC.set_SetValue("USER_TOTAL3", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL3"));
            fleF198_2ND_REC.set_SetValue("USER_TOTAL4", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL4"));
            fleF198_2ND_REC.set_SetValue("USER_TOTAL5", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL5"));
            fleF198_2ND_REC.set_SetValue("USER_TOTAL6", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL6"));
            fleF198_2ND_REC.set_SetValue("USER_TOTAL7", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL7"));
            fleF198_2ND_REC.set_SetValue("USER_TOTAL8", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL8"));
            fleF198_2ND_REC.set_SetValue("USER_TOTAL9", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL9"));
            fleF198_2ND_REC.set_SetValue("USER_TOTAL10", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL10"));

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
    //# fleF198_OUTPUT_ADD_REC_1_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:55 PM
    //#-----------------------------------------
    private void fleF198_OUTPUT_ADD_REC_1_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("RECORD_ID", !Fixed, fleF198_USER_DEFINED_TOTALS.GetStringValue("RECORD_ID"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("UDT_KEY", !Fixed, fleF198_USER_DEFINED_TOTALS.GetStringValue("UDT_KEY"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("USER_TOTAL1", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL1"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("USER_TOTAL2", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL2"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("USER_TOTAL3", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL3"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("USER_TOTAL4", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL4"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("USER_TOTAL5", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL5"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("USER_TOTAL6", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL6"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("USER_TOTAL7", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL7"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("USER_TOTAL8", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL8"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("USER_TOTAL9", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL9"));
            fleF198_OUTPUT_ADD_REC_1.set_SetValue("USER_TOTAL10", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL10"));

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
    //# fleF198_OUTPUT_ADD_REC_2_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:55 PM
    //#-----------------------------------------
    private void fleF198_OUTPUT_ADD_REC_2_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("RECORD_ID", !Fixed, fleF198_USER_DEFINED_TOTALS.GetStringValue("RECORD_ID"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("UDT_KEY", !Fixed, fleF198_USER_DEFINED_TOTALS.GetStringValue("UDT_KEY"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("USER_TOTAL1", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL1"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("USER_TOTAL2", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL2"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("USER_TOTAL3", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL3"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("USER_TOTAL4", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL4"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("USER_TOTAL5", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL5"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("USER_TOTAL6", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL6"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("USER_TOTAL7", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL7"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("USER_TOTAL8", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL8"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("USER_TOTAL9", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL9"));
            fleF198_OUTPUT_ADD_REC_2.set_SetValue("USER_TOTAL10", !Fixed, fleF198_USER_DEFINED_TOTALS.GetDecimalValue("USER_TOTAL10"));

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


    #region "Transaction Management Procedures(U126_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:54 PM

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
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF198_USER_DEFINED_TOTALS.Transaction = m_trnTRANS_UPDATE;
        fleF198_2ND_REC.Transaction = m_trnTRANS_UPDATE;
        fleF198_OUTPUT_ADD_REC_1.Transaction = m_trnTRANS_UPDATE;
        fleF198_OUTPUT_ADD_REC_2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U126_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:54 PM

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
            fleF020_DOCTOR_MSTR.Dispose();
            fleF198_USER_DEFINED_TOTALS.Dispose();
            fleF198_2ND_REC.Dispose();
            fleF198_OUTPUT_ADD_REC_1.Dispose();
            fleF198_OUTPUT_ADD_REC_2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U126_RUN_0_2)"


    public void Run()
    {

        try
        {
            Request("RUN_0_2");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--

                while (fleF198_USER_DEFINED_TOTALS.QTPForMissing("1"))
                {
                    // --> GET F198_USER_DEFINED_TOTALS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF198_USER_DEFINED_TOTALS.ElementOwner("RECORD_ID")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("A"));
                    m_strWhere.Append(" And ").Append(fleF198_USER_DEFINED_TOTALS.ElementOwner("UDT_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                    fleF198_USER_DEFINED_TOTALS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F198_USER_DEFINED_TOTALS <--

                    while (fleF198_2ND_REC.QTPForMissing("2"))
                    {
                        // --> GET F198_2ND_REC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF198_2ND_REC.ElementOwner("RECORD_ID")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF198_2ND_REC.ElementOwner("UDT_KEY")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));

                        fleF198_2ND_REC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F198_2ND_REC <--


                        if (Transaction())
                        {
                            fleF198_OUTPUT_ADD_REC_1.OutPut(OutPutType.Add, null, !fleF198_USER_DEFINED_TOTALS.Exists());


                            fleF198_OUTPUT_ADD_REC_2.OutPut(OutPutType.Add, null, !fleF198_2ND_REC.Exists());

                        }

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



public class U126_RUN_1_3 : U126
{

    public U126_RUN_1_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF198_1ST_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F198_USER_DEFINED_TOTALS", "F198_1ST_REC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF198_OUTPUT_UPDATE_REC_1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F198_USER_DEFINED_TOTALS", "F198_OUTPUT_UPDATE_REC_1", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF198_OUTPUT_UPDATE_REC_1.InitializeItems += fleF198_OUTPUT_UPDATE_REC_1_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U126_RUN_1_3)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF110_COMPENSATION;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF198_1ST_REC;

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


    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS0")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS1")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS2")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS3")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS4")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS5")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS6")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS7")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS8")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS9")) == "Y"))
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

    private SqlFileObject fleF198_OUTPUT_UPDATE_REC_1;


    #endregion


    #region "Standard Generated Procedures(U126_RUN_1_3)"


    #region "Automatic Item Initialization(U126_RUN_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:55 PM

    //#-----------------------------------------
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:55 PM
    //#-----------------------------------------
    private void fleF190_COMP_CODES_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF190_COMP_CODES.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF190_COMP_CODES.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF190_COMP_CODES.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF198_OUTPUT_UPDATE_REC_1_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:55 PM
    //#-----------------------------------------
    private void fleF198_OUTPUT_UPDATE_REC_1_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("RECORD_ID", !Fixed, fleF198_1ST_REC.GetStringValue("RECORD_ID"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("UDT_KEY", !Fixed, fleF198_1ST_REC.GetStringValue("UDT_KEY"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("USER_TOTAL1", !Fixed, fleF198_1ST_REC.GetDecimalValue("USER_TOTAL1"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("USER_TOTAL2", !Fixed, fleF198_1ST_REC.GetDecimalValue("USER_TOTAL2"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("USER_TOTAL3", !Fixed, fleF198_1ST_REC.GetDecimalValue("USER_TOTAL3"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("USER_TOTAL4", !Fixed, fleF198_1ST_REC.GetDecimalValue("USER_TOTAL4"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("USER_TOTAL5", !Fixed, fleF198_1ST_REC.GetDecimalValue("USER_TOTAL5"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("USER_TOTAL6", !Fixed, fleF198_1ST_REC.GetDecimalValue("USER_TOTAL6"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("USER_TOTAL7", !Fixed, fleF198_1ST_REC.GetDecimalValue("USER_TOTAL7"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("USER_TOTAL8", !Fixed, fleF198_1ST_REC.GetDecimalValue("USER_TOTAL8"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("USER_TOTAL9", !Fixed, fleF198_1ST_REC.GetDecimalValue("USER_TOTAL9"));
            fleF198_OUTPUT_UPDATE_REC_1.set_SetValue("USER_TOTAL10", !Fixed, fleF198_1ST_REC.GetDecimalValue("USER_TOTAL10"));

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


    #region "Transaction Management Procedures(U126_RUN_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:54 PM

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
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF198_1ST_REC.Transaction = m_trnTRANS_UPDATE;
        fleF198_OUTPUT_UPDATE_REC_1.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U126_RUN_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:54 PM

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
            fleF110_COMPENSATION.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF198_1ST_REC.Dispose();
            fleF198_OUTPUT_UPDATE_REC_1.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U126_RUN_1_3)"


    public void Run()
    {

        try
        {
            Request("RUN_1_3");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF110_COMPENSATION.QTPForMissing("1"))
                {
                    // --> GET F110_COMPENSATION <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF110_COMPENSATION.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF110_COMPENSATION.ElementOwner("EP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF110_COMPENSATION.ElementOwner("DOC_NBR"));

                    fleF110_COMPENSATION.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F110_COMPENSATION <--

                    while (fleF190_COMP_CODES.QTPForMissing("2"))
                    {
                        // --> GET F190_COMP_CODES <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                        fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F190_COMP_CODES <--

                        while (fleF198_1ST_REC.QTPForMissing("3"))
                        {
                            // --> GET F198_1ST_REC <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF198_1ST_REC.ElementOwner("RECORD_ID")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("A"));
                            m_strWhere.Append(" And ").Append(fleF198_1ST_REC.ElementOwner("UDT_KEY")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                            fleF198_1ST_REC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F198_1ST_REC <--


                            if (Transaction())
                            {

                                 if (Select_If())
                                {                                   

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS1")) == "Y")
                                    {
                                        fleF198_1ST_REC.set_SetValue("USER_TOTAL1", fleF198_1ST_REC.GetDecimalValue("USER_TOTAL1") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS2")) == "Y")
                                    {
                                        fleF198_1ST_REC.set_SetValue("USER_TOTAL2", fleF198_1ST_REC.GetDecimalValue("USER_TOTAL2") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS3")) == "Y")
                                    {
                                        fleF198_1ST_REC.set_SetValue("USER_TOTAL3", fleF198_1ST_REC.GetDecimalValue("USER_TOTAL3") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS4")) == "Y")
                                    {
                                        fleF198_1ST_REC.set_SetValue("USER_TOTAL4", fleF198_1ST_REC.GetDecimalValue("USER_TOTAL4") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS5")) == "Y")
                                    {
                                        fleF198_1ST_REC.set_SetValue("USER_TOTAL5", fleF198_1ST_REC.GetDecimalValue("USER_TOTAL5") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS6")) == "Y")
                                    {
                                        fleF198_1ST_REC.set_SetValue("USER_TOTAL6", fleF198_1ST_REC.GetDecimalValue("USER_TOTAL6") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS7")) == "Y")
                                    {
                                        fleF198_1ST_REC.set_SetValue("USER_TOTAL7", fleF198_1ST_REC.GetDecimalValue("USER_TOTAL7") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS8")) == "Y")
                                    {
                                        fleF198_1ST_REC.set_SetValue("USER_TOTAL8", fleF198_1ST_REC.GetDecimalValue("USER_TOTAL8") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS9")) == "Y")
                                    {
                                        fleF198_1ST_REC.set_SetValue("USER_TOTAL9", fleF198_1ST_REC.GetDecimalValue("USER_TOTAL9"));                                        

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS10")) == "Y")
                                    {
                                        fleF198_1ST_REC.set_SetValue("USER_TOTAL10", fleF198_1ST_REC.GetDecimalValue("USER_TOTAL10") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                                        
                                    }

                                    fleF198_1ST_REC.OutPut(OutPutType.Update);

                                }
                            }

                        }

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
            EndRequest("RUN_1_3");

        }

    }







    #endregion


}
//RUN_1_3



public class U126_RUN_3_4 : U126
{

    public U126_RUN_3_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF198_2ND_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F198_USER_DEFINED_TOTALS", "F198_2ND_REC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF198_OUTPUT_UPDATE_REC_2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F198_USER_DEFINED_TOTALS", "F198_OUTPUT_UPDATE_REC_2", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF198_OUTPUT_UPDATE_REC_2.InitializeItems += fleF198_OUTPUT_UPDATE_REC_2_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U126_RUN_3_4)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF110_COMPENSATION;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF198_2ND_REC;

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


    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS10")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS11")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS12")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS13")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS14")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS15")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS16")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS17")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS18")) == "Y" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS19")) == "Y"))
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

    private SqlFileObject fleF198_OUTPUT_UPDATE_REC_2;


    #endregion


    #region "Standard Generated Procedures(U126_RUN_3_4)"


    #region "Automatic Item Initialization(U126_RUN_3_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:55 PM

    //#-----------------------------------------
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:55 PM
    //#-----------------------------------------
    private void fleF190_COMP_CODES_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF190_COMP_CODES.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF190_COMP_CODES.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF190_COMP_CODES.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF198_OUTPUT_UPDATE_REC_2_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:55 PM
    //#-----------------------------------------
    private void fleF198_OUTPUT_UPDATE_REC_2_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("RECORD_ID", !Fixed, fleF198_2ND_REC.GetStringValue("RECORD_ID"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("UDT_KEY", !Fixed, fleF198_2ND_REC.GetStringValue("UDT_KEY"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("USER_TOTAL1", !Fixed, fleF198_2ND_REC.GetDecimalValue("USER_TOTAL1"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("USER_TOTAL2", !Fixed, fleF198_2ND_REC.GetDecimalValue("USER_TOTAL2"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("USER_TOTAL3", !Fixed, fleF198_2ND_REC.GetDecimalValue("USER_TOTAL3"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("USER_TOTAL4", !Fixed, fleF198_2ND_REC.GetDecimalValue("USER_TOTAL4"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("USER_TOTAL5", !Fixed, fleF198_2ND_REC.GetDecimalValue("USER_TOTAL5"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("USER_TOTAL6", !Fixed, fleF198_2ND_REC.GetDecimalValue("USER_TOTAL6"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("USER_TOTAL7", !Fixed, fleF198_2ND_REC.GetDecimalValue("USER_TOTAL7"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("USER_TOTAL8", !Fixed, fleF198_2ND_REC.GetDecimalValue("USER_TOTAL8"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("USER_TOTAL9", !Fixed, fleF198_2ND_REC.GetDecimalValue("USER_TOTAL9"));
            fleF198_OUTPUT_UPDATE_REC_2.set_SetValue("USER_TOTAL10", !Fixed, fleF198_2ND_REC.GetDecimalValue("USER_TOTAL10"));

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


    #region "Transaction Management Procedures(U126_RUN_3_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:54 PM

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
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF198_2ND_REC.Transaction = m_trnTRANS_UPDATE;
        fleF198_OUTPUT_UPDATE_REC_2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U126_RUN_3_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:54 PM

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
            fleF110_COMPENSATION.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF198_2ND_REC.Dispose();
            fleF198_OUTPUT_UPDATE_REC_2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U126_RUN_3_4)"


    public void Run()
    {

        try
        {
            Request("RUN_3_4");



            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF110_COMPENSATION.QTPForMissing("1"))
                {
                    // --> GET F110_COMPENSATION <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF110_COMPENSATION.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF110_COMPENSATION.ElementOwner("EP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF110_COMPENSATION.ElementOwner("DOC_NBR"));

                    fleF110_COMPENSATION.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F110_COMPENSATION <--

                    while (fleF190_COMP_CODES.QTPForMissing("2"))
                    {
                        // --> GET F190_COMP_CODES <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                        fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F190_COMP_CODES <--

                        while (fleF198_2ND_REC.QTPForMissing("3"))
                        {
                            // --> GET F198_2ND_REC <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF198_2ND_REC.ElementOwner("RECORD_ID")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("B"));
                            m_strWhere.Append(" And ").Append(fleF198_2ND_REC.ElementOwner("UDT_KEY")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                            fleF198_2ND_REC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F198_2ND_REC <--


                            if (Transaction())
                            {

                                 if (Select_If())
                                {                                   

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS11")) == "Y")
                                    {
                                        fleF198_2ND_REC.set_SetValue("USER_TOTAL1", fleF198_2ND_REC.GetDecimalValue("USER_TOTAL1") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS12")) == "Y")
                                    {
                                        fleF198_2ND_REC.set_SetValue("USER_TOTAL2", fleF198_2ND_REC.GetDecimalValue("USER_TOTAL2") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS13")) == "Y")
                                    {
                                        fleF198_2ND_REC.set_SetValue("USER_TOTAL3", fleF198_2ND_REC.GetDecimalValue("USER_TOTAL3") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS14")) == "Y")
                                    {
                                        fleF198_2ND_REC.set_SetValue("USER_TOTAL4", fleF198_2ND_REC.GetDecimalValue("USER_TOTAL4") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS15")) == "Y")
                                    {
                                        fleF198_2ND_REC.set_SetValue("USER_TOTAL5", fleF198_2ND_REC.GetDecimalValue("USER_TOTAL5") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS16")) == "Y")
                                    {
                                        fleF198_2ND_REC.set_SetValue("USER_TOTAL6", fleF198_2ND_REC.GetDecimalValue("USER_TOTAL6") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS17")) == "Y")
                                    {
                                        fleF198_2ND_REC.set_SetValue("USER_TOTAL7", fleF198_2ND_REC.GetDecimalValue("USER_TOTAL7") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS18")) == "Y")
                                    {
                                        fleF198_2ND_REC.set_SetValue("USER_TOTAL8", fleF198_2ND_REC.GetDecimalValue("USER_TOTAL8") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS19")) == "Y")
                                    {
                                        fleF198_2ND_REC.set_SetValue("USER_TOTAL9", fleF198_2ND_REC.GetDecimalValue("USER_TOTAL9") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));

                                       

                                    }

                                    if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("AFFECT_GROSS20")) == "Y")
                                    {
                                        fleF198_2ND_REC.set_SetValue("USER_TOTAL20", fleF198_2ND_REC.GetDecimalValue("USER_TOTAL10") + fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
                                       
                                    }

                                    fleF198_2ND_REC.OutPut(OutPutType.Update);

                                }
                            }

                        }

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
            EndRequest("RUN_3_4");

        }

    }







    #endregion


}
//RUN_3_4




