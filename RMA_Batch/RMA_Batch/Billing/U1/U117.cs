
#region "Screen Comments"

// #> PROGRAM         U117.QTS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// CALCULATE any `percentage` based `deduction` type transaction
// such as`TAX` for all pay codes
// All percentage based deductions are applied against the 
// Potential Payment amount (`PAYPOT`)
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 93/JAN/01  ____   B.E.     - original
// 93/MAY/20  ____   B.E.     - optimize, removed SELECT, round calc
// 93/JUN/08  ____   B.E.     - round using ROUND function
// 1999/Feb/18         S.B.     - Checked for Y2K.
// 1999/June/01  S.B.     - Added the use file
// def_compensation_status.def to 
// prevent hard coding of compensation-status.
// 2001/may/22 B.E. subfile f119 made permanent for icu payroll
// 2001/may/23 B.E. gross amount of TAX was original the total dollars taxed
// which was a figure that was not used. Using this amount
// also increased the gross amount of the TOTDED transaction
// and this made the gross amt of the PAYEFT transaction
// be lower than the net amt since the gross amount was 
// calculated as TOTBIL - TOTDED. 
// This gross amount now set equal to net amount.
// 2001/nov/09 B.E. - modified this program to not process specifically `TAX`
// deductions but all `percentage` based `deductions`.
// 2001/nov/27 B.E. - the nov/09 changed restricted the copying of `fixed
// amount` deductions from being copied into the f119.sf
// and therefore there never appeared in f119-ytd so
// changed this program to select them but only
// process them into the subfile and be ignored in all
// other updates
// - the method of determining the amount of the deduction 
// is determined by the `F` lat or `P`ercentage factor
// of deduction 
// 2003/dec/24    - alpha doctor nbr
// 2006/may/10 b.e.      - $1M payroll changes to size of calculated fields
// 2016/Sep/13 MC1  - Helena requested to not allow negative TAX calculation


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U117 : BaseClassControl
{

    private U117 m_U117;

    public U117(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);


    }

    public U117(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);


    }

    public override void Dispose()
    {
        if ((m_U117 != null))
        {
            m_U117.CloseTransactionObjects();
            m_U117 = null;
        }
    }

    public U117 GetU117(int Level)
    {
        if (m_U117 == null)
        {
            m_U117 = new U117("U117", Level);
        }
        else
        {
            m_U117.ResetValues();
        }
        return m_U117;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_EP_NBR;
    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal PAYPOT_SEQ;
    protected CoreCharacter PAYPOT_TYPE;

    protected CoreCharacter PAYPOT_GROUP;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U117_CONST_MSTR_GET_EP_NBR_1 CONST_MSTR_GET_EP_NBR_1 = new U117_CONST_MSTR_GET_EP_NBR_1(Name, Level);
            CONST_MSTR_GET_EP_NBR_1.Run();
            CONST_MSTR_GET_EP_NBR_1.Dispose();
            CONST_MSTR_GET_EP_NBR_1 = null;

            U117_U117A_GET_PAYPOT_2 U117A_GET_PAYPOT_2 = new U117_U117A_GET_PAYPOT_2(Name, Level);
            U117A_GET_PAYPOT_2.Run();
            U117A_GET_PAYPOT_2.Dispose();
            U117A_GET_PAYPOT_2 = null;

            U117_CALC_PERCENTAGE_DEDUCTIONS_3 CALC_PERCENTAGE_DEDUCTIONS_3 = new U117_CALC_PERCENTAGE_DEDUCTIONS_3(Name, Level);
            CALC_PERCENTAGE_DEDUCTIONS_3.Run();
            CALC_PERCENTAGE_DEDUCTIONS_3.Dispose();
            CALC_PERCENTAGE_DEDUCTIONS_3 = null;

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



public class U117_CONST_MSTR_GET_EP_NBR_1 : U117
{

    public U117_CONST_MSTR_GET_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U117_CONST_MSTR_GET_EP_NBR_1)"

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


    #region "Standard Generated Procedures(U117_CONST_MSTR_GET_EP_NBR_1)"


    #region "Automatic Item Initialization(U117_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U117_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:14:06 PM

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


    #region "FILE Management Procedures(U117_CONST_MSTR_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:14:06 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U117_CONST_MSTR_GET_EP_NBR_1)"


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



public class U117_U117A_GET_PAYPOT_2 : U117
{

    public U117_U117A_GET_PAYPOT_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U117_U117A_GET_PAYPOT_2)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("PAYPOT"));


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


    #region "Standard Generated Procedures(U117_U117A_GET_PAYPOT_2)"


    #region "Automatic Item Initialization(U117_U117A_GET_PAYPOT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U117_U117A_GET_PAYPOT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:14:06 PM

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
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U117_U117A_GET_PAYPOT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:14:06 PM

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
            fleF190_COMP_CODES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U117_U117A_GET_PAYPOT_2)"


    public void Run()
    {

        try
        {
            Request("U117A_GET_PAYPOT_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    PAYPOT_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    PAYPOT_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("U117A_GET_PAYPOT_2");

        }

    }







    #endregion


}
//U117A_GET_PAYPOT_2



