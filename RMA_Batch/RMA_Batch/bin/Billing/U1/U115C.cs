
#region "Screen Comments"

// U115C.QTS
// ((C)) Dyad Technologies
// PURPOSE: SUB-PROCESS WITHIN  EARNINGS GENERATION  PROCESS.
// CALCULATE REQUIRED TRANSACTIONS AS OF CURRENT EP
// MODIFICATION HISTORY
// DATE    SAF #  WHO      DESCRIPTION
// 95/NOV/15  ____   M.C.     - original
// 96/FEB/26  ----   M.C.  - NO OPTIONAL TO F020-DOCTOR-EXTRA,
// AND GENERATE INCREQ & INCTAR ONLY
// IF DOC-YRLY-REQREV OR DOC-YRLY-TARREV
// IS ZERO
// 1999/Feb/18         S.B.     - Checked for Y2K.
// 1999/June/01  S.B.     - Added the use file
// def_compensation_status.def to 
// prevent hard coding of compensation-status.
// 2003/dec/24  A.A.  - alpha doctor nbr
// 2005/sep/06  M.C.  - extend the criteria for definition of amt-increq
// and amt-inctar
// 2009/mar/18  MC1  - extend the criteria for definition of amt-increq
// and amt-inctar to use amt-gross instead of amt-net


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U115C : BaseClassControl
{

    private U115C m_U115C;

    public U115C(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        INCREQ_SEQ = new CoreDecimal("INCREQ_SEQ", 2, this, ResetTypes.ResetAtStartup);
        INCREQ_TYPE = new CoreCharacter("INCREQ_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCREQ_GROUP = new CoreCharacter("INCREQ_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCREQ_SEQ_RPT = new CoreDecimal("INCREQ_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        INCTAR_SEQ = new CoreDecimal("INCTAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        INCTAR_TYPE = new CoreCharacter("INCTAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCTAR_GROUP = new CoreCharacter("INCTAR_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCTAR_SEQ_RPT = new CoreDecimal("INCTAR_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);


    }

    public U115C(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        YTDINC_SEQ = new CoreDecimal("YTDINC_SEQ", 2, this, ResetTypes.ResetAtStartup);
        INCREQ_SEQ = new CoreDecimal("INCREQ_SEQ", 2, this, ResetTypes.ResetAtStartup);
        INCREQ_TYPE = new CoreCharacter("INCREQ_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCREQ_GROUP = new CoreCharacter("INCREQ_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCREQ_SEQ_RPT = new CoreDecimal("INCREQ_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);
        INCTAR_SEQ = new CoreDecimal("INCTAR_SEQ", 2, this, ResetTypes.ResetAtStartup);
        INCTAR_TYPE = new CoreCharacter("INCTAR_TYPE", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCTAR_GROUP = new CoreCharacter("INCTAR_GROUP", 1, this, ResetTypes.ResetAtStartup, Common.cEmptyString);
        INCTAR_SEQ_RPT = new CoreDecimal("INCTAR_SEQ_RPT", 2, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U115C != null))
        {
            m_U115C.CloseTransactionObjects();
            m_U115C = null;
        }
    }

    public U115C GetU115C(int Level)
    {
        if (m_U115C == null)
        {
            m_U115C = new U115C("U115C", Level);
        }
        else
        {
            m_U115C.ResetValues();
        }
        return m_U115C;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal YTDINC_SEQ;
    protected CoreDecimal INCREQ_SEQ;
    protected CoreCharacter INCREQ_TYPE;
    protected CoreCharacter INCREQ_GROUP;
    protected CoreDecimal INCREQ_SEQ_RPT;
    protected CoreDecimal INCTAR_SEQ;
    protected CoreCharacter INCTAR_TYPE;
    protected CoreCharacter INCTAR_GROUP;

    protected CoreDecimal INCTAR_SEQ_RPT;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U115C_U115_A_GET_YTDINC_1 U115_A_GET_YTDINC_1 = new U115C_U115_A_GET_YTDINC_1(Name, Level);
            U115_A_GET_YTDINC_1.Run();
            U115_A_GET_YTDINC_1.Dispose();
            U115_A_GET_YTDINC_1 = null;

            U115C_U115_A_GET_INCREQ_2 U115_A_GET_INCREQ_2 = new U115C_U115_A_GET_INCREQ_2(Name, Level);
            U115_A_GET_INCREQ_2.Run();
            U115_A_GET_INCREQ_2.Dispose();
            U115_A_GET_INCREQ_2 = null;

            U115C_U115_A_GET_INCTAR_3 U115_A_GET_INCTAR_3 = new U115C_U115_A_GET_INCTAR_3(Name, Level);
            U115_A_GET_INCTAR_3.Run();
            U115_A_GET_INCTAR_3.Dispose();
            U115_A_GET_INCTAR_3 = null;

            U115C_U115_RUN_0_4 U115_RUN_0_4 = new U115C_U115_RUN_0_4(Name, Level);
            U115_RUN_0_4.Run();
            U115_RUN_0_4.Dispose();
            U115_RUN_0_4 = null;

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



public class U115C_U115_A_GET_YTDINC_1 : U115C
{

    public U115C_U115_A_GET_YTDINC_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115C_U115_A_GET_YTDINC_1)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("YTDINC"));


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


    #region "Standard Generated Procedures(U115C_U115_A_GET_YTDINC_1)"


    #region "Automatic Item Initialization(U115C_U115_A_GET_YTDINC_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115C_U115_A_GET_YTDINC_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:19:55 PM

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


    #region "FILE Management Procedures(U115C_U115_A_GET_YTDINC_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:19:55 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115C_U115_A_GET_YTDINC_1)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_YTDINC_1");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    YTDINC_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");

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
            EndRequest("U115_A_GET_YTDINC_1");

        }

    }







    #endregion


}
//U115_A_GET_YTDINC_1



public class U115C_U115_A_GET_INCREQ_2 : U115C
{

    public U115C_U115_A_GET_INCREQ_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115C_U115_A_GET_INCREQ_2)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("INCREQ"));


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


    #region "Standard Generated Procedures(U115C_U115_A_GET_INCREQ_2)"


    #region "Automatic Item Initialization(U115C_U115_A_GET_INCREQ_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115C_U115_A_GET_INCREQ_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:19:56 PM

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


    #region "FILE Management Procedures(U115C_U115_A_GET_INCREQ_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:19:56 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115C_U115_A_GET_INCREQ_2)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_INCREQ_2");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    INCREQ_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    INCREQ_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    INCREQ_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");
                    INCREQ_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");

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
            EndRequest("U115_A_GET_INCREQ_2");

        }

    }







    #endregion


}
//U115_A_GET_INCREQ_2



