
#region "Screen Comments"

// #> PROGRAM-ID.     u086.qts
// ((C)) Dyad Technologies
// PROGRAM PURPOSE: When patient eligibility information is changed a
// driver record is written to f086. F086 is used by this
// program to update all patient claims that were being
//  H eld so that they will be  R esubmitted. Any held
// claim which belongs to the current cycle (claim`s
// f001 record`s status is checked) have the status
// set to  blank  rather than  R  so they can be
// processed by the OHIP submission program rather than
// the resubmits program.
// Any of the patient`s claims in the `rejected claims` 
// file are also deleted by the program.
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 93/APR/28 AGK.         - ORIGINAL (SMS 141)
// 93/MAY/28 M.CHAN      - PDR 573
// - A NEW REQUEST TO RESUBMIT SUBMITTED
// CLAIMS THAT HAVE NOT BEEN PAID
// 96/DEC/10 M. CHAN      - REVISED THE ACCESS AND SELECT STMT
// 98/DEC/08 M. CHAN      - add a new request to sort f086-pat-id to create
// unique ikey into the subfile, and using the 
// subfile as the driver file for each request
// - add on errors report on each output statement
// - use pkey index of f002-claims-mstr instead of 
// bkey index in request resubmit_submitted_claims
// 1999/jan/31 B.E. - y2k
// 1999/Feb/01 M.C.          - change to access to key-p-clm-data instead of the
// individual segments for p key
// 1999/nov/25 B.E. - added select if clmhdr-date-cash-tape-payment = blanks
// to existing test for all zeros
// 00/may/30 B.E.     - if claim that qualified for resubmission belongs
// to the current cycle, then set it submit status ind
// to blank rather than  R .
// 00/may/30 B.E.    - removed code that set  Y es confidential status to  N .
// 00/may/30 B.E.    - removed resubmit_submitted_claims request
// 03/dec/23 A.A.    - alpha doctor nbr
// 04/Jan/21 M.C.    - Brad suggested to clone request patient_claims_update to another
// new request except no linkage to rejected-claims
// 04/Mar/23 M.C.    - modify the definition for submit-status  based on balance due
// in two requests, also add bal-due in two requests
// 04/aug/29 b.e.     - for unknown reason the access of claim  22C5000199  
// gave error in translating the `99` to numeric if the 
// linkage was from subfile to claims directly. Therefore
// split request `patient_claims_update` into 2 parts - 
// to create batch/claim numbers as alpha/numeric vales 
// and put into temp subrfile which then access f002 fine 


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U086 : BaseClassControl
{

    private U086 m_U086;

    public U086(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U086(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U086 != null))
        {
            m_U086.CloseTransactionObjects();
            m_U086 = null;
        }
    }

    public U086 GetU086(int Level)
    {
        if (m_U086 == null)
        {
            m_U086 = new U086("U086", Level);
        }
        else
        {
            m_U086.ResetValues();
        }
        return m_U086;
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

            U086_SORT_F086_PAT_ID_1 SORT_F086_PAT_ID_1 = new U086_SORT_F086_PAT_ID_1(Name, Level);
            SORT_F086_PAT_ID_1.Run();
            SORT_F086_PAT_ID_1.Dispose();
            SORT_F086_PAT_ID_1 = null;

            U086_PATIENT_CLAIMS_UPDATE_PART_1_2 PATIENT_CLAIMS_UPDATE_PART_1_2 = new U086_PATIENT_CLAIMS_UPDATE_PART_1_2(Name, Level);
            PATIENT_CLAIMS_UPDATE_PART_1_2.Run();
            PATIENT_CLAIMS_UPDATE_PART_1_2.Dispose();
            PATIENT_CLAIMS_UPDATE_PART_1_2 = null;

            U086_PATIENT_CLAIMS_UPDATE_PART_1_3 PATIENT_CLAIMS_UPDATE_PART_1_3 = new U086_PATIENT_CLAIMS_UPDATE_PART_1_3(Name, Level);
            PATIENT_CLAIMS_UPDATE_PART_1_3.Run();
            PATIENT_CLAIMS_UPDATE_PART_1_3.Dispose();
            PATIENT_CLAIMS_UPDATE_PART_1_3 = null;

            U086_PATIENT_CLAIMS_UPDATE_2_4 PATIENT_CLAIMS_UPDATE_2_4 = new U086_PATIENT_CLAIMS_UPDATE_2_4(Name, Level);
            PATIENT_CLAIMS_UPDATE_2_4.Run();
            PATIENT_CLAIMS_UPDATE_2_4.Dispose();
            PATIENT_CLAIMS_UPDATE_2_4 = null;

            U086_DELETE_REJECTED_CLAIMS_5 DELETE_REJECTED_CLAIMS_5 = new U086_DELETE_REJECTED_CLAIMS_5(Name, Level);
            DELETE_REJECTED_CLAIMS_5.Run();
            DELETE_REJECTED_CLAIMS_5.Dispose();
            DELETE_REJECTED_CLAIMS_5 = null;

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



public class U086_SORT_F086_PAT_ID_1 : U086
{

    public U086_SORT_F086_PAT_ID_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF086_PAT_ID = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F086_PAT_ID", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSORTF086 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SORTF086", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U086_SORT_F086_PAT_ID_1)"

    private SqlFileObject fleF086_PAT_ID;
    private SqlFileObject fleSORTF086;


    #endregion


    #region "Standard Generated Procedures(U086_SORT_F086_PAT_ID_1)"


    #region "Automatic Item Initialization(U086_SORT_F086_PAT_ID_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U086_SORT_F086_PAT_ID_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:53 PM

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
        fleF086_PAT_ID.Transaction = m_trnTRANS_UPDATE;
        fleSORTF086.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U086_SORT_F086_PAT_ID_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:53 PM

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
            fleF086_PAT_ID.Dispose();
            fleSORTF086.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U086_SORT_F086_PAT_ID_1)"


    public void Run()
    {

        try
        {
            Request("SORT_F086_PAT_ID_1");

            while (fleF086_PAT_ID.QTPForMissing())
            {
                // --> GET F086_PAT_ID <--

                fleF086_PAT_ID.GetData();
                // --> End GET F086_PAT_ID <--


                if (Transaction())
                {

                    Sort(fleF086_PAT_ID.GetSortValue("CLMHDR_PAT_OHIP_ID_OR_CHART"));


                }

            }


            while (Sort(fleF086_PAT_ID))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleSORTF086, fleF086_PAT_ID.At("CLMHDR_PAT_OHIP_ID_OR_CHART"), SubFileType.Keep, fleF086_PAT_ID);
                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART


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
            EndRequest("SORT_F086_PAT_ID_1");

        }

    }




    #endregion


}
//SORT_F086_PAT_ID_1



