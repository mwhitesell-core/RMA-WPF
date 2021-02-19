
#region "Screen Comments"

// #> PROGRAM-ID.     U113.QTS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// GENERATE COMPENSATION  DEFAULTS  FROM F113 FILE
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/JAN/01  ____   R.A.     - original
// 1999/JAN/15  ----   S.B.     - Checked for Y2K.
// 1999/June/01  S.B.     - Added the use file
// def_compensation_status.def to 
// prevent hard coding of compensation-status.
// 2003/dec/24         A.A.  - alpha doctor nbr


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U113 : BaseClassControl
{

    private U113 m_U113;

    public U113(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_FIRST_EP_NBR_OF_FISCAL_YR = new CoreDecimal("W_FIRST_EP_NBR_OF_FISCAL_YR", 6, this, ResetTypes.ResetAtStartup);


    }

    public U113(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_FIRST_EP_NBR_OF_FISCAL_YR = new CoreDecimal("W_FIRST_EP_NBR_OF_FISCAL_YR", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U113 != null))
        {
            m_U113.CloseTransactionObjects();
            m_U113 = null;
        }
    }

    public U113 GetU113(int Level)
    {
        if (m_U113 == null)
        {
            m_U113 = new U113("U113", Level);
        }
        else
        {
            m_U113.ResetValues();
        }
        return m_U113;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_EP_NBR;

    protected CoreDecimal W_FIRST_EP_NBR_OF_FISCAL_YR;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U113_A_CONSTANTS_VALUES_EP_NBR_1 A_CONSTANTS_VALUES_EP_NBR_1 = new U113_A_CONSTANTS_VALUES_EP_NBR_1(Name, Level);
            A_CONSTANTS_VALUES_EP_NBR_1.Run();
            A_CONSTANTS_VALUES_EP_NBR_1.Dispose();
            A_CONSTANTS_VALUES_EP_NBR_1 = null;

            U113_RUN_0_2 RUN_0_2 = new U113_RUN_0_2(Name, Level);
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



public class U113_A_CONSTANTS_VALUES_EP_NBR_1 : U113
{

    public U113_A_CONSTANTS_VALUES_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U113_A_CONSTANTS_VALUES_EP_NBR_1)"

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


    #region "Standard Generated Procedures(U113_A_CONSTANTS_VALUES_EP_NBR_1)"


    #region "Automatic Item Initialization(U113_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U113_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:22 PM

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


    #region "FILE Management Procedures(U113_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:22 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U113_A_CONSTANTS_VALUES_EP_NBR_1)"


    public void Run()
    {

        try
        {
            Request("A_CONSTANTS_VALUES_EP_NBR_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                if (Transaction())
                {
                    W_CURRENT_EP_NBR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR");
                    W_FIRST_EP_NBR_OF_FISCAL_YR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("FIRST_EP_NBR_OF_FISCAL_YR");

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
            EndRequest("A_CONSTANTS_VALUES_EP_NBR_1");

        }

    }







    #endregion


}
//A_CONSTANTS_VALUES_EP_NBR_1



public class U113_RUN_0_2 : U113
{

    public U113_RUN_0_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF113_DEFAULT_COMP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F113_DEFAULT_COMP", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_DEFAULT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_DEFAULT", false, false, false, 0, "m_trnTRANS_UPDATE");

        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF110_COMPENSATION.InitializeItems += fleF110_COMPENSATION_AutomaticItemInitialization;
        fleF110_DEFAULT.InitializeItems += fleF110_DEFAULT_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U113_RUN_0_2)"

    private SqlFileObject fleF113_DEFAULT_COMP;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF110_COMPENSATION;
    private DCharacter COMPENSATION_STATUS_ACCEPTED = new DCharacter("COMPENSATION_STATUS_ACCEPTED", 1);
    private void COMPENSATION_STATUS_ACCEPTED_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
            if (fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_FROM") <= W_CURRENT_EP_NBR.Value & fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_TO") >= W_CURRENT_EP_NBR.Value)
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

    private SqlFileObject fleF110_DEFAULT;


    #endregion


    #region "Standard Generated Procedures(U113_RUN_0_2)"


    #region "Automatic Item Initialization(U113_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:22 PM

    //#-----------------------------------------
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:22 PM
    //#-----------------------------------------
    private void fleF190_COMP_CODES_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("COMP_CODE", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE"));
            fleF190_COMP_CODES.set_SetValue("FACTOR", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("FACTOR"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_DATE", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_DATE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_TIME", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_TIME"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF110_COMPENSATION_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:22 PM
    //#-----------------------------------------
    private void fleF110_COMPENSATION_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_COMPENSATION.set_SetValue("DOC_NBR", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR"));
            fleF110_COMPENSATION.set_SetValue("COMP_CODE", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE"));
            fleF110_COMPENSATION.set_SetValue("FACTOR", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("FACTOR"));
            fleF110_COMPENSATION.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_COMPENSATION.set_SetValue("COMP_UNITS", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("COMP_UNITS"));
            fleF110_COMPENSATION.set_SetValue("AMT_GROSS", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS"));
            fleF110_COMPENSATION.set_SetValue("AMT_NET", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET"));
            fleF110_COMPENSATION.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_DATE", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_TIME", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_COMPENSATION.set_SetValue("FILLER", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF110_COMPENSATION.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_COMPENSATION.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));

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
    //# fleF110_DEFAULT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:22 PM
    //#-----------------------------------------
    private void fleF110_DEFAULT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_DEFAULT.set_SetValue("DOC_NBR", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR"));
            fleF110_DEFAULT.set_SetValue("COMP_CODE", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE"));
            fleF110_DEFAULT.set_SetValue("FACTOR", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("FACTOR"));
            fleF110_DEFAULT.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_DEFAULT.set_SetValue("COMP_UNITS", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("COMP_UNITS"));
            fleF110_DEFAULT.set_SetValue("AMT_GROSS", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS"));
            fleF110_DEFAULT.set_SetValue("AMT_NET", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET"));
            fleF110_DEFAULT.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_DEFAULT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_DEFAULT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF113_DEFAULT_COMP.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_DEFAULT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_DEFAULT.set_SetValue("FILLER", !Fixed, fleF113_DEFAULT_COMP.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF110_DEFAULT.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_DEFAULT.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            //TODO: Manual steps may be required.
            fleF110_DEFAULT.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_DEFAULT.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));

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


    #region "Transaction Management Procedures(U113_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:22 PM

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
        fleF113_DEFAULT_COMP.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
        fleF110_DEFAULT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U113_RUN_0_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:22 PM

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
            fleF113_DEFAULT_COMP.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF110_COMPENSATION.Dispose();
            fleF110_DEFAULT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U113_RUN_0_2)"


    public void Run()
    {

        try
        {
            Request("RUN_0_2");

            while (fleF113_DEFAULT_COMP.QTPForMissing())
            {
                // --> GET F113_DEFAULT_COMP <--

                fleF113_DEFAULT_COMP.GetData();
                // --> End GET F113_DEFAULT_COMP <--

                while (fleF190_COMP_CODES.QTPForMissing("1"))
                {
                    // --> GET F190_COMP_CODES <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")));

                    fleF190_COMP_CODES.GetData(m_strWhere.ToString());
                    // --> End GET F190_COMP_CODES <--

                    while (fleF110_COMPENSATION.QTPForMissing("2"))
                    {
                        // --> GET F110_COMPENSATION <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF110_COMPENSATION.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE")));
                        m_strWhere.Append(" And ").Append(fleF110_COMPENSATION.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF113_DEFAULT_COMP.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" And ").Append(fleF110_COMPENSATION.ElementOwner("EP_NBR")).Append(" = ");
                        m_strWhere.Append((W_CURRENT_EP_NBR.Value));
                        m_strWhere.Append(" And ").Append(fleF110_COMPENSATION.ElementOwner("PROCESS_SEQ")).Append(" = ");
                        m_strWhere.Append((fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ")));

                        fleF110_COMPENSATION.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F110_COMPENSATION <--


                        if (Transaction())
                        {

                             if (Select_If())
                            {

                                fleF110_DEFAULT.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                                fleF110_DEFAULT.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                                fleF110_DEFAULT.set_SetValue("COMP_CODE", fleF113_DEFAULT_COMP.GetStringValue("COMP_CODE"));


                                fleF110_DEFAULT.set_SetValue("COMP_TYPE", fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));


                                fleF110_DEFAULT.set_SetValue("PROCESS_SEQ", fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));


                                fleF110_DEFAULT.set_SetValue("FACTOR", fleF113_DEFAULT_COMP.GetDecimalValue("FACTOR"));


                                fleF110_DEFAULT.set_SetValue("FACTOR_OVERRIDE", fleF113_DEFAULT_COMP.GetStringValue("FACTOR_OVERRIDE"));


                                fleF110_DEFAULT.set_SetValue("COMP_UNITS", fleF113_DEFAULT_COMP.GetDecimalValue("COMP_UNITS"));


                                fleF110_DEFAULT.set_SetValue("AMT_GROSS", fleF113_DEFAULT_COMP.GetDecimalValue("AMT_GROSS"));


                                fleF110_DEFAULT.set_SetValue("AMT_NET", fleF113_DEFAULT_COMP.GetDecimalValue("AMT_NET"));


                                fleF110_DEFAULT.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                                fleF110_DEFAULT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                                fleF110_DEFAULT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                                fleF110_DEFAULT.set_SetValue("LAST_MOD_USER_ID", "U113 DEFINED  ");

                                fleF110_DEFAULT.OutPut(OutPutType.Add, null, !fleF110_COMPENSATION.Exists());

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
            EndRequest("RUN_0_2");

        }

    }







    #endregion


}
//RUN_0_2




