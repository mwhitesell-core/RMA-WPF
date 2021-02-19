
#region "Screen Comments"

// #> PROGRAM-ID.     U030B_PART3_B.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : THIRD PASS OF U030B
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 06/Nov/03 M.C.         - ORIGINAL 
// - create miscellaneous premium payment records from record 8
// 07/Feb/15 M.C.      - Since Mary put the the postdate `termination date` in the
// doctor master, we still have to consider active doctor if the
// termination date > sysdate
// 07/apr/16 M.C.      - change the definition of x-paid-amt for negative amount as well
// 07/jun/13 M.C.      - add a new request at the end of the program to create records in the
// `tmp-counters-alpha` file from subfile
// 09/mar/09 M.C.      - add clinic 37 payment to apply to clinic 22  
// 09/mar/23 M.C.      - use clmhdr-adj-cd instead of hardcode `AGEP` because AGEP & MOHR can use
// this program
// 09/apr/01 M.C.      - use x-adj-cd instead of clmhdr-adj-cd
// 09/apr/20 M.C.         - u030b_part3.qts split into u030b_part3_a/b.qts
// 13/May/15 MC1      - replace x-adj-cd = `MOHDn` to `MOHD` when creating claim detail 
// 13/May/22 MC2          - update clmdtl-amt-tech-billed & clmhdr-amt-tech-paid for clinic 60`s & 70`s
// for Miscellanceous payment, include tmp-doctor-alpha in the access to extract the tech paid
// 2016/Mar/28 MC3          - modify to update next batch nbr properly; Yasemin agrees to change from W01 to WW0
// for next payment batch nbr and reserve for WW0 to WW2 so that there are 3000 batches
// allowed before rest (WW0000 to WW2999)
// 2016/Jul/28 MC4      - transfer last request to u030b_part3_a.qts as Yasemin requested to generate ru030n.txt
// as part of AGEP/MOHD_part1
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U030B_PART3_B : BaseClassControl
{

    private U030B_PART3_B m_U030B_PART3_B;

    public U030B_PART3_B(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U030B_PART3_B(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U030B_PART3_B != null))
        {
            m_U030B_PART3_B.CloseTransactionObjects();
            m_U030B_PART3_B = null;
        }
    }

    public U030B_PART3_B GetU030B_PART3_B(int Level)
    {
        if (m_U030B_PART3_B == null)
        {
            m_U030B_PART3_B = new U030B_PART3_B("U030B_PART3_B", Level);
        }
        else
        {
            m_U030B_PART3_B.ResetValues();
        }
        return m_U030B_PART3_B;
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

            U030B_PART3_B_CREATE_PAYMENT_RECS_1 CREATE_PAYMENT_RECS_1 = new U030B_PART3_B_CREATE_PAYMENT_RECS_1(Name, Level);
            CREATE_PAYMENT_RECS_1.Run();
            CREATE_PAYMENT_RECS_1.Dispose();
            CREATE_PAYMENT_RECS_1 = null;

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



public class U030B_PART3_B_CREATE_PAYMENT_RECS_1 : U030B_PART3_B
{

    public U030B_PART3_B_CREATE_PAYMENT_RECS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleR031A_BATCH_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleTMP_DOCTOR_ALPHA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "TMP_DOCTOR_ALPHA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_BATCH_NBR = new CoreDecimal("X_BATCH_NBR", 4, this);
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADJ_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "F002_ADJ_HDR", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADJ_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "F002_ADJ_DTL", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR031A_PAY_BATCHES = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R031A_PAY_BATCHES", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleICONST_MSTR_REC.SetItemFinals += fleICONST_MSTR_REC_SetItemFinals;
        X_PAY_BATCH_NBR.GetValue += X_PAY_BATCH_NBR_GetValue;
        X_CLINIC_BATCH_NBR.GetValue += X_CLINIC_BATCH_NBR_GetValue;
        X_CLAIM_NBR.GetValue += X_CLAIM_NBR_GetValue;
        X_TECH_AMT.GetValue += X_TECH_AMT_GetValue;
        fleF001_BATCH_CONTROL_FILE.InitializeItems += fleF001_BATCH_CONTROL_FILE_InitializeItems;
        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;
        fleF002_ADJ_HDR.InitializeItems += fleF002_ADJ_HDR_InitializeItems;
        fleF002_ADJ_DTL.InitializeItems += fleF002_ADJ_DTL_InitializeItems;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART3_B_CREATE_PAYMENT_RECS_1)"

    private SqlFileObject fleR031A_BATCH_NBR;
    private SqlFileObject fleTMP_DOCTOR_ALPHA;
    private SqlFileObject fleICONST_MSTR_REC;

    private void fleICONST_MSTR_REC_SetItemFinals()
    {

        try
        {
            fleICONST_MSTR_REC.set_SetValue("ICONST_CLINIC_PAY_BATCH_NBR", QDesign.Substring(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_PAY_BATCH_NBR"), 1, 2) + QDesign.ASCII(X_BATCH_NBR.Value, 4));


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

    private DDecimal X_PAY_BATCH_NBR = new DDecimal("X_PAY_BATCH_NBR", 4);
    private void X_PAY_BATCH_NBR_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(QDesign.Substring(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_PAY_BATCH_NBR"), 3, 4));


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
    private CoreDecimal X_BATCH_NBR;
    private DCharacter X_CLINIC_BATCH_NBR = new DCharacter("X_CLINIC_BATCH_NBR", 8);
    private void X_CLINIC_BATCH_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.ASCII(fleR031A_BATCH_NBR.GetStringValue("X_CLINIC"), 2) + QDesign.Substring(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_PAY_BATCH_NBR"), 1, 2) + QDesign.ASCII(X_BATCH_NBR.Value, 4);


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
            Value = fleR031A_BATCH_NBR.GetDecimalValue("X_CLAIM_COUNT");


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
    private DDecimal X_TECH_AMT = new DDecimal("X_TECH_AMT", 8);
    private void X_TECH_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;

            if (fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_NBR_1_2") >= 61 & fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_NBR_1_2") <= 75)
            {
                CurrentValue = QDesign.Divide(fleR031A_BATCH_NBR.GetDecimalValue("X_TOTAL_PAID_AMT") * fleTMP_DOCTOR_ALPHA.GetDecimalValue("TMP_COUNTER_1"), fleTMP_DOCTOR_ALPHA.GetDecimalValue("TMP_COUNTER_3"));
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
    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_NBR", true, X_CLINIC_BATCH_NBR.Value);
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_TYPE", true, "P");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD", true, "M");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_ADJ_CD_SUB_TYPE", true, "0");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CLINIC_NBR", true, fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_NBR"));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_BATCH_ENTERED", true, QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_DATE_PERIOD_END", true, QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY"), 4) + QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM"), 2) + QDesign.ASCII(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD"), 2));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_LOC", true, "MISC");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AGENT_CD", true, 0);
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_CYCLE_NBR", true, fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_CYCLE_NBR"));
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_AR_YY_MM", true, "000000");
            if (!Fixed)
                fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_STATUS", true, "1");


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
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_LAST_CLAIM_NBR", X_CLAIM_NBR.Value);
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_NBR_CLAIMS_IN_BATCH", X_CLAIM_NBR.Value);


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
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_BATCH_NBR", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_SERV_CODE", true, "00000");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_CLM_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_LOC", true, "MISC");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_DOC_DEPT", true, fleR031A_BATCH_NBR.GetDecimalValue("DOC_DEPT"));
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
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_BATCH_NBR", true, QDesign.ASCII(fleR031A_BATCH_NBR.GetStringValue("X_CLINIC"), 2) + fleR031A_BATCH_NBR.GetStringValue("DOC_NBR") + QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 3, 3));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_CLAIM_NBR", true, 1);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_OMA_CD", true, "0000");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_OMA_SUFF", true, "0");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ADJ_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_I_O_PAT_IND", true, "O");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AGENT_CD", true, fleF001_BATCH_CONTROL_FILE.GetDecimalValue("BATCTRL_AGENT_CD"));
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
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", true, "N");
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS", true, fleR031A_BATCH_NBR.GetDecimalValue("X_TOTAL_PAID_AMT"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_AMT_TECH_PAID", true, X_TECH_AMT.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ORIG_BATCH_NBR", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("CLMHDR_ORIG_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
                fleF002_ADJ_HDR.set_SetValue("KEY_P_CLM_TYPE", true, "Z");


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
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_BATCH_NBR", true, fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_CLAIM_NBR", true, X_CLAIM_NBR.Value);
            if (!Fixed)
            {
                if (QDesign.NULL(QDesign.Substring(fleR031A_BATCH_NBR.GetStringValue("X_ADJ_CD"), 1, 4)) == "MOHD")
                {
                    fleF002_ADJ_DTL.set_SetValue("KEY_CLM_SERV_CODE", true, "MOHD");
                }
                else
                {
                    fleF002_ADJ_DTL.set_SetValue("KEY_CLM_SERV_CODE", true, fleR031A_BATCH_NBR.GetStringValue("X_ADJ_CD"));
                }
            }
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_CLM_ADJ_NBR", true, "0");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_BATCH_NBR", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_BATCH_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_CLAIM_NBR", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"));
            if (!Fixed)
            {
                if (QDesign.NULL(QDesign.Substring(fleR031A_BATCH_NBR.GetStringValue("X_ADJ_CD"), 1, 4)) == "MOHD")
                {
                    fleF002_ADJ_DTL.set_SetValue("CLMDTL_OMA_CD", true, "MOHD");
                }
                else
                {
                    fleF002_ADJ_DTL.set_SetValue("CLMDTL_OMA_CD", true, fleR031A_BATCH_NBR.GetStringValue("X_ADJ_CD"));
                }
            }
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_OMA_SUFF", true, " ");
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ADJ_NBR", true, 1);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_AGENT_CD", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_AGENT_CD"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ADJ_CD", true, fleF002_ADJ_HDR.GetStringValue("CLMHDR_ADJ_CD"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_YY", true, QDesign.NConvert(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(0, 4)));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_MM", true, QDesign.NConvert(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(4, 2)));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_MM", true, QDesign.NConvert(QDesign.ASCII(QDesign.SysDate(ref m_cnnQUERY), 8).Substring(6, 2)));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_NBR_SERV", true, 0);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_NBR_1", true, 0);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_DAY_1", true, 0);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_NBR_2", true, 0);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_DAY_2", true, 0);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_NBR_3", true, 0);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_SV_DAY_3", true, 0);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_DATE_PERIOD_END", true, QDesign.ASCII(fleF002_ADJ_HDR.GetNumericDateValue("CLMHDR_DATE_PERIOD_END"), 8));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_CYCLE_NBR", true, fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_CYCLE_NBR"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_FEE_OMA", true, fleR031A_BATCH_NBR.GetDecimalValue("X_TOTAL_PAID_AMT"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_FEE_OHIP", true, fleR031A_BATCH_NBR.GetDecimalValue("X_TOTAL_PAID_AMT"));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_AMT_TECH_BILLED", true, X_TECH_AMT.Value);
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ORIG_BATCH_NBR", true, QDesign.NConvert((fleF002_ADJ_HDR.GetStringValue("CLMHDR_ORIG_BATCH_NBR") + QDesign.ASCII(fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_ORIG_CLAIM_NBR"), 2)).Substring(0, 8)));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH", true, QDesign.NConvert((fleF002_ADJ_HDR.GetStringValue("CLMHDR_ORIG_BATCH_NBR") + QDesign.ASCII(fleF002_ADJ_HDR.GetDecimalValue("CLMHDR_ORIG_CLAIM_NBR"), 2)).Substring(8, 2)));
            if (!Fixed)
                fleF002_ADJ_DTL.set_SetValue("KEY_P_CLM_TYPE", true, "Z");
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

    private SqlFileObject fleR031A_PAY_BATCHES;


    #endregion


    #region "Standard Generated Procedures(U030B_PART3_B_CREATE_PAYMENT_RECS_1)"


    #region "Automatic Item Initialization(U030B_PART3_B_CREATE_PAYMENT_RECS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART3_B_CREATE_PAYMENT_RECS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:46 PM

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
        fleR031A_BATCH_NBR.Transaction = m_trnTRANS_UPDATE;
        fleTMP_DOCTOR_ALPHA.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF002_ADJ_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_ADJ_DTL.Transaction = m_trnTRANS_UPDATE;
        fleR031A_PAY_BATCHES.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART3_B_CREATE_PAYMENT_RECS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:46 PM

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
            fleR031A_BATCH_NBR.Dispose();
            fleTMP_DOCTOR_ALPHA.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleF002_ADJ_HDR.Dispose();
            fleF002_ADJ_DTL.Dispose();
            fleR031A_PAY_BATCHES.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART3_B_CREATE_PAYMENT_RECS_1)"


    public void Run()
    {

        try
        {
            Request("CREATE_PAYMENT_RECS_1");

            while (fleR031A_BATCH_NBR.QTPForMissing())
            {
                // --> GET R031A_BATCH_NBR <--

                fleR031A_BATCH_NBR.GetData();
                // --> End GET R031A_BATCH_NBR <--

                while (fleTMP_DOCTOR_ALPHA.QTPForMissing("1"))
                {
                    // --> GET TMP_DOCTOR_ALPHA <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleTMP_DOCTOR_ALPHA.ElementOwner("DOC_OHIP_NBR")).Append(" = ");
                    m_strWhere.Append((fleR031A_BATCH_NBR.GetDecimalValue("DOC_OHIP_NBR")));
                    m_strWhere.Append(" And ").Append(fleTMP_DOCTOR_ALPHA.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(" "));
                    m_strWhere.Append(" And ").Append(fleTMP_DOCTOR_ALPHA.ElementOwner("TMP_ALPHA_FIELD_1")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.ASCII(fleR031A_BATCH_NBR.GetDecimalValue("ICONST_CLINIC_NBR_1_2"), 2)));

                    fleTMP_DOCTOR_ALPHA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET TMP_DOCTOR_ALPHA <--

                    while (fleICONST_MSTR_REC.QTPForMissing("2"))
                    {
                        // --> GET ICONST_MSTR_REC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                        m_strWhere.Append((fleR031A_BATCH_NBR.GetDecimalValue("X_CLINIC")));

                        fleICONST_MSTR_REC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET ICONST_MSTR_REC <--

                        if (Transaction())
                        {
                            Sort(fleR031A_BATCH_NBR.GetSortValue("X_CLINIC"), fleR031A_BATCH_NBR.GetSortValue("X_BATCH_COUNT"));
                        }
                    }
                }
            }

            while (Sort(fleR031A_BATCH_NBR, fleTMP_DOCTOR_ALPHA, fleICONST_MSTR_REC))
            {
                if (fleR031A_BATCH_NBR.At("X_CLINIC") || fleR031A_BATCH_NBR.At("X_BATCH_COUNT"))
                {
                    X_BATCH_NBR.Value = X_PAY_BATCH_NBR.Value + fleR031A_BATCH_NBR.GetDecimalValue("X_BATCH_COUNT");
                }

                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_ACT", fleR031A_BATCH_NBR.GetDecimalValue("X_TOTAL_PAID_AMT"));
                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_AMT_EST", fleR031A_BATCH_NBR.GetDecimalValue("X_TOTAL_PAID_AMT"));
                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_CALC_TOT_REV", fleR031A_BATCH_NBR.GetDecimalValue("X_TOTAL_PAID_AMT"));
                SubTotal(ref fleF001_BATCH_CONTROL_FILE, "BATCTRL_MANUAL_PAY_TOT", fleR031A_BATCH_NBR.GetDecimalValue("X_TOTAL_PAID_AMT"));

                SubFile(ref m_trnTRANS_UPDATE, ref fleR031A_PAY_BATCHES, fleR031A_BATCH_NBR.At("X_CLINIC") || fleR031A_BATCH_NBR.At("X_BATCH_COUNT"), SubFileType.Keep, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR", "BATCTRL_MANUAL_PAY_TOT");

                fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Add, fleR031A_BATCH_NBR.At("X_CLINIC") || fleR031A_BATCH_NBR.At("X_BATCH_COUNT"), null);
                fleF002_ADJ_HDR.OutPut(OutPutType.Add);
                fleF002_ADJ_DTL.OutPut(OutPutType.Add);
                fleICONST_MSTR_REC.OutPut(OutPutType.Update, fleR031A_BATCH_NBR.At("X_CLINIC") || fleR031A_BATCH_NBR.At("X_BATCH_COUNT"), null);

            
                Reset(ref X_BATCH_NBR, X_PAY_BATCH_NBR.Value, fleR031A_BATCH_NBR.At("X_CLINIC") || fleR031A_BATCH_NBR.At("X_BATCH_COUNT"));
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
            EndRequest("CREATE_PAYMENT_RECS_1");
        }
    }

    #endregion
}
//CREATE_PAYMENT_RECS_1




