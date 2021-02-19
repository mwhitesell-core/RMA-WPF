
#region "Screen Comments"

// #> PROGRAM-ID.     U035C.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : To print the direct bill invoices
// This pgm is the third series of the 3 pgms     
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 2001/APR/18 M.C.         - ORIGINAL (convert from u035c.cbl)
// update claim header records
// 2013/May/14 MC1          - create a new request to create record in f010-crm per patient 


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U035C : BaseClassControl
{

    private U035C m_U035C;

    public U035C(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U035C(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U035C != null))
        {
            m_U035C.CloseTransactionObjects();
            m_U035C = null;
        }
    }

    public U035C GetU035C(int Level)
    {
        if (m_U035C == null)
        {
            m_U035C = new U035C("U035C", Level);
        }
        else
        {
            m_U035C.ResetValues();
        }
        return m_U035C;
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

            U035C_UPDATE_1 UPDATE_1 = new U035C_UPDATE_1(Name, Level);
            UPDATE_1.Run();
            UPDATE_1.Dispose();
            UPDATE_1 = null;

            U035C_UPDATE_CLMHDR_2 UPDATE_CLMHDR_2 = new U035C_UPDATE_CLMHDR_2(Name, Level);
            UPDATE_CLMHDR_2.Run();
            UPDATE_CLMHDR_2.Dispose();
            UPDATE_CLMHDR_2 = null;

            U035C_CREATE_F010_CRM_3 CREATE_F010_CRM_3 = new U035C_CREATE_F010_CRM_3(Name, Level);
            CREATE_F010_CRM_3.Run();
            CREATE_F010_CRM_3.Dispose();
            CREATE_F010_CRM_3 = null;

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



public class U035C_UPDATE_1 : U035C
{

    public U035C_UPDATE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU035A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U035C_UPDATE_1)"

    private SqlFileObject fleU035A;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_REPRINT_FLAG", "N");
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_AUTO_LOGOUT")) == "Y")
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_REFERENCE", QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));
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

    }




    #endregion


    #region "Standard Generated Procedures(U035C_UPDATE_1)"


    #region "Automatic Item Initialization(U035C_UPDATE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U035C_UPDATE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:48:58 PM

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
        fleU035A.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U035C_UPDATE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:48:58 PM

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
            fleU035A.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U035C_UPDATE_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_1");

            while (fleU035A.QTPForMissing())
            {
                // --> GET U035A <--

                fleU035A.GetData();
                // --> End GET U035A <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU035A.GetStringValue("CLM_SHADOW_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleU035A.GetDecimalValue("CLM_SHADOW_CLAIM_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {
                        fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update);

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
            EndRequest("UPDATE_1");

        }

    }







    #endregion


}
//UPDATE_1



public class U035C_UPDATE_CLMHDR_2 : U035C
{

    public U035C_UPDATE_CLMHDR_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU035PAY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035PAY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U035C_UPDATE_CLMHDR_2)"

    private SqlFileObject fleU035PAY;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_CURR_PAYMENT", 0);


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


    #region "Standard Generated Procedures(U035C_UPDATE_CLMHDR_2)"


    #region "Automatic Item Initialization(U035C_UPDATE_CLMHDR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U035C_UPDATE_CLMHDR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:48:58 PM

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
        fleU035PAY.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U035C_UPDATE_CLMHDR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:48:58 PM

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
            fleU035PAY.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U035C_UPDATE_CLMHDR_2)"


    public void Run()
    {

        try
        {
            Request("UPDATE_CLMHDR_2");

            while (fleU035PAY.QTPForMissing())
            {
                // --> GET U035PAY <--

                fleU035PAY.GetData();
                // --> End GET U035PAY <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU035PAY.GetStringValue("CLM_SHADOW_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleU035PAY.GetDecimalValue("CLM_SHADOW_CLAIM_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {

                        Sort(fleU035PAY.GetSortValue("CLM_SHADOW_BATCH_NBR"), fleU035PAY.GetSortValue("CLM_SHADOW_CLAIM_NBR"));


                    }

                }

            }

            while (Sort(fleU035PAY, fleF002_CLAIMS_MSTR))
            {
                fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update, fleU035PAY.At("CLM_SHADOW_BATCH_NBR") || fleU035PAY.At("CLM_SHADOW_CLAIM_NBR"), null);

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
            EndRequest("UPDATE_CLMHDR_2");

        }

    }







    #endregion


}
//UPDATE_CLMHDR_2



