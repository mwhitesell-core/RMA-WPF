
#region "Screen Comments"

// filename: unlof002_rat_payment.qts
// purpose:  select data for claims_subfile history file for each clinic
// based on u030_paid_amt.sf  via u030b_part2.qts  
// Modification History
// 2015/Jun/30   MC      - original 
// 2015/Jul/28 MC1       - comment out the redundant x-delimiter after clmhdr-pat-ohip-id-or-chart
// 2015/Aug/06 MC2       - change to create subfile in /foxtrot/bi  


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UNLOF002_RAT_PAYMENT : BaseClassControl
{

    private UNLOF002_RAT_PAYMENT m_UNLOF002_RAT_PAYMENT;

    public UNLOF002_RAT_PAYMENT(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UNLOF002_RAT_PAYMENT(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UNLOF002_RAT_PAYMENT != null))
        {
            m_UNLOF002_RAT_PAYMENT.CloseTransactionObjects();
            m_UNLOF002_RAT_PAYMENT = null;
        }
    }

    public UNLOF002_RAT_PAYMENT GetUNLOF002_RAT_PAYMENT(int Level)
    {
        if (m_UNLOF002_RAT_PAYMENT == null)
        {
            m_UNLOF002_RAT_PAYMENT = new UNLOF002_RAT_PAYMENT("UNLOF002_RAT_PAYMENT", Level);
        }
        else
        {
            m_UNLOF002_RAT_PAYMENT.ResetValues();
        }
        return m_UNLOF002_RAT_PAYMENT;
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

            UNLOF002_RAT_PAYMENT_UNLOF002_1 UNLOF002_1 = new UNLOF002_RAT_PAYMENT_UNLOF002_1(Name, Level);
            UNLOF002_1.Run();
            UNLOF002_1.Dispose();
            UNLOF002_1 = null;

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



public class UNLOF002_RAT_PAYMENT_UNLOF002_1 : UNLOF002_RAT_PAYMENT
{

    public UNLOF002_RAT_PAYMENT_UNLOF002_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_PAID_AMT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_PAID_AMT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUNLOF002HDR_RAT_PAYMENT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UNLOF002HDR_RAT_PAYMENT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        BILLED_AMT.GetValue += BILLED_AMT_GetValue;
        ADJUST_AMT.GetValue += ADJUST_AMT_GetValue;
        PAYMENT_AMT.GetValue += PAYMENT_AMT_GetValue;
        FLAG.GetValue += FLAG_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        CR.GetValue += CR_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        LF.GetValue += LF_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(UNLOF002_RAT_PAYMENT_UNLOF002_1)"

    private SqlFileObject fleU030_PAID_AMT;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private DDecimal BILLED_AMT = new DDecimal("BILLED_AMT", 7);
    private void BILLED_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal ADJUST_AMT = new DDecimal("ADJUST_AMT", 7);
    private void ADJUST_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 0;


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
    private DDecimal PAYMENT_AMT = new DDecimal("PAYMENT_AMT", 7);
    private void PAYMENT_AMT_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleU030_PAID_AMT.GetDecimalValue("X_TOT_AMT_PAID") * -1;


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
    private DCharacter FLAG = new DCharacter("FLAG", 1);
    private void FLAG_GetValue(ref string Value)
    {

        try
        {
            Value = "R";


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
    private DCharacter X_DELIMITER = new DCharacter("X_DELIMITER", 1);
    private void X_DELIMITER_GetValue(ref string Value)
    {

        try
        {
            Value = "~";


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
    private DInteger X_CR = new DInteger("X_CR", 2);
    private void X_CR_GetValue(ref decimal Value)
    {

        try
        {
            Value = 13;


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
    private DCharacter CR = new DCharacter("CR", 1);
    private void CR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(QDesign.Characters(X_CR.Value), 1, 1);


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
    private DInteger X_LF = new DInteger("X_LF", 2);
    private void X_LF_GetValue(ref decimal Value)
    {

        try
        {
            Value = 10;


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
    private DCharacter LF = new DCharacter("LF", 1);
    private void LF_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(QDesign.Characters(X_LF.Value), 1, 1);


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




    private SqlFileObject fleUNLOF002HDR_RAT_PAYMENT;


    #endregion


    #region "Standard Generated Procedures(UNLOF002_RAT_PAYMENT_UNLOF002_1)"


    #region "Automatic Item Initialization(UNLOF002_RAT_PAYMENT_UNLOF002_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UNLOF002_RAT_PAYMENT_UNLOF002_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:00 PM

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
        fleU030_PAID_AMT.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleUNLOF002HDR_RAT_PAYMENT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UNLOF002_RAT_PAYMENT_UNLOF002_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:00 PM

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
            fleU030_PAID_AMT.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleUNLOF002HDR_RAT_PAYMENT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UNLOF002_RAT_PAYMENT_UNLOF002_1)"


    public void Run()
    {

        try
        {
            Request("UNLOF002_1");

            while (fleU030_PAID_AMT.QTPForMissing())
            {
                // --> GET U030_PAID_AMT <--

                fleU030_PAID_AMT.GetData();
                // --> End GET U030_PAID_AMT <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleU030_PAID_AMT.GetStringValue("X_GROUP_NBR") + QDesign.Substring(fleU030_PAID_AMT.GetStringValue("RAT_145_ACCOUNT_NBR"), 1, 6))));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_PAID_AMT.GetStringValue("RAT_145_ACCOUNT_NBR"), 7, 2))));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {




                        SubFile(ref m_trnTRANS_UPDATE, ref fleUNLOF002HDR_RAT_PAYMENT, QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) == "0000", SubFileType.Portable, fleF002_CLAIMS_MSTR, "CLMHDR_BATCH_NBR", X_DELIMITER, "CLMHDR_CLAIM_NBR", "CLMHDR_ADJ_OMA_CD", "CLMHDR_ADJ_OMA_CD",
                        "CLMHDR_ADJ_OMA_SUFF", "CLMHDR_BATCH_TYPE", "CLMHDR_ADJ_CD_SUB_TYPE", "CLMHDR_DOC_NBR_OHIP", "CLMHDR_DOC_SPEC_CD", "CLMHDR_REFER_DOC_NBR", "CLMHDR_DIAG_CD", fleU030_PAID_AMT, "CLMHDR_LOC", fleF002_CLAIMS_MSTR,
                        "CLMHDR_PAYROLL", fleU030_PAID_AMT, "CLMHDR_AGENT_CD", fleF002_CLAIMS_MSTR, "CLMHDR_ADJ_CD", "CLMHDR_I_O_PAT_IND", "CLMHDR_PAT_OHIP_ID_OR_CHART", fleU030_PAID_AMT, "CLMHDR_DOC_DEPT", fleF002_CLAIMS_MSTR,
                        "CLMHDR_DATE_CASH_TAPE_PAYMENT", "CLMHDR_MSG_NBR", "CLMHDR_REPRINT_FLAG", "CLMHDR_SUB_NBR", "CLMHDR_AUTO_LOGOUT", "CLMHDR_FEE_COMPLEX", "CLMHDR_DATE_PERIOD_END", "CLMHDR_AMT_TECH_BILLED", "CLMHDR_AMT_TECH_PAID", "CLMHDR_TOT_CLAIM_AR_OMA",
                        "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", BILLED_AMT, ADJUST_AMT, PAYMENT_AMT, "CLMHDR_STATUS_OHIP", "CLMHDR_MANUAL_REVIEW", "CLMHDR_SERV_DATE", "CLMHDR_ELIG_ERROR", "CLMHDR_ELIG_STATUS",
                        "CLMHDR_SERV_ERROR", "CLMHDR_SERV_STATUS", "CLMHDR_ORIG_BATCH_ID", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", "KEY_P_CLAIMS_MSTR", FLAG,
                        CR, LF);
                        //Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:KEY_P_CLAIMS_MSTR


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
            EndRequest("UNLOF002_1");

        }

    }




    #endregion


}
//UNLOF002_1




