
#region "Screen Comments"

// 2015/Feb/02 - change doc ohip nbr and doc nbr for all associate files (hdr/dtl/addr/desc)


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UPDATE_SUSP_HDR_DTL_ADD_DESC : BaseClassControl
{

    private UPDATE_SUSP_HDR_DTL_ADD_DESC m_UPDATE_SUSP_HDR_DTL_ADD_DESC;

    public UPDATE_SUSP_HDR_DTL_ADD_DESC(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UPDATE_SUSP_HDR_DTL_ADD_DESC(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UPDATE_SUSP_HDR_DTL_ADD_DESC != null))
        {
            m_UPDATE_SUSP_HDR_DTL_ADD_DESC.CloseTransactionObjects();
            m_UPDATE_SUSP_HDR_DTL_ADD_DESC = null;
        }
    }

    public UPDATE_SUSP_HDR_DTL_ADD_DESC GetUPDATE_SUSP_HDR_DTL_ADD_DESC(int Level)
    {
        if (m_UPDATE_SUSP_HDR_DTL_ADD_DESC == null)
        {
            m_UPDATE_SUSP_HDR_DTL_ADD_DESC = new UPDATE_SUSP_HDR_DTL_ADD_DESC("UPDATE_SUSP_HDR_DTL_ADD_DESC", Level);
        }
        else
        {
            m_UPDATE_SUSP_HDR_DTL_ADD_DESC.ResetValues();
        }
        return m_UPDATE_SUSP_HDR_DTL_ADD_DESC;
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

            UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_HDR_1 UPDATE_F002_SUSPEND_HDR_1 = new UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_HDR_1(Name, Level);
            UPDATE_F002_SUSPEND_HDR_1.Run();
            UPDATE_F002_SUSPEND_HDR_1.Dispose();
            UPDATE_F002_SUSPEND_HDR_1 = null;

            UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DTL_2 UPDATE_F002_SUSPEND_DTL_2 = new UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DTL_2(Name, Level);
            UPDATE_F002_SUSPEND_DTL_2.Run();
            UPDATE_F002_SUSPEND_DTL_2.Dispose();
            UPDATE_F002_SUSPEND_DTL_2 = null;

            UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_ADDRESS_3 UPDATE_F002_SUSPEND_ADDRESS_3 = new UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_ADDRESS_3(Name, Level);
            UPDATE_F002_SUSPEND_ADDRESS_3.Run();
            UPDATE_F002_SUSPEND_ADDRESS_3.Dispose();
            UPDATE_F002_SUSPEND_ADDRESS_3 = null;

            UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DESC_4 UPDATE_F002_SUSPEND_DESC_4 = new UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DESC_4(Name, Level);
            UPDATE_F002_SUSPEND_DESC_4.Run();
            UPDATE_F002_SUSPEND_DESC_4.Dispose();
            UPDATE_F002_SUSPEND_DESC_4 = null;

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



public class UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_HDR_1 : UPDATE_SUSP_HDR_DTL_ADD_DESC
{

    public UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_HDR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVE_SUSPHDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVE_SUSPHDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_SUSPEND_HDR.SetItemFinals += fleF002_SUSPEND_HDR_SetItemFinals;
        fleF002_SUSPEND_HDR.Choose += fleF002_SUSPEND_HDR_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_HDR_1)"

    private SqlFileObject fleF002_SUSPEND_HDR;

    private void fleF002_SUSPEND_HDR_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", "U");
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", "U");
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_DOC_OHIP_NBR", 212464);
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_DOC_NBR", "07J");
            fleF002_SUSPEND_HDR.set_SetValue("SUSP_HDR_DOC_NBR", "07J");
            fleF002_SUSPEND_HDR.set_SetValue("SUSP_HDR_DOC_NBR", "07J");


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


    private void fleF002_SUSPEND_HDR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_SUSPEND_HDR.ElementOwner("CLMHDR_DOC_OHIP_NBR")).Append(" = ");
            strSQL.Append(196246);


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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_DOC_NBR")) == "97H" & QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_SPEC_CD")) == 13)
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




















    private SqlFileObject fleSAVE_SUSPHDR;


    #endregion


    #region "Standard Generated Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_HDR_1)"


    #region "Automatic Item Initialization(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_HDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_HDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:57 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleSAVE_SUSPHDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_HDR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:57 PM

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
            fleF002_SUSPEND_HDR.Dispose();
            fleSAVE_SUSPHDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_HDR_1)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F002_SUSPEND_HDR_1");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--

                if (Transaction())
                {

                     if (Select_If())
                    {



















                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVE_SUSPHDR, SubFileType.Keep, fleF002_SUSPEND_HDR);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_BATCH_NBR_REDEF)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:SUSPEND_HDR_ID)    'Parent:SUSPEND_HDR_ACR)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_FILLER1)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMDTL_DET_REC)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_CONSECUTIVE_SV_DAYS)    'Parent:CLMDTL_CONSEC_DATES_R_2)    'Parent:SUSPEND_DTL_ID)    'Parent:SUSPEND_ADDRESS_ID)    'Parent:SUSPEND_DTL_ID




















                        fleF002_SUSPEND_HDR.OutPut(OutPutType.Update);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_BATCH_NBR_REDEF)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:SUSPEND_HDR_ID)    'Parent:SUSPEND_HDR_ACR)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_FILLER1)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMDTL_DET_REC)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_CONSECUTIVE_SV_DAYS)    'Parent:CLMDTL_CONSEC_DATES_R_2)    'Parent:SUSPEND_DTL_ID)    'Parent:SUSPEND_ADDRESS_ID)    'Parent:SUSPEND_DTL_ID

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
            EndRequest("UPDATE_F002_SUSPEND_HDR_1");

        }

    }




    #endregion


}
//UPDATE_F002_SUSPEND_HDR_1



