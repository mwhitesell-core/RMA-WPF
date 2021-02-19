
#region "Screen Comments"

// #> PROGRAM-ID.     U114A.QTS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// If the current EP`s F112-PYCDCEILING record does not already
// have a COMPUTED CEILING (earn/expense) value, then this pgm
// will calculate one.
// Using the values stored in the DOCTOR master for YTD COMPUTED CEILING
// and the doctor`s current ANNUAL CEILING, it will calculate a new
// YTD COMPUTED CEILING and ANNUAL COMPUTED CEILING.  These values
// are stored in the F112 record, in the DOCTOR Mstr and also as
// the GROSS/NET values of the CEIEAR(Earnings) and CEIEXP(expense)
// transactions created by this pgm.
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 92/JAN/01  ____   B.E.     - original
// 92/JAN/01  ____   B.E.     - correct penny round off error for CEILING
// and Expense calculations when dividing by 12
// 92/OCT/08  ____   B.E.     - calculation to limit EP CEILINGS to maximum
// of annual ceilings (required for  13th  EP)
// 92/OCT/16  ____   B.E.     - F020 updated with YTD Ceilings for Earnings/Expenses
// 92/NOV/24  ____   B.E.     - use of DOC-ADJCEA calculations
// creation of ADJCEA trans.
// 93/FEB/15  ____   B.E.     - use of F020 COMPUTED ANNUAL CEILING values
// 93/FEB/17  ____   B.E.     - CHANGED BACK FROM COMPUTED ANNUAL CEILING
// ??? should YTDEAR change to YTDCEA ??? same question in u114
// 93/APR/08  ____   B.E.     - YTDexp changed to YTDcex
// 93/APR/14  ____   B.E.     - MAY ADD UPDATE OF F119
// 93/APR/19  ____   B.E.     - UPDATE F020 WITH CEILING VALUES (MTHLY/YTD)
// 93/MAY/06  ____   B.E.     - added   SUBFILE F119
// 93/MAY/??  ____   B.E.     - removed SUBFILE F119
// 93/MAY/18         B.E.     - add back +- 1CENT, added rounding (.5)
// 93/MAY/25         B.E.     - add .5 rounding to all divisions
// 93/JUN/01         B.E.     - removed rounding (10,000 ceiling 9,999)
// 93/JUL/06         B.E.     - COMPUTED CEILING now has cents
// 93/SEP/20         B.E.     - OUTPUT `CEIEXP` ONLY FOR PAYCODE `4`
// 93/SEP/21         B.E.     - added restrictions on OUTPUT statements
// to certain Pay Codes.
// 94/NOV/18         B.E.     - changed pgm to not recalculate YTDCEA/CEX
// from start of the year. Now uses current
// YTD ?? ceilings in F020 and 1 more EP`s
// ceiling using 1/12 of current ANNUAL
// QDesign.Ceiling(
// 96/FEB/13         M.C.     - SMS 147 - calculate REQREV and TARREV
// for MTD  and YTD in F020-DOCTOR-EXTRA
// 1999/JAN/15  ----   S.B.     - Checked for Y2K.
// 1999/June/01  S.B.     - Added the use file
// def_compensation_status.def to 
// prevent hard coding of compensation-status.
// 2003/dec/16  A.A.  - alpha doctor nbr
// 2006/may/10 b.e.      - $1M payroll changes to size of calculated fields
// 2012/Feb/09 MC1 - add `on errors report` on the output statement
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
// !!!! THIS PGMS STILL HAVE PLUS/MINS 0/1 DIFFERENT BETWEEN CEILING/EXPESE
// !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U114A : BaseClassControl
{

    private U114A m_U114A;

    public U114A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 1, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 1, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_PLUS1 = new CoreDecimal("W_CURRENT_EP_NBR_PLUS1", 1, this, ResetTypes.ResetAtStartup);
        W_EP_FISCAL_NBR = new CoreDecimal("W_EP_FISCAL_NBR", 2, this, ResetTypes.ResetAtStartup);
        ADJCEA_SEQ = new CoreDecimal("ADJCEA_SEQ", 6, this, ResetTypes.ResetAtStartup);
        ADJCEA_TYPE = new CoreCharacter("ADJCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEAR_SEQ = new CoreDecimal("CEIEAR_SEQ", 6, this, ResetTypes.ResetAtStartup);
        CEIEAR_FACTOR = new CoreDecimal("CEIEAR_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        CEIEAR_TYPE = new CoreCharacter("CEIEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_SEQ = new CoreDecimal("CEIEXP_SEQ", 6, this, ResetTypes.ResetAtStartup);
        CEIEXP_TYPE = new CoreCharacter("CEIEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_FACTOR = new CoreDecimal("CEIEXP_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 6, this, ResetTypes.ResetAtStartup);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 6, this, ResetTypes.ResetAtStartup);


    }

    public U114A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 1, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 1, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_PLUS1 = new CoreDecimal("W_CURRENT_EP_NBR_PLUS1", 1, this, ResetTypes.ResetAtStartup);
        W_EP_FISCAL_NBR = new CoreDecimal("W_EP_FISCAL_NBR", 2, this, ResetTypes.ResetAtStartup);
        ADJCEA_SEQ = new CoreDecimal("ADJCEA_SEQ", 6, this, ResetTypes.ResetAtStartup);
        ADJCEA_TYPE = new CoreCharacter("ADJCEA_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEAR_SEQ = new CoreDecimal("CEIEAR_SEQ", 6, this, ResetTypes.ResetAtStartup);
        CEIEAR_FACTOR = new CoreDecimal("CEIEAR_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        CEIEAR_TYPE = new CoreCharacter("CEIEAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_SEQ = new CoreDecimal("CEIEXP_SEQ", 6, this, ResetTypes.ResetAtStartup);
        CEIEXP_TYPE = new CoreCharacter("CEIEXP_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        CEIEXP_FACTOR = new CoreDecimal("CEIEXP_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        YTDCEA_SEQ = new CoreDecimal("YTDCEA_SEQ", 6, this, ResetTypes.ResetAtStartup);
        YTDCEX_SEQ = new CoreDecimal("YTDCEX_SEQ", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U114A != null))
        {
            m_U114A.CloseTransactionObjects();
            m_U114A = null;
        }
    }

    public U114A GetU114A(int Level)
    {
        if (m_U114A == null)
        {
            m_U114A = new U114A("U114A", Level);
        }
        else
        {
            m_U114A.ResetValues();
        }
        return m_U114A;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_EP_NBR;
    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal W_CURRENT_EP_NBR_PLUS1;
    protected CoreDecimal W_EP_FISCAL_NBR;
    protected CoreDecimal ADJCEA_SEQ;
    protected CoreCharacter ADJCEA_TYPE;
    protected CoreDecimal CEIEAR_SEQ;
    protected CoreDecimal CEIEAR_FACTOR;
    protected CoreCharacter CEIEAR_TYPE;
    protected CoreDecimal CEIEXP_SEQ;
    protected CoreCharacter CEIEXP_TYPE;
    protected CoreDecimal CEIEXP_FACTOR;
    protected CoreDecimal YTDCEA_SEQ;

    protected CoreDecimal YTDCEX_SEQ;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U114A_CONST_VALUES_GET_EP_NBR_1 CONST_VALUES_GET_EP_NBR_1 = new U114A_CONST_VALUES_GET_EP_NBR_1(Name, Level);
            CONST_VALUES_GET_EP_NBR_1.Run();
            CONST_VALUES_GET_EP_NBR_1.Dispose();
            CONST_VALUES_GET_EP_NBR_1 = null;

            U114A_GET_ADJCEA_2 GET_ADJCEA_2 = new U114A_GET_ADJCEA_2(Name, Level);
            GET_ADJCEA_2.Run();
            GET_ADJCEA_2.Dispose();
            GET_ADJCEA_2 = null;

            U114A_GET_CEIEAR_3 GET_CEIEAR_3 = new U114A_GET_CEIEAR_3(Name, Level);
            GET_CEIEAR_3.Run();
            GET_CEIEAR_3.Dispose();
            GET_CEIEAR_3 = null;

            U114A_GET_CEIEXP_4 GET_CEIEXP_4 = new U114A_GET_CEIEXP_4(Name, Level);
            GET_CEIEXP_4.Run();
            GET_CEIEXP_4.Dispose();
            GET_CEIEXP_4 = null;

            U114A_GET_YTDCEA_5 GET_YTDCEA_5 = new U114A_GET_YTDCEA_5(Name, Level);
            GET_YTDCEA_5.Run();
            GET_YTDCEA_5.Dispose();
            GET_YTDCEA_5 = null;

            U114A_GET_YTDCEX_6 GET_YTDCEX_6 = new U114A_GET_YTDCEX_6(Name, Level);
            GET_YTDCEX_6.Run();
            GET_YTDCEX_6.Dispose();
            GET_YTDCEX_6 = null;

            U114A_RUN_0_CALC_CEILINGS_7 RUN_0_CALC_CEILINGS_7 = new U114A_RUN_0_CALC_CEILINGS_7(Name, Level);
            RUN_0_CALC_CEILINGS_7.Run();
            RUN_0_CALC_CEILINGS_7.Dispose();
            RUN_0_CALC_CEILINGS_7 = null;

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



public class U114A_CONST_VALUES_GET_EP_NBR_1 : U114A
{

    public U114A_CONST_VALUES_GET_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U114A_CONST_VALUES_GET_EP_NBR_1)"

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


    #region "Standard Generated Procedures(U114A_CONST_VALUES_GET_EP_NBR_1)"


    #region "Automatic Item Initialization(U114A_CONST_VALUES_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U114A_CONST_VALUES_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:11 PM

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


    #region "FILE Management Procedures(U114A_CONST_VALUES_GET_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:11 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U114A_CONST_VALUES_GET_EP_NBR_1)"


    public void Run()
    {

        try
        {
            Request("CONST_VALUES_GET_EP_NBR_1");

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
            EndRequest("CONST_VALUES_GET_EP_NBR_1");

        }

    }







    #endregion


}
//CONST_VALUES_GET_EP_NBR_1



public class U114A_GET_ADJCEA_2 : U114A
{

    public U114A_GET_ADJCEA_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U114A_GET_ADJCEA_2)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("ADJCEA"));


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


    #region "Standard Generated Procedures(U114A_GET_ADJCEA_2)"


    #region "Automatic Item Initialization(U114A_GET_ADJCEA_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U114A_GET_ADJCEA_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:11 PM

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


    #region "FILE Management Procedures(U114A_GET_ADJCEA_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:11 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U114A_GET_ADJCEA_2)"


    public void Run()
    {

        try
        {
            Request("GET_ADJCEA_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    ADJCEA_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    ADJCEA_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_ADJCEA_2");

        }

    }







    #endregion


}
//GET_ADJCEA_2



