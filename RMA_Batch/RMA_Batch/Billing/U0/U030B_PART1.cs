
#region "Screen Comments"

// #> PROGRAM-ID.     U030B.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : SECOND PASS OF U030
// THIS IS THE MAIN PROGRAM OF THE ORIGINAL
// U030.CB
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 91/FEB/20 M.C.         - ORIGINAL (SMS 138)
// 91/JUL/27 M.C.        - PDR 511
// - ADD TWO NEW REQUESTS IN THE BEGINNING
// EDIT AND SORT RECORDS
// 91/OCT/01 M.C.             - PDR 520
// - ADD TWO NEW REQUESTS BETWEEN REQUESTS
// `CREATE_ISAM_DTL` AND `MATCH_DTL`
// - TRY TO MATCH RAT DTL WITH EQUIVALENCE
// TABLE FOR THE DTL THAT DO NOT MATCH TO
// CLAIM MSTR
// - ADD NEW FIELD `PART-DTL-EQUIV-FLAG` IN
// PART-PAID-DTL RECORD
// - SAVE `X-BAL-FLAG` IN U030_NO_ADJ SUBFILE.
// 91/DEC/16 M.C.         - ADD SEL IF CONDITION IN MATCH_DTL REQUEST
// - ADD SELECTION AND STORE TWO MORE FIELDS
// IN THE SUBFILE IN SORT_BEFORE_ADJ REQUEST
// - COMMENT THE LINKAGE TO F002-CLMHDR AND
// SOME DEFINE STATEMENTS AND SELECTION
// CONDITION IN  SORT_BEFORE_ADJ REQUEST
// - COMMENT THE LINKAGE TO F002-CLMDTL AND
// SOME DEFINE STATEMENTS AND SELECTION
// CONDITION IN CREATE_B_ADJUSTMENT REQUEST
// - IN CREATE_B_ADJUSTMENT REQUEST, CREATE
// A NEW SUBFILE TO STORE ALL ADJUSTED
// BATCHES
// - ADD A NEW REQUEST TO UPDATE THE ADJUSTED
// BATCHES INTO THE INTERMEDIATE FILE
// PART_ADJ_BATCH
// 92/MAR/20 M.C.            - PDR 550
// - AGENT 4 CLAIMS GOT PROCESSED IN TAPE,
// MODIFY REQUEST `EXTRACT-CLAIMS`, TO
// UPDATE CLAIMS MSTR AND/OR CREATE
// PART-PAID-HDR FOR AGENT 4 AS WELL
// 92/AUG/17 M.C.        - TAKE OUT THE SELECTION CRITERIA  IN
// MATCH_DTL REQUEST
// 93/FEB/19 M.C.         - PDR 560 - WHEN CREATING THE ADJUSTMENT
// USE THE DOC-DEPT INSTEAD OF THE DEPT OF
// THE ORIGINAL CLAIM DEPT
// 93/AUG/10 M.C.          - PDR 565 - SET THE CLMDTL-LINE-NO
// 93/SEP/02 M.C.         - SMS 143 - EXTEND THE FILE DEFINITION
// IN PART-PAID-HDR AND
// PART-PAID-DTL FILE TO STORE
// THE NECESSARY INFO FOR RU030B
// REPORT
// 94/JAN/06 M.C.          - SMS 144 - INCLUDE THE LOGIC FOR SOCIAL
// CONTRACT ADJUSTMENT (IE. HOLD
// BACK OR OVERPAY)
// 94/FEB/01 M.C.        - COMMENT OUT THE REQUEST `CREATE_DUMMY_
// SERV_CODE`, DO NOT CREATE AUTO ADJUSTMENT
// FOR DUMMY CODE Y999A, REPORT ON THE NEW
// REPORT FOR MANUALLY ADJUSTMENT BY USER
// 94/FEB/21 M.C.            - SUBTOTAL THE OUTSTANDING BALANCE BY CLAIM
// AND UPDATE TO THE CLAIM HEADER IN A NEW
// SEPARATE REQUEST
// 94/AUG/03 M.C.         - SMS 146 - CHECK THE APPROPRIATE SOCIAL
// CONTRACT REDUCTION FACTOR BASED
// ON THE SERVICE DATE
// 95/APR/25 M.C.             - PDR 615 - PRESET THE AGENT  OF AUTOMATIC
// ADJUSTMENT CLAIM TO BE THE SAME
// AS THE ORIGINAL CLAIM
// - PRESET THE BATCTRL AGENT OF THE
// AUTOMATIC ADJUSTMENT TO BE THE
// SAME AS THE LAST CLAIM IN THE
// BATCH
// 96/MAR/11 M.C.           - PDR 637 - UPDATE OHIP CLAIM NBR INTO
// F002-CLAIMS-EXTRA IN PROCEDURE
// HOLD_CLAIM_STATUS
// 96/OCT/08 M.C.      - MODIFY REQUEST `EXTRACT_CLAIMS` TO ADD
// CLMHDR-AGENT-CD IN U030_PAID_AMT SUBFILE
// - MODIFY REQUEST `UPDATE_CASH_MSTR` TO USE
// CLMHDR-AGENT-CD TO LINK F051-DOC-CASH-MSTR
// 97/APR/14 YAS.        - PDR 656 - NEW CLINIC 82 - NO AUTO ADJUST
// 97/AUG/06 YAS.          - PDR 664 - NEW CLINIC 83 - NO AUTO ADJUST
// 97/DEC/03 M.C.          - PDR 663 - ADD TO LINK TO F099 FILE
// SUBSTITUTE RAT-145-GROUP-NBR WITH X-GROUP-NBR
// FROM REQUEST EXTRACT_CLAIMS AND ONWARD
// 98/MAR/25 YAS.            - PDR 668 - ADD CLINIC 80
// 98/Sep/10 B.E. - for clinic 60-65, if ohip no-payment reason code
// is 80 and autoajustment created should affect
// only techical portion of claim.
// 1999/May/21 S.B.     - Added the use file
// def_batctrl_batch_status.def to 
// prevent hardcoding of batctrl-batch-status.
// 1999/May/31 S.B.     - Added the use file
// def_clmhdr_status_ohip.def to 
// prevent hard coding of clmhdr-status-ohip.
// 1999/oct/20 B.E.   - y2k format of date assignments changed from 6 to 8
// 1999/dec/20 M.C.   - create P key when creating f002 hdr/dtl adjustment
// 2000/feb/14 M.C.   - correct the formula when creating p key dtl record 
// 2001/feb/06 M.C.   - Yas requests to update MOH`s claim number with all
// claims.  Modify request extract_claims and 
// hold_claim_status
// 2001/nov/16 B.E.   - transfer last `request` from u030b to u030bb to 
// reduce complexity/size of u030b
// 2002/sep/05 yas.   - add new linic 95 (AA2K)
// 2002/sep/09 M.C.   - undo the transfer done on 2001/nov/16 by Brad
// - transfer back the first `request`from u030bb to u030b for
// updating amount in clmhdr
// - u030b_special2.qts has already included this logic 
// of updating clmhdr amount.  
// If u030b_special1/2.qts are run to replace u030b.qts,
// currently update clmhdr amount will be double.
// jun/02/04    yas   - add new clinics AA5V AA5W AA5X AA5Y 6317
// 2003/oct/22 M.C.  - Mary Ann/Yasemin requested not to automatically adjust
// if department = 26 and reason code = D7 or 35
// 2003/nov/04 M.C.  - Mary Ann/Yasemin requested not to automatically adjust
// if department = 26 only           
// 2003/nov/12 M.C.  - comment out the clinics when creating u030_auto_adj or
// u030_no_adj subfiles, they are redundant codes, they 
// can determine based on the values defined for each limit
// for each clinic in the constants mstr
// 2003/dec/12 A.A.  - alpha doctor nbr
// 2004/aug/10 M.C.  - allow first 3 character to be alpha numeric
// when pattern matching against rat-145-account-nbr
// 2004/nov/25 M.C.  - check to make sure 3 digit doc nbr match with their
// own 6 digit ohip nbr; otherwise, it considers as error
// - add f020 to the access statement
// 2006/apr/04 M.C.  - change the sort on explan cd in descending order 
// in the last request  
// 2010/Apr/07 MC1   - use set lock record update
// 2010/04/07 - MC1
// set lock file update
// 2010/04/07 - end
// ;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U030B_PART1 : BaseClassControl
{

    private U030B_PART1 m_U030B_PART1;

    public U030B_PART1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U030B_PART1(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U030B_PART1 != null))
        {
            m_U030B_PART1.CloseTransactionObjects();
            m_U030B_PART1 = null;
        }
    }

    public U030B_PART1 GetU030B_PART1(int Level)
    {
        if (m_U030B_PART1 == null)
        {
            m_U030B_PART1 = new U030B_PART1("U030B_PART1", Level);
        }
        else
        {
            m_U030B_PART1.ResetValues();
        }
        return m_U030B_PART1;
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

            U030B_PART1_EDIT_RECORDS_1 EDIT_RECORDS_1 = new U030B_PART1_EDIT_RECORDS_1(Name, Level);
            EDIT_RECORDS_1.Run();
            EDIT_RECORDS_1.Dispose();
            EDIT_RECORDS_1 = null;

            U030B_PART1_SORT_GOOD_RECORDS_2 SORT_GOOD_RECORDS_2 = new U030B_PART1_SORT_GOOD_RECORDS_2(Name, Level);
            SORT_GOOD_RECORDS_2.Run();
            SORT_GOOD_RECORDS_2.Dispose();
            SORT_GOOD_RECORDS_2 = null;

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



public class U030B_PART1_EDIT_RECORDS_1 : U030B_PART1
{

    public U030B_PART1_EDIT_RECORDS_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_TAPE_145_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "U030_TAPE_145_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF099_GROUP_CLAIM_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F099_GROUP_CLAIM_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU030_GOOD_145_REC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_GOOD_145_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_UNMATCH = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_UNMATCH", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_GROUP_NBR.GetValue += X_GROUP_NBR_GetValue;
        GOOD_REC.GetValue += GOOD_REC_GetValue;
        X_TYPE.GetValue += X_TYPE_GetValue;
        X_OMA_FOUND.GetValue += X_OMA_FOUND_GetValue;
        X_TECH_AMT.GetValue += X_TECH_AMT_GetValue;
        X_PROF_AMT.GetValue += X_PROF_AMT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART1_EDIT_RECORDS_1)"

    private SqlFileObject fleU030_TAPE_145_FILE;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF099_GROUP_CLAIM_MSTR;
    private DCharacter X_GROUP_NBR = new DCharacter("X_GROUP_NBR", 2);
    private void X_GROUP_NBR_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (fleF002_CLAIMS_MSTR.Exists())
            {
                CurrentValue= QDesign.Substring(fleU030_TAPE_145_FILE.GetStringValue("RAT_145_GROUP_NBR"), 1, 2);
            }
            else if (fleF099_GROUP_CLAIM_MSTR.Exists())
            {
                CurrentValue= QDesign.Substring(fleF099_GROUP_CLAIM_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF099_GROUP_CLAIM_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2), 1, 2);
                //Parent:CLAIM_ID
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
    private DCharacter GOOD_REC = new DCharacter("GOOD_REC", 1);
    private void GOOD_REC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (MatchPattern(fleU030_TAPE_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"), "???#####") & QDesign.NULL(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_OHIP_NBR")) == QDesign.NULL(fleU030_TAPE_145_FILE.GetDecimalValue("RAT_145_DOC_NBR")))
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "N";
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
    private DCharacter X_TYPE = new DCharacter("X_TYPE", 1);
    private void X_TYPE_GetValue(ref string Value)
    {

        try
        {
            Value = "H";


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
    private DCharacter X_OMA_FOUND = new DCharacter("X_OMA_FOUND", 1);
    private void X_OMA_FOUND_GetValue(ref string Value)
    {

        try
        {
            Value = " ";


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
    private DInteger X_TECH_AMT = new DInteger("X_TECH_AMT", 7);
    private void X_TECH_AMT_GetValue(ref decimal Value)
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
    private DInteger X_PROF_AMT = new DInteger("X_PROF_AMT", 7);
    private void X_PROF_AMT_GetValue(ref decimal Value)
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


    private SqlFileObject fleU030_GOOD_145_REC;


    private SqlFileObject fleU030_UNMATCH;


    #endregion


    #region "Standard Generated Procedures(U030B_PART1_EDIT_RECORDS_1)"


    #region "Automatic Item Initialization(U030B_PART1_EDIT_RECORDS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART1_EDIT_RECORDS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:17 PM

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
        fleU030_TAPE_145_FILE.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF099_GROUP_CLAIM_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU030_GOOD_145_REC.Transaction = m_trnTRANS_UPDATE;
        fleU030_UNMATCH.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART1_EDIT_RECORDS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:17 PM

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
            fleU030_TAPE_145_FILE.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF099_GROUP_CLAIM_MSTR.Dispose();
            fleU030_GOOD_145_REC.Dispose();
            fleU030_UNMATCH.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART1_EDIT_RECORDS_1)"


    public void Run()
    {

        try
        {
            Request("EDIT_RECORDS_1");

            while (fleU030_TAPE_145_FILE.QTPForMissing())
            {
                // --> GET U030_TAPE_145_FILE <--

                fleU030_TAPE_145_FILE.GetData();
                // --> End GET U030_TAPE_145_FILE <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_TAPE_145_FILE.GetStringValue("RAT_145_GROUP_NBR"), 1, 2) + QDesign.Substring(fleU030_TAPE_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"), 1, 6)));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_TAPE_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"), 7, 2))));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleU030_TAPE_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR"), 1, 3)));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        while (fleF099_GROUP_CLAIM_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F099_GROUP_CLAIM_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF099_GROUP_CLAIM_MSTR.ElementOwner("ACCOUNTING_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleU030_TAPE_145_FILE.GetStringValue("RAT_145_ACCOUNT_NBR")));

                            fleF099_GROUP_CLAIM_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F099_GROUP_CLAIM_MSTR <--


                            if (Transaction())
                            {


                                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_GOOD_145_REC, QDesign.NULL(GOOD_REC.Value) == "Y", SubFileType.Keep, fleU030_TAPE_145_FILE, X_GROUP_NBR);




                                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_UNMATCH, QDesign.NULL(GOOD_REC.Value) == "N", SubFileType.Keep, fleU030_TAPE_145_FILE, X_GROUP_NBR, X_TYPE, X_OMA_FOUND, X_TECH_AMT, X_PROF_AMT);



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
            EndRequest("EDIT_RECORDS_1");

        }

    }




    #endregion


}
//EDIT_RECORDS_1



public class U030B_PART1_SORT_GOOD_RECORDS_2 : U030B_PART1
{

    public U030B_PART1_SORT_GOOD_RECORDS_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_GOOD_145_REC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_GOOD_145_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU030_SORT_145_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_SORT_145_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U030B_PART1_SORT_GOOD_RECORDS_2)"

    private SqlFileObject fleU030_GOOD_145_REC;


    private SqlFileObject fleU030_SORT_145_FILE;


    #endregion


    #region "Standard Generated Procedures(U030B_PART1_SORT_GOOD_RECORDS_2)"


    #region "Automatic Item Initialization(U030B_PART1_SORT_GOOD_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030B_PART1_SORT_GOOD_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:17 PM

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
        fleU030_GOOD_145_REC.Transaction = m_trnTRANS_UPDATE;
        fleU030_SORT_145_FILE.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030B_PART1_SORT_GOOD_RECORDS_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:07:17 PM

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
            fleU030_GOOD_145_REC.Dispose();
            fleU030_SORT_145_FILE.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030B_PART1_SORT_GOOD_RECORDS_2)"


    public void Run()
    {

        try
        {
            Request("SORT_GOOD_RECORDS_2");

            while (fleU030_GOOD_145_REC.QTPForMissing())
            {
                // --> GET U030_GOOD_145_REC <--

                fleU030_GOOD_145_REC.GetData();
                // --> End GET U030_GOOD_145_REC <--


                if (Transaction())
                {

                    Sort(fleU030_GOOD_145_REC.GetSortValue("X_GROUP_NBR"), fleU030_GOOD_145_REC.GetSortValue("RAT_145_ACCOUNT_NBR"), fleU030_GOOD_145_REC.GetSortValue("RAT_145_EXPLAN_CD", SortType.Descending));



                }

            }


            while (Sort(fleU030_GOOD_145_REC))
            {

                SubFile(ref m_trnTRANS_UPDATE, ref fleU030_SORT_145_FILE, SubFileType.Keep, fleU030_GOOD_145_REC);



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
            EndRequest("SORT_GOOD_RECORDS_2");

        }

    }




    #endregion


}
//SORT_GOOD_RECORDS_2




