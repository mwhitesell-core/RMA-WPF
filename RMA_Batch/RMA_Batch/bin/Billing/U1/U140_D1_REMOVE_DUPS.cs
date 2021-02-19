
#region "Screen Comments"

// 2008/nov/06 M.C. -  modify if condition when output subfile
// 2012/Mar/07   MC1     -  include percentage in the sort, this will pick up the active doctor first
// -  add a new request to eliminate the zero amt or percentage record except for report only group
// 2012/03/07 - MC1


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U140_D1_REMOVE_DUPS : BaseClassControl
{

    private U140_D1_REMOVE_DUPS m_U140_D1_REMOVE_DUPS;

    public U140_D1_REMOVE_DUPS(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U140_D1_REMOVE_DUPS(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U140_D1_REMOVE_DUPS != null))
        {
            m_U140_D1_REMOVE_DUPS.CloseTransactionObjects();
            m_U140_D1_REMOVE_DUPS = null;
        }
    }

    public U140_D1_REMOVE_DUPS GetU140_D1_REMOVE_DUPS(int Level)
    {
        if (m_U140_D1_REMOVE_DUPS == null)
        {
            m_U140_D1_REMOVE_DUPS = new U140_D1_REMOVE_DUPS("U140_D1_REMOVE_DUPS", Level);
        }
        else
        {
            m_U140_D1_REMOVE_DUPS.ResetValues();
        }
        return m_U140_D1_REMOVE_DUPS;
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

            U140_D1_REMOVE_DUPS_ONE_1 ONE_1 = new U140_D1_REMOVE_DUPS_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            U140_D1_REMOVE_DUPS_TWO_2 TWO_2 = new U140_D1_REMOVE_DUPS_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

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



public class U140_D1_REMOVE_DUPS_ONE_1 : U140_D1_REMOVE_DUPS
{

    public U140_D1_REMOVE_DUPS_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU140_D1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_D1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        LAST_DOC_SOLO = new CoreCharacter("LAST_DOC_SOLO", 6, this, Common.cEmptyString);
        LAST_DOC_NBR = new CoreCharacter("LAST_DOC_NBR", 3, this, Common.cEmptyString);
        LAST_DOC_GROUP = new CoreCharacter("LAST_DOC_GROUP", 4, this, Common.cEmptyString);
        LAST_X_CONVERSION_AMT = new CoreDecimal("LAST_X_CONVERSION_AMT", 11, this);
        LAST_X_SUBMISSION_AMT = new CoreDecimal("LAST_X_SUBMISSION_AMT", 11, this);
        fleU140_TEMP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_TEMP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U140_D1_REMOVE_DUPS_ONE_1)"

    private SqlFileObject fleU140_D1;
    private CoreCharacter LAST_DOC_SOLO;
    private CoreCharacter LAST_DOC_NBR;
    private CoreCharacter LAST_DOC_GROUP;
    private CoreDecimal LAST_X_CONVERSION_AMT;
    private CoreDecimal LAST_X_SUBMISSION_AMT;
    private SqlFileObject fleU140_TEMP;


    #endregion


    #region "Standard Generated Procedures(U140_D1_REMOVE_DUPS_ONE_1)"


    #region "Automatic Item Initialization(U140_D1_REMOVE_DUPS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_D1_REMOVE_DUPS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:23 PM

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
        fleU140_D1.Transaction = m_trnTRANS_UPDATE;
        fleU140_TEMP.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_D1_REMOVE_DUPS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:23 PM

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
            fleU140_D1.Dispose();
            fleU140_TEMP.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_D1_REMOVE_DUPS_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleU140_D1.QTPForMissing())
            {
                // --> GET U140_D1 <--

                fleU140_D1.GetData();
                // --> End GET U140_D1 <--


                if (Transaction())
                {

                    Sort(fleU140_D1.GetSortValue("DOC_AFP_PAYM_GROUP"), fleU140_D1.GetSortValue("DOC_AFP_PAYM_SOLO"), fleU140_D1.GetSortValue("AFP_MULTI_DOC_RA_PERCENTAGE", SortType.Descending), fleU140_D1.GetSortValue("X_CONVERSION_AMT"), fleU140_D1.GetSortValue("X_SUBMISSION_AMT"));



                }

            }

            while (Sort(fleU140_D1))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleU140_TEMP, QDesign.NULL(LAST_DOC_SOLO.Value) != QDesign.NULL(fleU140_D1.GetStringValue("DOC_AFP_PAYM_SOLO")) | QDesign.NULL(LAST_DOC_GROUP.Value) != QDesign.NULL(fleU140_D1.GetStringValue("DOC_AFP_PAYM_GROUP")) | QDesign.NULL(LAST_X_CONVERSION_AMT.Value) != QDesign.NULL(fleU140_D1.GetDecimalValue("X_CONVERSION_AMT")) | QDesign.NULL(LAST_X_SUBMISSION_AMT.Value) != QDesign.NULL(fleU140_D1.GetDecimalValue("X_SUBMISSION_AMT")) | (QDesign.NULL(LAST_DOC_NBR.Value) != QDesign.NULL(fleU140_D1.GetStringValue("DOC_NBR")) & QDesign.NULL(fleU140_D1.GetDecimalValue("X_CONVERSION_AMT")) != 0 & QDesign.NULL(fleU140_D1.GetStringValue("AFP_GROUP_PROCESS_FLAG")) == "E") | (QDesign.NULL(LAST_DOC_NBR.Value) != QDesign.NULL(fleU140_D1.GetStringValue("DOC_NBR")) & QDesign.NULL(fleU140_D1.GetStringValue("AFP_GROUP_PROCESS_FLAG")) == "R"), SubFileType.Keep, fleU140_D1);

                LAST_DOC_SOLO.Value = fleU140_D1.GetStringValue("DOC_AFP_PAYM_SOLO");
                LAST_DOC_NBR.Value = fleU140_D1.GetStringValue("DOC_NBR");
                LAST_DOC_GROUP.Value = fleU140_D1.GetStringValue("DOC_AFP_PAYM_GROUP");
                LAST_X_CONVERSION_AMT.Value = fleU140_D1.GetDecimalValue("X_CONVERSION_AMT");
                LAST_X_SUBMISSION_AMT.Value = fleU140_D1.GetDecimalValue("X_SUBMISSION_AMT");

                Reset(ref LAST_DOC_SOLO, fleU140_D1.At("DOC_AFP_PAYM_GROUP") || fleU140_D1.At("DOC_AFP_PAYM_SOLO") || fleU140_D1.At("AFP_MULTI_DOC_RA_PERCENTAGE") || fleU140_D1.At("X_CONVERSION_AMT") || fleU140_D1.At("X_SUBMISSION_AMT"));
                Reset(ref LAST_DOC_NBR, fleU140_D1.At("DOC_AFP_PAYM_GROUP") || fleU140_D1.At("DOC_AFP_PAYM_SOLO") || fleU140_D1.At("AFP_MULTI_DOC_RA_PERCENTAGE") || fleU140_D1.At("X_CONVERSION_AMT") || fleU140_D1.At("X_SUBMISSION_AMT"));
                Reset(ref LAST_DOC_GROUP, fleU140_D1.At("DOC_AFP_PAYM_GROUP") || fleU140_D1.At("DOC_AFP_PAYM_SOLO") || fleU140_D1.At("AFP_MULTI_DOC_RA_PERCENTAGE") || fleU140_D1.At("X_CONVERSION_AMT") || fleU140_D1.At("X_SUBMISSION_AMT"));
                Reset(ref LAST_X_CONVERSION_AMT, fleU140_D1.At("DOC_AFP_PAYM_GROUP") || fleU140_D1.At("DOC_AFP_PAYM_SOLO") || fleU140_D1.At("AFP_MULTI_DOC_RA_PERCENTAGE") || fleU140_D1.At("X_CONVERSION_AMT") || fleU140_D1.At("X_SUBMISSION_AMT"));
                Reset(ref LAST_X_SUBMISSION_AMT, fleU140_D1.At("DOC_AFP_PAYM_GROUP") || fleU140_D1.At("DOC_AFP_PAYM_SOLO") || fleU140_D1.At("AFP_MULTI_DOC_RA_PERCENTAGE") || fleU140_D1.At("X_CONVERSION_AMT") || fleU140_D1.At("X_SUBMISSION_AMT"));

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



