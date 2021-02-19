
#region "Screen Comments"

// Program: maria_rejects2.qts
// Purpose: create subfile of submission errors to pass to maria_rejects1.qzs
// Mod Hist
// 2003/nov/28 b.e. - orig


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class MARIA_REJECTS2 : BaseClassControl
{

    private MARIA_REJECTS2 m_MARIA_REJECTS2;

    public MARIA_REJECTS2(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public MARIA_REJECTS2(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_MARIA_REJECTS2 != null))
        {
            m_MARIA_REJECTS2.CloseTransactionObjects();
            m_MARIA_REJECTS2 = null;
        }
    }

    public MARIA_REJECTS2 GetMARIA_REJECTS2(int Level)
    {
        if (m_MARIA_REJECTS2 == null)
        {
            m_MARIA_REJECTS2 = new MARIA_REJECTS2("MARIA_REJECTS2", Level);
        }
        else
        {
            m_MARIA_REJECTS2.ResetValues();
        }
        return m_MARIA_REJECTS2;
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

            MARIA_REJECTS2_MARIA_1_1 MARIA_1_1 = new MARIA_REJECTS2_MARIA_1_1(Name, Level);
            MARIA_1_1.Run();
            MARIA_1_1.Dispose();
            MARIA_1_1 = null;

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



public class MARIA_REJECTS2_MARIA_1_1 : MARIA_REJECTS2
{

    public MARIA_REJECTS2_MARIA_1_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleMARIA_REJECTS1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "MARIA_REJECTS1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleMARIA_REJECTS2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "MARIA_REJECTS2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(MARIA_REJECTS2_MARIA_1_1)"

    private SqlFileObject fleMARIA_REJECTS1;
    private SqlFileObject fleMARIA_REJECTS2;


    #endregion


    #region "Standard Generated Procedures(MARIA_REJECTS2_MARIA_1_1)"


    #region "Automatic Item Initialization(MARIA_REJECTS2_MARIA_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(MARIA_REJECTS2_MARIA_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:13 PM

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
        fleMARIA_REJECTS1.Transaction = m_trnTRANS_UPDATE;
        fleMARIA_REJECTS2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(MARIA_REJECTS2_MARIA_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:13 PM

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
            fleMARIA_REJECTS1.Dispose();
            fleMARIA_REJECTS2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(MARIA_REJECTS2_MARIA_1_1)"


    public void Run()
    {

        try
        {
            Request("MARIA_1_1");

            while (fleMARIA_REJECTS1.QTPForMissing())
            {
                // --> GET MARIA_REJECTS1 <--

                fleMARIA_REJECTS1.GetData();
                // --> End GET MARIA_REJECTS1 <--


                if (Transaction())
                {

                    Sort(fleMARIA_REJECTS1.GetSortValue("SUBMITTED_REJECTED_CLAIM"), fleMARIA_REJECTS1.GetSortValue("EDT_ERR_H_CD_1"));


                }

            }

            while (Sort(fleMARIA_REJECTS1))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_REJECTS2, fleMARIA_REJECTS1.At("SUBMITTED_REJECTED_CLAIM") || fleMARIA_REJECTS1.At("EDT_ERR_H_CD_1"), SubFileType.Keep, fleMARIA_REJECTS1);


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
            EndRequest("MARIA_1_1");

        }

    }







    #endregion


}
//MARIA_1_1




