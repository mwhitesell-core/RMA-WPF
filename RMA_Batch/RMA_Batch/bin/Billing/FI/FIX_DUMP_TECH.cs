
#region "Screen Comments"

// 2010/feb/23 MC1 - zero out the clmdtl-amt-tech-billed and reduce the clmdtl-amt-tech-billed
// from clmhdr-amt-tech-billed


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class FIX_DUMP_TECH : BaseClassControl
{

    private FIX_DUMP_TECH m_FIX_DUMP_TECH;

    public FIX_DUMP_TECH(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public FIX_DUMP_TECH(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_FIX_DUMP_TECH != null))
        {
            m_FIX_DUMP_TECH.CloseTransactionObjects();
            m_FIX_DUMP_TECH = null;
        }
    }

    public FIX_DUMP_TECH GetFIX_DUMP_TECH(int Level)
    {
        if (m_FIX_DUMP_TECH == null)
        {
            m_FIX_DUMP_TECH = new FIX_DUMP_TECH("FIX_DUMP_TECH", Level);
        }
        else
        {
            m_FIX_DUMP_TECH.ResetValues();
        }
        return m_FIX_DUMP_TECH;
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

            FIX_DUMP_TECH_ZERO_CLMDTL_AMT_TECH_1 ZERO_CLMDTL_AMT_TECH_1 = new FIX_DUMP_TECH_ZERO_CLMDTL_AMT_TECH_1(Name, Level);
            ZERO_CLMDTL_AMT_TECH_1.Run();
            ZERO_CLMDTL_AMT_TECH_1.Dispose();
            ZERO_CLMDTL_AMT_TECH_1 = null;

            FIX_DUMP_TECH_REDUCE_CLMHDR_AMT_TECH_2 REDUCE_CLMHDR_AMT_TECH_2 = new FIX_DUMP_TECH_REDUCE_CLMHDR_AMT_TECH_2(Name, Level);
            REDUCE_CLMHDR_AMT_TECH_2.Run();
            REDUCE_CLMHDR_AMT_TECH_2.Dispose();
            REDUCE_CLMHDR_AMT_TECH_2 = null;

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



public class FIX_DUMP_TECH_ZERO_CLMDTL_AMT_TECH_1 : FIX_DUMP_TECH
{

    public FIX_DUMP_TECH_ZERO_CLMDTL_AMT_TECH_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleDUMP_TECH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DUMP_TECH", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_SUSPEND_DTL.SetItemFinals += fleF002_SUSPEND_DTL_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(FIX_DUMP_TECH_ZERO_CLMDTL_AMT_TECH_1)"

    private SqlFileObject fleDUMP_TECH;
    private SqlFileObject fleF002_SUSPEND_DTL;

    private void fleF002_SUSPEND_DTL_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", 0);


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
            if (QDesign.NULL(fleDUMP_TECH.GetStringValue("CLMDTL_OMA_CD")) == QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")) & QDesign.NULL(fleDUMP_TECH.GetStringValue("CLMDTL_OMA_SUFF")) == QDesign.NULL(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_SUFF")))
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


    #region "Standard Generated Procedures(FIX_DUMP_TECH_ZERO_CLMDTL_AMT_TECH_1)"


    #region "Automatic Item Initialization(FIX_DUMP_TECH_ZERO_CLMDTL_AMT_TECH_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(FIX_DUMP_TECH_ZERO_CLMDTL_AMT_TECH_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:55 PM

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
        fleDUMP_TECH.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(FIX_DUMP_TECH_ZERO_CLMDTL_AMT_TECH_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:55 PM

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
            fleDUMP_TECH.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(FIX_DUMP_TECH_ZERO_CLMDTL_AMT_TECH_1)"


    public void Run()
    {

        try
        {
            Request("ZERO_CLMDTL_AMT_TECH_1");

            while (fleDUMP_TECH.QTPForMissing())
            {
                // --> GET DUMP_TECH <--

                fleDUMP_TECH.GetData();
                // --> End GET DUMP_TECH <--

                while (fleF002_SUSPEND_DTL.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleDUMP_TECH.GetDecimalValue("CLMDTL_DOC_OHIP_NBR")));

                    fleF002_SUSPEND_DTL.GetData(m_strWhere.ToString());
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
            EndRequest("ZERO_CLMDTL_AMT_TECH_1");

        }

    }







    #endregion


}
//ZERO_CLMDTL_AMT_TECH_1



public class FIX_DUMP_TECH_REDUCE_CLMHDR_AMT_TECH_2 : FIX_DUMP_TECH
{

    public FIX_DUMP_TECH_REDUCE_CLMHDR_AMT_TECH_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleDUMP_TECH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DUMP_TECH", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(FIX_DUMP_TECH_REDUCE_CLMHDR_AMT_TECH_2)"

    private SqlFileObject fleDUMP_TECH;
    private SqlFileObject fleF002_SUSPEND_HDR;


    #endregion


    #region "Standard Generated Procedures(FIX_DUMP_TECH_REDUCE_CLMHDR_AMT_TECH_2)"


    #region "Automatic Item Initialization(FIX_DUMP_TECH_REDUCE_CLMHDR_AMT_TECH_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(FIX_DUMP_TECH_REDUCE_CLMHDR_AMT_TECH_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:55 PM

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
        fleDUMP_TECH.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(FIX_DUMP_TECH_REDUCE_CLMHDR_AMT_TECH_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:02:55 PM

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
            fleDUMP_TECH.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(FIX_DUMP_TECH_REDUCE_CLMHDR_AMT_TECH_2)"


    public void Run()
    {

        try
        {
            Request("REDUCE_CLMHDR_AMT_TECH_2");

            while (fleDUMP_TECH.QTPForMissing())
            {
                // --> GET DUMP_TECH <--

                fleDUMP_TECH.GetData();
                // --> End GET DUMP_TECH <--

                while (fleF002_SUSPEND_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleDUMP_TECH.GetDecimalValue("CLMDTL_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleDUMP_TECH.GetStringValue("CLMDTL_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_HDR <--


                    if (Transaction())
                    {

                        Sort(fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_OHIP_NBR"), fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_ACCOUNTING_NBR"));


                    }

                }

            }


            while (Sort(fleDUMP_TECH, fleF002_SUSPEND_HDR))
            {
                SubTotal(ref fleF002_SUSPEND_HDR, "CLMHDR_AMT_TECH_BILLED", fleDUMP_TECH.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"), ItemType.Negative);

                fleF002_SUSPEND_HDR.OutPut(OutPutType.Update, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"), null);

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
            EndRequest("REDUCE_CLMHDR_AMT_TECH_2");

        }

    }







    #endregion


}
//REDUCE_CLMHDR_AMT_TECH_2




