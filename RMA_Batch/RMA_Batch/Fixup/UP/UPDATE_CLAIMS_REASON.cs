
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UPDATE_CLAIMS_REASON : BaseClassControl
{

    private UPDATE_CLAIMS_REASON m_UPDATE_CLAIMS_REASON;

    public UPDATE_CLAIMS_REASON(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UPDATE_CLAIMS_REASON(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UPDATE_CLAIMS_REASON != null))
        {
            m_UPDATE_CLAIMS_REASON.CloseTransactionObjects();
            m_UPDATE_CLAIMS_REASON = null;
        }
    }

    public UPDATE_CLAIMS_REASON GetUPDATE_CLAIMS_REASON(int Level)
    {
        if (m_UPDATE_CLAIMS_REASON == null)
        {
            m_UPDATE_CLAIMS_REASON = new UPDATE_CLAIMS_REASON("UPDATE_CLAIMS_REASON", Level);
        }
        else
        {
            m_UPDATE_CLAIMS_REASON.ResetValues();
        }
        return m_UPDATE_CLAIMS_REASON;
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

            UPDATE_CLAIMS_REASON_UPDATE_CLAIMS_1 UPDATE_CLAIMS_1 = new UPDATE_CLAIMS_REASON_UPDATE_CLAIMS_1(Name, Level);
            UPDATE_CLAIMS_1.Run();
            UPDATE_CLAIMS_1.Dispose();
            UPDATE_CLAIMS_1 = null;

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



public class UPDATE_CLAIMS_REASON_UPDATE_CLAIMS_1 : UPDATE_CLAIMS_REASON
{

    public UPDATE_CLAIMS_REASON_UPDATE_CLAIMS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleREASON = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "REASON", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(UPDATE_CLAIMS_REASON_UPDATE_CLAIMS_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_STATUS_OHIP", "I2");
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_STATUS_OHIP", "I2");


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


    private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("B"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField("89N15095"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("00000"));


            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField("0"));


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
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_TYPE")) == "C" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_DATE_SYS")) == "20130227")
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



    private SqlFileObject fleREASON;


    #endregion


    #region "Standard Generated Procedures(UPDATE_CLAIMS_REASON_UPDATE_CLAIMS_1)"


    #region "Automatic Item Initialization(UPDATE_CLAIMS_REASON_UPDATE_CLAIMS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UPDATE_CLAIMS_REASON_UPDATE_CLAIMS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:13 PM

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
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleREASON.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UPDATE_CLAIMS_REASON_UPDATE_CLAIMS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:14 PM

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
            fleF002_CLAIMS_MSTR.Dispose();
            fleREASON.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UPDATE_CLAIMS_REASON_UPDATE_CLAIMS_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_CLAIMS_1");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--

                if (Transaction())
                {

                     if (Select_If())
                    {


                        SubFile(ref m_trnTRANS_UPDATE, ref fleREASON, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMHDR_CLAIM_ID", "CLMHDR_DATE_CASH_TAPE_PAYMENT", "CLMHDR_STATUS_OHIP", "CLMHDR_STATUS_OHIP");
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT



                        fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT

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
            EndRequest("UPDATE_CLAIMS_1");

        }

    }




    #endregion


}
//UPDATE_CLAIMS_1




