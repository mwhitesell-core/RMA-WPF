
#region "Screen Comments"

// 2015/Apr/15 MC - original
// combine eligibility rejects & RA rejects by doctor # 
// clone from r134.qzs & r135.qzs  


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class R136 : BaseClassControl
{

    private R136 m_R136;

    public R136(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public R136(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_R136 != null))
        {
            m_R136.CloseTransactionObjects();
            m_R136 = null;
        }
    }

    public R136 GetR136(int Level)
    {
        if (m_R136 == null)
        {
            m_R136 = new R136("R136", Level);
        }
        else
        {
            m_R136.ResetValues();
        }
        return m_R136;
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

            R136_EXTRACT_F087_1 EXTRACT_F087_1 = new R136_EXTRACT_F087_1(Name, Level);
            EXTRACT_F087_1.Run();
            EXTRACT_F087_1.Dispose();
            EXTRACT_F087_1 = null;

            R136_EXTRACT_F088_2 EXTRACT_F088_2 = new R136_EXTRACT_F088_2(Name, Level);
            EXTRACT_F088_2.Run();
            EXTRACT_F088_2.Dispose();
            EXTRACT_F088_2 = null;

            R136_COMBINE_3 COMBINE_3 = new R136_COMBINE_3(Name, Level);
            COMBINE_3.Run();
            COMBINE_3.Dispose();
            COMBINE_3 = null;

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



public class R136_EXTRACT_F087_1 : R136
{

    public R136_EXTRACT_F087_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR134 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R134", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        F087_REJECT = new CoreDecimal("F087_REJECT", 6, this);
        fleR136 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R136", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        F088_REJECT.GetValue += F088_REJECT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(R136_EXTRACT_F087_1)"

    private SqlFileObject fleR134;
    private CoreDecimal F087_REJECT;
    private DDecimal F088_REJECT = new DDecimal("F088_REJECT", 6);
    private void F088_REJECT_GetValue(ref decimal Value)
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
    private SqlFileObject fleR136;


    #endregion


    #region "Standard Generated Procedures(R136_EXTRACT_F087_1)"


    #region "Automatic Item Initialization(R136_EXTRACT_F087_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R136_EXTRACT_F087_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:46 PM

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
        fleR134.Transaction = m_trnTRANS_UPDATE;
        fleR136.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R136_EXTRACT_F087_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:46 PM

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
            fleR134.Dispose();
            fleR136.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R136_EXTRACT_F087_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_F087_1");

            while (fleR134.QTPForMissing())
            {
                // --> GET R134 <--

                fleR134.GetData();
                // --> End GET R134 <--


                if (Transaction())
                {

                    Sort(fleR134.GetSortValue("CLMHDR_DOC_NBR"), fleR134.GetSortValue("SUBMITTED_REJECTED_CLAIM"));



                }

            }

            while (Sort(fleR134))
            {
                if (fleR134.At("CLMHDR_DOC_NBR") || fleR134.At("SUBMITTED_REJECTED_CLAIM"))
                {
                    F087_REJECT.Value = F087_REJECT.Value + 1;
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleR136, fleR134.At("CLMHDR_DOC_NBR"), SubFileType.Keep, fleR134, "DOC_DEPT", "CLMHDR_DOC_NBR", "DOC_NAME", F087_REJECT, F088_REJECT);


                Reset(ref F087_REJECT, fleR134.At("CLMHDR_DOC_NBR"));

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
            EndRequest("EXTRACT_F087_1");

        }

    }







    #endregion


}
//EXTRACT_F087_1



public class R136_EXTRACT_F088_2 : R136
{

    public R136_EXTRACT_F088_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR135 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R135", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        F088_REJECT = new CoreDecimal("F088_REJECT", 6, this);
        fleR136 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R136", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        F087_REJECT.GetValue += F087_REJECT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(R136_EXTRACT_F088_2)"

    private SqlFileObject fleR135;
    private DDecimal F087_REJECT = new DDecimal("F087_REJECT", 6);
    private void F087_REJECT_GetValue(ref decimal Value)
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
    private CoreDecimal F088_REJECT;
    private SqlFileObject fleR136;


    #endregion


