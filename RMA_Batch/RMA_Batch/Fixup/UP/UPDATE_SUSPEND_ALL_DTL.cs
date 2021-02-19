
#region "Screen Comments"

// 2012/aug/02 - MC  - allow user to change all selected suspend details
// 2013/09/16 - yas  - ******** after running an verifying this program you must modify and run the following program to i
// update the hdr update_suspend_hdr_from_all_dtl.qts


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UPDATE_SUSPEND_ALL_DTL : BaseClassControl
{

    private UPDATE_SUSPEND_ALL_DTL m_UPDATE_SUSPEND_ALL_DTL;

    public UPDATE_SUSPEND_ALL_DTL(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UPDATE_SUSPEND_ALL_DTL(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UPDATE_SUSPEND_ALL_DTL != null))
        {
            m_UPDATE_SUSPEND_ALL_DTL.CloseTransactionObjects();
            m_UPDATE_SUSPEND_ALL_DTL = null;
        }
    }

    public UPDATE_SUSPEND_ALL_DTL GetUPDATE_SUSPEND_ALL_DTL(int Level)
    {
        if (m_UPDATE_SUSPEND_ALL_DTL == null)
        {
            m_UPDATE_SUSPEND_ALL_DTL = new UPDATE_SUSPEND_ALL_DTL("UPDATE_SUSPEND_ALL_DTL", Level);
        }
        else
        {
            m_UPDATE_SUSPEND_ALL_DTL.ResetValues();
        }
        return m_UPDATE_SUSPEND_ALL_DTL;
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

            UPDATE_SUSPEND_ALL_DTL_UPDATE_F002_SUSPEND_DTL_1 UPDATE_F002_SUSPEND_DTL_1 = new UPDATE_SUSPEND_ALL_DTL_UPDATE_F002_SUSPEND_DTL_1(Name, Level);
            UPDATE_F002_SUSPEND_DTL_1.Run();
            UPDATE_F002_SUSPEND_DTL_1.Dispose();
            UPDATE_F002_SUSPEND_DTL_1 = null;

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



public class UPDATE_SUSPEND_ALL_DTL_UPDATE_F002_SUSPEND_DTL_1 : UPDATE_SUSPEND_ALL_DTL
{

    public UPDATE_SUSPEND_ALL_DTL_UPDATE_F002_SUSPEND_DTL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_SUSPEND_DTL.SetItemFinals += fleF002_SUSPEND_DTL_SetItemFinals;
        fleF002_SUSPEND_DTL.Choose += fleF002_SUSPEND_DTL_Choose;
        NEW_CODE.GetValue += NEW_CODE_GetValue;
        NEW_PRICE.GetValue += NEW_PRICE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UPDATE_SUSPEND_ALL_DTL_UPDATE_F002_SUSPEND_DTL_1)"

    private SqlFileObject fleF002_SUSPEND_DTL;

    private void fleF002_SUSPEND_DTL_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_STATUS", "U");
            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_FEE_OMA", NEW_PRICE.Value);
            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_FEE_OHIP", NEW_PRICE.Value);
            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_OMA_CD", NEW_CODE.Value);


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


    private void fleF002_SUSPEND_DTL_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
            strSQL.Append(18049);


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
            if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == "E082")
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

    private DCharacter NEW_CODE = new DCharacter("NEW_CODE", 4);
    private void NEW_CODE_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == "E082")
            {
                CurrentValue = "E083";
            }
            else if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == "YYYY")
            {
                CurrentValue = "XXXX";
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
    private DDecimal NEW_PRICE = new DDecimal("NEW_PRICE", 6);
    private void NEW_PRICE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == "E082")
            {
                CurrentValue = 930;
            }
            else if (QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) == "YYYY")
            {
                CurrentValue = 0;
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



    #endregion


    #region "Standard Generated Procedures(UPDATE_SUSPEND_ALL_DTL_UPDATE_F002_SUSPEND_DTL_1)"


    #region "Automatic Item Initialization(UPDATE_SUSPEND_ALL_DTL_UPDATE_F002_SUSPEND_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UPDATE_SUSPEND_ALL_DTL_UPDATE_F002_SUSPEND_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:56 PM

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
        fleF002_SUSPEND_DTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UPDATE_SUSPEND_ALL_DTL_UPDATE_F002_SUSPEND_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:56 PM

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
            fleF002_SUSPEND_DTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UPDATE_SUSPEND_ALL_DTL_UPDATE_F002_SUSPEND_DTL_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F002_SUSPEND_DTL_1");

            while (fleF002_SUSPEND_DTL.QTPForMissing())
            {
                // --> GET F002_SUSPEND_DTL <--

                fleF002_SUSPEND_DTL.GetData();
                // --> End GET F002_SUSPEND_DTL <--


                if (Transaction())
                {

                     if (Select_If())
                    {
                        fleF002_SUSPEND_DTL.OutPut(OutPutType.Update);

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
            EndRequest("UPDATE_F002_SUSPEND_DTL_1");

        }

    }







    #endregion


}
//UPDATE_F002_SUSPEND_DTL_1




