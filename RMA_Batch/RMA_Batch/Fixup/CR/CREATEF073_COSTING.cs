
#region "Screen Comments"

// 2013/sep/25 MC - create f073 file based on savef020adjtype subfile which is based on f002 file
// - whatever the highest count of the adj-cd-sub-type (C,S,D,W) for the doctor,
// create the records only for Disk  or Web


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class CREATEF073_COSTING : BaseClassControl
{

    private CREATEF073_COSTING m_CREATEF073_COSTING;

    public CREATEF073_COSTING(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSAVEF020ADJTYPE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF020ADJTYPE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF073_CLIENT_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F073_CLIENT_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF073_CLIENT_DOC_MSTR.SetItemFinals += fleF073_CLIENT_DOC_MSTR_SetItemFinals;

    }

    public CREATEF073_COSTING(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSAVEF020ADJTYPE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF020ADJTYPE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF073_CLIENT_DOC_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F073_CLIENT_DOC_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF073_CLIENT_DOC_MSTR.SetItemFinals += fleF073_CLIENT_DOC_MSTR_SetItemFinals;

    }

    public override void Dispose()
    {
        if ((m_CREATEF073_COSTING != null))
        {
            m_CREATEF073_COSTING.CloseTransactionObjects();
            m_CREATEF073_COSTING = null;
        }
    }

    public CREATEF073_COSTING GetCREATEF073_COSTING(int Level)
    {
        if (m_CREATEF073_COSTING == null)
        {
            m_CREATEF073_COSTING = new CREATEF073_COSTING("CREATEF073_COSTING", Level);
        }
        else
        {
            m_CREATEF073_COSTING.ResetValues();
        }
        return m_CREATEF073_COSTING;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleSAVEF020ADJTYPE;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleSAVEF020ADJTYPE.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE")) == "D" | QDesign.NULL(fleSAVEF020ADJTYPE.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE")) == "W")
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

    private SqlFileObject fleF073_CLIENT_DOC_MSTR;

    private void fleF073_CLIENT_DOC_MSTR_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleSAVEF020ADJTYPE.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE")) == "D")
            {
                fleF073_CLIENT_DOC_MSTR.set_SetValue("CLIENT_ID", "DISK");
            }
            else if (QDesign.NULL(fleSAVEF020ADJTYPE.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE")) == "W")
            {
                fleF073_CLIENT_DOC_MSTR.set_SetValue("CLIENT_ID", "WEB");
            }
            fleF073_CLIENT_DOC_MSTR.set_SetValue("DOC_NBR", fleSAVEF020ADJTYPE.GetStringValue("DOC_NBR"));


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



    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("CREATEF073_COSTING");

            while (fleSAVEF020ADJTYPE.QTPForMissing())
            {
                // --> GET SAVEF020ADJTYPE <--

                fleSAVEF020ADJTYPE.GetData();
                // --> End GET SAVEF020ADJTYPE <--

                if (Transaction())
                {

                     if (Select_If())
                    {
                        fleF073_CLIENT_DOC_MSTR.OutPut(OutPutType.Add);

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
            EndRequest("CREATEF073_COSTING");

        }

    }


    #region "Standard Generated Procedures(CREATEF073_COSTING_CREATEF073_COSTING)"

    #region "Transaction Management Procedures(CREATEF073_COSTING_CREATEF073_COSTING)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:03 PM

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
        fleSAVEF020ADJTYPE.Transaction = m_trnTRANS_UPDATE;
        fleF073_CLIENT_DOC_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(CREATEF073_COSTING_CREATEF073_COSTING)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:03 PM

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
            fleSAVEF020ADJTYPE.Dispose();
            fleF073_CLIENT_DOC_MSTR.Dispose();


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

