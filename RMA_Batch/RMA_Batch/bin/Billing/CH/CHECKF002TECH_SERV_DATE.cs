
#region "Screen Comments"

// 2010/Nov/03 M.C. - check  clmdtl-amt-tech-billed from all details including
// adjust detail to see if match with clmhdr-amt-tech-billed.
// - check if clmhdr-serv-date = 0


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class CHECKF002TECH_SERV_DATE : BaseClassControl
{

    private CHECKF002TECH_SERV_DATE m_CHECKF002TECH_SERV_DATE;

    public CHECKF002TECH_SERV_DATE(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public CHECKF002TECH_SERV_DATE(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_CHECKF002TECH_SERV_DATE != null))
        {
            m_CHECKF002TECH_SERV_DATE.CloseTransactionObjects();
            m_CHECKF002TECH_SERV_DATE = null;
        }
    }

    public CHECKF002TECH_SERV_DATE GetCHECKF002TECH_SERV_DATE(int Level)
    {
        if (m_CHECKF002TECH_SERV_DATE == null)
        {
            m_CHECKF002TECH_SERV_DATE = new CHECKF002TECH_SERV_DATE("CHECKF002TECH_SERV_DATE", Level);
        }
        else
        {
            m_CHECKF002TECH_SERV_DATE.ResetValues();
        }
        return m_CHECKF002TECH_SERV_DATE;
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

            CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1 EXTRACT_CLAIM_CLMHDR_1 = new CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1(Name, Level);
            EXTRACT_CLAIM_CLMHDR_1.Run();
            EXTRACT_CLAIM_CLMHDR_1.Dispose();
            EXTRACT_CLAIM_CLMHDR_1 = null;

            CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMDTL_2 EXTRACT_CLAIM_CLMDTL_2 = new CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMDTL_2(Name, Level);
            EXTRACT_CLAIM_CLMDTL_2.Run();
            EXTRACT_CLAIM_CLMDTL_2.Dispose();
            EXTRACT_CLAIM_CLMDTL_2 = null;

            CHECKF002TECH_SERV_DATE_SEL_DIFF_TECH_SERV_DATE_3 SEL_DIFF_TECH_SERV_DATE_3 = new CHECKF002TECH_SERV_DATE_SEL_DIFF_TECH_SERV_DATE_3(Name, Level);
            SEL_DIFF_TECH_SERV_DATE_3.Run();
            SEL_DIFF_TECH_SERV_DATE_3.Dispose();
            SEL_DIFF_TECH_SERV_DATE_3 = null;

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



public class CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1 : CHECKF002TECH_SERV_DATE
{

    public CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleEXTF002HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF002HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        fleF002_CLAIMS_MSTR.SelectIf += FleF002_CLAIMS_MSTR_SelectIf;
    }




    #region "Declarations (Variables, Files and Transactions)(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void FleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append("  ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" =  'C'  ");


            SelectIfClause = strSQL.ToString();


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





    private SqlFileObject fleEXTF002HDR;


    #endregion


    #region "Standard Generated Procedures(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"


    #region "Automatic Item Initialization(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:15 PM

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
        fleEXTF002HDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:15 PM

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
            fleEXTF002HDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMHDR_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_CLAIM_CLMHDR_1");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--

                if (Transaction())
                {

                    SubFile(ref m_trnTRANS_UPDATE, ref fleEXTF002HDR, SubFileType.Keep, fleF002_CLAIMS_MSTR, "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_SERV_DATE", "CLMHDR_AMT_TECH_BILLED", "CLMHDR_TOT_CLAIM_AR_OHIP",
                    "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_AGENT_CD");


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
            EndRequest("EXTRACT_CLAIM_CLMHDR_1");

        }

    }




    #endregion


}
//EXTRACT_CLAIM_CLMHDR_1



public class CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMDTL_2 : CHECKF002TECH_SERV_DATE
{

