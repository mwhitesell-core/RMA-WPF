
#region "Screen Comments"

// 2013/Sep/11 MC - u031.qts 
// - delete the undefined payment batch claim from premium payments via AGEP/MOHR/MOHD1/2
// based on the subfile r030r_undefined_doc which is generated from r030r2.qzc of r030r.qzs


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U031 : BaseClassControl
{

    private U031 m_U031;

    public U031(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U031(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U031 != null))
        {
            m_U031.CloseTransactionObjects();
            m_U031 = null;
        }
    }

    public U031 GetU031(int Level)
    {
        if (m_U031 == null)
        {
            m_U031 = new U031("U031", Level);
        }
        else
        {
            m_U031.ResetValues();
        }
        return m_U031;
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

            U031_DELETE_PAYMENT_CLAIM_1 DELETE_PAYMENT_CLAIM_1 = new U031_DELETE_PAYMENT_CLAIM_1(Name, Level);
            DELETE_PAYMENT_CLAIM_1.Run();
            DELETE_PAYMENT_CLAIM_1.Dispose();
            DELETE_PAYMENT_CLAIM_1 = null;

            U031_REDUCE_BATCH_AMOUNT_2 REDUCE_BATCH_AMOUNT_2 = new U031_REDUCE_BATCH_AMOUNT_2(Name, Level);
            REDUCE_BATCH_AMOUNT_2.Run();
            REDUCE_BATCH_AMOUNT_2.Dispose();
            REDUCE_BATCH_AMOUNT_2 = null;

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



public class U031_DELETE_PAYMENT_CLAIM_1 : U031
{

    public U031_DELETE_PAYMENT_CLAIM_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR030R_UNDEFINED_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R030R_UNDEFINED_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVEF002_PAY_CLMHDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF002_PAY_CLMHDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleSAVEF002_PAY_CLMDTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF002_PAY_CLMDTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U031_DELETE_PAYMENT_CLAIM_1)"

    private SqlFileObject fleR030R_UNDEFINED_DOC;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleSAVEF002_PAY_CLMHDR;
    private SqlFileObject fleSAVEF002_PAY_CLMDTL;


    #endregion


    #region "Standard Generated Procedures(U031_DELETE_PAYMENT_CLAIM_1)"


    #region "Automatic Item Initialization(U031_DELETE_PAYMENT_CLAIM_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U031_DELETE_PAYMENT_CLAIM_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:33 PM

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
        fleR030R_UNDEFINED_DOC.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF002_PAY_CLMHDR.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF002_PAY_CLMDTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U031_DELETE_PAYMENT_CLAIM_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:33 PM

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
            fleR030R_UNDEFINED_DOC.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleSAVEF002_PAY_CLMHDR.Dispose();
            fleSAVEF002_PAY_CLMDTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U031_DELETE_PAYMENT_CLAIM_1)"


    public void Run()
    {

        try
        {
            Request("DELETE_PAYMENT_CLAIM_1");

            while (fleR030R_UNDEFINED_DOC.QTPForMissing())
            {
                // --> GET R030R_UNDEFINED_DOC <--

                fleR030R_UNDEFINED_DOC.GetData();
                // --> End GET R030R_UNDEFINED_DOC <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleR030R_UNDEFINED_DOC.GetStringValue("BATCTRL_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleR030R_UNDEFINED_DOC.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {

                        




                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF002_PAY_CLMHDR, QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "0000", SubFileType.Keep, fleF002_CLAIMS_MSTR);
                            


                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF002_PAY_CLMDTL, QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "0000", SubFileType.Keep, fleF002_CLAIMS_MSTR);

                        

                        fleF002_CLAIMS_MSTR.OutPut(OutPutType.Delete);


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
            EndRequest("DELETE_PAYMENT_CLAIM_1");

        }

    }




    #endregion


}
//DELETE_PAYMENT_CLAIM_1



public class U031_REDUCE_BATCH_AMOUNT_2 : U031
{