public class U035C_CREATE_F010_CRM_3 : U035C
{

    public U035C_CREATE_F010_CRM_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU035A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        CLM_COUNT = new CoreDecimal("CLM_COUNT", 6, this);
        fleF010_CRM = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_CRM", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF010_CRM.SetItemFinals += fleF010_CRM_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U035C_CREATE_F010_CRM_3)"

    private SqlFileObject fleU035A;
    private CoreDecimal CLM_COUNT;
    private SqlFileObject fleF010_CRM;

    private void fleF010_CRM_SetItemFinals()
    {

        try
        {
            fleF010_CRM.set_SetValue("KEY_PAT_MSTR", fleU035A.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART"));
            fleF010_CRM.set_SetValue("CLMHDR_BATCH_NBR", fleU035A.GetStringValue("CLM_SHADOW_BATCH_NBR"));
            fleF010_CRM.set_SetValue("CLMHDR_CLAIM_NBR", fleU035A.GetDecimalValue("CLM_SHADOW_CLAIM_NBR"));
            fleF010_CRM.set_SetValue("GHOST_DATE_DESCENDING", (20991231 - QDesign.SysDate(ref m_cnnQUERY)));
            fleF010_CRM.set_SetValue("DATE_ASSIGNED", QDesign.SysDate(ref m_cnnQUERY));
            fleF010_CRM.set_SetValue("TIME_ASSIGNED", (1000000 - (QDesign.SysTime(ref m_cnnQUERY) / 100)));
            fleF010_CRM.set_SetValue("KEY_DTL_SEQ_NBR", 1);
            fleF010_CRM.set_SetValue("ACTION_CODE", "IS");
            fleF010_CRM.set_SetValue("FOLLOWUP_ACTION", QDesign.ASCII(CLM_COUNT.Value) + " invoices sent - " + fleU035A.GetStringValue("CLM_SHADOW_BATCH_NBR") + QDesign.ASCII(fleU035A.GetDecimalValue("CLM_SHADOW_CLAIM_NBR"), 2));


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


    #region "Standard Generated Procedures(U035C_CREATE_F010_CRM_3)"


    #region "Automatic Item Initialization(U035C_CREATE_F010_CRM_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U035C_CREATE_F010_CRM_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:48:58 PM

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
        fleU035A.Transaction = m_trnTRANS_UPDATE;
        fleF010_CRM.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U035C_CREATE_F010_CRM_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:48:58 PM

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
            fleU035A.Dispose();
            fleF010_CRM.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U035C_CREATE_F010_CRM_3)"


    public void Run()
    {

        try
        {
            Request("CREATE_F010_CRM_3");

            while (fleU035A.QTPForMissing())
            {
                // --> GET U035A <--

                fleU035A.GetData();
                // --> End GET U035A <--


                if (Transaction())
                {

                    Sort(fleU035A.GetSortValue("CLMHDR_PAT_OHIP_ID_OR_CHART"));



                }

            }

            while (Sort(fleU035A))
            {
                CLM_COUNT.Value = CLM_COUNT.Value + 1;

                fleF010_CRM.OutPut(OutPutType.Add, fleU035A.At("CLMHDR_PAT_OHIP_ID_OR_CHART"), null);

                Reset(ref CLM_COUNT, fleU035A.At("CLMHDR_PAT_OHIP_ID_OR_CHART"));

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
            EndRequest("CREATE_F010_CRM_3");

        }

    }







    #endregion


}
//CREATE_F010_CRM_3