public class U115C_U115_A_GET_INCTAR_3 : U115C
{

    public U115C_U115_A_GET_INCTAR_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF190_COMP_CODES = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F190_COMP_CODES", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF190_COMP_CODES.Choose += fleF190_COMP_CODES_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U115C_U115_A_GET_INCTAR_3)"

    private SqlFileObject fleF190_COMP_CODES;

    private void fleF190_COMP_CODES_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF190_COMP_CODES.ElementOwner("COMP_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("INCTAR"));


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


    #region "Standard Generated Procedures(U115C_U115_A_GET_INCTAR_3)"


    #region "Automatic Item Initialization(U115C_U115_A_GET_INCTAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U115C_U115_A_GET_INCTAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:19:56 PM

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


    #region "FILE Management Procedures(U115C_U115_A_GET_INCTAR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:19:56 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115C_U115_A_GET_INCTAR_3)"


    public void Run()
    {

        try
        {
            Request("U115_A_GET_INCTAR_3");

            while (fleF190_COMP_CODES.QTPForMissing())
            {
                // --> GET F190_COMP_CODES <--

                fleF190_COMP_CODES.GetData();
                // --> End GET F190_COMP_CODES <--

                if (Transaction())
                {
                    INCTAR_SEQ.Value = fleF190_COMP_CODES.GetDecimalValue("PROCESS_SEQ");
                    INCTAR_TYPE.Value = fleF190_COMP_CODES.GetStringValue("COMP_TYPE");
                    INCTAR_SEQ_RPT.Value = fleF190_COMP_CODES.GetDecimalValue("REPORTING_SEQ");
                    INCTAR_GROUP.Value = fleF190_COMP_CODES.GetStringValue("COMP_CODE_GROUP");

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
            EndRequest("U115_A_GET_INCTAR_3");

        }

    }







    #endregion


}
//U115_A_GET_INCTAR_3



public class U115C_U115_RUN_0_4 : U115C
{

    public U115C_U115_RUN_0_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF112_PYCDCEILINGS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F112_PYCDCEILINGS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_YTDINC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_YTDINC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF119_INCREQ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_INCREQ", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF119_INCTAR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F119", "F119_INCTAR", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF110_INCREQ = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_INCREQ", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF110_INCTAR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F110_COMPENSATION", "F110_INCTAR", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;
        AMT_INCREQ.GetValue += AMT_INCREQ_GetValue;
        AMT_INCTAR.GetValue += AMT_INCTAR_GetValue;
        X_REC_TYPE.GetValue += X_REC_TYPE_GetValue;
        X_NOT_NEEDED.GetValue += X_NOT_NEEDED_GetValue;
        X_COMP_CODE_INCREQ.GetValue += X_COMP_CODE_INCREQ_GetValue;
        COMPENSATION_STATUS_ACCEPTED.GetValue += COMPENSATION_STATUS_ACCEPTED_GetValue;
        X_COMP_CODE_INCTAR.GetValue += X_COMP_CODE_INCTAR_GetValue;
        fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;
        fleF110_YTDINC.InitializeItems += fleF110_YTDINC_AutomaticItemInitialization;
        fleF110_INCREQ.InitializeItems += fleF110_INCREQ_AutomaticItemInitialization;
        fleF110_INCTAR.InitializeItems += fleF110_INCTAR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U115C_U115_RUN_0_4)"

    private SqlFileObject fleCONSTANTS_MSTR_REC_6;
    private SqlFileObject fleF112_PYCDCEILINGS;
    private SqlFileObject fleF020_DOCTOR_EXTRA;
    private SqlFileObject fleF110_YTDINC;

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

    private DInteger AMT_INCREQ = new DInteger("AMT_INCREQ", 10);
    private void AMT_INCREQ_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_REQREV")) != 0 & QDesign.NULL(fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ")) != 0 & QDesign.NULL(fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_REQUIRE_REVENUE")) != 0)
            {
                CurrentValue = fleF110_YTDINC.GetDecimalValue("AMT_GROSS") - fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDREQ");
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
    private DInteger AMT_INCTAR = new DInteger("AMT_INCTAR", 10);
    private void AMT_INCTAR_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0;
            if (QDesign.NULL(fleF112_PYCDCEILINGS.GetDecimalValue("DOC_YRLY_TARREV")) != 0 & QDesign.NULL(fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR")) != 0 & QDesign.NULL(fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YRLY_TARGET_REVENUE")) != 0)
            {
                CurrentValue = fleF110_YTDINC.GetDecimalValue("AMT_GROSS") - fleF020_DOCTOR_EXTRA.GetDecimalValue("DOC_YTDTAR");
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
    private DCharacter X_COMP_CODE_INCREQ = new DCharacter("X_COMP_CODE_INCREQ", 6);
    private void X_COMP_CODE_INCREQ_GetValue(ref string Value)
    {

        try
        {
            Value = "INCREQ";


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
    private SqlFileObject fleF119_INCREQ;
    private DCharacter X_COMP_CODE_INCTAR = new DCharacter("X_COMP_CODE_INCTAR", 6);
    private void X_COMP_CODE_INCTAR_GetValue(ref string Value)
    {

        try
        {
            Value = "INCTAR";


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
    private SqlFileObject fleF119_INCTAR;
    private SqlFileObject fleF110_INCREQ;
    private SqlFileObject fleF110_INCTAR;


    #endregion


    #region "Standard Generated Procedures(U115C_U115_RUN_0_4)"


    #region "Automatic Item Initialization(U115C_U115_RUN_0_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:20:02 PM

    //#-----------------------------------------
    //# fleF020_DOCTOR_EXTRA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:19:56 PM
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
    //# fleF110_YTDINC_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:19:56 PM
    //#-----------------------------------------
    private void fleF110_YTDINC_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_YTDINC.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_YTDINC.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_YTDINC.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_YTDINC.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_YTDINC.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_YTDINC.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_YTDINC.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));

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
    //# fleF110_INCREQ_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:01 PM
    //#-----------------------------------------
    private void fleF110_INCREQ_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_INCREQ.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_INCREQ.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_INCREQ.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_INCREQ.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_INCREQ.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_INCREQ.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_INCREQ.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF110_INCREQ.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_YTDINC.GetDecimalValue("PROCESS_SEQ"));
            fleF110_INCREQ.set_SetValue("COMP_CODE", !Fixed, fleF110_YTDINC.GetStringValue("COMP_CODE"));
            fleF110_INCREQ.set_SetValue("COMP_TYPE", !Fixed, fleF110_YTDINC.GetStringValue("COMP_TYPE"));
            fleF110_INCREQ.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_YTDINC.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_INCREQ.set_SetValue("COMP_UNITS", !Fixed, fleF110_YTDINC.GetDecimalValue("COMP_UNITS"));
            fleF110_INCREQ.set_SetValue("AMT_GROSS", !Fixed, fleF110_YTDINC.GetDecimalValue("AMT_GROSS"));
            fleF110_INCREQ.set_SetValue("AMT_NET", !Fixed, fleF110_YTDINC.GetDecimalValue("AMT_NET"));
            fleF110_INCREQ.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_YTDINC.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_INCREQ.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_YTDINC.GetStringValue("COMPENSATION_STATUS"));

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
    //# fleF110_INCTAR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:20:02 PM
    //#-----------------------------------------
    private void fleF110_INCTAR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF110_INCTAR.set_SetValue("DOC_NBR", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR"));
            fleF110_INCTAR.set_SetValue("EP_NBR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR"));
            fleF110_INCTAR.set_SetValue("FACTOR", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("FACTOR"));
            fleF110_INCTAR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_DATE"));
            fleF110_INCTAR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF112_PYCDCEILINGS.GetDecimalValue("LAST_MOD_TIME"));
            fleF110_INCTAR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF112_PYCDCEILINGS.GetStringValue("LAST_MOD_USER_ID"));
            //TODO: Manual steps may be required.
            fleF110_INCTAR.set_SetValue("FILLER", !Fixed, fleF020_DOCTOR_EXTRA.GetStringValue("FILLER"));
            //TODO: Manual steps may be required.
            fleF110_INCTAR.set_SetValue("PROCESS_SEQ", !Fixed, fleF110_YTDINC.GetDecimalValue("PROCESS_SEQ"));
            fleF110_INCTAR.set_SetValue("COMP_CODE", !Fixed, fleF110_YTDINC.GetStringValue("COMP_CODE"));
            fleF110_INCTAR.set_SetValue("COMP_TYPE", !Fixed, fleF110_YTDINC.GetStringValue("COMP_TYPE"));
            fleF110_INCTAR.set_SetValue("FACTOR_OVERRIDE", !Fixed, fleF110_YTDINC.GetStringValue("FACTOR_OVERRIDE"));
            fleF110_INCTAR.set_SetValue("COMP_UNITS", !Fixed, fleF110_YTDINC.GetDecimalValue("COMP_UNITS"));
            fleF110_INCTAR.set_SetValue("AMT_GROSS", !Fixed, fleF110_YTDINC.GetDecimalValue("AMT_GROSS"));
            fleF110_INCTAR.set_SetValue("AMT_NET", !Fixed, fleF110_YTDINC.GetDecimalValue("AMT_NET"));
            fleF110_INCTAR.set_SetValue("EP_NBR_ENTRY", !Fixed, fleF110_YTDINC.GetDecimalValue("EP_NBR_ENTRY"));
            fleF110_INCTAR.set_SetValue("COMPENSATION_STATUS", !Fixed, fleF110_YTDINC.GetStringValue("COMPENSATION_STATUS"));

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


