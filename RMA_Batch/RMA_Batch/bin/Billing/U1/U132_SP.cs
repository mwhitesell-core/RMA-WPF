
#region "Screen Comments"

// #> PROGRAM-ID.     u132_sp.qts
// ((C)) Dyad Technologies
// PURPOSE: Uploads transactions from a `text` file into the special
// payments file (F114) so payment will be created 
// during the current EP payroll run 
// MODIFICATION HISTORY
// DATE     WHO     DESCRIPTION
// 2007/jan/09 brad    - cloned from u132.qts when that program was split
// into u132_dc.qts and this one u132_sp.qts
// 2008/sep/26 brad1   - added rec-type =  A  in f114 update so that upload into f119 goes into `94` screen
// 2009/jun/18 MC      - include rec-type `A` in the access statements of all requests
// 2012/Apr/05   MC1     - add `on errors report` when output file f114


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U132_SP : BaseClassControl
{

    private U132_SP m_U132_SP;

    public U132_SP(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);


    }

    public U132_SP(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U132_SP != null))
        {
            m_U132_SP.CloseTransactionObjects();
            m_U132_SP = null;
        }
    }

    public U132_SP GetU132_SP(int Level)
    {
        if (m_U132_SP == null)
        {
            m_U132_SP = new U132_SP("U132_SP", Level);
        }
        else
        {
            m_U132_SP.ResetValues();
        }
        return m_U132_SP;
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

            U132_SP_CONST_MSTR_GET_EP_NBR_1 CONST_MSTR_GET_EP_NBR_1 = new U132_SP_CONST_MSTR_GET_EP_NBR_1(Name, Level);
            CONST_MSTR_GET_EP_NBR_1.Run();
            CONST_MSTR_GET_EP_NBR_1.Dispose();
            CONST_MSTR_GET_EP_NBR_1 = null;

            U132_SP_PROCESS_VERIFY_DATA_2 PROCESS_VERIFY_DATA_2 = new U132_SP_PROCESS_VERIFY_DATA_2(Name, Level);
            PROCESS_VERIFY_DATA_2.Run();
            PROCESS_VERIFY_DATA_2.Dispose();
            PROCESS_VERIFY_DATA_2 = null;

            U132_SP_PROCESS_3 PROCESS_3 = new U132_SP_PROCESS_3(Name, Level);
            PROCESS_3.Run();
            PROCESS_3.Dispose();
            PROCESS_3 = null;

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



public class U132_SP_CONST_MSTR_GET_EP_NBR_1 : U132_SP
{

    public U132_SP_CONST_MSTR_GET_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U132_SP_CONST_MSTR_GET_EP_NBR_1)"

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


    #region "Standard Generated Procedures(U132_SP_CONST_MSTR_GET_EP_NBR_1)"


    #region "Automatic Item Initialization(U132_SP_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U132_SP_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:23 PM

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


    #region "FILE Management Procedures(U132_SP_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:23 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U132_SP_CONST_MSTR_GET_EP_NBR_1)"


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



public class U132_SP_PROCESS_VERIFY_DATA_2 : U132_SP
{

    public U132_SP_PROCESS_VERIFY_DATA_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU132DAT = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "$APPLICATION_UPL/U132", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF114_SPECIAL_PAYMENTS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F114_SPECIAL_PAYMENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU132_ERRORS = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U132_ERRORS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        fleF114_SPECIAL_PAYMENTS.InitializeItems += fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U132_SP_PROCESS_VERIFY_DATA_2)"

    private SqlFileObject fleU132DAT;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF114_SPECIAL_PAYMENTS;
    private SqlFileObject fleF020_DOCTOR_MSTR;
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
            if (!fleF190_COMP_CODES.Exists() | !fleF020_DOCTOR_MSTR.Exists())
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

    private SqlFileObject fleU132_ERRORS;


    #endregion


    #region "Standard Generated Procedures(U132_SP_PROCESS_VERIFY_DATA_2)"


    #region "Automatic Item Initialization(U132_SP_PROCESS_VERIFY_DATA_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:27 PM

    //#-----------------------------------------
    //# fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:24 PM
    //#-----------------------------------------
    private void fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF114_SPECIAL_PAYMENTS.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_DATE", !Fixed, fleF190_COMP_CODES.GetDecimalValue("LAST_MOD_DATE"));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_TIME", !Fixed, fleF190_COMP_CODES.GetDecimalValue("LAST_MOD_TIME"));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF190_COMP_CODES.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:25 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("DOC_NBR"));

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


    #region "Transaction Management Procedures(U132_SP_PROCESS_VERIFY_DATA_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:23 PM

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
        fleU132DAT.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF114_SPECIAL_PAYMENTS.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU132_ERRORS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U132_SP_PROCESS_VERIFY_DATA_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:23 PM

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
            fleU132DAT.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF114_SPECIAL_PAYMENTS.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleU132_ERRORS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U132_SP_PROCESS_VERIFY_DATA_2)"


    public void Run()
    {

        try
        {
            Request("PROCESS_VERIFY_DATA_2");

            while (fleU132DAT.QTPForMissing())
            {
                // --> GET U132DAT <--

                fleU132DAT.GetData();
                // --> End GET U132DAT <--

                while (fleF190_COMP_CODES.QTPForMissing("1"))
                {
                    // --> GET F190_COMP_CODES <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU132DAT.GetStringValue("COMP_CODE")));

                    fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F190_COMP_CODES <--

                    while (fleF114_SPECIAL_PAYMENTS.QTPForMissing("2"))
                    {
                        // --> GET F114_SPECIAL_PAYMENTS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleU132DAT.GetStringValue("COMP_CODE")));
                        m_strWhere.Append(" And ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleU132DAT.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" And ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("EP_NBR_FROM")).Append(" = ");
                        m_strWhere.Append((W_CURRENT_EP_NBR.Value));
                        m_strWhere.Append(" And ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("REC_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("A"));

                        fleF114_SPECIAL_PAYMENTS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F114_SPECIAL_PAYMENTS <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleU132DAT.GetStringValue("DOC_NBR")));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F020_DOCTOR_MSTR <--


                            if (Transaction())
                            {

                                 if (Select_If())
                                {
                                    SubFile(ref m_trnTRANS_UPDATE, ref fleU132_ERRORS, SubFileType.Keep, W_CURRENT_EP_NBR, fleU132DAT);


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
            EndRequest("PROCESS_VERIFY_DATA_2");

        }

    }







    #endregion


}
//PROCESS_VERIFY_DATA_2



public class U132_SP_PROCESS_3 : U132_SP
{

    public U132_SP_PROCESS_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU132DAT = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "$APPLICATION_UPL/U132", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF114_SPECIAL_PAYMENTS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F114_SPECIAL_PAYMENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU132_SP_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U132_SP_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF114_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F114_SPECIAL_PAYMENTS", "F114_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        fleF114_ADD.SetItemFinals += fleF114_ADD_SetItemFinals;
        fleF114_SPECIAL_PAYMENTS.InitializeItems += fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF114_ADD.InitializeItems += fleF114_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U132_SP_PROCESS_3)"

    private SqlFileObject fleU132DAT;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF114_SPECIAL_PAYMENTS;
    private SqlFileObject fleF020_DOCTOR_MSTR;
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
    private SqlFileObject fleU132_SP_AUDIT;
    private SqlFileObject fleF114_ADD;

    private void fleF114_ADD_SetItemFinals()
    {

        try
        {
            fleF114_ADD.set_SetValue("DOC_NBR", fleU132DAT.GetStringValue("DOC_NBR"));
            fleF114_ADD.set_SetValue("COMP_CODE", fleU132DAT.GetStringValue("COMP_CODE"));
            fleF114_ADD.set_SetValue("REC_TYPE", "A");
            fleF114_ADD.set_SetValue("EP_NBR_FROM", W_CURRENT_EP_NBR.Value);
            fleF114_ADD.set_SetValue("EP_NBR_TO", W_CURRENT_EP_NBR.Value);
            fleF114_ADD.set_SetValue("COMP_UNITS", 0);
            fleF114_ADD.set_SetValue("AMT_GROSS", fleU132DAT.GetDecimalValue("SIGNED_AMT_NET"));
            fleF114_ADD.set_SetValue("AMT_NET", fleU132DAT.GetDecimalValue("SIGNED_AMT_NET"));
            fleF114_ADD.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF114_ADD.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF114_ADD.set_SetValue("LAST_MOD_USER_ID", "u132_sp Gen`d");


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


    #region "Standard Generated Procedures(U132_SP_PROCESS_3)"


    #region "Automatic Item Initialization(U132_SP_PROCESS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:31 PM

    //#-----------------------------------------
    //# fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:28 PM
    //#-----------------------------------------
    private void fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF114_SPECIAL_PAYMENTS.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_DATE", !Fixed, fleF190_COMP_CODES.GetDecimalValue("LAST_MOD_DATE"));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_TIME", !Fixed, fleF190_COMP_CODES.GetDecimalValue("LAST_MOD_TIME"));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF190_COMP_CODES.GetStringValue("LAST_MOD_USER_ID"));

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
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:28 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("DOC_NBR"));

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
    //# fleF114_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:11:31 PM
    //#-----------------------------------------
    private void fleF114_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF114_ADD.set_SetValue("COMP_CODE", !Fixed, fleF190_COMP_CODES.GetStringValue("COMP_CODE"));
            fleF114_ADD.set_SetValue("LAST_MOD_DATE", !Fixed, fleF190_COMP_CODES.GetDecimalValue("LAST_MOD_DATE"));
            fleF114_ADD.set_SetValue("LAST_MOD_TIME", !Fixed, fleF190_COMP_CODES.GetDecimalValue("LAST_MOD_TIME"));
            fleF114_ADD.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF190_COMP_CODES.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF114_ADD.set_SetValue("DOC_NBR", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("DOC_NBR"));
            fleF114_ADD.set_SetValue("REC_TYPE", !Fixed, fleF114_SPECIAL_PAYMENTS.GetStringValue("REC_TYPE"));
            fleF114_ADD.set_SetValue("EP_NBR_FROM", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_FROM"));
            fleF114_ADD.set_SetValue("EP_NBR_TO", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_TO"));
            fleF114_ADD.set_SetValue("COMP_UNITS", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("COMP_UNITS"));
            fleF114_ADD.set_SetValue("AMT_GROSS", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS"));
            fleF114_ADD.set_SetValue("AMT_NET", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_NET"));
            fleF114_ADD.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF114_SPECIAL_PAYMENTS.GetDecimalValue("EP_NBR_ENTRY"));

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


    #region "Transaction Management Procedures(U132_SP_PROCESS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:23 PM

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
        fleU132DAT.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF114_SPECIAL_PAYMENTS.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU132_SP_AUDIT.Transaction = m_trnTRANS_UPDATE;
        fleF114_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U132_SP_PROCESS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:11:23 PM

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
            fleU132DAT.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF114_SPECIAL_PAYMENTS.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleU132_SP_AUDIT.Dispose();
            fleF114_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U132_SP_PROCESS_3)"


    public void Run()
    {

        try
        {
            Request("PROCESS_3");

            while (fleU132DAT.QTPForMissing())
            {
                // --> GET U132DAT <--

                fleU132DAT.GetData();
                // --> End GET U132DAT <--

                while (fleF190_COMP_CODES.QTPForMissing("1"))
                {
                    // --> GET F190_COMP_CODES <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU132DAT.GetStringValue("COMP_CODE")));

                    fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F190_COMP_CODES <--

                    while (fleF114_SPECIAL_PAYMENTS.QTPForMissing("2"))
                    {
                        // --> GET F114_SPECIAL_PAYMENTS <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleU132DAT.GetStringValue("COMP_CODE")));
                        m_strWhere.Append(" And ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleU132DAT.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" And ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("EP_NBR_FROM")).Append(" = ");
                        m_strWhere.Append((W_CURRENT_EP_NBR.Value));
                        m_strWhere.Append(" And ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("REC_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("A"));

                        fleF114_SPECIAL_PAYMENTS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F114_SPECIAL_PAYMENTS <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleU132DAT.GetStringValue("DOC_NBR")));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                            // --> End GET F020_DOCTOR_MSTR <--


                            if (Transaction())
                            {
                                SubFile(ref m_trnTRANS_UPDATE, ref fleU132_SP_AUDIT, SubFileType.Keep, W_CURRENT_EP_NBR, fleU132DAT);

                                fleF114_ADD.OutPut(OutPutType.Add, null, !fleF114_SPECIAL_PAYMENTS.Exists() & 1 == 1);

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
            EndRequest("PROCESS_3");

        }

    }







    #endregion


}
//PROCESS_3




