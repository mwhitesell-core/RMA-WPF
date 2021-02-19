
#region "Screen Comments"

// #> PROGRAM-ID.     U035A.QTS
// ((C)) Dyad Technologies
// PROGRAM PURPOSE : To print the direct bill invoices
// This pgm is the first series of the 3 pgms     
// MODIFICATION HISTORY
// DATE   WHO          DESCRIPTION
// 2001/MAR/27 M.C.         - ORIGINAL (convert from u035a/b/c.cbl)
// 2003/jan/21 yas            include clmhdr-doc-dept in subfiles
// 2003/dec/23 A.A.      - alpha doctor nbr
// 2005/jan/27 M.C.      - add clmhdr-doc-dept in the sort statement,
// this will calculate the balance due properly for patient`s
// claims under each compnay
// 2007/mar/05 M.C.      - substitute clmhdr-doc-dept with dept-company instead,
// access to f070-dept-mstr to retrieve  dept-company
// this will calculate the balance due properly for patient`s
// claims under each compnay
// 2007/Jul/04 M.C.      - change to set lock record update
// 2008/apr/03 M.C.      - include x-pat-dtl-counter in u035dtl_totalled of the final request 
// 2012/Jan/23 MC1      - realize that subdivision & ikey could have changed in f002-claims-mstr after creation
// in f002-claim-shadow, so use the update info from f002-claims-mstr instead of shadow file
// when creating direct invoices
// 2007/07/04 - MC
// set lock file update
// 2007/07/04 - end


#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;



public class U035A : BaseClassControl
{

    private U035A m_U035A;