public class U114A_GET_CEIEAR_3 : U114A
{

    public U114A_GET_CEIEAR_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U114A_GET_CEIEAR_3)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("CEIEAR"));


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


    #region "Standard Generated Procedures(U114A_GET_CEIEAR_3)"


    #region "Automatic Item Initialization(U114A_GET_CEIEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U114A_GET_CEIEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:11 PM

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


    #region "FILE Management Procedures(U114A_GET_CEIEAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:11 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U114A_GET_CEIEAR_3)"


    public void Run()
    {

        try
        {
            Request("GET_CEIEAR_3");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    CEIEAR_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    CEIEAR_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_CEIEAR_3");

        }

    }







    #endregion


}
//GET_CEIEAR_3



public class U114A_GET_CEIEXP_4 : U114A
{

    public U114A_GET_CEIEXP_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U114A_GET_CEIEXP_4)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("CEIEXP"));


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


    #region "Standard Generated Procedures(U114A_GET_CEIEXP_4)"


    #region "Automatic Item Initialization(U114A_GET_CEIEXP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U114A_GET_CEIEXP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:11 PM

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


    #region "FILE Management Procedures(U114A_GET_CEIEXP_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:12 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U114A_GET_CEIEXP_4)"


    public void Run()
    {

        try
        {
            Request("GET_CEIEXP_4");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    CEIEXP_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    CEIEXP_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");

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
            EndRequest("GET_CEIEXP_4");

        }

    }







    #endregion


}
//GET_CEIEXP_4



