
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UPDATE_F087_VH8 : BaseClassControl
{

    private UPDATE_F087_VH8 m_UPDATE_F087_VH8;

    public UPDATE_F087_VH8(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF087SUBMITTEDREJECTEDCLAIMSHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF087 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF087", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF087SUBMITTEDREJECTEDCLAIMSHDR.SetItemFinals += fleF087SUBMITTEDREJECTEDCLAIMSHDR_SetItemFinals;
        fleF087SUBMITTEDREJECTEDCLAIMSHDR.Choose += fleF087SUBMITTEDREJECTEDCLAIMSHDR_Choose;

    }

    public UPDATE_F087_VH8(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF087SUBMITTEDREJECTEDCLAIMSHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF087 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF087", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF087SUBMITTEDREJECTEDCLAIMSHDR.SetItemFinals += fleF087SUBMITTEDREJECTEDCLAIMSHDR_SetItemFinals;
        fleF087SUBMITTEDREJECTEDCLAIMSHDR.Choose += fleF087SUBMITTEDREJECTEDCLAIMSHDR_Choose;

    }

    public override void Dispose()
    {
        if ((m_UPDATE_F087_VH8 != null))
        {
            m_UPDATE_F087_VH8.CloseTransactionObjects();
            m_UPDATE_F087_VH8 = null;
        }
    }

    public UPDATE_F087_VH8 GetUPDATE_F087_VH8(int Level)
    {
        if (m_UPDATE_F087_VH8 == null)
        {
            m_UPDATE_F087_VH8 = new UPDATE_F087_VH8("UPDATE_F087_VH8", Level);
        }
        else
        {
            m_UPDATE_F087_VH8.ResetValues();
        }
        return m_UPDATE_F087_VH8;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleF087SUBMITTEDREJECTEDCLAIMSHDR;

    private void fleF087SUBMITTEDREJECTEDCLAIMSHDR_SetItemFinals()
    {

        try
        {
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("CHARGE_STATUS", "C");


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


    private void fleF087SUBMITTEDREJECTEDCLAIMSHDR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF087SUBMITTEDREJECTEDCLAIMSHDR.ElementOwner("EDT_PROCESS_DATE")).Append(" = ");
            strSQL.Append(Common.StringToField("20140501"));


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


    public override bool SelectIf()
    {


        try
        {
            if ((QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("OHIP_ERR_CODE")) == "VH8" | QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("EDT_ERR_H_CD_1")) == "VH8" | QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("EDT_ERR_H_CD_2")) == "VH8" | QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("EDT_ERR_H_CD_3")) == "VH8" | QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("EDT_ERR_H_CD_4")) == "VH8" | QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("EDT_ERR_H_CD_5")) == "VH8") & QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("CHARGE_STATUS")) == "Y")
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


    private SqlFileObject fleSAVEF087;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F087_VH8");

            while (fleF087SUBMITTEDREJECTEDCLAIMSHDR.QTPForMissing())
            {
                // --> GET F087SUBMITTEDREJECTEDCLAIMSHDR <--

                fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetData();
                // --> End GET F087SUBMITTEDREJECTEDCLAIMSHDR <--

                if (Transaction())
                {

                     if (Select_If())
                    {

                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF087, SubFileType.Keep, fleF087SUBMITTEDREJECTEDCLAIMSHDR, "SUBMITTED_REJECTED_CLAIM", "EDT_PROCESS_DATE", "CHARGE_STATUS");
                        //Parent:SUBMITTED_REJECTED_CLAIM


                        fleF087SUBMITTEDREJECTEDCLAIMSHDR.OutPut(OutPutType.Update);
                        //Parent:SUBMITTED_REJECTED_CLAIM

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
            EndRequest("UPDATE_F087_VH8");

        }

    }


    #region "Standard Generated Procedures(UPDATE_F087_VH8_UPDATE_F087_VH8)"

    #region "Transaction Management Procedures(UPDATE_F087_VH8_UPDATE_F087_VH8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:16 PM

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
        fleF087SUBMITTEDREJECTEDCLAIMSHDR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF087.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UPDATE_F087_VH8_UPDATE_F087_VH8)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:16 PM

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
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.Dispose();
            fleSAVEF087.Dispose();


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

