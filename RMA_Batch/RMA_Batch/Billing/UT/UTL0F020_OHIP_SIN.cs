
#region "Screen Comments"

// 2015/Mar/03 MC - UTL0F020_OHIP_SIN.qts
// - determine for different OHIP & SIN nbr for doctors in different environments


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UTL0F020_OHIP_SIN : BaseClassControl
{

    private UTL0F020_OHIP_SIN m_UTL0F020_OHIP_SIN;

    public UTL0F020_OHIP_SIN(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UTL0F020_OHIP_SIN(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UTL0F020_OHIP_SIN != null))
        {
            m_UTL0F020_OHIP_SIN.CloseTransactionObjects();
            m_UTL0F020_OHIP_SIN = null;
        }
    }

    public UTL0F020_OHIP_SIN GetUTL0F020_OHIP_SIN(int Level)
    {
        if (m_UTL0F020_OHIP_SIN == null)
        {
            m_UTL0F020_OHIP_SIN = new UTL0F020_OHIP_SIN("UTL0F020_OHIP_SIN", Level);
        }
        else
        {
            m_UTL0F020_OHIP_SIN.ResetValues();
        }
        return m_UTL0F020_OHIP_SIN;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.


    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            UTL0F020_OHIP_SIN_ONE_1 ONE_1 = new UTL0F020_OHIP_SIN_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            UTL0F020_OHIP_SIN_TWO_2 TWO_2 = new UTL0F020_OHIP_SIN_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            UTL0F020_OHIP_SIN_THREE_3 THREE_3 = new UTL0F020_OHIP_SIN_THREE_3(Name, Level);
            THREE_3.Run();
            THREE_3.Dispose();
            THREE_3 = null;

            UTL0F020_OHIP_SIN_FOUR_4 FOUR_4 = new UTL0F020_OHIP_SIN_FOUR_4(Name, Level);
            FOUR_4.Run();
            FOUR_4.Dispose();
            FOUR_4 = null;

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



public class UTL0F020_OHIP_SIN_ONE_1 : UTL0F020_OHIP_SIN
{

    public UTL0F020_OHIP_SIN_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleUTL0F020_A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F020_ALL_A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.PortableSubFile);
        XCOUNT = new CoreDecimal("XCOUNT", 6, this);
        fleUTL0F020_COUNT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F020_COUNT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(UTL0F020_OHIP_SIN_ONE_1)"

    private SqlFileObject fleUTL0F020_A;
    private CoreDecimal XCOUNT;
    private SqlFileObject fleUTL0F020_COUNT;


    #endregion


    #region "Standard Generated Procedures(UTL0F020_OHIP_SIN_ONE_1)"


    #region "Automatic Item Initialization(UTL0F020_OHIP_SIN_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0F020_OHIP_SIN_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:14 PM

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
        fleUTL0F020_A.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F020_COUNT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0F020_OHIP_SIN_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:14 PM

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
            fleUTL0F020_A.Dispose();
            fleUTL0F020_COUNT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0F020_OHIP_SIN_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleUTL0F020_A.QTPForMissing())
            {
                // --> GET UTL0F020_A <--

                fleUTL0F020_A.GetData();
                // --> End GET UTL0F020_A <--


                if (Transaction())
                {

                    Sort(fleUTL0F020_A.GetSortValue("DOC_NBR"), fleUTL0F020_A.GetSortValue("DOC_DEPT"), fleUTL0F020_A.GetSortValue("DOC_NAME"));



                }

            }

            while (Sort(fleUTL0F020_A))
            {
                XCOUNT.Value = XCOUNT.Value + 1;

                SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F020_COUNT, SubFileType.Keep, fleUTL0F020_A, XCOUNT);


                Reset(ref XCOUNT, fleUTL0F020_A.At("DOC_NBR") || fleUTL0F020_A.At("DOC_DEPT") || fleUTL0F020_A.At("DOC_NAME"));

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
            EndRequest("ONE_1");

        }

    }







    #endregion


}
//ONE_1



public class UTL0F020_OHIP_SIN_TWO_2 : UTL0F020_OHIP_SIN
{

