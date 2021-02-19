
#region "Screen Comments"

// 2012/May/10    M. Chan         web_before_after.qts


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class WEB_BEFORE_AFTER : BaseClassControl
{

    private WEB_BEFORE_AFTER m_WEB_BEFORE_AFTER;

    public WEB_BEFORE_AFTER(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSUSPDTL_ALL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SUSPDTL_ALL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_DIFF = new CoreDecimal("X_DIFF", 10, this);
        fleSUSPDTL_ALL_SORT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SUSPDTL_ALL_SORT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_AMT_DIFF.GetValue += X_AMT_DIFF_GetValue;

    }

    public WEB_BEFORE_AFTER(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSUSPDTL_ALL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SUSPDTL_ALL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_DIFF = new CoreDecimal("X_DIFF", 10, this);
        fleSUSPDTL_ALL_SORT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SUSPDTL_ALL_SORT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_AMT_DIFF.GetValue += X_AMT_DIFF_GetValue;

    }

    public override void Dispose()
    {
        if ((m_WEB_BEFORE_AFTER != null))
        {
            m_WEB_BEFORE_AFTER.CloseTransactionObjects();
            m_WEB_BEFORE_AFTER = null;
        }
    }

    public WEB_BEFORE_AFTER GetWEB_BEFORE_AFTER(int Level)
    {
        if (m_WEB_BEFORE_AFTER == null)
        {
            m_WEB_BEFORE_AFTER = new WEB_BEFORE_AFTER("WEB_BEFORE_AFTER", Level);
        }
        else
        {
            m_WEB_BEFORE_AFTER.ResetValues();
        }
        return m_WEB_BEFORE_AFTER;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.
    private SqlFileObject fleSUSPDTL_ALL;
    private CoreDecimal X_DIFF;
    private DDecimal X_AMT_DIFF = new DDecimal("X_AMT_DIFF", 10);
    private void X_AMT_DIFF_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleSUSPDTL_ALL.GetDecimalValue("X_SEQ")) == 1)
            {
                CurrentValue = 0;
            }
            else if (QDesign.NULL(fleSUSPDTL_ALL.GetDecimalValue("X_SEQ")) == 2)
            {
                CurrentValue = X_DIFF.Value;
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
    private SqlFileObject fleSUSPDTL_ALL_SORT;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"


    public void Run()
    {

        try
        {
            Request("WEB_BEFORE_AFTER");

            while (fleSUSPDTL_ALL.QTPForMissing())
            {
                // --> GET SUSPDTL_ALL <--

                fleSUSPDTL_ALL.GetData();
                // --> End GET SUSPDTL_ALL <--


                if (Transaction())
                {

                    Sort(fleSUSPDTL_ALL.GetSortValue("CLMHDR_DOC_NBR"), fleSUSPDTL_ALL.GetSortValue("CLMHDR_DOC_DEPT"), fleSUSPDTL_ALL.GetSortValue("CLMHDR_DOC_SPEC_CD"), fleSUSPDTL_ALL.GetSortValue("X_SEQ"));



                }

            }

            while (Sort(fleSUSPDTL_ALL))
            {
                if (QDesign.NULL(fleSUSPDTL_ALL.GetDecimalValue("X_SEQ")) == 1)
                {
                    X_DIFF.Value = X_DIFF.Value + fleSUSPDTL_ALL.GetDecimalValue("X_AMT");
                }
                else if (QDesign.NULL(fleSUSPDTL_ALL.GetDecimalValue("X_SEQ")) == 2)
                {
                    X_DIFF.Value = X_DIFF.Value - fleSUSPDTL_ALL.GetDecimalValue("X_AMT");
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleSUSPDTL_ALL_SORT, SubFileType.Keep, X_AMT_DIFF, fleSUSPDTL_ALL);


                Reset(ref X_DIFF, fleSUSPDTL_ALL.At("CLMHDR_DOC_NBR") || fleSUSPDTL_ALL.At("CLMHDR_DOC_DEPT") || fleSUSPDTL_ALL.At("CLMHDR_DOC_SPEC_CD"));

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
            EndRequest("WEB_BEFORE_AFTER");

        }

    }


    #region "Standard Generated Procedures(WEB_BEFORE_AFTER_WEB_BEFORE_AFTER)"

    #region "Transaction Management Procedures(WEB_BEFORE_AFTER_WEB_BEFORE_AFTER)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:13 PM

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
        fleSUSPDTL_ALL.Transaction = m_trnTRANS_UPDATE;
        fleSUSPDTL_ALL_SORT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(WEB_BEFORE_AFTER_WEB_BEFORE_AFTER)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:52:13 PM

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
            fleSUSPDTL_ALL.Dispose();
            fleSUSPDTL_ALL_SORT.Dispose();


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

