
#region "Screen Comments"

// 2010/Oct/04 - update susp-hdr-doc-nbr & susp-hdr-clinic-nbr as well if applicable
// because of the new index added


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UPDATE_SUSPEND_HDR : BaseClassControl
{

    private UPDATE_SUSPEND_HDR m_UPDATE_SUSPEND_HDR;

    public UPDATE_SUSPEND_HDR(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UPDATE_SUSPEND_HDR(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UPDATE_SUSPEND_HDR != null))
        {
            m_UPDATE_SUSPEND_HDR.CloseTransactionObjects();
            m_UPDATE_SUSPEND_HDR = null;
        }
    }

    public UPDATE_SUSPEND_HDR GetUPDATE_SUSPEND_HDR(int Level)
    {
        if (m_UPDATE_SUSPEND_HDR == null)
        {
            m_UPDATE_SUSPEND_HDR = new UPDATE_SUSPEND_HDR("UPDATE_SUSPEND_HDR", Level);
        }
        else
        {
            m_UPDATE_SUSPEND_HDR.ResetValues();
        }
        return m_UPDATE_SUSPEND_HDR;
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

            UPDATE_SUSPEND_HDR_UPDATE_F002_SUSPEND_HDR_1 UPDATE_F002_SUSPEND_HDR_1 = new UPDATE_SUSPEND_HDR_UPDATE_F002_SUSPEND_HDR_1(Name, Level);
            UPDATE_F002_SUSPEND_HDR_1.Run();
            UPDATE_F002_SUSPEND_HDR_1.Dispose();
            UPDATE_F002_SUSPEND_HDR_1 = null;

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



public class UPDATE_SUSPEND_HDR_UPDATE_F002_SUSPEND_HDR_1 : UPDATE_SUSPEND_HDR
{

    public UPDATE_SUSPEND_HDR_UPDATE_F002_SUSPEND_HDR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_SUSPEND_HDR.SetItemFinals += fleF002_SUSPEND_HDR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(UPDATE_SUSPEND_HDR_UPDATE_F002_SUSPEND_HDR_1)"

    private SqlFileObject fleF002_SUSPEND_HDR;

    private void fleF002_SUSPEND_HDR_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", "U");
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_DOC_SPEC_CD_ALPHA", "60");
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_DOC_SPEC_CD", 60);


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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")) == 25898 & QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DOC_NBR")) == "23F")
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




    #endregion


    #region "Standard Generated Procedures(UPDATE_SUSPEND_HDR_UPDATE_F002_SUSPEND_HDR_1)"


    #region "Automatic Item Initialization(UPDATE_SUSPEND_HDR_UPDATE_F002_SUSPEND_HDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UPDATE_SUSPEND_HDR_UPDATE_F002_SUSPEND_HDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:55 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UPDATE_SUSPEND_HDR_UPDATE_F002_SUSPEND_HDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:55 PM

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
            fleF002_SUSPEND_HDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UPDATE_SUSPEND_HDR_UPDATE_F002_SUSPEND_HDR_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F002_SUSPEND_HDR_1");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--

                if (Transaction())
                {

                     if (Select_If())
                    {
                        fleF002_SUSPEND_HDR.OutPut(OutPutType.Update);

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
            EndRequest("UPDATE_F002_SUSPEND_HDR_1");

        }

    }







    #endregion


}
//UPDATE_F002_SUSPEND_HDR_1




