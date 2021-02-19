
#region "Screen Comments"

// #> PROGRAM-ID.   utl0201.qts
// ((C)) Dyad Technologies
// PROGRAM PURPOSE :
// - extract data from:
// - all `doctor changes audit` files 
// - f020
// - all payments from f119 and f119 history
// and place into .ps for ftp download to SQL server database
// NOTE:  This program is run for 3 environments for their own files and then consolidate to *_all.ps in 101c/production
// This program should NOT extract master files that are shared the same for all environments.  If needed, define
// in utl0030.qts
// MODIFICATION HISTORY
// DATE   WHO   DESCRIPTION
// 2015/mar/03 b.e - original
// 2015/mar/24 MC1 - transfer the request for f191 from ut0030.qts as agreed by Brad
// 2017/jan/09 be2 - ID: 1706 - don`t see f020-doctor-mstr doctors if terminate > 18 months ago
// temp comment out of above select but permanent addition of doc term date to downloaded f020 subfile


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class Billing_UTL0201 : BaseClassControl
{

    private Billing_UTL0201 m_Billing_UTL0201;

    public Billing_UTL0201(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        ENVIRONMENT = new CoreCharacter("ENVIRONMENT", 4, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());


    }

    public Billing_UTL0201(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_CURRENT_EP_NBR = new CoreDecimal("W_CURRENT_EP_NBR", 6, this, ResetTypes.ResetAtStartup);
        ENVIRONMENT = new CoreCharacter("ENVIRONMENT", 4, this, ResetTypes.ResetAtStartup, Prompt(1).ToString());


    }

    public override void Dispose()
    {
        if ((m_Billing_UTL0201 != null))
        {
            m_Billing_UTL0201.CloseTransactionObjects();
            m_Billing_UTL0201 = null;
        }
    }

    public Billing_UTL0201 GetBilling_UTL0201(int Level)
    {
        if (m_Billing_UTL0201 == null)
        {
            m_Billing_UTL0201 = new Billing_UTL0201("Billing_UTL0201", Level);
        }
        else
        {
            m_Billing_UTL0201.ResetValues();
        }
        return m_Billing_UTL0201;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    protected CoreDecimal W_CURRENT_EP_NBR;

    protected CoreCharacter ENVIRONMENT;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            Billing_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1 A_CONSTANTS_VALUES_EP_NBR_1 = new Billing_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1(Name, Level);
            A_CONSTANTS_VALUES_EP_NBR_1.Run();
            A_CONSTANTS_VALUES_EP_NBR_1.Dispose();
            A_CONSTANTS_VALUES_EP_NBR_1 = null;

            Billing_UTL0201_F020_AUDIT_2 F020_AUDIT_2 = new Billing_UTL0201_F020_AUDIT_2(Name, Level);
            F020_AUDIT_2.Run();
            F020_AUDIT_2.Dispose();
            F020_AUDIT_2 = null;

            Billing_UTL0201_F028_AUDIT_3 F028_AUDIT_3 = new Billing_UTL0201_F028_AUDIT_3(Name, Level);
            F028_AUDIT_3.Run();
            F028_AUDIT_3.Dispose();
            F028_AUDIT_3 = null;

            Billing_UTL0201_F110_AUDIT_4 F110_AUDIT_4 = new Billing_UTL0201_F110_AUDIT_4(Name, Level);
            F110_AUDIT_4.Run();
            F110_AUDIT_4.Dispose();
            F110_AUDIT_4 = null;

            Billing_UTL0201_F112_AUDIT_5 F112_AUDIT_5 = new Billing_UTL0201_F112_AUDIT_5(Name, Level);
            F112_AUDIT_5.Run();
            F112_AUDIT_5.Dispose();
            F112_AUDIT_5 = null;

            Billing_UTL0201_F119_AUDIT_6 F119_AUDIT_6 = new Billing_UTL0201_F119_AUDIT_6(Name, Level);
            F119_AUDIT_6.Run();
            F119_AUDIT_6.Dispose();
            F119_AUDIT_6 = null;

            Billing_UTL0201_F020_7 F020_7 = new Billing_UTL0201_F020_7(Name, Level);
            F020_7.Run();
            F020_7.Dispose();
            F020_7 = null;

            Billing_UTL0201_F119_8 F119_8 = new Billing_UTL0201_F119_8(Name, Level);
            F119_8.Run();
            F119_8.Dispose();
            F119_8 = null;

            Billing_UTL0201_F119_HISTORY_9 F119_HISTORY_9 = new Billing_UTL0201_F119_HISTORY_9(Name, Level);
            F119_HISTORY_9.Run();
            F119_HISTORY_9.Dispose();
            F119_HISTORY_9 = null;

            Billing_UTL0201_F191_10 F191_10 = new Billing_UTL0201_F191_10(Name, Level);
            F191_10.Run();
            F191_10.Dispose();
            F191_10 = null;

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



public class Billing_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1 : Billing_UTL0201
{

    public Billing_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleCONSTANTS_MSTR_REC_6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "CONSTANTS_MSTR_REC_6", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleCONSTANTS_MSTR_REC_6.Choose += fleCONSTANTS_MSTR_REC_6_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"

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


    #region "Standard Generated Procedures(Billing_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"


    #region "Automatic Item Initialization(Billing_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:18 PM

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


    #region "FILE Management Procedures(Billing_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:18 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0201_A_CONSTANTS_VALUES_EP_NBR_1)"


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



public class Billing_UTL0201_F020_AUDIT_2 : Billing_UTL0201
{

    public Billing_UTL0201_F020_AUDIT_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "F020_DOCTOR_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTLF020_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTLF020_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0201_F020_AUDIT_2)"

    private SqlFileObject fleF020_DOCTOR_AUDIT;
    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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



    private SqlFileObject fleUTLF020_AUDIT;


    #endregion


    #region "Standard Generated Procedures(Billing_UTL0201_F020_AUDIT_2)"


    #region "Automatic Item Initialization(Billing_UTL0201_F020_AUDIT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_UTL0201_F020_AUDIT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:18 PM

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
        fleF020_DOCTOR_AUDIT.Transaction = m_trnTRANS_UPDATE;
        fleUTLF020_AUDIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_UTL0201_F020_AUDIT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:18 PM

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
            fleF020_DOCTOR_AUDIT.Dispose();
            fleUTLF020_AUDIT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0201_F020_AUDIT_2)"


    public void Run()
    {

        try
        {
            Request("F020_AUDIT_2");

            while (fleF020_DOCTOR_AUDIT.QTPForMissing())
            {
                // --> GET F020_DOCTOR_AUDIT <--

                fleF020_DOCTOR_AUDIT.GetData();
                // --> End GET F020_DOCTOR_AUDIT <--


                if (Transaction())
                {



                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTLF020_AUDIT, SubFileType.Keep, ENVIRONMENT, X_DELIMITER, fleF020_DOCTOR_AUDIT);



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
            EndRequest("F020_AUDIT_2");

        }

    }




    #endregion


}
//F020_AUDIT_2



public class Billing_UTL0201_F028_AUDIT_3 : Billing_UTL0201
{

    public Billing_UTL0201_F028_AUDIT_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF028_AUDIT_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F028_AUDIT_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTLF028_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTLF028_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0201_F028_AUDIT_3)"

    private SqlFileObject fleF028_AUDIT_FILE;
    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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



    private SqlFileObject fleUTLF028_AUDIT;


    #endregion


    #region "Standard Generated Procedures(Billing_UTL0201_F028_AUDIT_3)"


    #region "Automatic Item Initialization(Billing_UTL0201_F028_AUDIT_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_UTL0201_F028_AUDIT_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
        fleF028_AUDIT_FILE.Transaction = m_trnTRANS_UPDATE;
        fleUTLF028_AUDIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_UTL0201_F028_AUDIT_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
            fleF028_AUDIT_FILE.Dispose();
            fleUTLF028_AUDIT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0201_F028_AUDIT_3)"


    public void Run()
    {

        try
        {
            Request("F028_AUDIT_3");

            while (fleF028_AUDIT_FILE.QTPForMissing())
            {
                // --> GET F028_AUDIT_FILE <--

                fleF028_AUDIT_FILE.GetData();
                // --> End GET F028_AUDIT_FILE <--


                if (Transaction())
                {



                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTLF028_AUDIT, SubFileType.Keep, ENVIRONMENT, X_DELIMITER, fleF028_AUDIT_FILE, X_LF);



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
            EndRequest("F028_AUDIT_3");

        }

    }




    #endregion


}
//F028_AUDIT_3



public class Billing_UTL0201_F110_AUDIT_4 : Billing_UTL0201
{

    public Billing_UTL0201_F110_AUDIT_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF110_COMPENSATION_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "F110_COMPENSATION_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTLF110_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTLF110_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0201_F110_AUDIT_4)"

    private SqlFileObject fleF110_COMPENSATION_AUDIT;
    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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



    private SqlFileObject fleUTLF110_AUDIT;


    #endregion


    #region "Standard Generated Procedures(Billing_UTL0201_F110_AUDIT_4)"


    #region "Automatic Item Initialization(Billing_UTL0201_F110_AUDIT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_UTL0201_F110_AUDIT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
        fleF110_COMPENSATION_AUDIT.Transaction = m_trnTRANS_UPDATE;
        fleUTLF110_AUDIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_UTL0201_F110_AUDIT_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
            fleF110_COMPENSATION_AUDIT.Dispose();
            fleUTLF110_AUDIT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0201_F110_AUDIT_4)"


    public void Run()
    {

        try
        {
            Request("F110_AUDIT_4");

            while (fleF110_COMPENSATION_AUDIT.QTPForMissing())
            {
                // --> GET F110_COMPENSATION_AUDIT <--

                fleF110_COMPENSATION_AUDIT.GetData();
                // --> End GET F110_COMPENSATION_AUDIT <--


                if (Transaction())
                {



                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTLF110_AUDIT, SubFileType.Keep, ENVIRONMENT, X_DELIMITER, fleF110_COMPENSATION_AUDIT, X_LF);



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
            EndRequest("F110_AUDIT_4");

        }

    }




    #endregion


}
//F110_AUDIT_4



public class Billing_UTL0201_F112_AUDIT_5 : Billing_UTL0201
{

    public Billing_UTL0201_F112_AUDIT_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF112_PYCDCEILINGS_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "F112_PYCDCEILINGS_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTLF112_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTLF112_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0201_F112_AUDIT_5)"

    private SqlFileObject fleF112_PYCDCEILINGS_AUDIT;
    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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



    private SqlFileObject fleUTLF112_AUDIT;


    #endregion


    #region "Standard Generated Procedures(Billing_UTL0201_F112_AUDIT_5)"


    #region "Automatic Item Initialization(Billing_UTL0201_F112_AUDIT_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_UTL0201_F112_AUDIT_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
        fleF112_PYCDCEILINGS_AUDIT.Transaction = m_trnTRANS_UPDATE;
        fleUTLF112_AUDIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_UTL0201_F112_AUDIT_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
            fleF112_PYCDCEILINGS_AUDIT.Dispose();
            fleUTLF112_AUDIT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0201_F112_AUDIT_5)"


    public void Run()
    {

        try
        {
            Request("F112_AUDIT_5");

            while (fleF112_PYCDCEILINGS_AUDIT.QTPForMissing())
            {
                // --> GET F112_PYCDCEILINGS_AUDIT <--

                fleF112_PYCDCEILINGS_AUDIT.GetData();
                // --> End GET F112_PYCDCEILINGS_AUDIT <--


                if (Transaction())
                {



                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTLF112_AUDIT, SubFileType.Keep, ENVIRONMENT, X_DELIMITER, fleF112_PYCDCEILINGS_AUDIT, X_LF);



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
            EndRequest("F112_AUDIT_5");

        }

    }




    #endregion


}
//F112_AUDIT_5



public class Billing_UTL0201_F119_AUDIT_6 : Billing_UTL0201
{

    public Billing_UTL0201_F119_AUDIT_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "F119_DOCTOR_YTD_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleBilling_UTL0201_F119_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "Billing_UTL0201_F119_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0201_F119_AUDIT_6)"

    private SqlFileObject fleF119_DOCTOR_YTD_AUDIT;
    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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



    private SqlFileObject fleBilling_UTL0201_F119_AUDIT;


    #endregion


    #region "Standard Generated Procedures(Billing_UTL0201_F119_AUDIT_6)"


    #region "Automatic Item Initialization(Billing_UTL0201_F119_AUDIT_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_UTL0201_F119_AUDIT_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
        fleF119_DOCTOR_YTD_AUDIT.Transaction = m_trnTRANS_UPDATE;
        fleBilling_UTL0201_F119_AUDIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_UTL0201_F119_AUDIT_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
            fleF119_DOCTOR_YTD_AUDIT.Dispose();
            fleBilling_UTL0201_F119_AUDIT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0201_F119_AUDIT_6)"


    public void Run()
    {

        try
        {
            Request("F119_AUDIT_6");

            while (fleF119_DOCTOR_YTD_AUDIT.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD_AUDIT <--

                fleF119_DOCTOR_YTD_AUDIT.GetData();
                // --> End GET F119_DOCTOR_YTD_AUDIT <--


                if (Transaction())
                {



                    SubFile(ref m_trnTRANS_UPDATE, ref fleBilling_UTL0201_F119_AUDIT, SubFileType.Keep, ENVIRONMENT, X_DELIMITER, fleF119_DOCTOR_YTD_AUDIT, X_LF);



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
            EndRequest("F119_AUDIT_6");

        }

    }




    #endregion


}
//F119_AUDIT_6



public class Billing_UTL0201_F020_7 : Billing_UTL0201
{

    public Billing_UTL0201_F020_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0F020 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F020", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        SYS_MTH.GetValue += SYS_MTH_GetValue;
        TERM_18_MTHS_AGO.GetValue += TERM_18_MTHS_AGO_GetValue;
        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;
        X_DOC_OHIP_NBR.GetValue += X_DOC_OHIP_NBR_GetValue;
        X_DOC_SIN_NBR.GetValue += X_DOC_SIN_NBR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0201_F020_7)"

    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF070_DEPT_MSTR;
    private DDecimal SYS_MTH = new DDecimal("SYS_MTH", 6);
    private void SYS_MTH_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.PHMod((QDesign.SysDate(ref m_cnnQUERY) / 100), 100);


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
    private DDecimal TERM_18_MTHS_AGO = new DDecimal("TERM_18_MTHS_AGO", 8);
    private void TERM_18_MTHS_AGO_GetValue(ref decimal Value)
    {

        try
        {
            Value = 20151231;


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
            if (QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) == 0 | QDesign.NULL(fleF020_DOCTOR_MSTR.GetNumericDateValue("DOC_DATE_FAC_TERM")) > QDesign.NULL(TERM_18_MTHS_AGO.Value))
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

    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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
    private DCharacter X_DOC_OHIP_NBR = new DCharacter("X_DOC_OHIP_NBR", 6);
    private void X_DOC_OHIP_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")), 1, 6);


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
    private DCharacter X_DOC_SIN_NBR = new DCharacter("X_DOC_SIN_NBR", 9);
    private void X_DOC_SIN_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_SIN_NBR")), 1, 9);


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



    private SqlFileObject fleUTL0F020;


    #endregion


    #region "Standard Generated Procedures(Billing_UTL0201_F020_7)"


    #region "Automatic Item Initialization(Billing_UTL0201_F020_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_UTL0201_F020_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F020.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_UTL0201_F020_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
            fleF070_DEPT_MSTR.Dispose();
            fleUTL0F020.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0201_F020_7)"


    public void Run()
    {

        try
        {
            Request("F020_7");

            while (fleF020_DOCTOR_MSTR.QTPForMissing())
            {
                // --> GET F020_DOCTOR_MSTR <--

                fleF020_DOCTOR_MSTR.GetData();
                // --> End GET F020_DOCTOR_MSTR <--

                while (fleF070_DEPT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F070_DEPT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ");
                    m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")));

                    fleF070_DEPT_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F070_DEPT_MSTR <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {



                            SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F020, SubFileType.Keep, ENVIRONMENT, X_DELIMITER, fleF020_DOCTOR_MSTR, "DOC_NBR", "DOC_DEPT", "DOC_NAME", "DOC_INITS",
                            X_DOC_OHIP_NBR, X_DOC_SIN_NBR, "DOC_DATE_FAC_TERM", X_LF);



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
            EndRequest("F020_7");

        }

    }




    #endregion


}
//F020_7



public class Billing_UTL0201_F119_8 : Billing_UTL0201
{

    public Billing_UTL0201_F119_8(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleBilling_UTL0201_F119 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "Billing_UTL0201_F119", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;
        X_PED.GetValue += X_PED_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0201_F119_8)"

    private SqlFileObject fleF119_DOCTOR_YTD;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF119_DOCTOR_YTD.GetStringValue("REC_TYPE")) == "A")
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

    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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
    private DCharacter X_PED = new DCharacter("X_PED", 6);
    private void X_PED_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(QDesign.ASCII(W_CURRENT_EP_NBR.Value), 1, 6);


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



    private SqlFileObject fleBilling_UTL0201_F119;


    #endregion


    #region "Standard Generated Procedures(Billing_UTL0201_F119_8)"


    #region "Automatic Item Initialization(Billing_UTL0201_F119_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_UTL0201_F119_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
        fleF119_DOCTOR_YTD.Transaction = m_trnTRANS_UPDATE;
        fleBilling_UTL0201_F119.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_UTL0201_F119_8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
            fleF119_DOCTOR_YTD.Dispose();
            fleBilling_UTL0201_F119.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0201_F119_8)"


    public void Run()
    {

        try
        {
            Request("F119_8");

            while (fleF119_DOCTOR_YTD.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD <--

                fleF119_DOCTOR_YTD.GetData();
                // --> End GET F119_DOCTOR_YTD <--


                if (Transaction())
                {

                     if (Select_If())
                    {



                        SubFile(ref m_trnTRANS_UPDATE, ref fleBilling_UTL0201_F119, SubFileType.Keep, ENVIRONMENT, X_DELIMITER, fleF119_DOCTOR_YTD, "DOC_NBR", X_PED, "COMP_CODE", "PROCESS_SEQ",
                        "COMP_CODE_GROUP", "REC_TYPE", "AMT_MTD", "AMT_YTD", "LAST_MOD_DATE", "LAST_MOD_TIME", "LAST_MOD_USER_ID", X_LF);



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
            EndRequest("F119_8");

        }

    }




    #endregion


}
//F119_8



public class Billing_UTL0201_F119_HISTORY_9 : Billing_UTL0201
{

    public Billing_UTL0201_F119_HISTORY_9(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF119_DOCTOR_YTD_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F119_DOCTOR_YTD_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleBilling_UTL0201_F119_HISTORY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "Billing_UTL0201_F119_HISTORY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;
        X_BLANK_LAST_MOD_DATE.GetValue += X_BLANK_LAST_MOD_DATE_GetValue;
        X_BLANK_LAST_MOD_TIME.GetValue += X_BLANK_LAST_MOD_TIME_GetValue;
        X_BLANK_LAST_MOD_USER_ID.GetValue += X_BLANK_LAST_MOD_USER_ID_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0201_F119_HISTORY_9)"

    private SqlFileObject fleF119_DOCTOR_YTD_HISTORY;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF119_DOCTOR_YTD_HISTORY.GetStringValue("REC_TYPE")) == "A")
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

    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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
    private DCharacter X_BLANK_LAST_MOD_DATE = new DCharacter("X_BLANK_LAST_MOD_DATE", 8);
    private void X_BLANK_LAST_MOD_DATE_GetValue(ref string Value)
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
    private DCharacter X_BLANK_LAST_MOD_TIME = new DCharacter("X_BLANK_LAST_MOD_TIME", 5);
    private void X_BLANK_LAST_MOD_TIME_GetValue(ref string Value)
    {

        try
        {
            Value = "  ";


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
    private DCharacter X_BLANK_LAST_MOD_USER_ID = new DCharacter("X_BLANK_LAST_MOD_USER_ID", 15);
    private void X_BLANK_LAST_MOD_USER_ID_GetValue(ref string Value)
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



    private SqlFileObject fleBilling_UTL0201_F119_HISTORY;


    #endregion


    #region "Standard Generated Procedures(Billing_UTL0201_F119_HISTORY_9)"


    #region "Automatic Item Initialization(Billing_UTL0201_F119_HISTORY_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_UTL0201_F119_HISTORY_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
        fleF119_DOCTOR_YTD_HISTORY.Transaction = m_trnTRANS_UPDATE;
        fleBilling_UTL0201_F119_HISTORY.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_UTL0201_F119_HISTORY_9)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
            fleF119_DOCTOR_YTD_HISTORY.Dispose();
            fleBilling_UTL0201_F119_HISTORY.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0201_F119_HISTORY_9)"


    public void Run()
    {

        try
        {
            Request("F119_HISTORY_9");

            while (fleF119_DOCTOR_YTD_HISTORY.QTPForMissing())
            {
                // --> GET F119_DOCTOR_YTD_HISTORY <--

                fleF119_DOCTOR_YTD_HISTORY.GetData();
                // --> End GET F119_DOCTOR_YTD_HISTORY <--


                if (Transaction())
                {

                     if (Select_If())
                    {



                        SubFile(ref m_trnTRANS_UPDATE, ref fleBilling_UTL0201_F119_HISTORY, SubFileType.Keep, ENVIRONMENT, X_DELIMITER, fleF119_DOCTOR_YTD_HISTORY, X_BLANK_LAST_MOD_DATE, X_BLANK_LAST_MOD_TIME, X_BLANK_LAST_MOD_USER_ID, X_LF);



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
            EndRequest("F119_HISTORY_9");

        }

    }




    #endregion


}
//F119_HISTORY_9



public class Billing_UTL0201_F191_10 : Billing_UTL0201
{

    public Billing_UTL0201_F191_10(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF191_EARNINGS_PERIOD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F191_EARNINGS_PERIOD", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUTL0F191 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F191", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF191_EARNINGS_PERIOD.Choose += fleF191_EARNINGS_PERIOD_Choose;
        X_NUM_LF.GetValue += X_NUM_LF_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;
        X_ICONST_DATE_PERIOD_END.GetValue += X_ICONST_DATE_PERIOD_END_GetValue;
        X_EP_DATE_START.GetValue += X_EP_DATE_START_GetValue;
        X_EP_DATE_END.GetValue += X_EP_DATE_END_GetValue;
        X_DATE_EFT_DEPOSIT.GetValue += X_DATE_EFT_DEPOSIT_GetValue;
        X_ACCOUNTING_PERIOD_DATE_END.GetValue += X_ACCOUNTING_PERIOD_DATE_END_GetValue;
        X_EP_DATE_CLOSED.GetValue += X_EP_DATE_CLOSED_GetValue;
        X_LAST_MOD_DATE.GetValue += X_LAST_MOD_DATE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(Billing_UTL0201_F191_10)"

    private SqlFileObject fleF191_EARNINGS_PERIOD;

    private void fleF191_EARNINGS_PERIOD_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF191_EARNINGS_PERIOD.ElementOwner("EP_NBR")).Append(" = ");
            strSQL.Append(200701);


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

    private DInteger X_NUM_LF = new DInteger("X_NUM_LF", 4);
    private void X_NUM_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter X_LF = new DCharacter("X_LF", 1);
    private void X_LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Characters(X_NUM_LF.Value);


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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
    private DCharacter X_ICONST_DATE_PERIOD_END = new DCharacter("X_ICONST_DATE_PERIOD_END", 10);
    private void X_ICONST_DATE_PERIOD_END_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("ICONST_DATE_PERIOD_END"), "0008")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("ICONST_DATE_PERIOD_END"), "0005")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("ICONST_DATE_PERIOD_END"), "0002"));


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
    private DCharacter X_EP_DATE_START = new DCharacter("X_EP_DATE_START", 10);
    private void X_EP_DATE_START_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("EP_DATE_START"), "0008")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("EP_DATE_START"), "0005")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("EP_DATE_START"), "0002"));


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
    private DCharacter X_EP_DATE_END = new DCharacter("X_EP_DATE_END", 10);
    private void X_EP_DATE_END_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetDecimalValue("EP_DATE_END"), "0008")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetDecimalValue("EP_DATE_END"), "0005")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetDecimalValue("EP_DATE_END"), "0002"));


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
    private DCharacter X_DATE_EFT_DEPOSIT = new DCharacter("X_DATE_EFT_DEPOSIT", 10);
    private void X_DATE_EFT_DEPOSIT_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("DATE_EFT_DEPOSIT"), "0008")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("DATE_EFT_DEPOSIT"), "0005")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("DATE_EFT_DEPOSIT"), "0002"));


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
    private DCharacter X_ACCOUNTING_PERIOD_DATE_END = new DCharacter("X_ACCOUNTING_PERIOD_DATE_END", 10);
    private void X_ACCOUNTING_PERIOD_DATE_END_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("ACCOUNTING_PERIOD_DATE_END"), "0008")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("ACCOUNTING_PERIOD_DATE_END"), "0005")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("ACCOUNTING_PERIOD_DATE_END"), "0002"));


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
    private DCharacter X_EP_DATE_CLOSED = new DCharacter("X_EP_DATE_CLOSED", 10);
    private void X_EP_DATE_CLOSED_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("EP_DATE_CLOSED"), "0008")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("EP_DATE_CLOSED"), "0005")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("EP_DATE_CLOSED"), "0002"));


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
    private DCharacter X_LAST_MOD_DATE = new DCharacter("X_LAST_MOD_DATE", 10);
    private void X_LAST_MOD_DATE_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("LAST_MOD_DATE"), "0008")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("LAST_MOD_DATE"), "0005")) + "-" + QDesign.ASCII(QDesign.DateExtract(fleF191_EARNINGS_PERIOD.GetNumericDateValue("LAST_MOD_DATE"), "0002"));


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



    private SqlFileObject fleUTL0F191;


    #endregion


    #region "Standard Generated Procedures(Billing_UTL0201_F191_10)"


    #region "Automatic Item Initialization(Billing_UTL0201_F191_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(Billing_UTL0201_F191_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:19 PM

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
        fleF191_EARNINGS_PERIOD.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F191.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(Billing_UTL0201_F191_10)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:20 PM

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
            fleF191_EARNINGS_PERIOD.Dispose();
            fleUTL0F191.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(Billing_UTL0201_F191_10)"


    public void Run()
    {

        try
        {
            Request("F191_10");

            while (fleF191_EARNINGS_PERIOD.QTPForMissing())
            {
                // --> GET F191_EARNINGS_PERIOD <--

                fleF191_EARNINGS_PERIOD.GetData();
                // --> End GET F191_EARNINGS_PERIOD <--


                if (Transaction())
                {



                    SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F191, SubFileType.Keep, ENVIRONMENT, X_DELIMITER, fleF191_EARNINGS_PERIOD, "EP_NBR", X_ICONST_DATE_PERIOD_END, X_EP_DATE_START, X_EP_DATE_END,
                    "EP_QTR_CALENDAR", "EP_QTR_FISCAL", "DATE_EFT_DEPOSIT", "ACCOUNTING_PERIOD_NBR", X_ACCOUNTING_PERIOD_DATE_END, "EP_STATUS", X_EP_DATE_CLOSED, X_LAST_MOD_DATE, "LAST_MOD_TIME", "LAST_MOD_USER_ID",
                    "EP_FISCAL_NBR", "PED_YYYYMM", X_LF);



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
            EndRequest("F191_10");

        }

    }




    #endregion


}
//F191_10




