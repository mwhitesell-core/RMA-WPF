
#region "Screen Comments"

// PURPOSE: REPORT suspend detail for # of svc/claims/amount for each doctor
// DATE:  WHO:  MODIFICATION
// 2012/May/01 M. CHAN  ORIGINAL
// SUMMARIZE THE SVC/CLAIM/AMT BY DOCTOR
// INTO SUBFILE te be run 2 times (before/after) modification


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class SUSPDTL_2 : BaseClassControl
{

    private SUSPDTL_2 m_SUSPDTL_2;

    public SUSPDTL_2(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public SUSPDTL_2(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_SUSPDTL_2 != null))
        {
            m_SUSPDTL_2.CloseTransactionObjects();
            m_SUSPDTL_2 = null;
        }
    }

    public SUSPDTL_2 GetSUSPDTL_2(int Level)
    {
        if (m_SUSPDTL_2 == null)
        {
            m_SUSPDTL_2 = new SUSPDTL_2("SUSPDTL_2", Level);
        }
        else
        {
            m_SUSPDTL_2.ResetValues();
        }
        return m_SUSPDTL_2;
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

            SUSPDTL_2_SUSPEND_DTL_1 SUSPEND_DTL_1 = new SUSPDTL_2_SUSPEND_DTL_1(Name, Level);
            SUSPEND_DTL_1.Run();
            SUSPEND_DTL_1.Dispose();
            SUSPEND_DTL_1 = null;

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



public class SUSPDTL_2_SUSPEND_DTL_1 : SUSPDTL_2
{

    public SUSPDTL_2_SUSPEND_DTL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_SVC = new CoreDecimal("X_SVC", 5, this);
        X_CLM = new CoreDecimal("X_CLM", 5, this);
        X_AMT = new CoreDecimal("X_AMT", 9, this);
        fleSUSPDTL_ALL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SUSPDTL_ALL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_SEQ.GetValue += X_SEQ_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(SUSPDTL_2_SUSPEND_DTL_1)"

    private SqlFileObject fleF002_SUSPEND_DTL;
    private SqlFileObject fleF002_SUSPEND_HDR;
    private DDecimal X_SEQ = new DDecimal("X_SEQ", 1);
    private void X_SEQ_GetValue(ref decimal Value)
    {

        try
        {
            Value = (Convert.ToDecimal(Prompt(1)));


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
    private CoreDecimal X_SVC;
    private CoreDecimal X_CLM;
    private CoreDecimal X_AMT;
    private SqlFileObject fleSUSPDTL_ALL;


    #endregion


    #region "Standard Generated Procedures(SUSPDTL_2_SUSPEND_DTL_1)"


    #region "Automatic Item Initialization(SUSPDTL_2_SUSPEND_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(SUSPDTL_2_SUSPEND_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:06 PM

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
        fleSUSPDTL_ALL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(SUSPDTL_2_SUSPEND_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:06 PM

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
            fleSUSPDTL_ALL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(SUSPDTL_2_SUSPEND_DTL_1)"


    public void Run()
    {

        try
        {
            Request("SUSPEND_DTL_1");

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

                    fleF002_SUSPEND_HDR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F002_SUSPEND_HDR <--


                    if (Transaction())
                    {

                        Sort(fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_NBR"), fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_DEPT"), fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_SPEC_CD"), fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_ACCOUNTING_NBR"));



                    }

                }

            }

            while (Sort(fleF002_SUSPEND_DTL, fleF002_SUSPEND_HDR))
            {
                X_SVC.Value = X_SVC.Value + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_NBR_SERV");
                if (fleF002_SUSPEND_HDR.At("CLMHDR_DOC_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_DEPT") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_SPEC_CD") || fleF002_SUSPEND_DTL.At("CLMDTL_ACCOUNTING_NBR"))
                {
                    X_CLM.Value = X_CLM.Value + 1;
                }
                X_AMT.Value = X_AMT.Value + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP");

                SubFile(ref m_trnTRANS_UPDATE, ref fleSUSPDTL_ALL, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_DEPT") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_SPEC_CD"), SubFileType.Keep, fleF002_SUSPEND_HDR, "CLMHDR_DOC_NBR", "CLMHDR_DOC_DEPT", "CLMHDR_DOC_SPEC_CD", X_SVC, X_CLM,
                X_AMT, X_SEQ);


                Reset(ref X_SVC, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_DEPT") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_SPEC_CD"));
                Reset(ref X_CLM, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_DEPT") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_SPEC_CD"));
                Reset(ref X_AMT, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_DEPT") || fleF002_SUSPEND_HDR.At("CLMHDR_DOC_SPEC_CD"));

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
            EndRequest("SUSPEND_DTL_1");

        }

    }







    #endregion


}
//SUSPEND_DTL_1




