
#region "Screen Comments"

// Program: u140_e.qts
// Purpose: upload AFP payments to the payroll`s f114 special payments
// file so that they can be paid during the next payroll
// Additionally this pgm now creates non-payable but 
// tithe-able transactions for calculating dept tithe amounts.
// modification history
// 2004/??/?? b.e. - original
// 2004/11/25 b.e. - amt-gross now set to afp-payment-amt instead 
// of afp-payment-amt-total
// 2004/feb/04 b.e. - added access to f020 doctor master to get data to
// store doctor data in audit subfile so that later
// reports don`t have to access f020 to get this info.
// 05/mar/08 M.C.        - substitute afp-payment-percentage with afp-multi-doc-ra-percentage
// 07/aug/13 b.e. - summarize all payments for a doctor into a single
// f114 payment transaction
// 07/aug/15 M.C. - change temp item to reset at doc-nbr and output f114 at doc-nbr
// and subfile u140_e_audit at doc-nbr as well
// 08/may/09 brad  - upload goverance transactions (AFPCON) to f119  +  
// records INSTEAD OF f114 (otherwise they go to f110 and
// get paid - don`t want that). 
// We want to track the payments  for tithe calculations
// but not pay them. 
// 08/jun/16 M.C. - add a new request to create NONRB and NONRBP for rec type D
// 08/jun/30 M.C. - Brad changed his mind, he would like to create 
// transactions in f114-special-payment
// instead of f119 subfile for AFPCON, NONRB & NONRBP
// 08/jul/31 b.e. - originally payroll was A = 101c, B = mp. July 2008
// brought tithing and dep membership (depmem) charges
// and a new solo payroll - payroll C.
// Now payrolls B(mp) and C(solo) can`t just check the 
// f074 flag - they must also consider the afp group 
// and dept of doctor
// The current afp group that is `fuzzy` is H132 where
// some doctors get  paid in payroll B and others 
// in payroll C.
// Thus when running payroll B (in mp) test afp group
// and dept of doctor to exclude payroll + docs and 
// when running payroll + (in solo) ONLY include
// certain H132 docs based upon their dept and ignore
// the fact that f074 shows payroll B for H132.
// 08/aug/05 M.C. - change the selection criteria for payroll + and comment out for B
// 08/sep/02 M.C. - change the definition for solo doctors
// 08/sep/18 M.C. - ensure rec-type = `A` for solo and `C` for 101c
// 08/oct/14 M.C. - subtotal does not work properly, change to final old value + new value instead
// 2009/jul/08 MC1       - include f074-afp-group-sequence-mstr in the access of request u140_nonrb_nonrbp           
// - check on nonrbp-flag or solo-flag instead of hard coded group number


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U140_E : BaseClassControl
{

    private U140_E m_U140_E;

    public U140_E(string Name, int Level) : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 1, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 1, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_PLUS1 = new CoreDecimal("W_CURRENT_EP_NBR_PLUS1", 1, this, ResetTypes.ResetAtStartup);
        W_EP_FISCAL_NBR = new CoreDecimal("W_EP_FISCAL_NBR", 1, this, ResetTypes.ResetAtStartup);
        AFPCON_SEQ = new CoreDecimal("AFPCON_SEQ", 2, this, ResetTypes.ResetAtStartup);
        AFPCON_TYPE = new CoreCharacter("AFPCON_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        AFPCON_CODE_GROUP = new CoreCharacter("AFPCON_CODE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        NONRB_SEQ = new CoreDecimal("NONRB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        NONRB_TYPE = new CoreCharacter("NONRB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        NONRB_CODE_GROUP = new CoreCharacter("NONRB_CODE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        NONRBP_SEQ = new CoreDecimal("NONRBP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        NONRBP_TYPE = new CoreCharacter("NONRBP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        NONRBP_CODE_GROUP = new CoreCharacter("NONRBP_CODE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);


    }

    public U140_E(string Name, int Level, bool Request) : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 1, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 1, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_PLUS1 = new CoreDecimal("W_CURRENT_EP_NBR_PLUS1", 1, this, ResetTypes.ResetAtStartup);
        W_EP_FISCAL_NBR = new CoreDecimal("W_EP_FISCAL_NBR", 1, this, ResetTypes.ResetAtStartup);
        AFPCON_SEQ = new CoreDecimal("AFPCON_SEQ", 2, this, ResetTypes.ResetAtStartup);
        AFPCON_TYPE = new CoreCharacter("AFPCON_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        AFPCON_CODE_GROUP = new CoreCharacter("AFPCON_CODE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        NONRB_SEQ = new CoreDecimal("NONRB_SEQ", 2, this, ResetTypes.ResetAtStartup);
        NONRB_TYPE = new CoreCharacter("NONRB_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        NONRB_CODE_GROUP = new CoreCharacter("NONRB_CODE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        NONRBP_SEQ = new CoreDecimal("NONRBP_SEQ", 2, this, ResetTypes.ResetAtStartup);
        NONRBP_TYPE = new CoreCharacter("NONRBP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        NONRBP_CODE_GROUP = new CoreCharacter("NONRBP_CODE_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);


    }

    public override void Dispose()
    {
        if ((m_U140_E != null))
        {
            m_U140_E.CloseTransactionObjects();
            m_U140_E = null;
        }
    }

    public U140_E GetU140_E(int Level)
    {
        if (m_U140_E == null)
        {
            m_U140_E = new U140_E("U140_E", Level);
        }
        else
        {
            m_U140_E.ResetValues();
        }
        return m_U140_E;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_EP_NBR;
    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal W_CURRENT_EP_NBR_PLUS1;
    protected CoreDecimal W_EP_FISCAL_NBR;
    protected CoreDecimal AFPCON_SEQ;
    protected CoreCharacter AFPCON_TYPE;
    protected CoreCharacter AFPCON_CODE_GROUP;
    protected CoreDecimal NONRB_SEQ;
    protected CoreCharacter NONRB_TYPE;
    protected CoreCharacter NONRB_CODE_GROUP;
    protected CoreDecimal NONRBP_SEQ;
    protected CoreCharacter NONRBP_TYPE;

    protected CoreCharacter NONRBP_CODE_GROUP;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U140_E_U114A_CONST_VALUES_GET_EP_NBR_1 U114A_CONST_VALUES_GET_EP_NBR_1 = new U140_E_U114A_CONST_VALUES_GET_EP_NBR_1(Name, Level);
            U114A_CONST_VALUES_GET_EP_NBR_1.Run();
            U114A_CONST_VALUES_GET_EP_NBR_1.Dispose();
            U114A_CONST_VALUES_GET_EP_NBR_1 = null;

            U140_E_U140_GET_AFPCON_2 U140_GET_AFPCON_2 = new U140_E_U140_GET_AFPCON_2(Name, Level);
            U140_GET_AFPCON_2.Run();
            U140_GET_AFPCON_2.Dispose();
            U140_GET_AFPCON_2 = null;

            U140_E_U140_GET_NONRB_3 U140_GET_NONRB_3 = new U140_E_U140_GET_NONRB_3(Name, Level);
            U140_GET_NONRB_3.Run();
            U140_GET_NONRB_3.Dispose();
            U140_GET_NONRB_3 = null;

            U140_E_U140_GET_NONRBP_4 U140_GET_NONRBP_4 = new U140_E_U140_GET_NONRBP_4(Name, Level);
            U140_GET_NONRBP_4.Run();
            U140_GET_NONRBP_4.Dispose();
            U140_GET_NONRBP_4 = null;

            U140_E_U140_UPDATE_F114_5 U140_UPDATE_F114_5 = new U140_E_U140_UPDATE_F114_5(Name, Level);
            U140_UPDATE_F114_5.Run();
            U140_UPDATE_F114_5.Dispose();
            U140_UPDATE_F114_5 = null;

            U140_E_U140_NONRB_NONRBP_6 U140_NONRB_NONRBP_6 = new U140_E_U140_NONRB_NONRBP_6(Name, Level);
            U140_NONRB_NONRBP_6.Run();
            U140_NONRB_NONRBP_6.Dispose();
            U140_NONRB_NONRBP_6 = null;

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



public class U140_E_U114A_CONST_VALUES_GET_EP_NBR_1 : U140_E
{

    public U140_E_U114A_CONST_VALUES_GET_EP_NBR_1(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_E_U114A_CONST_VALUES_GET_EP_NBR_1)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF191_EARNINGS_PERIOD;

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


    #region "Standard Generated Procedures(U140_E_U114A_CONST_VALUES_GET_EP_NBR_1)"


    #region "Automatic Item Initialization(U140_E_U114A_CONST_VALUES_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_E_U114A_CONST_VALUES_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:15 PM

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
        fleF191_EARNINGS_PERIOD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_E_U114A_CONST_VALUES_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:15 PM

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
            fleF191_EARNINGS_PERIOD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_E_U114A_CONST_VALUES_GET_EP_NBR_1)"


    public void Run()
    {

        try
        {
            Request("U114A_CONST_VALUES_GET_EP_NBR_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF191_EARNINGS_PERIOD.QTPForMissing("1"))
                {
                    // --> GET F191_EARNINGS_PERIOD <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    fleF191_EARNINGS_PERIOD.GetData(m_strWhere.ToString());
                    // --> End GET F191_EARNINGS_PERIOD <--

                    if (Transaction())
                    {
                        W_CURRENT_EP_NBR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR");
                        W_CURRENT_EP_NBR_MINUS1.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1;
                        W_CURRENT_EP_NBR_PLUS1.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") + 1;
                        W_EP_FISCAL_NBR.Value = fleF191_EARNINGS_PERIOD.GetDecimalValue("EP_FISCAL_NBR");

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
            EndRequest("U114A_CONST_VALUES_GET_EP_NBR_1");

        }

    }







    #endregion


}
//U114A_CONST_VALUES_GET_EP_NBR_1



public class U140_E_U140_GET_AFPCON_2 : U140_E
{

    public U140_E_U140_GET_AFPCON_2(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_E_U140_GET_AFPCON_2)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("AFPCON"));


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


    #region "Standard Generated Procedures(U140_E_U140_GET_AFPCON_2)"


    #region "Automatic Item Initialization(U140_E_U140_GET_AFPCON_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_E_U140_GET_AFPCON_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:16 PM

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


    #region "FILE Management Procedures(U140_E_U140_GET_AFPCON_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:16 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_E_U140_GET_AFPCON_2)"


    public void Run()
    {

        try
        {
            Request("U140_GET_AFPCON_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    AFPCON_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    AFPCON_CODE_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");

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
            EndRequest("U140_GET_AFPCON_2");

        }

    }







    #endregion


}
//U140_GET_AFPCON_2



public class U140_E_U140_GET_NONRB_3 : U140_E
{

    public U140_E_U140_GET_NONRB_3(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_E_U140_GET_NONRB_3)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("NONRB"));


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


    #region "Standard Generated Procedures(U140_E_U140_GET_NONRB_3)"


    #region "Automatic Item Initialization(U140_E_U140_GET_NONRB_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_E_U140_GET_NONRB_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:16 PM

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


    #region "FILE Management Procedures(U140_E_U140_GET_NONRB_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:16 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_E_U140_GET_NONRB_3)"


    public void Run()
    {

        try
        {
            Request("U140_GET_NONRB_3");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    NONRB_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    NONRB_CODE_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");

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
            EndRequest("U140_GET_NONRB_3");

        }

    }







    #endregion


}
//U140_GET_NONRB_3



public class U140_E_U140_GET_NONRBP_4 : U140_E
{

    public U140_E_U140_GET_NONRBP_4(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_E_U140_GET_NONRBP_4)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("NONRBP"));


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


    #region "Standard Generated Procedures(U140_E_U140_GET_NONRBP_4)"


    #region "Automatic Item Initialization(U140_E_U140_GET_NONRBP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_E_U140_GET_NONRBP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:16 PM

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


    #region "FILE Management Procedures(U140_E_U140_GET_NONRBP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:16 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_E_U140_GET_NONRBP_4)"


    public void Run()
    {

        try
        {
            Request("U140_GET_NONRBP_4");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    NONRBP_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    NONRBP_CODE_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");

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
            EndRequest("U140_GET_NONRBP_4");

        }

    }







    #endregion


}
//U140_GET_NONRBP_4



public class U140_E_U140_UPDATE_F114_5 : U140_E
{

    public U140_E_U140_UPDATE_F114_5(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_TMP_AMT_GROSS = new CoreDecimal("X_TMP_AMT_GROSS", 10, this);
        X_TMP_AMT_NET = new CoreDecimal("X_TMP_AMT_NET", 10, this);
        fleF114_SPECIAL_PAYMENTS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F114_SPECIAL_PAYMENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU140_E_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_E_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_SELECTED_PAYROLL.GetValue += X_SELECTED_PAYROLL_GetValue;
        X_SOLO_DOC.GetValue += X_SOLO_DOC_GetValue;
        X_GFT_DOC.GetValue += X_GFT_DOC_GetValue;
        X_NON_GFT_DOC.GetValue += X_NON_GFT_DOC_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        fleF114_SPECIAL_PAYMENTS.SetItemFinals += fleF114_SPECIAL_PAYMENTS_SetItemFinals;
        X_AMT_NET.GetValue += X_AMT_NET_GetValue;
        X_AMT_GROSS.GetValue += X_AMT_GROSS_GetValue;
        fleF074_AFP_GROUP_MSTR.InitializeItems += fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF114_SPECIAL_PAYMENTS.InitializeItems += fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_E_U140_UPDATE_F114_5)"

    private SqlFileObject fleF075_AFP_DOC_MSTR;
    private SqlFileObject fleF074_AFP_GROUP_MSTR;
    private SqlFileObject fleF190_COMP_CODES;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DCharacter X_SELECTED_PAYROLL = new DCharacter("X_SELECTED_PAYROLL", 1);
    private void X_SELECTED_PAYROLL_GetValue(ref string Value)
    {

        try
        {
            Value = Prompt(1).ToString();


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
    private CoreDecimal X_TMP_AMT_GROSS;
    private CoreDecimal X_TMP_AMT_NET;
    private DCharacter X_SOLO_DOC = new DCharacter("X_SOLO_DOC", 1);
    private void X_SOLO_DOC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == "H132" & QDesign.NULL(X_SELECTED_PAYROLL.Value) == "C")
            {
                CurrentValue = "Y";
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
    private DCharacter X_GFT_DOC = new DCharacter("X_GFT_DOC", 1);
    private void X_GFT_DOC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == "H111" & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 14 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 15) & QDesign.NULL(X_SELECTED_PAYROLL.Value) == "A")
            {
                CurrentValue = "Y";
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
    private DCharacter X_NON_GFT_DOC = new DCharacter("X_NON_GFT_DOC", 1);
    private void X_NON_GFT_DOC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 4 & QDesign.NULL(X_SELECTED_PAYROLL.Value) == "A")
            {
                CurrentValue = "Y";
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
    private DCharacter X_REC_TYPE = new DCharacter("X_REC_TYPE", 1);
    private void X_REC_TYPE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF074_AFP_GROUP_MSTR.GetStringValue("BATCTRL_PAYROLL")) == "C")
            {
                CurrentValue = "A";
            }
            else
            {
                CurrentValue = "C";
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
            if (QDesign.NULL(fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT")) != 0 & QDesign.NULL(X_SELECTED_PAYROLL.Value) == QDesign.NULL(fleF074_AFP_GROUP_MSTR.GetStringValue("BATCTRL_PAYROLL")) & QDesign.NULL(fleF074_AFP_GROUP_MSTR.GetStringValue("AFP_GROUP_PROCESS_FLAG")) == "E")
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

    private SqlFileObject fleF114_SPECIAL_PAYMENTS;

    private void fleF114_SPECIAL_PAYMENTS_SetItemFinals()
    {

        try
        {
            fleF114_SPECIAL_PAYMENTS.set_SetValue("DOC_NBR", fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("COMP_CODE", "AFPCON");
            fleF114_SPECIAL_PAYMENTS.set_SetValue("EP_NBR_FROM", W_CURRENT_EP_NBR.Value);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("EP_NBR_TO", W_CURRENT_EP_NBR.Value);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("COMP_UNITS", fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE"));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("AMT_GROSS", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS") + X_TMP_AMT_GROSS.Value);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("AMT_NET", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_NET") + X_TMP_AMT_NET.Value);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_USER_ID", "U140_e  gen`d");
            fleF114_SPECIAL_PAYMENTS.set_SetValue("REC_TYPE", X_REC_TYPE.Value);


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



    private SqlFileObject fleU140_E_AUDIT;
    private DInteger X_AMT_NET = new DInteger("X_AMT_NET", 10);
    private void X_AMT_NET_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT");


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
            Value = fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT");


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


    #region "Standard Generated Procedures(U140_E_U140_UPDATE_F114_5)"


    #region "Automatic Item Initialization(U140_E_U140_UPDATE_F114_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:19 PM

    //#-----------------------------------------
    //# fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:17 PM
    //#-----------------------------------------
    private void fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF074_AFP_GROUP_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_REPORTING_MTH", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT_TOTAL", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT_TOTAL"));

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
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:17 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));

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
    //# fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:17 PM
    //#-----------------------------------------
    private void fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF114_SPECIAL_PAYMENTS.set_SetValue("DOC_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"));
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



    #endregion


    #region "Transaction Management Procedures(U140_E_U140_UPDATE_F114_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:16 PM

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
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF190_COMP_CODES.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF114_SPECIAL_PAYMENTS.Transaction = m_trnTRANS_UPDATE;
        fleU140_E_AUDIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_E_U140_UPDATE_F114_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:16 PM

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
            fleF075_AFP_DOC_MSTR.Dispose();
            fleF074_AFP_GROUP_MSTR.Dispose();
            fleF190_COMP_CODES.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF114_SPECIAL_PAYMENTS.Dispose();
            fleU140_E_AUDIT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_E_U140_UPDATE_F114_5)"


    public void Run()
    {

        try
        {
            Request("U140_UPDATE_F114_5");

            while (fleF075_AFP_DOC_MSTR.QTPForMissing())
            {
                // --> GET F075_AFP_DOC_MSTR <--

                fleF075_AFP_DOC_MSTR.GetData();
                // --> End GET F075_AFP_DOC_MSTR <--

                while (fleF074_AFP_GROUP_MSTR.QTPForMissing("1"))
                {
                    // --> GET F074_AFP_GROUP_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));

                    fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F074_AFP_GROUP_MSTR <--

                    while (fleF190_COMP_CODES.QTPForMissing("2"))
                    {
                        // --> GET F190_COMP_CODES <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("AFPCON"));

                        fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F190_COMP_CODES <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR")));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F020_DOCTOR_MSTR <--


                            if (Transaction())
                            {
                                X_TMP_AMT_GROSS.Value = X_TMP_AMT_GROSS.Value + fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT");
                                X_TMP_AMT_NET.Value = X_TMP_AMT_NET.Value + fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT");

                                if (Select_If())
                                {

                                    Sort(fleF075_AFP_DOC_MSTR.GetSortValue("DOC_NBR"), fleF075_AFP_DOC_MSTR.GetSortValue("DOC_AFP_PAYM_GROUP"));



                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleF075_AFP_DOC_MSTR, fleF074_AFP_GROUP_MSTR, fleF190_COMP_CODES, fleF020_DOCTOR_MSTR))
            {
                while (fleF114_SPECIAL_PAYMENTS.QTPForMissing())
                {
                    // --> GET F114_SPECIAL_PAYMENTS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("AFPCON"));
                    m_strWhere.Append(" And ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR")));

                    fleF114_SPECIAL_PAYMENTS.GetData(m_strWhere.ToString());
                    // --> End GET F114_SPECIAL_PAYMENTS <--




                    fleF114_SPECIAL_PAYMENTS.OutPut(OutPutType.Add_Update, fleF075_AFP_DOC_MSTR.At("DOC_NBR"), null);



                }




                SubFile(ref m_trnTRANS_UPDATE, ref fleU140_E_AUDIT, fleF075_AFP_DOC_MSTR.At("DOC_NBR"), SubFileType.Keep, X_SELECTED_PAYROLL, fleF075_AFP_DOC_MSTR, "DOC_NBR", "DOC_AFP_PAYM_GROUP", fleF020_DOCTOR_MSTR, "DOC_NAME",
                "DOC_INITS", "DOC_DEPT", fleF190_COMP_CODES, fleF114_SPECIAL_PAYMENTS, "EP_NBR_FROM", "EP_NBR_TO", "COMP_UNITS", X_TMP_AMT_GROSS, X_TMP_AMT_NET, X_REC_TYPE);



                Reset(ref X_TMP_AMT_GROSS, fleF075_AFP_DOC_MSTR.At("DOC_NBR"));
                Reset(ref X_TMP_AMT_NET, fleF075_AFP_DOC_MSTR.At("DOC_NBR"));

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
            EndRequest("U140_UPDATE_F114_5");

        }

    }




    #endregion


}
//U140_UPDATE_F114_5



public class U140_E_U140_NONRB_NONRBP_6 : U140_E
{

    public U140_E_U140_NONRB_NONRBP_6(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF075_AFP_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F075_AFP_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF074_AFP_GROUP_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F074_AFP_GROUP_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF074_AFP_GROUP_SEQUENCE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F074_AFP_GROUP_SEQUENCE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_TMP_AMT_GROSS = new CoreDecimal("X_TMP_AMT_GROSS", 10, this);
        X_TMP_AMT_NET = new CoreDecimal("X_TMP_AMT_NET", 10, this);
        fleF114_SPECIAL_PAYMENTS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F114_SPECIAL_PAYMENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU140_E_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_E_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_SELECTED_PAYROLL.GetValue += X_SELECTED_PAYROLL_GetValue;
        X_SOLO_DOC.GetValue += X_SOLO_DOC_GetValue;
        X_GFT_DOC.GetValue += X_GFT_DOC_GetValue;
        X_NON_GFT_DOC.GetValue += X_NON_GFT_DOC_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        X_NONRBP_GROUP.GetValue += X_NONRBP_GROUP_GetValue;
        X_SOLO_NONRBP_GROUP.GetValue += X_SOLO_NONRBP_GROUP_GetValue;
        X_NONRB.GetValue += X_NONRB_GetValue;
        X_NONRBP.GetValue += X_NONRBP_GetValue;
        X_COMP_CODE.GetValue += X_COMP_CODE_GetValue;
        REPORTING_SEQ.GetValue += REPORTING_SEQ_GetValue;
        COMP_CODE_GROUP.GetValue += COMP_CODE_GROUP_GetValue;
        X_AMT_NET.GetValue += X_AMT_NET_GetValue;
        X_AMT_GROSS.GetValue += X_AMT_GROSS_GetValue;
        fleF114_SPECIAL_PAYMENTS.SetItemFinals += fleF114_SPECIAL_PAYMENTS_SetItemFinals;
        fleF074_AFP_GROUP_MSTR.InitializeItems += fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF074_AFP_GROUP_SEQUENCE_MSTR.InitializeItems += fleF074_AFP_GROUP_SEQUENCE_MSTR_AutomaticItemInitialization;
        fleF114_SPECIAL_PAYMENTS.InitializeItems += fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U140_E_U140_NONRB_NONRBP_6)"

    private SqlFileObject fleF075_AFP_DOC_MSTR;
    private SqlFileObject fleF074_AFP_GROUP_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF074_AFP_GROUP_SEQUENCE_MSTR;
    private DCharacter X_SELECTED_PAYROLL = new DCharacter("X_SELECTED_PAYROLL", 1);
    private void X_SELECTED_PAYROLL_GetValue(ref string Value)
    {

        try
        {
            Value = Prompt(2).ToString();


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
    private DCharacter X_SOLO_DOC = new DCharacter("X_SOLO_DOC", 1);
    private void X_SOLO_DOC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == "H132" & QDesign.NULL(X_SELECTED_PAYROLL.Value) == "C")
            {
                CurrentValue = "Y";
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
    private DCharacter X_GFT_DOC = new DCharacter("X_GFT_DOC", 1);
    private void X_GFT_DOC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == "H111" & (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 14 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 15) & QDesign.NULL(X_SELECTED_PAYROLL.Value) == "A")
            {
                CurrentValue = "Y";
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
    private DCharacter X_NON_GFT_DOC = new DCharacter("X_NON_GFT_DOC", 1);
    private void X_NON_GFT_DOC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) == 4 & QDesign.NULL(X_SELECTED_PAYROLL.Value) == "A")
            {
                CurrentValue = "Y";
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
    private DCharacter X_REC_TYPE = new DCharacter("X_REC_TYPE", 1);
    private void X_REC_TYPE_GetValue(ref string Value)
    {

        try
        {
            Value = "D";


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
    private DCharacter X_NONRBP_GROUP = new DCharacter("X_NONRBP_GROUP", 1);
    private void X_NONRBP_GROUP_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("NONRBP_FLAG")) == "Y" & QDesign.NULL(fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("SOLO_FLAG")) == "N")
            {
                CurrentValue = "Y";
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
    private DCharacter X_SOLO_NONRBP_GROUP = new DCharacter("X_SOLO_NONRBP_GROUP", 1);
    private void X_SOLO_NONRBP_GROUP_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("NONRBP_FLAG")) == "Y" & (QDesign.NULL(fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("SOLO_FLAG")) == "Y" | QDesign.NULL(fleF074_AFP_GROUP_SEQUENCE_MSTR.GetStringValue("SOLO_FLAG")) == "N"))
            {
                CurrentValue = "Y";
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
    private DCharacter X_NONRB = new DCharacter("X_NONRB", 1);
    private void X_NONRB_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_SOLO_DOC.Value) == "Y" & QDesign.NULL(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")) == "H132")
            {
                CurrentValue = "Y";
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
    private DCharacter X_NONRBP = new DCharacter("X_NONRBP", 1);
    private void X_NONRBP_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (((QDesign.NULL(X_SOLO_DOC.Value) == "Y" & QDesign.NULL(X_SOLO_NONRBP_GROUP.Value) == "Y") | (QDesign.NULL(X_GFT_DOC.Value) == "Y" & QDesign.NULL(X_NONRBP_GROUP.Value) == "Y") | (QDesign.NULL(X_NON_GFT_DOC.Value) == "Y" & QDesign.NULL(X_NONRBP_GROUP.Value) == "Y")))
            {
                CurrentValue = "Y";
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
            if (QDesign.NULL(fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_SUBMISSION_AMT")) != 0 & (QDesign.NULL(X_NONRB.Value) == "Y" | QDesign.NULL(X_NONRBP.Value) == "Y"))
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

    private DCharacter X_COMP_CODE = new DCharacter("X_COMP_CODE", 6);
    private void X_COMP_CODE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_NONRB.Value) == "Y")
            {
                CurrentValue = "NONRB";
            }
            else if (QDesign.NULL(X_NONRBP.Value) == "Y")
            {
                CurrentValue = "NONRBP";
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
    private DDecimal REPORTING_SEQ = new DDecimal("REPORTING_SEQ", 2);
    private void REPORTING_SEQ_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_NONRB.Value) == "Y")
            {
                CurrentValue = NONRB_SEQ.Value;
            }
            else if (QDesign.NULL(X_NONRBP.Value) == "Y")
            {
                CurrentValue = NONRBP_SEQ.Value;
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
    private DCharacter COMP_CODE_GROUP = new DCharacter("COMP_CODE_GROUP", 1);
    private void COMP_CODE_GROUP_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_NONRB.Value) == "Y")
            {
                CurrentValue = QDesign.NULL(NONRB_CODE_GROUP.Value);
            }
            else if (QDesign.NULL(X_NONRBP.Value) == "Y")
            {
                CurrentValue = QDesign.NULL(NONRBP_CODE_GROUP.Value);
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
    private DInteger X_AMT_NET = new DInteger("X_AMT_NET", 10);
    private void X_AMT_NET_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_SUBMISSION_AMT");


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
            Value = fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_SUBMISSION_AMT");


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
    private CoreDecimal X_TMP_AMT_GROSS;
    private CoreDecimal X_TMP_AMT_NET;
    private SqlFileObject fleF114_SPECIAL_PAYMENTS;

    private void fleF114_SPECIAL_PAYMENTS_SetItemFinals()
    {

        try
        {
            fleF114_SPECIAL_PAYMENTS.set_SetValue("DOC_NBR", fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("COMP_CODE", X_COMP_CODE.Value);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("EP_NBR_FROM", W_CURRENT_EP_NBR.Value);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("EP_NBR_TO", W_CURRENT_EP_NBR.Value);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("COMP_UNITS", fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE"));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("AMT_GROSS", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_GROSS") + X_TMP_AMT_GROSS.Value);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("AMT_NET", fleF114_SPECIAL_PAYMENTS.GetDecimalValue("AMT_NET") + X_TMP_AMT_NET.Value);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
            fleF114_SPECIAL_PAYMENTS.set_SetValue("LAST_MOD_USER_ID", "U140_e  gen`d");
            fleF114_SPECIAL_PAYMENTS.set_SetValue("REC_TYPE", X_REC_TYPE.Value);


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



    private SqlFileObject fleU140_E_AUDIT;


    #endregion


    #region "Standard Generated Procedures(U140_E_U140_NONRB_NONRBP_6)"


    #region "Automatic Item Initialization(U140_E_U140_NONRB_NONRBP_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:22 PM

    //#-----------------------------------------
    //# fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:19 PM
    //#-----------------------------------------
    private void fleF074_AFP_GROUP_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF074_AFP_GROUP_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_REPORTING_MTH", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("AFP_REPORTING_MTH"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_MULTI_DOC_RA_PERCENTAGE", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT"));
            fleF074_AFP_GROUP_MSTR.set_SetValue("AFP_PAYMENT_AMT_TOTAL", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_PAYMENT_AMT_TOTAL"));

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
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:19 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_OHIP_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetDecimalValue("DOC_OHIP_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));

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
    //# fleF074_AFP_GROUP_SEQUENCE_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:19 PM
    //#-----------------------------------------
    private void fleF074_AFP_GROUP_SEQUENCE_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF074_AFP_GROUP_SEQUENCE_MSTR.set_SetValue("DOC_AFP_PAYM_GROUP", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP"));

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
    //# fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:19 PM
    //#-----------------------------------------
    private void fleF114_SPECIAL_PAYMENTS_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF114_SPECIAL_PAYMENTS.set_SetValue("DOC_NBR", !Fixed, fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR"));

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


    #region "Transaction Management Procedures(U140_E_U140_NONRB_NONRBP_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:16 PM

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
        fleF075_AFP_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF074_AFP_GROUP_SEQUENCE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF114_SPECIAL_PAYMENTS.Transaction = m_trnTRANS_UPDATE;
        fleU140_E_AUDIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_E_U140_NONRB_NONRBP_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:16 PM

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
            fleF075_AFP_DOC_MSTR.Dispose();
            fleF074_AFP_GROUP_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF074_AFP_GROUP_SEQUENCE_MSTR.Dispose();
            fleF114_SPECIAL_PAYMENTS.Dispose();
            fleU140_E_AUDIT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_E_U140_NONRB_NONRBP_6)"


    public void Run()
    {

        try
        {
            Request("U140_NONRB_NONRBP_6");

            while (fleF075_AFP_DOC_MSTR.QTPForMissing())
            {
                // --> GET F075_AFP_DOC_MSTR <--

                fleF075_AFP_DOC_MSTR.GetData();
                // --> End GET F075_AFP_DOC_MSTR <--

                while (fleF074_AFP_GROUP_MSTR.QTPForMissing("1"))
                {
                    // --> GET F074_AFP_GROUP_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));

                    fleF074_AFP_GROUP_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F074_AFP_GROUP_MSTR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF074_AFP_GROUP_SEQUENCE_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F074_AFP_GROUP_SEQUENCE_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF074_AFP_GROUP_SEQUENCE_MSTR.ElementOwner("DOC_AFP_PAYM_GROUP")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_AFP_PAYM_GROUP")));

                            fleF074_AFP_GROUP_SEQUENCE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F074_AFP_GROUP_SEQUENCE_MSTR <--


                            if (Transaction())
                            {

                                if (Select_If())
                                {

                                    Sort(fleF075_AFP_DOC_MSTR.GetSortValue("DOC_NBR"), X_COMP_CODE.Value);



                                }

                            }

                        }

                    }

                }

            }

            while (Sort(fleF075_AFP_DOC_MSTR, fleF074_AFP_GROUP_MSTR, fleF020_DOCTOR_MSTR, fleF074_AFP_GROUP_SEQUENCE_MSTR))
            {
                X_TMP_AMT_GROSS.Value = X_TMP_AMT_GROSS.Value + fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_SUBMISSION_AMT");
                X_TMP_AMT_NET.Value = X_TMP_AMT_NET.Value + fleF075_AFP_DOC_MSTR.GetDecimalValue("AFP_SUBMISSION_AMT");

                while (fleF114_SPECIAL_PAYMENTS.QTPForMissing())
                {
                    // --> GET F114_SPECIAL_PAYMENTS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF075_AFP_DOC_MSTR.GetStringValue("DOC_NBR")));
                    m_strWhere.Append(" And ").Append(fleF114_SPECIAL_PAYMENTS.ElementOwner("COMP_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(X_COMP_CODE.Value));

                    fleF114_SPECIAL_PAYMENTS.GetData(m_strWhere.ToString());
                    // --> End GET F114_SPECIAL_PAYMENTS <--




                    fleF114_SPECIAL_PAYMENTS.OutPut(OutPutType.Add_Update, fleF075_AFP_DOC_MSTR.At("DOC_NBR") || At(X_COMP_CODE), null);



                }




                SubFile(ref m_trnTRANS_UPDATE, ref fleU140_E_AUDIT, fleF075_AFP_DOC_MSTR.At("DOC_NBR") || At(X_COMP_CODE), SubFileType.Keep, X_SELECTED_PAYROLL, fleF075_AFP_DOC_MSTR, "DOC_NBR", "DOC_AFP_PAYM_GROUP", fleF020_DOCTOR_MSTR, "DOC_NAME",
                "DOC_INITS", "DOC_DEPT", fleF114_SPECIAL_PAYMENTS, "COMP_CODE", "EP_NBR_FROM", "EP_NBR_TO", "COMP_UNITS", X_TMP_AMT_GROSS, X_TMP_AMT_NET, X_REC_TYPE);



                Reset(ref X_TMP_AMT_GROSS, fleF075_AFP_DOC_MSTR.At("DOC_NBR") || At(X_COMP_CODE));
                Reset(ref X_TMP_AMT_NET, fleF075_AFP_DOC_MSTR.At("DOC_NBR") || At(X_COMP_CODE));

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
            EndRequest("U140_NONRB_NONRBP_6");

        }

    }




    #endregion


}
//U140_NONRB_NONRBP_6




