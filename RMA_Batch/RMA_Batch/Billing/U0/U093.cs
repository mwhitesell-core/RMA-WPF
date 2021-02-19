
#region "Screen Comments"

// #> PROGRAM-ID.    u093.qts
// ((C)) Dyad Technologies
// PROGRAM PURPOSE :  DELETE THE ADJUSTMENT AND PAYMENT BATCH CONTROL
// RECORDS FROM THE BATCH CONTROL FILE (F001) AND
// THE ASSOCIATED RECORDS FOR THESE BATCHS IN THE
// CLAIMS MASTER FILE (F002). BATCHES ARE SELECTED
// BY P.E.D. FALLING WITHIN OPERATOR INPUT CUT-OFF DATE.
// AN AUDIT REPORT IS PRINTED OF ALL BATCHES DELETED,
// WITH TOTALS BY BATCH TYPE
// MODIFICATION HISTORY
// DATE   WHO     DESCRIPTION
// 03/dec/15 A.A. alpha doctor nbr


#endregion

using Core.DataAccess.SqlServer;
using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U093 : BaseClassControl
{

    private U093 m_U093;

    public U093(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U093(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U093 != null))
        {
            m_U093.CloseTransactionObjects();
            m_U093 = null;
        }
    }

    public U093 GetU093(int Level)
    {
        if (m_U093 == null)
        {
            m_U093 = new U093("U093", Level);
        }
        else
        {
            m_U093.ResetValues();
        }
        return m_U093;
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

            U093_ONE_1 ONE_1 = new U093_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

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



public class U093_ONE_1 : U093
{

    public U093_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU093_DELETE_BATCH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U093_DELETE_BATCH", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU093_RETAIN_BATCH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U093_RETAIN_BATCH", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF001_BATCH_CONTROL_FILE.Choose += fleF001_BATCH_CONTROL_FILE_Choose;
        D_DATE.GetValue += D_DATE_GetValue;
        D_CUT_OFF_DATE.GetValue += D_CUT_OFF_DATE_GetValue;
        D_BATCTRL_DATE_PERIOD_END.GetValue += D_BATCTRL_DATE_PERIOD_END_GetValue;
        D_DELETE_FLAG.GetValue += D_DELETE_FLAG_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U093_ONE_1)"

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleF002_CLAIMS_MSTR_DTL;
    private SqlFileObject fleF002_CLAIMS_MSTR_DESC;
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
                strSQL.Append(Common.StringToField(Prompt(1).ToString())).Append(" AND ").Append(Common.StringToField(Prompt(2).ToString()));

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
    private DDecimal D_CUT_OFF_DATE = new DDecimal("D_CUT_OFF_DATE", 8);
    private void D_CUT_OFF_DATE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(D_DATE.Value) == 0)
            {
                CurrentValue = QDesign.NConvert(QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD"), 2));
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
            if ((QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "P" | QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "A") & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS")) == "4" & D_BATCTRL_DATE_PERIOD_END.Value <= D_CUT_OFF_DATE.Value)
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


    private SqlFileObject fleU093_DELETE_BATCH;


    private SqlFileObject fleU093_RETAIN_BATCH;


    #endregion


    #region "Standard Generated Procedures(U093_ONE_1)"


    #region "Automatic Item Initialization(U093_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U093_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:42 PM

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
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_DTL.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_DESC.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU093_DELETE_BATCH.Transaction = m_trnTRANS_UPDATE;
        fleU093_RETAIN_BATCH.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U093_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:42 PM

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
            fleF002_CLAIMS_MSTR.Dispose();
            fleF002_CLAIMS_MSTR_DTL.Dispose();
            fleF002_CLAIMS_MSTR_DESC.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU093_DELETE_BATCH.Dispose();
            fleU093_RETAIN_BATCH.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U093_ONE_1)"


    public void Run()
    {

        try
        {
            Request("ONE_1");

            while (fleF001_BATCH_CONTROL_FILE.QTPForMissing())
            {
                // --> GET F001_BATCH_CONTROL_FILE <--
                fleF001_BATCH_CONTROL_FILE.GetData();
                // --> End GET F001_BATCH_CONTROL_FILE <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleICONST_MSTR_REC.QTPForMissing("4"))
                    {
                        // --> GET ICONST_MSTR_REC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2))));
                        //Parent:CLMHDR_CLAIM_ID

                        fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                        // --> End GET ICONST_MSTR_REC <--

                        if (Transaction())
                        {
                            Sort(fleF001_BATCH_CONTROL_FILE.GetSortValue("BATCTRL_BATCH_NBR"), fleF002_CLAIMS_MSTR.GetSortValue("KEY_CLM_CLAIM_NBR"));
                        }
                    }
                }
            }

            while (Sort(fleF001_BATCH_CONTROL_FILE, fleF002_CLAIMS_MSTR, fleICONST_MSTR_REC))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleU093_DELETE_BATCH, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_BATCH_NBR") || fleF002_CLAIMS_MSTR.At("KEY_CLM_CLAIM_NBR"), QDesign.NULL(D_DELETE_FLAG.Value) == "Y", SubFileType.Keep, fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", fleF002_CLAIMS_MSTR, "CLMHDR_ADJ_CD_SUB_TYPE", "CLMHDR_TOT_CLAIM_AR_OMA",
                "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", D_CUT_OFF_DATE, fleF001_BATCH_CONTROL_FILE);

                SubFile(ref m_trnTRANS_UPDATE, ref fleU093_RETAIN_BATCH, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_BATCH_NBR") || fleF002_CLAIMS_MSTR.At("KEY_CLM_CLAIM_NBR"), QDesign.NULL(D_DELETE_FLAG.Value) == "N", SubFileType.Keep, fleICONST_MSTR_REC, "ICONST_CLINIC_NBR_1_2", fleF002_CLAIMS_MSTR, "CLMHDR_ADJ_CD_SUB_TYPE", "CLMHDR_TOT_CLAIM_AR_OMA",
                "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", D_CUT_OFF_DATE, fleF001_BATCH_CONTROL_FILE);

                if (D_DELETE_FLAG.Value == "Y")
                {
                    m_strSQL = new StringBuilder("DELETE FROM INDEXED.F002_CLAIMS_MSTR_DTL WHERE KEY_CLM_BATCH_NBR = ");
                    m_strSQL.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strSQL.Append(" AND KEY_CLM_CLAIM_NBR = " + fleF002_CLAIMS_MSTR.GetDecimalValue("KEY_CLM_CLAIM_NBR"));

                    SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), System.Data.CommandType.Text, m_strSQL.ToString());

                    m_strSQL = new StringBuilder("DELETE FROM INDEXED.F002_CLAIMS_MSTR_DESC WHERE KEY_CLM_BATCH_NBR = ");
                    m_strSQL.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strSQL.Append(" AND KEY_CLM_CLAIM_NBR = " + fleF002_CLAIMS_MSTR.GetDecimalValue("KEY_CLM_CLAIM_NBR"));

                    SqlHelper.ExecuteNonQuery(Common.GetSqlConnectionString(), System.Data.CommandType.Text, m_strSQL.ToString());
                }

                fleF002_CLAIMS_MSTR.OutPut(OutPutType.Delete, null, D_DELETE_FLAG.Value == "Y");
                fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Delete, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_BATCH_NBR"), QDesign.NULL(D_DELETE_FLAG.Value) == "Y");
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
            EndRequest("ONE_1");
        }
    }

    #endregion
}
//ONE_1




