#region "Screen Comments"

//  #> PROGRAM-ID.    u072.qts
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : THIS PROGRAM IS USED IN CONJUNCTION WITH R071 AND R073.
//  ITS PURPOSE IS TO PURGE THE CLAIMS WITH VALUES LESS
//  THAN .64 AND GREATER THAN -.64.  R071 VERIFIES THE NON-
//  PURGED CLAIMS AND R073 VERIFIES THE PURGED CLAIMS.
//  MODIFICATION HISTORY
//  DATE   WHO DESCRIPTION
//  00/apr/28 B.A. - converted from u072.cbl
//  00/oct/13 B.E. - changed purge criteria based upon yas`s request
//  00/nov/23 M.C. - correct the criteria for not alternative funding clinics
//  use and instead of or when checking clinic 80, 81, 82, 83,95
//  02/jul/05 M.C. - Yas requests to delete claims that have balance 99 cents and under
//  for non-clinic 80`s  
//  03/may/03 yas - add new clinics 91,92,93,94,96
//  03/dec/23 A.A. - alpha doctor nbr
//  2004/mar/04   yas   - take out clinic 96
//  2004/mar/16   M.C.  - modify x-delete-flag definition to use afp-flag instead of clinic nbr
//  2004/may/19   M.C.  - modify the value check on afp-flag(iconst-clinic-card-colour)
//  - value `O` represents old afp  
//  2011/09/13    MC1   - Yasemin wants to change from < to <= when compare with cutoff date (ie inclusive) 
//  2012/02/01    MC2   - change the condition when calculating the balance  
//  2014/03/26    MC3   - discovered that there are about 41 records with agent 6 with 0 balance did not get purge prior 2006;
//  somehow the amounts between oma & ohip are different.  According to d003, to calculate the
//  balance due based on clmhdr-tot-claim-ar-ohip for all agents; hence change the same here 
//  ------------------------------------------------

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U072 : BaseClassControl
{
    private U072 m_U072;
    
    public U072(string Name, int Level) 
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public U072(string Name, int Level, bool Request) 
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose()
    {
        if (!(m_U072 == null))
        {
            m_U072.CloseTransactionObjects();
            m_U072 = null;
        }
    }
    
    public U072 GetU072(int Level)
    {
        if ((m_U072 == null))
        {
            m_U072 = new U072("U072", Level);
        }
        else
        {
            m_U072.ResetValues();
        }
        
        return m_U072;
    }
    
    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.
    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
    protected SqlTransaction m_trnTRANS_UPDATE;
    
    public override bool RunQTP()
    {
        try
        {
            U072_DELETE_TYPE_CLAIM_1 DELETE_TYPE_CLAIM_1 = new U072_DELETE_TYPE_CLAIM_1(Name, Level);
            DELETE_TYPE_CLAIM_1.Run();
            DELETE_TYPE_CLAIM_1.Dispose();
            DELETE_TYPE_CLAIM_1 = null;

            U072_RETAIN_TYPE_CLAIMS_2 RETAIN_TYPE_CLAIMS_2 = new U072_RETAIN_TYPE_CLAIMS_2(Name, Level);
            RETAIN_TYPE_CLAIMS_2.Run();
            RETAIN_TYPE_CLAIMS_2.Dispose();
            RETAIN_TYPE_CLAIMS_2 = null;

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
}

public class U072_DELETE_TYPE_CLAIM_1 : U072
{
    public U072_DELETE_TYPE_CLAIM_1(string Name, int Level) 
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleICONST_MSTR_REC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F090_CONSTANTS_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU072_DELETE_CLAIM_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U072_DELETE_CLAIM_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U072_RETAIN_CLAIM", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR_HDR.Choose += fleF002_CLAIMS_MSTR_HDR_Choose;
    }

    #region "Declarations (Variables, Files and Transactions)(U072_DELETE_TYPE_CLAIM_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR_HDR;
    private SqlFileObject fleICONST_MSTR_REC;
    
    private void fleF002_CLAIMS_MSTR_HDR_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("B"));
            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("00000"));

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
    
    private DDecimal X_BALANCE_DUE = new DDecimal("X_BALANCE_DUE", 7);
    
    private void X_BALANCE_DUE_GetValue(ref Decimal Value)
    {
        try
        {
            Value = (fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS") + fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_TOT_CLAIM_AR_OHIP"));
        }

        catch (CustomApplicationException ex)
        {
            WriteError(ex);
        }

        catch (Exception ex) {
            WriteError(ex);
        }
    }
    
    private DDecimal X_PED_PURGE_PRIOR_TO_DATE = new DDecimal("X_PED_PURGE_PRIOR_TO_DATE");
    
    private void X_PED_PURGE_PRIOR_TO_DATE_GetValue(ref Decimal Value)
    {
        try
        {
            Value = Convert.ToDecimal(Prompt(2));
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
    
    private DDecimal X_PURGE_PRIOR_TO_YYMM01 = new DDecimal("X_PURGE_PRIOR_TO_YYMM01");
    
    private void X_PURGE_PRIOR_TO_YYMM01_GetValue(ref Decimal Value)
    {
        try
        {
            Value = QDesign.NConvert((QDesign.Substring(QDesign.ASCII(X_PED_PURGE_PRIOR_TO_DATE.Value, 8), 1, 6) + "01"));
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
    
    private DCharacter X_DELETE_FLAG = new DCharacter("X_DELETE_FLAG", 1);
    
    private void X_DELETE_FLAG_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_BATCH_TYPE")) == "C" && fleF002_CLAIMS_MSTR_HDR.GetNumericDateValue("CLMHDR_DATE_PERIOD_END") <= X_PED_PURGE_PRIOR_TO_DATE.Value && (((QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) != "O"))) && (QDesign.NULL(X_BALANCE_DUE.Value) > -100 && QDesign.NULL(X_BALANCE_DUE.Value) < 100) || ((QDesign.NULL(fleICONST_MSTR_REC.GetStringValue("ICONST_CLINIC_CARD_COLOUR")) == "O")))
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

    private SqlFileObject fleU072_DELETE_CLAIM_HDR;
    private SqlFileObject fleU072_RETAIN_CLAIM;

    #endregion

    #region "Standard Generated Procedures(U072_DELETE_TYPE_CLAIM_1)"

    #region "Automatic Item Initialization(U072_DELETE_TYPE_CLAIM_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(U072_DELETE_TYPE_CLAIM_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 8/30/2019 9:56:14 AM

    // #-----------------------------------------
    // # InitializeTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void InitializeTransactionObjects() {
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
    
    // #-----------------------------------------
    // # CloseTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void CloseTransactionObjects()
    {
        try
        {
            this.CloseFiles();

            if (!(m_trnTRANS_UPDATE == null))
            {
                m_trnTRANS_UPDATE.Dispose();
            }
            
            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Close();
            }
            
            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Dispose();
            }
            
            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Close();
            }
            
            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Dispose();
            }
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
        if ((Method == TransactionMethods.Rollback))
        {
            m_trnTRANS_UPDATE.Rollback();
        }
        else
        {
            m_trnTRANS_UPDATE.Commit();
        }
        
        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        this.Initialize_TRANS_UPDATE();
    }
    
    private void Initialize_TRANS_UPDATE()
    {
        fleF002_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        fleICONST_MSTR_REC.Transaction = m_trnTRANS_UPDATE;
        fleU072_DELETE_CLAIM_HDR.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion


    #region "FILE Management Procedures(U072_DELETE_TYPE_CLAIM_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 8/30/2019 9:56:14 AM
    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------
    protected override void InitializeFiles()
    {
        try
        {
            this.Initialize_TRANS_UPDATE();
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
    
    // #-----------------------------------------
    // # CloseFiles Procedure.
    // #-----------------------------------------
    protected override void CloseFiles()
    {
        try
        {
            fleF002_CLAIMS_MSTR_HDR.Dispose();
            fleICONST_MSTR_REC.Dispose();
            fleU072_DELETE_CLAIM_HDR.Dispose();
            fleU072_RETAIN_CLAIM.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U072_DELETE_TYPE_CLAIM_1)"
    public void Run()
    {
        try
        {
            Request("DELETE_TYPE_CLAIM_1");

            while (fleF002_CLAIMS_MSTR_HDR.QTPForMissing())
            {
                //  --> GET F002_CLAIMS_MSTR_HDR <--
                fleF002_CLAIMS_MSTR_HDR.GetData();
                //  --> End GET F002_CLAIMS_MSTR_HDR <--

                while (fleICONST_MSTR_REC.QTPForMissing("1"))
                {
                    //  --> GET ICONST_MSTR_REC <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleICONST_MSTR_REC.ElementOwner("ICONST_CLINIC_NBR_1_2")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2)));

                    fleICONST_MSTR_REC.GetData(m_strWhere.ToString());

                    //  --> End GET ICONST_MSTR_REC <--
                    if (Transaction())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, "U072_DELETE_CLAIM_HDR", X_DELETE_FLAG.Value == "Y", SubFileType.Keep, fleF002_CLAIMS_MSTR_HDR, "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "CLMHDR_BATCH_TYPE", "CLMHDR_ADJ_CD", "CLMHDR_AGENT_CD", "CLMHDR_CYCLE_NBR", "CLMHDR_DATE_PERIOD_END", "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", X_BALANCE_DUE, "CLMHDR_ORIG_BATCH_NBR", "CLMHDR_ORIG_CLAIM_NBR", X_PED_PURGE_PRIOR_TO_DATE);
                        // Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ORIG_BATCH_ID

                        SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM", X_DELETE_FLAG.Value == "N", SubFileType.Keep, fleF002_CLAIMS_MSTR_HDR, "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", X_PED_PURGE_PRIOR_TO_DATE);
                        // Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ORIG_BATCH_ID
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
            EndRequest("DELETE_TYPE_CLAIM_1");
        }
    }

    #endregion
}
// DELETE_TYPE_CLAIM_1

public class U072_RETAIN_TYPE_CLAIMS_2 : U072
{
    public U072_RETAIN_TYPE_CLAIMS_2(string Name, int Level) 
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleU072_RETAIN_CLAIM = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU072_RETAIN_CLAIM_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU072_RETAIN_CLAIM_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U072_RETAIN_CLAIM_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
    }

    #region "Declarations (Variables, Files and Transactions)(U072_RETAIN_TYPE_CLAIMS_2)"

    private SqlFileObject fleU072_RETAIN_CLAIM;
    private SqlFileObject fleF002_CLAIMS_MSTR_HDR;
    private SqlFileObject fleF002_CLAIMS_MSTR_DTL;

    private DCharacter X_KEY_CLM_SERV_CODE = new DCharacter("X_KEY_CLM_SERV_CODE", 4);
    
    private void X_KEY_CLM_SERV_CODE_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR_HDR.GetStringValue("KEY_CLM_SERV_CODE"), 1, 4);
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

    private SqlFileObject fleU072_RETAIN_CLAIM_HDR;
    private SqlFileObject fleU072_RETAIN_CLAIM_DTL;
    private SqlFileObject fleU072_RETAIN_CLAIM_DESC;

    #endregion

    #region "Standard Generated Procedures(U072_RETAIN_TYPE_CLAIMS_2)"

    #region "Automatic Item Initialization(U072_RETAIN_TYPE_CLAIMS_2)"


    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(U072_RETAIN_TYPE_CLAIMS_2)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 8/30/2019 9:56:14 AM

    // #-----------------------------------------
    // # InitializeTransactionObjects Procedure.
    // #-----------------------------------------
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
    
    // #-----------------------------------------
    // # CloseTransactionObjects Procedure.
    // #-----------------------------------------
    protected override void CloseTransactionObjects()
    {
        try
        {
            this.CloseFiles();

            if (!(m_trnTRANS_UPDATE == null))
            {
                m_trnTRANS_UPDATE.Dispose();
            }
            
            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Close();
            }
            
            if (!(m_cnnTRANS_UPDATE == null))
            {
                m_cnnTRANS_UPDATE.Dispose();
            }
            
            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Close();
            }
            
            if (!(m_cnnQUERY == null))
            {
                m_cnnQUERY.Dispose();
            }
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
        if ((Method == TransactionMethods.Rollback))
        {
            m_trnTRANS_UPDATE.Rollback();
        }
        else
        {
            m_trnTRANS_UPDATE.Commit();
        }
        
        m_trnTRANS_UPDATE = m_cnnTRANS_UPDATE.BeginTransaction();
        this.Initialize_TRANS_UPDATE();
    }
    
    private void Initialize_TRANS_UPDATE()
    {
        fleU072_RETAIN_CLAIM.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_HDR.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_DTL.Transaction = m_trnTRANS_UPDATE;
        fleU072_RETAIN_CLAIM_DESC.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(U072_RETAIN_TYPE_CLAIMS_2)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 8/30/2019 9:56:14 AM

    // #-----------------------------------------
    // # InitializeFiles Procedure.
    // #-----------------------------------------
    protected override void InitializeFiles()
    {
        try
        {
            this.Initialize_TRANS_UPDATE();
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
    
    // #-----------------------------------------
    // # CloseFiles Procedure.
    // #-----------------------------------------
    protected override void CloseFiles()
    {
        try
        {
            fleU072_RETAIN_CLAIM.Dispose();
            fleF002_CLAIMS_MSTR_HDR.Dispose();
            fleF002_CLAIMS_MSTR_DTL.Dispose();
            fleU072_RETAIN_CLAIM_HDR.Dispose();
            fleU072_RETAIN_CLAIM_DTL.Dispose();
            fleU072_RETAIN_CLAIM_DESC.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U072_RETAIN_TYPE_CLAIMS_2)"
    public void Run()
    {
        try
        {
            Request("RETAIN_TYPE_CLAIMS_2");

            while (fleU072_RETAIN_CLAIM.QTPForMissing())
            {
                //  --> GET U072_RETAIN_CLAIM <--
                fleU072_RETAIN_CLAIM.GetData();
                //  --> End GET U072_RETAIN_CLAIM <--

                while (fleF002_CLAIMS_MSTR_HDR.QTPForMissing("1"))
                {
                    //  --> GET F002_CLAIMS_MSTR_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU072_RETAIN_CLAIM.GetStringValue("KEY_CLM_TYPE")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleU072_RETAIN_CLAIM.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(fleU072_RETAIN_CLAIM.GetDecimalValue("KEY_CLM_CLAIM_NBR"));

                    fleF002_CLAIMS_MSTR_HDR.GetData(m_strWhere.ToString());
                    //  --> End GET F002_CLAIMS_MSTR <--

                    while (fleF002_CLAIMS_MSTR_DTL.QTPForMissing("1"))
                    {
                        //  --> GET F002_CLAIMS_MSTR_DTL <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR_HDR.GetStringValue("KEY_CLM_TYPE")));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR_HDR.GetStringValue("KEY_CLM_BATCH_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("KEY_CLM_CLAIM_NBR"));

                        fleF002_CLAIMS_MSTR_DTL.GetData(m_strWhere.ToString());
                        //  --> End GET F002_CLAIMS_MSTR_DTL <--

                        if (Transaction())
                        {
                            SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_HDR", fleF002_CLAIMS_MSTR_HDR.GetStringValue("KEY_CLM_SERV_CODE") == "00000", SubFileType.Keep, fleF002_CLAIMS_MSTR_HDR, "CLMHDR_BATCH_NBR", "CLMHDR_CLAIM_NBR", "CLMHDR_OMA_SUFF_ADJ", "CLMHDR_BATCH_TYPE", "CLMHDR_ADJ_CD_SUB_TYPE", "CLMHDR_DOC_NBR_OHIP", "CLMHDR_DOC_SPEC_CD", "CLMHDR_REFER_DOC_NBR", "CLMHDR_DIAG_CD", "CLMHDR_LOC", "CLMHDR_HOSP", "CLMHDR_AGENT_CD", "CLMHDR_ADJ_CD", "CLMHDR_TAPE_SUBMIT_IND", "CLMHDR_I_O_PAT_IND", "CLMHDR_PAT_OHIP_ID_OR_CHART", "CLMHDR_PAT_ACRONYM", "CLMHDR_REFERENCE", "CLMHDR_DATE_ADMIT", "CLMHDR_DOC_DEPT", "CLMHDR_DATE_CASH_TAPE_PAYMENT", "CLMHDR_CURR_PAYMENT", "CLMHDR_DATE_PERIOD_END", "CLMHDR_CYCLE_NBR", "CLMHDR_DATE_SYS", "CLMHDR_AMT_TECH_BILLED", "CLMHDR_AMT_TECH_PAID", "CLMHDR_TOT_CLAIM_AR_OMA", "CLMHDR_TOT_CLAIM_AR_OHIP", "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", "CLMHDR_STATUS_OHIP", "CLMHDR_MANUAL_REVIEW", "CLMHDR_SUBMIT_DATE", "CLMHDR_CONFIDENTIAL_FLAG", "CLMHDR_SERV_DATE", "CLMHDR_ORIG_BATCH_ID", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", "KEY_P_CLM_TYPE", "KEY_P_CLM_DATA");
                            // Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ORIG_BATCH_ID

                            SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_DTL", fleF002_CLAIMS_MSTR_DTL.GetStringValue("KEY_CLM_SERV_CODE") != "00000" & X_KEY_CLM_SERV_CODE.Value != "ZZZZ", SubFileType.Keep, fleF002_CLAIMS_MSTR_DTL, "CLMDTL_BATCH_NBR", "CLMDTL_CLAIM_NBR", "CLMDTL_OMA_CD", "CLMDTL_OMA_SUFF", "CLMDTL_ADJ_NBR", "CLMDTL_REV_GROUP_CD", "CLMDTL_AGENT_CD", "CLMDTL_ADJ_CD", "CLMDTL_NBR_SERV", "CLMDTL_SV_DATE", "CLMDTL_CONSEC_DATES", "CLMDTL_AMT_TECH_BILLED", "CLMDTL_FEE_OMA", "CLMDTL_FEE_OHIP", "CLMDTL_DATE_PERIOD_END", "CLMDTL_CYCLE_NBR", "CLMDTL_DIAG_CD", "CLMDTL_LINE_NO", "CLMDTL_FILLER9", "CLMDTL_ORIG_BATCH_ID", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", "KEY_P_CLM_TYPE", "KEY_P_CLM_DATA");
                            // Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ORIG_BATCH_ID

                            SubFile(ref m_trnTRANS_UPDATE, "U072_RETAIN_CLAIM_DESC", X_KEY_CLM_SERV_CODE.Value == "ZZZZ", SubFileType.Keep, fleF002_CLAIMS_MSTR_DTL, "CLMDTL_BATCH_NBR", "CLMDTL_CLAIM_NBR", "CLMDTL_OMA_CD", "CLMDTL_OMA_SUFF", "CLMDTL_ADJ_NBR", "CLMDTL_DESC", "CLMDTL_ORIG_BATCH_ID", "KEY_CLM_TYPE", "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "KEY_CLM_SERV_CODE", "KEY_CLM_ADJ_NBR", "KEY_P_CLM_TYPE", "KEY_P_CLM_DATA");
                            // Parent:CLMDTL_CONSEC_DATES)    'Parent:CLMHDR_OMA_SUFF_ADJ)    'Parent:CLMHDR_PAT_OHIP_ID_OR_CHART)    'Parent:CLMHDR_PAT_ACRONYM)    'Parent:CLMHDR_DATE_CASH_TAPE_PAYMENT)    'Parent:CLMHDR_ORIG_BATCH_ID)    'Parent:CLMDTL_SV_DATE)    'Parent:CLMDTL_ORIG_BATCH_ID
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
            EndRequest("RETAIN_TYPE_CLAIMS_2");
        }
    }

    #endregion
}
// RETAIN_TYPE_CLAIMS_2