public class U086_PATIENT_CLAIMS_UPDATE_PART_1_2 : U086
{

    public U086_PATIENT_CLAIMS_UPDATE_PART_1_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSORTF086 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SORTF086", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleREJECTED_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "REJECTED_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSORTF086_2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SORTF086_2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        BATCH_NBR.GetValue += BATCH_NBR_GetValue;
        CLAIM_NBR_2.GetValue += CLAIM_NBR_2_GetValue;
        CLAIM_NBR_NUM.GetValue += CLAIM_NBR_NUM_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U086_PATIENT_CLAIMS_UPDATE_PART_1_2)"

    private SqlFileObject fleSORTF086;
    private SqlFileObject fleREJECTED_CLAIMS;
    private DCharacter BATCH_NBR = new DCharacter("BATCH_NBR", 8);
    private void BATCH_NBR_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleREJECTED_CLAIMS.GetStringValue("CLAIM_NBR"), 1, 8);


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
    private DCharacter CLAIM_NBR_2 = new DCharacter("CLAIM_NBR_2", 2);
    private void CLAIM_NBR_2_GetValue(ref string Value)
    {

        try
        {
            Value= QDesign.Substring(fleREJECTED_CLAIMS.GetStringValue("CLAIM_NBR"), 9, 2);


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
    private DDecimal CLAIM_NBR_NUM = new DDecimal("CLAIM_NBR_NUM", 6);
    private void CLAIM_NBR_NUM_GetValue(ref decimal Value)
    {

        try
        {
            Value = QDesign.NConvert(CLAIM_NBR_2.Value);


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

    private SqlFileObject fleSORTF086_2;


    #endregion


    #region "Standard Generated Procedures(U086_PATIENT_CLAIMS_UPDATE_PART_1_2)"


    #region "Automatic Item Initialization(U086_PATIENT_CLAIMS_UPDATE_PART_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U086_PATIENT_CLAIMS_UPDATE_PART_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:53 PM

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
        fleSORTF086.Transaction = m_trnTRANS_UPDATE;
        fleREJECTED_CLAIMS.Transaction = m_trnTRANS_UPDATE;
        fleSORTF086_2.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U086_PATIENT_CLAIMS_UPDATE_PART_1_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:53 PM

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
            fleSORTF086.Dispose();
            fleREJECTED_CLAIMS.Dispose();
            fleSORTF086_2.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U086_PATIENT_CLAIMS_UPDATE_PART_1_2)"


    public void Run()
    {

        try
        {
            Request("PATIENT_CLAIMS_UPDATE_PART_1_2");

            while (fleSORTF086.QTPForMissing())
            {
                // --> GET SORTF086 <--

                fleSORTF086.GetData();
                // --> End GET SORTF086 <--

                while (fleREJECTED_CLAIMS.QTPForMissing("1"))
                {
                    // --> GET REJECTED_CLAIMS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleREJECTED_CLAIMS.ElementOwner("CLMHDR_PAT_OHIP_ID_OR_CHART")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSORTF086.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")));

                    fleREJECTED_CLAIMS.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET REJECTED_CLAIMS <--


                    if (Transaction())
                    {

                        SubFile(ref m_trnTRANS_UPDATE, ref fleSORTF086_2, SubFileType.Keep, fleSORTF086, BATCH_NBR, CLAIM_NBR_NUM);
                        //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART


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
            EndRequest("PATIENT_CLAIMS_UPDATE_PART_1_2");

        }

    }




    #endregion


}
//PATIENT_CLAIMS_UPDATE_PART_1_2



public class U086_PATIENT_CLAIMS_UPDATE_PART_1_3 : U086
{

    public U086_PATIENT_CLAIMS_UPDATE_PART_1_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSORTF086_2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SORTF086_2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
        BAL_DUE.GetValue += BAL_DUE_GetValue;
        SUBMIT_STATUS.GetValue += SUBMIT_STATUS_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U086_PATIENT_CLAIMS_UPDATE_PART_1_3)"

    private SqlFileObject fleSORTF086_2;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_TAPE_SUBMIT_IND")) == "H" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_TAPE_SUBMIT_IND")) == "R")
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", SUBMIT_STATUS.Value);
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
    private DCharacter SUBMIT_STATUS = new DCharacter("SUBMIT_STATUS", 1);
    private void SUBMIT_STATUS_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (fleF001_BATCH_CONTROL_FILE.Exists() & string.Compare(QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS")) , QDesign.NULL(BATCTRL_BATCH_STATUS_OHIP_SENT.Value))<0)
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
            else if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SUBMIT_DATE")) != 0 & (BAL_DUE.Value <= 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_STATUS_OHIP")) == "I2"))
            {
                CurrentValue = "S";
            }
            else if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SUBMIT_DATE")) == 0 & (BAL_DUE.Value <= 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_STATUS_OHIP")) == "I2"))
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


    #endregion


    #region "Standard Generated Procedures(U086_PATIENT_CLAIMS_UPDATE_PART_1_3)"


    #region "Automatic Item Initialization(U086_PATIENT_CLAIMS_UPDATE_PART_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U086_PATIENT_CLAIMS_UPDATE_PART_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:53 PM

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
        fleSORTF086_2.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U086_PATIENT_CLAIMS_UPDATE_PART_1_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:53 PM

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
            fleSORTF086_2.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U086_PATIENT_CLAIMS_UPDATE_PART_1_3)"


    public void Run()
    {

        try
        {
            Request("PATIENT_CLAIMS_UPDATE_PART_1_3");

            while (fleSORTF086_2.QTPForMissing())
            {
                // --> GET SORTF086_2 <--

                fleSORTF086_2.GetData();
                // --> End GET SORTF086_2 <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(("B")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSORTF086_2.GetStringValue("BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleSORTF086_2.GetDecimalValue("CLAIM_NBR_NUM")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleF001_BATCH_CONTROL_FILE.QTPForMissing("2"))
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
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART

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
            EndRequest("PATIENT_CLAIMS_UPDATE_PART_1_3");

        }

    }




    #endregion


}
//PATIENT_CLAIMS_UPDATE_PART_1_3



