
#region "Screen Comments"

// #> PROGRAM-ID.     U118.QTS
// ((C)) Dyad Technologies
// purpose: sub-process within  earnings generation  process.
// - calculates `tot`  deductions  and  advances  trans.
// - also places deduction type transactions into the f119 subfile
// for eventual upload into the f119-doctor-ytd EXCEPT `percentage
// based deductions such as TAX which are placed there in u117
// Note: - originally program also did a o`TOT`al `ADV`ances TRANS
// but advances/deficit processing now handled as just
// another deduction.
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 93/JAN/01  ____   B.E.     - original
// 93/MAY/19  ____   B.E.     - sort to sorted, added *F119
// 93/MAY/27  ____   B.E.     - added F119-DOCTOR-YTD
// 93/JUN/21  ____   B.E.     - added ADVANCES
// 93/JUN/22  ____   B.E.     - optimize (calculate TOT values and
// add to YTD values in F020)
// removed LINKAGE to F119-DOCTOR-YTD
// 93/JUN/24  ____   B.E.     - added update of F020`s YTDDED
// 98/oct/21         B.E.     - in conversion to unix values in data base
// were changed to `numeric size 8`. The
// f119 subfile contained variables that
// were defined int*8 size 4. The database
// fields were assigned to temp field to make
// them match.
// in this pgm modified to use new size defn.
// 1999/Feb/18         S.B.     - Checked for Y2K.
// 1999/may/05  B.E.  - getting data conversion errors in field amt-gross
// within f119 - changed to use x-tmp-amt instead
// of amt-net taken directly from f110
// 1999/June/01  S.B.     - Added the use file
// def_compensation_status.def to 
// prevent hard coding of compensation-status.
// 2001/apr/12  B.E. - TOTDED now written out if non-zero, not just if
// positive amount. This allows `negative` adjustments
// to increase the PAYEFT amount
// 2001/nov/08 B.E. - all `D`eduction type transactions EXCEPT `TAX` where
// placed into f119 subfile. At the time TAX was the
// only `percentage` based deduction. Changed to NOT
// put ANY percentage based deduction rather than
// specifically TAX.
// 2002/jul/23 B.E. - fixed bug on above change for percentage based
// deductions - logic on output to f119 should have
// only output `flat` based deductions which have
// are identified due to their factor being = 1.0000
// 2003/dec/24 A.A. - alpha doctor nbr
// 2006/may/10 b.e.      - $1M payroll changes to size of calculated fields
// 2010/dec/14 MC1 - comment out write record in subfile f119
// 2012/May/05 MC2 - add new temp item amt-totded-true to exclude `DEFIC`
// this value will be used to update f119 amt-ytd in u122.qts


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U118 : BaseClassControl
{

    private U118 m_U118;

    public U118(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreInteger("W_CURRENT_EP_NBR", 4, this, ResetTypes.ResetAtStartup);
        W_FIRST_EP_NBR_OF_FISCAL_YR = new CoreInteger("W_FIRST_EP_NBR_OF_FISCAL_YR", 4, this, ResetTypes.ResetAtStartup);
        TOTDED_SEQ = new CoreDecimal("TOTDED_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTDED_SEQ_RPT = new CoreDecimal("TOTDED_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTDED_TYPE = new CoreCharacter("TOTDED_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTDED_GROUP = new CoreCharacter("TOTDED_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_SEQ = new CoreDecimal("TOTADV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ_RPT = new CoreDecimal("TOTADV_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_TYPE = new CoreCharacter("TOTADV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_GROUP = new CoreCharacter("TOTADV_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);


    }

    public U118(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreInteger("W_CURRENT_EP_NBR", 4, this, ResetTypes.ResetAtStartup);
        W_FIRST_EP_NBR_OF_FISCAL_YR = new CoreInteger("W_FIRST_EP_NBR_OF_FISCAL_YR", 4, this, ResetTypes.ResetAtStartup);
        TOTDED_SEQ = new CoreDecimal("TOTDED_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTDED_SEQ_RPT = new CoreDecimal("TOTDED_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTDED_TYPE = new CoreCharacter("TOTDED_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTDED_GROUP = new CoreCharacter("TOTDED_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_SEQ = new CoreDecimal("TOTADV_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_SEQ_RPT = new CoreDecimal("TOTADV_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        TOTADV_TYPE = new CoreCharacter("TOTADV_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTADV_GROUP = new CoreCharacter("TOTADV_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);


    }

    public override void Dispose()
    {
        if ((m_U118 != null))
        {
            m_U118.CloseTransactionObjects();
            m_U118 = null;
        }
    }

    public U118 GetU118(int Level)
    {
        if (m_U118 == null)
        {
            m_U118 = new U118("U118", Level);
        }
        else
        {
            m_U118.ResetValues();
        }
        return m_U118;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreInteger W_CURRENT_EP_NBR;
    protected CoreInteger W_FIRST_EP_NBR_OF_FISCAL_YR;
    protected CoreDecimal TOTDED_SEQ;
    protected CoreDecimal TOTDED_SEQ_RPT;
    protected CoreCharacter TOTDED_TYPE;
    protected CoreCharacter TOTDED_GROUP;
    protected CoreDecimal TOTADV_SEQ;
    protected CoreDecimal TOTADV_SEQ_RPT;
    protected CoreCharacter TOTADV_TYPE;

    protected CoreCharacter TOTADV_GROUP;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U118_A_CONSTANTS_VALUES_EP_NBR_1 A_CONSTANTS_VALUES_EP_NBR_1 = new U118_A_CONSTANTS_VALUES_EP_NBR_1(Name, Level);
            A_CONSTANTS_VALUES_EP_NBR_1.Run();
            A_CONSTANTS_VALUES_EP_NBR_1.Dispose();
            A_CONSTANTS_VALUES_EP_NBR_1 = null;

            U118_A_GET_TOTDED_2 A_GET_TOTDED_2 = new U118_A_GET_TOTDED_2(Name, Level);
            A_GET_TOTDED_2.Run();
            A_GET_TOTDED_2.Dispose();
            A_GET_TOTDED_2 = null;

            U118_A_GET_TOTADV_3 A_GET_TOTADV_3 = new U118_A_GET_TOTADV_3(Name, Level);
            A_GET_TOTADV_3.Run();
            A_GET_TOTADV_3.Dispose();
            A_GET_TOTADV_3 = null;

            U118_RUN_0_CALC_TOTDED_4 RUN_0_CALC_TOTDED_4 = new U118_RUN_0_CALC_TOTDED_4(Name, Level);
            RUN_0_CALC_TOTDED_4.Run();
            RUN_0_CALC_TOTDED_4.Dispose();
            RUN_0_CALC_TOTDED_4 = null;

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



public class U118_A_CONSTANTS_VALUES_EP_NBR_1 : U118
{

    public U118_A_CONSTANTS_VALUES_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U118_A_CONSTANTS_VALUES_EP_NBR_1)"

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


    #region "Standard Generated Procedures(U118_A_CONSTANTS_VALUES_EP_NBR_1)"


    #region "Automatic Item Initialization(U118_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U118_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:57 PM

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


    #region "FILE Management Procedures(U118_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:57 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U118_A_CONSTANTS_VALUES_EP_NBR_1)"


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



public class U118_A_GET_TOTDED_2 : U118
{

    public U118_A_GET_TOTDED_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U118_A_GET_TOTDED_2)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("TOTDED"));


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


    #region "Standard Generated Procedures(U118_A_GET_TOTDED_2)"


    #region "Automatic Item Initialization(U118_A_GET_TOTDED_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U118_A_GET_TOTDED_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:58 PM

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


    #region "FILE Management Procedures(U118_A_GET_TOTDED_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:58 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U118_A_GET_TOTDED_2)"


    public void Run()
    {

        try
        {
            Request("A_GET_TOTDED_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    TOTDED_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    TOTDED_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    TOTDED_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    TOTDED_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");

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
            EndRequest("A_GET_TOTDED_2");

        }

    }







    #endregion


}
//A_GET_TOTDED_2



public class U118_A_GET_TOTADV_3 : U118
{

    public U118_A_GET_TOTADV_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U118_A_GET_TOTADV_3)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("TOTADV"));


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


    #region "Standard Generated Procedures(U118_A_GET_TOTADV_3)"


    #region "Automatic Item Initialization(U118_A_GET_TOTADV_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U118_A_GET_TOTADV_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:58 PM

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


    #region "FILE Management Procedures(U118_A_GET_TOTADV_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:58 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U118_A_GET_TOTADV_3)"


    public void Run()
    {

        try
        {
            Request("A_GET_TOTADV_3");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    TOTADV_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    TOTADV_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    TOTADV_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    TOTADV_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");

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
            EndRequest("A_GET_TOTADV_3");

        }

    }







    #endregion


}
//A_GET_TOTADV_3



public class U118_RUN_0_CALC_TOTDED_4 : U118
{

    public U118_RUN_0_CALC_TOTDED_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_COMPENSATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        AMT_TOTDED_G = new CoreInteger("AMT_TOTDED_G", 10, this);
        AMT_TOTADV_G = new CoreInteger("AMT_TOTADV_G", 10, this);
        AMT_TOTDED_N = new CoreInteger("AMT_TOTDED_N", 10, this);
        AMT_TOTADV_N = new CoreInteger("AMT_TOTADV_N", 10, this);
        fleF110_EP_TOT_DEDUCT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_EP_TOT_DEDUCT", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_TOTADV = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_TOTADV", false, false, false, 0, "m_trnTRANS_UPDATE");
        AMT_TOTDED_TRUE = new CoreInteger("AMT_TOTDED_TRUE", 10, this);
        X_COMP_CODE_TOTDED = new CoreCharacter("X_COMP_CODE_TOTDED", 6, this, Common.cEmptyString);
        fleF119_TOTDED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_TOTDED", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_COMP_CODE_TOTADV = new CoreCharacter("X_COMP_CODE_TOTADV", 6, this, Common.cEmptyString);
        fleF119_TOTADV = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_TOTADV", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        X_NOT_NEEDED.GetValue += X_NOT_NEEDED_GetValue;
        X_TMP_AMT.GetValue += X_TMP_AMT_GetValue;
        fleF020_DOCTOR_MSTR.SetItemFinals += fleF020_DOCTOR_MSTR_SetItemFinals;
        fleF190_COMP_CODES.InitializeItems += fleF190_COMP_CODES_AutomaticItemInitialization;
        fleF110_EP_TOT_DEDUCT.InitializeItems += fleF110_EP_TOT_DEDUCT_AutomaticItemInitialization;
        fleF110_TOTADV.InitializeItems += fleF110_TOTADV_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        COMP_CODE.GetValue += COMP_CODE_GetValue;
        REPORTING_SEQ.GetValue += REPORTING_SEQ_GetValue;
        COMP_CODE_GROUP.GetValue += COMP_CODE_GROUP_GetValue;
        X_AMT_NET.GetValue += X_AMT_NET_GetValue;
        X_AMT_GROSS.GetValue += X_AMT_GROSS_GetValue;

        DEBUG_NOTE = new CoreCharacter("DEBUG_NOTE", 64, this, Common.cEmptyString);

    }

    #region "Declarations (Variables, Files and Transactions)(U118_RUN_0_CALC_TOTDED_4)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF110_COMPENSATION;
    private SqlFileObject fleF190_COMP_CODES;
    private CoreCharacter DEBUG_NOTE;

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
            if ((QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "D" | QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "A"))
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

    private CoreInteger AMT_TOTDED_G;
    private CoreInteger AMT_TOTADV_G;
    private CoreInteger AMT_TOTDED_N;
    private CoreInteger AMT_TOTADV_N;
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
    private SqlFileObject fleF110_EP_TOT_DEDUCT;
    private SqlFileObject fleF110_TOTADV;
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
    private DInteger X_TMP_AMT = new DInteger("X_TMP_AMT", 10);
    private void X_TMP_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF110_COMPENSATION.GetDecimalValue("AMT_NET");


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
    private CoreInteger AMT_TOTDED_TRUE;
    private CoreCharacter X_COMP_CODE_TOTDED;
    private SqlFileObject fleF119_TOTDED;
    private CoreCharacter X_COMP_CODE_TOTADV;
    private SqlFileObject fleF119_TOTADV;
    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleF020_DOCTOR_MSTR_SetItemFinals()
    {

        try
        {
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_YTDDED", fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_YTDDED") + AMT_TOTDED_TRUE.Value);


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

    private DCharacter COMP_CODE = new DCharacter("COMP_CODE", 6);
    private void COMP_CODE_GetValue(ref string Value)
    {
        try
        {
            Value = X_COMP_CODE_TOTDED.Value;
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
            Value = TOTDED_SEQ_RPT.Value;
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
            Value = X_COMP_CODE_TOTDED.Value;
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
            Value = AMT_TOTDED_TRUE.Value;
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
            Value = AMT_TOTDED_N.Value;
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


    #region "Standard Generated Procedures(U118_RUN_0_CALC_TOTDED_4)"


    #region "Automatic Item Initialization(U118_RUN_0_CALC_TOTDED_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:14:05 PM

    //#-----------------------------------------
    //# fleF190_COMP_CODES_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:58 PM
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
    //# fleF110_EP_TOT_DEDUCT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:58 PM
    //#-----------------------------------------
    private void fleF110_EP_TOT_DEDUCT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_EP_TOT_DEDUCT.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_EP_TOT_DEDUCT.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# fleF110_TOTADV_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:58 PM
    //#-----------------------------------------
    private void fleF110_TOTADV_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_TOTADV.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));
            fleF110_TOTADV.set_SetValue("EP_NBR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR"));
            fleF110_TOTADV.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_COMPENSATION.GetDecimalValue("PROCESS_SEQ"));
            fleF110_TOTADV.set_SetValue("COMP_CODE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_CODE"));
            fleF110_TOTADV.set_SetValue("COMP_TYPE", !Fixed, fleF110_COMPENSATION.GetStringValue("COMP_TYPE"));
            fleF110_TOTADV.set_SetValue("FACTOR", !Fixed, fleF110_COMPENSATION.GetDecimalValue("FACTOR"));
            fleF110_TOTADV.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_COMPENSATION.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_TOTADV.set_SetValue("COMP_UNITS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("COMP_UNITS"));
            fleF110_TOTADV.set_SetValue("AMT_GROSS", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS"));
            fleF110_TOTADV.set_SetValue("AMT_NET", !Fixed, fleF110_COMPENSATION.GetDecimalValue("AMT_NET"));
            fleF110_TOTADV.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_COMPENSATION.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_TOTADV.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_COMPENSATION.GetStringValue("COMPENSATION_STATUS"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_DATE", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_TIME", !Fixed, fleF110_COMPENSATION.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_TOTADV.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF110_COMPENSATION.GetStringValue("LAST_MOD_USER_ID"));
            fleF110_TOTADV.set_SetValue("FILLER", !Fixed, fleF110_COMPENSATION.GetStringValue("FILLER"));

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
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:14:05 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_NBR", !Fixed, fleF110_COMPENSATION.GetStringValue("DOC_NBR"));

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


    #region "Transaction Management Procedures(U118_RUN_0_CALC_TOTDED_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:58 PM

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
        fleF110_EP_TOT_DEDUCT.Transaction = m_trnTRANS_UPDATE;
        fleF110_TOTADV.Transaction = m_trnTRANS_UPDATE;
        fleF119_TOTDED.Transaction = m_trnTRANS_UPDATE;
        fleF119_TOTADV.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U118_RUN_0_CALC_TOTDED_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:58 PM

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
            fleF110_EP_TOT_DEDUCT.Dispose();
            fleF110_TOTADV.Dispose();
            fleF119_TOTDED.Dispose();
            fleF119_TOTADV.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U118_RUN_0_CALC_TOTDED_4)"


    public void Run()
    {

        try
        {
            Request("RUN_0_CALC_TOTDED_4");

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

                 

                    fleF110_COMPENSATION.GetData(m_strWhere.ToString());
                    // --> End GET F110_COMPENSATION <--

                    while (fleF190_COMP_CODES.QTPForMissing("2"))
                    {
                        // --> GET F190_COMP_CODES <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("COMP_CODE")));

                        fleF190_COMP_CODES.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F190_COMP_CODES <--


                        if (Transaction())
                        {

                             if (Select_If())
                            {

                                Sort(fleF110_COMPENSATION.GetSortValue("DOC_NBR"), fleF110_COMPENSATION.GetSortValue("EP_NBR"), fleF110_COMPENSATION.GetSortValue("COMP_CODE"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleCONSTANTS_MSTR_REC_6, fleF110_COMPENSATION, fleF190_COMP_CODES))
            {
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "D")
                {
                    AMT_TOTDED_G.Value = AMT_TOTDED_G.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                }
                else
                {
                    AMT_TOTDED_G.Value = AMT_TOTDED_G.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "A")
                {
                    AMT_TOTADV_G.Value = AMT_TOTADV_G.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_GROSS");
                }
                else
                {
                    AMT_TOTADV_G.Value = AMT_TOTADV_G.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "D")
                {
                    AMT_TOTDED_N.Value = AMT_TOTDED_N.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    AMT_TOTDED_N.Value = AMT_TOTDED_N.Value;
                }
                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "A")
                {
                    AMT_TOTADV_N.Value = AMT_TOTADV_N.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");
                }
                else
                {
                    AMT_TOTADV_N.Value = AMT_TOTADV_N.Value;
                }


                fleF110_EP_TOT_DEDUCT.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);
                fleF110_EP_TOT_DEDUCT.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);
                fleF110_EP_TOT_DEDUCT.set_SetValue("COMP_CODE", "TOTDED");
                fleF110_EP_TOT_DEDUCT.set_SetValue("COMP_TYPE", QDesign.NULL(TOTDED_TYPE.Value));
                fleF110_EP_TOT_DEDUCT.set_SetValue("PROCESS_SEQ", TOTDED_SEQ.Value);
                fleF110_EP_TOT_DEDUCT.set_SetValue("FACTOR", 0);
                fleF110_EP_TOT_DEDUCT.set_SetValue("FACTOR_OVERRIDE", " ");
                fleF110_EP_TOT_DEDUCT.set_SetValue("COMP_UNITS", 0);
                fleF110_EP_TOT_DEDUCT.set_SetValue("AMT_GROSS", AMT_TOTDED_G.Value);
                fleF110_EP_TOT_DEDUCT.set_SetValue("AMT_NET", AMT_TOTDED_N.Value);
                fleF110_EP_TOT_DEDUCT.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);
                fleF110_EP_TOT_DEDUCT.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleF110_EP_TOT_DEDUCT.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleF110_EP_TOT_DEDUCT.set_SetValue("LAST_MOD_USER_ID", "U118 gen`d");
                fleF110_EP_TOT_DEDUCT.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(AMT_TOTDED_N.Value) != 0);


                fleF110_TOTADV.set_SetValue("EP_NBR", W_CURRENT_EP_NBR.Value);
                fleF110_TOTADV.set_SetValue("EP_NBR_ENTRY", W_CURRENT_EP_NBR.Value);
                fleF110_TOTADV.set_SetValue("COMP_CODE", "TOTADV");
                fleF110_TOTADV.set_SetValue("COMP_TYPE", QDesign.NULL(TOTADV_TYPE.Value));
                fleF110_TOTADV.set_SetValue("PROCESS_SEQ", TOTADV_SEQ.Value);
                fleF110_TOTADV.set_SetValue("FACTOR", 0);
                fleF110_TOTADV.set_SetValue("FACTOR_OVERRIDE", " ");
                fleF110_TOTADV.set_SetValue("COMP_UNITS", 0);
                fleF110_TOTADV.set_SetValue("AMT_GROSS", AMT_TOTADV_G.Value);
                fleF110_TOTADV.set_SetValue("AMT_NET", AMT_TOTADV_N.Value);
                fleF110_TOTADV.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);
                fleF110_TOTADV.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));
                fleF110_TOTADV.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);
                fleF110_TOTADV.set_SetValue("LAST_MOD_USER_ID", "U118 gen`d");
                fleF110_TOTADV.OutPut(OutPutType.Add, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(AMT_TOTADV_N.Value) > 0);

                if (QDesign.NULL(fleF190_COMP_CODES.GetStringValue("COMP_TYPE")) == "D" & QDesign.NULL(fleF110_COMPENSATION.GetStringValue("COMP_CODE")) != "DEFIC")
                {
                    AMT_TOTDED_TRUE.Value = AMT_TOTDED_TRUE.Value + fleF110_COMPENSATION.GetDecimalValue("AMT_NET");

                }

                X_COMP_CODE_TOTDED.Value = "TOTDED";

                // GW. This subfile is wrong!
                //SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TOTDED, fleF110_COMPENSATION.At("DOC_NBR"), SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION,
                //    "DOC_NBR", COMP_CODE, REPORTING_SEQ, COMP_CODE_GROUP, X_REC_TYPE, X_AMT_NET, X_AMT_GROSS);

                DEBUG_NOTE.Value = "Generated By: u118 TOTDED";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TOTDED, fleF110_COMPENSATION.At("DOC_NBR"), SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION,
                    "DOC_NBR", X_COMP_CODE_TOTDED, TOTDED_SEQ_RPT, TOTDED_GROUP, X_REC_TYPE, AMT_TOTDED_TRUE, AMT_TOTDED_N, DEBUG_NOTE);

                X_COMP_CODE_TOTADV.Value = "TOTADV";

                DEBUG_NOTE.Value = "Generated By: u118 - TOTADV";
                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_TOTADV, fleF110_COMPENSATION.At("DOC_NBR"), QDesign.NULL(AMT_TOTADV_N.Value) > 0, SubFileType.Keep, SubFileMode.Append, fleF110_COMPENSATION, 
                    "DOC_NBR", X_COMP_CODE_TOTADV, TOTADV_SEQ_RPT, TOTADV_GROUP, X_REC_TYPE, X_NOT_NEEDED, AMT_TOTADV_N, DEBUG_NOTE);

                while (fleF020_DOCTOR_MSTR.QTPForMissing())
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF110_COMPENSATION.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update);
                }

                Reset(ref AMT_TOTDED_G, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref AMT_TOTADV_G, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref AMT_TOTDED_N, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref AMT_TOTADV_N, fleF110_COMPENSATION.At("DOC_NBR"));
                Reset(ref AMT_TOTDED_TRUE, fleF110_COMPENSATION.At("DOC_NBR"));

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
            EndRequest("RUN_0_CALC_TOTDED_4");

        }

    }







    #endregion


}
//RUN_0_CALC_TOTDED_4




