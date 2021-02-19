
#region "Screen Comments"

// #> PROGRAM-ID.     U802.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : CREATE AUTOMATIC ADJUSTMENT FROM ADJ-CLAIM-FILE
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 93/AUG/25 M.C.         - ORIGINAL (SMS 143)
// 94/JAN/14 M.C.      - SMS 144
// - ADD THE ROUND OPTION TO CALCULATE AMOUNT
// 94/FEB/04 M.C.      - ADD LOGIC FOR MULTIPLE CLINIC ADJUSTMENT
// - RESET THE BATCH NBR FOR EACH CLINIC
// 99/mar/08 C.M.      - Y2K CONVERSION AND I-CONST-CLINIC-NBR
// - HAS BEEN CONVERTED FROM 9(4) TO X(4) 
// 1999/May/19 S.B.      - Re-checked the Y2K. 
// 1999/May/21 S.B.         - Added the use file
// def_batctrl_batch_status.def to 
// prevent hardcoding of batctrl-batch-status.
// 1999/May/31 S.B.         - Added the use file
// def_clmhdr_status_ohip.def to 
// prevent hard coding of clmhdr-status-ohip.
// - Removed the `nconvert` from
// `nconvert(iconst-clinic-nbr)`
// 1999/Oct/20 M.C.         - defined clmhdr-reference of the adjustment
// claim header to clmhdr-reference of the
// original claim header
// 2003/dec/24 A.A.      - alpha doctor nbr
// 2007/jul/04 M.C.      - add set lock record update
// 2012/Apr/02 MC1      - clmhdr-amt-tech-billed is not update properly, think it is the sequence of update
// 2014/Apr/08 MC2      - create a new request to delete records from f002-outstanding                           
// 2007/07/04 - MC
// 2007/07/04 - end
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U802 : BaseClassControl
{

    private U802 m_U802;

    public U802(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U802(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U802 != null))
        {
            m_U802.CloseTransactionObjects();
            m_U802 = null;
        }
    }

    public U802 GetU802(int Level)
    {
        if (m_U802 == null)
        {
            m_U802 = new U802("U802", Level);
        }
        else
        {
            m_U802.ResetValues();
        }
        return m_U802;
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

            U802_CALC_BATCH_NBR_1 CALC_BATCH_NBR_1 = new U802_CALC_BATCH_NBR_1(Name, Level);
            CALC_BATCH_NBR_1.Run();
            CALC_BATCH_NBR_1.Dispose();
            CALC_BATCH_NBR_1 = null;

            U802_CREATE_B_ADJUSTMENT_2 CREATE_B_ADJUSTMENT_2 = new U802_CREATE_B_ADJUSTMENT_2(Name, Level);
            CREATE_B_ADJUSTMENT_2.Run();
            CREATE_B_ADJUSTMENT_2.Dispose();
            CREATE_B_ADJUSTMENT_2 = null;

            U802_DELETE_F002_OUTSTANDING_3 DELETE_F002_OUTSTANDING_3 = new U802_DELETE_F002_OUTSTANDING_3(Name, Level);
            DELETE_F002_OUTSTANDING_3.Run();
            DELETE_F002_OUTSTANDING_3.Dispose();
            DELETE_F002_OUTSTANDING_3 = null;

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



public class U802_CALC_BATCH_NBR_1 : U802
{

    public U802_CALC_BATCH_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleADJ_CLAIM_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "ADJ_CLAIM_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_COUNT = new CoreDecimal("X_COUNT", 6, this);
        X_BATCH_COUNT = new CoreDecimal("X_BATCH_COUNT", 6, this);
        fleU802_SRT_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U802_SRT_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        CLM_ID.GetValue += CLM_ID_GetValue;
        X_CLINIC_NBR.GetValue += X_CLINIC_NBR_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U802_CALC_BATCH_NBR_1)"

    private SqlFileObject fleADJ_CLAIM_FILE;
    private DCharacter CLM_ID = new DCharacter("CLM_ID", 10);
    private void CLM_ID_GetValue(ref string Value)
    {

        try
        {
            Value = fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR") + QDesign.ASCII(fleADJ_CLAIM_FILE.GetDecimalValue("ADJ_CLAIM_NBR"), 2);


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
    private DCharacter X_CLINIC_NBR = new DCharacter("X_CLINIC_NBR", 2);
    private void X_CLINIC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleADJ_CLAIM_FILE.GetStringValue("ADJ_BATCH_NBR"), 1, 2);


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
    private CoreDecimal X_COUNT;

    private CoreDecimal X_BATCH_COUNT;










    private SqlFileObject fleU802_SRT_ADJ;


    #endregion


    #region "Standard Generated Procedures(U802_CALC_BATCH_NBR_1)"


    #region "Automatic Item Initialization(U802_CALC_BATCH_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U802_CALC_BATCH_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:32 PM

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
        fleADJ_CLAIM_FILE.Transaction = m_trnTRANS_UPDATE;
        fleU802_SRT_ADJ.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U802_CALC_BATCH_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:32 PM

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
            fleADJ_CLAIM_FILE.Dispose();
            fleU802_SRT_ADJ.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U802_CALC_BATCH_NBR_1)"


    public void Run()
    {

        try
        {
            Request("CALC_BATCH_NBR_1");

            while (fleADJ_CLAIM_FILE.QTPForMissing())
            {
                // --> GET ADJ_CLAIM_FILE <--

                fleADJ_CLAIM_FILE.GetData();
                // --> End GET ADJ_CLAIM_FILE <--


                if (Transaction())
                {

                    Sort(X_CLINIC_NBR.Value, CLM_ID.Value);



                }

            }

            while (Sort(fleADJ_CLAIM_FILE))
            {
                Count(ref X_COUNT, At(X_CLINIC_NBR) || At(CLM_ID));
                if (At(X_CLINIC_NBR) || At(CLM_ID))
                {
                    X_BATCH_COUNT.Value = QDesign.Ceiling(X_COUNT.Value / 99);
                }












                SubFile(ref m_trnTRANS_UPDATE, ref fleU802_SRT_ADJ, At(X_CLINIC_NBR) || At(CLM_ID), SubFileType.Keep, X_COUNT, X_BATCH_COUNT, X_CLINIC_NBR, fleADJ_CLAIM_FILE);
                


                Reset(ref X_COUNT, At(X_CLINIC_NBR) || At(CLM_ID));

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
            EndRequest("CALC_BATCH_NBR_1");

        }

    }




    #endregion


}
//CALC_BATCH_NBR_1



public class U802_CREATE_B_ADJUSTMENT_2 : U802
{

    public U802_CREATE_B_ADJUSTMENT_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU802_SRT_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U802_SRT_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLMHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "F002_CLMHDR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_BATCH_NBR = new CoreInteger("X_BATCH_NBR", 6, this);
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADJ_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "F002_ADJ_HDR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADJ_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "F002_ADJ_DTL", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU030_DTL_KEY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_DTL_KEY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleICONST_MSTR_REC.SetItemFinals += fleICONST_MSTR_REC_SetItemFinals;
        X_CLINIC_BATCH_NBR.GetValue += X_CLINIC_BATCH_NBR_GetValue;
        X_MOD.GetValue += X_MOD_GetValue;
        X_CLAIM_NBR.GetValue += X_CLAIM_NBR_GetValue;
        X_TOT_CLAIM_AR_OMA.GetValue += X_TOT_CLAIM_AR_OMA_GetValue;
        X_AMT_TECH_BILLED.GetValue += X_AMT_TECH_BILLED_GetValue;
        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
        CLMHDR_STATUS_OHIP_ACCEPTED.GetValue += CLMHDR_STATUS_OHIP_ACCEPTED_GetValue;
        fleF001_BATCH_CONTROL_FILE.InitializeItems += fleF001_BATCH_CONTROL_FILE_InitializeItems;
        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;
        fleF002_ADJ_HDR.InitializeItems += fleF002_ADJ_HDR_InitializeItems;
        fleF002_ADJ_DTL.InitializeItems += fleF002_ADJ_DTL_InitializeItems;

    }


    #region "Declarations (Variables, Files and Transactions)(U802_CREATE_B_ADJUSTMENT_2)"

    private SqlFileObject fleU802_SRT_ADJ;
    private SqlFileObject fleF002_CLMHDR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;

    private void fleICONST_MSTR_REC_SetItemFinals()
    {

        try
        {
            fleICONST_MSTR_REC.set_SetValue("ICONST_CLINIC_BATCH_NBR", X_BATCH_NBR.Value);


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

    private CoreInteger X_BATCH_NBR;
    private DCharacter X_CLINIC_BATCH_NBR = new DCharacter("X_CLINIC_BATCH_NBR", 8);
    private void X_CLINIC_BATCH_NBR_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleU802_SRT_ADJ.GetStringValue("ADJ_BATCH_NBR"), 1, 2) + QDesign.ASCII(X_BATCH_NBR.Value, 6);


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
    private DDecimal X_MOD = new DDecimal("X_MOD", 6);
    private void X_MOD_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.PHMod(fleU802_SRT_ADJ.GetDecimalValue("X_COUNT"), 99);


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
    private DDecimal X_CLAIM_NBR = new DDecimal("X_CLAIM_NBR", 6);
    private void X_CLAIM_NBR_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_MOD.Value) != 0)
            {
                CurrentValue = X_MOD.Value;
            }
            else
            {
                CurrentValue = 99;
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
    private DInteger X_TOT_CLAIM_AR_OMA = new DInteger("X_TOT_CLAIM_AR_OMA", 7);
    private void X_TOT_CLAIM_AR_OMA_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Round(fleF002_CLMHDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") * fleU802_SRT_ADJ.GetDecimalValue("ADJ_AMT_BAL") / fleF002_CLMHDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"), 0, RoundOptionTypes.Near);


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
    private DInteger X_AMT_TECH_BILLED = new DInteger("X_AMT_TECH_BILLED", 7);
    private void X_AMT_TECH_BILLED_GetValue(ref decimal Value)
    {

        try
        {

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            Value = QDesign.Round(fleF002_CLMHDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") * fleU802_SRT_ADJ.GetDecimalValue("ADJ_AMT_BAL") / fleF002_CLMHDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"), 0, RoundOptionTypes.Near);


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
    private DCharacter BATCTRL_BATCH_STATUS_UNBALANCED = new DCharacter("BATCTRL_BATCH_STATUS_UNBALANCED", 1);
    private void BATCTRL_BATCH_STATUS_UNBALANCED_GetValue(ref string Value)
    {

        try
        {
            Value = "0";


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
    private DCharacter BATCTRL_BATCH_STATUS_BALANCED = new DCharacter("BATCTRL_BATCH_STATUS_BALANCED", 1);
    private void BATCTRL_BATCH_STATUS_BALANCED_GetValue(ref string Value)
    {

        try
        {
            Value = "1";


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
    private DCharacter BATCTRL_BATCH_STATUS_REV_UPDATED = new DCharacter("BATCTRL_BATCH_STATUS_REV_UPDATED", 1);
    private void BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue(ref string Value)
    {

        try
        {
            Value = "2";


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
    private DCharacter BATCTRL_BATCH_STATUS_OHIP_SENT = new DCharacter("BATCTRL_BATCH_STATUS_OHIP_SENT", 1);
    private void BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue(ref string Value)
    {

        try
        {
            Value = "3";


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
    private DCharacter BATCTRL_BATCH_STATUS_MONTHEND_DONE = new DCharacter("BATCTRL_BATCH_STATUS_MONTHEND_DONE", 1);
    private void BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue(ref string Value)
    {

        try
        {
            Value = "4";


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
    private DCharacter CLMHDR_STATUS_OHIP_ACCEPTED = new DCharacter("CLMHDR_STATUS_OHIP_ACCEPTED", 2);
    private void CLMHDR_STATUS_OHIP_ACCEPTED_GetValue(ref string Value)
    {

        try
        {
            Value = "00";


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
    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_NBR", true, X_CLINIC_BATCH_NBR.Value);
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_TYPE", true, "A");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CLINIC_NBR", true, fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_NBR"));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD", true, "B");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AGENT_CD", true, fleU802_SRT_ADJ.GetDecimalValue("ADJ_AGENT_CD"));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_BATCH_ENTERED", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_PERIOD_END", true, QDesign.ASCII(fleICONST_MSTR_REC.GetNumericDateValue("ICONST_DATE_PERIOD_END"), 8));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CYCLE_NBR", true, fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_CYCLE_NBR"));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AR_YY_MM", true, "000000");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD_SUB_TYPE", true, "A");


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



    private void fleF001_BATCH_CONTROL_FILE_SetItemFinals()
    {

        try
        {
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_NBR_CLAIMS_IN_BATCH", X_CLAIM_NBR.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_LAST_CLAIM_NBR", X_CLAIM_NBR.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_STATUS", BATCTRL_BATCH_STATUS_BALANCED.Value);


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

    private SqlFileObject fleF002_ADJ_HDR;

    private void fleF002_ADJ_HDR_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_TYPE", true, "B");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_BATCH_NBR", true, X_CLINIC_BATCH_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_SERV_CODE", true, "00000");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ORIG_BATCH_NBR", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ORIG_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_BATCH_TYPE", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_CD_SUB_TYPE", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD_SUB_TYPE"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AGENT_CD", true, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AGENT_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_CD", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DATE_PERIOD_END", true, QDesign.NConvert(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_DATE_PERIOD_END")));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_CYCLE_NBR", true, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CYCLE_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_CLAIM_ID", true, fleF002_CLMHDR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLMHDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLMHDR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLMHDR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLMHDR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"));
            //Parent:CLMHDR_CLAIM_ID
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DIAG_CD", true, fleF002_CLMHDR.GetDecimalValue("CLMHDR_DIAG_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_HOSP", true, fleF002_CLMHDR.GetStringValue("CLMHDR_HOSP"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_I_O_PAT_IND", true, fleF002_CLMHDR.GetStringValue("CLMHDR_I_O_PAT_IND"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_LOC", true, fleF002_CLMHDR.GetStringValue("CLMHDR_LOC"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_PAT_OHIP_ID_OR_CHART", true, fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_KEY_DATA"));
            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_PAT_ACRONYM", true, fleU802_SRT_ADJ.GetStringValue("ADJ_PAT_ACRONYM"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DOC_DEPT", true, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_REFERENCE", true, fleF002_CLMHDR.GetStringValue("CLMHDR_REFERENCE"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DATE_ADMIT", true, "00000000");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DATE_CASH_TAPE_PAYMENT", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DATE_SYS", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_STATUS_OHIP", true, CLMHDR_STATUS_OHIP_ACCEPTED.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", true, "N");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DOC_NBR_OHIP", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DOC_SPEC_CD", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_REFER_DOC_NBR", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_CURR_PAYMENT", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AMT_TECH_PAID", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", true, 0);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AMT_TECH_BILLED", true, X_AMT_TECH_BILLED.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OMA", true, X_TOT_CLAIM_AR_OMA.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", true, fleU802_SRT_ADJ.GetDecimalValue("ADJ_AMT_BAL"));


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

    private SqlFileObject fleF002_ADJ_DTL;

    private void fleF002_ADJ_DTL_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_TYPE", true, "B");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_BATCH_NBR", true, X_CLINIC_BATCH_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_SERV_CODE", true, fleU802_SRT_ADJ.GetStringValue("ADJ_OMA_CD_SUFF"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_BATCH_NBR", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_CLAIM_NBR", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_OMA_CD", true, QDesign.Substring(fleU802_SRT_ADJ.GetStringValue("ADJ_OMA_CD_SUFF"), 1, 4));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_OMA_SUFF", true, QDesign.Substring(fleU802_SRT_ADJ.GetStringValue("ADJ_OMA_CD_SUFF"), 5, 1));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ADJ_NBR", true, 1);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_AGENT_CD", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_AGENT_CD"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ADJ_CD", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_ADJ_CD"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_DATE", true, QDesign.ASCII(fleU802_SRT_ADJ.GetNumericDateValue("ADJ_SERV_DATE"), 8));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_NBR_SERV", true, 0);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_CONSEC_DATES", true, 0);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_DATE_PERIOD_END", true, QDesign.ASCII(fleF002_ADJ_HDR.GetNumericDateValue("CLMHDR_DATE_PERIOD_END"), 8));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_CYCLE_NBR", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_CYCLE_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ORIG_BATCH_ID", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_ORIG_BATCH_NBR") + QDesign.ASCII(fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_ORIG_CLAIM_NBR"), 2));
            //Parent:CLMHDR_ORIG_BATCH_ID
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_FEE_OMA", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_FEE_OHIP", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_DIAG_CD", true, fleU802_SRT_ADJ.GetDecimalValue("ADJ_DIAG_CD"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_REV_GROUP_CD", true, " ");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_LINE_NO", true, fleU802_SRT_ADJ.GetDecimalValue("ADJ_LINE_NO"));


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

    private SqlFileObject fleU030_DTL_KEY;


    #endregion


    #region "Standard Generated Procedures(U802_CREATE_B_ADJUSTMENT_2)"


    #region "Automatic Item Initialization(U802_CREATE_B_ADJUSTMENT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U802_CREATE_B_ADJUSTMENT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:32 PM

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
        fleU802_SRT_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLMHDR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF002_ADJ_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_ADJ_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_DTL_KEY.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U802_CREATE_B_ADJUSTMENT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:32 PM

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
            fleU802_SRT_ADJ.Dispose();
            fleF002_CLMHDR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleF002_ADJ_HDR.Dispose();
            fleF002_ADJ_DTL.Dispose();
            fleU030_DTL_KEY.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U802_CREATE_B_ADJUSTMENT_2)"


    public void Run()
    {

        try
        {
            Request("CREATE_B_ADJUSTMENT_2");

            while (fleU802_SRT_ADJ.QTPForMissing())
            {
                // --> GET U802_SRT_ADJ <--

                fleU802_SRT_ADJ.GetData();
                // --> End GET U802_SRT_ADJ <--

                while (fleF002_CLMHDR.QTPForMissing("1"))
                {
                    // --> GET F002_CLMHDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU802_SRT_ADJ.GetStringValue("ADJ_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleU802_SRT_ADJ.GetDecimalValue("ADJ_CLAIM_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLMHDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLMHDR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleF002_CLMHDR.GetStringValue("KEY_CLM_BATCH_NBR"), 3, 3)));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleICONST_MSTR_REC.QTPForMissing("3"))
                        {
                            // --> GET ICONST_MSTR_REC <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                            m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU802_SRT_ADJ.GetStringValue("ADJ_BATCH_NBR"), 1, 2))));

                            fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                            // --> End GET ICONST_MSTR_REC <--


                            if (Transaction())
                            {

                                Sort(fleU802_SRT_ADJ.GetSortValue("X_CLINIC_NBR"), fleU802_SRT_ADJ.GetSortValue("X_BATCH_COUNT"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleU802_SRT_ADJ, fleF002_CLMHDR, fleF020_DOCTOR_MSTR, fleICONST_MSTR_REC))
            {
                if (fleU802_SRT_ADJ.At("X_CLINIC_NBR") || fleU802_SRT_ADJ.At("X_BATCH_COUNT"))
                {
                    X_BATCH_NBR.Value = fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_BATCH_NBR") + fleU802_SRT_ADJ.GetDecimalValue("X_BATCH_COUNT");
                }


                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_ACT", fleU802_SRT_ADJ.GetDecimalValue("ADJ_AMT_BAL"));


                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_EST", fleU802_SRT_ADJ.GetDecimalValue("ADJ_AMT_BAL"));


                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_CALC_AR_DUE", fleU802_SRT_ADJ.GetDecimalValue("ADJ_AMT_BAL"));


                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_CALC_TOT_REV", fleU802_SRT_ADJ.GetDecimalValue("ADJ_AMT_BAL"));

                fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Add, fleU802_SRT_ADJ.At("X_CLINIC_NBR") || fleU802_SRT_ADJ.At("X_BATCH_COUNT"), null);  

                fleF002_ADJ_HDR.OutPut(OutPutType.Add);     

                fleF002_ADJ_DTL.OutPut(OutPutType.Add);    

                SubTotal(ref fleF002_CLMHDR, "CLMHDR_AMT_TECH_BILLED", X_AMT_TECH_BILLED.Value);


                SubTotal(ref fleF002_CLMHDR, "CLMHDR_TOT_CLAIM_AR_OMA", X_TOT_CLAIM_AR_OMA.Value);


                SubTotal(ref fleF002_CLMHDR, "CLMHDR_TOT_CLAIM_AR_OHIP", fleU802_SRT_ADJ.GetDecimalValue("ADJ_AMT_BAL"));

                fleF002_CLMHDR.OutPut(OutPutType.Update);

                fleICONST_MSTR_REC.OutPut(OutPutType.Update, fleU802_SRT_ADJ.At("X_CLINIC_NBR"), null);

                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_DTL_KEY, SubFileType.Keep, fleF002_ADJ_DTL, "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR");
                
                Reset(ref X_BATCH_NBR, fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_BATCH_NBR"), fleU802_SRT_ADJ.At("X_CLINIC_NBR"));

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
            EndRequest("CREATE_B_ADJUSTMENT_2");

        }

    }




    #endregion


}
//CREATE_B_ADJUSTMENT_2



public class U802_DELETE_F002_OUTSTANDING_3 : U802
{

    public U802_DELETE_F002_OUTSTANDING_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU802_SRT_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U802_SRT_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_OUTSTANDING = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_OUTSTANDING", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(U802_DELETE_F002_OUTSTANDING_3)"

    private SqlFileObject fleU802_SRT_ADJ;
    private SqlFileObject fleF002_OUTSTANDING;

    #endregion


    #region "Standard Generated Procedures(U802_DELETE_F002_OUTSTANDING_3)"


    #region "Automatic Item Initialization(U802_DELETE_F002_OUTSTANDING_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U802_DELETE_F002_OUTSTANDING_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:32 PM

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
        fleU802_SRT_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleF002_OUTSTANDING.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U802_DELETE_F002_OUTSTANDING_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:32 PM

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
            fleU802_SRT_ADJ.Dispose();
            fleF002_OUTSTANDING.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U802_DELETE_F002_OUTSTANDING_3)"


    public void Run()
    {

        try
        {
            Request("DELETE_F002_OUTSTANDING_3");

            while (fleU802_SRT_ADJ.QTPForMissing())
            {
                // --> GET U802_SRT_ADJ <--

                fleU802_SRT_ADJ.GetData();
                // --> End GET U802_SRT_ADJ <--

                while (fleF002_OUTSTANDING.QTPForMissing("1"))
                {
                    // --> GET F002_OUTSTANDING <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU802_SRT_ADJ.GetStringValue("ADJ_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleU802_SRT_ADJ.GetDecimalValue("ADJ_CLAIM_NBR")));

                    fleF002_OUTSTANDING.GetData(m_strWhere.ToString());
                    // --> End GET F002_OUTSTANDING <--


                    if (Transaction())
                    {











                        fleF002_OUTSTANDING.OutPut(OutPutType.Delete);
                        

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
            EndRequest("DELETE_F002_OUTSTANDING_3");

        }

    }




    #endregion


}
//DELETE_F002_OUTSTANDING_3