public class U114A_GET_YTDCEA_5 : U114A
{

    public U114A_GET_YTDCEA_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U114A_GET_YTDCEA_5)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDCEA"));


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


    #region "Standard Generated Procedures(U114A_GET_YTDCEA_5)"


    #region "Automatic Item Initialization(U114A_GET_YTDCEA_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U114A_GET_YTDCEA_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:12 PM

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


    #region "FILE Management Procedures(U114A_GET_YTDCEA_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:12 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U114A_GET_YTDCEA_5)"


    public void Run()
    {

        try
        {
            Request("GET_YTDCEA_5");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDCEA_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");

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
            EndRequest("GET_YTDCEA_5");

        }

    }







    #endregion


}
//GET_YTDCEA_5



public class U114A_GET_YTDCEX_6 : U114A
{

    public U114A_GET_YTDCEX_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U114A_GET_YTDCEX_6)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDCEX"));


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


    #region "Standard Generated Procedures(U114A_GET_YTDCEX_6)"


    #region "Automatic Item Initialization(U114A_GET_YTDCEX_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U114A_GET_YTDCEX_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:12 PM

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


    #region "FILE Management Procedures(U114A_GET_YTDCEX_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:12 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U114A_GET_YTDCEX_6)"


    public void Run()
    {

        try
        {
            Request("GET_YTDCEX_6");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDCEX_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");

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
            EndRequest("GET_YTDCEX_6");

        }

    }







    #endregion


}
//GET_YTDCEX_6



public class U114A_RUN_0_CALC_CEILINGS_7 : U114A
{