    #region "Transaction Management Procedures(U115C_U115_RUN_0_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:19:56 PM

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
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleF110_YTDINC.Transaction = m_trnTRANS_UPDATE;
        fleF119_INCREQ.Transaction = m_trnTRANS_UPDATE;
        fleF119_INCTAR.Transaction = m_trnTRANS_UPDATE;
        fleF110_INCREQ.Transaction = m_trnTRANS_UPDATE;
        fleF110_INCTAR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U115C_U115_RUN_0_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:19:56 PM

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
            fleF020_DOCTOR_EXTRA.Dispose();
            fleF110_YTDINC.Dispose();
            fleF119_INCREQ.Dispose();
            fleF119_INCTAR.Dispose();
            fleF110_INCREQ.Dispose();
            fleF110_INCTAR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U115C_U115_RUN_0_4)"


    public void Run()
    {

        try
        {
            Request("U115_RUN_0_4");

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

                    while (fleF020_DOCTOR_EXTRA.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_EXTRA <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));

                        fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_EXTRA <--

                        while (fleF110_YTDINC.QTPForMissing("3"))
                        {
                            // --> GET F110_YTDINC <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF110_YTDINC.ElementOwner("EP_NBR")).Append(" = ");
                            m_strWhere.Append((fleF112_PYCDCEILINGS.GetDecimalValue("EP_NBR")));
                            m_strWhere.Append(" And ").Append(fleF110_YTDINC.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF112_PYCDCEILINGS.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" And ").Append(fleF110_YTDINC.ElementOwner("PROCESS_SEQ")).Append(" = ");
                            m_strWhere.Append((YTDINC_SEQ.Value));
                            m_strWhere.Append(" And ").Append(fleF110_YTDINC.ElementOwner("COMP_CODE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("YTDINC"));

                            fleF110_YTDINC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F110_YTDINC <--


                            if (Transaction())
                            {
                                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_INCREQ, QDesign.NULL(AMT_INCREQ.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE_INCREQ, INCREQ_SEQ_RPT, INCREQ_GROUP, X_REC_TYPE,
                                X_NOT_NEEDED, AMT_INCREQ);

                                SubFile(ref m_trnTRANS_UPDATE, ref fleF119_INCTAR, QDesign.NULL(AMT_INCTAR.Value) != 0, SubFileType.Keep, SubFileMode.Append, fleF112_PYCDCEILINGS, "DOC_NBR", X_COMP_CODE_INCTAR, INCTAR_SEQ_RPT, INCTAR_GROUP, X_REC_TYPE,
                                X_NOT_NEEDED, AMT_INCTAR);


                                fleF110_INCREQ.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                                fleF110_INCREQ.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                                fleF110_INCREQ.set_SetValue("COMP_CODE", "INCREQ");


                                fleF110_INCREQ.set_SetValue("COMP_TYPE", QDesign.NULL(INCREQ_TYPE.Value));


                                fleF110_INCREQ.set_SetValue("PROCESS_SEQ", INCREQ_SEQ.Value);


                                fleF110_INCREQ.set_SetValue("FACTOR", 0);


                                fleF110_INCREQ.set_SetValue("FACTOR_OVERRIDE", " ");


                                fleF110_INCREQ.set_SetValue("COMP_UNITS", 0);


                                fleF110_INCREQ.set_SetValue("AMT_GROSS", 0);


                                fleF110_INCREQ.set_SetValue("AMT_NET", AMT_INCREQ.Value);


                                fleF110_INCREQ.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                                fleF110_INCREQ.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                                fleF110_INCREQ.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                                fleF110_INCREQ.set_SetValue("LAST_MOD_USER_ID", "U115C gen`d");

                                fleF110_INCREQ.OutPut(OutPutType.Add, null, QDesign.NULL(AMT_INCREQ.Value) != 0);



                                fleF110_INCTAR.set_SetValue("EP_NBR", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                                fleF110_INCTAR.set_SetValue("EP_NBR_ENTRY", fleCONSTANTS_MSTR_REC_6.GetDecimalValue("CURRENT_EP_NBR"));


                                fleF110_INCTAR.set_SetValue("COMP_CODE", "INCTAR");


                                fleF110_INCTAR.set_SetValue("COMP_TYPE", QDesign.NULL(INCTAR_TYPE.Value));


                                fleF110_INCTAR.set_SetValue("PROCESS_SEQ", INCTAR_SEQ.Value);


                                fleF110_INCTAR.set_SetValue("FACTOR", 0);


                                fleF110_INCTAR.set_SetValue("FACTOR_OVERRIDE", " ");


                                fleF110_INCTAR.set_SetValue("COMP_UNITS", 0);


                                fleF110_INCTAR.set_SetValue("AMT_GROSS", 0);


                                fleF110_INCTAR.set_SetValue("AMT_NET", AMT_INCTAR.Value);


                                fleF110_INCTAR.set_SetValue("COMPENSATION_STATUS", COMPENSATION_STATUS_ACCEPTED.Value);


                                fleF110_INCTAR.set_SetValue("LAST_MOD_DATE", QDesign.SysDate(ref m_cnnQUERY));


                                fleF110_INCTAR.set_SetValue("LAST_MOD_TIME", QDesign.SysTime(ref m_cnnQUERY) / 10000);


                                fleF110_INCTAR.set_SetValue("LAST_MOD_USER_ID", "U115C gen`d");

                                fleF110_INCTAR.OutPut(OutPutType.Add, null, QDesign.NULL(AMT_INCTAR.Value) != 0);

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
            EndRequest("U115_RUN_0_4");

        }

    }







    #endregion


}
//U115_RUN_0_4