    public UTL0F020_OHIP_SIN_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleUTL0F020_COUNT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F020_COUNT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleUTL0F020_OHIP_SIN = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F020_OHIP_SIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        KEY1.GetValue += KEY1_GetValue;
        KEY2.GetValue += KEY2_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0F020_OHIP_SIN_TWO_2)"

    private SqlFileObject fleUTL0F020_COUNT;
    private DCharacter KEY1 = new DCharacter("KEY1", 40);
    private void KEY1_GetValue(ref string Value)
    {

        try
        {
            Value = fleUTL0F020_COUNT.GetStringValue("DOC_NBR") + QDesign.ASCII(fleUTL0F020_COUNT.GetDecimalValue("DOC_DEPT"), 2) + fleUTL0F020_COUNT.GetStringValue("DOC_NAME");


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
    private DCharacter KEY2 = new DCharacter("KEY2", 15);
    private void KEY2_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(fleUTL0F020_COUNT.GetDecimalValue("DOC_OHIP_NBR"), 6) + QDesign.ASCII(fleUTL0F020_COUNT.GetDecimalValue("DOC_SIN_123"), 3) + QDesign.ASCII(fleUTL0F020_COUNT.GetDecimalValue("DOC_SIN_456"), 3) + QDesign.ASCII(fleUTL0F020_COUNT.GetDecimalValue("DOC_SIN_789"), 3);


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
    private SqlFileObject fleUTL0F020_OHIP_SIN;


    #endregion


    #region "Standard Generated Procedures(UTL0F020_OHIP_SIN_TWO_2)"


    #region "Automatic Item Initialization(UTL0F020_OHIP_SIN_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0F020_OHIP_SIN_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:14 PM

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
        fleUTL0F020_COUNT.Transaction = m_trnTRANS_UPDATE;
        fleUTL0F020_OHIP_SIN.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0F020_OHIP_SIN_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:14 PM

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
            fleUTL0F020_COUNT.Dispose();
            fleUTL0F020_OHIP_SIN.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0F020_OHIP_SIN_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleUTL0F020_COUNT.QTPForMissing())
            {
                // --> GET UTL0F020_COUNT <--

                fleUTL0F020_COUNT.GetData();
                // --> End GET UTL0F020_COUNT <--


                if (Transaction())
                {

                    Sort(KEY1.Value, KEY2.Value);



                }

            }

            while (Sort(fleUTL0F020_COUNT))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleUTL0F020_OHIP_SIN, SubFileType.Keep, fleUTL0F020_COUNT);


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
            EndRequest("TWO_2");

        }

    }







    #endregion


}
//TWO_2



public class UTL0F020_OHIP_SIN_THREE_3 : UTL0F020_OHIP_SIN
{

