
#region "Screen Comments"

// #> PROGRAM-ID.     U020C.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : UPDATE SHADOW, CLAIMS, BATCTRL AND CONSTANTS FILES
// NOTE: if the patient has non-blank message code, then the claim can`t
// be submitted to OHIP and must be put on hold. 
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 91/FEB/13 D.B.         - ORIGINAL (SMS 138)
// 91/APR/29 M.C.      - SMS 138 (ENHANCEMENT)
// - UPDATE THE CLMHDR WITH CLAIM STATUS
// AND SUBMISSION DATE
// 91/OCT/07 M.C.      - PDR 521 - OPTIMIZATION
// 91/OCT/28 M.C.      - UPDATE CYCLE STRAIGHT TO CONSTANT-MSTR
// DO NOT DEPEND ON BATCH CONTROL FILE.
// 92/JUN/10 M.C.      - SMS 139 - UPDATE RECORD 61 TO 65 IN
// CONSTANTS-MSTR AS WELL
// 92/JUL/06 Y.B.         - UPDATE RECORD 60 TO 65 IN CONSTANTS-MSTR
// 93/MAR/18 M.C.      - SMS 140 - THE FIRST REQUEST IS NOW
// TRANSFERRED TO U020B.QTS
// - SELECT ON MOH-FLAG INSTEAD OF AGENT
// - UPDATE ANY VALID CLINIC BETWEEN 22 TO 99
// IN CONSTANTS-MSTR
// 93/MAY/06 M.C.      - SMS 141
// - ADD PAT-MESS-CODE INTO CONSIDERATION
// - PUT ALL NEW CLAIMS THAT HAVE MESS CODE
// IN PAT-MSTR INTO REJECTED-CLAIMS FILE
// AND THE SUBFILE U020C1
// 96/JAN/16 M.C.      - PDR 636
// - UPDATE BATCTRL-STATUS TO `3` INSTEAD OF
// `2`
// 98/Mar/06 M.C.      - SAF 149
// - add on errors report for all output files
// 99/feb/09 B.E  - no y2k changes needed
// 1999/May/21 S.B.        - Added the use file
// def_batctrl_batch_status.def to 
// prevent hardcoding of batctrl-batch-status.
// 04/jan/12 M.C. - alpha doc nbr
// 10/aug/03 MC1  - do not preset clmhdr-submit-date of f085 to be the set as f002
// 11/Jan/17 MC2  - update clmhdr-submit-date of f085 to be the system run date
// - keep append for subfile u020c1
// - update the last request to update constants mstr based on the actual clinic
// 11/Feb/14 MC3  - transfer the last request update-const-mstr to u020d.qts to be executed once


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U020C : BaseClassControl
{

    private U020C m_U020C;

    public U020C(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U020C(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U020C != null))
        {
            m_U020C.CloseTransactionObjects();
            m_U020C = null;
        }
    }

    public U020C GetU020C(int Level)
    {
        if (m_U020C == null)
        {
            m_U020C = new U020C("U020C", Level);
        }
        else
        {
            m_U020C.ResetValues();
        }
        return m_U020C;
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

            U020C_PROCESS_SHADOW_1 PROCESS_SHADOW_1 = new U020C_PROCESS_SHADOW_1(Name, Level);
            PROCESS_SHADOW_1.Run();
            PROCESS_SHADOW_1.Dispose();
            PROCESS_SHADOW_1 = null;

            U020C_UPDATE_BATCH_CONTROL_2 UPDATE_BATCH_CONTROL_2 = new U020C_UPDATE_BATCH_CONTROL_2(Name, Level);
            UPDATE_BATCH_CONTROL_2.Run();
            UPDATE_BATCH_CONTROL_2.Dispose();
            UPDATE_BATCH_CONTROL_2 = null;

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



public class U020C_PROCESS_SHADOW_1 : U020C
{

    public U020C_PROCESS_SHADOW_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU020A1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020A1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIM_SHADOW = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIM_SHADOW", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU020C1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020C1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleREJECTED_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "REJECTED_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        X_CLAIM_NBR.GetValue += X_CLAIM_NBR_GetValue;
        fleF002_CLAIM_SHADOW.SetItemFinals += fleF002_CLAIM_SHADOW_SetItemFinals;
        fleREJECTED_CLAIMS.SetItemFinals += fleREJECTED_CLAIMS_SetItemFinals;

        fleU020A1.SelectIf += fleU020A1_SelectIf;

    }


    #region "Declarations (Variables, Files and Transactions)(U020C_PROCESS_SHADOW_1)"

    private SqlFileObject fleU020A1;


    private void fleU020A1_SelectIf(ref string SelectIfClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (    ").Append(fleU020A1.ElementOwner("BATCTRL_BATCH_TYPE")).Append(" =  'C')");


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

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleU020A1.GetStringValue("PAT_MESS_CODE")) == QDesign.NULL(" "))
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", "S");
            }
            else
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", "H");
            }
            if (QDesign.NULL(fleU020A1.GetStringValue("PAT_MESS_CODE")) == QDesign.NULL(" "))
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_SUBMIT_DATE", QDesign.SysDate(ref m_cnnQUERY));
            }
            else
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_SUBMIT_DATE", 0);
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

    }

    private DCharacter X_CLAIM_NBR = new DCharacter("X_CLAIM_NBR", 10);
    private void X_CLAIM_NBR_GetValue(ref string Value)
    {

        try
        {
            Value = fleU020A1.GetStringValue("BATCTRL_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2);


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
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_CLINIC", fleU020A1.GetDecimalValue("ICONST_CLINIC_NBR_1_2"));
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_SUBDIVISION", fleU020A1.GetStringValue("CLMHDR_SUB_NBR"));
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_PAT_KEY_TYPE", (fleU020A1.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleU020A1.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(0, 1));

            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_PAT_KEY_OHIP", (fleU020A1.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleU020A1.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 8));

            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_FILLER5", (fleU020A1.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleU020A1.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(9, 7));

            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_BATCH_NBR", fleU020A1.GetStringValue("BATCTRL_BATCH_NBR"));
            fleF002_CLAIM_SHADOW.set_SetValue("CLM_SHADOW_CLAIM_NBR", QDesign.NConvert(QDesign.Substring(fleU020A1.GetStringValue("CLMHDR_BATCH_NBR") + fleU020A1.GetStringValue("CLMHDR_CLAIM_NBR"), 9, 2)));


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


    private SqlFileObject fleU020C1;
    private SqlFileObject fleREJECTED_CLAIMS;

    private void fleREJECTED_CLAIMS_SetItemFinals()
    {

        try
        {
            fleREJECTED_CLAIMS.set_SetValue("CLAIM_NBR", X_CLAIM_NBR.Value);
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_PAT_OHIP_ID_OR_CHART", fleU020A1.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleU020A1.GetStringValue("CLMHDR_PAT_KEY_DATA"));
            fleREJECTED_CLAIMS.set_SetValue("DOC_NBR", fleU020A1.GetStringValue("DOC_NBR"));
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_LOC", fleU020A1.GetStringValue("CLMHDR_LOC"));
            fleREJECTED_CLAIMS.set_SetValue("MESS_CODE", fleU020A1.GetStringValue("PAT_MESS_CODE"));
            fleREJECTED_CLAIMS.set_SetValue("CLMHDR_SUBMIT_DATE", QDesign.SysDate(ref m_cnnQUERY));


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


    #region "Standard Generated Procedures(U020C_PROCESS_SHADOW_1)"


    #region "Automatic Item Initialization(U020C_PROCESS_SHADOW_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U020C_PROCESS_SHADOW_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:09 PM

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
        fleU020A1.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIM_SHADOW.Transaction = m_trnTRANS_UPDATE;
        fleU020C1.Transaction = m_trnTRANS_UPDATE;
        fleREJECTED_CLAIMS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U020C_PROCESS_SHADOW_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:09 PM

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
            fleU020A1.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF002_CLAIM_SHADOW.Dispose();
            fleU020C1.Dispose();
            fleREJECTED_CLAIMS.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U020C_PROCESS_SHADOW_1)"


    public void Run()
    {

        try
        {
            Request("PROCESS_SHADOW_1");

            while (fleU020A1.QTPForMissing())
            {
                // --> GET U020A1 <--

                fleU020A1.GetData();
                // --> End GET U020A1 <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU020A1.GetStringValue("BATCTRL_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleU020A1.GetDecimalValue("CLMHDR_CLAIM_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--


                    if (Transaction())
                    {

                        Sort(fleU020A1.GetSortValue("CLMHDR_BATCH_NBR"), fleU020A1.GetSortValue("CLMHDR_CLAIM_NBR"), fleU020A1.GetSortValue("CLMHDR_ADJ_OMA_CD"), fleU020A1.GetSortValue("CLMHDR_ADJ_OMA_SUFF"), fleU020A1.GetSortValue("CLMHDR_ADJ_ADJ_NBR"));



                    }

                }

            }


            while (Sort(fleU020A1, fleF002_CLAIMS_MSTR))
            {
                fleF002_CLAIM_SHADOW.OutPut(OutPutType.Add, fleU020A1.At("CLMHDR_BATCH_NBR") | fleU020A1.At("CLMHDR_CLAIM_NBR") | fleU020A1.At("CLMHDR_ADJ_OMA_CD") | fleU020A1.At("CLMHDR_ADJ_OMA_SUFF") | fleU020A1.At("CLMHDR_ADJ_ADJ_NBR"), (QDesign.NULL(fleU020A1.GetDecimalValue("BATCTRL_AGENT_CD")) == 4 | QDesign.NULL(fleU020A1.GetDecimalValue("BATCTRL_AGENT_CD")) == 6));



                fleF002_CLAIMS_MSTR.OutPut(OutPutType.Update, null, QDesign.NULL(fleU020A1.GetStringValue("MOH_FLAG")) == "Y");




                SubFile(ref m_trnTRANS_UPDATE, ref fleU020C1, QDesign.NULL(fleU020A1.GetStringValue("MOH_FLAG")) == "Y" & QDesign.NULL(fleU020A1.GetStringValue("PAT_MESS_CODE")) != QDesign.NULL(" "), SubFileType.Keep, SubFileMode.Append, fleU020A1);



                fleREJECTED_CLAIMS.OutPut(OutPutType.Add, null, QDesign.NULL(fleU020A1.GetStringValue("PAT_MESS_CODE")) != QDesign.NULL(" ") & QDesign.NULL(fleU020A1.GetStringValue("MOH_FLAG")) == "Y");


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



public class U020C_UPDATE_BATCH_CONTROL_2 : U020C
{

    public U020C_UPDATE_BATCH_CONTROL_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU020A1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U020A1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF001_BATCH_CONTROL_FILE.SetItemFinals += fleF001_BATCH_CONTROL_FILE_SetItemFinals;
        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U020C_UPDATE_BATCH_CONTROL_2)"

    private SqlFileObject fleU020A1;
    private SqlFileObject fleF001_BATCH_CONTROL_FILE;

    private void fleF001_BATCH_CONTROL_FILE_SetItemFinals()
    {

        try
        {
            fleF001_BATCH_CONTROL_FILE.set_SetValue("BATCTRL_BATCH_STATUS", BATCTRL_BATCH_STATUS_OHIP_SENT.Value);


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


    #endregion


    #region "Standard Generated Procedures(U020C_UPDATE_BATCH_CONTROL_2)"


    #region "Automatic Item Initialization(U020C_UPDATE_BATCH_CONTROL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U020C_UPDATE_BATCH_CONTROL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:09 PM

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
        fleU020A1.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U020C_UPDATE_BATCH_CONTROL_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 12:28:09 PM

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
            fleU020A1.Dispose();
            fleF001_BATCH_CONTROL_FILE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U020C_UPDATE_BATCH_CONTROL_2)"


    public void Run()
    {

        try
        {
            Request("UPDATE_BATCH_CONTROL_2");

            while (fleU020A1.QTPForMissing())
            {
                // --> GET U020A1 <--

                fleU020A1.GetData();
                // --> End GET U020A1 <--

                while (fleF001_BATCH_CONTROL_FILE.QTPForMissing("1"))
                {
                    // --> GET F001_BATCH_CONTROL_FILE <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF001_BATCH_CONTROL_FILE.ElementOwner("BATCTRL_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU020A1.GetStringValue("BATCTRL_BATCH_NBR")));

                    fleF001_BATCH_CONTROL_FILE.GetData(m_strWhere.ToString());
                    // --> End GET F001_BATCH_CONTROL_FILE <--


                    if (Transaction())
                    {

                        Sort(fleF001_BATCH_CONTROL_FILE.GetSortValue("BATCTRL_BATCH_NBR"));



                    }

                }

            }


            while (Sort(fleU020A1, fleF001_BATCH_CONTROL_FILE))
            {
                fleF001_BATCH_CONTROL_FILE.OutPut(OutPutType.Update, fleF001_BATCH_CONTROL_FILE.At("BATCTRL_BATCH_NBR"), null);


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
            EndRequest("UPDATE_BATCH_CONTROL_2");

        }

    }




    #endregion


}
//UPDATE_BATCH_CONTROL_2




