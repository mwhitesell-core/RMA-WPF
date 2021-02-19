
#region "Screen Comments"

// #> PROGRAM-ID.     u010daily.qts  
// ((C)) Dyad Technologies
// PROGRAM PURPOSE :update doc revenue/cash mstr from balanced batches
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 2001/Oct/11 M.C.         - ORIGINAL (convert from u010daily.cbl)
// `C`ash type `P`ayments, update cash only
// `M`isc type `P`ayments, update cash and revenue
// and all others update revenue only
// 2001/Oct/18 M.C.      -Brad requested to link to f923 for clinic nbr
// translation before update to f050 & f051 files
// 2001/nov/06 B.E.      -added copybook to allow definition of batch
// control batch status without hardcoding values
// 2001/nov/08 B.E. - changed program`s access of f923 to reflect the
// change in that file to use clmhdr-payroll field
// rather than agent-cd
// 2002/jan/14 B.E. - added subfile u010daily_payroll_feed which feeds
// calculations for ICU payrolli. Values are tranferred
// daily into the default compensation file so that
// at any time Users can determined what values 
// payroll would be based upon.
// 2002/jan/14 M.C. - include clmdtl-nbr-serv in u010daily_payroll_feed subfile   
// - also include clmhdr-pat-ohip-id-or-chart in extf001f002
// subfile
// 2003/dec/10 b.e. - alpha doctor number
// 2004/jul/12 b.e. - replaced clmhdr-payroll with hardcoded  A  when ICU
// payroll (payroll  B ) was dropped
// 2007/may/09 M.C. - write records to f050tp and f051tp for clinic 70`s like clinic 60`s
// 2009/sep/29 M.C.  - correct the criteria for clinic 60 and clinic 70 when updating to
// f050tp or f051tp files
// 2009/sep/30 M.C. - comment  out the subfile u010daily_payroll_feed since we don`t run ICU any more
// 2010/feb/10 MC1 - include clinic 66
// 2014/Apr/08 MC2       - add new request to create new `C`laim to f002-outstanding and delete records from
// f002-outstanding if the claim balance is zero from adjustment or payment
// 2016/Jul/20 MC3  - change amount field size
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U010DAILY : BaseClassControl
{

    private U010DAILY m_U010DAILY;

    public U010DAILY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U010DAILY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U010DAILY != null))
        {
            m_U010DAILY.CloseTransactionObjects();
            m_U010DAILY = null;
        }
    }

    public U010DAILY GetU010DAILY(int Level)
    {
        if (m_U010DAILY == null)
        {
            m_U010DAILY = new U010DAILY("U010DAILY", Level);
        }
        else
        {
            m_U010DAILY.ResetValues();
        }
        return m_U010DAILY;
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

            U010DAILY_SELECT_BALANCED_BATCHES_1 SELECT_BALANCED_BATCHES_1 = new U010DAILY_SELECT_BALANCED_BATCHES_1(Name, Level);
            SELECT_BALANCED_BATCHES_1.Run();
            SELECT_BALANCED_BATCHES_1.Dispose();
            SELECT_BALANCED_BATCHES_1 = null;

            U010DAILY_EXTRACT_F002_HDR_2 EXTRACT_F002_HDR_2 = new U010DAILY_EXTRACT_F002_HDR_2(Name, Level);
            EXTRACT_F002_HDR_2.Run();
            EXTRACT_F002_HDR_2.Dispose();
            EXTRACT_F002_HDR_2 = null;

            U010DAILY_EXTF002DTL_3 EXTF002DTL_3 = new U010DAILY_EXTF002DTL_3(Name, Level);
            EXTF002DTL_3.Run();
            EXTF002DTL_3.Dispose();
            EXTF002DTL_3 = null;

            U010DAILY_UPDATE_REV_CASH_4 UPDATE_REV_CASH_4 = new U010DAILY_UPDATE_REV_CASH_4(Name, Level);
            UPDATE_REV_CASH_4.Run();
            UPDATE_REV_CASH_4.Dispose();
            UPDATE_REV_CASH_4 = null;

            U010DAILY_ADD_TO_F002_OUTSTANDING_5 ADD_TO_F002_OUTSTANDING_5 = new U010DAILY_ADD_TO_F002_OUTSTANDING_5(Name, Level);
            ADD_TO_F002_OUTSTANDING_5.Run();
            ADD_TO_F002_OUTSTANDING_5.Dispose();
            ADD_TO_F002_OUTSTANDING_5 = null;

            U010DAILY_DELETE_FROM_F002_OUTSTANDING_6 DELETE_FROM_F002_OUTSTANDING_6 = new U010DAILY_DELETE_FROM_F002_OUTSTANDING_6(Name, Level);
            DELETE_FROM_F002_OUTSTANDING_6.Run();
            DELETE_FROM_F002_OUTSTANDING_6.Dispose();
            DELETE_FROM_F002_OUTSTANDING_6 = null;

            U010DAILY_DELETE_AA_FROM_F002_OUTSTANDING_7 DELETE_AA_FROM_F002_OUTSTANDING_7 = new U010DAILY_DELETE_AA_FROM_F002_OUTSTANDING_7(Name, Level);
            DELETE_AA_FROM_F002_OUTSTANDING_7.Run();
            DELETE_AA_FROM_F002_OUTSTANDING_7.Dispose();
            DELETE_AA_FROM_F002_OUTSTANDING_7 = null;

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



public class U010DAILY_SELECT_BALANCED_BATCHES_1 : U010DAILY
{

    public U010DAILY_SELECT_BALANCED_BATCHES_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleEXTF001NON_AA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001NON_AA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleEXTF001AA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001AA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleEXTF001 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;
        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;

        fleF001_BATCH_CONTROL_FILE.SelectIf += fleF001_BATCH_CONTROL_FILE_SelectIf;
    }


    #region "Declarations (Variables, Files and Transactions)(U010DAILY_SELECT_BALANCED_BATCHES_1)"

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_STATUS")).Append(" =  ").Append(Common.StringToField(BATCTRL_BATCH_STATUS_BALANCED.Value)).Append(" )");


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

  
    private void fleF001_BATCH_CONTROL_FILE_SetItemFinals()
    {

        try
        {
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_STATUS", BATCTRL_BATCH_STATUS_REV_UPDATED.Value);


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









    private SqlFileObject fleEXTF001NON_AA;









    private SqlFileObject fleEXTF001AA;









    private SqlFileObject fleEXTF001;


    #endregion


    #region "Standard Generated Procedures(U010DAILY_SELECT_BALANCED_BATCHES_1)"


    #region "Automatic Item Initialization(U010DAILY_SELECT_BALANCED_BATCHES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U010DAILY_SELECT_BALANCED_BATCHES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:56 PM

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
        fleEXTF001NON_AA.Transaction = m_trnTRANS_UPDATE;
        fleEXTF001AA.Transaction = m_trnTRANS_UPDATE;
        fleEXTF001.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U010DAILY_SELECT_BALANCED_BATCHES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:56 PM

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
            fleEXTF001NON_AA.Dispose();
            fleEXTF001AA.Dispose();
            fleEXTF001.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U010DAILY_SELECT_BALANCED_BATCHES_1)"


    public void Run()
    {

        try
        {
            Request("SELECT_BALANCED_BATCHES_1");

            while (fleF001_BATCH_CONTROL_FILE.QTPForMissing())
            {
                // --> GET F001_BATCH_CONTROL_FILE <--

                fleF001_BATCH_CONTROL_FILE.GetData();
                // --> End GET F001_BATCH_CONTROL_FILE <--


                if (Transaction())
                {

                    Sort(fleF001_BATCH_CONTROL_FILE.GetSortValue("BATCTRL_BATCH_NBR"));



                }

            }


            while (Sort(fleF001_BATCH_CONTROL_FILE))
            {


                SubFile(ref m_trnTRANS_UPDATE, ref fleEXTF001NON_AA, QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) != "A"
                    | QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD")) != "A", SubFileType.Keep,
                    fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR", "BATCTRL_AGENT_CD", "BATCTRL_ADJ_CD", "BATCTRL_CYCLE_NBR",
                "BATCTRL_DATE_PERIOD_END", "BATCTRL_BATCH_TYPE", "BATCTRL_MANUAL_PAY_TOT", "BATCTRL_CALC_AR_DUE", "BATCTRL_CALC_TOT_REV");


                SubFile(ref m_trnTRANS_UPDATE, ref fleEXTF001AA, QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_TYPE")) == "A"
                    & QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_ADJ_CD")) == "A", SubFileType.Keep,
                    fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR", "BATCTRL_AGENT_CD", "BATCTRL_CALC_AR_DUE");

                fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Update);

                SubFile(ref m_trnTRANS_UPDATE, ref fleEXTF001, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_BATCH_NBR"), SubFileType.Keep, fleF001_BATCH_CONTROL_FILE, "BATCTRL_BATCH_NBR");
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
            EndRequest("SELECT_BALANCED_BATCHES_1");

        }

    }




    #endregion


}
//SELECT_BALANCED_BATCHES_1



public class U010DAILY_EXTRACT_F002_HDR_2 : U010DAILY
{

    public U010DAILY_EXTRACT_F002_HDR_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEXTF001NON_AA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001NON_AA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleEXTF001F002 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001F002", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        CLMHDR_CLINIC_NBR.GetValue += CLMHDR_CLINIC_NBR_GetValue;
        CLMHDR_DOC_NBR.GetValue += CLMHDR_DOC_NBR_GetValue;
        CLMHDR_PAYROLL.GetValue += CLMHDR_PAYROLL_GetValue;
        CLMHDR_PAT_OHIP_ID_OR_CHART.GetValue += CLMHDR_PAT_OHIP_ID_OR_CHART_GetValue;
    }


    #region "Declarations (Variables, Files and Transactions)(U010DAILY_EXTRACT_F002_HDR_2)"

    private SqlFileObject fleEXTF001NON_AA;
    private SqlFileObject fleF002_CLAIMS_MSTR_HDR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetStringValue("KEY_CLM_SERV_CODE")) == "00000" 
                & QDesign.NULL(fleEXTF001NON_AA.GetStringValue("BATCTRL_DATE_PERIOD_END")) == QDesign.NULL(QDesign.ASCII(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_DATE_PERIOD_END"), 8)) 
                & QDesign.NULL(fleEXTF001NON_AA.GetStringValue("BATCTRL_BATCH_NBR")) == QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ORIG_BATCH_NBR")))
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

    private DCharacter CLMHDR_CLINIC_NBR = new DCharacter("CLMHDR_CLINIC_NBR", 2);
    private void CLMHDR_CLINIC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 8) + QDesign.ASCII(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 2);
            //Parent:CLMHDR_CLAIM_ID


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



    // GW2018. JUL 29. Added. Would prefer column to be renamed
    private DCharacter CLMHDR_PAYROLL = new DCharacter("CLMHDR_PAYROLL", 1);
    private void CLMHDR_PAYROLL_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_HOSP");
            //Parent:CLMHDR_CLAIM_ID


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

    // GW2018. JUL 29. Added. Would prefer column to be renamed
    private DCharacter CLMHDR_PAT_OHIP_ID_OR_CHART = new DCharacter("CLMHDR_PAT_OHIP_ID_OR_CHART", 16);
    private void CLMHDR_PAT_OHIP_ID_OR_CHART_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA");
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

    private DCharacter CLMHDR_DOC_NBR = new DCharacter("CLMHDR_DOC_NBR", 3);
    private void CLMHDR_DOC_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 8) + QDesign.ASCII(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 3, 3);
            //Parent:CLMHDR_CLAIM_ID


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









    private SqlFileObject fleEXTF001F002;


    #endregion


    #region "Standard Generated Procedures(U010DAILY_EXTRACT_F002_HDR_2)"


    #region "Automatic Item Initialization(U010DAILY_EXTRACT_F002_HDR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U010DAILY_EXTRACT_F002_HDR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:56 PM

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
        fleEXTF001NON_AA.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        fleEXTF001F002.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U010DAILY_EXTRACT_F002_HDR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:56 PM

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
            fleEXTF001NON_AA.Dispose();
            fleF002_CLAIMS_MSTR_HDR.Dispose();
            fleEXTF001F002.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U010DAILY_EXTRACT_F002_HDR_2)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_F002_HDR_2");

            while (fleEXTF001NON_AA.QTPForMissing())
            {
                // --> GET EXTF001NON_AA <--

                fleEXTF001NON_AA.GetData();
                // --> End GET EXTF001NON_AA <--

                while (fleF002_CLAIMS_MSTR_HDR.QTPForMissing("1"))
                {

                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001NON_AA.GetStringValue("BATCTRL_BATCH_NBR")));

                    fleF002_CLAIMS_MSTR_HDR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {

                        if (Select_If())
                        {




                            SubFile(ref m_trnTRANS_UPDATE, ref fleEXTF001F002, SubFileType.Keep, fleEXTF001NON_AA, fleF002_CLAIMS_MSTR_HDR, "CLMHDR_DOC_DEPT", "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", "CLMHDR_AMT_TECH_PAID", "CLMHDR_I_O_PAT_IND", "CLMHDR_AGENT_CD",
                            "CLMHDR_ADJ_CD", "CLMHDR_ADJ_CD_SUB_TYPE", "CLMHDR_LOC", "CLMHDR_ORIG_BATCH_NBR", "CLMHDR_ORIG_CLAIM_NBR", CLMHDR_CLINIC_NBR, CLMHDR_DOC_NBR, "KEY_CLM_CLAIM_NBR", CLMHDR_PAYROLL, CLMHDR_PAT_OHIP_ID_OR_CHART);



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
            EndRequest("EXTRACT_F002_HDR_2");

        }

    }




    #endregion


}
//EXTRACT_F002_HDR_2