    #region "Standard Generated Procedures(R136_EXTRACT_F088_2)"


    #region "Automatic Item Initialization(R136_EXTRACT_F088_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R136_EXTRACT_F088_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:46 PM

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
        fleR135.Transaction = m_trnTRANS_UPDATE;
        fleR136.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R136_EXTRACT_F088_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:46 PM

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
            fleR135.Dispose();
            fleR136.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R136_EXTRACT_F088_2)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_F088_2");

            while (fleR135.QTPForMissing())
            {
                // --> GET R135 <--

                fleR135.GetData();
                // --> End GET R135 <--


                if (Transaction())
                {

                    Sort(fleR135.GetSortValue("CLMHDR_DOC_NBR"), fleR135.GetSortValue("RAT_REJECTED_CLAIM"));



                }

            }

            while (Sort(fleR135))
            {
                if (fleR135.At("CLMHDR_DOC_NBR") || fleR135.At("RAT_REJECTED_CLAIM"))
                {
                    F088_REJECT.Value = F088_REJECT.Value + 1;
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleR136, fleR135.At("CLMHDR_DOC_NBR"), SubFileType.Keep, fleR135, "DOC_DEPT", "CLMHDR_DOC_NBR", "DOC_NAME", F087_REJECT, F088_REJECT);


                Reset(ref F088_REJECT, fleR135.At("CLMHDR_DOC_NBR"));

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
            EndRequest("EXTRACT_F088_2");

        }

    }







    #endregion


}
//EXTRACT_F088_2



public class R136_COMBINE_3 : R136
{

    public R136_COMBINE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR136 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R136", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        ELIG_REJECT = new CoreDecimal("ELIG_REJECT", 6, this);
        RA_REJECT = new CoreDecimal("RA_REJECT", 6, this);
        TOTAL_REJECT = new CoreDecimal("TOTAL_REJECT", 6, this);
        fleR136_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R136_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(R136_COMBINE_3)"

    private SqlFileObject fleR136;
    private CoreDecimal ELIG_REJECT;
    private CoreDecimal RA_REJECT;
    private CoreDecimal TOTAL_REJECT;
    private SqlFileObject fleR136_DOC;


    #endregion


    #region "Standard Generated Procedures(R136_COMBINE_3)"


    #region "Automatic Item Initialization(R136_COMBINE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(R136_COMBINE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:46 PM

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
        fleR136.Transaction = m_trnTRANS_UPDATE;
        fleR136_DOC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(R136_COMBINE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:03:46 PM

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
            fleR136.Dispose();
            fleR136_DOC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(R136_COMBINE_3)"


    public void Run()
    {

        try
        {
            Request("COMBINE_3");

            while (fleR136.QTPForMissing())
            {
                // --> GET R136 <--

                fleR136.GetData();
                // --> End GET R136 <--


                if (Transaction())
                {

                    Sort(fleR136.GetSortValue("CLMHDR_DOC_NBR"));



                }

            }

            while (Sort(fleR136))
            {
                ELIG_REJECT.Value = ELIG_REJECT.Value + fleR136.GetDecimalValue("F087_REJECT");
                RA_REJECT.Value = RA_REJECT.Value + fleR136.GetDecimalValue("F088_REJECT");
                TOTAL_REJECT.Value = TOTAL_REJECT.Value + fleR136.GetDecimalValue("F087_REJECT") + fleR136.GetDecimalValue("F088_REJECT");

                SubFile(ref m_trnTRANS_UPDATE, ref fleR136_DOC, fleR136.At("CLMHDR_DOC_NBR"), SubFileType.Keep, fleR136, "DOC_DEPT", "CLMHDR_DOC_NBR", "DOC_NAME", ELIG_REJECT, RA_REJECT,
                TOTAL_REJECT);


                Reset(ref ELIG_REJECT, fleR136.At("CLMHDR_DOC_NBR"));
                Reset(ref RA_REJECT, fleR136.At("CLMHDR_DOC_NBR"));
                Reset(ref TOTAL_REJECT, fleR136.At("CLMHDR_DOC_NBR"));

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
            EndRequest("COMBINE_3");

        }

    }







    #endregion


}
//COMBINE_3




