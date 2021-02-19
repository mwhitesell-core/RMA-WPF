
#region "Screen Comments"

// 2012/aug/02 - MC - update suspend hdr amts from suspend details after finish all fixup
// from update_suspend_all_dtl.qts
// - running this program has no harm even no changes from suspend details


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UPDATE_SUSPEND_HDR_FROM_ALL_DTL : BaseClassControl
{

    private UPDATE_SUSPEND_HDR_FROM_ALL_DTL m_UPDATE_SUSPEND_HDR_FROM_ALL_DTL;

    public UPDATE_SUSPEND_HDR_FROM_ALL_DTL(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UPDATE_SUSPEND_HDR_FROM_ALL_DTL(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UPDATE_SUSPEND_HDR_FROM_ALL_DTL != null))
        {
            m_UPDATE_SUSPEND_HDR_FROM_ALL_DTL.CloseTransactionObjects();
            m_UPDATE_SUSPEND_HDR_FROM_ALL_DTL = null;
        }
    }

    public UPDATE_SUSPEND_HDR_FROM_ALL_DTL GetUPDATE_SUSPEND_HDR_FROM_ALL_DTL(int Level)
    {
        if (m_UPDATE_SUSPEND_HDR_FROM_ALL_DTL == null)
        {
            m_UPDATE_SUSPEND_HDR_FROM_ALL_DTL = new UPDATE_SUSPEND_HDR_FROM_ALL_DTL("UPDATE_SUSPEND_HDR_FROM_ALL_DTL", Level);
        }
        else
        {
            m_UPDATE_SUSPEND_HDR_FROM_ALL_DTL.ResetValues();
        }
        return m_UPDATE_SUSPEND_HDR_FROM_ALL_DTL;
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

            UPDATE_SUSPEND_HDR_FROM_ALL_DTL_1 u1 = new UPDATE_SUSPEND_HDR_FROM_ALL_DTL_1(Name, Level);
            u1.Run();
            u1.Dispose();
            u1 = null;

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



public class UPDATE_SUSPEND_HDR_FROM_ALL_DTL_1 : UPDATE_SUSPEND_HDR_FROM_ALL_DTL
{

    public UPDATE_SUSPEND_HDR_FROM_ALL_DTL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_DTL_FEE_OMA = new CoreDecimal("X_DTL_FEE_OMA", 7, this);
        X_DTL_FEE_OHIP = new CoreDecimal("X_DTL_FEE_OHIP", 7, this);

        fleF002_SUSPEND_HDR.SetItemFinals += fleF002_SUSPEND_HDR_SetItemFinals;
        fleF002_SUSPEND_DTL.Choose += fleF002_SUSPEND_DTL_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(UPDATE_SUSPEND_HDR_FROM_ALL_DTL_1)"

    private SqlFileObject fleF002_SUSPEND_DTL;
    private SqlFileObject fleF002_SUSPEND_HDR;

    private void fleF002_SUSPEND_HDR_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", "U");
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", X_DTL_FEE_OMA.Value);
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", X_DTL_FEE_OHIP.Value);


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

    private CoreDecimal X_DTL_FEE_OMA;

    private CoreDecimal X_DTL_FEE_OHIP;


    #endregion


    #region "Standard Generated Procedures(UPDATE_SUSPEND_HDR_FROM_ALL_DTL_1)"


    #region "Automatic Item Initialization(UPDATE_SUSPEND_HDR_FROM_ALL_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UPDATE_SUSPEND_HDR_FROM_ALL_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:54 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UPDATE_SUSPEND_HDR_FROM_ALL_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:54 PM

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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UPDATE_SUSPEND_HDR_FROM_ALL_DTL_1)"


    public void Run()
    {

        try
        {
            Request("1");

            while (fleF002_SUSPEND_DTL.QTPForMissing())
            {
                // --> GET F002_SUSPEND_DTL <--

                fleF002_SUSPEND_DTL.GetData();
                // --> End GET F002_SUSPEND_DTL <--

                while (fleF002_SUSPEND_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_HDR <--


                    if (Transaction())
                    {

                        Sort(fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_OHIP_NBR"), fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_ACCOUNTING_NBR"));



                    }

                }

            }

            while (Sort(fleF002_SUSPEND_DTL, fleF002_SUSPEND_HDR))
            {
                X_DTL_FEE_OMA.Value = X_DTL_FEE_OMA.Value + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OMA");
                X_DTL_FEE_OHIP.Value = X_DTL_FEE_OHIP.Value + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP");

                fleF002_SUSPEND_HDR.OutPut(OutPutType.Update, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"), null);

                Reset(ref X_DTL_FEE_OMA, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"));
                Reset(ref X_DTL_FEE_OHIP, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"));

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
            EndRequest("1");

        }

    }







    #endregion


}
//1




