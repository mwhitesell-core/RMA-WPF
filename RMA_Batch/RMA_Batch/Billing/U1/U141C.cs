
#region "Screen Comments"

// #> PROGRAM-ID.     u141c.qts
// ((C)) Dyad Infosys LTD   
// PURPOSE:   Create miscellaneous payment  batches/claims from a `text` file.
// Third pass to create the data from u141a_valid subfile which is created from u141a.qts
// MODIFICATION HISTORY
// DATE     WHO     DESCRIPTION
// 2015/Nov/10 MC      - original   (clone from u030b_part3_a/b.qts)
// 2016/Mar/28 MC1     - modify to update next batch nbr properly; Yasemin agrees to change from W01 to WW0
// for next payment batch nbr and reserve for WW0 to WW2 so that there are 3000 batches
// allowed before rest (WW0000 to WW2999)
// 2016/Jul/05 MC2     - do not need to check with x-check-amt (highest amt)
// 2016/Jul/20 MC3     - change x-batch-amount from size 7 to 9
// -------------------------------------------------------------------------------


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U141C : BaseClassControl
{

    private U141C m_U141C;

    public U141C(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U141C(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U141C != null))
        {
            m_U141C.CloseTransactionObjects();
            m_U141C = null;
        }
    }

    public U141C GetU141C(int Level)
    {
        if (m_U141C == null)
        {
            m_U141C = new U141C("U141C", Level);
        }
        else
        {
            m_U141C.ResetValues();
        }
        return m_U141C;
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

            U141C_CALCULATE_RUNNING_AMT_1 CALCULATE_RUNNING_AMT_1 = new U141C_CALCULATE_RUNNING_AMT_1(Name, Level);
            CALCULATE_RUNNING_AMT_1.Run();
            CALCULATE_RUNNING_AMT_1.Dispose();
            CALCULATE_RUNNING_AMT_1 = null;

            U141C_DETERMINE_HIGHEST_AMT_2 DETERMINE_HIGHEST_AMT_2 = new U141C_DETERMINE_HIGHEST_AMT_2(Name, Level);
            DETERMINE_HIGHEST_AMT_2.Run();
            DETERMINE_HIGHEST_AMT_2.Dispose();
            DETERMINE_HIGHEST_AMT_2 = null;

            U141C_CALCULATE_BATCH_NBR_3 CALCULATE_BATCH_NBR_3 = new U141C_CALCULATE_BATCH_NBR_3(Name, Level);
            CALCULATE_BATCH_NBR_3.Run();
            CALCULATE_BATCH_NBR_3.Dispose();
            CALCULATE_BATCH_NBR_3 = null;

            U141C_U141_GEN_BATCH_NBRS_4 U141_GEN_BATCH_NBRS_4 = new U141C_U141_GEN_BATCH_NBRS_4(Name, Level);
            U141_GEN_BATCH_NBRS_4.Run();
            U141_GEN_BATCH_NBRS_4.Dispose();
            U141_GEN_BATCH_NBRS_4 = null;

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



public class U141C_CALCULATE_RUNNING_AMT_1 : U141C
{

    public U141C_CALCULATE_RUNNING_AMT_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU141A_VALID = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141A_VALID", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_AMT = new CoreDecimal("X_AMT", 9, this);
        fleU141C_RUNNING_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141C_RUNNING_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U141C_CALCULATE_RUNNING_AMT_1)"

    private SqlFileObject fleU141A_VALID;

    private CoreDecimal X_AMT;






    private SqlFileObject fleU141C_RUNNING_AMT;


    #endregion


    #region "Standard Generated Procedures(U141C_CALCULATE_RUNNING_AMT_1)"


    #region "Automatic Item Initialization(U141C_CALCULATE_RUNNING_AMT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U141C_CALCULATE_RUNNING_AMT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:09:45 PM

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
        fleU141A_VALID.Transaction = m_trnTRANS_UPDATE;
        fleU141C_RUNNING_AMT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U141C_CALCULATE_RUNNING_AMT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:09:45 PM

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
            fleU141A_VALID.Dispose();
            fleU141C_RUNNING_AMT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U141C_CALCULATE_RUNNING_AMT_1)"


    public void Run()
    {

        try
        {
            Request("CALCULATE_RUNNING_AMT_1");

            while (fleU141A_VALID.QTPForMissing())
            {
                // --> GET U141A_VALID <--

                fleU141A_VALID.GetData();
                // --> End GET U141A_VALID <--


                if (Transaction())
                {

                    Sort(fleU141A_VALID.GetSortValue("CLINIC_NBR"), fleU141A_VALID.GetSortValue("HDR_AGENT_CD"));



                }

            }

            while (Sort(fleU141A_VALID))
            {
                X_AMT.Value = X_AMT.Value + fleU141A_VALID.GetDecimalValue("SIGNED_AMT_NET");








                SubFile(ref m_trnTRANS_UPDATE, ref fleU141C_RUNNING_AMT, SubFileType.Keep, X_AMT, fleU141A_VALID);



                Reset(ref X_AMT, fleU141A_VALID.At("CLINIC_NBR") || fleU141A_VALID.At("HDR_AGENT_CD"));

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
            EndRequest("CALCULATE_RUNNING_AMT_1");

        }

    }




    #endregion


}
//CALCULATE_RUNNING_AMT_1