    public U114A_RUN_0_CALC_CEILINGS_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEBUGU114 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU114", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDEBUGU114_2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU114_2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF110_CEIEAR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_CEIEAR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_CEIEXP = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_CEIEXP", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_ADJCEA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_ADJCEA", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        W_DOC_YRLY_CEILING.GetValue += W_DOC_YRLY_CEILING_GetValue;
        W_DOC_YRLY_CEILING_COMPUTED.GetValue += W_DOC_YRLY_CEILING_COMPUTED_GetValue;
        W_EP_CEIL_EARN.GetValue += W_EP_CEIL_EARN_GetValue;
        W_POT_ANNUAL_CALCEARN.GetValue += W_POT_ANNUAL_CALCEARN_GetValue;
        W_EP_CEIL_EARN_1.GetValue += W_EP_CEIL_EARN_1_GetValue;
        W_DOC_ADJCEA_ABS.GetValue += W_DOC_ADJCEA_ABS_GetValue;
        W_EP_CEIL_EARN_ADJ.GetValue += W_EP_CEIL_EARN_ADJ_GetValue;
        W_NEW_ADJCEA.GetValue += W_NEW_ADJCEA_GetValue;
        W_CEIL_EARN_YTD.GetValue += W_CEIL_EARN_YTD_GetValue;
        W_EP_CEIL_EARN_ACT.GetValue += W_EP_CEIL_EARN_ACT_GetValue;
        W_DOC_YRLY_EXPENSE.GetValue += W_DOC_YRLY_EXPENSE_GetValue;
        W_DOC_YRLY_EXPENSE_COMPUTED.GetValue += W_DOC_YRLY_EXPENSE_COMPUTED_GetValue;
        W_EP_CEIL_EXPN.GetValue += W_EP_CEIL_EXPN_GetValue;
        W_POT_ANNUAL_CALCEXPN.GetValue += W_POT_ANNUAL_CALCEXPN_GetValue;
        W_EP_CEIL_EXPN_1.GetValue += W_EP_CEIL_EXPN_1_GetValue;
        W_CEIL_EXPN_YTD.GetValue += W_CEIL_EXPN_YTD_GetValue;
        W_EP_CEIL_EXPN_ACT.GetValue += W_EP_CEIL_EXPN_ACT_GetValue;
        W_DOC_YRLY_REQREV.GetValue += W_DOC_YRLY_REQREV_GetValue;
        W_DOC_YRLY_REQUIRE_REVENUE.GetValue += W_DOC_YRLY_REQUIRE_REVENUE_GetValue;
        W_EP_REQREV.GetValue += W_EP_REQREV_GetValue;
        W_POT_ANNUAL_REQREV.GetValue += W_POT_ANNUAL_REQREV_GetValue;
        W_EP_REQREV_1.GetValue += W_EP_REQREV_1_GetValue;
        W_REQREV_YTD.GetValue += W_REQREV_YTD_GetValue;
        W_EP_REQREV_ACT.GetValue += W_EP_REQREV_ACT_GetValue;
        W_DOC_YRLY_TARREV.GetValue += W_DOC_YRLY_TARREV_GetValue;
        W_DOC_YRLY_TARGET_REVENUE.GetValue += W_DOC_YRLY_TARGET_REVENUE_GetValue;
        W_EP_TARREV.GetValue += W_EP_TARREV_GetValue;
        W_POT_ANNUAL_TARREV.GetValue += W_POT_ANNUAL_TARREV_GetValue;
        W_EP_TARREV_1.GetValue += W_EP_TARREV_1_GetValue;
        W_TARREV_YTD.GetValue += W_TARREV_YTD_GetValue;
        W_EP_TARREV_ACT.GetValue += W_EP_TARREV_ACT_GetValue;
        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;
        fleF110_CEIEAR.InitializeItems += fleF110_CEIEAR_AutomaticItemInitialization;
        fleF110_CEIEXP.InitializeItems += fleF110_CEIEXP_AutomaticItemInitialization;
        fleF110_ADJCEA.InitializeItems += fleF110_ADJCEA_AutomaticItemInitialization;
        COMA_F112.GetValue += COMA_F112_GetValue;
        COMX_F112.GetValue += COMX_F112_GetValue;
    }


    #region "Declarations (Variables, Files and Transactions)(U114A_RUN_0_CALC_CEILINGS_7)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF112_PYCDCEILINGS;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_DOCTOR_EXTRA;

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



    private DDecimal COMX_F112 = new DDecimal("COMX_F112", 10);
    private void COMX_F112_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED");


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

    private DDecimal COMA_F112 = new DDecimal("COMA_F112", 10);
    private void COMA_F112_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED");


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


    private DDecimal W_DOC_YRLY_CEILING = new DDecimal("W_DOC_YRLY_CEILING", 10);
    private void W_DOC_YRLY_CEILING_GetValue(ref decimal Value)
    {

        try
        {
            Value = (fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING") * 100);


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
    private DDecimal W_DOC_YRLY_CEILING_COMPUTED = new DDecimal("W_DOC_YRLY_CEILING_COMPUTED", 10);
    private void W_DOC_YRLY_CEILING_COMPUTED_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED");


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
    private DDecimal W_EP_CEIL_EARN = new DDecimal("W_EP_CEIL_EARN", 10);
    private void W_EP_CEIL_EARN_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Round(W_DOC_YRLY_CEILING.Value / 12, 0, RoundOptionTypes.Near);


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
    private DDecimal W_POT_ANNUAL_CALCEARN = new DDecimal("W_POT_ANNUAL_CALCEARN", 10);
    private void W_POT_ANNUAL_CALCEARN_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA") + (W_EP_CEIL_EARN.Value * (12 - W_EP_FISCAL_NBR.Value + 1));


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
    private DDecimal W_EP_CEIL_EARN_1 = new DDecimal("W_EP_CEIL_EARN_1", 10);
    private void W_EP_CEIL_EARN_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(W_POT_ANNUAL_CALCEARN.Value) < QDesign.NULL(W_DOC_YRLY_CEILING_COMPUTED.Value))
            {
                CurrentValue = W_EP_CEIL_EARN.Value + 1;
            }
            else if (QDesign.NULL(W_POT_ANNUAL_CALCEARN.Value) > QDesign.NULL(W_DOC_YRLY_CEILING_COMPUTED.Value))
            {
                CurrentValue = W_EP_CEIL_EARN.Value - 1;
            }
            else
            {
                CurrentValue = W_EP_CEIL_EARN.Value;
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
    private DDecimal W_DOC_ADJCEA_ABS = new DDecimal("W_DOC_ADJCEA_ABS", 10);
    private void W_DOC_ADJCEA_ABS_GetValue(ref decimal Value)
    {

        try
        {
            Value = Math.Abs(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA"));


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
    private DDecimal W_EP_CEIL_EARN_ADJ = new DDecimal("W_EP_CEIL_EARN_ADJ", 10);
    private void W_EP_CEIL_EARN_ADJ_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA")) == 0)
            {
                CurrentValue = W_EP_CEIL_EARN_1.Value;
            }
            else if ((QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA")) > 0) | (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA") <= 0 & W_DOC_ADJCEA_ABS.Value <= W_EP_CEIL_EARN_1.Value))
            {
                CurrentValue = W_EP_CEIL_EARN_1.Value + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA");
            }
            else
            {
                CurrentValue = 0;
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
    private DDecimal W_NEW_ADJCEA = new DDecimal("W_NEW_ADJCEA", 10);
    private void W_NEW_ADJCEA_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA") >= 0 | (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA") <= 0 & W_DOC_ADJCEA_ABS.Value <= W_EP_CEIL_EARN.Value))
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_ADJCEA") + W_EP_CEIL_EARN.Value;
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
    private DDecimal W_CEIL_EARN_YTD = new DDecimal("W_CEIL_EARN_YTD", 10);
    private void W_CEIL_EARN_YTD_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_EP_CEIL_EARN_ADJ.Value + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA");


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
    private DDecimal W_EP_CEIL_EARN_ACT = new DDecimal("W_EP_CEIL_EARN_ACT", 10);
    private void W_EP_CEIL_EARN_ACT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (W_CEIL_EARN_YTD.Value <= W_DOC_YRLY_CEILING_COMPUTED.Value)
            {
                CurrentValue = W_EP_CEIL_EARN_ADJ.Value;
            }
            else if (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDEAR") >= W_DOC_YRLY_CEILING_COMPUTED.Value)
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = W_DOC_YRLY_CEILING_COMPUTED.Value - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEA");
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
    private DDecimal W_DOC_YRLY_EXPENSE = new DDecimal("W_DOC_YRLY_EXPENSE", 10);
    private void W_DOC_YRLY_EXPENSE_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE") * 100;


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
    private DDecimal W_DOC_YRLY_EXPENSE_COMPUTED = new DDecimal("W_DOC_YRLY_EXPENSE_COMPUTED", 10);
    private void W_DOC_YRLY_EXPENSE_COMPUTED_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED");


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
    private DDecimal W_EP_CEIL_EXPN = new DDecimal("W_EP_CEIL_EXPN", 10);
    private void W_EP_CEIL_EXPN_GetValue(ref decimal Value)
    {

        try
        {

            Value = QDesign.Round(QDesign.Divide(W_DOC_YRLY_EXPENSE.Value, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPN_ALLOC_PERS")), 0, RoundOptionTypes.Near);


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
    private DDecimal W_POT_ANNUAL_CALCEXPN = new DDecimal("W_POT_ANNUAL_CALCEXPN", 10);
    private void W_POT_ANNUAL_CALCEXPN_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX") + (W_EP_CEIL_EXPN.Value * (12 - W_EP_FISCAL_NBR.Value + 1));


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
    private DDecimal W_EP_CEIL_EXPN_1 = new DDecimal("W_EP_CEIL_EXPN_1", 10);
    private void W_EP_CEIL_EXPN_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(W_POT_ANNUAL_CALCEXPN.Value) < QDesign.NULL(W_DOC_YRLY_EXPENSE_COMPUTED.Value))
            {
                CurrentValue = W_EP_CEIL_EXPN.Value + 1;
            }
            else if (QDesign.NULL(W_POT_ANNUAL_CALCEXPN.Value) > QDesign.NULL(W_DOC_YRLY_EXPENSE_COMPUTED.Value))
            {
                CurrentValue = W_EP_CEIL_EXPN.Value - 1;
            }
            else
            {
                CurrentValue = W_EP_CEIL_EXPN.Value;
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
    private DDecimal W_CEIL_EXPN_YTD = new DDecimal("W_CEIL_EXPN_YTD", 10);
    private void W_CEIL_EXPN_YTD_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_EP_CEIL_EXPN_1.Value + fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX");


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
    private DDecimal W_EP_CEIL_EXPN_ACT = new DDecimal("W_EP_CEIL_EXPN_ACT", 10);
    private void W_EP_CEIL_EXPN_ACT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (W_CEIL_EXPN_YTD.Value <= W_DOC_YRLY_EXPENSE_COMPUTED.Value)
            {
                CurrentValue = W_EP_CEIL_EXPN.Value;
            }
            else if (fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX") >= W_DOC_YRLY_EXPENSE_COMPUTED.Value)
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = W_DOC_YRLY_EXPENSE_COMPUTED.Value - fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDCEX");
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
    private DDecimal W_DOC_YRLY_REQREV = new DDecimal("W_DOC_YRLY_REQREV", 10);
    private void W_DOC_YRLY_REQREV_GetValue(ref decimal Value)
    {

        try
        {
            Value = (fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV") * 100);


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
    private DDecimal W_DOC_YRLY_REQUIRE_REVENUE = new DDecimal("W_DOC_YRLY_REQUIRE_REVENUE", 10);
    private void W_DOC_YRLY_REQUIRE_REVENUE_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE");


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
    private DDecimal W_EP_REQREV = new DDecimal("W_EP_REQREV", 10);
    private void W_EP_REQREV_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Round(W_DOC_YRLY_REQREV.Value / 12, 0, RoundOptionTypes.Near);


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
    private DDecimal W_POT_ANNUAL_REQREV = new DDecimal("W_POT_ANNUAL_REQREV", 10);
    private void W_POT_ANNUAL_REQREV_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ") + (W_EP_REQREV.Value * (12 - W_EP_FISCAL_NBR.Value + 1));


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
    private DDecimal W_EP_REQREV_1 = new DDecimal("W_EP_REQREV_1", 10);
    private void W_EP_REQREV_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(W_POT_ANNUAL_REQREV.Value) < QDesign.NULL(W_DOC_YRLY_REQUIRE_REVENUE.Value))
            {
                CurrentValue = W_EP_REQREV.Value + 1;
            }
            else if (QDesign.NULL(W_POT_ANNUAL_REQREV.Value) > QDesign.NULL(W_DOC_YRLY_REQUIRE_REVENUE.Value))
            {
                CurrentValue = W_EP_REQREV.Value - 1;
            }
            else
            {
                CurrentValue = W_EP_REQREV.Value;
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
    private DDecimal W_REQREV_YTD = new DDecimal("W_REQREV_YTD", 10);
    private void W_REQREV_YTD_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_EP_REQREV_1.Value + fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ");


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
    private DDecimal W_EP_REQREV_ACT = new DDecimal("W_EP_REQREV_ACT", 10);
    private void W_EP_REQREV_ACT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (W_REQREV_YTD.Value <= W_DOC_YRLY_REQUIRE_REVENUE.Value)
            {
                CurrentValue = W_EP_REQREV_1.Value;
            }
            else if (fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ") >= W_DOC_YRLY_REQUIRE_REVENUE.Value)
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = W_DOC_YRLY_REQUIRE_REVENUE.Value - fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ");
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
    private DDecimal W_DOC_YRLY_TARREV = new DDecimal("W_DOC_YRLY_TARREV", 10);
    private void W_DOC_YRLY_TARREV_GetValue(ref decimal Value)
    {

        try
        {
            Value = (fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV") * 100);


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
    private DDecimal W_DOC_YRLY_TARGET_REVENUE = new DDecimal("W_DOC_YRLY_TARGET_REVENUE", 10);
    private void W_DOC_YRLY_TARGET_REVENUE_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_TARGET_REVENUE");


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
    private DDecimal W_EP_TARREV = new DDecimal("W_EP_TARREV", 10);
    private void W_EP_TARREV_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Round(W_DOC_YRLY_TARREV.Value / 12, 0, RoundOptionTypes.Near);


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
    private DDecimal W_POT_ANNUAL_TARREV = new DDecimal("W_POT_ANNUAL_TARREV", 10);
    private void W_POT_ANNUAL_TARREV_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR") + (W_EP_TARREV.Value * (12 - W_EP_FISCAL_NBR.Value + 1));


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
    private DDecimal W_EP_TARREV_1 = new DDecimal("W_EP_TARREV_1", 10);
    private void W_EP_TARREV_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(W_POT_ANNUAL_TARREV.Value) < QDesign.NULL(W_DOC_YRLY_TARGET_REVENUE.Value))
            {
                CurrentValue = W_EP_TARREV.Value + 1;
            }
            else if (QDesign.NULL(W_POT_ANNUAL_TARREV.Value) > QDesign.NULL(W_DOC_YRLY_TARGET_REVENUE.Value))
            {
                CurrentValue = W_EP_TARREV.Value - 1;
            }
            else
            {
                CurrentValue = W_EP_TARREV.Value;
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
    private DDecimal W_TARREV_YTD = new DDecimal("W_TARREV_YTD", 10);
    private void W_TARREV_YTD_GetValue(ref decimal Value)
    {

        try
        {
            Value = W_EP_TARREV_1.Value + fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR");


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
    private DDecimal W_EP_TARREV_ACT = new DDecimal("W_EP_TARREV_ACT", 8);
    private void W_EP_TARREV_ACT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (W_TARREV_YTD.Value <= W_DOC_YRLY_TARGET_REVENUE.Value)
            {
                CurrentValue = W_EP_TARREV_1.Value;
            }
            else if (fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR") >= W_DOC_YRLY_TARGET_REVENUE.Value)
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = W_DOC_YRLY_TARGET_REVENUE.Value - fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR");
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
    private SqlFileObject fleDEBUGU114;
    private SqlFileObject fleDEBUGU114_2;
    private SqlFileObject fleF110_CEIEAR;
    private SqlFileObject fleF110_CEIEXP;
    private SqlFileObject fleF110_ADJCEA;


    #endregion


    #region "Standard Generated Procedures(U114A_RUN_0_CALC_CEILINGS_7)"


    #region "Automatic Item Initialization(U114A_RUN_0_CALC_CEILINGS_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:21 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:13 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_CEILING_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_CEILING_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YRLY_EXPENSE_COMPUTED", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_EXPENSE_COMPUTED"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_RMA_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_RMA_EXPENSE_PERCENT_MISC"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_REG", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_REG"));
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_DEPT_EXPENSE_PERCENT_MISC", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("DOC_DEPT_EXPENSE_PERCENT_MISC"));

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
    //# fleF020_DOCTOR_EXTRA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:13 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_EXTRA_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));

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
    //# fleF110_CEIEAR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:19 PM
    //#-----------------------------------------
    private void fleF110_CEIEAR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_CEIEAR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_CEIEAR.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_CEIEAR.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_CEIEAR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_CEIEAR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_CEIEAR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_CEIEAR.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));

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
    //# fleF110_CEIEXP_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:20 PM
    //#-----------------------------------------
    private void fleF110_CEIEXP_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_CEIEXP.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_CEIEXP.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_CEIEXP.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_CEIEXP.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_CEIEXP.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_CEIEXP.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_CEIEXP.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));


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
    //# fleF110_ADJCEA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:22:21 PM
    //#-----------------------------------------
    private void fleF110_ADJCEA_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_ADJCEA.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_ADJCEA.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_ADJCEA.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_ADJCEA.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_ADJCEA.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_ADJCEA.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_ADJCEA.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.


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


    #region "Transaction Management Procedures(U114A_RUN_0_CALC_CEILINGS_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:12 PM

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
        fleF112_PYCDCEILINGS.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleDEBUGU114.Transaction = m_trnTRANS_UPDATE;
        fleDEBUGU114_2.Transaction = m_trnTRANS_UPDATE;
        fleF110_CEIEAR.Transaction = m_trnTRANS_UPDATE;
        fleF110_CEIEXP.Transaction = m_trnTRANS_UPDATE;
        fleF110_ADJCEA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U114A_RUN_0_CALC_CEILINGS_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:22:12 PM

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
            fleF112_PYCDCEILINGS.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF020_DOCTOR_EXTRA.Dispose();
            fleDEBUGU114.Dispose();
            fleDEBUGU114_2.Dispose();
            fleF110_CEIEAR.Dispose();
            fleF110_CEIEXP.Dispose();
            fleF110_ADJCEA.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U114A_RUN_0_CALC_CEILINGS_7)"


    public void Run()
    {

        try
        {
            Request("RUN_0_CALC_CEILINGS_7");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                while (fleF112_PYCDCEILINGS.QTPForMissing("1"))
                {
                    // --> GET F112_PYCDCEILINGS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR")).Append(" = ");
                    m_strWhere.Append((fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR")));

                    m_strOrderBy = new StringBuilder(" ORDER BY ");
                    m_strOrderBy.Append(fleF112_PYCDCEILINGS.ElementOwner("EP_NBR"));
                    m_strOrderBy.Append(", ").Append(fleF112_PYCDCEILINGS.ElementOwner("DOC_NBR"));

                    fleF112_PYCDCEILINGS.GetData(m_strWhere.ToString(), m_strOrderBy.ToString());
                    // --> End GET F112_PYCDCEILINGS <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF020_DOCTOR_EXTRA.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_EXTRA <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                            fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F020_DOCTOR_EXTRA <--


                            if (Transaction())
                            {

                                Sort(fleF112_PYCDCEILINGS.GetSortValue("DOC_NBR"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleCONSTANTS_MSTR_REC_6, fleF112_PYCDCEILINGS, fleF020_DOCTOR_MSTR, fleF020_DOCTOR_EXTRA))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU114, SubFileType.Keep, fleF112_PYCDCEILINGS, "EP_NBR", "DOC_NBR", "DOC_PAY_CODE", "DOC_PAY_CODE", "DOC_PAY_SUB_CODE", fleF020_DOCTOR_MSTR,
                "DOC_YRLY_CEILING_COMPUTED", COMA_F112, W_DOC_YRLY_CEILING, W_DOC_YRLY_CEILING_COMPUTED, fleF020_DOCTOR_MSTR, "DOC_YRLY_EXPENSE_COMPUTED", COMX_F112, W_EP_CEIL_EARN,
                W_EP_CEIL_EARN_ADJ, fleF020_DOCTOR_MSTR, "DOC_ADJCEA", W_NEW_ADJCEA, W_CEIL_EARN_YTD, W_POT_ANNUAL_CALCEARN, W_EP_CEIL_EARN_1, W_DOC_ADJCEA_ABS, W_EP_CEIL_EARN_ACT, W_EP_FISCAL_NBR,
                W_DOC_YRLY_EXPENSE, W_DOC_YRLY_EXPENSE_COMPUTED, W_EP_CEIL_EXPN, W_CEIL_EXPN_YTD, W_EP_CEIL_EXPN_ACT, fleF112_PYCDCEILINGS, "DOC_YRLY_EXPN_ALLOC_PERS", fleF020_DOCTOR_MSTR, "DOC_YTDCEA", "DOC_YTDCEX",
                W_EP_TARREV_ACT, W_EP_REQREV_ACT);

                SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU114_2, SubFileType.Keep, fleF112_PYCDCEILINGS, "DOC_NBR", W_DOC_YRLY_REQREV, W_DOC_YRLY_REQUIRE_REVENUE, W_POT_ANNUAL_REQREV, fleF020_DOCTOR_EXTRA, "DOC_YTDREQ",
                W_EP_REQREV, W_EP_REQREV_1, W_REQREV_YTD, W_EP_REQREV_ACT);


                fleF110_CEIEAR.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                fleF110_CEIEAR.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                fleF110_CEIEAR.set_SetValue("COMP_CODE", "CEIEAR");


                fleF110_CEIEAR.set_SetValue("COMP_TYPE", QDesign.NULL(CEIEAR_TYPE.Value));


                fleF110_CEIEAR.set_SetValue("PROCESS_SEQ", CEIEAR_SEQ.Value);


                fleF110_CEIEAR.set_SetValue("FACTOR", 0);


                fleF110_CEIEAR.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_CEIEAR.set_SetValue("COMP_UNITS", 0);


                fleF110_CEIEAR.set_SetValue("AMT_GROSS", W_DOC_YRLY_CEILING.Value);


                fleF110_CEIEAR.set_SetValue("AMT_NET", W_EP_CEIL_EARN_ACT.Value);


                fleF110_CEIEAR.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                fleF110_CEIEAR.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_CEIEAR.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_CEIEAR.set_SetValue("LAST_MOD_USER_ID", "U114     gen`d");

                fleF110_CEIEAR.OutPut(OutPutType.Add, null, QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "1" | QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "3" | QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "4");



                fleF110_CEIEXP.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);


                fleF110_CEIEXP.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                fleF110_CEIEXP.set_SetValue("COMP_CODE", "CEIEXP");


                fleF110_CEIEXP.set_SetValue("COMP_TYPE", QDesign.NULL(CEIEXP_TYPE.Value));


                fleF110_CEIEXP.set_SetValue("PROCESS_SEQ", CEIEXP_SEQ.Value);


                fleF110_CEIEXP.set_SetValue("FACTOR", 0);


                fleF110_CEIEXP.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_CEIEXP.set_SetValue("COMP_UNITS", 0);


                fleF110_CEIEXP.set_SetValue("AMT_GROSS", W_DOC_YRLY_EXPENSE.Value);


                fleF110_CEIEXP.set_SetValue("AMT_NET", W_EP_CEIL_EXPN_ACT.Value);


                fleF110_CEIEXP.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                fleF110_CEIEXP.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_CEIEXP.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_CEIEXP.set_SetValue("LAST_MOD_USER_ID", "U114 gen`d");

                fleF110_CEIEXP.OutPut(OutPutType.Add, null, QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "1" | QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "3" | QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) == "4");



                fleF110_ADJCEA.set_SetValue("EP_NBR", W_CURRENT_EP_NBR_PLUS1.Value);


                fleF110_ADJCEA.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);


                fleF110_ADJCEA.set_SetValue("COMP_CODE", "ADJCEA");


                fleF110_ADJCEA.set_SetValue("COMP_TYPE", QDesign.NULL(ADJCEA_TYPE.Value));


                fleF110_ADJCEA.set_SetValue("PROCESS_SEQ", ADJCEA_SEQ.Value);


                fleF110_ADJCEA.set_SetValue("FACTOR", 0);


                fleF110_ADJCEA.set_SetValue("FACTOR_OVERRIDE", " ");


                fleF110_ADJCEA.set_SetValue("COMP_UNITS", 0);


                fleF110_ADJCEA.set_SetValue("AMT_GROSS", 0);


                fleF110_ADJCEA.set_SetValue("AMT_NET", W_NEW_ADJCEA.Value);


                fleF110_ADJCEA.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                fleF110_ADJCEA.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                fleF110_ADJCEA.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                fleF110_ADJCEA.set_SetValue("LAST_MOD_USER_ID", "U114 gen`d");

                fleF110_ADJCEA.OutPut(OutPutType.Add, null, QDesign.NULL(W_NEW_ADJCEA.Value) != 0);

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
            EndRequest("RUN_0_CALC_CEILINGS_7");

        }

    }







    #endregion


}
//RUN_0_CALC_CEILINGS_7