    public U031_REDUCE_BATCH_AMOUNT_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR030R_UNDEFINED_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R030R_UNDEFINED_DOC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        BATCH_AMOUNT = new CoreDecimal("BATCH_AMOUNT", 7, this);
        NBR_OF_CLAIM = new CoreDecimal("NBR_OF_CLAIM", 2, this);
        fleSAVEF001_PAY_BATCH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVEF001_PAY_BATCH", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U031_REDUCE_BATCH_AMOUNT_2)"

    private SqlFileObject fleR030R_UNDEFINED_DOC;
    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_SetItemFinals()
    {

        try
        {
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_ACT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT") - BATCH_AMOUNT.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_ACT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_ACT") - BATCH_AMOUNT.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_EST") - BATCH_AMOUNT.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AMT_EST", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AMT_EST") - BATCH_AMOUNT.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_TOT_REV", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_TOT_REV") - BATCH_AMOUNT.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CALC_TOT_REV", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CALC_TOT_REV") - BATCH_AMOUNT.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_MANUAL_PAY_TOT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_MANUAL_PAY_TOT") - BATCH_AMOUNT.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_MANUAL_PAY_TOT", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_MANUAL_PAY_TOT") - BATCH_AMOUNT.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_NBR_CLAIMS_IN_BATCH", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH") - NBR_OF_CLAIM.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_NBR_CLAIMS_IN_BATCH", fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_NBR_CLAIMS_IN_BATCH") - NBR_OF_CLAIM.Value);


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

    private CoreDecimal BATCH_AMOUNT;

    private CoreDecimal NBR_OF_CLAIM;


















    private SqlFileObject fleSAVEF001_PAY_BATCH;


    #endregion


    #region "Standard Generated Procedures(U031_REDUCE_BATCH_AMOUNT_2)"


    #region "Automatic Item Initialization(U031_REDUCE_BATCH_AMOUNT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U031_REDUCE_BATCH_AMOUNT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:33 PM

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
        fleR030R_UNDEFINED_DOC.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleSAVEF001_PAY_BATCH.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U031_REDUCE_BATCH_AMOUNT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:33 PM

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
            fleR030R_UNDEFINED_DOC.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleSAVEF001_PAY_BATCH.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U031_REDUCE_BATCH_AMOUNT_2)"


    public void Run()
    {

        try
        {
            Request("REDUCE_BATCH_AMOUNT_2");

            while (fleR030R_UNDEFINED_DOC.QTPForMissing())
            {
                // --> GET R030R_UNDEFINED_DOC <--

                fleR030R_UNDEFINED_DOC.GetData();
                // --> End GET R030R_UNDEFINED_DOC <--

                while (fleF001_BATCH_CONTROL_FILE.QTPForMissing("1"))
                {
                    // --> GET F001_BATCH_CONTROL_FILE <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleR030R_UNDEFINED_DOC.GetStringValue("BATCTRL_BATCH_NBR")));

                    fleF001_BATCH_CONTROL_FILE.GetData(m_strWhere.ToString());
                    // --> End GET F001_BATCH_CONTROL_FILE <--


                    if (Transaction())
                    {

                        Sort(fleF001_BATCH_CONTROL_FILE.GetSortValue("BATCTRL_BATCH_NBR"));



                    }

                }

            }

            while (Sort(fleR030R_UNDEFINED_DOC, fleF001_BATCH_CONTROL_FILE))
            {
                BATCH_AMOUNT.Value = BATCH_AMOUNT.Value + fleR030R_UNDEFINED_DOC.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
                NBR_OF_CLAIM.Value = NBR_OF_CLAIM.Value + 1;




















                SubFile(ref m_trnTRANS_UPDATE, ref fleSAVEF001_PAY_BATCH, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_BATCH_NBR"), SubFileType.Keep, fleF001_BATCH_CONTROL_FILE);





















                fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Update, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_BATCH_NBR"), null);


                Reset(ref BATCH_AMOUNT, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_BATCH_NBR"));
                Reset(ref NBR_OF_CLAIM, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_BATCH_NBR"));

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
            EndRequest("REDUCE_BATCH_AMOUNT_2");

        }

    }




    #endregion


}
//REDUCE_BATCH_AMOUNT_2