    public CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMDTL_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEXTF002HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF002HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_AMT_TECH_BILLED = new CoreDecimal("X_AMT_TECH_BILLED", 6, this);
        X_AMT_OHIP = new CoreDecimal("X_AMT_OHIP", 7, this);
        X_AMT_OMA = new CoreDecimal("X_AMT_OMA", 7, this);
        X_SV_DATE = new CoreDecimal("X_SV_DATE", 8, this);
        fleF002_ORIG_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F002_ORIG_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR.SelectIf += FleF002_CLAIMS_MSTR_SelectIf;
        X_DATE.GetValue += X_DATE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMDTL_2)"

    private SqlFileObject fleEXTF002HDR;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void FleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append("  ( ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append("! =  '0000'  ");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append("! =  'ZZZZ'  ");
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_OMA_CD")).Append("! =  'PAID' ) ");


            SelectIfClause = strSQL.ToString();


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

 

    private CoreDecimal X_AMT_TECH_BILLED;
    private CoreDecimal X_AMT_OHIP;
    private CoreDecimal X_AMT_OMA;
    private DDecimal X_DATE = new DDecimal("X_DATE", 8);
    private void X_DATE_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2));



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

    private CoreDecimal X_SV_DATE;
    private SqlFileObject fleF002_ORIG_DTL;


    #endregion


    #region "Standard Generated Procedures(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMDTL_2)"


    #region "Automatic Item Initialization(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMDTL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMDTL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:15 PM

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
        fleEXTF002HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_ORIG_DTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMDTL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:15 PM

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
            fleEXTF002HDR.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF002_ORIG_DTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CHECKF002TECH_SERV_DATE_EXTRACT_CLAIM_CLMDTL_2)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_CLAIM_CLMDTL_2");

            while (fleEXTF002HDR.QTPForMissing())
            {
                // --> GET EXTF002HDR <--

                fleEXTF002HDR.GetData();
                // --> End GET EXTF002HDR <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF002HDR.GetStringValue("KEY_CLM_TYPE")));
                    m_strWhere.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF002HDR.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" AND ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF002HDR.GetStringValue("KEY_CLM_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {
                        Sort(fleF002_CLAIMS_MSTR.GetSortValue("KEY_CLM_BATCH_NBR"), fleF002_CLAIMS_MSTR.GetSortValue("KEY_CLM_CLAIM_NBR"));
                    }

                }

            }

            while (Sort(fleEXTF002HDR, fleF002_CLAIMS_MSTR))
            {
                X_AMT_TECH_BILLED.Value = X_AMT_TECH_BILLED.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_AMT_TECH_BILLED");
                X_AMT_OHIP.Value = X_AMT_OHIP.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP");
                X_AMT_OMA.Value = X_AMT_OMA.Value + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OMA");
                Minimum(ref X_SV_DATE);


                SubFile(ref m_trnTRANS_UPDATE, ref fleF002_ORIG_DTL, fleF002_CLAIMS_MSTR.At("KEY_CLM_BATCH_NBR") || fleF002_CLAIMS_MSTR.At("KEY_CLM_CLAIM_NBR"), SubFileType.Keep, X_AMT_TECH_BILLED, X_SV_DATE, X_AMT_OHIP, X_AMT_OMA, fleEXTF002HDR);



                Reset(ref X_AMT_TECH_BILLED, fleF002_CLAIMS_MSTR.At("KEY_CLM_BATCH_NBR") || fleF002_CLAIMS_MSTR.At("KEY_CLM_CLAIM_NBR"));
                Reset(ref X_AMT_OHIP, fleF002_CLAIMS_MSTR.At("KEY_CLM_BATCH_NBR") || fleF002_CLAIMS_MSTR.At("KEY_CLM_CLAIM_NBR"));
                Reset(ref X_AMT_OMA, fleF002_CLAIMS_MSTR.At("KEY_CLM_BATCH_NBR") || fleF002_CLAIMS_MSTR.At("KEY_CLM_CLAIM_NBR"));
                Reset(ref X_SV_DATE, fleF002_CLAIMS_MSTR.At("KEY_CLM_BATCH_NBR") || fleF002_CLAIMS_MSTR.At("KEY_CLM_CLAIM_NBR"));

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
            EndRequest("EXTRACT_CLAIM_CLMDTL_2");

        }

    }




    #endregion


}
//EXTRACT_CLAIM_CLMDTL_2