public class UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DTL_2 : UPDATE_SUSP_HDR_DTL_ADD_DESC
{

    public UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DTL_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSAVE_SUSPHDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVE_SUSPHDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVE_SUSPDTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVE_SUSPDTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_SUSPEND_DTL.SetItemFinals += fleF002_SUSPEND_DTL_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DTL_2)"

    private SqlFileObject fleSAVE_SUSPHDR;
    private SqlFileObject fleF002_SUSPEND_DTL;

    private void fleF002_SUSPEND_DTL_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_DTL.set_SetValue("CLMDTL_DOC_OHIP_NBR", 212464);


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




















    private SqlFileObject fleSAVE_SUSPDTL;


    #endregion


    #region "Standard Generated Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DTL_2)"


    #region "Automatic Item Initialization(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DTL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DTL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:57 PM

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
        fleSAVE_SUSPHDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DTL.Transaction = m_trnTRANS_UPDATE;
        fleSAVE_SUSPDTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DTL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:57 PM

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
            fleSAVE_SUSPHDR.Dispose();
            fleF002_SUSPEND_DTL.Dispose();
            fleSAVE_SUSPDTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DTL_2)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F002_SUSPEND_DTL_2");

            while (fleSAVE_SUSPHDR.QTPForMissing())
            {
                // --> GET SAVE_SUSPHDR <--

                fleSAVE_SUSPHDR.GetData();
                // --> End GET SAVE_SUSPHDR <--

                while (fleF002_SUSPEND_DTL.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleSAVE_SUSPHDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSAVE_SUSPHDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_DTL.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_DTL <--


                    if (Transaction())
                    {


















                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVE_SUSPDTL, SubFileType.Keep, fleF002_SUSPEND_DTL);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_BATCH_NBR_REDEF)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:SUSPEND_HDR_ID)    'Parent:SUSPEND_HDR_ACR)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_FILLER1)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMDTL_DET_REC)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_CONSECUTIVE_SV_DAYS)    'Parent:CLMDTL_CONSEC_DATES_R_2)    'Parent:SUSPEND_DTL_ID)    'Parent:SUSPEND_ADDRESS_ID)    'Parent:SUSPEND_DTL_ID




















                        fleF002_SUSPEND_DTL.OutPut(OutPutType.Update);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_BATCH_NBR_REDEF)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:SUSPEND_HDR_ID)    'Parent:SUSPEND_HDR_ACR)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_FILLER1)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMDTL_DET_REC)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_CONSECUTIVE_SV_DAYS)    'Parent:CLMDTL_CONSEC_DATES_R_2)    'Parent:SUSPEND_DTL_ID)    'Parent:SUSPEND_ADDRESS_ID)    'Parent:SUSPEND_DTL_ID

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
            EndRequest("UPDATE_F002_SUSPEND_DTL_2");

        }

    }




    #endregion


}
//UPDATE_F002_SUSPEND_DTL_2