public class U010DAILY_EXTF002DTL_3 : U010DAILY
{

    public U010DAILY_EXTF002DTL_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEXTF001F002 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001F002", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleEXTF001F002DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001F002DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_SV_NBR2.GetValue += X_SV_NBR2_GetValue;
        X_SV_NBR3.GetValue += X_SV_NBR3_GetValue;
        X_SV_NBR4.GetValue += X_SV_NBR4_GetValue;
        X_NBR_SERV.GetValue += X_NBR_SERV_GetValue;

        CLMDTL_SV_DATE.GetValue += CLMDTL_SV_DATE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U010DAILY_EXTF002DTL_3)"


    private SqlFileObject fleEXTF001F002;
    private SqlFileObject fleF002_CLAIMS_MSTR_DTL;

    // GW2018. Jul 31. Added for parent
    private DCharacter CLMDTL_SV_DATE = new DCharacter("CLMDTL_SV_DATE", 8);
    private void CLMDTL_SV_DATE_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_SV_YY").ToString().PadLeft(4, '0') +
                fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_SV_MM").ToString().PadLeft(2, '0') +
                fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_SV_DD").ToString().PadLeft(2, '0');

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
            if (QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) != "0000" & QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) != "ZZZZ"
                & QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_ORIG_BATCH_NBR")) == QDesign.NULL(fleEXTF001F002.GetStringValue("CLMHDR_ORIG_BATCH_NBR"))
                & QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_ORIG_CLAIM_NBR_IN_BATCH")) == QDesign.NULL(fleEXTF001F002.GetDecimalValue("CLMHDR_ORIG_CLAIM_NBR")))
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

    private DDecimal X_SV_NBR2 = new DDecimal("X_SV_NBR2", 2);
    private void X_SV_NBR2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;



            if (QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "OP"
                & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "MR"
                & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "BI")
            {

                try
                {
                    if (QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 1) == " ")
                    {
                        CurrentValue = 0;
                    }
                    else
                    {
                        CurrentValue = Convert.ToDecimal(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 1));
                    }
                }
                catch
                {
                    CurrentValue = 0;
                }
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
    private DDecimal X_SV_NBR3 = new DDecimal("X_SV_NBR3", 2);
    private void X_SV_NBR3_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;


            if (QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "OP"
                & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "MR"
                & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "BI")
            {

                try
                {
                    if (QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 4, 1) == " ")
                    {
                        CurrentValue = 0;
                    }
                    else
                    {
                        CurrentValue = Convert.ToDecimal(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 4, 1));
                    }
                }
                catch
                {
                    CurrentValue = 0;
                }
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
    private DDecimal X_SV_NBR4 = new DDecimal("X_SV_NBR4", 2);
    private void X_SV_NBR4_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;

            if (QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "OP"
                & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "MR"
                & QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2)) != "BI")
            {

                try
                {
                    if (QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 8, 1) == " ")
                    {
                        CurrentValue = 0;
                    }
                    else
                    {
                        CurrentValue = Convert.ToDecimal(QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_CONSEC_DATES_R"), 8, 1));
                    }
                }
                catch
                {
                    CurrentValue = 0;
                }
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
    private DDecimal X_NBR_SERV = new DDecimal("X_NBR_SERV", 2);
    private void X_NBR_SERV_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_NBR_SERV") + X_SV_NBR2.Value + X_SV_NBR3.Value + X_SV_NBR4.Value;


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

    private SqlFileObject fleEXTF001F002DTL;


    #endregion


    #region "Standard Generated Procedures(U010DAILY_EXTF002DTL_3)"


    #region "Automatic Item Initialization(U010DAILY_EXTF002DTL_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U010DAILY_EXTF002DTL_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:56 PM

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
        fleEXTF001F002.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_DTL.Transaction = m_trnTRANS_UPDATE;
        fleEXTF001F002DTL.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U010DAILY_EXTF002DTL_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:56 PM

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
            fleEXTF001F002.Dispose();
            fleF002_CLAIMS_MSTR_DTL.Dispose();
            fleEXTF001F002DTL.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U010DAILY_EXTF002DTL_3)"


    public void Run()
    {

        try
        {
            Request("EXTF002DTL_3");

            while (fleEXTF001F002.QTPForMissing())
            {
                // --> GET EXTF001F002 <--

                fleEXTF001F002.GetData();

                // --> End GET EXTF001F002 <--

                while (fleF002_CLAIMS_MSTR_DTL.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR_DTL <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002.GetStringValue("BATCTRL_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleEXTF001F002.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR_DTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {

                        if (Select_If())
                        {
                            SubFile(ref m_trnTRANS_UPDATE, ref fleEXTF001F002DTL, SubFileType.Keep, fleF002_CLAIMS_MSTR_DTL, "CLMDTL_NBR_SERV", "CLMDTL_FEE_OHIP", "CLMDTL_AMT_TECH_BILLED", "CLMDTL_OMA_CD",
                            "CLMDTL_OMA_SUFF", "CLMDTL_LINE_NO", CLMDTL_SV_DATE, "CLMDTL_CONSEC_DATES_R", X_NBR_SERV, fleEXTF001F002);

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
            EndRequest("EXTF002DTL_3");

        }

    }




    #endregion


}
//EXTF002DTL_3



public class U010DAILY_UPDATE_REV_CASH_4 : U010DAILY
{

    public U010DAILY_UPDATE_REV_CASH_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEXTF001F002DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001F002DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF923_DOC_REVENUE_TRANSLATION = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F923_DOC_REVENUE_TRANSLATION", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_REV_UPD = new CoreDecimal("X_REV_UPD", 9, this);
        X_CASH_UPD = new CoreDecimal("X_CASH_UPD", 9, this);
        X_REV_REC = new CoreDecimal("X_REV_REC", 6, this);
        X_CASH_REC = new CoreDecimal("X_CASH_REC", 6, this);
        fleF050_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF050TP_DOC_REVENUE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F050TP_DOC_REVENUE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF051_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF051TP_DOC_CASH_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F051TP_DOC_CASH_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleR010DAILY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "R010DAILY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF923_TRANSLATION_AUDIT = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "F923_TRANSLATION_AUDIT", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_SUFF.GetValue += X_SUFF_GetValue;
        X_I_O_IND.GetValue += X_I_O_IND_GetValue;
        X_PROF_FEE.GetValue += X_PROF_FEE_GetValue;
        X_NBR_SVC.GetValue += X_NBR_SVC_GetValue;
        X_PAYMENTS.GetValue += X_PAYMENTS_GetValue;
        X_TECH_PAID.GetValue += X_TECH_PAID_GetValue;
        X_PROF_PAID.GetValue += X_PROF_PAID_GetValue;
        X_TRANSLATED_CLINIC.GetValue += X_TRANSLATED_CLINIC_GetValue;
        X_NBR_PROCESSED.GetValue += X_NBR_PROCESSED_GetValue;
        fleF050_DOC_REVENUE_MSTR.InitializeItems += fleF050_DOC_REVENUE_MSTR_InitializeItems;
        fleF050TP_DOC_REVENUE_MSTR.InitializeItems += fleF050TP_DOC_REVENUE_MSTR_InitializeItems;
        fleF051_DOC_CASH_MSTR.InitializeItems += fleF051_DOC_CASH_MSTR_InitializeItems;
        fleF051TP_DOC_CASH_MSTR.InitializeItems += fleF051TP_DOC_CASH_MSTR_InitializeItems;

    }


    #region "Declarations (Variables, Files and Transactions)(U010DAILY_UPDATE_REV_CASH_4)"

    private SqlFileObject fleEXTF001F002DTL;
    private SqlFileObject fleF923_DOC_REVENUE_TRANSLATION;
    private DCharacter X_SUFF = new DCharacter("X_SUFF", 1);
    private void X_SUFF_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (string.Compare(fleEXTF001F002DTL.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE"), "9") <= 0 & QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_ADJ_CD")) == "M")
            {
                CurrentValue = fleEXTF001F002DTL.GetStringValue("CLMHDR_ADJ_CD_SUB_TYPE");
            }
            else if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_ADJ_CD")) == "M")
            {
                CurrentValue = "0";
            }
            else
            {
                CurrentValue = fleEXTF001F002DTL.GetStringValue("CLMDTL_OMA_SUFF");
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
    private DCharacter X_I_O_IND = new DCharacter("X_I_O_IND", 1);
    private void X_I_O_IND_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("CLMHDR_I_O_PAT_IND")) != "I" & QDesign.NULL(fleEXTF001F002DTL.GetStringValue("CLMHDR_I_O_PAT_IND")) != "O")
            {
                CurrentValue = "I";
            }
            else
            {
                CurrentValue = fleEXTF001F002DTL.GetStringValue("CLMHDR_I_O_PAT_IND");
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
    private DDecimal X_PROF_FEE = new DDecimal("X_PROF_FEE", 8);
    private void X_PROF_FEE_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleEXTF001F002DTL.GetDecimalValue("CLMDTL_FEE_OHIP") - fleEXTF001F002DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED");


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
    private DDecimal X_NBR_SVC = new DDecimal("X_NBR_SVC", 4);
    private void X_NBR_SVC_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A")
            {
                CurrentValue = 0;
            }
            else
            {
                CurrentValue = fleEXTF001F002DTL.GetDecimalValue("X_NBR_SERV");
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
    private DDecimal X_PAYMENTS = new DDecimal("X_PAYMENTS", 8);
    private void X_PAYMENTS_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P" & QDesign.NULL(fleEXTF001F002DTL.GetStringValue("CLMHDR_ADJ_CD")) == "C")
            {
                CurrentValue = 0 - fleEXTF001F002DTL.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
            }
            else if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P")
            {
                CurrentValue = fleEXTF001F002DTL.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");
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
    private DDecimal X_TECH_PAID = new DDecimal("X_TECH_PAID", 8);
    private void X_TECH_PAID_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P" & QDesign.NULL(fleEXTF001F002DTL.GetStringValue("CLMHDR_ADJ_CD")) == "C")
            {
                CurrentValue = 0 - fleEXTF001F002DTL.GetDecimalValue("CLMHDR_AMT_TECH_PAID");
            }
            else if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P")
            {
                CurrentValue = fleEXTF001F002DTL.GetDecimalValue("CLMHDR_AMT_TECH_PAID");
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
    private DDecimal X_PROF_PAID = new DDecimal("X_PROF_PAID", 8);
    private void X_PROF_PAID_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P")
            {
                CurrentValue = X_PAYMENTS.Value - X_TECH_PAID.Value;
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
    private DCharacter X_TRANSLATED_CLINIC = new DCharacter("X_TRANSLATED_CLINIC", 2);
    private void X_TRANSLATED_CLINIC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (fleF923_DOC_REVENUE_TRANSLATION.Exists())
            {
                CurrentValue = QDesign.ASCII(fleF923_DOC_REVENUE_TRANSLATION.GetDecimalValue("CLINIC_NBR_TRANSLATED"), 2);
            }
            else
            {
                CurrentValue = fleEXTF001F002DTL.GetStringValue("CLMHDR_CLINIC_NBR");
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
    private CoreDecimal X_REV_UPD;
    private CoreDecimal X_CASH_UPD;
    private CoreDecimal X_REV_REC;
    private CoreDecimal X_CASH_REC;
    private DDecimal X_NBR_PROCESSED = new DDecimal("X_NBR_PROCESSED", 6);
    private void X_NBR_PROCESSED_GetValue(ref decimal Value)
    {

        try
        {
            Value = X_REV_REC.Value + X_CASH_REC.Value;


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
    private SqlFileObject fleF050_DOC_REVENUE_MSTR;

    private void fleF050_DOC_REVENUE_MSTR_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_CLINIC_1_2", true, X_TRANSLATED_CLINIC.Value);
            if (!Fixed)
                fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_DEPT", true, fleEXTF001F002DTL.GetDecimalValue("CLMHDR_DOC_DEPT"));
            if (!Fixed)
                fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_DOC_NBR", true, fleEXTF001F002DTL.GetStringValue("CLMHDR_DOC_NBR"));
            if (!Fixed)
                fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_LOCATION", true, fleEXTF001F002DTL.GetStringValue("CLMHDR_LOC"));
            if (!Fixed)
                fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_OMA_CODE", true, fleEXTF001F002DTL.GetStringValue("CLMDTL_OMA_CD"));
            if (!Fixed)
                fleF050_DOC_REVENUE_MSTR.set_SetValue("DOCREV_OMA_SUFF", true, X_SUFF.Value);


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

    private SqlFileObject fleF050TP_DOC_REVENUE_MSTR;

    private void fleF050TP_DOC_REVENUE_MSTR_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_CLINIC_NBR", true, QDesign.NConvert(X_TRANSLATED_CLINIC.Value));
            if (!Fixed)
                fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_AGENT_CD", true, QDesign.ASCII(fleEXTF001F002DTL.GetDecimalValue("CLMHDR_AGENT_CD"), 1));
            if (!Fixed)
                fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_LOC_CD", true, fleEXTF001F002DTL.GetStringValue("CLMHDR_LOC"));
            if (!Fixed)
                fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OMA_CODE", true, fleEXTF001F002DTL.GetStringValue("CLMDTL_OMA_CD"));
            if (!Fixed)
                fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_OMA_SUFFIX", true, X_SUFF.Value);
            if (!Fixed)
                fleF050TP_DOC_REVENUE_MSTR.set_SetValue("DOCREVTP_DOC_NBR", true, fleEXTF001F002DTL.GetStringValue("CLMHDR_DOC_NBR"));


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

    private SqlFileObject fleF051_DOC_CASH_MSTR;

    private void fleF051_DOC_CASH_MSTR_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF051_DOC_CASH_MSTR.set_SetValue("DOCASH_CLINIC_1_2", true, X_TRANSLATED_CLINIC.Value);
            if (!Fixed)
                fleF051_DOC_CASH_MSTR.set_SetValue("DOCASH_DEPT", true, fleEXTF001F002DTL.GetDecimalValue("CLMHDR_DOC_DEPT"));
            if (!Fixed)
                fleF051_DOC_CASH_MSTR.set_SetValue("DOCASH_DOC_NBR", true, fleEXTF001F002DTL.GetStringValue("CLMHDR_DOC_NBR"));
            if (!Fixed)
                fleF051_DOC_CASH_MSTR.set_SetValue("DOCASH_LOCATION", true, fleEXTF001F002DTL.GetStringValue("CLMHDR_LOC"));
            if (!Fixed)
                fleF051_DOC_CASH_MSTR.set_SetValue("DOCASH_AGENCY_TYPE", true, QDesign.ASCII(fleEXTF001F002DTL.GetDecimalValue("CLMHDR_AGENT_CD"), 1));


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

    private SqlFileObject fleF051TP_DOC_CASH_MSTR;

    private void fleF051TP_DOC_CASH_MSTR_InitializeItems(bool Fixed)
    {

        try
        {
            if (!Fixed)
                fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_CLINIC_NBR", true, QDesign.NConvert(X_TRANSLATED_CLINIC.Value));
            if (!Fixed)
                fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_AGENT_CD", true, QDesign.ASCII(fleEXTF001F002DTL.GetDecimalValue("CLMHDR_AGENT_CD"), 1));
            if (!Fixed)
                fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_LOC_CD", true, fleEXTF001F002DTL.GetStringValue("CLMHDR_LOC"));
            if (!Fixed)
                fleF051TP_DOC_CASH_MSTR.set_SetValue("DOCASHTP_DOC_NBR", true, fleEXTF001F002DTL.GetStringValue("CLMHDR_DOC_NBR"));


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










    private SqlFileObject fleR010DAILY;









    private SqlFileObject fleF923_TRANSLATION_AUDIT;


    #endregion


    #region "Standard Generated Procedures(U010DAILY_UPDATE_REV_CASH_4)"


    #region "Automatic Item Initialization(U010DAILY_UPDATE_REV_CASH_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U010DAILY_UPDATE_REV_CASH_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:56 PM

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
        fleEXTF001F002DTL.Transaction = m_trnTRANS_UPDATE;
        fleF923_DOC_REVENUE_TRANSLATION.Transaction = m_trnTRANS_UPDATE;
        fleF050_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF050TP_DOC_REVENUE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF051_DOC_CASH_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF051TP_DOC_CASH_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleR010DAILY.Transaction = m_trnTRANS_UPDATE;
        fleF923_TRANSLATION_AUDIT.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U010DAILY_UPDATE_REV_CASH_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:56 PM

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
            fleEXTF001F002DTL.Dispose();
            fleF923_DOC_REVENUE_TRANSLATION.Dispose();
            fleF050_DOC_REVENUE_MSTR.Dispose();
            fleF050TP_DOC_REVENUE_MSTR.Dispose();
            fleF051_DOC_CASH_MSTR.Dispose();
            fleF051TP_DOC_CASH_MSTR.Dispose();
            fleR010DAILY.Dispose();
            fleF923_TRANSLATION_AUDIT.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U010DAILY_UPDATE_REV_CASH_4)"


    public void Run()
    {

        try
        {
            Request("UPDATE_REV_CASH_4");

            while (fleEXTF001F002DTL.QTPForMissing())
            {
                // --> GET EXTF001F002DTL <--

                fleEXTF001F002DTL.GetData();
                // --> End GET EXTF001F002DTL <--

                while (fleF923_DOC_REVENUE_TRANSLATION.QTPForMissing("1"))
                {
                    // --> GET F923_DOC_REVENUE_TRANSLATION <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMHDR_DOC_NBR")));
                    m_strWhere.Append(" And ").Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(fleEXTF001F002DTL.GetStringValue("CLMHDR_CLINIC_NBR"))));
                    m_strWhere.Append(" And ").Append(fleF923_DOC_REVENUE_TRANSLATION.ElementOwner("CLMHDR_PAYROLL")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("A"));

                    fleF923_DOC_REVENUE_TRANSLATION.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F923_DOC_REVENUE_TRANSLATION <--


                    if (Transaction())
                    {

                        Sort(fleEXTF001F002DTL.GetSortValue("BATCTRL_BATCH_NBR"), fleEXTF001F002DTL.GetSortValue("KEY_CLM_CLAIM_NBR"));


                    }

                }

            }

            while (Sort(fleEXTF001F002DTL, fleF923_DOC_REVENUE_TRANSLATION))
            {
                if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) != "P" | QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_ADJ_CD")) != "C")
                {
                    X_REV_UPD.Value = X_REV_UPD.Value + fleEXTF001F002DTL.GetDecimalValue("CLMDTL_FEE_OHIP");
                }
                if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P")
                {
                    X_CASH_UPD.Value = X_CASH_UPD.Value + X_PAYMENTS.Value;
                }
                if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) != "P" | QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_ADJ_CD")) != "C")
                {
                    X_REV_REC.Value = X_REV_REC.Value + 1;
                }
                if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P")
                {
                    X_CASH_REC.Value = X_CASH_REC.Value + 1;
                }

                while (fleF050_DOC_REVENUE_MSTR.QTPForMissing())
                {
                    // --> GET F050_DOC_REVENUE_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_CLINIC_1_2")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(X_TRANSLATED_CLINIC.Value));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_DEPT")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.ASCII(fleEXTF001F002DTL.GetDecimalValue("CLMHDR_DOC_DEPT"), 2)));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMHDR_DOC_NBR")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMHDR_LOC")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_OMA_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMDTL_OMA_CD")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050_DOC_REVENUE_MSTR.ElementOwner("DOCREV_OMA_SUFF")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(X_SUFF.Value));

                    fleF050_DOC_REVENUE_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F050_DOC_REVENUE_MSTR <--


                    if (QDesign.NULL(X_I_O_IND.Value) == "I")
                    {
                        SubTotal(ref fleF050_DOC_REVENUE_MSTR, "DOCREV_MTD_IN_SVC", X_NBR_SVC.Value);

                    }

                    if (QDesign.NULL(X_I_O_IND.Value) == "I")
                    {
                        SubTotal(ref fleF050_DOC_REVENUE_MSTR, "DOCREV_MTD_IN_REC", fleEXTF001F002DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));

                    }

                    if (QDesign.NULL(X_I_O_IND.Value) == "I")
                    {
                        SubTotal(ref fleF050_DOC_REVENUE_MSTR, "DOCREV_YTD_IN_SVC", X_NBR_SVC.Value);

                    }

                    if (QDesign.NULL(X_I_O_IND.Value) == "I")
                    {
                        SubTotal(ref fleF050_DOC_REVENUE_MSTR, "DOCREV_YTD_IN_REC", fleEXTF001F002DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));

                    }

                    if (QDesign.NULL(X_I_O_IND.Value) == "O")
                    {
                        SubTotal(ref fleF050_DOC_REVENUE_MSTR, "DOCREV_MTD_OUT_SVC", X_NBR_SVC.Value);

                    }

                    if (QDesign.NULL(X_I_O_IND.Value) == "O")
                    {
                        SubTotal(ref fleF050_DOC_REVENUE_MSTR, "DOCREV_MTD_OUT_REC", fleEXTF001F002DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));

                    }

                    if (QDesign.NULL(X_I_O_IND.Value) == "O")
                    {
                        SubTotal(ref fleF050_DOC_REVENUE_MSTR, "DOCREV_YTD_OUT_SVC", X_NBR_SVC.Value);

                    }

                    if (QDesign.NULL(X_I_O_IND.Value) == "O")
                    {
                        SubTotal(ref fleF050_DOC_REVENUE_MSTR, "DOCREV_YTD_OUT_REC", fleEXTF001F002DTL.GetDecimalValue("CLMDTL_FEE_OHIP"));

                    }

                    fleF050_DOC_REVENUE_MSTR.OutPut(OutPutType.Add_Update, null, QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C" | QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" | (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P" & QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_ADJ_CD")) == "M"));



                }


                while (fleF050TP_DOC_REVENUE_MSTR.QTPForMissing())
                {
                    // --> GET F050TP_DOC_REVENUE_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(X_TRANSLATED_CLINIC.Value));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_AGENT_CD")).Append(" = ");
                    m_strWhere.Append(fleEXTF001F002DTL.GetDecimalValue("CLMHDR_AGENT_CD"));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_LOC_CD")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMHDR_LOC")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_OMA_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMDTL_OMA_CD")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_OMA_SUFFIX")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(X_SUFF.Value));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF050TP_DOC_REVENUE_MSTR.ElementOwner("DOCREVTP_DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMHDR_DOC_NBR")));

                    fleF050TP_DOC_REVENUE_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F050TP_DOC_REVENUE_MSTR <--


                    if (QDesign.NULL(fleEXTF001F002DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED")) != 0)
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_TECH_NBR_SVC1", X_NBR_SVC.Value);

                    }

                    if (QDesign.NULL(fleEXTF001F002DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED")) != 0)
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_TECH_NBR_SVC2", X_NBR_SVC.Value);

                    }

                    if (QDesign.NULL(X_PROF_FEE.Value) != 0)
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_PROF_NBR_SVC1", X_NBR_SVC.Value);

                    }

                    if (QDesign.NULL(X_PROF_FEE.Value) != 0)
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_PROF_NBR_SVC2", X_NBR_SVC.Value);

                    }

                    if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C" | QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P")
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_TECH_AMT_BILLED1", fleEXTF001F002DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));

                    }

                    if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C" | QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P")
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_TECH_AMT_BILLED2", fleEXTF001F002DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));

                    }

                    if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C" | QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P")
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_PROF_AMT_BILLED1", X_PROF_FEE.Value);

                    }

                    if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C" | QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P")
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_PROF_AMT_BILLED2", X_PROF_FEE.Value);

                    }

                    if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A")
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_TECH_AMT_ADJUSTS1", fleEXTF001F002DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));

                    }

                    if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A")
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_TECH_AMT_ADJUSTS2", fleEXTF001F002DTL.GetDecimalValue("CLMDTL_AMT_TECH_BILLED"));

                    }

                    if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A")
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_PROF_AMT_ADJUSTS1", X_PROF_FEE.Value);

                    }

                    if (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A")
                    {
                        SubTotal(ref fleF050TP_DOC_REVENUE_MSTR, "DOCREVTP_OUT_PROF_AMT_ADJUSTS2", X_PROF_FEE.Value);

                    }

                    if(!AccessOk && 
                        (
                        (
                        (string.Compare(X_TRANSLATED_CLINIC.Value, "61") >= 0 && string.Compare(X_TRANSLATED_CLINIC.Value, "66") <= 0) || 
                        (string.Compare(X_TRANSLATED_CLINIC.Value, "71") >= 0 && string.Compare(X_TRANSLATED_CLINIC.Value, "75") <= 0)
                        ) && 
                        (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C" || QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" || (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P" && QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_ADJ_CD")) == "M"))))
                    {

                    }

                    fleF050TP_DOC_REVENUE_MSTR.OutPut(OutPutType.Add_Update, null, ((string.Compare(X_TRANSLATED_CLINIC.Value, "61") >= 0 & string.Compare(X_TRANSLATED_CLINIC.Value, "66") <= 0) | (string.Compare(X_TRANSLATED_CLINIC.Value, "71") >= 0 & string.Compare(X_TRANSLATED_CLINIC.Value, "75") <= 0)) & (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "C" | QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" | (QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P" & QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_ADJ_CD")) == "M")));



                }


                while (fleF051_DOC_CASH_MSTR.QTPForMissing())
                {
                    // --> GET F051_DOC_CASH_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_CLINIC_1_2")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(X_TRANSLATED_CLINIC.Value));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_DEPT")).Append(" = ");
                    m_strWhere.Append(fleEXTF001F002DTL.GetDecimalValue("CLMHDR_DOC_DEPT"));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMHDR_DOC_NBR")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_LOCATION")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMHDR_LOC")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF051_DOC_CASH_MSTR.ElementOwner("DOCASH_AGENCY_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMHDR_AGENT_CD")));
                  
                    fleF051_DOC_CASH_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F051_DOC_CASH_MSTR <--



                    SubTotal(ref fleF051_DOC_CASH_MSTR, "DOCASH_MTD_IN_REC", X_PAYMENTS.Value);


                    SubTotal(ref fleF051_DOC_CASH_MSTR, "DOCASH_YTD_IN_REC", X_PAYMENTS.Value);


                    fleF051_DOC_CASH_MSTR.OutPut(OutPutType.Add_Update, fleEXTF001F002DTL.At("BATCTRL_BATCH_NBR") || fleEXTF001F002DTL.At("KEY_CLM_CLAIM_NBR"), QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P");



                }


                while (fleF051TP_DOC_CASH_MSTR.QTPForMissing())
                {
                    // --> GET F051TP_DOC_CASH_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF051TP_DOC_CASH_MSTR.ElementOwner("DOCASHTP_CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(X_TRANSLATED_CLINIC.Value));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF051TP_DOC_CASH_MSTR.ElementOwner("DOCASHTP_AGENT_CD")).Append(" = ");
                    m_strWhere.Append(fleEXTF001F002DTL.GetDecimalValue("CLMHDR_AGENT_CD"));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF051TP_DOC_CASH_MSTR.ElementOwner("DOCASHTP_LOC_CD")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMHDR_LOC")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF051TP_DOC_CASH_MSTR.ElementOwner("DOCASHTP_DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002DTL.GetStringValue("CLMHDR_DOC_NBR")));
              

                    fleF051TP_DOC_CASH_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F051TP_DOC_CASH_MSTR <--



                    SubTotal(ref fleF051TP_DOC_CASH_MSTR, "DOCASHTP_TECH_OUT_MTD", X_TECH_PAID.Value);


                    SubTotal(ref fleF051TP_DOC_CASH_MSTR, "DOCASHTP_TECH_OUT_YTD", X_TECH_PAID.Value);


                    SubTotal(ref fleF051TP_DOC_CASH_MSTR, "DOCASHTP_PROF_OUT_MTD", X_PROF_PAID.Value);


                    SubTotal(ref fleF051TP_DOC_CASH_MSTR, "DOCASHTP_PROF_OUT_YTD", X_PROF_PAID.Value);


                    fleF051TP_DOC_CASH_MSTR.OutPut(OutPutType.Add_Update, fleEXTF001F002DTL.At("BATCTRL_BATCH_NBR") || fleEXTF001F002DTL.At("KEY_CLM_CLAIM_NBR"), ((string.Compare(X_TRANSLATED_CLINIC.Value, "61") >= 0 & string.Compare(X_TRANSLATED_CLINIC.Value, "66") <= 0) | (string.Compare(X_TRANSLATED_CLINIC.Value, "71") >= 0 & string.Compare(X_TRANSLATED_CLINIC.Value, "75") <= 0)) & QDesign.NULL(fleEXTF001F002DTL.GetStringValue("BATCTRL_BATCH_TYPE")) == "P");



                }



                SubFile(ref m_trnTRANS_UPDATE, ref fleR010DAILY, fleEXTF001F002DTL.At("BATCTRL_BATCH_NBR"), SubFileType.Keep, fleEXTF001F002DTL, "BATCTRL_BATCH_NBR", "BATCTRL_AGENT_CD", "BATCTRL_ADJ_CD", "BATCTRL_CYCLE_NBR", "BATCTRL_DATE_PERIOD_END",
                "BATCTRL_BATCH_TYPE", "BATCTRL_MANUAL_PAY_TOT", "BATCTRL_CALC_AR_DUE", "BATCTRL_CALC_TOT_REV", "CLMHDR_DOC_DEPT", "CLMHDR_CLINIC_NBR", X_REV_UPD, X_CASH_UPD, X_NBR_PROCESSED);



                SubFile(ref m_trnTRANS_UPDATE, ref fleF923_TRANSLATION_AUDIT, fleF923_DOC_REVENUE_TRANSLATION.Exists(), SubFileType.Keep, fleEXTF001F002DTL, "BATCTRL_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_DOC_NBR", "CLMDTL_OMA_CD", "CLMDTL_LINE_NO",
                "CLMHDR_AGENT_CD", "CLMHDR_CLINIC_NBR", fleF923_DOC_REVENUE_TRANSLATION, "CLINIC_NBR_TRANSLATED");



                Reset(ref X_REV_UPD, fleEXTF001F002DTL.At("BATCTRL_BATCH_NBR"));
                Reset(ref X_CASH_UPD, fleEXTF001F002DTL.At("BATCTRL_BATCH_NBR"));
                Reset(ref X_REV_REC, fleEXTF001F002DTL.At("BATCTRL_BATCH_NBR"));
                Reset(ref X_CASH_REC, fleEXTF001F002DTL.At("BATCTRL_BATCH_NBR"));

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
            EndRequest("UPDATE_REV_CASH_4");

        }

    }




    #endregion


}
//UPDATE_REV_CASH_4



