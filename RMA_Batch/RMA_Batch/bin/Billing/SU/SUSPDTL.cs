
#region "Screen Comments"

// PURPOSE: REPORT DETAIL OF DISKETTE IF NO HARD COPY SEND
// DATE:  WHO:  MODIFICATION
// 98/06/12 M. CHAN  ORIGINAL
// SUMMARIZE THE SVC/CLAIM/AMT BY CLINIC
// INTO SUBFILE, PRINT AS FINAL FOOTING
// ON REPORT
// 98/08/17 M. CHAN  add request statement 
// 02/05/02 yasemin  add clinic 85(represents payroll B)
// 02/08/23 yasemin  add clinic 95(represents oncology clinic)
// 03/08/23 yasemin  add clinic 91,92,93,94,96                    
// 2003/dec/10    b.e.            alpha doctor number conversion
// 2004/mar/03    yasemin  add clinic 43 and 84
// 2004/jun/07    yasemin  add new afp clinic 31-59  
// 2004/oct/22    yasemin  add new afp clinic  46 
// 2005/feb/08    yasemin  add new clinic 86
// 2007/apr/15    yasemin  add new clinics 71-75
// 2007/nov       yasemin  add new clinic 87 
// 2008/Apr yasemin        add new clinic 37
// 2008/Oct yasemin       add new clinic 88
// 2009/Apr yasemin       add new clinic 89
// 2009/Jun yasemin       add new clinic 79
// 2009/dec/12 brad1         changed all zoned*8 to zoned*9
// 2010/Feb yasemin       add new clinic 66
// 2011/Jan       yasemin       add new clinic 23
// 2012/Jan/23    yasemin         add new clinic 24
// 2012/Jun/08    yasemin         add new clinic 25
// 2014/Apr/03    yasemin         add new clinic 69
// 2014/May/05    yasemin         add new clinic 68
// 2014/Oct/17    yasemin         add new clinic 30
// 2015/Mar/10    yasemin         add new clinic 26
// 2016/Apr/13    MC1             correct programming so that do not need to hardcode each new clinic
// technically a rewrite program


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class SUSPDTL : BaseClassControl
{

    private SUSPDTL m_SUSPDTL;

    public SUSPDTL(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public SUSPDTL(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_SUSPDTL != null))
        {
            m_SUSPDTL.CloseTransactionObjects();
            m_SUSPDTL = null;
        }
    }

    public SUSPDTL GetSUSPDTL(int Level)
    {
        if (m_SUSPDTL == null)
        {
            m_SUSPDTL = new SUSPDTL("SUSPDTL", Level);
        }
        else
        {
            m_SUSPDTL.ResetValues();
        }
        return m_SUSPDTL;
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

            SUSPDTL_SUSPEND_DTL_1 SUSPEND_DTL_1 = new SUSPDTL_SUSPEND_DTL_1(Name, Level);
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



public class SUSPDTL_SUSPEND_DTL_1 : SUSPDTL
{

    public SUSPDTL_SUSPEND_DTL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_SVC = new CoreDecimal("X_SVC", 5, this);
        X_CLM = new CoreDecimal("X_CLM", 5, this);
        X_AMT = new CoreDecimal("X_AMT", 10, this);
        fleSUSPDTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SUSPDTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(SUSPDTL_SUSPEND_DTL_1)"

    private SqlFileObject fleF002_SUSPEND_DTL;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF002_SUSPEND_HDR;
    private CoreDecimal X_SVC;
    private CoreDecimal X_CLM;
    private CoreDecimal X_AMT;
    private SqlFileObject fleSUSPDTL;


    #endregion


    #region "Standard Generated Procedures(SUSPDTL_SUSPEND_DTL_1)"


    #region "Automatic Item Initialization(SUSPDTL_SUSPEND_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(SUSPDTL_SUSPEND_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:08 PM

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
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleSUSPDTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(SUSPDTL_SUSPEND_DTL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:08 PM

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
            fleF020_DOCTOR_MSTR.Dispose();
            fleF002_SUSPEND_HDR.Dispose();
            fleSUSPDTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(SUSPDTL_SUSPEND_DTL_1)"


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

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_BATCH_NBR"), 3, 3))));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleF002_SUSPEND_HDR.QTPForMissing("2"))
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

                            Sort(fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_CLINIC_NBR_1_2"), fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_DOC_OHIP_NBR"), fleF002_SUSPEND_DTL.GetSortValue("CLMDTL_ACCOUNTING_NBR"));



                        }

                    }

                }

            }

            while (Sort(fleF002_SUSPEND_DTL, fleF020_DOCTOR_MSTR, fleF002_SUSPEND_HDR))
            {
                X_SVC.Value = X_SVC.Value + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_NBR_SERV");
                if (fleF002_SUSPEND_HDR.At("CLMHDR_CLINIC_NBR_1_2") || fleF002_SUSPEND_DTL.At("CLMDTL_DOC_OHIP_NBR") || fleF002_SUSPEND_DTL.At("CLMDTL_ACCOUNTING_NBR"))
                {
                    X_CLM.Value = X_CLM.Value + 1;
                }
                X_AMT.Value = X_AMT.Value + fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_FEE_OHIP");

                SubFile(ref m_trnTRANS_UPDATE, ref fleSUSPDTL, fleF002_SUSPEND_HDR.At("CLMHDR_CLINIC_NBR_1_2"), SubFileType.Keep, fleF002_SUSPEND_HDR, "CLMHDR_CLINIC_NBR_1_2", X_SVC, X_CLM, X_AMT);


                Reset(ref X_SVC, fleF002_SUSPEND_HDR.At("CLMHDR_CLINIC_NBR_1_2"));
                Reset(ref X_CLM, fleF002_SUSPEND_HDR.At("CLMHDR_CLINIC_NBR_1_2"));
                Reset(ref X_AMT, fleF002_SUSPEND_HDR.At("CLMHDR_CLINIC_NBR_1_2"));

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