public class UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_ADDRESS_3 : UPDATE_SUSP_HDR_DTL_ADD_DESC
{

    public UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_ADDRESS_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSAVE_SUSPHDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVE_SUSPHDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_SUSPEND_ADDRESS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_ADDRESS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVE_SUSPADDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVE_SUSPADDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_SUSPEND_ADDRESS.SetItemFinals += fleF002_SUSPEND_ADDRESS_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_ADDRESS_3)"

    private SqlFileObject fleSAVE_SUSPHDR;
    private SqlFileObject fleF002_SUSPEND_ADDRESS;

    private void fleF002_SUSPEND_ADDRESS_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_ADDRESS.set_SetValue("ADD_DOC_OHIP_NBR", 212464);


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




















    private SqlFileObject fleSAVE_SUSPADDR;


    #endregion


    #region "Standard Generated Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_ADDRESS_3)"


    #region "Automatic Item Initialization(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_ADDRESS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_ADDRESS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:57 PM

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
        fleSAVE_SUSPHDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_ADDRESS.Transaction = m_trnTRANS_UPDATE;
        fleSAVE_SUSPADDR.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_ADDRESS_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:57 PM

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
            fleSAVE_SUSPHDR.Dispose();
            fleF002_SUSPEND_ADDRESS.Dispose();
            fleSAVE_SUSPADDR.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_ADDRESS_3)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F002_SUSPEND_ADDRESS_3");

            while (fleSAVE_SUSPHDR.QTPForMissing())
            {
                // --> GET SAVE_SUSPHDR <--

                fleSAVE_SUSPHDR.GetData();
                // --> End GET SAVE_SUSPHDR <--

                while (fleF002_SUSPEND_ADDRESS.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_ADDRESS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_ADDRESS.ElementOwner("ADD_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleSAVE_SUSPHDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_ADDRESS.ElementOwner("ADD_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSAVE_SUSPHDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_ADDRESS.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_ADDRESS <--


                    if (Transaction())
                    {


















                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVE_SUSPADDR, SubFileType.Keep, fleF002_SUSPEND_ADDRESS);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_BATCH_NBR_REDEF)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:SUSPEND_HDR_ID)    'Parent:SUSPEND_HDR_ACR)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_FILLER1)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMDTL_DET_REC)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_CONSECUTIVE_SV_DAYS)    'Parent:CLMDTL_CONSEC_DATES_R_2)    'Parent:SUSPEND_DTL_ID)    'Parent:SUSPEND_ADDRESS_ID)    'Parent:SUSPEND_DTL_ID




















                        fleF002_SUSPEND_ADDRESS.OutPut(OutPutType.Update);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_BATCH_NBR_REDEF)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:SUSPEND_HDR_ID)    'Parent:SUSPEND_HDR_ACR)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_FILLER1)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMDTL_DET_REC)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_CONSECUTIVE_SV_DAYS)    'Parent:CLMDTL_CONSEC_DATES_R_2)    'Parent:SUSPEND_DTL_ID)    'Parent:SUSPEND_ADDRESS_ID)    'Parent:SUSPEND_DTL_ID

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
            EndRequest("UPDATE_F002_SUSPEND_ADDRESS_3");

        }

    }




    #endregion


}
//UPDATE_F002_SUSPEND_ADDRESS_3



