
#region "Screen Comments"

// #> PROGRAM-ID.     U030B_autoadj_clinic_dtl.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : This program will create auto adjustment at the claim detail after
// the regular RA run.
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 2009/Feb/05 M.C.         - automatically adjust for detail has explan cd `I4` and oma cd `G313A`
// 2009/Mar/05 M.C.      - Yasemin requests to include explan cd `36` as well since MOH has changed 
// their mind for this month run
// 2009/Jun/2  Yas          - Add clinic 79 to the selection
// 2009/Jul/20 M.C.         - Yas requested to add clinic 78 & 79 to the selection
// 2012/Jan/25 MC1          - clone from the original u030b_autoadj_clinic_88.qts which is no longer used
// - instead, use this new program, add two more criteria   
// 2012/Apr/02 MC2          - clmhdr-amt-tech-billed is not update properly, think it is the sequence of update
// 2013/Nov/05 MC3        - add more selection to be auto adjust, E082A/E083A with reason code `SX` or
// K071A/K072A with reason code `D7`, and these apply to all clinics
// - regardless of existing scenario, do not check if amt-paid = 0
// 2013/Dec/10 MC4        - undo MC3 as Yasemin/Lori requested - do not auto adjust, E082A/E083A with reason code `SX` or
// K071A/K072A with reason code `D7`
// 2016/Jan/28 MC5      - modify/add more selection to be auto adjust
// 2016/Jul/05 MC6      - change subfile name
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U030B_AUTOADJ_CLINIC_DTL : BaseClassControl
{

    private U030B_AUTOADJ_CLINIC_DTL m_U030B_AUTOADJ_CLINIC_DTL;

    public U030B_AUTOADJ_CLINIC_DTL(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U030B_AUTOADJ_CLINIC_DTL(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U030B_AUTOADJ_CLINIC_DTL != null))
        {
            m_U030B_AUTOADJ_CLINIC_DTL.CloseTransactionObjects();
            m_U030B_AUTOADJ_CLINIC_DTL = null;
        }
    }

    public U030B_AUTOADJ_CLINIC_DTL GetU030B_AUTOADJ_CLINIC_DTL(int Level)
    {
        if (m_U030B_AUTOADJ_CLINIC_DTL == null)
        {
            m_U030B_AUTOADJ_CLINIC_DTL = new U030B_AUTOADJ_CLINIC_DTL("U030B_AUTOADJ_CLINIC_DTL", Level);
        }
        else
        {
            m_U030B_AUTOADJ_CLINIC_DTL.ResetValues();
        }
        return m_U030B_AUTOADJ_CLINIC_DTL;
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

            U030B_AUTOADJ_CLINIC_DTL_CALC_BATCH_NBR_1 CALC_BATCH_NBR_1 = new U030B_AUTOADJ_CLINIC_DTL_CALC_BATCH_NBR_1(Name, Level);
            CALC_BATCH_NBR_1.Run();
            CALC_BATCH_NBR_1.Dispose();
            CALC_BATCH_NBR_1 = null;

            U030B_AUTOADJ_CLINIC_DTL_CREATE_B_ADJUSTMENT_2 CREATE_B_ADJUSTMENT_2 = new U030B_AUTOADJ_CLINIC_DTL_CREATE_B_ADJUSTMENT_2(Name, Level);
            CREATE_B_ADJUSTMENT_2.Run();
            CREATE_B_ADJUSTMENT_2.Dispose();
            CREATE_B_ADJUSTMENT_2 = null;

            U030B_AUTOADJ_CLINIC_DTL_PART_ADJ_BATCH_3 PART_ADJ_BATCH_3 = new U030B_AUTOADJ_CLINIC_DTL_PART_ADJ_BATCH_3(Name, Level);
            PART_ADJ_BATCH_3.Run();
            PART_ADJ_BATCH_3.Dispose();
            PART_ADJ_BATCH_3 = null;

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



public class U030B_AUTOADJ_CLINIC_DTL_CALC_BATCH_NBR_1 : U030B_AUTOADJ_CLINIC_DTL
{

    public U030B_AUTOADJ_CLINIC_DTL_CALC_BATCH_NBR_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_NO_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_NO_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePART_PAID_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        X_COUNT = new CoreDecimal("X_COUNT", 6, this);
        X_BATCH_COUNT = new CoreDecimal("X_BATCH_COUNT", 6, this);
        fleU030_88_AUTO_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_88_AUTO_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_BAL_DUE.GetValue += X_BAL_DUE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_AUTOADJ_CLINIC_DTL_CALC_BATCH_NBR_1)"

    private SqlFileObject fleU030_NO_ADJ;
    private SqlFileObject flePART_PAID_DTL;
    private DDecimal X_BAL_DUE = new DDecimal("X_BAL_DUE", 8);
    private void X_BAL_DUE_GetValue(ref decimal Value)
    {

        try
        {
            Value = flePART_PAID_DTL.GetDecimalValue("PART_DTL_AMT_BILL") - flePART_PAID_DTL.GetDecimalValue("PART_DTL_AMT_PAID");


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
            if (((QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_EXPLAN_CD")) == "I4" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_EXPLAN_CD")) == "36") & QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD")) == "G313A" & (QDesign.NULL(fleU030_NO_ADJ.GetDecimalValue("PART_HDR_CLINIC_NBR")) == 88 | QDesign.NULL(fleU030_NO_ADJ.GetDecimalValue("PART_HDR_CLINIC_NBR")) == 78 | QDesign.NULL(fleU030_NO_ADJ.GetDecimalValue("PART_HDR_CLINIC_NBR")) == 79)) | ((QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_EXPLAN_CD")) == "36" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_EXPLAN_CD")) == "58" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_EXPLAN_CD")) == "D6" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_EXPLAN_CD")) == "O9" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_EXPLAN_CD")) == "O2") & (QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD")) == "E082A" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD")) == "E083A" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD")) == "G271A" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD")) == "P007A" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD")) == "P025A") & (X_BAL_DUE.Value <= 5600)) | ((QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_EXPLAN_CD")) == "80") & ((fleU030_NO_ADJ.GetDecimalValue("PART_HDR_CLINIC_NBR") >= 61 & fleU030_NO_ADJ.GetDecimalValue("PART_HDR_CLINIC_NBR") <= 66) | (fleU030_NO_ADJ.GetDecimalValue("PART_HDR_CLINIC_NBR") >= 71 & fleU030_NO_ADJ.GetDecimalValue("PART_HDR_CLINIC_NBR") <= 75))) | ((QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_EXPLAN_CD")) == "M1") & (QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD")) == "G388A" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD")) == "E423A" | QDesign.NULL(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD")) == "P005A") & (X_BAL_DUE.Value <= 4600)))
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

    private CoreDecimal X_COUNT;

    private CoreDecimal X_BATCH_COUNT;














    private SqlFileObject fleU030_88_AUTO_ADJ;


    #endregion


    #region "Standard Generated Procedures(U030B_AUTOADJ_CLINIC_DTL_CALC_BATCH_NBR_1)"


    #region "Automatic Item Initialization(U030B_AUTOADJ_CLINIC_DTL_CALC_BATCH_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_AUTOADJ_CLINIC_DTL_CALC_BATCH_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:25 PM

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
        fleU030_NO_ADJ.Transaction = m_trnTRANS_UPDATE;
        flePART_PAID_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_88_AUTO_ADJ.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_AUTOADJ_CLINIC_DTL_CALC_BATCH_NBR_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:25 PM

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
            fleU030_NO_ADJ.Dispose();
            flePART_PAID_DTL.Dispose();
            fleU030_88_AUTO_ADJ.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_AUTOADJ_CLINIC_DTL_CALC_BATCH_NBR_1)"


    public void Run()
    {

        try
        {
            Request("CALC_BATCH_NBR_1");

            while (fleU030_NO_ADJ.QTPForMissing())
            {
                // --> GET U030_NO_ADJ <--

                fleU030_NO_ADJ.GetData();
                // --> End GET U030_NO_ADJ <--

                while (flePART_PAID_DTL.QTPForMissing("1"))
                {
                    // --> GET PART_PAID_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append((fleU030_NO_ADJ.GetDecimalValue("PART_HDR_CLINIC_NBR")));
                    m_strWhere.Append(" And ").Append(flePART_PAID_DTL.ElementOwner("PART_DTL_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_NO_ADJ.GetStringValue("PART_HDR_CLAIM_NBR")));

                    flePART_PAID_DTL.GetData(m_strWhere.ToString());
                    // --> End GET PART_PAID_DTL <--


                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleU030_NO_ADJ.GetSortValue("PART_HDR_CLAIM_ID"));



                        }

                    }

                }

            }

            while (Sort(fleU030_NO_ADJ, flePART_PAID_DTL))
            {
                Count(ref X_COUNT);
                X_BATCH_COUNT.Value = QDesign.Ceiling(X_COUNT.Value / 99);



                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_88_AUTO_ADJ, SubFileType.Keep, X_COUNT, X_BATCH_COUNT, fleU030_NO_ADJ, "PART_HDR_CLAIM_ID", flePART_PAID_DTL);



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



public class U030B_AUTOADJ_CLINIC_DTL_CREATE_B_ADJUSTMENT_2 : U030B_AUTOADJ_CLINIC_DTL
{

    public U030B_AUTOADJ_CLINIC_DTL_CREATE_B_ADJUSTMENT_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_88_AUTO_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_88_AUTO_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLMHDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "F002_CLMHDR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_BATCH_NBR = new CoreInteger("X_BATCH_NBR", 6, this);
        fleU030MC_DEBUG_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030MC_DEBUG_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADJ_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "F002_ADJ_HDR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADJ_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "F002_ADJ_DTL", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU030_88_DTL_KEY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_88_DTL_KEY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_88_ADJ_BATCHES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_88_ADJ_BATCHES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleICONST_MSTR_REC.SetItemFinals += fleICONST_MSTR_REC_SetItemFinals;
        X_CLINIC_BATCH_NBR.GetValue += X_CLINIC_BATCH_NBR_GetValue;
        X_MOD.GetValue += X_MOD_GetValue;
        X_CLAIM_NBR.GetValue += X_CLAIM_NBR_GetValue;
        X_OHIP_BAL.GetValue += X_OHIP_BAL_GetValue;
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


    #region "Declarations (Variables, Files and Transactions)(U030B_AUTOADJ_CLINIC_DTL_CREATE_B_ADJUSTMENT_2)"

    private SqlFileObject fleU030_88_AUTO_ADJ;
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
            Value= QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2) + QDesign.ASCII(X_BATCH_NBR.Value, 6);


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
            Value = QDesign.PHMod(fleU030_88_AUTO_ADJ.GetDecimalValue("X_COUNT"), 99);


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
    private DInteger X_OHIP_BAL = new DInteger("X_OHIP_BAL", 7);
    private void X_OHIP_BAL_GetValue(ref decimal Value)
    {

        try
        {
            Value = (fleU030_88_AUTO_ADJ.GetDecimalValue("PART_DTL_AMT_BILL") - fleU030_88_AUTO_ADJ.GetDecimalValue("PART_DTL_AMT_PAID")) * -1;


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

            Value = QDesign.Round(QDesign.Divide(fleF002_CLMHDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") , fleF002_CLMHDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) * X_OHIP_BAL.Value, 0, RoundOptionTypes.Near);


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
            decimal CurrentValue = 0;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleU030_88_AUTO_ADJ.GetStringValue("PART_DTL_EXPLAN_CD")) == "80" & ((string.Compare(QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2), "61") >=0 &String.Compare(QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2), "66") <= 0) | (String.Compare(QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2), "71") >= 0 & String.Compare(QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2), "75") <= 0)))
            {
                CurrentValue = X_OHIP_BAL.Value;
            }
            else
            {
                CurrentValue = QDesign.Round(QDesign.Divide(fleF002_CLMHDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED") , fleF002_CLMHDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP")) * X_OHIP_BAL.Value, 0, RoundOptionTypes.Near);
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






    private SqlFileObject fleU030MC_DEBUG_ADJ;
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
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_BATCH_ENTERED", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_PERIOD_END", true, Convert.ToDecimal(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY").ToString().PadLeft(4, '0') + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM").ToString().PadLeft(2, '0') + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD").ToString().PadLeft(2, '0')));

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
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AGENT_CD", fleF002_CLMHDR.GetDecimalValue("CLMHDR_AGENT_CD"));


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
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_CD", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DATE_PERIOD_END", true, QDesign.NConvert(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_DATE_PERIOD_END")));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_CYCLE_NBR", true, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_CYCLE_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_BATCH_NBR", true, fleF002_CLMHDR.GetStringValue("CLMHDR_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_CLAIM_NBR", true, fleF002_CLMHDR.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_OMA_CD", true, fleF002_CLMHDR.GetStringValue("CLMHDR_ADJ_OMA_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_OMA_SUFF", true, fleF002_CLMHDR.GetStringValue("CLMHDR_ADJ_OMA_SUFF"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_ADJ_NBR", true, fleF002_CLMHDR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DIAG_CD", true, fleF002_CLMHDR.GetDecimalValue("CLMHDR_DIAG_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_HOSP", true, fleF002_CLMHDR.GetStringValue("CLMHDR_HOSP"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_I_O_PAT_IND", true, fleF002_CLMHDR.GetStringValue("CLMHDR_I_O_PAT_IND"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AGENT_CD", true, fleF002_CLMHDR.GetDecimalValue("CLMHDR_AGENT_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_LOC", true, fleF002_CLMHDR.GetStringValue("CLMHDR_LOC"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_PAT_KEY_TYPE", true, fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_KEY_TYPE"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_PAT_KEY_DATA", true, fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_KEY_DATA"));


            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_PAT_ACRONYM6", true, fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_ACRONYM6"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_PAT_ACRONYM3", true, fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_ACRONYM3"));

            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DOC_DEPT", true, fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_REFERENCE", true, fleU030_88_AUTO_ADJ.GetStringValue("PART_DTL_EXPLAN_CD"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DATE_ADMIT", true, "00000000");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_MSG_NBR", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(0, 2));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_REPRINT_FLAG", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(2, 1));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_SUB_NBR", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(3, 1));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AUTO_LOGOUT", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(4, 1));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_FEE_COMPLEX", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(5, 1));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("FILLER", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(6, 2));
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
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_TOT_CLAIM_AR_OHIP", true, X_OHIP_BAL.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_P_CLM_TYPE", true, "Z");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_P_CLM_DATA", true, QDesign.Substring(fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLMHDR.GetStringValue("CLMHDR_PAT_KEY_DATA"), 2, 14));
            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART


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
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_SERV_CODE", true, fleU030_88_AUTO_ADJ.GetStringValue("PART_DTL_OMA_CD"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_BATCH_NBR", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_CLAIM_NBR", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_OMA_CD", true, QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_DTL_OMA_CD"), 1, 4));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_OMA_SUFF", true, QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_DTL_OMA_CD"), 5, 1));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ADJ_NBR", true, 1);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_AGENT_CD", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_AGENT_CD"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ADJ_CD", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_ADJ_CD"));
          
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_YY", true, fleU030_88_AUTO_ADJ.GetStringValue("PART_DTL_SERV_DATE").Substring(0, 4));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_MM", true, fleU030_88_AUTO_ADJ.GetStringValue("PART_DTL_SERV_DATE").Substring(4, 2));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_DD", true, fleU030_88_AUTO_ADJ.GetStringValue("PART_DTL_SERV_DATE").Substring(6, 2));

            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_NBR_SERV", true, 0);
           
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_DATE_PERIOD_END", true, QDesign.ASCII(fleF002_ADJ_HDR.GetNumericDateValue("CLMHDR_DATE_PERIOD_END"), 8));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_CYCLE_NBR", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_CYCLE_NBR"));
        
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ORIG_BATCH_NBR", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_ORIG_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_ORIG_CLAIM_NBR"));

            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_FEE_OMA", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_FEE_OHIP", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_AMT_TECH_BILLED"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_DIAG_CD", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_DIAG_CD"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_REV_GROUP_CD", true, " ");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_LINE_NO", true, 1);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_P_CLM_TYPE", true, "Z");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_P_CLM_DATA", true, X_CLINIC_BATCH_NBR.Value + QDesign.ASCII(X_CLAIM_NBR.Value, 2) + fleU030_88_AUTO_ADJ.GetStringValue("PART_DTL_OMA_CD") + "0");


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






    private SqlFileObject fleU030_88_DTL_KEY;






    private SqlFileObject fleU030_88_ADJ_BATCHES;


    #endregion


    #region "Standard Generated Procedures(U030B_AUTOADJ_CLINIC_DTL_CREATE_B_ADJUSTMENT_2)"


    #region "Automatic Item Initialization(U030B_AUTOADJ_CLINIC_DTL_CREATE_B_ADJUSTMENT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_AUTOADJ_CLINIC_DTL_CREATE_B_ADJUSTMENT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:25 PM

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
        fleU030_88_AUTO_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLMHDR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU030MC_DEBUG_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF002_ADJ_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_ADJ_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU030_88_DTL_KEY.Transaction = m_trnTRANS_UPDATE;
        fleU030_88_ADJ_BATCHES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_AUTOADJ_CLINIC_DTL_CREATE_B_ADJUSTMENT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:25 PM

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
            fleU030_88_AUTO_ADJ.Dispose();
            fleF002_CLMHDR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU030MC_DEBUG_ADJ.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleF002_ADJ_HDR.Dispose();
            fleF002_ADJ_DTL.Dispose();
            fleU030_88_DTL_KEY.Dispose();
            fleU030_88_ADJ_BATCHES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_AUTOADJ_CLINIC_DTL_CREATE_B_ADJUSTMENT_2)"


    public void Run()
    {

        try
        {
            Request("CREATE_B_ADJUSTMENT_2");

            while (fleU030_88_AUTO_ADJ.QTPForMissing())
            {
                // --> GET U030_88_AUTO_ADJ <--

                fleU030_88_AUTO_ADJ.GetData();
                // --> End GET U030_88_AUTO_ADJ <--

                while (fleF002_CLMHDR.QTPForMissing("1"))
                {
                    // --> GET F002_CLMHDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 8)));
                    m_strWhere.Append(" And ").Append(fleF002_CLMHDR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 9, 2))));
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
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 3, 3)));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString());
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleICONST_MSTR_REC.QTPForMissing("3"))
                        {
                            // --> GET ICONST_MSTR_REC <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                            m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_88_AUTO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 2))));

                            fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                            // --> End GET ICONST_MSTR_REC <--


                            if (Transaction())
                            {

                                Sort(fleU030_88_AUTO_ADJ.GetSortValue("X_BATCH_COUNT"), fleU030_88_AUTO_ADJ.GetSortValue("PART_HDR_CLAIM_ID"));



                            }

                        }

                    }

                }

            }

            while (Sort(fleU030_88_AUTO_ADJ, fleF002_CLMHDR, fleF020_DOCTOR_MSTR, fleICONST_MSTR_REC))
            {
                if (fleU030_88_AUTO_ADJ.At("X_BATCH_COUNT"))
                {
                    X_BATCH_NBR.Value = fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_BATCH_NBR") + fleU030_88_AUTO_ADJ.GetDecimalValue("X_BATCH_COUNT");
                }

                SubFile(ref m_trnTRANS_UPDATE, ref fleU030MC_DEBUG_ADJ, SubFileType.Keep, X_CLINIC_BATCH_NBR, X_CLAIM_NBR, fleF002_CLMHDR, "CLMHDR_TOT_CLAIM_AR_OMA", X_TOT_CLAIM_AR_OMA, "CLMHDR_TOT_CLAIM_AR_OHIP", X_OHIP_BAL,
                "CLMHDR_AMT_TECH_BILLED", X_AMT_TECH_BILLED, fleU030_88_AUTO_ADJ);



                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_ACT", X_OHIP_BAL.Value);


                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_EST", X_OHIP_BAL.Value);


                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_CALC_AR_DUE", X_OHIP_BAL.Value);


                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_CALC_TOT_REV", X_OHIP_BAL.Value);


                fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Add, fleU030_88_AUTO_ADJ.At("X_BATCH_COUNT"), null);



                fleF002_ADJ_HDR.OutPut(OutPutType.Add);


                fleF002_ADJ_DTL.OutPut(OutPutType.Add);




                SubTotal(ref fleF002_CLMHDR, "CLMHDR_AMT_TECH_BILLED", X_AMT_TECH_BILLED.Value);


                SubTotal(ref fleF002_CLMHDR, "CLMHDR_TOT_CLAIM_AR_OMA", X_TOT_CLAIM_AR_OMA.Value);


                SubTotal(ref fleF002_CLMHDR, "CLMHDR_TOT_CLAIM_AR_OHIP", X_OHIP_BAL.Value);


                fleF002_CLMHDR.OutPut(OutPutType.Update, fleU030_88_AUTO_ADJ.At("X_BATCH_COUNT") || fleU030_88_AUTO_ADJ.At("PART_HDR_CLAIM_ID"), null);



                fleICONST_MSTR_REC.OutPut(OutPutType.Update, AtFinal(), null);



                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_88_DTL_KEY, SubFileType.Keep, fleF002_ADJ_DTL, "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR");



                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_88_ADJ_BATCHES, fleU030_88_AUTO_ADJ.At("X_BATCH_COUNT"), SubFileType.Keep, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR");


                Reset(ref X_BATCH_NBR, fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_BATCH_NBR"), AtInitial());
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



public class U030B_AUTOADJ_CLINIC_DTL_PART_ADJ_BATCH_3 : U030B_AUTOADJ_CLINIC_DTL
{

    public U030B_AUTOADJ_CLINIC_DTL_PART_ADJ_BATCH_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_88_ADJ_BATCHES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_88_ADJ_BATCHES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePART_ADJ_BATCH = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "PART_ADJ_BATCH", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        flePART_ADJ_BATCH.SetItemFinals += flePART_ADJ_BATCH_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_AUTOADJ_CLINIC_DTL_PART_ADJ_BATCH_3)"

    private SqlFileObject fleU030_88_ADJ_BATCHES;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR")) == "000000")
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

    private SqlFileObject flePART_ADJ_BATCH;

    private void flePART_ADJ_BATCH_SetItemFinals()
    {

        try
        {
            flePART_ADJ_BATCH.set_SetValue("PART_ADJ_CLAIM_ID", QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 10));
            //Parent:CLMHDR_CLAIM_ID
            flePART_ADJ_BATCH.set_SetValue("PART_ADJ_BAL", fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));


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


    #region "Standard Generated Procedures(U030B_AUTOADJ_CLINIC_DTL_PART_ADJ_BATCH_3)"


    #region "Automatic Item Initialization(U030B_AUTOADJ_CLINIC_DTL_PART_ADJ_BATCH_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_AUTOADJ_CLINIC_DTL_PART_ADJ_BATCH_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:25 PM

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
        fleU030_88_ADJ_BATCHES.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePART_ADJ_BATCH.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_AUTOADJ_CLINIC_DTL_PART_ADJ_BATCH_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:25 PM

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
            fleU030_88_ADJ_BATCHES.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            flePART_ADJ_BATCH.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_AUTOADJ_CLINIC_DTL_PART_ADJ_BATCH_3)"


    public void Run()
    {

        try
        {
            Request("PART_ADJ_BATCH_3");

            while (fleU030_88_ADJ_BATCHES.QTPForMissing())
            {
                // --> GET U030_88_ADJ_BATCHES <--

                fleU030_88_ADJ_BATCHES.GetData();
                // --> End GET U030_88_ADJ_BATCHES <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU030_88_ADJ_BATCHES.GetStringValue("BATCTRL_BATCH_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {
                            




                            flePART_ADJ_BATCH.OutPut(OutPutType.Add);


                        }

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
            EndRequest("PART_ADJ_BATCH_3");

        }

    }




    #endregion


}
//PART_ADJ_BATCH_3