public class U141C_DETERMINE_HIGHEST_AMT_2 : U141C
{

    public U141C_DETERMINE_HIGHEST_AMT_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU141A_VALID = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141A_VALID", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU141C_HIGHEST_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141C_HIGHEST_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_ABS_AMT.GetValue += X_ABS_AMT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U141C_DETERMINE_HIGHEST_AMT_2)"

    private SqlFileObject fleU141A_VALID;
    private DDecimal X_ABS_AMT = new DDecimal("X_ABS_AMT", 7);
    private void X_ABS_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = Math.Abs(fleU141A_VALID.GetDecimalValue("SIGNED_AMT_NET"));


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







    private SqlFileObject fleU141C_HIGHEST_AMT;


    #endregion


    #region "Standard Generated Procedures(U141C_DETERMINE_HIGHEST_AMT_2)"


    #region "Automatic Item Initialization(U141C_DETERMINE_HIGHEST_AMT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U141C_DETERMINE_HIGHEST_AMT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:09:45 PM

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
        fleU141A_VALID.Transaction = m_trnTRANS_UPDATE;
        fleU141C_HIGHEST_AMT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U141C_DETERMINE_HIGHEST_AMT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:09:45 PM

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
            fleU141A_VALID.Dispose();
            fleU141C_HIGHEST_AMT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U141C_DETERMINE_HIGHEST_AMT_2)"


    public void Run()
    {

        try
        {
            Request("DETERMINE_HIGHEST_AMT_2");

            while (fleU141A_VALID.QTPForMissing())
            {
                // --> GET U141A_VALID <--

                fleU141A_VALID.GetData();
                // --> End GET U141A_VALID <--


                if (Transaction())
                {

                    Sort(X_ABS_AMT.Value);


                }

            }


            while (Sort(fleU141A_VALID))
            {






                SubFile(ref m_trnTRANS_UPDATE, ref fleU141C_HIGHEST_AMT, AtFinal(), SubFileType.Keep, X_ABS_AMT, fleU141A_VALID);



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
            EndRequest("DETERMINE_HIGHEST_AMT_2");

        }

    }




    #endregion


}
//DETERMINE_HIGHEST_AMT_2



public class U141C_CALCULATE_BATCH_NBR_3 : U141C
{