public class CHECKF002TECH_SERV_DATE_SEL_DIFF_TECH_SERV_DATE_3 : CHECKF002TECH_SERV_DATE
{

    public CHECKF002TECH_SERV_DATE_SEL_DIFF_TECH_SERV_DATE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_ORIG_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F002_ORIG_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDIFF_AMTS_SEL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DIFF_AMTS_SEL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDIFF_SV_DATE_SEL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "DIFF_SV_DATE_SEL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(CHECKF002TECH_SERV_DATE_SEL_DIFF_TECH_SERV_DATE_3)"

    private SqlFileObject fleF002_ORIG_DTL;

    private SqlFileObject fleDIFF_AMTS_SEL;

    private SqlFileObject fleDIFF_SV_DATE_SEL;


    #endregion


    #region "Standard Generated Procedures(CHECKF002TECH_SERV_DATE_SEL_DIFF_TECH_SERV_DATE_3)"


    #region "Automatic Item Initialization(CHECKF002TECH_SERV_DATE_SEL_DIFF_TECH_SERV_DATE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(CHECKF002TECH_SERV_DATE_SEL_DIFF_TECH_SERV_DATE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:15 PM

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
        fleF002_ORIG_DTL.Transaction = m_trnTRANS_UPDATE;
        fleDIFF_AMTS_SEL.Transaction = m_trnTRANS_UPDATE;
        fleDIFF_SV_DATE_SEL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(CHECKF002TECH_SERV_DATE_SEL_DIFF_TECH_SERV_DATE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:00:15 PM

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
            fleF002_ORIG_DTL.Dispose();
            fleDIFF_AMTS_SEL.Dispose();
            fleDIFF_SV_DATE_SEL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CHECKF002TECH_SERV_DATE_SEL_DIFF_TECH_SERV_DATE_3)"


    public void Run()
    {

        try
        {
            Request("SEL_DIFF_TECH_SERV_DATE_3");

            while (fleF002_ORIG_DTL.QTPForMissing())
            {
                // --> GET F002_ORIG_DTL <--

                fleF002_ORIG_DTL.GetData();
                // --> End GET F002_ORIG_DTL <--


                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, ref fleDIFF_AMTS_SEL, QDesign.NULL(fleF002_ORIG_DTL.GetDecimalValue("X_AMT_TECH_BILLED")) != QDesign.NULL(fleF002_ORIG_DTL.GetDecimalValue("CLMHDR_AMT_TECH_BILLED")) | QDesign.NULL(fleF002_ORIG_DTL.GetDecimalValue("X_AMT_OHIP")) != QDesign.NULL(fleF002_ORIG_DTL.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) | QDesign.NULL(fleF002_ORIG_DTL.GetDecimalValue("X_AMT_OMA")) != QDesign.NULL(fleF002_ORIG_DTL.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA")), SubFileType.Keep, fleF002_ORIG_DTL);



                    SubFile(ref m_trnTRANS_UPDATE, ref fleDIFF_SV_DATE_SEL, QDesign.NULL(fleF002_ORIG_DTL.GetNumericDateValue("CLMHDR_SERV_DATE")) == 0 | QDesign.NULL(fleF002_ORIG_DTL.GetNumericDateValue("CLMHDR_SERV_DATE")) != QDesign.NULL(fleF002_ORIG_DTL.GetDecimalValue("X_SV_DATE")), SubFileType.Keep, fleF002_ORIG_DTL);



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
            EndRequest("SEL_DIFF_TECH_SERV_DATE_3");

        }

    }




    #endregion


}
//SEL_DIFF_TECH_SERV_DATE_3




