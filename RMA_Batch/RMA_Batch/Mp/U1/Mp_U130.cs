
#region "Screen Comments"

// #> PROGRAM-ID.     u130.qts
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// Copies payments into f114 to f110 and deletes them from f114
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 2004/02/25            b.e.    - original
// 2004/03/15  b.e. - add logic to factor amt-net


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Mp_U130 : BaseClassControl
{

    private Mp_U130 m_Mp_U130;

    public Mp_U130(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);


    }

    public Mp_U130(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_Mp_U130 != null))
        {
            m_Mp_U130.CloseTransactionObjects();
            m_Mp_U130 = null;
        }
    }

    public Mp_U130 GetMp_U130(int Level)
    {
        if (m_Mp_U130 == null)
        {
            m_Mp_U130 = new Mp_U130("Mp_U130", Level);
        }
        else
        {
            m_Mp_U130.ResetValues();
        }
        return m_Mp_U130;
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

            Mp_U130_CONST_MSTR_GET_EP_NBR_1 CONST_MSTR_GET_EP_NBR_1 = new Mp_U130_CONST_MSTR_GET_EP_NBR_1(Name, Level);
            CONST_MSTR_GET_EP_NBR_1.Run();
            CONST_MSTR_GET_EP_NBR_1.Dispose();
            CONST_MSTR_GET_EP_NBR_1 = null;

            Mp_U130_PROCESS_2 PROCESS_2 = new Mp_U130_PROCESS_2(Name, Level);
            PROCESS_2.Run();
            PROCESS_2.Dispose();
            PROCESS_2 = null;

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



public class Mp_U130_CONST_MSTR_GET_EP_NBR_1 : Mp_U130
{

    public Mp_U130_CONST_MSTR_GET_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U130_CONST_MSTR_GET_EP_NBR_1)"

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


    #region "Standard Generated Procedures(Mp_U130_CONST_MSTR_GET_EP_NBR_1)"


    #region "Automatic Item Initialization(Mp_U130_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Mp_U130_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:30 PM

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


    #region "FILE Management Procedures(Mp_U130_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:30 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U130_CONST_MSTR_GET_EP_NBR_1)"


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



public class Mp_U130_PROCESS_2 : Mp_U130
{

    public Mp_U130_PROCESS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF114_SPECIAL_PAYMENTS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F114_SPECIAL_PAYMENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleMp_U130_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U130_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF110_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_UPDATE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_UPDATE", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF114_DELETE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F114_SPECIAL_PAYMENTS", "F114_DELETE", false, false, false, 0, "m_trnTRANS_UPDATE");

        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        X_FACTOR.GetValue += X_FACTOR_GetValue;
        X_AMT_NET_FACTORED.GetValue += X_AMT_NET_FACTORED_GetValue;
        fleF110_ADD.SetItemFinals += fleF110_ADD_SetItemFinals;
        fleF110_COMPENSATION.SetItemFinals += fleF110_UPDATE_SetItemFinals;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF110_COMPENSATION.InitializeItems += fleF110_COMPENSATION_AutomaticItemInitialization;
        fleF110_ADD.InitializeItems += fleF110_ADD_AutomaticItemInitialization;
        fleF110_UPDATE.InitializeItems += fleF110_UPDATE_AutomaticItemInitialization;
        fleF114_DELETE.InitializeItems += fleF114_DELETE_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(Mp_U130_PROCESS_2)"

    private SqlFileObject fleF114_SPECIAL_PAYMENTS;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF110_COMPENSATION;
    public override bool SelectIf()
    {


        try
        {
            if (fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_FROM") <= W_CURRENT_EP_NBR.Value & fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_TO") >= W_CURRENT_EP_NBR.Value)
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
    private DDecimal X_FACTOR = new DDecimal("X_FACTOR", 6);
    private void X_FACTOR_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleF110_COMPENSATION.Exists())
            {
                CurrentValue = fleF110_COMPENSATION.GetDecimalValue("FACTOR");
            }
            else if (fleF190_COMP_CODES.Exists())
            {
                CurrentValue = fleF190_COMP_CODES.GetDecimalValue("FACTOR");
            }
            else
            {
                CurrentValue = 1;
            }

            Value = CurrentValue;

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
    private DDecimal X_AMT_NET_FACTORED = new DDecimal("X_AMT_NET_FACTORED", 6);
    private void X_AMT_NET_FACTORED_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Round((fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS") * fleF110_COMPENSATION.GetDecimalValue("FACTOR")) / 10000, 0, RoundOptionTypes.Near);


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
    private SqlFileObject fleMp_U130_AUDIT;
    private SqlFileObject fleF110_ADD;

    private void fleF110_ADD_SetItemFinals()
    {

        try
        {
            fleF110_ADD.set_SetValue("DOC_NBR", fleF114_SPECIAL_PAYMENTS.GetStringValue("DOC_NBR"));
            fleF110_ADD.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);
            fleF110_ADD.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);
            fleF110_ADD.set_SetValue("COMP_CODE", fleF114_SPECIAL_PAYMENTS.GetStringValue("COMP_CODE"));
            fleF110_ADD.set_SetValue("COMP_TYPE", fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_ADD.set_SetValue("PROCESS_SEQ", fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            fleF110_ADD.set_SetValue("FACTOR", fleF190_COMP_CODES.GetDecimalValue("FACTOR"));
            fleF110_ADD.set_SetValue("FACTOR_OVERRIDE", " ");
            fleF110_ADD.set_SetValue("COMP_UNITS", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("COMP_UNITS"));
            fleF110_ADD.set_SetValue("AMT_GROSS", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS"));
            fleF110_ADD.set_SetValue("AMT_NET", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_NET"));
            //fleF110_ADD.set_SetValue("AMT_NET", X_AMT_NET_FACTORED.Value);
            fleF110_ADD.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);
            fleF110_ADD.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF110_ADD.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF110_ADD.set_SetValue("LAST_MOD_USER_ID", "u130    Gen`d");


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

    private SqlFileObject fleF110_UPDATE;

    private void fleF110_UPDATE_SetItemFinals()
    {

        try
        {
            fleF110_COMPENSATION.set_SetValue("FACTOR_OVERRIDE", "*");
            fleF110_COMPENSATION.set_SetValue("COMP_UNITS", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("COMP_UNITS"));
            fleF110_COMPENSATION.set_SetValue("AMT_GROSS", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS"));
            fleF110_COMPENSATION.set_SetValue("AMT_NET", X_AMT_NET_FACTORED.Value);
            fleF110_COMPENSATION.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_USER_ID", "u130    Upd`d");


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

    private SqlFileObject fleF114_DELETE;


    #endregion


    #region "Standard Generated Procedures(Mp_U130_PROCESS_2)"


    #region "Automatic Item Initialization(Mp_U130_PROCESS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:34 PM

    //#-----------------------------------------
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:30 PM
    //#-----------------------------------------
    private void fleF190_COMP_CODES_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF190_COMP_CODES.set_SetValue("COMP_CODE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("COMP_CODE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_DATE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("LAST_MOD_DATE"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_TIME", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("LAST_MOD_TIME"));
            fleF190_COMP_CODES.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("LAST_MOD_USER_ID"));

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
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:30 PM
    //#-----------------------------------------
    private void fleF110_COMPENSATION_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_COMPENSATION.set_SetValue("DOC_NBR", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("DOC_NBR"));
            fleF110_COMPENSATION.set_SetValue("COMP_CODE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("COMP_CODE"));
            fleF110_COMPENSATION.set_SetValue("COMP_UNITS", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("COMP_UNITS"));
            fleF110_COMPENSATION.set_SetValue("AMT_GROSS", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS"));
            fleF110_COMPENSATION.set_SetValue("AMT_NET", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_NET"));
            fleF110_COMPENSATION.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_DATE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_TIME", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_COMPENSATION.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_COMPENSATION.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_COMPENSATION.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            fleF110_COMPENSATION.set_SetValue("FACTOR", !Fixed, fleF190_COMP_CODES.GetDecimalValue("FACTOR"));

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
    //# fleF110_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:32 PM
    //#-----------------------------------------
    private void fleF110_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_ADD.set_SetValue("DOC_NBR", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("DOC_NBR"));
            fleF110_ADD.set_SetValue("COMP_CODE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("COMP_CODE"));
            fleF110_ADD.set_SetValue("COMP_UNITS", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("COMP_UNITS"));
            fleF110_ADD.set_SetValue("AMT_GROSS", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS"));
            fleF110_ADD.set_SetValue("AMT_NET", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_NET"));
            fleF110_ADD.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_ADD.set_SetValue("LAST_MOD_DATE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_ADD.set_SetValue("LAST_MOD_TIME", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_ADD.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_ADD.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_ADD.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            fleF110_ADD.set_SetValue("FACTOR", !Fixed, fleF190_COMP_CODES.GetDecimalValue("FACTOR"));
            //TODO: Manual steps may be required.
            fleF110_ADD.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_ADD.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_ADD.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_ADD.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_UPDATE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:33 PM
    //#-----------------------------------------
    private void fleF110_UPDATE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_UPDATE.set_SetValue("DOC_NBR", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("DOC_NBR"));
            fleF110_UPDATE.set_SetValue("COMP_CODE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("COMP_CODE"));
            fleF110_UPDATE.set_SetValue("COMP_UNITS", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("COMP_UNITS"));
            fleF110_UPDATE.set_SetValue("AMT_GROSS", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS"));
            fleF110_UPDATE.set_SetValue("AMT_NET", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_NET"));
            fleF110_UPDATE.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_UPDATE.set_SetValue("LAST_MOD_DATE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_UPDATE.set_SetValue("LAST_MOD_TIME", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_UPDATE.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_UPDATE.set_SetValue("COMP_TYPE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_TYPE"));
            fleF110_UPDATE.set_SetValue("PROCESS_SEQ", !Fixed, fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ"));
            fleF110_UPDATE.set_SetValue("FACTOR", !Fixed, fleF190_COMP_CODES.GetDecimalValue("FACTOR"));
            //TODO: Manual steps may be required.
            fleF110_UPDATE.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_UPDATE.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_UPDATE.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_UPDATE.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF114_DELETE_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:45:34 PM
    //#-----------------------------------------
    private void fleF114_DELETE_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF114_DELETE.set_SetValue("DOC_NBR", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("DOC_NBR"));
            fleF114_DELETE.set_SetValue("COMP_CODE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("COMP_CODE"));
            fleF114_DELETE.set_SetValue("REC_TYPE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("REC_TYPE"));
            fleF114_DELETE.set_SetValue("EP_NBR_FROM", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_FROM"));
            fleF114_DELETE.set_SetValue("EP_NBR_TO", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_TO"));
            fleF114_DELETE.set_SetValue("COMP_UNITS", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("COMP_UNITS"));
            fleF114_DELETE.set_SetValue("AMT_GROSS", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS"));
            fleF114_DELETE.set_SetValue("AMT_NET", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_NET"));
            fleF114_DELETE.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_ENTRY"));
            fleF114_DELETE.set_SetValue("LAST_MOD_DATE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("LAST_MOD_DATE"));
            fleF114_DELETE.set_SetValue("LAST_MOD_TIME", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("LAST_MOD_TIME"));
            fleF114_DELETE.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("LAST_MOD_USER_ID"));

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


    #region "Transaction Management Procedures(Mp_U130_PROCESS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:30 PM

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
        fleF114_SPECIAL_PAYMENTS.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF110_COMPENSATION.Transaction = m_trnTRANS_UPDATE;
        fleMp_U130_AUDIT.Transaction = m_trnTRANS_UPDATE;
        fleF110_ADD.Transaction = m_trnTRANS_UPDATE;
        fleF110_UPDATE.Transaction = m_trnTRANS_UPDATE;
        fleF114_DELETE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Mp_U130_PROCESS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:45:30 PM

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
            fleF114_SPECIAL_PAYMENTS.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF110_COMPENSATION.Dispose();
            fleMp_U130_AUDIT.Dispose();
            fleF110_ADD.Dispose();
            fleF110_UPDATE.Dispose();
            fleF114_DELETE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Mp_U130_PROCESS_2)"


    public void Run()
    {

        try
        {
            Request("PROCESS_2");

            while (fleF114_SPECIAL_PAYMENTS.QTPForMissing())
            {
                // --> GET F114_SPECIAL_PAYMENTS <--

                fleF114_SPECIAL_PAYMENTS.GetData();
                // --> End GET F114_SPECIAL_PAYMENTS <--

                while (fleF190_COMP_CODES.QTPForMissing("1"))
                {
                    // --> GET F190_COMP_CODES <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF114_SPECIAL_PAYMENTS.GetStringValue("COMP_CODE")));

                    fleF190_COMP_CODES.GetData(m_strWhere.ToString());
                    // --> End GET F190_COMP_CODES <--

                    while (fleF110_COMPENSATION.QTPForMissing("2"))
                    {
                        // --> GET F110_COMPENSATION <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF110_COMPENSATION.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF114_SPECIAL_PAYMENTS.GetStringValue("COMP_CODE")));
                        m_strWhere.Append(" And ").Append(fleF110_COMPENSATION.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF114_SPECIAL_PAYMENTS.GetStringValue("DOC_NBR")));
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
                                SubFile(ref m_trnTRANS_UPDATE, ref fleMp_U130_AUDIT, SubFileType.Keep, W_CURRENT_EP_NBR, fleF114_SPECIAL_PAYMENTS, "DOC_NBR", fleF110_COMPENSATION, "EP_NBR", fleF114_SPECIAL_PAYMENTS, "COMP_CODE",
                                "AMT_GROSS", "AMT_NET", X_FACTOR, X_AMT_NET_FACTORED);

                                fleF110_ADD.OutPut(OutPutType.Add, null, !fleF110_COMPENSATION.Exists() & 1 == 1);


                                fleF110_COMPENSATION.OutPut(OutPutType.Update, null, fleF110_COMPENSATION.Exists() & 1 == 1);


                                fleF114_SPECIAL_PAYMENTS.OutPut(OutPutType.Delete, null, 1 == 1);

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
            EndRequest("PROCESS_2");

        }

    }







    #endregion


}
//PROCESS_2