public class U086_PATIENT_CLAIMS_UPDATE_2_4 : U086
{

    public U086_PATIENT_CLAIMS_UPDATE_2_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSORTF086 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SORTF086", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF001_BATCH_CONTROL_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F001_BATCH_CONTROL_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_CLAIMS_MSTR.SetItemFinals += fleF002_CLAIMS_MSTR_SetItemFinals;
        BATCTRL_BATCH_STATUS_UNBALANCED.GetValue += BATCTRL_BATCH_STATUS_UNBALANCED_GetValue;
        BATCTRL_BATCH_STATUS_BALANCED.GetValue += BATCTRL_BATCH_STATUS_BALANCED_GetValue;
        BATCTRL_BATCH_STATUS_REV_UPDATED.GetValue += BATCTRL_BATCH_STATUS_REV_UPDATED_GetValue;
        BATCTRL_BATCH_STATUS_OHIP_SENT.GetValue += BATCTRL_BATCH_STATUS_OHIP_SENT_GetValue;
        BATCTRL_BATCH_STATUS_MONTHEND_DONE.GetValue += BATCTRL_BATCH_STATUS_MONTHEND_DONE_GetValue;
        BAL_DUE.GetValue += BAL_DUE_GetValue;
        SUBMIT_STATUS.GetValue += SUBMIT_STATUS_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U086_PATIENT_CLAIMS_UPDATE_2_4)"

    private SqlFileObject fleSORTF086;
    private SqlFileObject fleF002_CLAIMS_MSTR;

    private void fleF002_CLAIMS_MSTR_SetItemFinals()
    {

        try
        {
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_TAPE_SUBMIT_IND")) == "H" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_TAPE_SUBMIT_IND")) == "R")
            {
                fleF002_CLAIMS_MSTR.set_SetValue("CLMHDR_TAPE_SUBMIT_IND", SUBMIT_STATUS.Value);
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
    private DCharacter SUBMIT_STATUS = new DCharacter("SUBMIT_STATUS", 1);
    private void SUBMIT_STATUS_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (fleF001_BATCH_CONTROL_FILE.Exists() & string.Compare(QDesign.NULL(fleF001_BATCH_CONTROL_FILE.GetStringValue("BATCTRL_BATCH_STATUS")) , QDesign.NULL(BATCTRL_BATCH_STATUS_OHIP_SENT.Value))<0)
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
            else if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SUBMIT_DATE")) != 0 & (BAL_DUE.Value <= 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_STATUS_OHIP")) == "I2"))
            {
                CurrentValue = "S";
            }
            else if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_SUBMIT_DATE")) == 0 & (BAL_DUE.Value <= 0 | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_STATUS_OHIP")) == "I2"))
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


    #endregion


    #region "Standard Generated Procedures(U086_PATIENT_CLAIMS_UPDATE_2_4)"


    #region "Automatic Item Initialization(U086_PATIENT_CLAIMS_UPDATE_2_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U086_PATIENT_CLAIMS_UPDATE_2_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:54 PM

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
        fleSORTF086.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF001_BATCH_CONTROL_FILE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U086_PATIENT_CLAIMS_UPDATE_2_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:54 PM

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
            fleSORTF086.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U086_PATIENT_CLAIMS_UPDATE_2_4)"


    public void Run()
    {

        try
        {
            Request("PATIENT_CLAIMS_UPDATE_2_4");

            while (fleSORTF086.QTPForMissing())
            {
                // --> GET SORTF086 <--

                fleSORTF086.GetData();
                // --> End GET SORTF086 <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_P_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(("P")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_P_CLM_DATA")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleSORTF086.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART"), 2, 15)));
                    //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleF001_BATCH_CONTROL_FILE.QTPForMissing("2"))
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
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART

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
            EndRequest("PATIENT_CLAIMS_UPDATE_2_4");

        }

    }




    #endregion


}
//PATIENT_CLAIMS_UPDATE_2_4



