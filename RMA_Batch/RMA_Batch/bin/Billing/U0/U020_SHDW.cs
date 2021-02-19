
#region "Screen Comments"

// #> PROGRAM-ID.     U020_SHDW.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : READ F001-BATCH-CONTROL-FILE AND SELECT
// BALANCED BATCHES(<=2) 
// AND EXTRACT DATA NEEDED FOR CLAIM SHADOW
// This program only runs as first part of claim purge
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 2012/Jan/23 MC1          - ORIGINAL


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U020_SHDW : BaseClassControl
{

    private U020_SHDW m_U020_SHDW;

    public U020_SHDW(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U020_SHDW(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U020_SHDW != null))
        {
            m_U020_SHDW.CloseTransactionObjects();
            m_U020_SHDW = null;
        }
    }

    public U020_SHDW GetU020_SHDW(int Level)
    {
        if (m_U020_SHDW == null)
        {
            m_U020_SHDW = new U020_SHDW("U020_SHDW", Level);
        }
        else
        {
            m_U020_SHDW.ResetValues();
        }
        return m_U020_SHDW;
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

            U020_SHDW_PROCESS_SHADOW_1 PROCESS_SHADOW_1 = new U020_SHDW_PROCESS_SHADOW_1(Name, Level);
            PROCESS_SHADOW_1.Run();
            PROCESS_SHADOW_1.Dispose();
            PROCESS_SHADOW_1 = null;

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



public class U020_SHDW_PROCESS_SHADOW_1 : U020_SHDW
{

    public U020_SHDW_PROCESS_SHADOW_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIM_SHADOW = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIM_SHADOW", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
        fleF002_CLAIM_SHADOW.SetItemFinals += fleF002_CLAIM_SHADOW_SetItemFinals;

        fleF001_BATCH_CONTROL_FILE.SelectIf += fleF001_BATCH_CONTROL_FILE_SelectIf;
        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(U020_SHDW_PROCESS_SHADOW_1)"

    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_STATUS")).Append(" <=  ").Append(Common.StringToField(BATCTRL_BATCH_STATUS_REV_UPDATED.Value)).Append("  AND ");
            strSQL.Append("    ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_TYPE")).Append(" =  'C' AND ");
            strSQL.Append(" (    ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_AGENT_CD")).Append(" =  4 OR ");
            strSQL.Append("    ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_AGENT_CD")).Append(" =  6 ))");


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

    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_ADJ_OMA_CD")).Append(" =  '0000')");


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

    private SqlFileObject fleICONST_MSTR_REC;
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
    private SqlFileObject fleF002_CLAIM_SHADOW;

    private void fleF002_CLAIM_SHADOW_SetItemFinals()
    {

        try
        {
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_CLINIC", fleICONST_MSTR_REC.GetDecimalValue("ICONST_CLINIC_NBR_1_2"));
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_SUBDIVISION", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_SUB_NBR"));
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_PAT_KEY_TYPE", fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE"));
            
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_PAT_KEY_OHIP", (fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")));
            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART).Padright(16).Substring(1,8)    'Parent:CLM_SHADOW_PATIENT
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_FILLER5", (fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")));
            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART).Padright(16).Substring(9,7)    'Parent:CLM_SHADOW_PATIENT
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_BATCH_NBR", fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"));
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_CLAIM_NBR", fleF002_CLAIMS_MSTR.GetDecimalValue("KEY_CLM_CLAIM_NBR"));


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


    #region "Standard Generated Procedures(U020_SHDW_PROCESS_SHADOW_1)"


    #region "Automatic Item Initialization(U020_SHDW_PROCESS_SHADOW_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U020_SHDW_PROCESS_SHADOW_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:03 PM

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
        fleF002_CLAIM_SHADOW.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U020_SHDW_PROCESS_SHADOW_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:03 PM

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
            fleF002_CLAIM_SHADOW.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U020_SHDW_PROCESS_SHADOW_1)"


    public void Run()
    {

        try
        {
            Request("PROCESS_SHADOW_1");

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
                        m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_NBR"), 1, 2))));

                        fleICONST_MSTR_REC.GetData(m_strWhere.ToString());
                        // --> End GET ICONST_MSTR_REC <--


                        if (Transaction())
                        {

                            Sort(fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_BATCH_NBR"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_CLAIM_NBR"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_ADJ_OMA_CD"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_ADJ_OMA_SUFF"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_ADJ_ADJ_NBR"));
                            //Parent:CLMHDR_CLAIM_ID


                        }

                    }

                }

            }


            while (Sort(fleF001_BATCH_CONTROL_FILE, fleF002_CLAIMS_MSTR, fleICONST_MSTR_REC))
            {


                fleF002_CLAIM_SHADOW.OutPut(OutPutType.Add, fleF002_CLAIMS_MSTR.At("CLMHDR_CLAIM_ID"), null);
                //Parent:CLMHDR_CLAIM_ID)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLM_SHADOW_PATIENT

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
            EndRequest("PROCESS_SHADOW_1");

        }

    }




    #endregion


}
//PROCESS_SHADOW_1