    public U141C_CALCULATE_BATCH_NBR_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU141C_RUNNING_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141C_RUNNING_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU141C_HIGHEST_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141C_HIGHEST_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_BATCH_COUNT_BEFORE = new CoreDecimal("X_BATCH_COUNT_BEFORE", 6, this);
        X_BATCH_COUNT_AFTER = new CoreDecimal("X_BATCH_COUNT_AFTER", 6, this);
        X_COUNT = new CoreDecimal("X_COUNT", 6, this);
        X_CLAIM_COUNT = new CoreDecimal("X_CLAIM_COUNT", 6, this);
        X_BATCH_COUNT = new CoreDecimal("X_BATCH_COUNT", 6, this);
        X_BATCH_AMOUNT = new CoreDecimal("X_BATCH_AMOUNT", 9, this);
        X_AGENT_BEFORE = new CoreCharacter("X_AGENT_BEFORE", 1, this, Common.cEmptyString);
        X_AGENT_AFTER = new CoreCharacter("X_AGENT_AFTER", 1, this, Common.cEmptyString);
        CHANGE_BATCH_FLAG = new CoreCharacter("CHANGE_BATCH_FLAG", 1, this, Common.cEmptyString);
        fleU141C_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141C_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU141C_DEBUG_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141C_DEBUG_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_CHECK_AMT.GetValue += X_CHECK_AMT_GetValue;
        X_ABS_BATCH_AMT.GetValue += X_ABS_BATCH_AMT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U141C_CALCULATE_BATCH_NBR_3)"

    private SqlFileObject fleU141C_RUNNING_AMT;







    private SqlFileObject fleU141C_HIGHEST_AMT;
    private DDecimal X_CHECK_AMT = new DDecimal("X_CHECK_AMT", 7);
    private void X_CHECK_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 9000000)
            {
                CurrentValue = 500000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 8500000)
            {
                CurrentValue = 1000000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 8000000)
            {
                CurrentValue = 1500000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 7500000)
            {
                CurrentValue = 2000000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 7000000)
            {
                CurrentValue = 2500000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 6500000)
            {
                CurrentValue = 3000000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 6000000)
            {
                CurrentValue = 3500000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 5500000)
            {
                CurrentValue = 4000000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 5000000)
            {
                CurrentValue = 4500000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 4500000)
            {
                CurrentValue = 5000000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 4000000)
            {
                CurrentValue = 5500000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 3500000)
            {
                CurrentValue = 6000000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 3000000)
            {
                CurrentValue = 6500000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 2500000)
            {
                CurrentValue = 7000000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 2000000)
            {
                CurrentValue = 7500000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 1500000)
            {
                CurrentValue = 8000000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 1000000)
            {
                CurrentValue = 8500000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 500000)
            {
                CurrentValue = 9000000;
            }
            else if (QDesign.NULL(fleU141C_HIGHEST_AMT.GetDecimalValue("X_ABS_AMT")) > 0)
            {
                CurrentValue = 9500000;
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
    private CoreDecimal X_BATCH_COUNT_BEFORE;
    private CoreDecimal X_BATCH_COUNT_AFTER;
    private CoreDecimal X_COUNT;
    private CoreDecimal X_CLAIM_COUNT;
    private CoreDecimal X_BATCH_COUNT;
    private CoreDecimal X_BATCH_AMOUNT;
    private CoreCharacter X_AGENT_BEFORE;
    private CoreCharacter X_AGENT_AFTER;
    private CoreCharacter CHANGE_BATCH_FLAG;
    private DDecimal X_ABS_BATCH_AMT = new DDecimal("X_ABS_BATCH_AMT", 6);
    private void X_ABS_BATCH_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = Math.Abs(X_BATCH_AMOUNT.Value);


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







    private SqlFileObject fleU141C_BATCH_NBR;







    private SqlFileObject fleU141C_DEBUG_BATCH_NBR;


    #endregion


    #region "Standard Generated Procedures(U141C_CALCULATE_BATCH_NBR_3)"


    #region "Automatic Item Initialization(U141C_CALCULATE_BATCH_NBR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U141C_CALCULATE_BATCH_NBR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:09:45 PM

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
        fleU141C_RUNNING_AMT.Transaction = m_trnTRANS_UPDATE;
        fleU141C_HIGHEST_AMT.Transaction = m_trnTRANS_UPDATE;
        fleU141C_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
        fleU141C_DEBUG_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U141C_CALCULATE_BATCH_NBR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:09:45 PM

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
            fleU141C_RUNNING_AMT.Dispose();
            fleU141C_HIGHEST_AMT.Dispose();
            fleU141C_BATCH_NBR.Dispose();
            fleU141C_DEBUG_BATCH_NBR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U141C_CALCULATE_BATCH_NBR_3)"


    public void Run()
    {

        try
        {
            Request("CALCULATE_BATCH_NBR_3");

            while (fleU141C_RUNNING_AMT.QTPForMissing())
            {
                // --> GET U141C_RUNNING_AMT <--

                fleU141C_RUNNING_AMT.GetData();
                // --> End GET U141C_RUNNING_AMT <--

                while (fleU141C_HIGHEST_AMT.QTPForMissing("1"))
                {
                    // --> GET U141C_HIGHEST_AMT <--
                    //m_strWhere = new StringBuilder(" WHERE ");
                    //m_strWhere.Append(fleU141C_HIGHEST_AMT.ElementOwner("CORE_RECORD_NUMBER")).Append(" = ");
                    //m_strWhere.Append((0));

                    //fleU141C_HIGHEST_AMT.GetData(m_strWhere.ToString());
                    fleU141C_HIGHEST_AMT.GetData();
                    // --> End GET U141C_HIGHEST_AMT <--


                    if (Transaction())
                    {

                        Sort(fleU141C_RUNNING_AMT.GetSortValue("CLINIC_NBR"), fleU141C_RUNNING_AMT.GetSortValue("HDR_AGENT_CD"));



                    }

                }

            }

            while (Sort(fleU141C_RUNNING_AMT, fleU141C_HIGHEST_AMT))
            {
                X_BATCH_COUNT_BEFORE.Value = X_BATCH_COUNT.Value;
                X_AGENT_BEFORE.Value = X_AGENT_AFTER.Value;
                if (QDesign.NULL(X_CLAIM_COUNT.Value) < 99 & QDesign.NULL(X_BATCH_COUNT.Value) != 0 & QDesign.NULL(fleU141C_RUNNING_AMT.GetStringValue("HDR_AGENT_CD")) == QDesign.NULL(X_AGENT_BEFORE.Value))
                {
                    CHANGE_BATCH_FLAG.Value = "N";
                }
                else
                {
                    CHANGE_BATCH_FLAG.Value = "Y";
                }
                if (QDesign.NULL(CHANGE_BATCH_FLAG.Value) == "N")
                {
                    X_BATCH_AMOUNT.Value = X_BATCH_AMOUNT.Value + fleU141C_RUNNING_AMT.GetDecimalValue("SIGNED_AMT_NET");
                }
                else
                {
                    X_BATCH_AMOUNT.Value = fleU141C_RUNNING_AMT.GetDecimalValue("SIGNED_AMT_NET");
                }
                if (QDesign.NULL(CHANGE_BATCH_FLAG.Value) == "N")
                {
                    X_CLAIM_COUNT.Value = X_CLAIM_COUNT.Value + 1;
                }
                else
                {
                    X_CLAIM_COUNT.Value = 1;
                }
                if (QDesign.NULL(CHANGE_BATCH_FLAG.Value) == "Y")
                {
                    X_BATCH_COUNT.Value = X_BATCH_COUNT.Value + 1;
                }
                else
                {
                    X_BATCH_COUNT.Value = X_BATCH_COUNT_BEFORE.Value;
                }
                Count(ref X_COUNT);
                X_BATCH_COUNT_AFTER.Value = X_BATCH_COUNT.Value;
                X_AGENT_AFTER.Value = fleU141C_RUNNING_AMT.GetStringValue("HDR_AGENT_CD");








                SubFile(ref m_trnTRANS_UPDATE, ref fleU141C_BATCH_NBR, SubFileType.Keep, X_COUNT, X_BATCH_COUNT, X_CLAIM_COUNT, fleU141C_RUNNING_AMT);









                SubFile(ref m_trnTRANS_UPDATE, ref fleU141C_DEBUG_BATCH_NBR, SubFileType.Keep, X_COUNT, X_BATCH_COUNT_BEFORE, X_BATCH_COUNT, X_CLAIM_COUNT, X_BATCH_AMOUNT, X_BATCH_COUNT_AFTER, CHANGE_BATCH_FLAG,
                X_AGENT_BEFORE, X_AGENT_AFTER, fleU141C_RUNNING_AMT);



                Reset(ref X_BATCH_AMOUNT, fleU141C_RUNNING_AMT.At("CLINIC_NBR") || fleU141C_RUNNING_AMT.At("HDR_AGENT_CD"));
                Reset(ref X_BATCH_COUNT, fleU141C_RUNNING_AMT.At("CLINIC_NBR"));
                Reset(ref X_COUNT, fleU141C_RUNNING_AMT.At("CLINIC_NBR") || fleU141C_RUNNING_AMT.At("HDR_AGENT_CD"));

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
            EndRequest("CALCULATE_BATCH_NBR_3");

        }

    }




    #endregion


}
//CALCULATE_BATCH_NBR_3



