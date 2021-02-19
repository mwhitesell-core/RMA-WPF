
#region "Screen Comments"

// #> PROGRAM-ID.    u095.qts
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : DELETE THE  CLAIMS  BATCH CONTROL RECORDS IN THE
// BATCH CONTROL FILE (F001) FOR ALL  CLAIMS  BATCHES THAT
// HAVE BEEN PROCESSED INTO THE CLAIMS AUDIT
// SECTION (IE. THEIR STATUS = `4`) WHOSE P.E.D. FALLS
// WITH RANGE AS INPUT BY OPERATOR.
// AN AUDIT REPORT IS PRINTED OF ALL BATCHES DELETED
// AND WITH TOTALS BY TYPE OF BATCH.
// MODIFICATION HISTORY
// DATE      WHO        DESCRIPTION
// 2000/04/28   B.Annis    Originally converted from u072.cbl
// 2003/dec/15  A.A.   alpha doctor nbr


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U095 : BaseClassControl
{

    private U095 m_U095;

    public U095(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U095(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U095 != null))
        {
            m_U095.CloseTransactionObjects();
            m_U095 = null;
        }
    }

    public U095 GetU095(int Level)
    {
        if (m_U095 == null)
        {
            m_U095 = new U095("U095", Level);
        }
        else
        {
            m_U095.ResetValues();
        }
        return m_U095;
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

            U095_DELETE_CLAIM_BATCHES_1 DELETE_CLAIM_BATCHES_1 = new U095_DELETE_CLAIM_BATCHES_1(Name, Level);
            DELETE_CLAIM_BATCHES_1.Run();
            DELETE_CLAIM_BATCHES_1.Dispose();
            DELETE_CLAIM_BATCHES_1 = null;

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



public class U095_DELETE_CLAIM_BATCHES_1 : U095
{

    public U095_DELETE_CLAIM_BATCHES_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU095_DELETE_BATCH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U095_DELETE_BATCH", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU095_RETAIN_BATCH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U095_RETAIN_BATCH", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF001_BATCH_CONTROL_FILE.Choose += fleF001_BATCH_CONTROL_FILE_Choose;
        D_DATE.GetValue += D_DATE_GetValue;
        D_CUT_OFF_DATE.GetValue += D_CUT_OFF_DATE_GetValue;
        D_BATCTRL_DATE_PERIOD_END.GetValue += D_BATCTRL_DATE_PERIOD_END_GetValue;
        D_DELETE_FLAG.GetValue += D_DELETE_FLAG_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U095_DELETE_CLAIM_BATCHES_1)"

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;
    private SqlFileObject fleICONST_MSTR_REC;

    private void fleF001_BATCH_CONTROL_FILE_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            if ((Prompt(1).ToString() != null) && Prompt(2).ToString().Length > 0)
            {
                strSQL.Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR"));
                strSQL.Append(" BETWEEN ");
                strSQL.Append(Common.StringToField(Prompt(2).ToString())).Append(" AND ").Append(Common.StringToField(Prompt(2).ToString()));

            }

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

    private DDecimal D_DATE = new DDecimal("D_DATE");
    private void D_DATE_GetValue(ref decimal Value)
    {

        try
        {
            Value = (Convert.ToDecimal(Prompt(3)));


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
    private DDecimal D_CUT_OFF_DATE = new DDecimal("D_CUT_OFF_DATE");
    private void D_CUT_OFF_DATE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(D_DATE.Value) == 0)
            {
                CurrentValue = fleICONST_MSTR_REC.GetNumericDateValue("ICONST_DATE_PERIOD_END");
            }
            else
            {
                CurrentValue = D_DATE.Value;
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
    private DDecimal D_BATCTRL_DATE_PERIOD_END = new DDecimal("D_BATCTRL_DATE_PERIOD_END");
    private void D_BATCTRL_DATE_PERIOD_END_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_DATE_PERIOD_END"));


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
    private DCharacter D_DELETE_FLAG = new DCharacter("D_DELETE_FLAG", 1);
    private void D_DELETE_FLAG_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "C" & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS")) == "4" & D_BATCTRL_DATE_PERIOD_END.Value <= D_CUT_OFF_DATE.Value)
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "N";
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

    private SqlFileObject fleU095_DELETE_BATCH;

    private SqlFileObject fleU095_RETAIN_BATCH;


    #endregion


    #region "Standard Generated Procedures(U095_DELETE_CLAIM_BATCHES_1)"


    #region "Automatic Item Initialization(U095_DELETE_CLAIM_BATCHES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U095_DELETE_CLAIM_BATCHES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:39 PM

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
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU095_DELETE_BATCH.Transaction = m_trnTRANS_UPDATE;
        fleU095_RETAIN_BATCH.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U095_DELETE_CLAIM_BATCHES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:39 PM

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
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU095_DELETE_BATCH.Dispose();
            fleU095_RETAIN_BATCH.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U095_DELETE_CLAIM_BATCHES_1)"


    public void Run()
    {

        try
        {
            Request("DELETE_CLAIM_BATCHES_1");

            while (fleF001_BATCH_CONTROL_FILE.QTPForMissing())
            {
                // --> GET F001_BATCH_CONTROL_FILE <--

                fleF001_BATCH_CONTROL_FILE.GetData();
                // --> End GET F001_BATCH_CONTROL_FILE <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    // --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 1, 2))));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                    // --> End GET ICONST_MSTR_REC <--


                    if (Transaction())
                    {

                        SubFile(ref m_trnTRANS_UPDATE, ref fleU095_DELETE_BATCH, QDesign.NULL(D_DELETE_FLAG.Value) == "Y", SubFileType.Keep, fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", D_CUT_OFF_DATE, fleF001_BATCH_CONTROL_FILE);



                        SubFile(ref m_trnTRANS_UPDATE, ref fleU095_RETAIN_BATCH, QDesign.NULL(D_DELETE_FLAG.Value) == "N", SubFileType.Keep, fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", D_CUT_OFF_DATE, fleF001_BATCH_CONTROL_FILE);



                        fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Delete, null, D_DELETE_FLAG.Value == "Y");



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
            EndRequest("DELETE_CLAIM_BATCHES_1");

        }

    }




    #endregion


}
//DELETE_CLAIM_BATCHES_1




