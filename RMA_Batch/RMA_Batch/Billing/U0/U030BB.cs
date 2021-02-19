
#region "Screen Comments"

// #> Program-id.     u030bb.qts
// ((C)) Dyad Technologies
// Program Purpose:  - RMA charges doctors for researching and correcting
// claims rejected on the RAT if they can`t be
// automatically adjusted.  An incorrect claim usually has
// an OHIP error code however any claim not fully paid
// can be considered to be in error and requiring work.
// - So that these rejects can be tracked and costed
// this pgm adds the rejected claims to f088-hdr/dtl files.
// For costing purposes only the header is accessed however
// the details can be viewed and the `charge` indicator
// at the header level can be manually changed (m088).
// - The first request updates the f088-hdr record and
// sets a error code or `blank` and a charge status of  NO .
// - The 2nd request updates the f088-dtl records.
// - The 3rd request prompts for the RAT processing date and
// uses this date to select the f088-dtl records for the
// RAT being processed.  The selected detail records are
// filtered based upon `charge/no charge` rules supplied
// by thekla/lori etc.  The chargeable details are extracted
// into a subfile and then used to update the header record
// with a charge status of  Y es and with an OHIP error 
// code that matches the highest valued detail of the claim.
// - NOTE #1: unable to add new request on u030b as too
// many files would be declared so this separate
// program was created.
// MODIFICATION HISTORY
// DATE    WHO    DESCRIPTION
// 2000/jan/21 B.A.   - original
// 2000/mar/10 B.E.   - add new fields to f088, obtain claims`s PED via f002
// 2000/mar/30 M.C.   - change the linkage syntax    
// - add 3 define items and select statement in request
// f088_add_dtl....
// 2001/nov/16 B.E.   - transfer last `request` of u030b into u030bb to 
// reduce complexity/size of u030b
// 2002/sep/09 M.C.   - undo the transfer done on 2001/nov/16 by Brad
// - transfer back the first `request` from u030bb to u030b for
// updating amount in clmhdr
// - u030b_special2.qts has already included this logic of updating
// clmhdr amount.  If u030b_special1/2.qts are run to replace u030b.qts,
// currently update clmhdr amount will be double.
// - comment out the request instead of deleting it                    
// 2003/dec/19 A.A.   - alpha doctor nbr
// 2010/Apr/07 MC1   - use set lock record update
// 2010/04/07 - MC1
// set lock file update


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U030BB : BaseClassControl
{

    private U030BB m_U030BB;

    public U030BB(string Name, int Level) : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_PED = new CoreDecimal("W_PED", 8, this, ResetTypes.ResetAtStartup);


    }

    public U030BB(string Name, int Level, bool Request) : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_PED = new CoreDecimal("W_PED", 8, this, ResetTypes.ResetAtStartup);


    }

    public override void Dispose()
    {
        if ((m_U030BB != null))
        {
            m_U030BB.CloseTransactionObjects();
            m_U030BB = null;
        }
    }

    public U030BB GetU030BB(int Level)
    {
        if (m_U030BB == null)
        {
            m_U030BB = new U030BB("U030BB", Level);
        }
        else
        {
            m_U030BB.ResetValues();
        }
        return m_U030BB;
    }



    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    protected CoreDecimal W_PED;

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();

    protected SqlTransaction m_trnTRANS_UPDATE;


    #endregion


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {


        try
        {

            U030BB_GET_ICONST_CLINIC_VALUES_1 GET_ICONST_CLINIC_VALUES_1 = new U030BB_GET_ICONST_CLINIC_VALUES_1(Name, Level);
            GET_ICONST_CLINIC_VALUES_1.Run();
            GET_ICONST_CLINIC_VALUES_1.Dispose();
            GET_ICONST_CLINIC_VALUES_1 = null;

            U030BB_ADD_HDR_2 ADD_HDR_2 = new U030BB_ADD_HDR_2(Name, Level);
            ADD_HDR_2.Run();
            ADD_HDR_2.Dispose();
            ADD_HDR_2 = null;

            U030BB_ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3 ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3 = new U030BB_ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3(Name, Level);
            ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3.Run();
            ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3.Dispose();
            ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3 = null;

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



public class U030BB_GET_ICONST_CLINIC_VALUES_1 : U030BB
{

    public U030BB_GET_ICONST_CLINIC_VALUES_1(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        W_PED = new CoreDecimal("W_PED", 8, this, ResetTypes.ResetAtStartup);
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "ICONST_MSTR_REC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC.Choose += fleICONST_MSTR_REC_Choose;

    }


    #region "Declarations (Variables, Files and Transactions)(U030BB_GET_ICONST_CLINIC_VALUES_1)"

    protected CoreDecimal W_PED;
    private SqlFileObject fleICONST_MSTR_REC;
    private void fleICONST_MSTR_REC_Choose(ref string ChooseClause)
    {

        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
            strSQL.Append(Prompt(1).ToString());


            ChooseClause = strSQL.ToString();


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


    #region "Standard Generated Procedures(U030BB_GET_ICONST_CLINIC_VALUES_1)"


    #region "Automatic Item Initialization(U030BB_GET_ICONST_CLINIC_VALUES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U030BB_GET_ICONST_CLINIC_VALUES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:42 PM

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
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030BB_GET_ICONST_CLINIC_VALUES_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:42 PM

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
            fleICONST_MSTR_REC.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030BB_GET_ICONST_CLINIC_VALUES_1)"


    public void Run()
    {

        try
        {
            Request("GET_ICONST_CLINIC_VALUES_1");

            while (fleICONST_MSTR_REC.QTPForMissing())
            {
                // --> GET ICONST_MSTR_REC <--

                fleICONST_MSTR_REC.GetData();
                // --> End GET ICONST_MSTR_REC <--


                if (Transaction())
                {
                    if (AtFinal())
                    {
                        W_PED.Value = Convert.ToInt64(fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_YY").ToString().PadLeft(4, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_MM").ToString().PadLeft(2, '0')
                            + fleICONST_MSTR_REC.GetDecimalValue("ICONST_DATE_PERIOD_END_DD").ToString().PadLeft(2, '0'));
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
            EndRequest("GET_ICONST_CLINIC_VALUES_1");

        }

    }







    #endregion


}
//GET_ICONST_CLINIC_VALUES_1



public class U030BB_ADD_HDR_2 : U030BB
{

    public U030BB_ADD_HDR_2(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_NO_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_NO_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePART_PAID_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF088_HDR_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_HDR", "F088_HDR_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        NOT_CHARGED.GetValue += NOT_CHARGED_GetValue;
        CHARGED.GetValue += CHARGED_GetValue;
        CANCELLED.GetValue += CANCELLED_GetValue;
        fleF088_HDR_ADD.SetItemFinals += fleF088_HDR_ADD_SetItemFinals;
        fleF088_HDR_ADD.InitializeItems += fleF088_HDR_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U030BB_ADD_HDR_2)"

    private SqlFileObject fleU030_NO_ADJ;
    private SqlFileObject flePART_PAID_HDR;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private DCharacter NOT_CHARGED = new DCharacter("NOT_CHARGED", 1);
    private void NOT_CHARGED_GetValue(ref string Value)
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
    private DCharacter CHARGED = new DCharacter("CHARGED", 1);
    private void CHARGED_GetValue(ref string Value)
    {

        try
        {
            Value = "Y";


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
    private DCharacter CANCELLED = new DCharacter("CANCELLED", 1);
    private void CANCELLED_GetValue(ref string Value)
    {

        try
        {
            Value = "C";


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
    private SqlFileObject fleF088_HDR_ADD;

    private void fleF088_HDR_ADD_SetItemFinals()
    {

        try
        {
            fleF088_HDR_ADD.set_SetValue("CLMHDR_BATCH_NBR", QDesign.Substring(QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR"), 1, 8));
            //Parent:PART_HDR_CLAIM_ID
            fleF088_HDR_ADD.set_SetValue("CLMHDR_CLAIM_NBR", QDesign.NConvert(QDesign.Substring(QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR"), 9, 2)));
            //Parent:PART_HDR_CLAIM_ID
            fleF088_HDR_ADD.set_SetValue("CLMHDR_DOC_NBR", QDesign.Substring(QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR"), 3, 3));
            //Parent:PART_HDR_CLAIM_ID
            fleF088_HDR_ADD.set_SetValue("PART_HDR_AMT_BILL", fleU030_NO_ADJ.GetDecimalValue("PART_HDR_AMT_BILL"));
            fleF088_HDR_ADD.set_SetValue("PART_HDR_AMT_PAID", fleU030_NO_ADJ.GetDecimalValue("PART_HDR_AMT_PAID"));
            fleF088_HDR_ADD.set_SetValue("OHIP_ERR_CODE", " ");
            fleF088_HDR_ADD.set_SetValue("CHARGE_STATUS", NOT_CHARGED.Value);
            fleF088_HDR_ADD.set_SetValue("PED", W_PED.Value);
            fleF088_HDR_ADD.set_SetValue("CLMHDR_DATE_PERIOD_END", fleF002_CLAIMS_MSTR.GetNumericDateValue("CLMHDR_DATE_PERIOD_END"));
            fleF088_HDR_ADD.set_SetValue("CLMHDR_SERV_DATE", flePART_PAID_HDR.GetNumericDateValue("PART_HDR_SERV_DATE"));
            fleF088_HDR_ADD.set_SetValue("ENTRY_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF088_HDR_ADD.set_SetValue("ENTRY_TIME_LONG", QDesign.SysTime(ref m_cnnQUERY));
            fleF088_HDR_ADD.set_SetValue("ENTRY_USER_ID", "u030bb");


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


    #region "Standard Generated Procedures(U030BB_ADD_HDR_2)"


    #region "Automatic Item Initialization(U030BB_ADD_HDR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:44 PM

    //#-----------------------------------------
    //# fleF088_HDR_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:06:44 PM
    //#-----------------------------------------
    private void fleF088_HDR_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF088_HDR_ADD.set_SetValue("PART_HDR_AMT_BILL", !Fixed, flePART_PAID_HDR.GetDecimalValue("PART_HDR_AMT_BILL"));
            fleF088_HDR_ADD.set_SetValue("PART_HDR_AMT_PAID", !Fixed, flePART_PAID_HDR.GetDecimalValue("PART_HDR_AMT_PAID"));

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


    #region "Transaction Management Procedures(U030BB_ADD_HDR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:42 PM

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
        flePART_PAID_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF088_HDR_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030BB_ADD_HDR_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:42 PM

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
            flePART_PAID_HDR.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF088_HDR_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030BB_ADD_HDR_2)"


    public void Run()
    {

        try
        {
            Request("ADD_HDR_2");

            while (fleU030_NO_ADJ.QTPForMissing())
            {
                // --> GET U030_NO_ADJ <--

                fleU030_NO_ADJ.GetData();
                // --> End GET U030_NO_ADJ <--

                while (flePART_PAID_HDR.QTPForMissing("1"))
                {
                    // --> GET PART_PAID_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(flePART_PAID_HDR.ElementOwner("PART_HDR_CLINIC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleU030_NO_ADJ.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + fleU030_NO_ADJ.GetStringValue("PART_HDR_CLAIM_NBR")).PadRight(10).Substring(0, 2)));
                    //Parent:PART_HDR_CLAIM_ID    'Parent:PART_HDR_CLAIM_ID
                    m_strWhere.Append(" AND ").Append(" ").Append(flePART_PAID_HDR.ElementOwner("PART_HDR_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((QDesign.ASCII(fleU030_NO_ADJ.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + fleU030_NO_ADJ.GetStringValue("PART_HDR_CLAIM_NBR")).PadRight(10).Substring(2, 8)));
                    //Parent:PART_HDR_CLAIM_ID    'Parent:PART_HDR_CLAIM_ID

                    flePART_PAID_HDR.GetData(m_strWhere.ToString());
                    // --> End GET PART_PAID_HDR <--

                    while (fleF002_CLAIMS_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((QDesign.Substring(QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR"), 1, 8))));
                        //Parent:PART_HDR_CLAIM_ID
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(QDesign.Substring(QDesign.ASCII(flePART_PAID_HDR.GetDecimalValue("PART_HDR_CLINIC_NBR"), 2) + flePART_PAID_HDR.GetStringValue("PART_HDR_CLAIM_NBR"), 9, 2))));
                        //Parent:PART_HDR_CLAIM_ID
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("00000"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("0"));

                        fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F002_CLAIMS_MSTR <--


                        if (Transaction())
                        {




                            fleF088_HDR_ADD.OutPut(OutPutType.Add);


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
            EndRequest("ADD_HDR_2");

        }

    }




    #endregion


}
//ADD_HDR_2



public class U030BB_ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3 : U030BB
{

    public U030BB_ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU030_NO_ADJ = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U030_NO_ADJ", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePART_PAID_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "PART_PAID_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.TempFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF088_DTL_ADD = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F088_RAT_REJECTED_CLAIMS_HIST_DTL", "F088_DTL_ADD", false, false, false, 0, "m_trnTRANS_UPDATE");

        CONSEC_DATE_1.GetValue += CONSEC_DATE_1_GetValue;
        CONSEC_DATE_2.GetValue += CONSEC_DATE_2_GetValue;
        CONSEC_DATE_3.GetValue += CONSEC_DATE_3_GetValue;
        fleF088_DTL_ADD.SetItemFinals += fleF088_DTL_ADD_SetItemFinals;
        fleF088_DTL_ADD.InitializeItems += fleF088_DTL_ADD_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U030BB_ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3)"

    private SqlFileObject fleU030_NO_ADJ;
    private SqlFileObject flePART_PAID_DTL;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private DDecimal CONSEC_DATE_1 = new DDecimal("CONSEC_DATE_1");
    private void CONSEC_DATE_1_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2))) != 0)
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 2, 2));

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
    private DDecimal CONSEC_DATE_2 = new DDecimal("CONSEC_DATE_2");
    private void CONSEC_DATE_2_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 5, 2))) != 0)
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 5, 2));

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
    private DDecimal CONSEC_DATE_3 = new DDecimal("CONSEC_DATE_3");
    private void CONSEC_DATE_3_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 8, 2))) != 0)
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 8, 2));

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

    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(flePART_PAID_DTL.GetNumericDateValue("PART_DTL_SERV_DATE")) == QDesign.NULL(QDesign.NConvert(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2))) | QDesign.NULL(flePART_PAID_DTL.GetNumericDateValue("PART_DTL_SERV_DATE")) == QDesign.NULL(CONSEC_DATE_1.Value) | QDesign.NULL(flePART_PAID_DTL.GetNumericDateValue("PART_DTL_SERV_DATE")) == QDesign.NULL(CONSEC_DATE_2.Value) | QDesign.NULL(flePART_PAID_DTL.GetNumericDateValue("PART_DTL_SERV_DATE")) == QDesign.NULL(CONSEC_DATE_3.Value))
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

    private SqlFileObject fleF088_DTL_ADD;

    private void fleF088_DTL_ADD_SetItemFinals()
    {

        try
        {
            fleF088_DTL_ADD.set_SetValue("CLMHDR_BATCH_NBR", QDesign.Substring(QDesign.ASCII(flePART_PAID_DTL.GetDecimalValue("PART_DTL_CLINIC_NBR"), 2) + flePART_PAID_DTL.GetStringValue("PART_DTL_CLAIM_NBR") + flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD"), 1, 8));
            //Parent:PART_DTL_CLAIM_ID
            fleF088_DTL_ADD.set_SetValue("CLMHDR_CLAIM_NBR", QDesign.NConvert(QDesign.Substring(QDesign.ASCII(flePART_PAID_DTL.GetDecimalValue("PART_DTL_CLINIC_NBR"), 2) + flePART_PAID_DTL.GetStringValue("PART_DTL_CLAIM_NBR") + flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD"), 9, 2)));
            //Parent:PART_DTL_CLAIM_ID
            fleF088_DTL_ADD.set_SetValue("CLMHDR_ADJ_OMA_CD", QDesign.Substring(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD"), 1, 4));
            fleF088_DTL_ADD.set_SetValue("CLMHDR_ADJ_OMA_SUFF", QDesign.Substring(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD"), 5, 1));
            fleF088_DTL_ADD.set_SetValue("CLMHDR_ADJ_ADJ_NBR", "0");
            fleF088_DTL_ADD.set_SetValue("PED", W_PED.Value);
            fleF088_DTL_ADD.set_SetValue("OHIP_ERR_CODE", flePART_PAID_DTL.GetStringValue("PART_DTL_EXPLAN_CD"));
            fleF088_DTL_ADD.set_SetValue("PART_DTL_AMT_PAID", flePART_PAID_DTL.GetDecimalValue("PART_DTL_AMT_PAID"));
            fleF088_DTL_ADD.set_SetValue("PART_DTL_AMT_BILL", flePART_PAID_DTL.GetDecimalValue("PART_DTL_AMT_BILL"));
            fleF088_DTL_ADD.set_SetValue("AUTO_ADJ_FLAG", "N");
            fleF088_DTL_ADD.set_SetValue("CLMHDR_DOC_NBR", QDesign.Substring(QDesign.ASCII(flePART_PAID_DTL.GetDecimalValue("PART_DTL_CLINIC_NBR"), 2) + flePART_PAID_DTL.GetStringValue("PART_DTL_CLAIM_NBR") + flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD"), 3, 3));
            //Parent:PART_DTL_CLAIM_ID
            fleF088_DTL_ADD.set_SetValue("CLMDTL_DATE_PERIOD_END", fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_DATE_PERIOD_END"));
            fleF088_DTL_ADD.set_SetValue("CLMDTL_SV_DATE", QDesign.ASCII(flePART_PAID_DTL.GetNumericDateValue("PART_DTL_SERV_DATE"), 8));
            fleF088_DTL_ADD.set_SetValue("ENTRY_DATE", QDesign.SysDate(ref m_cnnQUERY));
            fleF088_DTL_ADD.set_SetValue("ENTRY_TIME_LONG", QDesign.SysTime(ref m_cnnQUERY));
            fleF088_DTL_ADD.set_SetValue("ENTRY_USER_ID", "u030bb");


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


    #region "Standard Generated Procedures(U030BB_ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3)"


    #region "Automatic Item Initialization(U030BB_ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:46 PM

    //#-----------------------------------------
    //# fleF088_DTL_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:06:46 PM
    //#-----------------------------------------
    private void fleF088_DTL_ADD_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            //fleF088_DTL_ADD.set_SetValue("PART_DTL_AMT_BILL", !Fixed, flePART_PAID_DTL.GetDecimalValue("PART_DTL_AMT_BILL"));
            //fleF088_DTL_ADD.set_SetValue("PART_DTL_AMT_PAID", !Fixed, flePART_PAID_DTL.GetDecimalValue("PART_DTL_AMT_PAID"));

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


    #region "Transaction Management Procedures(U030BB_ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:42 PM

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
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF088_DTL_ADD.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U030BB_ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:42 PM

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
            fleF002_CLAIMS_MSTR.Dispose();
            fleF088_DTL_ADD.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U030BB_ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3)"


    public void Run()
    {

        try
        {
            Request("ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3");

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

                    while (fleF002_CLAIMS_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((QDesign.Substring(fleU030_NO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 1, 8))));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((QDesign.NConvert(QDesign.Substring(fleU030_NO_ADJ.GetStringValue("PART_HDR_CLAIM_ID"), 9, 2))));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(QDesign.Substring(flePART_PAID_DTL.GetStringValue("PART_DTL_OMA_CD"), 1, 5)));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("0"));

                        fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F002_CLAIMS_MSTR <--


                        if (Transaction())
                        {

                            if (Select_If())
                            {





                                fleF088_DTL_ADD.OutPut(OutPutType.Add);


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
            EndRequest("ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3");

        }

    }




    #endregion


}
//ADD_DTL_IGNORE_DUPLICATE_KEY_ERROR_3