public class U117_CALC_PERCENTAGE_DEDUCTIONS_3 : U117
{

    public U117_CALC_PERCENTAGE_DEDUCTIONS_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_PAYPOT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_PAYPOT", false, false, false, 0, "m_trnTRANS_UPDATE");
        AMT_NET_DEDUC = new CoreInteger("AMT_NET_DEDUC", 10, this);
        fleU117_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U117_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF110_UPDATE_DEDUC_TRANSACTION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_UPDATE_DEDUC_TRANSACTION", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        W_DEDUCTION_TYPE.GetValue += W_DEDUCTION_TYPE_GetValue;
        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        X_NOT_NEEDED.GetValue += X_NOT_NEEDED_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        X_COMP_CODE.GetValue += X_COMP_CODE_GetValue;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF110_PAYPOT.InitializeItems += fleF110_PAYPOT_AutomaticItemInitialization;
        fleF110_UPDATE_DEDUC_TRANSACTION.InitializeItems += fleF110_UPDATE_DEDUC_TRANSACTION_AutomaticItemInitialization;
        COMP_CODE.GetValue += COMP_CODE_GetValue;
        X_AMT_NET.GetValue += X_AMT_NET_GetValue;
        X_AMT_GROSS.GetValue += X_AMT_GROSS_GetValue;