    public U035A(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public U035A(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;


    }

    public override void Dispose()
    {
        if ((m_U035A != null))
        {
            m_U035A.CloseTransactionObjects();
            m_U035A = null;
        }
    }

    public U035A GetU035A(int Level)
    {
        if (m_U035A == null)
        {
            m_U035A = new U035A("U035A", Level);
        }
        else
        {
            m_U035A.ResetValues();
        }
        return m_U035A;
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

            U035A_EXTRACT_1 EXTRACT_1 = new U035A_EXTRACT_1(Name, Level);
            EXTRACT_1.Run();
            EXTRACT_1.Dispose();
            EXTRACT_1 = null;

            U035A_SORT_2 SORT_2 = new U035A_SORT_2(Name, Level);
            SORT_2.Run();
            SORT_2.Dispose();
            SORT_2 = null;

            U035A_EXTRACT_CLM_DTL_3 EXTRACT_CLM_DTL_3 = new U035A_EXTRACT_CLM_DTL_3(Name, Level);
            EXTRACT_CLM_DTL_3.Run();
            EXTRACT_CLM_DTL_3.Dispose();
            EXTRACT_CLM_DTL_3 = null;

            U035A_EXTRACT_CLM_DESC_4 EXTRACT_CLM_DESC_4 = new U035A_EXTRACT_CLM_DESC_4(Name, Level);
            EXTRACT_CLM_DESC_4.Run();
            EXTRACT_CLM_DESC_4.Dispose();
            EXTRACT_CLM_DESC_4 = null;

            U035A_EXTRACT_CLM_MSGS_5 EXTRACT_CLM_MSGS_5 = new U035A_EXTRACT_CLM_MSGS_5(Name, Level);
            EXTRACT_CLM_MSGS_5.Run();
            EXTRACT_CLM_MSGS_5.Dispose();
            EXTRACT_CLM_MSGS_5 = null;

            U035A_CALCULATE_RUNNING_TOTALS_6 CALCULATE_RUNNING_TOTALS_6 = new U035A_CALCULATE_RUNNING_TOTALS_6(Name, Level);
            CALCULATE_RUNNING_TOTALS_6.Run();
            CALCULATE_RUNNING_TOTALS_6.Dispose();
            CALCULATE_RUNNING_TOTALS_6 = null;

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



public class U035A_EXTRACT_1 : U035A
{

    public U035A_EXTRACT_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIM_SHADOW = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIM_SHADOW", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF070_DEPT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F070_DEPT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU035A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleRU035A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "RU035A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_BAL_DUE.GetValue += X_BAL_DUE_GetValue;
        fleF070_DEPT_MSTR.InitializeItems += fleF070_DEPT_MSTR_AutomaticItemInitialization;

    }


    #region "Declarations (Variables, Files and Transactions)(U035A_EXTRACT_1)"

    private SqlFileObject fleF002_CLAIM_SHADOW;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleF070_DEPT_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private DDecimal X_BAL_DUE = new DDecimal("X_BAL_DUE", 8);
    private void X_BAL_DUE_GetValue(ref decimal Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OMA") + fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS");


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











    private SqlFileObject fleU035A;











    private SqlFileObject fleRU035A;


    #endregion


    #region "Standard Generated Procedures(U035A_EXTRACT_1)"


    #region "Automatic Item Initialization(U035A_EXTRACT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:10 PM

    //#-----------------------------------------
    //# fleF070_DEPT_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:06:05 PM
    //#-----------------------------------------
    private void fleF070_DEPT_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            //TODO: Manual steps may be required.
            fleF070_DEPT_MSTR.set_SetValue("FILLER", !Fixed, fleF010_PAT_MSTR.GetStringValue("FILLER"));

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


    #region "Transaction Management Procedures(U035A_EXTRACT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:03 PM

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
        fleF002_CLAIM_SHADOW.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF070_DEPT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU035A.Transaction = m_trnTRANS_UPDATE;
        fleRU035A.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U035A_EXTRACT_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
            fleF002_CLAIM_SHADOW.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleF070_DEPT_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleU035A.Dispose();
            fleRU035A.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U035A_EXTRACT_1)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_1");

            while (fleF002_CLAIM_SHADOW.QTPForMissing())
            {
                // --> GET F002_CLAIM_SHADOW <--

                fleF002_CLAIM_SHADOW.GetData();
                // --> End GET F002_CLAIM_SHADOW <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_CLAIM_SHADOW.GetStringValue("CLM_SHADOW_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleF002_CLAIM_SHADOW.GetDecimalValue("CLM_SHADOW_CLAIM_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("00000"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("0"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleF010_PAT_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F010_PAT_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                        //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                        m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                        //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                        m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                        //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                        m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));
                        //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

                        fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F010_PAT_MSTR <--

                        while (fleF070_DEPT_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F070_DEPT_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF070_DEPT_MSTR.ElementOwner("DEPT_NBR")).Append(" = ");
                            m_strWhere.Append((fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_DOC_DEPT")));

                            fleF070_DEPT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F070_DEPT_MSTR <--

                            while (fleF020_DOCTOR_MSTR.QTPForMissing("4"))
                            {
                                // --> GET F020_DOCTOR_MSTR <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField((QDesign.Substring(fleF002_CLAIM_SHADOW.GetStringValue("CLM_SHADOW_BATCH_NBR"), 3, 3))));

                                fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F020_DOCTOR_MSTR <--


                                if (Transaction())
                                {






                                    SubFile(ref m_trnTRANS_UPDATE, ref fleU035A, fleF010_PAT_MSTR.Exists() & fleF002_CLAIMS_MSTR.Exists() & QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_AGENT_CD")) != 4 & QDesign.NULL(X_BAL_DUE.Value) > 64 & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_REPRINT_FLAG")) == "Y", SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMHDR_AGENT_CD", "CLMHDR_AGENT_CD", fleF070_DEPT_MSTR, "DEPT_COMPANY", fleF002_CLAIM_SHADOW,
                                    "CLM_SHADOW_CLINIC", fleF002_CLAIMS_MSTR, "CLMHDR_SUB_NBR", fleF010_PAT_MSTR, "PAT_SURNAME", "PAT_GIVEN_NAME", fleF002_CLAIMS_MSTR, "CLMHDR_PAT_OHIP_ID_OR_CHART", fleF002_CLAIM_SHADOW, "CLM_SHADOW_BATCH_NBR",
                                    "CLM_SHADOW_CLAIM_NBR", fleF002_CLAIMS_MSTR, "CLMHDR_MSG_NBR", "CLMHDR_HOSP", "CLMHDR_FEE_COMPLEX", "CLMHDR_DATE_SYS", fleF010_PAT_MSTR, "SUBSCR_MSG_NBR", "SUBSCR_ADDR1", "SUBSCR_ADDR2",
                                    "SUBSCR_ADDR3", "SUBSCR_POSTAL_CD", "PAT_COUNTRY", "PAT_OHIP_MMYY", fleF020_DOCTOR_MSTR, "DOC_NAME");








                                    SubFile(ref m_trnTRANS_UPDATE, ref fleRU035A, !fleF010_PAT_MSTR.Exists() | !fleF002_CLAIMS_MSTR.Exists(), SubFileType.Keep, fleF002_CLAIMS_MSTR, "CLMHDR_AGENT_CD", "CLMHDR_AGENT_CD", fleF070_DEPT_MSTR, "DEPT_COMPANY", fleF002_CLAIM_SHADOW,
                                    "CLM_SHADOW_CLINIC", "CLM_SHADOW_SUBDIVISION", fleF002_CLAIMS_MSTR, "CLMHDR_PAT_OHIP_ID_OR_CHART", fleF002_CLAIM_SHADOW, "CLM_SHADOW_BATCH_NBR", "CLM_SHADOW_CLAIM_NBR");



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
            EndRequest("EXTRACT_1");

        }

    }




    #endregion


}
//EXTRACT_1



public class U035A_SORT_2 : U035A
{

    public U035A_SORT_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU035A = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU035B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU035BB = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035BB", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U035A_SORT_2)"

    private SqlFileObject fleU035A;











    private SqlFileObject fleU035B;











    private SqlFileObject fleU035BB;


    #endregion


    #region "Standard Generated Procedures(U035A_SORT_2)"


    #region "Automatic Item Initialization(U035A_SORT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U035A_SORT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
        fleU035A.Transaction = m_trnTRANS_UPDATE;
        fleU035B.Transaction = m_trnTRANS_UPDATE;
        fleU035BB.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U035A_SORT_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
            fleU035A.Dispose();
            fleU035B.Dispose();
            fleU035BB.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U035A_SORT_2)"


    public void Run()
    {

        try
        {
            Request("SORT_2");

            while (fleU035A.QTPForMissing())
            {
                // --> GET U035A <--

                fleU035A.GetData();
                // --> End GET U035A <--


                if (Transaction())
                {

                    Sort(fleU035A.GetSortValue("CLMHDR_AGENT_CD"), fleU035A.GetSortValue("CLM_SHADOW_CLINIC"), fleU035A.GetSortValue("CLMHDR_SUB_NBR"), fleU035A.GetSortValue("PAT_SURNAME"), fleU035A.GetSortValue("PAT_GIVEN_NAME"), fleU035A.GetSortValue("DEPT_COMPANY"), fleU035A.GetSortValue("CLMHDR_PAT_OHIP_ID_OR_CHART"), fleU035A.GetSortValue("CLM_SHADOW_BATCH_NBR"), fleU035A.GetSortValue("CLM_SHADOW_CLAIM_NBR"));


                }

            }


            while (Sort(fleU035A))
            {










                SubFile(ref m_trnTRANS_UPDATE, ref fleU035B, SubFileType.Keep, fleU035A);













                SubFile(ref m_trnTRANS_UPDATE, ref fleU035BB, fleU035A.At("CLMHDR_AGENT_CD") || fleU035A.At("CLM_SHADOW_CLINIC") || fleU035A.At("CLMHDR_SUB_NBR") || fleU035A.At("PAT_SURNAME") || fleU035A.At("PAT_GIVEN_NAME") || fleU035A.At("DEPT_COMPANY") || fleU035A.At("CLMHDR_PAT_OHIP_ID_OR_CHART"), SubFileType.Keep, fleU035A);



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
            EndRequest("SORT_2");

        }

    }




    #endregion


}
//SORT_2



public class U035A_EXTRACT_CLM_DTL_3 : U035A
{

    public U035A_EXTRACT_CLM_DTL_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU035B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CLAIM_REC_COUNTER = new CoreDecimal("X_CLAIM_REC_COUNTER", 6, this);
        fleU035DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU035PAY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035PAY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_SERV_DATE.GetValue += X_SERV_DATE_GetValue;
        X_NBR_SERV.GetValue += X_NBR_SERV_GetValue;
        X_CLAIM_NO.GetValue += X_CLAIM_NO_GetValue;
        X_OHIP_CD.GetValue += X_OHIP_CD_GetValue;
        X_DOC_NAME.GetValue += X_DOC_NAME_GetValue;
        X_HOSP.GetValue += X_HOSP_GetValue;
        X_DESC.GetValue += X_DESC_GetValue;
        X_CHARGE.GetValue += X_CHARGE_GetValue;
        X_CREDIT.GetValue += X_CREDIT_GetValue;
        X_TYPE.GetValue += X_TYPE_GetValue;
        X_PAT.GetValue += X_PAT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U035A_EXTRACT_CLM_DTL_3)"

    private SqlFileObject fleU035B;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    private SqlFileObject fleF040_OMA_FEE_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "0000" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) != "ZZZZ")
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

    private DDecimal X_SERV_DATE = new DDecimal("X_SERV_DATE");
    private void X_SERV_DATE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "A" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "B" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "C")
            {
                CurrentValue = QDesign.NConvert(fleU035B.GetStringValue("CLMHDR_DATE_SYS"));
            }
            else
            {
                CurrentValue = QDesign.NConvert(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2));

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
            decimal CurrentValue = 0m;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == QDesign.NULL(" "))
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV");
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
    private DCharacter X_CLAIM_NO = new DCharacter("X_CLAIM_NO", 10);
    private void X_CLAIM_NO_GetValue(ref string Value)
    {

        try
        {
            Value = QDesign.Substring(fleU035B.GetStringValue("CLM_SHADOW_BATCH_NBR"), 1, 8) + QDesign.ASCII(fleU035B.GetDecimalValue("CLM_SHADOW_CLAIM_NBR"), 2);


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
    private DCharacter X_OHIP_CD = new DCharacter("X_OHIP_CD", 5);
    private void X_OHIP_CD_GetValue(ref string Value)
    {

        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF");


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
    private DCharacter X_DOC_NAME = new DCharacter("X_DOC_NAME", 24);
    private void X_DOC_NAME_GetValue(ref string Value)
    {

        try
        {
            Value = fleU035B.GetStringValue("DOC_NAME");


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
    private DCharacter X_HOSP = new DCharacter("X_HOSP", 1);
    private void X_HOSP_GetValue(ref string Value)
    {

        try
        {
            Value = fleU035B.GetStringValue("CLMHDR_HOSP");


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
    private DCharacter X_DESC = new DCharacter("X_DESC", 47);
    private void X_DESC_GetValue(ref string Value)
    {

        try
        {
            string CurrentValue = string.Empty;
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "H110" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "H106")
            {
                CurrentValue = "OFF HOUR VISIT PREMIUM";
            }
            else if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "C" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OMA")) < 0)
            {
                CurrentValue = "PAYMENT - THANK YOU";
            }
            else if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "C")
            {
                CurrentValue = "PAYMENT REVERSAL - EXPLANATION ENCLOSED";
            }
            else if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "A" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "B")
            {
                CurrentValue = "ADJUSTMENT";
            }
            else if (QDesign.NULL(fleU035B.GetStringValue("CLMHDR_FEE_COMPLEX")) == "H")
            {
                CurrentValue = fleF040_OMA_FEE_MSTR.GetStringValue("FEE_DESC");
            }
            else if (QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "NM" | QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "PF" | QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "DR" | QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "DU" | ((QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "CP" | QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "DT") & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF")) == "A"))
            {
                CurrentValue = "PROCEDURE";
            }
            else if (((QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "CP" | QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "DT" | QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "SP") & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF")) == "C"))
            {
                CurrentValue = "ANAESTHESIA";
            }
            else if (QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "SP" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF")) == "B")
            {
                CurrentValue = "ASSISTING";
            }
            else if (QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "SP" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF")) == "A")
            {
                CurrentValue = "SURGICAL PROCEDURE";
            }
            else if (QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC") + QDesign.ASCII(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_ICC_CAT"), 1) + QDesign.ASCII(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_ICC_GRP"), 2) + QDesign.ASCII(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_ICC_REDUC_IND"), 1)) == "SP0447" & QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF")) == "A")
            {
                CurrentValue = "OBSTETRICS";
            }
            else if (QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "CV")
            {
                CurrentValue = "VISITS";
            }
            else if (QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_ICC_SEC")) == "LM")
            {
                CurrentValue = "LAB WORK";
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
    private DDecimal X_CHARGE = new DDecimal("X_CHARGE", 8);
    private void X_CHARGE_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (((QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "A" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "B" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "C") & QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OMA")) > 0) | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == QDesign.NULL(" "))
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
    private DDecimal X_CREDIT = new DDecimal("X_CREDIT", 8);
    private void X_CREDIT_GetValue(ref decimal Value)
    {

        try
        {
            decimal CurrentValue = 0m;
            if (((QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "A" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "B" | QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "C") & QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OMA")) < 0))
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
    private DDecimal X_TYPE = new DDecimal("X_TYPE", 1);
    private void X_TYPE_GetValue(ref decimal Value)
    {

        try
        {
            Value = 1;


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
    private DDecimal X_PAT = new DDecimal("X_PAT", 1);
    private void X_PAT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 1;


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

    private CoreDecimal X_CLAIM_REC_COUNTER;










    private SqlFileObject fleU035DTL;











    private SqlFileObject fleU035PAY;


    #endregion


    #region "Standard Generated Procedures(U035A_EXTRACT_CLM_DTL_3)"


    #region "Automatic Item Initialization(U035A_EXTRACT_CLM_DTL_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U035A_EXTRACT_CLM_DTL_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
        fleU035B.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleU035DTL.Transaction = m_trnTRANS_UPDATE;
        fleU035PAY.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U035A_EXTRACT_CLM_DTL_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
            fleU035B.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleF040_OMA_FEE_MSTR.Dispose();
            fleU035DTL.Dispose();
            fleU035PAY.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U035A_EXTRACT_CLM_DTL_3)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_CLM_DTL_3");

            while (fleU035B.QTPForMissing())
            {
                // --> GET U035B <--

                fleU035B.GetData();
                // --> End GET U035B <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU035B.GetStringValue("CLM_SHADOW_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleU035B.GetDecimalValue("CLM_SHADOW_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    while (fleF040_OMA_FEE_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F040_OMA_FEE_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(0, 1)));

                        m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(1, 1)));


                        fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F040_OMA_FEE_MSTR <--


                        if (Transaction())
                        {

                             if (Select_If())
                            {

                                Sort(fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_AGENT_CD"), fleU035B.GetSortValue("CLM_SHADOW_CLINIC"), fleU035B.GetSortValue("CLMHDR_SUB_NBR"), fleU035B.GetSortValue("PAT_SURNAME"), fleU035B.GetSortValue("PAT_GIVEN_NAME"), fleU035B.GetSortValue("DEPT_COMPANY"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_PAT_KEY_TYPE"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_PAT_KEY_DATA"), fleU035B.GetSortValue("CLM_SHADOW_BATCH_NBR"), fleU035B.GetSortValue("CLM_SHADOW_CLAIM_NBR"));
                                //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART



                            }

                        }

                    }

                }

            }

            while (Sort(fleU035B, fleF002_CLAIMS_MSTR, fleF040_OMA_FEE_MSTR))
            {
                X_CLAIM_REC_COUNTER.Value = X_CLAIM_REC_COUNTER.Value + 1;




                SubFile(ref m_trnTRANS_UPDATE, ref fleU035DTL, SubFileType.Keep, fleU035B, "CLMHDR_AGENT_CD", "DEPT_COMPANY", "CLM_SHADOW_CLINIC", "CLMHDR_SUB_NBR", "PAT_SURNAME", "PAT_GIVEN_NAME",
                "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLM_SHADOW_BATCH_NBR", "CLM_SHADOW_CLAIM_NBR", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POSTAL_CD", "PAT_COUNTRY", "PAT_OHIP_MMYY", X_SERV_DATE,
                X_NBR_SERV, X_CLAIM_NO, X_CLAIM_REC_COUNTER, X_OHIP_CD, X_DOC_NAME, X_HOSP, X_DESC, X_CHARGE, X_CREDIT, X_TYPE,
                X_PAT);





                SubFile(ref m_trnTRANS_UPDATE, ref fleU035PAY, QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_ADJ_CD")) == "C", SubFileType.Keep, fleU035B, "CLM_SHADOW_BATCH_NBR", "CLM_SHADOW_CLAIM_NBR");



                Reset(ref X_CLAIM_REC_COUNTER, fleF002_CLAIMS_MSTR.At("CLMHDR_AGENT_CD") || fleU035B.At("CLM_SHADOW_CLINIC") || fleU035B.At("CLMHDR_SUB_NBR") || fleU035B.At("PAT_SURNAME") || fleU035B.At("PAT_GIVEN_NAME") || fleU035B.At("DEPT_COMPANY") || fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_OHIP_ID_OR_CHART") || fleU035B.At("CLM_SHADOW_BATCH_NBR") || fleU035B.At("CLM_SHADOW_CLAIM_NBR"));

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
            EndRequest("EXTRACT_CLM_DTL_3");

        }

    }




    #endregion


}
//EXTRACT_CLM_DTL_3



public class U035A_EXTRACT_CLM_DESC_4 : U035A
{

    public U035A_EXTRACT_CLM_DESC_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU035B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CLAIM_REC_CTR = new CoreDecimal("X_CLAIM_REC_CTR", 6, this);
        X_CLAIM_REC_COUNTER = new CoreDecimal("X_CLAIM_REC_COUNTER", 6, this);
        X_DESC_REC_COUNTER = new CoreDecimal("X_DESC_REC_COUNTER", 6, this);
        X_DESC12 = new CoreCharacter("X_DESC12", 47, this, Common.cEmptyString);
        X_DESC34 = new CoreCharacter("X_DESC34", 47, this, Common.cEmptyString);
        X_DESC5 = new CoreCharacter("X_DESC5", 47, this, Common.cEmptyString);
        fleDESC12 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035DTL", "DESC12", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDESC34 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035DTL", "DESC34", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleDESC5 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035DTL", "DESC5", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_SERV_DATE.GetValue += X_SERV_DATE_GetValue;
        X_NBR_SERV.GetValue += X_NBR_SERV_GetValue;
        X_CLAIM_NO.GetValue += X_CLAIM_NO_GetValue;
        X_OHIP_CD.GetValue += X_OHIP_CD_GetValue;
        X_DOC_NAME.GetValue += X_DOC_NAME_GetValue;
        X_HOSP.GetValue += X_HOSP_GetValue;
        X_CHARGE.GetValue += X_CHARGE_GetValue;
        X_CREDIT.GetValue += X_CREDIT_GetValue;
        X_TYPE.GetValue += X_TYPE_GetValue;
        X_PAT.GetValue += X_PAT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U035A_EXTRACT_CLM_DESC_4)"

    private SqlFileObject fleU035B;
    private SqlFileObject fleF002_CLAIMS_MSTR;
    public override bool SelectIf()
    {


        try
        {
            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD")) == "ZZZZ")
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

    private CoreDecimal X_CLAIM_REC_CTR;
    private CoreDecimal X_CLAIM_REC_COUNTER;
    private CoreDecimal X_DESC_REC_COUNTER;
    private CoreCharacter X_DESC12;
    private CoreCharacter X_DESC34;
    private CoreCharacter X_DESC5;
    private DDecimal X_SERV_DATE = new DDecimal("X_SERV_DATE");
    private void X_SERV_DATE_GetValue(ref decimal Value)
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
    private DDecimal X_NBR_SERV = new DDecimal("X_NBR_SERV", 2);
    private void X_NBR_SERV_GetValue(ref decimal Value)
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
    private DCharacter X_CLAIM_NO = new DCharacter("X_CLAIM_NO", 10);
    private void X_CLAIM_NO_GetValue(ref string Value)
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
    private DCharacter X_OHIP_CD = new DCharacter("X_OHIP_CD", 5);
    private void X_OHIP_CD_GetValue(ref string Value)
    {

        try
        {
            Value = "ZZZZZ";


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
    private DCharacter X_DOC_NAME = new DCharacter("X_DOC_NAME", 24);
    private void X_DOC_NAME_GetValue(ref string Value)
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
    private DCharacter X_HOSP = new DCharacter("X_HOSP", 1);
    private void X_HOSP_GetValue(ref string Value)
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
    private DDecimal X_CHARGE = new DDecimal("X_CHARGE", 8);
    private void X_CHARGE_GetValue(ref decimal Value)
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
    private DDecimal X_CREDIT = new DDecimal("X_CREDIT", 8);
    private void X_CREDIT_GetValue(ref decimal Value)
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
    private DDecimal X_TYPE = new DDecimal("X_TYPE", 1);
    private void X_TYPE_GetValue(ref decimal Value)
    {

        try
        {
            Value = 2;


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
    private DDecimal X_PAT = new DDecimal("X_PAT", 1);
    private void X_PAT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 1;


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











    private SqlFileObject fleDESC12;











    private SqlFileObject fleDESC34;











    private SqlFileObject fleDESC5;


    #endregion


    #region "Standard Generated Procedures(U035A_EXTRACT_CLM_DESC_4)"


    #region "Automatic Item Initialization(U035A_EXTRACT_CLM_DESC_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U035A_EXTRACT_CLM_DESC_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
        fleU035B.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDESC12.Transaction = m_trnTRANS_UPDATE;
        fleDESC34.Transaction = m_trnTRANS_UPDATE;
        fleDESC5.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U035A_EXTRACT_CLM_DESC_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
            fleU035B.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleDESC12.Dispose();
            fleDESC34.Dispose();
            fleDESC5.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U035A_EXTRACT_CLM_DESC_4)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_CLM_DESC_4");

            while (fleU035B.QTPForMissing())
            {
                // --> GET U035B <--

                fleU035B.GetData();
                // --> End GET U035B <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU035B.GetStringValue("CLM_SHADOW_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((fleU035B.GetDecimalValue("CLM_SHADOW_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {

                         if (Select_If())
                        {

                            Sort(fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_AGENT_CD"), fleU035B.GetSortValue("CLM_SHADOW_CLINIC"), fleU035B.GetSortValue("CLMHDR_SUB_NBR"), fleU035B.GetSortValue("PAT_SURNAME"), fleU035B.GetSortValue("PAT_GIVEN_NAME"), fleU035B.GetSortValue("DEPT_COMPANY"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_PAT_KEY_TYPE"), fleF002_CLAIMS_MSTR.GetSortValue("CLMHDR_PAT_KEY_DATA"), fleU035B.GetSortValue("CLM_SHADOW_BATCH_NBR"), fleU035B.GetSortValue("CLM_SHADOW_CLAIM_NBR"));
                            //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART



                        }

                    }

                }

            }

            while (Sort(fleU035B, fleF002_CLAIMS_MSTR))
            {
                X_CLAIM_REC_CTR.Value = X_CLAIM_REC_CTR.Value + 1;
                X_CLAIM_REC_COUNTER.Value = 100 + X_CLAIM_REC_CTR.Value;
                X_DESC_REC_COUNTER.Value = X_DESC_REC_COUNTER.Value + 1;
                if (QDesign.NULL(X_DESC_REC_COUNTER.Value) == 1)
                {
                    X_DESC12.Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_DESC");
                }
                else if (QDesign.NULL(X_DESC_REC_COUNTER.Value) == 2)
                {
                    X_DESC12.Value = QDesign.Substring(X_DESC12.Value, 1, 22) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_DESC");
                }
                if (QDesign.NULL(X_DESC_REC_COUNTER.Value) == 3)
                {
                    X_DESC34.Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_DESC");
                }
                else if (QDesign.NULL(X_DESC_REC_COUNTER.Value) == 4)
                {
                    X_DESC34.Value = QDesign.Substring(X_DESC34.Value, 1, 22) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_DESC");
                }
                if (QDesign.NULL(X_DESC_REC_COUNTER.Value) == 5)
                {
                    X_DESC5.Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_DESC");
                }












                SubFile(ref m_trnTRANS_UPDATE, ref fleDESC12, fleF002_CLAIMS_MSTR.At("CLMHDR_AGENT_CD") || fleU035B.At("CLM_SHADOW_CLINIC") || fleU035B.At("CLMHDR_SUB_NBR") || fleU035B.At("PAT_SURNAME") || fleU035B.At("PAT_GIVEN_NAME") || fleU035B.At("DEPT_COMPANY") || fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_OHIP_ID_OR_CHART") || fleU035B.At("CLM_SHADOW_BATCH_NBR") || fleU035B.At("CLM_SHADOW_CLAIM_NBR"), QDesign.NULL(X_DESC12.Value) != QDesign.NULL(" "), SubFileType.Keep, fleU035B, X_SERV_DATE, X_NBR_SERV, X_CLAIM_NO, X_CLAIM_REC_COUNTER,
                X_OHIP_CD, X_DOC_NAME, X_HOSP, X_DESC12, X_CHARGE, X_CREDIT, X_TYPE, X_PAT);













                SubFile(ref m_trnTRANS_UPDATE, ref fleDESC34, fleF002_CLAIMS_MSTR.At("CLMHDR_AGENT_CD") || fleU035B.At("CLM_SHADOW_CLINIC") || fleU035B.At("CLMHDR_SUB_NBR") || fleU035B.At("PAT_SURNAME") || fleU035B.At("PAT_GIVEN_NAME") || fleU035B.At("DEPT_COMPANY") || fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_OHIP_ID_OR_CHART") || fleU035B.At("CLM_SHADOW_BATCH_NBR") || fleU035B.At("CLM_SHADOW_CLAIM_NBR"), QDesign.NULL(X_DESC34.Value) != QDesign.NULL(" "), SubFileType.Keep, fleU035B, X_SERV_DATE, X_NBR_SERV, X_CLAIM_NO, X_CLAIM_REC_COUNTER,
                X_OHIP_CD, X_DOC_NAME, X_HOSP, X_DESC34, X_CHARGE, X_CREDIT, X_TYPE, X_PAT);













                SubFile(ref m_trnTRANS_UPDATE, ref fleDESC5, fleF002_CLAIMS_MSTR.At("CLMHDR_AGENT_CD") || fleU035B.At("CLM_SHADOW_CLINIC") || fleU035B.At("CLMHDR_SUB_NBR") || fleU035B.At("PAT_SURNAME") || fleU035B.At("PAT_GIVEN_NAME") || fleU035B.At("DEPT_COMPANY") || fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_OHIP_ID_OR_CHART") || fleU035B.At("CLM_SHADOW_BATCH_NBR") || fleU035B.At("CLM_SHADOW_CLAIM_NBR"), QDesign.NULL(X_DESC5.Value) != QDesign.NULL(" "), SubFileType.Keep, fleU035B, X_SERV_DATE, X_NBR_SERV, X_CLAIM_NO, X_CLAIM_REC_COUNTER,
                X_OHIP_CD, X_DOC_NAME, X_HOSP, X_DESC5, X_CHARGE, X_CREDIT, X_TYPE, X_PAT);



                Reset(ref X_CLAIM_REC_CTR, fleF002_CLAIMS_MSTR.At("CLMHDR_AGENT_CD") || fleU035B.At("CLM_SHADOW_CLINIC") || fleU035B.At("CLMHDR_SUB_NBR") || fleU035B.At("PAT_SURNAME") || fleU035B.At("PAT_GIVEN_NAME") || fleU035B.At("DEPT_COMPANY") || fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_OHIP_ID_OR_CHART") || fleU035B.At("CLM_SHADOW_BATCH_NBR") || fleU035B.At("CLM_SHADOW_CLAIM_NBR"));
                Reset(ref X_DESC_REC_COUNTER, fleF002_CLAIMS_MSTR.At("CLMHDR_AGENT_CD") || fleU035B.At("CLM_SHADOW_CLINIC") || fleU035B.At("CLMHDR_SUB_NBR") || fleU035B.At("PAT_SURNAME") || fleU035B.At("PAT_GIVEN_NAME") || fleU035B.At("DEPT_COMPANY") || fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_OHIP_ID_OR_CHART") || fleU035B.At("CLM_SHADOW_BATCH_NBR") || fleU035B.At("CLM_SHADOW_CLAIM_NBR"));
                Reset(ref X_DESC12, fleF002_CLAIMS_MSTR.At("CLMHDR_AGENT_CD") || fleU035B.At("CLM_SHADOW_CLINIC") || fleU035B.At("CLMHDR_SUB_NBR") || fleU035B.At("PAT_SURNAME") || fleU035B.At("PAT_GIVEN_NAME") || fleU035B.At("DEPT_COMPANY") || fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_OHIP_ID_OR_CHART") || fleU035B.At("CLM_SHADOW_BATCH_NBR") || fleU035B.At("CLM_SHADOW_CLAIM_NBR"));
                Reset(ref X_DESC34, fleF002_CLAIMS_MSTR.At("CLMHDR_AGENT_CD") || fleU035B.At("CLM_SHADOW_CLINIC") || fleU035B.At("CLMHDR_SUB_NBR") || fleU035B.At("PAT_SURNAME") || fleU035B.At("PAT_GIVEN_NAME") || fleU035B.At("DEPT_COMPANY") || fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_OHIP_ID_OR_CHART") || fleU035B.At("CLM_SHADOW_BATCH_NBR") || fleU035B.At("CLM_SHADOW_CLAIM_NBR"));
                Reset(ref X_DESC5, fleF002_CLAIMS_MSTR.At("CLMHDR_AGENT_CD") || fleU035B.At("CLM_SHADOW_CLINIC") || fleU035B.At("CLMHDR_SUB_NBR") || fleU035B.At("PAT_SURNAME") || fleU035B.At("PAT_GIVEN_NAME") || fleU035B.At("DEPT_COMPANY") || fleF002_CLAIMS_MSTR.At("CLMHDR_PAT_OHIP_ID_OR_CHART") || fleU035B.At("CLM_SHADOW_BATCH_NBR") || fleU035B.At("CLM_SHADOW_CLAIM_NBR"));

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
            EndRequest("EXTRACT_CLM_DESC_4");

        }

    }




    #endregion


}
//EXTRACT_CLM_DESC_4



public class U035A_EXTRACT_CLM_MSGS_5 : U035A
{

    public U035A_EXTRACT_CLM_MSGS_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU035B = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035B", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF094_MSG_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F094_MSG_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_CLAIM_REC_COUNTER = new CoreDecimal("X_CLAIM_REC_COUNTER", 6, this);
        fleCLM_MSG1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035DTL", "CLM_MSG1", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleCLM_MSG2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035DTL", "CLM_MSG2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleCLM_MSG3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035DTL", "CLM_MSG3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleCLM_MSG4 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035DTL", "CLM_MSG4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_SERV_DATE.GetValue += X_SERV_DATE_GetValue;
        X_NBR_SERV.GetValue += X_NBR_SERV_GetValue;
        X_CLAIM_NO.GetValue += X_CLAIM_NO_GetValue;
        X_OHIP_CD.GetValue += X_OHIP_CD_GetValue;
        X_DOC_NAME.GetValue += X_DOC_NAME_GetValue;
        X_HOSP.GetValue += X_HOSP_GetValue;
        X_CHARGE.GetValue += X_CHARGE_GetValue;
        X_CREDIT.GetValue += X_CREDIT_GetValue;
        X_TYPE.GetValue += X_TYPE_GetValue;
        X_PAT.GetValue += X_PAT_GetValue;

    }


    #region "Declarations (Variables, Files and Transactions)(U035A_EXTRACT_CLM_MSGS_5)"

    private SqlFileObject fleU035B;
    private SqlFileObject fleF094_MSG_MSTR;
    private CoreDecimal X_CLAIM_REC_COUNTER;
    private DDecimal X_SERV_DATE = new DDecimal("X_SERV_DATE");
    private void X_SERV_DATE_GetValue(ref decimal Value)
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
    private DDecimal X_NBR_SERV = new DDecimal("X_NBR_SERV", 2);
    private void X_NBR_SERV_GetValue(ref decimal Value)
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
    private DCharacter X_CLAIM_NO = new DCharacter("X_CLAIM_NO", 10);
    private void X_CLAIM_NO_GetValue(ref string Value)
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
    private DCharacter X_OHIP_CD = new DCharacter("X_OHIP_CD", 5);
    private void X_OHIP_CD_GetValue(ref string Value)
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
    private DCharacter X_DOC_NAME = new DCharacter("X_DOC_NAME", 24);
    private void X_DOC_NAME_GetValue(ref string Value)
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
    private DCharacter X_HOSP = new DCharacter("X_HOSP", 1);
    private void X_HOSP_GetValue(ref string Value)
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
    private DDecimal X_CHARGE = new DDecimal("X_CHARGE", 8);
    private void X_CHARGE_GetValue(ref decimal Value)
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
    private DDecimal X_CREDIT = new DDecimal("X_CREDIT", 8);
    private void X_CREDIT_GetValue(ref decimal Value)
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
    private DDecimal X_TYPE = new DDecimal("X_TYPE", 1);
    private void X_TYPE_GetValue(ref decimal Value)
    {

        try
        {
            Value = 3;


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
    private DDecimal X_PAT = new DDecimal("X_PAT", 1);
    private void X_PAT_GetValue(ref decimal Value)
    {

        try
        {
            Value = 1;


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











    private SqlFileObject fleCLM_MSG1;











    private SqlFileObject fleCLM_MSG2;











    private SqlFileObject fleCLM_MSG3;











    private SqlFileObject fleCLM_MSG4;


    #endregion


    #region "Standard Generated Procedures(U035A_EXTRACT_CLM_MSGS_5)"


    #region "Automatic Item Initialization(U035A_EXTRACT_CLM_MSGS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U035A_EXTRACT_CLM_MSGS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
        fleU035B.Transaction = m_trnTRANS_UPDATE;
        fleF094_MSG_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleCLM_MSG1.Transaction = m_trnTRANS_UPDATE;
        fleCLM_MSG2.Transaction = m_trnTRANS_UPDATE;
        fleCLM_MSG3.Transaction = m_trnTRANS_UPDATE;
        fleCLM_MSG4.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U035A_EXTRACT_CLM_MSGS_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
            fleU035B.Dispose();
            fleF094_MSG_MSTR.Dispose();
            fleCLM_MSG1.Dispose();
            fleCLM_MSG2.Dispose();
            fleCLM_MSG3.Dispose();
            fleCLM_MSG4.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U035A_EXTRACT_CLM_MSGS_5)"


    public void Run()
    {

        try
        {
            Request("EXTRACT_CLM_MSGS_5");

            while (fleU035B.QTPForMissing())
            {
                // --> GET U035B <--

                fleU035B.GetData();
                // --> End GET U035B <--

                while (fleF094_MSG_MSTR.QTPForMissing("1"))
                {
                    // --> GET F094_MSG_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF094_MSG_MSTR.ElementOwner("MSG_SUB_KEY_1")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("M"));
                    m_strWhere.Append(" And ").Append(fleF094_MSG_MSTR.ElementOwner("MSG_SUB_KEY_23")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU035B.GetStringValue("CLMHDR_MSG_NBR")));

                    fleF094_MSG_MSTR.GetData(m_strWhere.ToString());
                    // --> End GET F094_MSG_MSTR <--


                    if (Transaction())
                    {
                        X_CLAIM_REC_COUNTER.Value = 201;











                        SubFile(ref m_trnTRANS_UPDATE, ref fleCLM_MSG1, QDesign.NULL(fleF094_MSG_MSTR.GetStringValue("MSG_DTL1")) != QDesign.NULL(" "), SubFileType.Keep, fleU035B, "CLMHDR_AGENT_CD", "DEPT_COMPANY", "CLM_SHADOW_CLINIC", "CLMHDR_SUB_NBR", "PAT_SURNAME",
                        "PAT_GIVEN_NAME", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLM_SHADOW_BATCH_NBR", "CLM_SHADOW_CLAIM_NBR", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POSTAL_CD", "PAT_COUNTRY", "PAT_OHIP_MMYY",
                        X_SERV_DATE, X_NBR_SERV, X_CLAIM_NO, X_CLAIM_REC_COUNTER, X_OHIP_CD, X_DOC_NAME, X_HOSP, fleF094_MSG_MSTR, "MSG_DTL1", "MSG_DTL1",
                        X_CHARGE, X_CREDIT, X_TYPE, X_PAT);


                        X_CLAIM_REC_COUNTER.Value = 202;











                        SubFile(ref m_trnTRANS_UPDATE, ref fleCLM_MSG2, QDesign.NULL(fleF094_MSG_MSTR.GetStringValue("MSG_DTL1")) != QDesign.NULL(" "), SubFileType.Keep, fleU035B, "CLMHDR_AGENT_CD", "DEPT_COMPANY", "CLM_SHADOW_CLINIC", "CLMHDR_SUB_NBR", "PAT_SURNAME",
                        "PAT_GIVEN_NAME", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLM_SHADOW_BATCH_NBR", "CLM_SHADOW_CLAIM_NBR", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POSTAL_CD", "PAT_COUNTRY", "PAT_OHIP_MMYY",
                        X_SERV_DATE, X_NBR_SERV, X_CLAIM_NO, X_CLAIM_REC_COUNTER, X_OHIP_CD, X_DOC_NAME, X_HOSP, fleF094_MSG_MSTR, "MSG_DTL2", X_CHARGE,
                        X_CREDIT, X_TYPE, X_PAT);


                        X_CLAIM_REC_COUNTER.Value = 203;











                        SubFile(ref m_trnTRANS_UPDATE, ref fleCLM_MSG3, QDesign.NULL(fleF094_MSG_MSTR.GetStringValue("MSG_DTL3")) != QDesign.NULL(" "), SubFileType.Keep, fleU035B, "CLMHDR_AGENT_CD", "DEPT_COMPANY", "CLM_SHADOW_CLINIC", "CLMHDR_SUB_NBR", "PAT_SURNAME",
                        "PAT_GIVEN_NAME", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLM_SHADOW_BATCH_NBR", "CLM_SHADOW_CLAIM_NBR", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POSTAL_CD", "PAT_COUNTRY", "PAT_OHIP_MMYY",
                        X_SERV_DATE, X_NBR_SERV, X_CLAIM_NO, X_CLAIM_REC_COUNTER, X_OHIP_CD, X_DOC_NAME, X_HOSP, fleF094_MSG_MSTR, "MSG_DTL3", "MSG_DTL3",
                        X_CHARGE, X_CREDIT, X_TYPE, X_PAT);


                        X_CLAIM_REC_COUNTER.Value = 204;











                        SubFile(ref m_trnTRANS_UPDATE, ref fleCLM_MSG4, QDesign.NULL(fleF094_MSG_MSTR.GetStringValue("MSG_DTL4")) != QDesign.NULL(" "), SubFileType.Keep, fleU035B, "CLMHDR_AGENT_CD", "DEPT_COMPANY", "CLM_SHADOW_CLINIC", "CLMHDR_SUB_NBR", "PAT_SURNAME",
                        "PAT_GIVEN_NAME", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLM_SHADOW_BATCH_NBR", "CLM_SHADOW_CLAIM_NBR", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POSTAL_CD", "PAT_COUNTRY", "PAT_OHIP_MMYY",
                        X_SERV_DATE, X_NBR_SERV, X_CLAIM_NO, X_CLAIM_REC_COUNTER, X_OHIP_CD, X_DOC_NAME, X_HOSP, fleF094_MSG_MSTR, "MSG_DTL4", "MSG_DTL4",
                        X_CHARGE, X_CREDIT, X_TYPE, X_PAT);



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
            EndRequest("EXTRACT_CLM_MSGS_5");

        }

    }




    #endregion


}
//EXTRACT_CLM_MSGS_5



public class U035A_CALCULATE_RUNNING_TOTALS_6 : U035A
{

    public U035A_CALCULATE_RUNNING_TOTALS_6(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleU035DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        X_CHARGE_TOT = new CoreDecimal("X_CHARGE_TOT", 8, this);
        X_CREDIT_TOT = new CoreDecimal("X_CREDIT_TOT", 8, this);
        X_BALDUE_TOT = new CoreDecimal("X_BALDUE_TOT", 8, this);
        X_PAT_DTL_COUNTER = new CoreDecimal("X_PAT_DTL_COUNTER", 3, this);
        fleU035DTL_TOTALLED = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U035DTL_TOTALLED", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);


    }


    #region "Declarations (Variables, Files and Transactions)(U035A_CALCULATE_RUNNING_TOTALS_6)"

    private SqlFileObject fleU035DTL;
    private CoreDecimal X_CHARGE_TOT;
    private CoreDecimal X_CREDIT_TOT;
    private CoreDecimal X_BALDUE_TOT;

    private CoreDecimal X_PAT_DTL_COUNTER;










    private SqlFileObject fleU035DTL_TOTALLED;


    #endregion


    #region "Standard Generated Procedures(U035A_CALCULATE_RUNNING_TOTALS_6)"


    #region "Automatic Item Initialization(U035A_CALCULATE_RUNNING_TOTALS_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion


    #region "Transaction Management Procedures(U035A_CALCULATE_RUNNING_TOTALS_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
        fleU035DTL.Transaction = m_trnTRANS_UPDATE;
        fleU035DTL_TOTALLED.Transaction = m_trnTRANS_UPDATE;


    }



    #endregion


    #region "FILE Management Procedures(U035A_CALCULATE_RUNNING_TOTALS_6)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:04 PM

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
            fleU035DTL.Dispose();
            fleU035DTL_TOTALLED.Dispose();


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


    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U035A_CALCULATE_RUNNING_TOTALS_6)"


    public void Run()
    {

        try
        {
            Request("CALCULATE_RUNNING_TOTALS_6");

            while (fleU035DTL.QTPForMissing())
            {
                // --> GET U035DTL <--

                fleU035DTL.GetData();
                // --> End GET U035DTL <--


                if (Transaction())
                {

                    Sort(fleU035DTL.GetSortValue("CLMHDR_AGENT_CD"), fleU035DTL.GetSortValue("CLM_SHADOW_CLINIC"), fleU035DTL.GetSortValue("CLMHDR_SUB_NBR"), fleU035DTL.GetSortValue("PAT_SURNAME"), fleU035DTL.GetSortValue("PAT_GIVEN_NAME"), fleU035DTL.GetSortValue("DEPT_COMPANY"), fleU035DTL.GetSortValue("CLMHDR_PAT_OHIP_ID_OR_CHART"), fleU035DTL.GetSortValue("CLM_SHADOW_BATCH_NBR"), fleU035DTL.GetSortValue("CLM_SHADOW_CLAIM_NBR"), fleU035DTL.GetSortValue("X_CLAIM_REC_COUNTER"));



                }

            }

            while (Sort(fleU035DTL))
            {
                X_CHARGE_TOT.Value = X_CHARGE_TOT.Value + fleU035DTL.GetDecimalValue("X_CHARGE");
                X_CREDIT_TOT.Value = X_CREDIT_TOT.Value + fleU035DTL.GetDecimalValue("X_CREDIT");
                X_BALDUE_TOT.Value = X_CHARGE_TOT.Value + X_CREDIT_TOT.Value;
                X_PAT_DTL_COUNTER.Value = X_PAT_DTL_COUNTER.Value + 1;












                SubFile(ref m_trnTRANS_UPDATE, ref fleU035DTL_TOTALLED, SubFileType.Keep, X_CHARGE_TOT, X_CREDIT_TOT, X_BALDUE_TOT, X_PAT_DTL_COUNTER, fleU035DTL);



                Reset(ref X_CHARGE_TOT, fleU035DTL.At("CLMHDR_AGENT_CD") || fleU035DTL.At("CLM_SHADOW_CLINIC") || fleU035DTL.At("CLMHDR_SUB_NBR") || fleU035DTL.At("PAT_SURNAME") || fleU035DTL.At("PAT_GIVEN_NAME") || fleU035DTL.At("DEPT_COMPANY") || fleU035DTL.At("CLMHDR_PAT_OHIP_ID_OR_CHART"));
                Reset(ref X_CREDIT_TOT, fleU035DTL.At("CLMHDR_AGENT_CD") || fleU035DTL.At("CLM_SHADOW_CLINIC") || fleU035DTL.At("CLMHDR_SUB_NBR") || fleU035DTL.At("PAT_SURNAME") || fleU035DTL.At("PAT_GIVEN_NAME") || fleU035DTL.At("DEPT_COMPANY") || fleU035DTL.At("CLMHDR_PAT_OHIP_ID_OR_CHART"));
                Reset(ref X_BALDUE_TOT, fleU035DTL.At("CLMHDR_AGENT_CD") || fleU035DTL.At("CLM_SHADOW_CLINIC") || fleU035DTL.At("CLMHDR_SUB_NBR") || fleU035DTL.At("PAT_SURNAME") || fleU035DTL.At("PAT_GIVEN_NAME") || fleU035DTL.At("DEPT_COMPANY") || fleU035DTL.At("CLMHDR_PAT_OHIP_ID_OR_CHART"));
                Reset(ref X_PAT_DTL_COUNTER, fleU035DTL.At("CLMHDR_AGENT_CD") || fleU035DTL.At("CLM_SHADOW_CLINIC") || fleU035DTL.At("CLMHDR_SUB_NBR") || fleU035DTL.At("PAT_SURNAME") || fleU035DTL.At("PAT_GIVEN_NAME") || fleU035DTL.At("DEPT_COMPANY") || fleU035DTL.At("CLMHDR_PAT_OHIP_ID_OR_CHART"));

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
            EndRequest("CALCULATE_RUNNING_TOTALS_6");

        }

    }




    #endregion


}
//CALCULATE_RUNNING_TOTALS_6




