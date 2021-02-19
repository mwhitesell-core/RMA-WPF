
#region "Screen Comments"

// unlof002_me_claim.qts
// 2015/Jul/14 MC - extract monthend claims/payment/adjustment for the selected monthend
// - this program will be run as part of the monthend report macro before u210.qts
// 2015/Jul/28 MC1 - comment out the redundant x-delimiter after clmhdr-pat-ohip-id-or-chart
// 2015/Aug/06 MC2  - create subfile in /foxtrot/bi instead of working directory (production) as Brad suggested


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class UNLOF002_ME_CLAIM : BaseClassControl
{

    private UNLOF002_ME_CLAIM m_UNLOF002_ME_CLAIM;

    public UNLOF002_ME_CLAIM(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public UNLOF002_ME_CLAIM(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_UNLOF002_ME_CLAIM != null))
        {
            m_UNLOF002_ME_CLAIM.CloseTransactionObjects();
            m_UNLOF002_ME_CLAIM = null;
        }
    }

    public UNLOF002_ME_CLAIM GetUNLOF002_ME_CLAIM(int Level)
    {
        if (m_UNLOF002_ME_CLAIM == null)
        {
            m_UNLOF002_ME_CLAIM = new UNLOF002_ME_CLAIM("UNLOF002_ME_CLAIM", Level);
        }
        else
        {
            m_UNLOF002_ME_CLAIM.ResetValues();
        }
        return m_UNLOF002_ME_CLAIM;
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

            UNLOF002_ME_CLAIM_UNLOF002_1 UNLOF002_1 = new UNLOF002_ME_CLAIM_UNLOF002_1(Name, Level);
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



public class UNLOF002_ME_CLAIM_UNLOF002_1 : UNLOF002_ME_CLAIM
{

    public UNLOF002_ME_CLAIM_UNLOF002_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleUNLOF002HDR_BI_SEL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UNLOF002HDR_BI_SEL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleUNLOF002DTL_BI_SEL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UNLOF002DTL_BI_SEL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleUNLOF002DTL_2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UNLOF002DTL_BI_SEL", "UNLOF002DTL_2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleUNLOF002DTL_3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UNLOF002DTL_BI_SEL", "UNLOF002DTL_3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleUNLOF002DTL_4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "UNLOF002DTL_BI_SEL", "UNLOF002DTL_4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_MONTHEND.GetValue += X_MONTHEND_GetValue;
        BILLED_AMT.GetValue += BILLED_AMT_GetValue;
        ADJUST_AMT.GetValue += ADJUST_AMT_GetValue;
        PAYMENT_AMT.GetValue += PAYMENT_AMT_GetValue;
        FLAG.GetValue += FLAG_GetValue;
        X_DELIMITER.GetValue += X_DELIMITER_GetValue;
        X_CR.GetValue += X_CR_GetValue;
        CR.GetValue += CR_GetValue;
        X_LF.GetValue += X_LF_GetValue;
        LF.GetValue += LF_GetValue;
        X_CLMDTL_CONSEC_DATES_SRV2.GetValue += X_CLMDTL_CONSEC_DATES_SRV2_GetValue;
        X_CLMDTL_CONSEC_DATES_SRV3.GetValue += X_CLMDTL_CONSEC_DATES_SRV3_GetValue;
        X_CLMDTL_CONSEC_DATES_SRV4.GetValue += X_CLMDTL_CONSEC_DATES_SRV4_GetValue;
        X_CLMDTL_CONSEC_DATES_DAY2.GetValue += X_CLMDTL_CONSEC_DATES_DAY2_GetValue;
        X_CLMDTL_CONSEC_DATES_DAY3.GetValue += X_CLMDTL_CONSEC_DATES_DAY3_GetValue;
        X_CLMDTL_CONSEC_DATES_DAY4.GetValue += X_CLMDTL_CONSEC_DATES_DAY4_GetValue;
        CLMDTL_NBR_SERV_1.GetValue += CLMDTL_NBR_SERV_1_GetValue;
        CLMDTL_NBR_SERV_2.GetValue += CLMDTL_NBR_SERV_2_GetValue;
        CLMDTL_NBR_SERV_3.GetValue += CLMDTL_NBR_SERV_3_GetValue;
        CLMDTL_NBR_SERV_4.GetValue += CLMDTL_NBR_SERV_4_GetValue;
        CLMDTL_SV_DATE_2.GetValue += CLMDTL_SV_DATE_2_GetValue;
        CLMDTL_SV_DATE_3.GetValue += CLMDTL_SV_DATE_3_GetValue;
        CLMDTL_SV_DATE_4.GetValue += CLMDTL_SV_DATE_4_GetValue;
        X_NBR_SVCS.GetValue += X_NBR_SVCS_GetValue;
        X_OHIP_FEE.GetValue += X_OHIP_FEE_GetValue;
        CLMDTL_FEE_OHIP_1.GetValue += CLMDTL_FEE_OHIP_1_GetValue;
        CLMDTL_FEE_OHIP_2.GetValue += CLMDTL_FEE_OHIP_2_GetValue;
        CLMDTL_FEE_OHIP_3.GetValue += CLMDTL_FEE_OHIP_3_GetValue;
        CLMDTL_FEE_OHIP_4.GetValue += CLMDTL_FEE_OHIP_4_GetValue;
        X_OMA_FEE.GetValue += X_OMA_FEE_GetValue;
        CLMDTL_FEE_OMA_1.GetValue += CLMDTL_FEE_OMA_1_GetValue;
        CLMDTL_FEE_OMA_2.GetValue += CLMDTL_FEE_OMA_2_GetValue;
        CLMDTL_FEE_OMA_3.GetValue += CLMDTL_FEE_OMA_3_GetValue;
        CLMDTL_FEE_OMA_4.GetValue += CLMDTL_FEE_OMA_4_GetValue;
        X_TECH_FEE.GetValue += X_TECH_FEE_GetValue;
        CLMDTL_AMT_TECH_BILLED_1.GetValue += CLMDTL_AMT_TECH_BILLED_1_GetValue;
        CLMDTL_AMT_TECH_BILLED_2.GetValue += CLMDTL_AMT_TECH_BILLED_2_GetValue;
        CLMDTL_AMT_TECH_BILLED_3.GetValue += CLMDTL_AMT_TECH_BILLED_3_GetValue;
        CLMDTL_AMT_TECH_BILLED_4.GetValue += CLMDTL_AMT_TECH_BILLED_4_GetValue;
        CLMDTL_FLAG_OP.GetValue += CLMDTL_FLAG_OP_GetValue;
        CLMDTL_FLAG_BI.GetValue += CLMDTL_FLAG_BI_GetValue;

        fleICONST_MSTR_REC.SelectIf += fleICONST_MSTR_REC_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(UNLOF002_ME_CLAIM_UNLOF002_1)"

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleICONST_MSTR_REC;

    private void fleICONST_MSTR_REC_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_MONTHEND")).Append(" =  X_MONTHEND.Value)");


            SelectIfClause = strSQL.ToString();


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

    private DCharacter X_MONTHEND = new DCharacter("X_MONTHEND", 1);
    private void X_MONTHEND_GetValue(ref string Value)
    {

        try
        {
            Value = Prompt(1).ToString();


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
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_DATE_PERIOD_END")) == QDesign.NULL(QDesign.ASCII(fleICONST_MSTR_REC.GetNumericDateValue("ICONST_DATE_PERIOD_END"))))
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

    private DDecimal BILLED_AMT = new DDecimal("BILLED_AMT", 7);
    private void BILLED_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_TYPE")) == "C")
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
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
    private DDecimal ADJUST_AMT = new DDecimal("ADJUST_AMT", 7);
    private void ADJUST_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_TYPE")) == "A")
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP");
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
    private DDecimal PAYMENT_AMT = new DDecimal("PAYMENT_AMT", 7);
    private void PAYMENT_AMT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_TYPE")) == "P")
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
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
    private DCharacter FLAG = new DCharacter("FLAG", 1);
    private void FLAG_GetValue(ref string Value)
    {

        try
        {
            Value = "N";


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
            Value= QDesign.Substring(QDesign.Characters(X_CR.Value), 1, 1);


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
            Value= QDesign.Substring(QDesign.Characters(X_LF.Value), 1, 1);


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









    private SqlFileObject fleUNLOF002HDR_BI_SEL;
    private DCharacter X_CLMDTL_CONSEC_DATES_SRV2 = new DCharacter("X_CLMDTL_CONSEC_DATES_SRV2", 1);
    private void X_CLMDTL_CONSEC_DATES_SRV2_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 1, 1);
            //Parent:CLMDTL_CONSEC_DATES_R


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
    private DCharacter X_CLMDTL_CONSEC_DATES_SRV3 = new DCharacter("X_CLMDTL_CONSEC_DATES_SRV3", 1);
    private void X_CLMDTL_CONSEC_DATES_SRV3_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 4, 1);
            //Parent:CLMDTL_CONSEC_DATES_R


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
    private DCharacter X_CLMDTL_CONSEC_DATES_SRV4 = new DCharacter("X_CLMDTL_CONSEC_DATES_SRV4", 1);
    private void X_CLMDTL_CONSEC_DATES_SRV4_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 7, 1);
            //Parent:CLMDTL_CONSEC_DATES_R


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
    private DCharacter X_CLMDTL_CONSEC_DATES_DAY2 = new DCharacter("X_CLMDTL_CONSEC_DATES_DAY2", 2);
    private void X_CLMDTL_CONSEC_DATES_DAY2_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) == "00" | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) == "0" | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) == " 0" | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) == QDesign.NULL("  ") | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) == "BI" | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) == "OP")
            {
                CurrentValue = "00";
            }
            else
            {
                CurrentValue= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2);
                //Parent:CLMDTL_CONSEC_DATES_R
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
    private DCharacter X_CLMDTL_CONSEC_DATES_DAY3 = new DCharacter("X_CLMDTL_CONSEC_DATES_DAY3", 2);
    private void X_CLMDTL_CONSEC_DATES_DAY3_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 5, 2)) == "00" | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 5, 2)) == "0" | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 5, 2)) == " 0" | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 5, 2)) == QDesign.NULL("  "))
            {
                CurrentValue = "00";
            }
            else
            {
                CurrentValue= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 5, 2);
                //Parent:CLMDTL_CONSEC_DATES_R
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
    private DCharacter X_CLMDTL_CONSEC_DATES_DAY4 = new DCharacter("X_CLMDTL_CONSEC_DATES_DAY4", 2);
    private void X_CLMDTL_CONSEC_DATES_DAY4_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 8, 2)) == "00" | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 8, 2)) == "0" | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 8, 2)) == " 0" | QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 8, 2)) == QDesign.NULL("  "))
            {
                CurrentValue = "00";
            }
            else
            {
                CurrentValue= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 8, 2);
                //Parent:CLMDTL_CONSEC_DATES_R
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
    private DDecimal CLMDTL_NBR_SERV_1 = new DDecimal("CLMDTL_NBR_SERV_1", 2);
    private void CLMDTL_NBR_SERV_1_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV");


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
    private DDecimal CLMDTL_NBR_SERV_2 = new DDecimal("CLMDTL_NBR_SERV_2", 2);
    private void CLMDTL_NBR_SERV_2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CLMDTL_CONSEC_DATES_SRV2.Value) == "0")
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = QDesign.NConvert(X_CLMDTL_CONSEC_DATES_SRV2.Value);
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
    private DDecimal CLMDTL_NBR_SERV_3 = new DDecimal("CLMDTL_NBR_SERV_3", 2);
    private void CLMDTL_NBR_SERV_3_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CLMDTL_CONSEC_DATES_SRV3.Value) == "0")
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = QDesign.NConvert(X_CLMDTL_CONSEC_DATES_SRV3.Value);
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
    private DDecimal CLMDTL_NBR_SERV_4 = new DDecimal("CLMDTL_NBR_SERV_4", 2);
    private void CLMDTL_NBR_SERV_4_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(X_CLMDTL_CONSEC_DATES_SRV4.Value) == "0")
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = QDesign.NConvert(X_CLMDTL_CONSEC_DATES_SRV4.Value);
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
    private DCharacter CLMDTL_SV_DATE_2 = new DCharacter("CLMDTL_SV_DATE_2", 8);
    private void CLMDTL_SV_DATE_2_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CLMDTL_CONSEC_DATES_DAY2.Value) == "00")
            {
                CurrentValue = "19000101";
            }
            else
            {
                CurrentValue= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + X_CLMDTL_CONSEC_DATES_DAY2.Value;

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
    private DCharacter CLMDTL_SV_DATE_3 = new DCharacter("CLMDTL_SV_DATE_3", 8);
    private void CLMDTL_SV_DATE_3_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CLMDTL_CONSEC_DATES_DAY3.Value) == "00")
            {
                CurrentValue = "19000101";
            }
            else
            {
                CurrentValue= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + X_CLMDTL_CONSEC_DATES_DAY3.Value;

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
    private DCharacter CLMDTL_SV_DATE_4 = new DCharacter("CLMDTL_SV_DATE_4", 8);
    private void CLMDTL_SV_DATE_4_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(X_CLMDTL_CONSEC_DATES_DAY4.Value) == "00")
            {
                CurrentValue = "19000101";
            }
            else
            {
                CurrentValue= QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + X_CLMDTL_CONSEC_DATES_DAY4.Value;

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
    private DDecimal X_NBR_SVCS = new DDecimal("X_NBR_SVCS", 2);
    private void X_NBR_SVCS_GetValue(ref decimal Value)
    {

        try
        {
            Value = CLMDTL_NBR_SERV_1.Value + CLMDTL_NBR_SERV_2.Value + CLMDTL_NBR_SERV_3.Value + CLMDTL_NBR_SERV_4.Value;


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
    private DDecimal X_OHIP_FEE = new DDecimal("X_OHIP_FEE", 7);
    private void X_OHIP_FEE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP") / X_NBR_SVCS.Value;
            }
            else
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP");
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
    private DDecimal CLMDTL_FEE_OHIP_1 = new DDecimal("CLMDTL_FEE_OHIP_1", 7);
    private void CLMDTL_FEE_OHIP_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = CLMDTL_NBR_SERV_1.Value * X_OHIP_FEE.Value;
            }
            else
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP");
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
    private DDecimal CLMDTL_FEE_OHIP_2 = new DDecimal("CLMDTL_FEE_OHIP_2", 7);
    private void CLMDTL_FEE_OHIP_2_GetValue(ref decimal Value)
    {

        try
        {
            Value = CLMDTL_NBR_SERV_2.Value * X_OHIP_FEE.Value;


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
    private DDecimal CLMDTL_FEE_OHIP_3 = new DDecimal("CLMDTL_FEE_OHIP_3", 7);
    private void CLMDTL_FEE_OHIP_3_GetValue(ref decimal Value)
    {

        try
        {
            Value = CLMDTL_NBR_SERV_3.Value * X_OHIP_FEE.Value;


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
    private DDecimal CLMDTL_FEE_OHIP_4 = new DDecimal("CLMDTL_FEE_OHIP_4", 7);
    private void CLMDTL_FEE_OHIP_4_GetValue(ref decimal Value)
    {

        try
        {
            Value = CLMDTL_NBR_SERV_4.Value * X_OHIP_FEE.Value;


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
    private DDecimal X_OMA_FEE = new DDecimal("X_OMA_FEE", 7);
    private void X_OMA_FEE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OMA") / X_NBR_SVCS.Value;
            }
            else
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OMA");
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
    private DDecimal CLMDTL_FEE_OMA_1 = new DDecimal("CLMDTL_FEE_OMA_1", 7);
    private void CLMDTL_FEE_OMA_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = CLMDTL_NBR_SERV_1.Value * X_OMA_FEE.Value;
            }
            else
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OMA");
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
    private DDecimal CLMDTL_FEE_OMA_2 = new DDecimal("CLMDTL_FEE_OMA_2", 7);
    private void CLMDTL_FEE_OMA_2_GetValue(ref decimal Value)
    {

        try
        {
            Value = CLMDTL_NBR_SERV_2.Value * X_OMA_FEE.Value;


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
    private DDecimal CLMDTL_FEE_OMA_3 = new DDecimal("CLMDTL_FEE_OMA_3", 7);
    private void CLMDTL_FEE_OMA_3_GetValue(ref decimal Value)
    {

        try
        {
            Value = CLMDTL_NBR_SERV_3.Value * X_OMA_FEE.Value;


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
    private DDecimal CLMDTL_FEE_OMA_4 = new DDecimal("CLMDTL_FEE_OMA_4", 7);
    private void CLMDTL_FEE_OMA_4_GetValue(ref decimal Value)
    {

        try
        {
            Value = CLMDTL_NBR_SERV_4.Value * X_OMA_FEE.Value;


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
    private DDecimal X_TECH_FEE = new DDecimal("X_TECH_FEE", 7);
    private void X_TECH_FEE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;

            // TODO: Expression may need to be checked for DIVISION by 0.  Manual steps may be required:

            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_AMT_TECH_BILLED") / X_NBR_SVCS.Value;
            }
            else
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_AMT_TECH_BILLED");
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
    private DDecimal CLMDTL_AMT_TECH_BILLED_1 = new DDecimal("CLMDTL_AMT_TECH_BILLED_1", 7);
    private void CLMDTL_AMT_TECH_BILLED_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = CLMDTL_NBR_SERV_1.Value * X_TECH_FEE.Value;
            }
            else
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_AMT_TECH_BILLED");
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
    private DDecimal CLMDTL_AMT_TECH_BILLED_2 = new DDecimal("CLMDTL_AMT_TECH_BILLED_2", 7);
    private void CLMDTL_AMT_TECH_BILLED_2_GetValue(ref decimal Value)
    {

        try
        {
            Value = CLMDTL_NBR_SERV_2.Value * X_TECH_FEE.Value;


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
    private DDecimal CLMDTL_AMT_TECH_BILLED_3 = new DDecimal("CLMDTL_AMT_TECH_BILLED_3", 7);
    private void CLMDTL_AMT_TECH_BILLED_3_GetValue(ref decimal Value)
    {

        try
        {
            Value = CLMDTL_NBR_SERV_3.Value * X_TECH_FEE.Value;


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
    private DDecimal CLMDTL_AMT_TECH_BILLED_4 = new DDecimal("CLMDTL_AMT_TECH_BILLED_4", 7);
    private void CLMDTL_AMT_TECH_BILLED_4_GetValue(ref decimal Value)
    {

        try
        {
            Value = CLMDTL_NBR_SERV_4.Value * X_TECH_FEE.Value;


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
    private DCharacter CLMDTL_FLAG_OP = new DCharacter("CLMDTL_FLAG_OP", 2);
    private void CLMDTL_FLAG_OP_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) == "OP")
            {
                CurrentValue = "OP";
            }
            else
            {
                CurrentValue = " ";
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
    private DCharacter CLMDTL_FLAG_BI = new DCharacter("CLMDTL_FLAG_BI", 2);
    private void CLMDTL_FLAG_BI_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2)) == "BI")
            {
                CurrentValue = "BI";
            }
            else
            {
                CurrentValue = " ";
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









    private SqlFileObject fleUNLOF002DTL_BI_SEL;









    private SqlFileObject fleUNLOF002DTL_2;









    private SqlFileObject fleUNLOF002DTL_3;









    private SqlFileObject fleUNLOF002DTL_4;


    #endregion


    #region "Standard Generated Procedures(UNLOF002_ME_CLAIM_UNLOF002_1)"


    #region "Automatic Item Initialization(UNLOF002_ME_CLAIM_UNLOF002_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(UNLOF002_ME_CLAIM_UNLOF002_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:02 PM

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
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleUNLOF002HDR_BI_SEL.Transaction = m_trnTRANS_UPDATE;
        fleUNLOF002DTL_BI_SEL.Transaction = m_trnTRANS_UPDATE;
        fleUNLOF002DTL_2.Transaction = m_trnTRANS_UPDATE;
        fleUNLOF002DTL_3.Transaction = m_trnTRANS_UPDATE;
        fleUNLOF002DTL_4.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(UNLOF002_ME_CLAIM_UNLOF002_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:53:02 PM

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
            fleICONST_MSTR_REC.Dispose();
            fleUNLOF002HDR_BI_SEL.Dispose();
            fleUNLOF002DTL_BI_SEL.Dispose();
            fleUNLOF002DTL_2.Dispose();
            fleUNLOF002DTL_3.Dispose();
            fleUNLOF002DTL_4.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UNLOF002_ME_CLAIM_UNLOF002_1)"


    public void Run()
    {

        try
        {
            Request("UNLOF002_1");

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

                    while (fleICONST_MSTR_REC.QTPForMissing("2"))
                    {
                        // --> GET ICONST_MSTR_REC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                        m_strWhere.Append(((QDesign.NConvert(QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 1, 2)))));

                        fleICONST_MSTR_REC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET ICONST_MSTR_REC <--


                        if (Transaction())
                        {

                             if (Select_If())
                            {









                                SubFile(ref m_trnTRANS_UPDATE, ref fleUNLOF002HDR_BI_SEL, QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) == "0000", SubFileType.Portable, fleF002_CLAIMS_MSTR, "CLMHDR_BATCH_NBR", X_DELIMITER, "CLMHDR_CLAIM_NBR", "CLMHDR_ADJ_OMA_CD", "CLMHDR_ADJ_OMA_CD",
                                "CLMHDR_ADJ_OMA_SUFF", "CLMHDR_BATCH_TYPE", "CLMHDR_ADJ_CD_SUB_TYPE", "CLMHDR_DOC_NBR_OHIP", "CLMHDR_DOC_SPEC_CD", "CLMHDR_REFER_DOC_NBR", "CLMHDR_DIAG_CD", "CLMHDR_LOC", "CLMHDR_PAYROLL", "CLMHDR_AGENT_CD",
                                "CLMHDR_ADJ_CD", "CLMHDR_I_O_PAT_IND", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLMHDR_DOC_DEPT", "CLMHDR_DATE_CASH_TAPE_PAYMENT", "CLMHDR_MSG_NBR", "CLMHDR_REPRINT_FLAG", "CLMHDR_SUB_NBR", "CLMHDR_AUTO_LOGOUT", "CLMHDR_FEE_COMPLEX",
                                "CLMHDR_DATE_PERIOD_END", "CLMHDR_AMT_TECH_BILLED", "CLMHDR_AMT_TECH_PAID", "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", BILLED_AMT, ADJUST_AMT, PAYMENT_AMT, "CLMHDR_STATUS_OHIP",
                                "CLMHDR_MANUAL_REVIEW", "CLMHDR_SERV_DATE", "CLMHDR_ELIG_ERROR", "CLMHDR_ELIG_STATUS", "CLMHDR_SERV_ERROR", "CLMHDR_SERV_STATUS", "CLMHDR_ORIG_BATCH_ID", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR",
                                "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", "KEY_P_CLAIMS_MSTR", FLAG, CR, LF);
                                //Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    )    'Parent:KEY_P_CLAIMS_MSTR)    'Parent:CLMDTL_ORIG_BATCH_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:ICONST_DATE_PERIOD_END










                                SubFile(ref m_trnTRANS_UPDATE, ref fleUNLOF002DTL_BI_SEL, QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "0000" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "ZZZZ", SubFileType.Portable, fleF002_CLAIMS_MSTR, "CLMDTL_ID", X_DELIMITER, "CLMDTL_REV_GROUP_CD", "CLMDTL_AGENT_CD", "CLMDTL_ADJ_CD",
                                "CLMDTL_NBR_SERV", "CLMDTL_SV_DATE", CLMDTL_FLAG_OP, CLMDTL_FLAG_BI, "CLMDTL_CONSEC_DATES_R", CLMDTL_AMT_TECH_BILLED_1, CLMDTL_FEE_OMA_1, CLMDTL_FEE_OHIP_1, "CLMDTL_DATE_PERIOD_END", "CLMDTL_CYCLE_NBR",
                                "CLMDTL_DIAG_CD", "CLMDTL_LINE_NO", "CLMDTL_RESUBMIT_FLAG", "CLMDTL_ORIG_BATCH_ID", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", "KEY_P_CLAIMS_MSTR",
                                FLAG, CR, LF);
                                //Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    )    'Parent:KEY_P_CLAIMS_MSTR)    'Parent:CLMDTL_ORIG_BATCH_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:ICONST_DATE_PERIOD_END










                                SubFile(ref m_trnTRANS_UPDATE, ref fleUNLOF002DTL_2, QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "0000" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "ZZZZ" & QDesign.NULL(CLMDTL_NBR_SERV_2.Value) > 0, SubFileType.Portable, fleF002_CLAIMS_MSTR, "CLMDTL_ID", X_DELIMITER, "CLMDTL_REV_GROUP_CD", "CLMDTL_AGENT_CD", "CLMDTL_ADJ_CD",
                                CLMDTL_NBR_SERV_2, CLMDTL_SV_DATE_2, CLMDTL_FLAG_OP, CLMDTL_FLAG_BI, "CLMDTL_CONSEC_DATES_R", CLMDTL_AMT_TECH_BILLED_2, CLMDTL_FEE_OMA_2, CLMDTL_FEE_OHIP_2, "CLMDTL_DATE_PERIOD_END", "CLMDTL_CYCLE_NBR",
                                "CLMDTL_DIAG_CD", "CLMDTL_LINE_NO", "CLMDTL_RESUBMIT_FLAG", "CLMDTL_ORIG_BATCH_ID", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", "KEY_P_CLAIMS_MSTR",
                                FLAG, CR, LF);
                                //Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    )    'Parent:KEY_P_CLAIMS_MSTR)    'Parent:CLMDTL_ORIG_BATCH_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:ICONST_DATE_PERIOD_END










                                SubFile(ref m_trnTRANS_UPDATE, ref fleUNLOF002DTL_3, QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "0000" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "ZZZZ" & QDesign.NULL(CLMDTL_NBR_SERV_3.Value) > 0, SubFileType.Portable, fleF002_CLAIMS_MSTR, "CLMDTL_ID", X_DELIMITER, "CLMDTL_REV_GROUP_CD", "CLMDTL_AGENT_CD", "CLMDTL_ADJ_CD",
                                CLMDTL_NBR_SERV_3, CLMDTL_SV_DATE_3, CLMDTL_FLAG_OP, CLMDTL_FLAG_BI, "CLMDTL_CONSEC_DATES_R", CLMDTL_AMT_TECH_BILLED_3, CLMDTL_FEE_OMA_3, CLMDTL_FEE_OHIP_3, "CLMDTL_DATE_PERIOD_END", "CLMDTL_CYCLE_NBR",
                                "CLMDTL_DIAG_CD", "CLMDTL_LINE_NO", "CLMDTL_RESUBMIT_FLAG", "CLMDTL_ORIG_BATCH_ID", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", "KEY_P_CLAIMS_MSTR",
                                FLAG, CR, LF);
                                //Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    )    'Parent:KEY_P_CLAIMS_MSTR)    'Parent:CLMDTL_ORIG_BATCH_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:ICONST_DATE_PERIOD_END










                                SubFile(ref m_trnTRANS_UPDATE, ref fleUNLOF002DTL_4, QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "0000" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD")) != "ZZZZ" & QDesign.NULL(CLMDTL_NBR_SERV_4.Value) > 0, SubFileType.Portable, fleF002_CLAIMS_MSTR, "CLMDTL_ID", X_DELIMITER, "CLMDTL_REV_GROUP_CD", "CLMDTL_AGENT_CD", "CLMDTL_ADJ_CD",
                                CLMDTL_NBR_SERV_4, CLMDTL_SV_DATE_4, CLMDTL_FLAG_OP, CLMDTL_FLAG_BI, "CLMDTL_CONSEC_DATES_R", CLMDTL_AMT_TECH_BILLED_4, CLMDTL_FEE_OMA_4, CLMDTL_FEE_OHIP_4, "CLMDTL_DATE_PERIOD_END", "CLMDTL_CYCLE_NBR",
                                "CLMDTL_DIAG_CD", "CLMDTL_LINE_NO", "CLMDTL_RESUBMIT_FLAG", "CLMDTL_ORIG_BATCH_ID", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", "KEY_P_CLAIMS_MSTR",
                                FLAG, CR, LF);
                                //Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMDTL_ID)    'Parent:CLMDTL_SV_DATE)    )    'Parent:KEY_P_CLAIMS_MSTR)    'Parent:CLMDTL_ORIG_BATCH_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:ICONST_DATE_PERIOD_END


                            }

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
            EndRequest("UNLOF002_1");

        }

    }




    #endregion


}
//UNLOF002_1