public class U010DAILY_ADD_TO_F002_OUTSTANDING_5 : U010DAILY
{

    public U010DAILY_ADD_TO_F002_OUTSTANDING_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEXTF001F002 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001F002", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_OUTSTANDING = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_OUTSTANDING", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleEXTF001F002_ADJ_PAY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001F002_ADJ_PAY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_OUTSTANDING.SetItemFinals += fleF002_OUTSTANDING_SetItemFinals;

    }


    #region "Declarations (Variables, Files and Transactions)(U010DAILY_ADD_TO_F002_OUTSTANDING_5)"

    private SqlFileObject fleEXTF001F002;
    private SqlFileObject fleF002_OUTSTANDING;

    private void fleF002_OUTSTANDING_SetItemFinals()
    {

        try
        {
            fleF002_OUTSTANDING.set_SetValue("KEY_CLM_TYPE", "B");
            fleF002_OUTSTANDING.set_SetValue("KEY_CLM_BATCH_NBR", fleEXTF001F002.GetStringValue("BATCTRL_BATCH_NBR"));
            fleF002_OUTSTANDING.set_SetValue("KEY_CLM_CLAIM_NBR", fleEXTF001F002.GetDecimalValue("KEY_CLM_CLAIM_NBR"));


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










    private SqlFileObject fleEXTF001F002_ADJ_PAY;


    #endregion


    #region "Standard Generated Procedures(U010DAILY_ADD_TO_F002_OUTSTANDING_5)"


    #region "Automatic Item Initialization(U010DAILY_ADD_TO_F002_OUTSTANDING_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U010DAILY_ADD_TO_F002_OUTSTANDING_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:56 PM

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
        fleEXTF001F002.Transaction = m_trnTRANS_UPDATE;
        fleF002_OUTSTANDING.Transaction = m_trnTRANS_UPDATE;
        fleEXTF001F002_ADJ_PAY.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U010DAILY_ADD_TO_F002_OUTSTANDING_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:56 PM

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
            fleEXTF001F002.Dispose();
            fleF002_OUTSTANDING.Dispose();
            fleEXTF001F002_ADJ_PAY.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U010DAILY_ADD_TO_F002_OUTSTANDING_5)"


    public void Run()
    {

        try
        {
            Request("ADD_TO_F002_OUTSTANDING_5");

            while (fleEXTF001F002.QTPForMissing())
            {
                // --> GET EXTF001F002 <--

                fleEXTF001F002.GetData();
                // --> End GET EXTF001F002 <--


                if (Transaction())
                {


                    fleF002_OUTSTANDING.OutPut(OutPutType.Add, null, QDesign.NULL(fleEXTF001F002.GetStringValue("BATCTRL_BATCH_TYPE")) == "C");


                    SubFile(ref m_trnTRANS_UPDATE, ref fleEXTF001F002_ADJ_PAY, (QDesign.NULL(fleEXTF001F002.GetStringValue("BATCTRL_BATCH_TYPE")) == "A" & QDesign.NULL(fleEXTF001F002.GetStringValue("CLMHDR_ADJ_CD")) == "B") | (QDesign.NULL(fleEXTF001F002.GetStringValue("BATCTRL_BATCH_TYPE")) == "P" & QDesign.NULL(fleEXTF001F002.GetStringValue("CLMHDR_ADJ_CD")) == "C"), SubFileType.Keep, fleEXTF001F002);


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
            EndRequest("ADD_TO_F002_OUTSTANDING_5");

        }

    }




    #endregion


}
//ADD_TO_F002_OUTSTANDING_5



public class U010DAILY_DELETE_FROM_F002_OUTSTANDING_6 : U010DAILY
{

    public U010DAILY_DELETE_FROM_F002_OUTSTANDING_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEXTF001F002_ADJ_PAY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001F002_ADJ_PAY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "F002_ADJ", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_OUTSTANDING = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_OUTSTANDING", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        BALANCE_DUE.GetValue += BALANCE_DUE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U010DAILY_DELETE_FROM_F002_OUTSTANDING_6)"

    private SqlFileObject fleEXTF001F002_ADJ_PAY;
    private SqlFileObject fleF002_CLAIMS_MSTR_HDR;
    private SqlFileObject fleF002_ADJ;
    private SqlFileObject fleF002_OUTSTANDING;
    private DDecimal BALANCE_DUE = new DDecimal("BALANCE_DUE", 7);
    private void BALANCE_DUE_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_ADJ.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_ADJ.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");


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


    #region "Standard Generated Procedures(U010DAILY_DELETE_FROM_F002_OUTSTANDING_6)"


    #region "Automatic Item Initialization(U010DAILY_DELETE_FROM_F002_OUTSTANDING_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U010DAILY_DELETE_FROM_F002_OUTSTANDING_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:57 PM

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
        fleEXTF001F002_ADJ_PAY.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleF002_OUTSTANDING.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U010DAILY_DELETE_FROM_F002_OUTSTANDING_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:57 PM

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
            fleEXTF001F002_ADJ_PAY.Dispose();
            fleF002_CLAIMS_MSTR_HDR.Dispose();
            fleF002_ADJ.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U010DAILY_DELETE_FROM_F002_OUTSTANDING_6)"


    public void Run()
    {

        try
        {
            Request("DELETE_FROM_F002_OUTSTANDING_6");

            while (fleEXTF001F002_ADJ_PAY.QTPForMissing())
            {
                // --> GET EXTF001F002_ADJ_PAY <--

                fleEXTF001F002_ADJ_PAY.GetData();
                // --> End GET EXTF001F002_ADJ_PAY <--

                while (fleF002_CLAIMS_MSTR_HDR.QTPForMissing("1"))
                {
                    // --> GET fleF002_CLAIMS_MSTR_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001F002_ADJ_PAY.GetStringValue("CLMHDR_ORIG_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleEXTF001F002_ADJ_PAY.GetDecimalValue("CLMHDR_ORIG_CLAIM_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));

                    fleF002_CLAIMS_MSTR_HDR.GetData(m_strWhere.ToString());
                    // --> End GET fleF002_CLAIMS_MSTR_HDR <--

                    while (fleF002_ADJ.QTPForMissing("2"))
                    {
                        // --> GET F002_ADJ <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_ADJ.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_ADJ.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_BATCH_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_ADJ.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_ADJ.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("00000"));

                        fleF002_ADJ.GetData(m_strWhere.ToString());
                        // --> End GET F002_ADJ <--

                        while (fleF002_OUTSTANDING.QTPForMissing("3"))
                        {
                            // --> GET F002_OUTSTANDING <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("B"));
                            m_strWhere.Append(" And ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF002_ADJ.GetStringValue("CLMHDR_BATCH_NBR")));
                            m_strWhere.Append(" And ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                            m_strWhere.Append((fleF002_ADJ.GetDecimalValue("CLMHDR_CLAIM_NBR")));

                            fleF002_OUTSTANDING.GetData(m_strWhere.ToString());
                            // --> End GET F002_OUTSTANDING <--


                            if (Transaction())
                            {


                                fleF002_OUTSTANDING.OutPut(OutPutType.Delete, null, BALANCE_DUE.Value == 0);

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
            EndRequest("DELETE_FROM_F002_OUTSTANDING_6");

        }

    }




    #endregion


}
//DELETE_FROM_F002_OUTSTANDING_6



public class U010DAILY_DELETE_AA_FROM_F002_OUTSTANDING_7 : U010DAILY
{

    public U010DAILY_DELETE_AA_FROM_F002_OUTSTANDING_7(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleEXTF001AA = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "EXTF001AA", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "F002_ADJ", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_OUTSTANDING = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_OUTSTANDING", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        BALANCE_DUE.GetValue += BALANCE_DUE_GetValue;

        fleF002_CLAIMS_MSTR_HDR.SelectIf += fleF002_CLAIMS_MSTR_HDR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(U010DAILY_DELETE_AA_FROM_F002_OUTSTANDING_7)"

    private SqlFileObject fleEXTF001AA;
    private SqlFileObject fleF002_CLAIMS_MSTR_HDR;

    private void fleF002_CLAIMS_MSTR_HDR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" =  '00000')");


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

    private SqlFileObject fleF002_ADJ;
    private SqlFileObject fleF002_OUTSTANDING;
    private DDecimal BALANCE_DUE = new DDecimal("BALANCE_DUE", 7);
    private void BALANCE_DUE_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_ADJ.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP") + fleF002_ADJ.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");


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


    #region "Standard Generated Procedures(U010DAILY_DELETE_AA_FROM_F002_OUTSTANDING_7)"


    #region "Automatic Item Initialization(U010DAILY_DELETE_AA_FROM_F002_OUTSTANDING_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U010DAILY_DELETE_AA_FROM_F002_OUTSTANDING_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:57 PM

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
        fleEXTF001AA.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_ADJ.Transaction = m_trnTRANS_UPDATE;
        fleF002_OUTSTANDING.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U010DAILY_DELETE_AA_FROM_F002_OUTSTANDING_7)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:27:57 PM

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
            fleEXTF001AA.Dispose();
            fleF002_CLAIMS_MSTR_HDR.Dispose();
            fleF002_ADJ.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U010DAILY_DELETE_AA_FROM_F002_OUTSTANDING_7)"


    public void Run()
    {

        try
        {
            Request("DELETE_AA_FROM_F002_OUTSTANDING_7");

            while (fleEXTF001AA.QTPForMissing())
            {
                // --> GET EXTF001AA <--

                fleEXTF001AA.GetData();
                // --> End GET EXTF001AA <--

                while (fleF002_CLAIMS_MSTR_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleEXTF001AA.GetStringValue("BATCTRL_BATCH_NBR")));

                    fleF002_CLAIMS_MSTR_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleF002_ADJ.QTPForMissing("2"))
                    {
                        // --> GET F002_ADJ <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_ADJ.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_ADJ.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_BATCH_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_ADJ.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_CLAIM_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_ADJ.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("00000"));

                        fleF002_ADJ.GetData(m_strWhere.ToString());
                        // --> End GET F002_ADJ <--

                        while (fleF002_OUTSTANDING.QTPForMissing("3"))
                        {
                            // --> GET F002_OUTSTANDING <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                            m_strWhere.Append(Common.StringToField("B"));
                            m_strWhere.Append(" And ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF002_ADJ.GetStringValue("CLMHDR_BATCH_NBR")));
                            m_strWhere.Append(" And ").Append(fleF002_OUTSTANDING.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                            m_strWhere.Append((fleF002_ADJ.GetDecimalValue("CLMHDR_CLAIM_NBR")));

                            fleF002_OUTSTANDING.GetData(m_strWhere.ToString());
                            // --> End GET F002_OUTSTANDING <--


                            if (Transaction())
                            {


                                fleF002_OUTSTANDING.OutPut(OutPutType.Delete, null, (BALANCE_DUE.Value == 0));

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
            EndRequest("DELETE_AA_FROM_F002_OUTSTANDING_7");

        }

    }




    #endregion


}
//DELETE_AA_FROM_F002_OUTSTANDING_7




