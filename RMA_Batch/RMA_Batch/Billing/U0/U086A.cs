
#region "Screen Comments"

// #> PROGRAM-ID.     u086a.qts
// ((C)) Dyad Technologies
// PROGRAM PURPOSE: When a claim is assigned to the wrong patient the
// users are allowed to update the `ikey` of the claim
// to point to the corrected patient. If ALL claims
// of the  original  or  old  patient are to be re-assigned
// to the  new  patient then the old/new patient info
// is write to f086a-orig-new-pat-ids file.
// This file is used by this program as a driver file
// to change ownership of the claims.
// MODIFICATION HISTORY
// DATE   WHO        DESCRIPTION
// 01/mar/20 B.E. - original 
// 03/dec/23 A.A. - alpha doctor nbr
// 05/aug/16 M.C. - add more criteria when setting `X` to submit ind
// also add bal-due


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U086A : BaseClassControl
{

    private U086A m_U086A;

    public U086A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U086A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U086A != null))
        {
            m_U086A.CloseTransactionObjects();
            m_U086A = null;
        }
    }

    public U086A GetU086A(int Level)
    {
        if (m_U086A == null)
        {
            m_U086A = new U086A("U086A", Level);
        }
        else
        {
            m_U086A.ResetValues();
        }
        return m_U086A;
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

            U086A_PATIENT_CLAIMS_UPDATE_1 PATIENT_CLAIMS_UPDATE_1 = new U086A_PATIENT_CLAIMS_UPDATE_1(Name, Level);
            PATIENT_CLAIMS_UPDATE_1.Run();
            PATIENT_CLAIMS_UPDATE_1.Dispose();
            PATIENT_CLAIMS_UPDATE_1 = null;

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



public class U086A_PATIENT_CLAIMS_UPDATE_1 : U086A
{

    public U086A_PATIENT_CLAIMS_UPDATE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF086A_ORIG_NEW_PAT_IDS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F086A_ORIG_NEW_PAT_IDS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_ORIG = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "F010_ORIG", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_NEW = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "F010_NEW", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU086A_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U086A_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
        BAL_DUE.GetValue += BAL_DUE_GetValue;
        SUBMIT_IND.GetValue += SUBMIT_IND_GetValue;
        fleF010_NEW.InitializeItems += fleF010_NEW_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U086A_PATIENT_CLAIMS_UPDATE_1)"

    private SqlFileObject fleF086A_ORIG_NEW_PAT_IDS;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_KEY_TYPE", (fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(0, 1));
            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_KEY_DATA", (fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(1, 15));
            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART
            fleF002_CLAIMS_MSTR.set_SetValue("KEY_P_CLM_DATA", QDesign.Substring(fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART"), 2, 17));
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_ACRONYM6", (fleF010_NEW.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_NEW.GetStringValue("PAT_ACRONYM_LAST3")).PadRight(9).Substring(0, 6));
            //Parent:CLMHDR_PAT_ACRONYM    'Parent:PAT_ACRONYM
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_PAT_ACRONYM3", (fleF010_NEW.GetStringValue("PAT_ACRONYM_FIRST6") + fleF010_NEW.GetStringValue("PAT_ACRONYM_LAST3")).PadRight(9).Substring(6, 3));
            //Parent:CLMHDR_PAT_ACRONYM    'Parent:PAT_ACRONYM
            fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", SUBMIT_IND.Value);


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

    private SqlFileObject fleF010_ORIG;
    private SqlFileObject fleF010_NEW;
    private SqlFileObject fleF001_BATCH_CONTROL_FILE;
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
    private DDecimal BAL_DUE = new DDecimal("BAL_DUE", 7);
    private void BAL_DUE_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");


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
    private DCharacter SUBMIT_IND = new DCharacter("SUBMIT_IND", 1);
    private void SUBMIT_IND_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR")) != "00000000" & string.Compare(QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS")) , QDesign.NULL(BATCTRL_BATCH_STATUS_OHIP_SENT.Value))<0)
            {
                CurrentValue = " ";
            }
            else if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SUBMIT_DATE")) == 0 & QDesign.NULL(BAL_DUE.Value) > 0 & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_STATUS_OHIP")) != "I2")
            {
                CurrentValue = "X";
            }
            else if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SUBMIT_DATE")) != 0 & QDesign.NULL(BAL_DUE.Value) > 0 & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_STATUS_OHIP")) != "I2")
            {
                CurrentValue = "R";
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


    private SqlFileObject fleU086A_AUDIT;


    #endregion


    #region "Standard Generated Procedures(U086A_PATIENT_CLAIMS_UPDATE_1)"


    #region "Automatic Item Initialization(U086A_PATIENT_CLAIMS_UPDATE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:53 PM

    //#-----------------------------------------
    //# fleF010_NEW_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:05:49 PM
    //#-----------------------------------------
    private void fleF010_NEW_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF010_NEW.set_SetValue("PAT_ACRONYM_FIRST6", !Fixed, fleF010_ORIG.GetStringValue("PAT_ACRONYM_FIRST6"));
            fleF010_NEW.set_SetValue("PAT_ACRONYM_LAST3", !Fixed, fleF010_ORIG.GetStringValue("PAT_ACRONYM_LAST3"));
            fleF010_NEW.set_SetValue("PAT_DIRECT_ALPHA", !Fixed, fleF010_ORIG.GetStringValue("PAT_DIRECT_ALPHA"));
            fleF010_NEW.set_SetValue("PAT_DIRECT_YY", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_DIRECT_YY"));
            fleF010_NEW.set_SetValue("PAT_DIRECT_MM", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_DIRECT_MM"));
            fleF010_NEW.set_SetValue("PAT_DIRECT_DD", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_DIRECT_DD"));
            fleF010_NEW.set_SetValue("PAT_DIRECT_LAST_6", !Fixed, fleF010_ORIG.GetStringValue("PAT_DIRECT_LAST_6"));
            fleF010_NEW.set_SetValue("PAT_CHART_NBR", !Fixed, fleF010_ORIG.GetStringValue("PAT_CHART_NBR"));
            fleF010_NEW.set_SetValue("PAT_CHART_NBR_2", !Fixed, fleF010_ORIG.GetStringValue("PAT_CHART_NBR_2"));
            fleF010_NEW.set_SetValue("PAT_CHART_NBR_3", !Fixed, fleF010_ORIG.GetStringValue("PAT_CHART_NBR_3"));
            fleF010_NEW.set_SetValue("PAT_CHART_NBR_4", !Fixed, fleF010_ORIG.GetStringValue("PAT_CHART_NBR_4"));
            fleF010_NEW.set_SetValue("PAT_CHART_NBR_5", !Fixed, fleF010_ORIG.GetStringValue("PAT_CHART_NBR_5"));
            fleF010_NEW.set_SetValue("PAT_SURNAME_FIRST3", !Fixed, fleF010_ORIG.GetStringValue("PAT_SURNAME_FIRST3"));
            fleF010_NEW.set_SetValue("PAT_SURNAME_LAST22", !Fixed, fleF010_ORIG.GetStringValue("PAT_SURNAME_LAST22"));
            fleF010_NEW.set_SetValue("PAT_GIVEN_NAME_FIRST1", !Fixed, fleF010_ORIG.GetStringValue("PAT_GIVEN_NAME_FIRST1"));
            fleF010_NEW.set_SetValue("FILLER3", !Fixed, fleF010_ORIG.GetStringValue("FILLER3"));
            fleF010_NEW.set_SetValue("PAT_INIT1", !Fixed, fleF010_ORIG.GetStringValue("PAT_INIT1"));
            fleF010_NEW.set_SetValue("PAT_INIT2", !Fixed, fleF010_ORIG.GetStringValue("PAT_INIT2"));
            fleF010_NEW.set_SetValue("PAT_INIT3", !Fixed, fleF010_ORIG.GetStringValue("PAT_INIT3"));
            fleF010_NEW.set_SetValue("PAT_LOCATION_FIELD", !Fixed, fleF010_ORIG.GetStringValue("PAT_LOCATION_FIELD"));
            fleF010_NEW.set_SetValue("PAT_LAST_DOC_NBR_SEEN", !Fixed, fleF010_ORIG.GetStringValue("PAT_LAST_DOC_NBR_SEEN"));
            fleF010_NEW.set_SetValue("PAT_BIRTH_DATE_YY", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_BIRTH_DATE_YY"));
            fleF010_NEW.set_SetValue("PAT_BIRTH_DATE_MM", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_BIRTH_DATE_MM"));
            fleF010_NEW.set_SetValue("PAT_BIRTH_DATE_DD", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_BIRTH_DATE_DD"));
            fleF010_NEW.set_SetValue("PAT_DATE_LAST_MAINT", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_DATE_LAST_MAINT"));
            fleF010_NEW.set_SetValue("PAT_DATE_LAST_VISIT", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_DATE_LAST_VISIT"));
            fleF010_NEW.set_SetValue("PAT_DATE_LAST_ADMIT", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_DATE_LAST_ADMIT"));
            fleF010_NEW.set_SetValue("PAT_PHONE_NBR", !Fixed, fleF010_ORIG.GetStringValue("PAT_PHONE_NBR"));
            fleF010_NEW.set_SetValue("PAT_TOTAL_NBR_VISITS", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_TOTAL_NBR_VISITS"));
            fleF010_NEW.set_SetValue("PAT_TOTAL_NBR_CLAIMS", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_TOTAL_NBR_CLAIMS"));
            fleF010_NEW.set_SetValue("PAT_SEX", !Fixed, fleF010_ORIG.GetStringValue("PAT_SEX"));
            fleF010_NEW.set_SetValue("PAT_IN_OUT", !Fixed, fleF010_ORIG.GetStringValue("PAT_IN_OUT"));
            fleF010_NEW.set_SetValue("PAT_NBR_OUTSTANDING_CLAIMS", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_NBR_OUTSTANDING_CLAIMS"));
            fleF010_NEW.set_SetValue("PAT_I_KEY", !Fixed, fleF010_ORIG.GetStringValue("PAT_I_KEY"));
            fleF010_NEW.set_SetValue("PAT_CON_NBR", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_CON_NBR"));
            fleF010_NEW.set_SetValue("PAT_I_NBR", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_I_NBR"));
            fleF010_NEW.set_SetValue("FILLER4", !Fixed, fleF010_ORIG.GetStringValue("FILLER4"));
            fleF010_NEW.set_SetValue("PAT_HEALTH_NBR", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_HEALTH_NBR"));
            fleF010_NEW.set_SetValue("PAT_VERSION_CD", !Fixed, fleF010_ORIG.GetStringValue("PAT_VERSION_CD"));
            fleF010_NEW.set_SetValue("PAT_HEALTH_65_IND", !Fixed, fleF010_ORIG.GetStringValue("PAT_HEALTH_65_IND"));
            fleF010_NEW.set_SetValue("PAT_EXPIRY_YY", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_EXPIRY_YY"));
            fleF010_NEW.set_SetValue("PAT_EXPIRY_MM", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_EXPIRY_MM"));
            fleF010_NEW.set_SetValue("PAT_PROV_CD", !Fixed, fleF010_ORIG.GetStringValue("PAT_PROV_CD"));
            fleF010_NEW.set_SetValue("SUBSCR_ADDR1", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_ADDR1"));
            fleF010_NEW.set_SetValue("SUBSCR_ADDR2", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_ADDR2"));
            fleF010_NEW.set_SetValue("SUBSCR_ADDR3", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_ADDR3"));
            fleF010_NEW.set_SetValue("SUBSCR_PROV_CD", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_PROV_CD"));
            fleF010_NEW.set_SetValue("SUBSCR_POST_CD1", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_POST_CD1"));
            fleF010_NEW.set_SetValue("SUBSCR_POST_CD2", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_POST_CD2"));
            fleF010_NEW.set_SetValue("SUBSCR_POST_CD3", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_POST_CD3"));
            fleF010_NEW.set_SetValue("SUBSCR_POST_CD4", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_POST_CD4"));
            fleF010_NEW.set_SetValue("SUBSCR_POST_CD5", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_POST_CD5"));
            fleF010_NEW.set_SetValue("SUBSCR_POST_CD6", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_POST_CD6"));
            fleF010_NEW.set_SetValue("FILLER", !Fixed, fleF010_ORIG.GetStringValue("FILLER"));
            fleF010_NEW.set_SetValue("SUBSCR_MSG_NBR", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_MSG_NBR"));
            fleF010_NEW.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY", !Fixed, fleF010_ORIG.GetDecimalValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_YY"));
            fleF010_NEW.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM", !Fixed, fleF010_ORIG.GetDecimalValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_MM"));
            fleF010_NEW.set_SetValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD", !Fixed, fleF010_ORIG.GetDecimalValue("SUBSCR_DATE_MSG_NBR_EFFECT_TO_DD"));
            fleF010_NEW.set_SetValue("SUBSCR_DATE_LAST_STATEMENT_YY", !Fixed, fleF010_ORIG.GetDecimalValue("SUBSCR_DATE_LAST_STATEMENT_YY"));
            fleF010_NEW.set_SetValue("SUBSCR_DATE_LAST_STATEMENT_MM", !Fixed, fleF010_ORIG.GetDecimalValue("SUBSCR_DATE_LAST_STATEMENT_MM"));
            fleF010_NEW.set_SetValue("SUBSCR_DATE_LAST_STATEMENT_DD", !Fixed, fleF010_ORIG.GetDecimalValue("SUBSCR_DATE_LAST_STATEMENT_DD"));
            fleF010_NEW.set_SetValue("SUBSCR_AUTO_UPDATE", !Fixed, fleF010_ORIG.GetStringValue("SUBSCR_AUTO_UPDATE"));
            fleF010_NEW.set_SetValue("PAT_LAST_MOD_BY", !Fixed, fleF010_ORIG.GetStringValue("PAT_LAST_MOD_BY"));
            fleF010_NEW.set_SetValue("PAT_DATE_LAST_ELIG_MAILING", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_DATE_LAST_ELIG_MAILING"));
            fleF010_NEW.set_SetValue("PAT_DATE_LAST_ELIG_MAINT", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_DATE_LAST_ELIG_MAINT"));
            fleF010_NEW.set_SetValue("PAT_LAST_BIRTH_DATE", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_LAST_BIRTH_DATE"));
            fleF010_NEW.set_SetValue("PAT_LAST_VERSION_CD", !Fixed, fleF010_ORIG.GetStringValue("PAT_LAST_VERSION_CD"));
            fleF010_NEW.set_SetValue("PAT_MESS_CODE", !Fixed, fleF010_ORIG.GetStringValue("PAT_MESS_CODE"));
            fleF010_NEW.set_SetValue("PAT_COUNTRY", !Fixed, fleF010_ORIG.GetStringValue("PAT_COUNTRY"));
            fleF010_NEW.set_SetValue("PAT_NO_OF_LETTER_SENT", !Fixed, fleF010_ORIG.GetDecimalValue("PAT_NO_OF_LETTER_SENT"));
            fleF010_NEW.set_SetValue("PAT_DIALYSIS", !Fixed, fleF010_ORIG.GetStringValue("PAT_DIALYSIS"));
            fleF010_NEW.set_SetValue("PAT_OHIP_VALIDATION_STATUS", !Fixed, fleF010_ORIG.GetStringValue("PAT_OHIP_VALIDATION_STATUS"));
            fleF010_NEW.set_SetValue("PAT_OBEC_STATUS", !Fixed, fleF010_ORIG.GetStringValue("PAT_OBEC_STATUS"));

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


    #region "Transaction Management Procedures(U086A_PATIENT_CLAIMS_UPDATE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:48 PM

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
        fleF086A_ORIG_NEW_PAT_IDS.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_ORIG.Transaction = m_trnTRANS_UPDATE;
        fleF010_NEW.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;
        fleU086A_AUDIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U086A_PATIENT_CLAIMS_UPDATE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:48 PM

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
            fleF086A_ORIG_NEW_PAT_IDS.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF010_ORIG.Dispose();
            fleF010_NEW.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();
            fleU086A_AUDIT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U086A_PATIENT_CLAIMS_UPDATE_1)"


    public void Run()
    {

        try
        {
            Request("PATIENT_CLAIMS_UPDATE_1");

            while (fleF086A_ORIG_NEW_PAT_IDS.QTPForMissing())
            {
                // --> GET F086A_ORIG_NEW_PAT_IDS <--

                fleF086A_ORIG_NEW_PAT_IDS.GetData();
                // --> End GET F086A_ORIG_NEW_PAT_IDS <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_P_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("P"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_P_CLM_DATA")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.Substring(fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART"), 2, 17))));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleF010_ORIG.QTPForMissing("2"))
                    {
                        // --> GET F010_ORIG <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_ORIG.ElementOwner("PAT_I_KEY")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(0, 1)));
                        
                        m_strWhere.Append(" AND ").Append(" ").Append(fleF010_ORIG.ElementOwner("PAT_CON_NBR")).Append(" = ");
                        m_strWhere.Append(QDesign.NConvert((fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(1, 2)));
                        
                        m_strWhere.Append(" AND ").Append(" ").Append(fleF010_ORIG.ElementOwner("PAT_I_NBR")).Append(" = ");
                        m_strWhere.Append(QDesign.NConvert((fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(3, 12)));
                        
                        m_strWhere.Append(" AND ").Append(" ").Append(fleF010_ORIG.ElementOwner("FILLER4")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(15, 1)));
                        

                        fleF010_ORIG.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_ORIG <--

                        while (fleF010_NEW.QTPForMissing("3"))
                        {
                            // --> GET F010_NEW <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF010_NEW.ElementOwner("PAT_I_KEY")).Append(" = ");
                            m_strWhere.Append(Common.StringToField((fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(0, 1)));
                            
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_NEW.ElementOwner("PAT_CON_NBR")).Append(" = ");
                            m_strWhere.Append(QDesign.NConvert((fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(1, 2)));
                            
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_NEW.ElementOwner("PAT_I_NBR")).Append(" = ");
                            m_strWhere.Append(QDesign.NConvert((fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(3, 12)));
                            
                            m_strWhere.Append(" AND ").Append(" ").Append(fleF010_NEW.ElementOwner("FILLER4")).Append(" = ");
                            m_strWhere.Append(Common.StringToField((fleF086A_ORIG_NEW_PAT_IDS.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")).PadRight(16).Substring(15, 1)));
                            

                            fleF010_NEW.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F010_NEW <--

                            while (fleF001_BATCH_CONTROL_FILE.QTPForMissing("4"))
                            {
                                // --> GET F001_BATCH_CONTROL_FILE <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR")));

                                fleF001_BATCH_CONTROL_FILE.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F001_BATCH_CONTROL_FILE <--


                                if (Transaction())
                                {

                                    fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update);




                                    SubFile(ref m_trnTRANS_UPDATE, ref fleU086A_AUDIT, SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMHDR_PAT_KEY_TYPE", "CLMHDR_PAT_KEY_DATA", "CLMHDR_PAT_ACRONYM6", "CLMHDR_PAT_ACRONYM3", fleF010_ORIG, "PAT_SURNAME_FIRST3", "PAT_SURNAME_LAST22", "PAT_GIVEN_NAME_FIRST1", "FILLER3", fleF002_CLAIMS_MSTR,
                                    "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", "KEY_P_CLM_TYPE", "KEY_P_CLM_DATA", fleF086A_ORIG_NEW_PAT_IDS, "ORIG_CLMHDR_PAT_OHIP_ID_OR_CHART", "ORIG_PAT_OLD_SURNAME", "ORIG_PAT_OLD_GIVEN_NAME", "PAT_OLD_SURNAME", "PAT_OLD_GIVEN_NAME");



                                }

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
            EndRequest("PATIENT_CLAIMS_UPDATE_1");

        }

    }




    #endregion


}
//PATIENT_CLAIMS_UPDATE_1