    public UTL0F020_OHIP_SIN_THREE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleUTL0F020_OHIP_SIN = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UTL0F020_OHIP_SIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_OHIP_SIN = new CoreDecimal("X_OHIP_SIN", 1, this);
        fleF020_OHIP_SIN = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F020_OHIP_SIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        KEY1.GetValue += KEY1_GetValue;
        KEY2.GetValue += KEY2_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0F020_OHIP_SIN_THREE_3)"

    private SqlFileObject fleUTL0F020_OHIP_SIN;
    private DCharacter KEY1 = new DCharacter("KEY1", 40);
    private void KEY1_GetValue(ref string Value)
    {

        try
        {
            Value = fleUTL0F020_OHIP_SIN.GetStringValue("DOC_NBR") + QDesign.ASCII(fleUTL0F020_OHIP_SIN.GetDecimalValue("DOC_DEPT"), 2) + fleUTL0F020_OHIP_SIN.GetStringValue("DOC_NAME");


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
    private DCharacter KEY2 = new DCharacter("KEY2", 15);
    private void KEY2_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(fleUTL0F020_OHIP_SIN.GetDecimalValue("DOC_OHIP_NBR"), 6) + QDesign.ASCII(fleUTL0F020_OHIP_SIN.GetDecimalValue("DOC_SIN_123"), 3) + QDesign.ASCII(fleUTL0F020_OHIP_SIN.GetDecimalValue("DOC_SIN_456"), 3) + QDesign.ASCII(fleUTL0F020_OHIP_SIN.GetDecimalValue("DOC_SIN_789"), 3);


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
    private CoreDecimal X_OHIP_SIN;
    private SqlFileObject fleF020_OHIP_SIN;


    #endregion


    #region "Standard Generated Procedures(UTL0F020_OHIP_SIN_THREE_3)"


    #region "Automatic Item Initialization(UTL0F020_OHIP_SIN_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0F020_OHIP_SIN_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:14 PM

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
        fleUTL0F020_OHIP_SIN.Transaction = m_trnTRANS_UPDATE;
        fleF020_OHIP_SIN.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0F020_OHIP_SIN_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:14 PM

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
            fleUTL0F020_OHIP_SIN.Dispose();
            fleF020_OHIP_SIN.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0F020_OHIP_SIN_THREE_3)"


    public void Run()
    {

        try
        {
            Request("THREE_3");

            while (fleUTL0F020_OHIP_SIN.QTPForMissing())
            {
                // --> GET UTL0F020_OHIP_SIN <--

                fleUTL0F020_OHIP_SIN.GetData();
                // --> End GET UTL0F020_OHIP_SIN <--


                if (Transaction())
                {

                    Sort(KEY1.Value, KEY2.Value, fleUTL0F020_OHIP_SIN.GetSortValue("XCOUNT"));



                }

            }

            while (Sort(fleUTL0F020_OHIP_SIN))
            {
                if (At(KEY1) || At(KEY2))
                {
                    X_OHIP_SIN.Value = X_OHIP_SIN.Value + 1;
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleF020_OHIP_SIN, At(KEY1), SubFileType.Keep, X_OHIP_SIN, fleUTL0F020_OHIP_SIN);


                Reset(ref X_OHIP_SIN, At(KEY1));

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
            EndRequest("THREE_3");

        }

    }







    #endregion


}
//THREE_3



public class UTL0F020_OHIP_SIN_FOUR_4 : UTL0F020_OHIP_SIN
{

    public UTL0F020_OHIP_SIN_FOUR_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF020_OHIP_SIN = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F020_OHIP_SIN", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_COUNTERS_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_COUNTERS_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleTMP_COUNTERS_ALPHA.SetItemFinals += fleTMP_COUNTERS_ALPHA_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(UTL0F020_OHIP_SIN_FOUR_4)"

    private SqlFileObject fleF020_OHIP_SIN;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF020_OHIP_SIN.GetDecimalValue("X_OHIP_SIN")) != 1)
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

    private SqlFileObject fleTMP_COUNTERS_ALPHA;

    private void fleTMP_COUNTERS_ALPHA_SetItemFinals()
    {

        try
        {
            fleTMP_COUNTERS_ALPHA.set_SetValue("TMP_COUNTER_KEY_ALPHA", fleF020_OHIP_SIN.GetStringValue("DOC_NBR") + QDesign.ASCII(fleF020_OHIP_SIN.GetDecimalValue("DOC_DEPT"), 2) + fleF020_OHIP_SIN.GetStringValue("DOC_NAME"));


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


    #region "Standard Generated Procedures(UTL0F020_OHIP_SIN_FOUR_4)"


    #region "Automatic Item Initialization(UTL0F020_OHIP_SIN_FOUR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UTL0F020_OHIP_SIN_FOUR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:14 PM

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
        fleF020_OHIP_SIN.Transaction = m_trnTRANS_UPDATE;
        fleTMP_COUNTERS_ALPHA.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UTL0F020_OHIP_SIN_FOUR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:14 PM

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
            fleF020_OHIP_SIN.Dispose();
            fleTMP_COUNTERS_ALPHA.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UTL0F020_OHIP_SIN_FOUR_4)"


    public void Run()
    {

        try
        {
            Request("FOUR_4");

            while (fleF020_OHIP_SIN.QTPForMissing())
            {
                // --> GET F020_OHIP_SIN <--

                fleF020_OHIP_SIN.GetData();
                // --> End GET F020_OHIP_SIN <--

                if (Transaction())
                {

                     if (Select_If())
                    {
                        fleTMP_COUNTERS_ALPHA.OutPut(OutPutType.Add);

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
            EndRequest("FOUR_4");

        }

    }







    #endregion


}
//FOUR_4