public class U141C_U141_GEN_BATCH_NBRS_4 : U141C
{

    public U141C_U141_GEN_BATCH_NBRS_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU141C_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141C_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_BATCH_NBR = new CoreDecimal("X_BATCH_NBR", 4, this);
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "F002_HDR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "F002_DTL", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU141C_PAY_BATCHES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141C_PAY_BATCHES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        BATCTRL_MANUAL_PAY_TOT = new CoreDecimal("BATCTRL_MANUAL_PAY_TOT", 9, this);

        fleICONST_MSTR_REC.SetItemFinals += fleICONST_MSTR_REC_SetItemFinals;
        X_PAY_BATCH_NBR.GetValue += X_PAY_BATCH_NBR_GetValue;
        X_CLINIC_BATCH_NBR.GetValue += X_CLINIC_BATCH_NBR_GetValue;
        X_CLAIM_NBR.GetValue += X_CLAIM_NBR_GetValue;
        X_TOTAL_PAID_AMT.GetValue += X_TOTAL_PAID_AMT_GetValue;
        fleF001_BATCH_CONTROL_FILE.InitializeItems += fleF001_BATCH_CONTROL_FILE_InitializeItems;
        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;
        fleF002_HDR.InitializeItems += fleF002_HDR_InitializeItems;
        fleF002_DTL.InitializeItems += fleF002_DTL_InitializeItems;

    }


    #region "Declarations (Variables, Files and Transactions)(U141C_U141_GEN_BATCH_NBRS_4)"

    private SqlFileObject fleU141C_BATCH_NBR;
    private SqlFileObject fleICONST_MSTR_REC;

    private void fleICONST_MSTR_REC_SetItemFinals()
    {

        try
        {
            fleICONST_MSTR_REC.set_SetValue("ICONST_CLINIC_PAY_BATCH_NBR", QDesign.Substring(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_PAY_BATCH_NBR"), 1, 2) + QDesign.ASCII(X_BATCH_NBR.Value, 4));


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

    private DDecimal X_PAY_BATCH_NBR = new DDecimal("X_PAY_BATCH_NBR", 4);
    private void X_PAY_BATCH_NBR_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.Substring(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_PAY_BATCH_NBR"), 3, 4));


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
    private CoreDecimal X_BATCH_NBR;
    private CoreDecimal BATCTRL_MANUAL_PAY_TOT;
    private DCharacter X_CLINIC_BATCH_NBR = new DCharacter("X_CLINIC_BATCH_NBR", 8);
    private void X_CLINIC_BATCH_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(fleU141C_BATCH_NBR.GetDecimalValue("CLINIC_NBR"), 2) + QDesign.Substring(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_PAY_BATCH_NBR"), 1, 2) + QDesign.ASCII(X_BATCH_NBR.Value, 4);


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
    private DDecimal X_CLAIM_NBR = new DDecimal("X_CLAIM_NBR", 6);
    private void X_CLAIM_NBR_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleU141C_BATCH_NBR.GetDecimalValue("X_CLAIM_COUNT");


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
    private DDecimal X_TOTAL_PAID_AMT = new DDecimal("X_TOTAL_PAID_AMT", 9);
    private void X_TOTAL_PAID_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleU141C_BATCH_NBR.GetDecimalValue("SIGNED_AMT_NET");


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
    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_NBR", true, X_CLINIC_BATCH_NBR.Value);
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_TYPE", true, "P");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD", true, "M");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD_SUB_TYPE", true, "A");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CLINIC_NBR", true, fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_NBR"));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_BATCH_ENTERED", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_PERIOD_END", true, QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD"), 2));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_LOC", true, "MISC");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AGENT_CD", true, QDesign.NConvert(fleU141C_BATCH_NBR.GetStringValue("HDR_AGENT_CD")));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CYCLE_NBR", true, fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_CYCLE_NBR"));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AR_YY_MM", true, "000000");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_STATUS", true, "1");


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



    private void fleF001_BATCH_CONTROL_FILE_SetItemFinals()
    {

        try
        {
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_LAST_CLAIM_NBR", X_CLAIM_NBR.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_NBR_CLAIMS_IN_BATCH", X_CLAIM_NBR.Value);


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

    private SqlFileObject fleF002_HDR;

    private void fleF002_HDR_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF002_HDR.set_SetValue("KEY_CLM_TYPE", true, "B");
            if (!Fixed)
                fleF002_HDR.set_SetValue("KEY_CLM_BATCH_NBR", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"));
            if (!Fixed)
                fleF002_HDR.set_SetValue("KEY_CLM_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_HDR.set_SetValue("KEY_CLM_SERV_CODE", true, "00000");
            if (!Fixed)
                fleF002_HDR.set_SetValue("KEY_CLM_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_LOC", true, "MISC");
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_DOC_DEPT", true, fleU141C_BATCH_NBR.GetDecimalValue("DOC_DEPT"));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_BATCH_TYPE", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE"));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_ADJ_CD_SUB_TYPE", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD_SUB_TYPE"));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_ADJ_CD", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD"));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_DATE_PERIOD_END", true, QDesign.NConvert(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_DATE_PERIOD_END")));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_CYCLE_NBR", true, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CYCLE_NBR"));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_BATCH_NBR", true, QDesign.ASCII(fleU141C_BATCH_NBR.GetDecimalValue("CLINIC_NBR"), 2) + fleU141C_BATCH_NBR.GetStringValue("DOC_NBR") + QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 3, 3));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_CLAIM_NBR", true, 1);
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_ADJ_OMA_CD", true, "0000");
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_ADJ_OMA_SUFF", true, "0");
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_ADJ_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_I_O_PAT_IND", true, "O");
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_AGENT_CD", true, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AGENT_CD"));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_DATE_ADMIT", true, "00000000");
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_MSG_NBR", true, QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 2));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_REPRINT_FLAG", true, QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 3, 1));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_SUB_NBR", true, QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 4, 1));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_AUTO_LOGOUT", true, QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 5, 1));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_FEE_COMPLEX", true, QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 6, 1));
            if (!Fixed)
                fleF002_HDR.set_SetValue("FILLER", true,QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 7, 2));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_DATE_SYS", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", true, "N");
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", true, X_TOTAL_PAID_AMT.Value);
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_ORIG_BATCH_NBR", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"));
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_ORIG_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_HDR.set_SetValue("KEY_P_CLM_TYPE", true, "Z");
            if (!Fixed)
                fleF002_HDR.set_SetValue("CLMHDR_REFERENCE", true, fleU141C_BATCH_NBR.GetStringValue("CLMHDR_REFERENCE"));


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

    private SqlFileObject fleF002_DTL;

    private void fleF002_DTL_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF002_DTL.set_SetValue("KEY_CLM_TYPE", true, "B");
            if (!Fixed)
                fleF002_DTL.set_SetValue("KEY_CLM_BATCH_NBR", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"));
            if (!Fixed)
                fleF002_DTL.set_SetValue("KEY_CLM_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_DTL.set_SetValue("KEY_CLM_SERV_CODE", true, fleU141C_BATCH_NBR.GetStringValue("CLMDTL_OMA_CD"));
            if (!Fixed)
                fleF002_DTL.set_SetValue("KEY_CLM_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_BATCH_NBR", true, fleF002_HDR.GetStringValue("CLMHDR_BATCH_NBR"));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_CLAIM_NBR", true, fleF002_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_OMA_CD", true, fleU141C_BATCH_NBR.GetStringValue("CLMDTL_OMA_CD"));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_OMA_SUFF", true, " ");
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_ADJ_NBR", true, 1);
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_AGENT_CD", true, fleF002_HDR.GetDecimalValue("CLMHDR_AGENT_CD"));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_ADJ_CD", true, fleF002_HDR.GetStringValue("CLMHDR_ADJ_CD"));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_SV_YY", true, QDesign.NConvert(QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 1, 4)));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_SV_MM", true, QDesign.NConvert(QDesign.Substring(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8), 5, 2)));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_SV_DD", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_NBR_SERV", true, 0);
            //if (!Fixed)
            //    fleF002_DTL.set_SetValue("CLMDTL_CONSEC_DATES", true, 0);
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_DATE_PERIOD_END", true, QDesign.ASCII(fleF002_HDR.GetNumericDateValue("CLMHDR_DATE_PERIOD_END"), 8));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_CYCLE_NBR", true, fleF002_HDR.GetDecimalValue("CLMHDR_CYCLE_NBR"));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_FEE_OMA", true, X_TOTAL_PAID_AMT.Value);
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_FEE_OHIP", true, X_TOTAL_PAID_AMT.Value);
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_ORIG_BATCH_NBR", true, fleF002_HDR.GetStringValue("CLMHDR_ORIG_BATCH_NBR"));
            if (!Fixed)
                fleF002_DTL.set_SetValue("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH", true, fleF002_HDR.GetDecimalValue("CLMHDR_ORIG_CLAIM_NBR"));
            if (!Fixed)
                fleF002_DTL.set_SetValue("KEY_P_CLM_TYPE", true, "Z");


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





    private SqlFileObject fleU141C_PAY_BATCHES;


    #endregion


    #region "Standard Generated Procedures(U141C_U141_GEN_BATCH_NBRS_4)"


    #region "Automatic Item Initialization(U141C_U141_GEN_BATCH_NBRS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U141C_U141_GEN_BATCH_NBRS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:09:45 PM

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
        fleU141C_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF002_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU141C_PAY_BATCHES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U141C_U141_GEN_BATCH_NBRS_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:09:45 PM

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
            fleU141C_BATCH_NBR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleF002_HDR.Dispose();
            fleF002_DTL.Dispose();
            fleU141C_PAY_BATCHES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U141C_U141_GEN_BATCH_NBRS_4)"


    public void Run()
    {

        try
        {
            Request("U141_GEN_BATCH_NBRS_4");

            while (fleU141C_BATCH_NBR.QTPForMissing())
            {
                // --> GET U141C_BATCH_NBR <--

                fleU141C_BATCH_NBR.GetData();
                // --> End GET U141C_BATCH_NBR <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append((fleU141C_BATCH_NBR.GetDecimalValue("CLINIC_NBR")));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--


                    if (Transaction())
                    {
                        Sort(fleU141C_BATCH_NBR.GetSortValue("CLINIC_NBR"), fleU141C_BATCH_NBR.GetSortValue("HDR_AGENT_CD"), fleU141C_BATCH_NBR.GetSortValue("X_BATCH_COUNT"));
                    }
                }
            }

            while (Sort(fleU141C_BATCH_NBR, fleICONST_MSTR_REC))
            {
                if (fleU141C_BATCH_NBR.At("CLINIC_NBR") || fleU141C_BATCH_NBR.At("HDR_AGENT_CD") || fleU141C_BATCH_NBR.At("X_BATCH_COUNT"))
                {
                    X_BATCH_NBR.Value = X_PAY_BATCH_NBR.Value + fleU141C_BATCH_NBR.GetDecimalValue("X_BATCH_COUNT");
                }

                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_ACT", X_TOTAL_PAID_AMT.Value);
                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_EST", X_TOTAL_PAID_AMT.Value);
                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_CALC_TOT_REV", X_TOTAL_PAID_AMT.Value);
                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_MANUAL_PAY_TOT", X_TOTAL_PAID_AMT.Value);

                BATCTRL_MANUAL_PAY_TOT.Value = fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_MANUAL_PAY_TOT");

                fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Add, fleU141C_BATCH_NBR.At("CLINIC_NBR") || fleU141C_BATCH_NBR.At("HDR_AGENT_CD") || fleU141C_BATCH_NBR.At("X_BATCH_COUNT"), null);
                fleF002_HDR.OutPut(OutPutType.Add);
                fleF002_DTL.OutPut(OutPutType.Add);
                fleICONST_MSTR_REC.OutPut(OutPutType.Update, fleU141C_BATCH_NBR.At("CLINIC_NBR"), null);

                SubFile(ref m_trnTRANS_UPDATE, ref fleU141C_PAY_BATCHES, fleU141C_BATCH_NBR.At("CLINIC_NBR") || fleU141C_BATCH_NBR.At("HDR_AGENT_CD") || fleU141C_BATCH_NBR.At("X_BATCH_COUNT"), SubFileType.Keep, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR", BATCTRL_MANUAL_PAY_TOT);

                Reset(ref X_BATCH_NBR, X_PAY_BATCH_NBR.Value, fleU141C_BATCH_NBR.At("CLINIC_NBR"));
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
            EndRequest("U141_GEN_BATCH_NBRS_4");

        }

    }




    #endregion


}
//U141_GEN_BATCH_NBRS_4




