
#region "Screen Comments"

// Program: maria_rejects1.qts
// Purpose: create subfile of submission errors to pass to maria_rejects1.qzs
// Mod Hist
// 2003/nov/28 b.e. - orig
// 2004/may/18 M.C. - alpha doc nbr


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class MARIA_REJECTS1 : BaseClassControl
{

    private MARIA_REJECTS1 m_MARIA_REJECTS1;

    public MARIA_REJECTS1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public MARIA_REJECTS1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_MARIA_REJECTS1 != null))
        {
            m_MARIA_REJECTS1.CloseTransactionObjects();
            m_MARIA_REJECTS1 = null;
        }
    }

    public MARIA_REJECTS1 GetMARIA_REJECTS1(int Level)
    {
        if (m_MARIA_REJECTS1 == null)
        {
            m_MARIA_REJECTS1 = new MARIA_REJECTS1("MARIA_REJECTS1", Level);
        }
        else
        {
            m_MARIA_REJECTS1.ResetValues();
        }
        return m_MARIA_REJECTS1;
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

            MARIA_REJECTS1_MARIA_1_1 MARIA_1_1 = new MARIA_REJECTS1_MARIA_1_1(Name, Level);
            MARIA_1_1.Run();
            MARIA_1_1.Dispose();
            MARIA_1_1 = null;

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



public class MARIA_REJECTS1_MARIA_1_1 : MARIA_REJECTS1
{

    public MARIA_REJECTS1_MARIA_1_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF087SUBMITTEDREJECTEDCLAIMSDTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF087SUBMITTEDREJECTEDCLAIMSHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F087_SUBMITTED_REJECTED_CLAIMS_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CLAIM_REC_COUNT = new CoreDecimal("X_CLAIM_REC_COUNT", 6, this);
        fleMARIA_1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "MARIA_REJECTS1", "MARIA_1", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleMARIA_2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "MARIA_REJECTS1", "MARIA_2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleMARIA_3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "MARIA_REJECTS1", "MARIA_3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleMARIA_4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "MARIA_REJECTS1", "MARIA_4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleMARIA_5 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "MARIA_REJECTS1", "MARIA_5", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        DOC_NBR.GetValue += DOC_NBR_GetValue;
        fleF087SUBMITTEDREJECTEDCLAIMSHDR.InitializeItems += fleF087SUBMITTEDREJECTEDCLAIMSHDR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(MARIA_REJECTS1_MARIA_1_1)"

    private SqlFileObject fleF087SUBMITTEDREJECTEDCLAIMSDTL;
    private SqlFileObject fleF087SUBMITTEDREJECTEDCLAIMSHDR;
    private DCharacter DOC_NBR = new DCharacter("DOC_NBR", 3);
    private void DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2), 3, 3);
            //Parent:SUBMITTED_REJECTED_CLAIM


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

    private CoreDecimal X_CLAIM_REC_COUNT;

    private SqlFileObject fleMARIA_1;


    private SqlFileObject fleMARIA_2;


    private SqlFileObject fleMARIA_3;


    private SqlFileObject fleMARIA_4;


    private SqlFileObject fleMARIA_5;


    #endregion


    #region "Standard Generated Procedures(MARIA_REJECTS1_MARIA_1_1)"


    #region "Automatic Item Initialization(MARIA_REJECTS1_MARIA_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:24 PM

    //#-----------------------------------------
    //# fleF087SUBMITTEDREJECTEDCLAIMSHDR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:04:14 PM
    //#-----------------------------------------
    private void fleF087SUBMITTEDREJECTEDCLAIMSHDR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("CLMHDR_BATCH_NBR", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("CLMHDR_BATCH_NBR"));
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("CLMHDR_CLAIM_NBR", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("PED", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetDecimalValue("PED"));
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("EDT_PROCESS_DATE", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetDecimalValue("EDT_PROCESS_DATE"));
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("ENTRY_DATE", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetDecimalValue("ENTRY_DATE"));
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("ENTRY_TIME_LONG", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetDecimalValue("ENTRY_TIME_LONG"));
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("ENTRY_USER_ID", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("ENTRY_USER_ID"));
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("LAST_MOD_DATE", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetDecimalValue("LAST_MOD_DATE"));
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("LAST_MOD_TIME", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetDecimalValue("LAST_MOD_TIME"));
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.set_SetValue("LAST_MOD_USER_ID", !Fixed, fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("LAST_MOD_USER_ID"));

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


    #region "Transaction Management Procedures(MARIA_REJECTS1_MARIA_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:14 PM

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
        fleF087SUBMITTEDREJECTEDCLAIMSDTL.Transaction = m_trnTRANS_UPDATE;
        fleF087SUBMITTEDREJECTEDCLAIMSHDR.Transaction = m_trnTRANS_UPDATE;
        fleMARIA_1.Transaction = m_trnTRANS_UPDATE;
        fleMARIA_2.Transaction = m_trnTRANS_UPDATE;
        fleMARIA_3.Transaction = m_trnTRANS_UPDATE;
        fleMARIA_4.Transaction = m_trnTRANS_UPDATE;
        fleMARIA_5.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(MARIA_REJECTS1_MARIA_1_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:14 PM

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
            fleF087SUBMITTEDREJECTEDCLAIMSDTL.Dispose();
            fleF087SUBMITTEDREJECTEDCLAIMSHDR.Dispose();
            fleMARIA_1.Dispose();
            fleMARIA_2.Dispose();
            fleMARIA_3.Dispose();
            fleMARIA_4.Dispose();
            fleMARIA_5.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(MARIA_REJECTS1_MARIA_1_1)"


    public void Run()
    {

        try
        {
            Request("MARIA_1_1");

            while (fleF087SUBMITTEDREJECTEDCLAIMSDTL.QTPForMissing())
            {
                // --> GET F087SUBMITTEDREJECTEDCLAIMSDTL <--

                fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetData();
                // --> End GET F087SUBMITTEDREJECTEDCLAIMSDTL <--

                while (fleF087SUBMITTEDREJECTEDCLAIMSHDR.QTPForMissing("1"))
                {
                    // --> GET F087SUBMITTEDREJECTEDCLAIMSHDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF087SUBMITTEDREJECTEDCLAIMSHDR.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("CLMHDR_BATCH_NBR")));
                    //Parent:SUBMITTED_REJECTED_CLAIM    'Parent:SUBMITTED_REJECTED_CLAIM
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF087SUBMITTEDREJECTEDCLAIMSHDR.ElementOwner("CLMHDR_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2)).PadRight(10).Substring(8, 2)));
                    //Parent:SUBMITTED_REJECTED_CLAIM    'Parent:SUBMITTED_REJECTED_CLAIM

                    fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetData(m_strWhere.ToString());
                    // --> End GET F087SUBMITTEDREJECTEDCLAIMSHDR <--


                    if (Transaction())
                    {

                        Sort(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetSortValue("CLMHDR_BATCH_NBR"), fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetSortValue("CLMHDR_CLAIM_NBR"));
                        //Parent:SUBMITTED_REJECTED_CLAIM



                    }

                }

            }

            while (Sort(fleF087SUBMITTEDREJECTEDCLAIMSDTL, fleF087SUBMITTEDREJECTEDCLAIMSHDR))
            {
                X_CLAIM_REC_COUNT.Value = X_CLAIM_REC_COUNT.Value + 1;


                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_1, QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("EDT_ERR_H_CD_1")) != QDesign.NULL(" ") & QDesign.NULL(X_CLAIM_REC_COUNT.Value) == 1, SubFileType.Keep, DOC_NBR, fleF087SUBMITTEDREJECTEDCLAIMSDTL, "SUBMITTED_REJECTED_CLAIM", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED",
                fleF087SUBMITTEDREJECTEDCLAIMSHDR, "EDT_ERR_H_CD_1", "EDT_ERR_H_CD_1", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_DTL_ERR_CD_1", "EDT_DTL_ERR_CD_1");



                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_2, QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("EDT_ERR_H_CD_2")) != QDesign.NULL(" ") & QDesign.NULL(X_CLAIM_REC_COUNT.Value) == 1, SubFileType.Keep, DOC_NBR, fleF087SUBMITTEDREJECTEDCLAIMSDTL, "SUBMITTED_REJECTED_CLAIM", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED",
                fleF087SUBMITTEDREJECTEDCLAIMSHDR, "EDT_ERR_H_CD_2", "EDT_ERR_H_CD_2", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_DTL_ERR_CD_2", "EDT_DTL_ERR_CD_2");



                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_3, QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("EDT_ERR_H_CD_3")) != QDesign.NULL(" ") & QDesign.NULL(X_CLAIM_REC_COUNT.Value) == 1, SubFileType.Keep, DOC_NBR, fleF087SUBMITTEDREJECTEDCLAIMSDTL, "SUBMITTED_REJECTED_CLAIM", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED",
                fleF087SUBMITTEDREJECTEDCLAIMSHDR, "EDT_ERR_H_CD_3", "EDT_ERR_H_CD_3", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_DTL_ERR_CD_3", "EDT_DTL_ERR_CD_3");



                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_4, QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("EDT_ERR_H_CD_4")) != QDesign.NULL(" ") & QDesign.NULL(X_CLAIM_REC_COUNT.Value) == 1, SubFileType.Keep, DOC_NBR, fleF087SUBMITTEDREJECTEDCLAIMSDTL, "SUBMITTED_REJECTED_CLAIM", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED",
                fleF087SUBMITTEDREJECTEDCLAIMSHDR, "EDT_ERR_H_CD_4", "EDT_ERR_H_CD_4", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_DTL_ERR_CD_4", "EDT_DTL_ERR_CD_4");



                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_5, QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSHDR.GetStringValue("EDT_ERR_H_CD_5")) != QDesign.NULL(" ") & QDesign.NULL(X_CLAIM_REC_COUNT.Value) == 1, SubFileType.Keep, DOC_NBR, fleF087SUBMITTEDREJECTEDCLAIMSDTL, "SUBMITTED_REJECTED_CLAIM", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED",
                fleF087SUBMITTEDREJECTEDCLAIMSHDR, "EDT_ERR_H_CD_5", "EDT_ERR_H_CD_5", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_DTL_ERR_CD_5", "EDT_DTL_ERR_CD_5");



                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_1, QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("EDT_DTL_ERR_CD_1")) != QDesign.NULL(" "), SubFileType.Keep, DOC_NBR, fleF087SUBMITTEDREJECTEDCLAIMSDTL, "SUBMITTED_REJECTED_CLAIM", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED",
                fleF087SUBMITTEDREJECTEDCLAIMSHDR, "EDT_ERR_H_CD_1", "EDT_ERR_H_CD_1", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_DTL_ERR_CD_1", "EDT_DTL_ERR_CD_1");



                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_2, QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("EDT_DTL_ERR_CD_2")) != QDesign.NULL(" "), SubFileType.Keep, DOC_NBR, fleF087SUBMITTEDREJECTEDCLAIMSDTL, "SUBMITTED_REJECTED_CLAIM", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED",
                fleF087SUBMITTEDREJECTEDCLAIMSHDR, "EDT_ERR_H_CD_2", "EDT_ERR_H_CD_2", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_DTL_ERR_CD_2", "EDT_DTL_ERR_CD_2");



                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_3, QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("EDT_DTL_ERR_CD_3")) != QDesign.NULL(" "), SubFileType.Keep, DOC_NBR, fleF087SUBMITTEDREJECTEDCLAIMSDTL, "SUBMITTED_REJECTED_CLAIM", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED",
                fleF087SUBMITTEDREJECTEDCLAIMSHDR, "EDT_ERR_H_CD_3", "EDT_ERR_H_CD_3", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_DTL_ERR_CD_3", "EDT_DTL_ERR_CD_3");



                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_4, QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("EDT_DTL_ERR_CD_4")) != QDesign.NULL(" "), SubFileType.Keep, DOC_NBR, fleF087SUBMITTEDREJECTEDCLAIMSDTL, "SUBMITTED_REJECTED_CLAIM", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED",
                fleF087SUBMITTEDREJECTEDCLAIMSHDR, "EDT_ERR_H_CD_4", "EDT_ERR_H_CD_4", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_DTL_ERR_CD_4", "EDT_DTL_ERR_CD_4");



                SubFile(ref m_trnTRANS_UPDATE, ref fleMARIA_5, QDesign.NULL(fleF087SUBMITTEDREJECTEDCLAIMSDTL.GetStringValue("EDT_DTL_ERR_CD_5")) != QDesign.NULL(" "), SubFileType.Keep, DOC_NBR, fleF087SUBMITTEDREJECTEDCLAIMSDTL, "SUBMITTED_REJECTED_CLAIM", "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "PED",
                fleF087SUBMITTEDREJECTEDCLAIMSHDR, "EDT_ERR_H_CD_5", "EDT_ERR_H_CD_5", fleF087SUBMITTEDREJECTEDCLAIMSDTL, "EDT_DTL_ERR_CD_5", "EDT_DTL_ERR_CD_5");



                Reset(ref X_CLAIM_REC_COUNT, fleF087SUBMITTEDREJECTEDCLAIMSDTL.At("SUBMITTED_REJECTED_CLAIM"));

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
            EndRequest("MARIA_1_1");

        }

    }




    #endregion


}
//MARIA_1_1




