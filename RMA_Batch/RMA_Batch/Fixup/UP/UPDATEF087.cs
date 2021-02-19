
#region "Screen Comments"



#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UPDATEF087 : BaseClassControl
{

    private UPDATEF087 m_UPDATEF087;

    public UPDATEF087(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UPDATEF087(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UPDATEF087 != null))
        {
            m_UPDATEF087.CloseTransactionObjects();
            m_UPDATEF087 = null;
        }
    }

    public UPDATEF087 GetUPDATEF087(int Level)
    {
        if (m_UPDATEF087 == null)
        {
            m_UPDATEF087 = new UPDATEF087("UPDATEF087", Level);
        }
        else
        {
            m_UPDATEF087.ResetValues();
        }
        return m_UPDATEF087;
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

            UPDATEF087_F087_1 F087_1 = new UPDATEF087_F087_1(Name, Level);
            F087_1.Run();
            F087_1.Dispose();
            F087_1 = null;

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



public class UPDATEF087_F087_1 : UPDATEF087
{

    public UPDATEF087_F087_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF087SUBMITTEDREJECTEDCLAIMSHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF087SUBMITTEDREJECTEDCLAIMSDTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF087 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F087", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF087SUBMITTEDREJECTEDCLAIMSHDR.SetItemFinals += fleF087SUBMITTEDREJECTEDCLAIMSHDR_SetItemFinals;
        fleF087SUBMITTEDREJECTEDCLAIMSHDR.Choose += fleF087SUBMITTEDREJECTEDCLAIMSHDR_Choose;
        fleF087SUBMITTEDREJECTEDCLAIMSDTL.InitializeItems += fleF087SUBMITTEDREJECTEDCLAIMSDTL_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(UPDATEF087_F087_1)"

    private SqlFileObject fleF087SUBMITTEDREJECTEDCLAIMSHDR;

    private void fleF087SUBMITTEDREJECTEDCLAIMSHDR_SetItemFinals()
    {

        try
        {
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("CHARGE_STATUS", "C");
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("CHARGE_STATUS", "C");


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

    private SqlFileObject fleF087SUBMITTEDREJECTEDCLAIMSDTL;

    private void fleF087SUBMITTEDREJECTEDCLAIMSHDR_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF087SUBMITTEDREJECTEDCLAIMSHDR.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField(("2205T001@").PadRight(10).Substring(0, 8)));
            //Parent:SUBMITTED_REJECTED_CLAIM
            strSQL.Append(" AND ").Append(fleF087SUBMITTEDREJECTEDCLAIMSHDR.ElementOwner("CLMHDR_CLAIM_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField(("2205T001@").PadRight(10).Substring(8, 2)));
            //Parent:SUBMITTED_REJECTED_CLAIM


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
            if (QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("OHIP_ERR_CODE")) == "A4D")
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



    private SqlFileObject fleF087;


    #endregion


    #region "Standard Generated Procedures(UPDATEF087_F087_1)"


    #region "Automatic Item Initialization(UPDATEF087_F087_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:17 PM

    //#-----------------------------------------
    //# fleF087SUBMITTEDREJECTEDCLAIMSDTL_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 2:52:16 PM
    //#-----------------------------------------
    private void fleF087SUBMITTEDREJECTEDCLAIMSDTL_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.set_SetValue("PED", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("PED"));
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.set_SetValue("CLMHDR_BATCH_NBR", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("CLMHDR_BATCH_NBR"));
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.set_SetValue("CLMHDR_CLAIM_NBR", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.set_SetValue("EDT_PROCESS_DATE", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("EDT_PROCESS_DATE"));
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.set_SetValue("ENTRY_DATE", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("ENTRY_DATE"));
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.set_SetValue("ENTRY_TIME_LONG", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("ENTRY_TIME_LONG"));
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.set_SetValue("ENTRY_USER_ID", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("ENTRY_USER_ID"));
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.set_SetValue("LAST_MOD_DATE", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("LAST_MOD_DATE"));
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.set_SetValue("LAST_MOD_TIME", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("LAST_MOD_TIME"));
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("LAST_MOD_USER_ID"));

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


    #region "Transaction Management Procedures(UPDATEF087_F087_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:16 PM

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
        fleF087SUBMITTEDREJECTEDCLAIMSHDR.Transaction = m_trnTRANS_UPDATE;
        fleF087SUBMITTEDREJECTEDCLAIMSDTL.Transaction = m_trnTRANS_UPDATE;
        fleF087.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UPDATEF087_F087_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:52:16 PM

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
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.Dispose();
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.Dispose();
            fleF087.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UPDATEF087_F087_1)"


    public void Run()
    {

        try
        {
            Request("F087_1");

            while (fleF087SUBMITTEDREJECTEDCLAIMSHDR.QTPForMissing())
            {
                // --> GET F087SUBMITTEDREJECTEDCLAIMSHDR <--

                fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetData();
                // --> End GET F087SUBMITTEDREJECTEDCLAIMSHDR <--

                while (fleF087SUBMITTEDREJECTEDCLAIMSDTL.QTPForMissing("1"))
                {
                    // --> GET F087SUBMITTEDREJECTEDCLAIMSDTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF087SUBMITTEDREJECTEDCLAIMSDTL.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("CLMHDR_BATCH_NBR")));
                    //Parent:SUBMITTED_REJECTED_CLAIM    'Parent:SUBMITTED_REJECTED_CLAIM
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF087SUBMITTEDREJECTEDCLAIMSDTL.ElementOwner("CLMHDR_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2)).PadRight(10).Substring(8, 2)));
                    //Parent:SUBMITTED_REJECTED_CLAIM    'Parent:SUBMITTED_REJECTED_CLAIM
                    m_strWhere.Append(GetWhereClauseString(fleF087SUBMITTEDREJECTEDCLAIMSDTL.ElementOwner("PED"), "=", fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetNumericDateValue("PED")));
                    m_strWhere.Append(GetWhereClauseString(fleF087SUBMITTEDREJECTEDCLAIMSDTL.ElementOwner("EDT_PROCESS_DATE"), "=", fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetNumericDateValue("EDT_PROCESS_DATE")));

                    fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F087SUBMITTEDREJECTEDCLAIMSDTL <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetSortValue("CLMHDR_BATCH_NBR"), fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetSortValue("CLMHDR_CLAIM_NBR"), fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetSortValue("PED"), fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetSortValue("EDT_PROCESS_DATE"));
                            //Parent:SUBMITTED_REJECTED_CLAIM


                        }

                    }

                }

            }


            while (Sort(fleF087SUBMITTEDREJECTEDCLAIMSHDR, fleF087SUBMITTEDREJECTEDCLAIMSDTL))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleF087, SubFileType.Keep, fleF087SUBMITTEDREJECTEDCLAIMSHDR, "SUBMITTED_REJECTED_CLAIM", "EDT_PROCESS_DATE", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_SERVICE_DATE", fleF087SUBMITTEDREJECTEDCLAIMSHDR, "CHARGE_STATUS",
                "CHARGE_STATUS");
                //Parent:SUBMITTED_REJECTED_CLAIM)    'Parent:SUBMITTED_REJECTED_CLAIM


                fleF087SUBMITTEDREJECTEDCLAIMSHDR.OutPut(OutPutType.Update, fleF087SUBMITTEDREJECTEDCLAIMSHDR.At("SUBMITTED_REJECTED_CLAIM") || fleF087SUBMITTEDREJECTEDCLAIMSHDR.At("PED") || fleF087SUBMITTEDREJECTEDCLAIMSHDR.At("EDT_PROCESS_DATE"), null);
                //Parent:SUBMITTED_REJECTED_CLAIM)    'Parent:SUBMITTED_REJECTED_CLAIM

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
            EndRequest("F087_1");

        }

    }




    #endregion


}
//F087_1