public class U140_D1_REMOVE_DUPS_TWO_2 : U140_D1_REMOVE_DUPS
{

    public U140_D1_REMOVE_DUPS_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU140_TEMP = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_TEMP", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU140_D2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U140_D2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U140_D1_REMOVE_DUPS_TWO_2)"

    private SqlFileObject fleU140_TEMP;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleU140_TEMP.GetDecimalValue("AFP_MULTI_DOC_RA_PERCENTAGE")) != 0 | QDesign.NULL(fleU140_TEMP.GetDecimalValue("X_CONVERSION_AMT")) != 0 | QDesign.NULL(fleU140_TEMP.GetDecimalValue("X_CONVERSION_AMT")) != 0 | QDesign.NULL(fleU140_TEMP.GetDecimalValue("DEPT_NBR")) == 0)
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

    private SqlFileObject fleU140_D2;


    #endregion


    #region "Standard Generated Procedures(U140_D1_REMOVE_DUPS_TWO_2)"


    #region "Automatic Item Initialization(U140_D1_REMOVE_DUPS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U140_D1_REMOVE_DUPS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:23 PM

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
        fleU140_TEMP.Transaction = m_trnTRANS_UPDATE;
        fleU140_D2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U140_D1_REMOVE_DUPS_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:23 PM

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
            fleU140_TEMP.Dispose();
            fleU140_D2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U140_D1_REMOVE_DUPS_TWO_2)"


    public void Run()
    {

        try
        {
            Request("TWO_2");

            while (fleU140_TEMP.QTPForMissing())
            {
                // --> GET U140_TEMP <--

                fleU140_TEMP.GetData();
                // --> End GET U140_TEMP <--

                if (Transaction())
                {

                     if (Select_If())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, ref fleU140_D2, SubFileType.Keep, fleU140_TEMP);


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
            EndRequest("TWO_2");

        }

    }







    #endregion


}
//TWO_2




