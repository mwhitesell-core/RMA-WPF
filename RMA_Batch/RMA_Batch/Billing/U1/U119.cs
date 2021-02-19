
#region "Screen Comments"

// #> PROGRAM-ID.     u119.qts   ;      / u119_icu.qts
// ((C)) Dyad Technologies
// PURPOSE: sub-process within  earnings generation  process.
// calculate `PAYEFT/TRANSF` transactions for all pay codes(except 7)
// taking into consideration any deficits outstanding. If the
// total deductions exceed the Potential Pay then the PAYEFT
// is zeroed and appropriate ADVOUT/DEFIC transactions created
// to process the deficit
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 93/JAN/01  ____   B.E.     - original
// 93/MAY/18  ____   B.E.     - added *F119
// 93/MAY/21  ____   B.E.     - Optimize
// 93/JUN/20  ____   B.E.     - Don`t allow negative EFT NET amount
// 93/JUN/21  ____   B.E.     - allow Advances (TOTADV) to affect PAYEFT, removed SELECT
// 93/JUN/22  ____   B.E.     - added U119_PAYEFT
// 93/JUL/06  ____   B.E.     - Output  Outstanding Advances  (ADVOUT)
// only if non-zero value
// 94/NOV/19         B.E.     - removed TOTADV from this pgm, now affect PAYPOT
// in U116.
// ??????? EP PLUS 1 AND MINUS 1 MUST BE READ NEXT/BACKWARDS, NOT SUBTRACTION
// 1999/Feb/18         S.B.     - Checked for Y2K.
// 1999/June/01  S.B.     - Added the use file
// def_compensation_status.def to 
// prevent hard coding of compensation-status.
// 2001/feb/20         B.E. - added conditional compile. If running in ICU
// payroll then select only the ICU paid doctors
// determined with select on dept # from use file
// 2001/feb/20         B.E. - added another request for `rma` ICU doctors
// so that their Potential payment amount is
// updated into f020 so that it can be printed
// on their r124b statements as  tranfer  amt.
// 2001/may/19 B.E. - changed advout and defic processing logic 
// 2001/may/22 B.E. - added calculation of TRANSF transaction instead of
// PAYEFT for ICU doctors
// - conditional compile genenerates either u119(regular pay)
// of u119_icu (ICU payroll)
// 2002/Nov/22 M.C. - make w-comp-code-transfer-or-eft alias comp-code when creating
// subfile f119 so that no compile error in u122 because the pgm is
// referencing comp-code instead 
// 2003/dec/16 A.A. - alpha doctor nbr
// 2005/mar/22 b.e. - alias x-amt-gross and x-amt-net so that u122 compiles
// 2006/may/10 b.e.      - $1M payroll changes to size of calculated fields
// 2014/apr/15 be1  - don`t run this program if doctors paycode is 7 as PAYEFT isn`t needed


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U119 : BaseClassControl
{

    private U119 m_U119;

    public U119(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_PLUS1 = new CoreDecimal("W_CURRENT_EP_NBR_PLUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYEFT_SEQ = new CoreDecimal("PAYEFT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYEFT_TYPE = new CoreCharacter("PAYEFT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYEFT_GROUP = new CoreCharacter("PAYEFT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYEFT_FACTOR = new CoreDecimal("PAYEFT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        TOTDED_SEQ = new CoreDecimal("TOTDED_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTDED_TYPE = new CoreCharacter("TOTDED_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTDED_GROUP = new CoreCharacter("TOTDED_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTDED_FACTOR = new CoreDecimal("TOTDED_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_SEQ = new CoreDecimal("ADVOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_TYPE = new CoreCharacter("ADVOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_GROUP = new CoreCharacter("ADVOUT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_FACTOR = new CoreDecimal("ADVOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEFIC_SEQ = new CoreDecimal("DEFIC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEFIC_TYPE = new CoreCharacter("DEFIC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEFIC_GROUP = new CoreCharacter("DEFIC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEFIC_FACTOR = new CoreDecimal("DEFIC_FACTOR", 6, this, ResetTypes.ResetAtStartup);


    }

    public U119(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_MINUS1 = new CoreDecimal("W_CURRENT_EP_NBR_MINUS1", 6, this, ResetTypes.ResetAtStartup);
        W_CURRENT_EP_NBR_PLUS1 = new CoreDecimal("W_CURRENT_EP_NBR_PLUS1", 6, this, ResetTypes.ResetAtStartup);
        PAYEFT_SEQ = new CoreDecimal("PAYEFT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYEFT_TYPE = new CoreCharacter("PAYEFT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYEFT_GROUP = new CoreCharacter("PAYEFT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYEFT_FACTOR = new CoreDecimal("PAYEFT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        TOTDED_SEQ = new CoreDecimal("TOTDED_SEQ", 2, this, ResetTypes.ResetAtStartup);
        TOTDED_TYPE = new CoreCharacter("TOTDED_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTDED_GROUP = new CoreCharacter("TOTDED_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        TOTDED_FACTOR = new CoreDecimal("TOTDED_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        PAYPOT_SEQ = new CoreDecimal("PAYPOT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        PAYPOT_TYPE = new CoreCharacter("PAYPOT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        PAYPOT_GROUP = new CoreCharacter("PAYPOT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_SEQ = new CoreDecimal("ADVOUT_SEQ", 2, this, ResetTypes.ResetAtStartup);
        ADVOUT_TYPE = new CoreCharacter("ADVOUT_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_GROUP = new CoreCharacter("ADVOUT_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        ADVOUT_FACTOR = new CoreDecimal("ADVOUT_FACTOR", 6, this, ResetTypes.ResetAtStartup);
        DEFIC_SEQ = new CoreDecimal("DEFIC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        DEFIC_TYPE = new CoreCharacter("DEFIC_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEFIC_GROUP = new CoreCharacter("DEFIC_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        DEFIC_FACTOR = new CoreDecimal("DEFIC_FACTOR", 6, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U119 != null))
        {
            m_U119.CloseTransactionObjects();
            m_U119 = null;
        }
    }

    public U119 GetU119(int Level)
    {
        if (m_U119 == null)
        {
            m_U119 = new U119("U119", Level);
        }
        else
        {
            m_U119.ResetValues();
        }
        return m_U119;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_EP_NBR;
    protected CoreDecimal W_CURRENT_EP_NBR_MINUS1;
    protected CoreDecimal W_CURRENT_EP_NBR_PLUS1;
    protected CoreDecimal PAYEFT_SEQ;
    protected CoreCharacter PAYEFT_TYPE;
    protected CoreCharacter PAYEFT_GROUP;
    protected CoreDecimal PAYEFT_FACTOR;
    protected CoreDecimal TOTDED_SEQ;
    protected CoreCharacter TOTDED_TYPE;
    protected CoreCharacter TOTDED_GROUP;
    protected CoreDecimal TOTDED_FACTOR;
    protected CoreDecimal PAYPOT_SEQ;
    protected CoreCharacter PAYPOT_TYPE;
    protected CoreCharacter PAYPOT_GROUP;
    protected CoreDecimal ADVOUT_SEQ;
    protected CoreCharacter ADVOUT_TYPE;
    protected CoreCharacter ADVOUT_GROUP;
    protected CoreDecimal ADVOUT_FACTOR;
    protected CoreDecimal DEFIC_SEQ;
    protected CoreCharacter DEFIC_TYPE;
    protected CoreCharacter DEFIC_GROUP;

    protected CoreDecimal DEFIC_FACTOR;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U119_U119_A_1 U119_A_1 = new U119_U119_A_1(Name, Level);
            U119_A_1.Run();
            U119_A_1.Dispose();
            U119_A_1 = null;

            U119_U119_A_GET_PAYEFT_2 U119_A_GET_PAYEFT_2 = new U119_U119_A_GET_PAYEFT_2(Name, Level);
            U119_A_GET_PAYEFT_2.Run();
            U119_A_GET_PAYEFT_2.Dispose();
            U119_A_GET_PAYEFT_2 = null;

            U119_U119_A_GET_TOTDED_3 U119_A_GET_TOTDED_3 = new U119_U119_A_GET_TOTDED_3(Name, Level);
            U119_A_GET_TOTDED_3.Run();
            U119_A_GET_TOTDED_3.Dispose();
            U119_A_GET_TOTDED_3 = null;

            U119_U119_A_GET_PAYPOT_4 U119_A_GET_PAYPOT_4 = new U119_U119_A_GET_PAYPOT_4(Name, Level);
            U119_A_GET_PAYPOT_4.Run();
            U119_A_GET_PAYPOT_4.Dispose();
            U119_A_GET_PAYPOT_4 = null;

            U119_U119_A_GET_ADVOUT_5 U119_A_GET_ADVOUT_5 = new U119_U119_A_GET_ADVOUT_5(Name, Level);
            U119_A_GET_ADVOUT_5.Run();
            U119_A_GET_ADVOUT_5.Dispose();
            U119_A_GET_ADVOUT_5 = null;

            U119_U119_A_GET_DEFIC_6 U119_A_GET_DEFIC_6 = new U119_U119_A_GET_DEFIC_6(Name, Level);
            U119_A_GET_DEFIC_6.Run();
            U119_A_GET_DEFIC_6.Dispose();
            U119_A_GET_DEFIC_6 = null;

            U119_U119_B_7 U119_B_7 = new U119_U119_B_7(Name, Level);
            U119_B_7.Run();
            U119_B_7.Dispose();
            U119_B_7 = null;

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



public class U119_U119_A_1 : U119
{

    public U119_U119_A_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U119_U119_A_1)"

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


    #region "Standard Generated Procedures(U119_U119_A_1)"


    #region "Automatic Item Initialization(U119_U119_A_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U119_U119_A_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:22 PM

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


    #region "FILE Management Procedures(U119_U119_A_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:22 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U119_U119_A_1)"


    public void Run()
    {

        try
        {
            Request("U119_A_1");

            while (fleCONSTANTS_MSTR_REC_6.QTPForMissing())
            {
                // --> GET CONSTANTS_MSTR_REC_6 <--

                fleCONSTANTS_MSTR_REC_6.GetData();
                // --> End GET CONSTANTS_MSTR_REC_6 <--

                if (Transaction())
                {
                    W_CURRENT_EP_NBR.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR");
                    W_CURRENT_EP_NBR_MINUS1.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") - 1;
                    W_CURRENT_EP_NBR_PLUS1.Value = fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR") + 1;

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
            EndRequest("U119_A_1");

        }

    }







    #endregion


}
//U119_A_1



public class U119_U119_A_GET_PAYEFT_2 : U119
{

    public U119_U119_A_GET_PAYEFT_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U119_U119_A_GET_PAYEFT_2)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("PAYEFT"));


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


    #region "Standard Generated Procedures(U119_U119_A_GET_PAYEFT_2)"


    #region "Automatic Item Initialization(U119_U119_A_GET_PAYEFT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U119_U119_A_GET_PAYEFT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:22 PM

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


    #region "FILE Management Procedures(U119_U119_A_GET_PAYEFT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:23 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U119_U119_A_GET_PAYEFT_2)"


    public void Run()
    {

        try
        {
            Request("U119_A_GET_PAYEFT_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    PAYEFT_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    PAYEFT_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    PAYEFT_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    PAYEFT_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("U119_A_GET_PAYEFT_2");

        }

    }







    #endregion


}
//U119_A_GET_PAYEFT_2



public class U119_U119_A_GET_TOTDED_3 : U119
{

    public U119_U119_A_GET_TOTDED_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U119_U119_A_GET_TOTDED_3)"

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


    #region "Standard Generated Procedures(U119_U119_A_GET_TOTDED_3)"


    #region "Automatic Item Initialization(U119_U119_A_GET_TOTDED_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U119_U119_A_GET_TOTDED_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:23 PM

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


    #region "FILE Management Procedures(U119_U119_A_GET_TOTDED_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:23 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U119_U119_A_GET_TOTDED_3)"


    public void Run()
    {

        try
        {
            Request("U119_A_GET_TOTDED_3");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    TOTDED_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    TOTDED_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    TOTDED_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("U119_A_GET_TOTDED_3");

        }

    }







    #endregion


}
//U119_A_GET_TOTDED_3



public class U119_U119_A_GET_PAYPOT_4 : U119
{

    public U119_U119_A_GET_PAYPOT_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U119_U119_A_GET_PAYPOT_4)"

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


    #region "Standard Generated Procedures(U119_U119_A_GET_PAYPOT_4)"


    #region "Automatic Item Initialization(U119_U119_A_GET_PAYPOT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U119_U119_A_GET_PAYPOT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:23 PM

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


    #region "FILE Management Procedures(U119_U119_A_GET_PAYPOT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:23 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U119_U119_A_GET_PAYPOT_4)"


    public void Run()
    {

        try
        {
            Request("U119_A_GET_PAYPOT_4");

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
            EndRequest("U119_A_GET_PAYPOT_4");

        }

    }







    #endregion


}
//U119_A_GET_PAYPOT_4



public class U119_U119_A_GET_ADVOUT_5 : U119
{

    public U119_U119_A_GET_ADVOUT_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U119_U119_A_GET_ADVOUT_5)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("ADVOUT"));


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


    #region "Standard Generated Procedures(U119_U119_A_GET_ADVOUT_5)"


    #region "Automatic Item Initialization(U119_U119_A_GET_ADVOUT_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U119_U119_A_GET_ADVOUT_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:23 PM

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


    #region "FILE Management Procedures(U119_U119_A_GET_ADVOUT_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:23 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U119_U119_A_GET_ADVOUT_5)"


    public void Run()
    {

        try
        {
            Request("U119_A_GET_ADVOUT_5");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    ADVOUT_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    ADVOUT_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    ADVOUT_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    ADVOUT_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("U119_A_GET_ADVOUT_5");

        }

    }







    #endregion


}
//U119_A_GET_ADVOUT_5



public class U119_U119_A_GET_DEFIC_6 : U119
{

    public U119_U119_A_GET_DEFIC_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U119_U119_A_GET_DEFIC_6)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("DEFIC"));


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


    #region "Standard Generated Procedures(U119_U119_A_GET_DEFIC_6)"


    #region "Automatic Item Initialization(U119_U119_A_GET_DEFIC_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U119_U119_A_GET_DEFIC_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:23 PM

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


    #region "FILE Management Procedures(U119_U119_A_GET_DEFIC_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:23 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U119_U119_A_GET_DEFIC_6)"


    public void Run()
    {

        try
        {
            Request("U119_A_GET_DEFIC_6");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    DEFIC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    DEFIC_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    DEFIC_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    DEFIC_FACTOR.Value = fleF190_COMP_CODES.GetDecimalValue("FACTOR");

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
            EndRequest("U119_A_GET_DEFIC_6");

        }

    }







    #endregion


}
//U119_A_GET_DEFIC_6



public class U119_U119_B_7 : U119
{

    public U119_U119_B_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_PAYPOT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_PAYPOT", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_TOTDED = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_TOTDED", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_PAYEFT = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_PAYEFT", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDEBUGU119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DEBUGU119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        W_COMP_CODE_TRANSFER_OR_EFT = new CoreCharacter("W_COMP_CODE_TRANSFER_OR_EFT", 6, this, Common.cEmptyString);
        fleF119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        W_COMP_CODE_ADVOUT = new CoreCharacter("W_COMP_CODE_ADVOUT", 6, this, Common.cEmptyString);
        fleF119_ADVOUT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_ADVOUT", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU119_PAYEFT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U119_PAYEFT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        W_EP_NBR = new CoreDecimal("W_EP_NBR", 6, this);
        W_EP_NBR_ENTRY = new CoreDecimal("W_EP_NBR_ENTRY", 6, this);
        W_TYPE = new CoreCharacter("W_TYPE", 1, this, Common.cEmptyString);
        W_SEQ = new CoreDecimal("W_SEQ", 2, this);
        W_FACTOR = new CoreDecimal("W_FACTOR", 6, this);
        W_FACTOR_OVERRIDE = new CoreCharacter("W_FACTOR_OVERRIDE", 1, this, Common.cEmptyString);
        W_COMP_UNITS = new CoreDecimal("W_COMP_UNITS", 6, this);
        W_AMT_GROSS = new CoreDecimal("W_AMT_GROSS", 10, this);
        W_AMT_NET = new CoreDecimal("W_AMT_NET", 10, this);
        fleU119_F110 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U119_F110", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU110_F110_ADVOUT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U119_F110", "U110_F110_ADVOUT", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        W_COMP_CODE_DEFIC = new CoreCharacter("W_COMP_CODE_DEFIC", 6, this, Common.cEmptyString);
        fleU110_F110_DEFIC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U119_F110", "U110_F110_DEFIC", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF020_DOCTOR_MSTR.SetItemFinals += fleF020_DOCTOR_MSTR_SetItemFinals;
        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        ICU_DEPT_1.GetValue += ICU_DEPT_1_GetValue;
        W_PAYEFT_AMT_1.GetValue += W_PAYEFT_AMT_1_GetValue;
        W_PAYEFT_AMT_N.GetValue += W_PAYEFT_AMT_N_GetValue;
        W_AMT_DEFICIT.GetValue += W_AMT_DEFICIT_GetValue;
        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        W_NOT_NEEDED.GetValue += W_NOT_NEEDED_GetValue;
        W_REC_TYPE.GetValue += W_REC_TYPE_GetValue;
        fleF110_PAYPOT.InitializeItems += fleF110_PAYPOT_AutomaticItemInitialization;
        fleF110_TOTDED.InitializeItems += fleF110_TOTDED_AutomaticItemInitialization;
        fleF110_PAYEFT.InitializeItems += fleF110_PAYEFT_AutomaticItemInitialization;
        fleF020_DOCTOR_MSTR.InitializeItems += fleF020_DOCTOR_MSTR_AutomaticItemInitialization;
        COMP_CODE.GetValue += COMP_CODE_GetValue;
        REPORTING_SEQ.GetValue += REPORTING_SEQ_GetValue;
        COMP_CODE_GROUP.GetValue += COMP_CODE_GROUP_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        X_AMT_NET.GetValue += X_AMT_NET_GetValue;
        X_AMT_GROSS.GetValue += X_AMT_GROSS_GetValue;

        DEBUG_NOTE = new CoreCharacter("DEBUG_NOTE", 64, this, Common.cEmptyString);

    }

    #region "Declarations (Variables, Files and Transactions)(U119_U119_B_7)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF112_PYCDCEILINGS;
    private SqlFileObject fleF110_PAYPOT;
    private SqlFileObject fleF110_TOTDED;
    private SqlFileObject fleF110_PAYEFT;
    private SqlFileObject fleF020_DOCTOR_MSTR;

    private CoreCharacter DEBUG_NOTE;

    private void fleF020_DOCTOR_MSTR_SetItemFinals()
    {

        try
        {
            fleF020_DOCTOR_MSTR.set_SetValue("DOC_PAYEFT", W_PAYEFT_AMT_N.Value);


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
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetStringValue("DOC_PAY_CODE")) != "7")
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

    private DDecimal ICU_DEPT_1 = new DDecimal("ICU_DEPT_1", 2);
    private void ICU_DEPT_1_GetValue(ref decimal Value)
    {

        try
        {
            Value = 15;


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
    private DInteger W_PAYEFT_AMT_1 = new DInteger("W_PAYEFT_AMT_1", 10);
    private void W_PAYEFT_AMT_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (!fleF110_PAYEFT.Exists())
            {
                CurrentValue = QDesign.Round(((fleF110_PAYPOT.GetDecimalValue("AMT_NET") - fleF110_TOTDED.GetDecimalValue("AMT_NET")) * PAYEFT_FACTOR.Value) / 10000, 0, RoundOptionTypes.Near);
            }
            else
            {
                CurrentValue = QDesign.Round(((fleF110_PAYPOT.GetDecimalValue("AMT_NET") - fleF110_TOTDED.GetDecimalValue("AMT_NET")) * fleF110_PAYEFT.GetDecimalValue("FACTOR")) / 10000, 0, RoundOptionTypes.Near);
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
    private DInteger W_PAYEFT_AMT_N = new DInteger("W_PAYEFT_AMT_N", 10);
    private void W_PAYEFT_AMT_N_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (W_PAYEFT_AMT_1.Value >= 0)
            {
                CurrentValue = W_PAYEFT_AMT_1.Value;
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
    private DInteger W_AMT_DEFICIT = new DInteger("W_AMT_DEFICIT", 10);
    private void W_AMT_DEFICIT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (W_PAYEFT_AMT_1.Value >= 0)
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = Math.Abs(W_PAYEFT_AMT_1.Value);
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
    private SqlFileObject fleDEBUGU119;
    private DInteger W_NOT_NEEDED = new DInteger("W_NOT_NEEDED", 10);
    private void W_NOT_NEEDED_GetValue(ref decimal Value)
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
    private DCharacter W_REC_TYPE = new DCharacter("W_REC_TYPE", 1);
    private void W_REC_TYPE_GetValue(ref string Value)
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
    private CoreCharacter W_COMP_CODE_TRANSFER_OR_EFT;
    private SqlFileObject fleF119;
    private CoreCharacter W_COMP_CODE_ADVOUT;
    private SqlFileObject fleF119_ADVOUT;
    private SqlFileObject fleU119_PAYEFT;
    private CoreDecimal W_EP_NBR;
    private CoreDecimal W_EP_NBR_ENTRY;
    private CoreCharacter W_TYPE;
    private CoreDecimal W_SEQ;
    private CoreDecimal W_FACTOR;
    private CoreCharacter W_FACTOR_OVERRIDE;
    private CoreDecimal W_COMP_UNITS;
    private CoreDecimal W_AMT_GROSS;
    private CoreDecimal W_AMT_NET;
    private SqlFileObject fleU119_F110;
    private SqlFileObject fleU110_F110_ADVOUT;
    private CoreCharacter W_COMP_CODE_DEFIC;
    private SqlFileObject fleU110_F110_DEFIC;

    private DCharacter COMP_CODE = new DCharacter("COMP_CODE", 6);
    private void COMP_CODE_GetValue(ref string Value)
    {
        try
        {
            if (W_COMP_CODE_ADVOUT.Value == "ADVOUT")
            {
                Value = W_COMP_CODE_ADVOUT.Value;
            }
            else
            {
                Value = W_COMP_CODE_TRANSFER_OR_EFT.Value;
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
    }

    private DInteger REPORTING_SEQ = new DInteger("REPORTING_SEQ", 2);
    private void REPORTING_SEQ_GetValue(ref decimal Value)
    {
        try
        {
            if (W_COMP_CODE_ADVOUT.Value == "ADVOUT")
            {
                Value = ADVOUT_SEQ.Value;
            }
            else
            {
                Value = PAYEFT_SEQ.Value;
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
    }

    private DCharacter COMP_CODE_GROUP = new DCharacter("COMP_CODE_GROUP", 1);
    private void COMP_CODE_GROUP_GetValue(ref string Value)
    {
        try
        {
            if (W_COMP_CODE_ADVOUT.Value == "ADVOUT")
            {
                Value = ADVOUT_GROUP.Value;
            }
            else
            {
                Value = PAYEFT_GROUP.Value;
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
    }

    private DCharacter X_REC_TYPE = new DCharacter("X_REC_TYPE", 1);
    private void X_REC_TYPE_GetValue(ref string Value)
    {
        try
        {
            Value = W_REC_TYPE.Value;
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
            Value = W_NOT_NEEDED.Value;
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
            if (W_COMP_CODE_ADVOUT.Value == "ADVOUT")
            {
                Value = W_AMT_DEFICIT.Value;
            }
            else
            {
                Value = W_PAYEFT_AMT_N.Value;
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
    }

    #endregion


    #region "Standard Generated Procedures(U119_U119_B_7)"


    #region "Automatic Item Initialization(U119_U119_B_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:57 PM

    //#-----------------------------------------
    //# fleF110_PAYPOT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:24 PM
    //#-----------------------------------------
    private void fleF110_PAYPOT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {

            fleF110_PAYPOT.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_PAYPOT.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_PAYPOT.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_PAYPOT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_PAYPOT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_PAYPOT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
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
    //# fleF110_TOTDED_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:24 PM
    //#-----------------------------------------
    private void fleF110_TOTDED_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_TOTDED.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_TOTDED.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_TOTDED.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_TOTDED.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_TOTDED.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_TOTDED.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_TOTDED.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_PAYPOT.GetDecimalValue("PROCESS_SEQ"));
            fleF110_TOTDED.set_SetValue("COMP_CODE", !Fixed, fleF110_PAYPOT.GetStringValue("COMP_CODE"));
            fleF110_TOTDED.set_SetValue("COMP_TYPE", !Fixed, fleF110_PAYPOT.GetStringValue("COMP_TYPE"));
            fleF110_TOTDED.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_PAYPOT.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_TOTDED.set_SetValue("COMP_UNITS", !Fixed, fleF110_PAYPOT.GetDecimalValue("COMP_UNITS"));
            fleF110_TOTDED.set_SetValue("AMT_GROSS", !Fixed, fleF110_PAYPOT.GetDecimalValue("AMT_GROSS"));
            fleF110_TOTDED.set_SetValue("AMT_NET", !Fixed, fleF110_PAYPOT.GetDecimalValue("AMT_NET"));
            fleF110_TOTDED.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_PAYPOT.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_TOTDED.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_PAYPOT.GetStringValue("COMPENSATION_STATUS"));
            fleF110_TOTDED.set_SetValue("FILLER", !Fixed, fleF110_PAYPOT.GetStringValue("FILLER"));


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
    //# fleF110_PAYEFT_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:24 PM
    //#-----------------------------------------
    private void fleF110_PAYEFT_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_PAYEFT.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_PAYEFT.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_PAYEFT.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_PAYEFT.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_PAYEFT.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_PAYEFT.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_PAYEFT.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_PAYPOT.GetDecimalValue("PROCESS_SEQ"));
            fleF110_PAYEFT.set_SetValue("COMP_CODE", !Fixed, fleF110_PAYPOT.GetStringValue("COMP_CODE"));
            fleF110_PAYEFT.set_SetValue("COMP_TYPE", !Fixed, fleF110_PAYPOT.GetStringValue("COMP_TYPE"));
            fleF110_PAYEFT.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_PAYPOT.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_PAYEFT.set_SetValue("COMP_UNITS", !Fixed, fleF110_PAYPOT.GetDecimalValue("COMP_UNITS"));
            fleF110_PAYEFT.set_SetValue("AMT_GROSS", !Fixed, fleF110_PAYPOT.GetDecimalValue("AMT_GROSS"));
            fleF110_PAYEFT.set_SetValue("AMT_NET", !Fixed, fleF110_PAYPOT.GetDecimalValue("AMT_NET"));
            fleF110_PAYEFT.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_PAYPOT.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_PAYEFT.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_PAYPOT.GetStringValue("COMPENSATION_STATUS"));
            fleF110_PAYEFT.set_SetValue("FILLER", !Fixed, fleF110_PAYPOT.GetStringValue("FILLER"));


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
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:13:24 PM
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



    #endregion


    #region "Transaction Management Procedures(U119_U119_B_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:24 PM

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
        fleF110_PAYPOT.Transaction = m_trnTRANS_UPDATE;
        fleF110_TOTDED.Transaction = m_trnTRANS_UPDATE;
        fleF110_PAYEFT.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDEBUGU119.Transaction = m_trnTRANS_UPDATE;
        fleF119.Transaction = m_trnTRANS_UPDATE;
        fleF119_ADVOUT.Transaction = m_trnTRANS_UPDATE;
        fleU119_PAYEFT.Transaction = m_trnTRANS_UPDATE;
        fleU119_F110.Transaction = m_trnTRANS_UPDATE;
        fleU110_F110_ADVOUT.Transaction = m_trnTRANS_UPDATE;
        fleU110_F110_DEFIC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U119_U119_B_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:13:24 PM

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
            fleF110_PAYPOT.Dispose();
            fleF110_TOTDED.Dispose();
            fleF110_PAYEFT.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleDEBUGU119.Dispose();
            fleF119.Dispose();
            fleF119_ADVOUT.Dispose();
            fleU119_PAYEFT.Dispose();
            fleU119_F110.Dispose();
            fleU110_F110_ADVOUT.Dispose();
            fleU110_F110_DEFIC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U119_U119_B_7)"


    public void Run()
    {

        try
        {
            Request("U119_B_7");

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

                    while (fleF110_PAYPOT.QTPForMissing("2"))
                    {
                        // --> GET F110_PAYPOT <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF110_PAYPOT.ElementOwner("EP_NBR")).Append(" = ");
                        m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                        m_strWhere.Append(" And ").Append(fleF110_PAYPOT.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" And ").Append(fleF110_PAYPOT.ElementOwner("PROCESS_SEQ")).Append(" = ");
                        m_strWhere.Append((PAYPOT_SEQ.Value));
                        m_strWhere.Append(" And ").Append(fleF110_PAYPOT.ElementOwner("COMP_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("PAYPOT"));                    
                                              

                        fleF110_PAYPOT.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F110_PAYPOT <--

                        while (fleF110_TOTDED.QTPForMissing("3"))
                        {
                            // --> GET F110_TOTDED <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF110_TOTDED.ElementOwner("EP_NBR")).Append(" = ");
                            m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                            m_strWhere.Append(" And ").Append(fleF110_TOTDED.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" And ").Append(fleF110_TOTDED.ElementOwner("PROCESS_SEQ")).Append(" = ");
                            m_strWhere.Append((TOTDED_SEQ.Value));
                            m_strWhere.Append(" And ").Append(fleF110_TOTDED.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("TOTDED"));

                            fleF110_TOTDED.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F110_TOTDED <--

                            while (fleF110_PAYEFT.QTPForMissing("4"))
                            {
                                // --> GET F110_PAYEFT <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF110_PAYEFT.ElementOwner("EP_NBR")).Append(" = ");
                                m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                                m_strWhere.Append(" And ").Append(fleF110_PAYEFT.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                                m_strWhere.Append(" And ").Append(fleF110_PAYEFT.ElementOwner("PROCESS_SEQ")).Append(" = ");
                                m_strWhere.Append((PAYEFT_SEQ.Value));
                                m_strWhere.Append(" And ").Append(fleF110_PAYEFT.ElementOwner("COMP_CODE")).Append(" = ");
                                m_strWhere.Append(Common.StringToField("PAYEFT"));

                                fleF110_PAYEFT.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F110_PAYEFT <--

                                while (fleF020_DOCTOR_MSTR.QTPForMissing("5"))
                                {
                                    // --> GET F020_DOCTOR_MSTR <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F020_DOCTOR_MSTR <--


                                    if (Transaction())
                                    {

                                         if (Select_If())
                                        {
                                            SubFile(ref m_trnTRANS_UPDATE, ref fleDEBUGU119, SubFileType.Keep, fleF112_PYCDCEILINGS, "DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_DEPT", "DOC_DEPT", ICU_DEPT_1, fleF110_PAYPOT,
                                            "AMT_NET", PAYEFT_FACTOR, fleF110_PAYEFT, "FACTOR", W_PAYEFT_AMT_1, W_AMT_DEFICIT, W_PAYEFT_AMT_N);

                                            //if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) != QDesign.NULL(ICU_DEPT_1.Value))
                                            //{
                                            //    W_COMP_CODE_TRANSFER_OR_EFT.Value = "TRANSF";
                                            //}
                                            //else
                                            //{
                                            //    W_COMP_CODE_TRANSFER_OR_EFT.Value = "PAYEFT";
                                            //}
                                            W_COMP_CODE_TRANSFER_OR_EFT.Value = "PAYEFT";

                                            DEBUG_NOTE.Value = "Generated By: u119 - PAYEFT";
                                            SubFile(ref m_trnTRANS_UPDATE, ref fleF119, SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, 
                                                "DOC_NBR", W_COMP_CODE_TRANSFER_OR_EFT, PAYEFT_SEQ, PAYEFT_GROUP, W_REC_TYPE, W_NOT_NEEDED, W_PAYEFT_AMT_N, DEBUG_NOTE);

                                            W_COMP_CODE_ADVOUT.Value = "ADVOUT";

                                            if(QDesign.NULL(W_AMT_DEFICIT.Value) > 0)
                                            {

                                            }

                                            DEBUG_NOTE.Value = "Generated By: u119 - ADVOUT";
                                            SubFile(ref m_trnTRANS_UPDATE, ref fleF119_ADVOUT, QDesign.NULL(W_AMT_DEFICIT.Value) > 0, SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS,
                                                "DOC_NBR", W_COMP_CODE_ADVOUT, ADVOUT_SEQ, ADVOUT_GROUP, W_REC_TYPE, W_NOT_NEEDED, W_AMT_DEFICIT, DEBUG_NOTE);

                                            SubFile(ref m_trnTRANS_UPDATE, ref fleU119_PAYEFT, QDesign.NULL(W_COMP_CODE_TRANSFER_OR_EFT.Value) == "PAYEFT", SubFileType.Portable, fleF112_PYCDCEILINGS, "DOC_NBR", fleF020_DOCTOR_MSTR, "DOC_DEPT", W_PAYEFT_AMT_N);

                                            fleF020_DOCTOR_MSTR.OutPut(OutPutType.Update);


                                            W_EP_NBR.Value = W_CURRENT_EP_NBR.Value;

                                            W_EP_NBR_ENTRY.Value = W_CURRENT_EP_NBR.Value;
                                            //if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")) != QDesign.NULL(ICU_DEPT_1.Value))
                                            //{
                                            //    W_COMP_CODE_TRANSFER_OR_EFT.Value = "TRANSF";
                                            //}
                                            //else
                                            //{
                                            //    W_COMP_CODE_TRANSFER_OR_EFT.Value = "PAYEFT";
                                            //}

                                            W_COMP_CODE_TRANSFER_OR_EFT.Value = "PAYEFT";
                                            W_TYPE.Value = QDesign.NULL(PAYEFT_TYPE.Value);
                                            W_SEQ.Value = PAYEFT_SEQ.Value;
                                            W_FACTOR.Value = PAYEFT_FACTOR.Value;
                                            if (fleF110_PAYEFT.Exists())
                                            {
                                                W_FACTOR_OVERRIDE.Value = "*";
                                            }
                                            else
                                            {
                                                W_FACTOR_OVERRIDE.Value = " ";
                                            }
                                            if (fleF110_PAYEFT.Exists())
                                            {
                                                W_COMP_UNITS.Value = Math.Floor(((fleF110_PAYEFT.GetDecimalValue("COMP_UNITS") * fleF110_PAYEFT.GetDecimalValue("FACTOR")) + 0.5m) / 10000);
                                            }
                                            else
                                            {
                                                W_COMP_UNITS.Value = 0;
                                            }
                                            W_AMT_GROSS.Value = (fleF110_PAYPOT.GetDecimalValue("AMT_NET") - fleF110_TOTDED.GetDecimalValue("AMT_NET"));
                                            W_AMT_NET.Value = W_PAYEFT_AMT_N.Value;

                                            SubFile(ref m_trnTRANS_UPDATE, ref fleU119_F110, SubFileType.Keep, fleF112_PYCDCEILINGS, "DOC_NBR", W_EP_NBR, W_EP_NBR_ENTRY, W_COMP_CODE_TRANSFER_OR_EFT, W_TYPE, W_SEQ,
                                            W_FACTOR, W_FACTOR_OVERRIDE, W_COMP_UNITS, W_AMT_GROSS, W_AMT_NET);


                                            W_EP_NBR.Value = W_CURRENT_EP_NBR.Value;
                                            W_EP_NBR_ENTRY.Value = W_CURRENT_EP_NBR.Value;
                                            W_COMP_CODE_ADVOUT.Value = "ADVOUT";
                                            W_TYPE.Value = QDesign.NULL(ADVOUT_TYPE.Value);
                                            W_SEQ.Value = ADVOUT_SEQ.Value;
                                            W_FACTOR.Value = ADVOUT_FACTOR.Value;
                                            W_FACTOR_OVERRIDE.Value = "*";
                                            W_COMP_UNITS.Value = 0;
                                            W_AMT_GROSS.Value = W_AMT_DEFICIT.Value;
                                            W_AMT_NET.Value = W_AMT_DEFICIT.Value;
                                            SubFile(ref m_trnTRANS_UPDATE, ref fleU110_F110_ADVOUT, QDesign.NULL(W_AMT_DEFICIT.Value) > 0, SubFileType.Keep, fleF112_PYCDCEILINGS, "DOC_NBR", W_EP_NBR, W_EP_NBR_ENTRY, W_COMP_CODE_ADVOUT, W_TYPE,
                                            W_SEQ, W_FACTOR, W_FACTOR_OVERRIDE, W_COMP_UNITS, W_AMT_GROSS, W_AMT_NET);


                                            W_EP_NBR.Value = W_CURRENT_EP_NBR_PLUS1.Value;
                                            W_EP_NBR_ENTRY.Value = W_CURRENT_EP_NBR.Value;
                                            W_COMP_CODE_DEFIC.Value = "DEFIC";
                                            W_TYPE.Value = QDesign.NULL(DEFIC_TYPE.Value);
                                            W_SEQ.Value = DEFIC_SEQ.Value;
                                            W_FACTOR.Value = DEFIC_FACTOR.Value;
                                            W_FACTOR_OVERRIDE.Value = "*";
                                            W_COMP_UNITS.Value = 0;
                                            W_AMT_GROSS.Value = W_AMT_DEFICIT.Value;
                                            W_AMT_NET.Value = W_AMT_DEFICIT.Value;
                                            SubFile(ref m_trnTRANS_UPDATE, ref fleU110_F110_DEFIC, QDesign.NULL(W_AMT_DEFICIT.Value) > 0, SubFileType.Keep, fleF112_PYCDCEILINGS, "DOC_NBR", W_EP_NBR, W_EP_NBR_ENTRY, W_COMP_CODE_DEFIC, W_TYPE,
                                            W_SEQ, W_FACTOR, W_FACTOR_OVERRIDE, W_COMP_UNITS, W_AMT_GROSS, W_AMT_NET);


                                        }

                                    }

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
            EndRequest("U119_B_7");

        }

    }







    #endregion


}
//U119_B_7