        DEBUG_NOTE = new CoreCharacter("DEBUG_NOTE", 64, this, Common.cEmptyString);

    }

    private CoreCharacter DEBUG_NOTE;

    #region "Declarations (Variables, Files and Transactions)(U117_CALC_PERCENTAGE_DEDUCTIONS_3)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF110_COMPENSATION;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF110_PAYPOT;

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

    private DCharacter W_DEDUCTION_TYPE = new DCharacter("W_DEDUCTION_TYPE", 1);
    private void W_DEDUCTION_TYPE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("FACTOR")) < 10000)
            {
                CurrentValue = "P";
            }
            else
            {
                CurrentValue = "F";
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

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "D")
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

    private CoreInteger AMT_NET_DEDUC;
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
    private SqlFileObject fleU117_AUDIT;
    private SqlFileObject fleF110_UPDATE_DEDUC_TRANSACTION;
    private DInteger X_NOT_NEEDED = new DInteger("X_NOT_NEEDED", 10);
    private void X_NOT_NEEDED_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DCharacter X_REC_TYPE = new DCharacter("X_REC_TYPE", 1);
    private void X_REC_TYPE_GetValue(ref string Value)
    {

        try
        {
            Value = "A";


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
    private DCharacter X_COMP_CODE = new DCharacter("X_COMP_CODE", 6);
    private void X_COMP_CODE_GetValue(ref string Value)
    {

        try
        {
            Value = fleF110_COMPENSATION.GetStringValue("COMP_CODE");


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
    private SqlFileObject fleF119;

    private DCharacter COMP_CODE = new DCharacter("COMP_CODE", 6);
    private void COMP_CODE_GetValue(ref string Value)
    {
        try
        {
            Value = X_COMP_CODE.Value;
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

    private DInteger X_AMT_NET = new DInteger("X_AMT_NET", 10);
    private void X_AMT_NET_GetValue(ref decimal Value)
    {
        try
        {
            Value = X_NOT_NEEDED.Value;
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

    private DInteger X_AMT_GROSS = new DInteger("X_AMT_GROSS", 10);
    private void X_AMT_GROSS_GetValue(ref decimal Value)
    {
        try
        {
            Value = AMT_NET_DEDUC.Value;
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


    #region "Standard Generated Procedures(U117_CALC_PERCENTAGE_DEDUCTIONS_3)"


    #region "Automatic Item Initialization(U117_CALC_PERCENTAGE_DEDUCTIONS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:14:11 PM

    //#-----------------------------------------
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:14:06 PM
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
    //# fleF110_PAYPOT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:14:06 PM
    //#-----------------------------------------
    private void fleF110_PAYPOT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_PAYPOT.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_PAYPOT.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_PAYPOT.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_PAYPOT.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_PAYPOT.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_PAYPOT.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_PAYPOT.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_PAYPOT.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_PAYPOT.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_PAYPOT.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_PAYPOT.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_PAYPOT.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_PAYPOT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_PAYPOT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_PAYPOT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_PAYPOT.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_UPDATE_DEDUC_TRANSACTION_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:14:08 PM
    //#-----------------------------------------
    private void fleF110_UPDATE_DEDUC_TRANSACTION_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_UPDATE_DEDUC_TRANSACTION.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(U117_CALC_PERCENTAGE_DEDUCTIONS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:14:06 PM

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
        fleF110_PAYPOT.Transaction = m_trnTRANS_UPDATE;
        fleU117_AUDIT.Transaction = m_trnTRANS_UPDATE;
        fleF110_UPDATE_DEDUC_TRANSACTION.Transaction = m_trnTRANS_UPDATE;
        fleF119.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U117_CALC_PERCENTAGE_DEDUCTIONS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:14:06 PM

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
            fleF110_PAYPOT.Dispose();
            fleU117_AUDIT.Dispose();
            fleF110_UPDATE_DEDUC_TRANSACTION.Dispose();
            fleF119.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U117_CALC_PERCENTAGE_DEDUCTIONS_3)"


    public void Run()
    {

        try
        {
            Request("CALC_PERCENTAGE_DEDUCTIONS_3");

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

                        while (fleF110_PAYPOT.QTPForMissing("3"))
                        {
                            // --> GET F110_PAYPOT <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF110_PAYPOT.ElementOwner("EP_NBR")).Append(" = ");
                            m_strWhere.Append((fleF110_COMPENSATION.GetDecimalValue("EP_NBR")));
                            m_strWhere.Append(" And ").Append(fleF110_PAYPOT.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("PAYPOT"));
                            m_strWhere.Append(" And ").Append(fleF110_PAYPOT.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" And ").Append(fleF110_PAYPOT.ElementOwner("PROCESS_SEQ")).Append(" = ");
                            m_strWhere.Append((PAYPOT_SEQ.Value));

                            fleF110_PAYPOT.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F110_PAYPOT <--


                            if (Transaction())
                            {
                                if (Select_If())
                                {
                                    if (QDesign.NULL(W_DEDUCTION_TYPE.Value) == "P" & QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "TAX" & QDesign.NULL(fleF110_PAYPOT.GetDecimalValue("AMT_NET")) > 0)
                                    {
                                        AMT_NET_DEDUC.Value = QDesign.Round((fleF110_PAYPOT.GetDecimalValue("AMT_NET") * fleF110_COMPENSATION.GetDecimalValue("FACTOR")) / 10000, 0, RoundOptionTypes.Near);
                                    }
                                    else if (QDesign.NULL(W_DEDUCTION_TYPE.Value) == "P" & QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) == "TAX" & fleF110_PAYPOT.GetDecimalValue("AMT_NET") <= 0)
                                    {
                                        AMT_NET_DEDUC.Value = 0;
                                    }
                                    else if (QDesign.NULL(W_DEDUCTION_TYPE.Value) == "P")
                                    {
                                        AMT_NET_DEDUC.Value = QDesign.Round((fleF110_PAYPOT.GetDecimalValue("AMT_NET") * fleF110_COMPENSATION.GetDecimalValue("FACTOR")) / 10000, 0, RoundOptionTypes.Near);
                                    }
                                    else
                                    {
                                        AMT_NET_DEDUC.Value = fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                                    }
                                    SubFile(ref m_trnTRANS_UPDATE, ref fleU117_AUDIT, SubFileType.Keep, fleF110_COMPENSATION, "DOC_NBR", "EP_NBR", "COMP_CODE", PAYPOT_SEQ, fleF110_PAYPOT, "AMT_NET",
                                    fleF110_COMPENSATION, "FACTOR", AMT_NET_DEDUC);


                                    fleF110_COMPENSATION.set_SetValue("FACTOR_OVERRIDE", "*");
                                    fleF110_COMPENSATION.set_SetValue("AMT_GROSS", AMT_NET_DEDUC.Value);
                                    fleF110_COMPENSATION.set_SetValue("AMT_NET", AMT_NET_DEDUC.Value);
                                    fleF110_COMPENSATION.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);
                                    fleF110_COMPENSATION.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                                    fleF110_COMPENSATION.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                                    fleF110_COMPENSATION.set_SetValue("LAST_MOD_USER_ID", "U117 gen`d");
                                    fleF110_COMPENSATION.OutPut(OutPutType.Update, null, QDesign.NULL(fleF110_COMPENSATION.GetDecimalValue("FACTOR")) < 10000);

                                    DEBUG_NOTE.Value = "Generated By: u117";
                                    SubFile(ref m_trnTRANS_UPDATE, ref fleF119, SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, "DOC_NBR", X_COMP_CODE, fleF190_COMP_CODES, "REPORTING_SEQ", "COMP_CODE_GROUP", X_REC_TYPE,
                                    X_NOT_NEEDED, AMT_NET_DEDUC, DEBUG_NOTE);


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
            EndRequest("CALC_PERCENTAGE_DEDUCTIONS_3");

        }

    }







    #endregion


}
//CALC_PERCENTAGE_DEDUCTIONS_3




