#region "Screen Comments"

//  #> PROGRAM-ID.    u099.qts
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE : TO PURGE `INACTIVE` PATIENTS FROM THE PATIENT
//  MASTER. IF THE PATIENTS DO NOT HAVE ANY CLAIMS,
//  THEN PATIENT IS DELETED.
//  MODIFICATION HISTORY
//  DATE      WHO        DESCRIPTION
//  2000/04/28   B.Annis    Originally converted from u099.cbl
//  2003/dec/23  A.A.   alpha doctor nbr

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U099 : BaseClassControl
{
    private U099 m_U099;
    
    public U099(string Name, int Level) 
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public U099(string Name, int Level, bool Request) 
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose()
    {
        if (!(m_U099 == null))
        {
            m_U099.CloseTransactionObjects();
            m_U099 = null;
        }
    }
    
    public U099 GetU099(int Level)
    {
        if ((m_U099 == null))
        {
            m_U099 = new U099("U099", Level);
        }
        else {
            m_U099.ResetValues();
        }
        
        return m_U099;
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
            U099_1 U099_1 = new U099_1(Name, Level);
            U099_1.Run();
            U099_1.Dispose();
            U099_1 = null;

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

public class U099_1 : U099
{
    public U099_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU099_DELETE_PATIENTS = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U099_DELETE_PATIENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU099_RETAIN_PATIENTS = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "U099_RETAIN_PATIENTS", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        D_SEL_DATE.GetValue += D_SEL_DATE_GetValue;
        D_DEL_FLAG.GetValue += D_DEL_FLAG_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(U099_1)"

    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleF002_CLAIMS_MSTR_HDR;
    
    private DDecimal D_SEL_DATE = new DDecimal("D_SEL_DATE");
    private void D_SEL_DATE_GetValue(ref Decimal Value)
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
    
    private DCharacter D_DEL_FLAG = new DCharacter("D_DEL_FLAG", 1);
    private void D_DEL_FLAG_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (! fleF002_CLAIMS_MSTR_HDR.Exists() 
                        && QDesign.NULL(D_SEL_DATE.Value) > QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_DATE_LAST_MAINT")) 
                        && QDesign.NULL(D_SEL_DATE.Value) > QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_DATE_LAST_VISIT")) 
                        && QDesign.NULL(D_SEL_DATE.Value) > QDesign.NULL(fleF010_PAT_MSTR.GetDecimalValue("PAT_DATE_LAST_ADMIT")))
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
    
    private SqlFileObject fleU099_DELETE_PATIENTS;
    private SqlFileObject fleU099_RETAIN_PATIENTS;

    #endregion

    #region "Standard Generated Procedures(U099_1)"

    #region "Automatic Item Initialization(U099_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(U099_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 8/30/2019 9:58:02 AM

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
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        fleU099_DELETE_PATIENTS.Transaction = m_trnTRANS_UPDATE;
        fleU099_RETAIN_PATIENTS.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(U099_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 8/30/2019 9:58:02 AM

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
            fleF010_PAT_MSTR.Dispose();
            fleF002_CLAIMS_MSTR_HDR.Dispose();
            fleU099_DELETE_PATIENTS.Dispose();
            fleU099_RETAIN_PATIENTS.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U099_1)"

    public void Run()
    {
        try
        {
            Request("U099");

            while (fleF010_PAT_MSTR.QTPForMissing())
            {
                //  --> GET F010_PAT_MSTR <--
                fleF010_PAT_MSTR.GetData();
                //  --> End GET F010_PAT_MSTR <--

                while (fleF002_CLAIMS_MSTR_HDR.QTPForMissing("1"))
                {
                    //  --> GET F002_CLAIMS_MSTR_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_P_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("P"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_P_CLM_DATA")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 2, 14)));

                    fleF002_CLAIMS_MSTR_HDR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    //  --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {
                        Sort(fleF010_PAT_MSTR.GetSortValue("PAT_I_KEY"), fleF010_PAT_MSTR.GetSortValue("PAT_CON_NBR"), fleF010_PAT_MSTR.GetSortValue("PAT_I_NBR"), fleF010_PAT_MSTR.GetSortValue("FILLER4"));
                        // Parent:KEY_PAT_MSTR
                    }
                }
            }
            
            while (Sort(fleF010_PAT_MSTR, fleF002_CLAIMS_MSTR_HDR))
            {
                SubFile(ref m_trnTRANS_UPDATE, "U099_DELETE_PATIENTS", fleF010_PAT_MSTR.At("KEY_PAT_MSTR"), QDesign.NULL(D_DEL_FLAG.Value) == "Y", SubFileType.Keep, fleF010_PAT_MSTR);
                // Parent:PAT_OHIP_OUT_PROV)    'Parent:PAT_EXPIRY_DATE)    'Parent:PAT_DIRECT_BDATE)    'Parent:PAT_BIRTH_DATE)    'Parent:SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO)    'Parent:SUBSCR_DATE_LAST_STATEMENT)    'Parent:PAT_ACRONYM)    'Parent:PAT_OHIP_MMYY)    'Parent:PAT_DIRECT_ID)    'Parent:PAT_FULL_NAME)    'Parent:PAT_SURNAME)    'Parent:PAT_SURNAME_RR)    'Parent:PAT_GIVEN_NAME)    'Parent:PAT_GIVEN_NAME_RR)    'Parent:PAT_INIT)    'Parent:KEY_PAT_MSTR)    'Parent:SUBSCR_POSTAL_CD)    'Parent:SUBSCR_POST_CODE1)    'Parent:SUBSCR_POST_CODE2)    'Parent:SUBSCR_MSG_DATA

                SubFile(ref m_trnTRANS_UPDATE, "U099_RETAIN_PATIENTS", fleF010_PAT_MSTR.At("KEY_PAT_MSTR"), QDesign.NULL(D_DEL_FLAG.Value) == "N", SubFileType.Keep, fleF010_PAT_MSTR);
                // Parent:PAT_OHIP_OUT_PROV)    'Parent:PAT_EXPIRY_DATE)    'Parent:PAT_DIRECT_BDATE)    'Parent:PAT_BIRTH_DATE)    'Parent:SUBSCR_DATE_MSG_NBR_EFFECTIVE_TO)    'Parent:SUBSCR_DATE_LAST_STATEMENT)    'Parent:PAT_ACRONYM)    'Parent:PAT_OHIP_MMYY)    'Parent:PAT_DIRECT_ID)    'Parent:PAT_FULL_NAME)    'Parent:PAT_SURNAME)    'Parent:PAT_SURNAME_RR)    'Parent:PAT_GIVEN_NAME)    'Parent:PAT_GIVEN_NAME_RR)    'Parent:PAT_INIT)    'Parent:KEY_PAT_MSTR)    'Parent:SUBSCR_POSTAL_CD)    'Parent:SUBSCR_POST_CODE1)    'Parent:SUBSCR_POST_CODE2)    'Parent:SUBSCR_MSG_DATA
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
            EndRequest("U099");
        }
    }

    #endregion
}