public class UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DESC_4 : UPDATE_SUSP_HDR_DTL_ADD_DESC
{

    public UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DESC_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSAVE_SUSPHDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVE_SUSPHDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_SUSPEND_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_SUSPEND_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSAVE_SUSPDESC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SAVE_SUSPDESC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_SUSPEND_DESC.SetItemFinals += fleF002_SUSPEND_DESC_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DESC_4)"

    private SqlFileObject fleSAVE_SUSPHDR;
    private SqlFileObject fleF002_SUSPEND_DESC;

    private void fleF002_SUSPEND_DESC_SetItemFinals()
    {

        try
        {
            fleF002_SUSPEND_DESC.set_SetValue("CLMDTL_DOC_OHIP_NBR", 212464);


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




















    private SqlFileObject fleSAVE_SUSPDESC;


    #endregion


    #region "Standard Generated Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DESC_4)"


    #region "Automatic Item Initialization(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DESC_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DESC_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:57 PM

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
        fleSAVE_SUSPHDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DESC.Transaction = m_trnTRANS_UPDATE;
        fleSAVE_SUSPDESC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DESC_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:51:57 PM

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
            fleSAVE_SUSPHDR.Dispose();
            fleF002_SUSPEND_DESC.Dispose();
            fleSAVE_SUSPDESC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UPDATE_SUSP_HDR_DTL_ADD_DESC_UPDATE_F002_SUSPEND_DESC_4)"


    public void Run()
    {

        try
        {
            Request("UPDATE_F002_SUSPEND_DESC_4");

            while (fleSAVE_SUSPHDR.QTPForMissing())
            {
                // --> GET SAVE_SUSPHDR <--

                fleSAVE_SUSPHDR.GetData();
                // --> End GET SAVE_SUSPHDR <--

                while (fleF002_SUSPEND_DESC.QTPForMissing("1"))
                {
                    // --> GET F002_SUSPEND_DESC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleSAVE_SUSPHDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSAVE_SUSPHDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF002_SUSPEND_DESC.GetData(m_strWhere.ToString());
                    // --> End GET F002_SUSPEND_DESC <--


                    if (Transaction())
                    {


















                        SubFile(ref m_trnTRANS_UPDATE, ref fleSAVE_SUSPDESC, SubFileType.Keep, fleF002_SUSPEND_DESC);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_BATCH_NBR_REDEF)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:SUSPEND_HDR_ID)    'Parent:SUSPEND_HDR_ACR)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_FILLER1)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMDTL_DET_REC)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_CONSECUTIVE_SV_DAYS)    'Parent:CLMDTL_CONSEC_DATES_R_2)    'Parent:SUSPEND_DTL_ID)    'Parent:SUSPEND_ADDRESS_ID)    'Parent:SUSPEND_DTL_ID




















                        fleF002_SUSPEND_DESC.OutPut(OutPutType.Update);
                        //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_BATCH_NBR_REDEF)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:SUSPEND_HDR_ID)    'Parent:SUSPEND_HDR_ACR)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_FILLER1)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMDTL_DET_REC)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMDTL_CONSEC_DATES_R)    'Parent:CLMDTL_CONSECUTIVE_SV_DAYS)    'Parent:CLMDTL_CONSEC_DATES_R_2)    'Parent:SUSPEND_DTL_ID)    'Parent:SUSPEND_ADDRESS_ID)    'Parent:SUSPEND_DTL_ID

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
            EndRequest("UPDATE_F002_SUSPEND_DESC_4");

        }

    }




    #endregion


}
//UPDATE_F002_SUSPEND_DESC_4