public class U086_DELETE_REJECTED_CLAIMS_5 : U086
{

    public U086_DELETE_REJECTED_CLAIMS_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleSORTF086 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SORTF086", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleREJECTED_CLAIMS = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "REJECTED_CLAIMS", "", false, false, false, 0, "m_trnTRANS_UPDATE");


    }


    #region "Declarations (Variables, Files and Transactions)(U086_DELETE_REJECTED_CLAIMS_5)"

    private SqlFileObject fleSORTF086;
    private SqlFileObject fleREJECTED_CLAIMS;

    #endregion


    #region "Standard Generated Procedures(U086_DELETE_REJECTED_CLAIMS_5)"


    #region "Automatic Item Initialization(U086_DELETE_REJECTED_CLAIMS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U086_DELETE_REJECTED_CLAIMS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:54 PM

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
        fleSORTF086.Transaction = m_trnTRANS_UPDATE;
        fleREJECTED_CLAIMS.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U086_DELETE_REJECTED_CLAIMS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:54 PM

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
            fleSORTF086.Dispose();
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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U086_DELETE_REJECTED_CLAIMS_5)"


    public void Run()
    {

        try
        {
            Request("DELETE_REJECTED_CLAIMS_5");

            while (fleSORTF086.QTPForMissing())
            {
                // --> GET SORTF086 <--

                fleSORTF086.GetData();
                // --> End GET SORTF086 <--

                while (fleREJECTED_CLAIMS.QTPForMissing("1"))
                {
                    // --> GET REJECTED_CLAIMS <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleREJECTED_CLAIMS.ElementOwner("CLMHDR_PAT_OHIP_ID_OR_CHART")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleSORTF086.GetStringValue("CLMHDR_PAT_OHIP_ID_OR_CHART")));

                    fleREJECTED_CLAIMS.GetData(m_strWhere.ToString());
                    // --> End GET REJECTED_CLAIMS <--


                    if (Transaction())
                    {

                        fleREJECTED_CLAIMS.OutPut(OutPutType.Delete);
                        //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART

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
            EndRequest("DELETE_REJECTED_CLAIMS_5");

        }

    }




    #endregion


}
//DELETE_REJECTED_CLAIMS_5




