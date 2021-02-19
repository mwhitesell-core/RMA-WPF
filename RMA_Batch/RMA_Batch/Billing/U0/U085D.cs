
#region "Screen Comments"

// Program: u085d 
// Purpose: create letters to patients requesting update of health card 
// eligibility information. All claims  of the patient are
// listed in the body of the letter along with doctor`s
// name
// - this pgm reduces in incoming files to a maximum of 5 records
// per patient
// 00/sep/14    B.E.    - reduce to a max of 5 the number of doctors reported 
// on any individual letter to a patient. This is 
// accomplished by outputing a doc-nbr-count field
// that is reset at the start of each patient. 
// 03/dec/14   A.A. - alpha doctor nbr


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U085D : BaseClassControl
{

    private U085D m_U085D;

    public U085D(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU085C = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U085C", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU085D = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U085D", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }

    public U085D(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU085C = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U085C", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU085D = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U085D", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }

    public override void Dispose()
    {
        if ((m_U085D != null))
        {
            m_U085D.CloseTransactionObjects();
            m_U085D = null;
        }
    }

    public U085D GetU085D(int Level)
    {
        if (m_U085D == null)
        {
            m_U085D = new U085D("U085D", Level);
        }
        else
        {
            m_U085D.ResetValues();
        }
        return m_U085D;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleU085C;
    public override bool SelectIf()
    {


        try
        {
            if (fleU085C.GetDecimalValue("X_DOC_NBR_COUNT") <= 5)
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

    private SqlFileObject fleU085D;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("U085D");

            while (fleU085C.QTPForMissing())
            {
                // --> GET U085C <--

                fleU085C.GetData();
                // --> End GET U085C <--

                if (Transaction())
                {

                     if (Select_If())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, ref fleU085D, SubFileType.Keep, fleU085C);


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
            EndRequest("U085D");

        }

    }


    #region "Standard Generated Procedures(U085D_U085D)"

    #region "Transaction Management Procedures(U085D_U085D)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:01 PM

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
        fleU085C.Transaction = m_trnTRANS_UPDATE;
        fleU085D.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U085D_U085D)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:01 PM

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
            fleU085C.Dispose();
            fleU085D.Dispose();


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


    public override bool RunQTP()
    {


        try
        {

            Run();

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

