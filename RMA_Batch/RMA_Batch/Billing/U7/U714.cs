#region "Screen Comments"

//  #> PROGRAM-ID.     U714.QTS
//  ((C)) Dyad Technologies
//  PROGRAM PURPOSE: UPDATE SUSPENDED CLAIM **HEADER** RECORDS TO `R`ESUBMIT
//  IF EXISTING CLAIM RECORDS FOUND IN F071-CLIENT-RMA-CLAIM-NBR
//  FILE.
//  MODIFICATION HISTORY
//  DATE    SMS #  WHO     DESCRIPTION
//  93/AUG/31         M. CHAN - ORIGINAL (SMS 142)
//  1999/jan/28         B. E.   - y2k 
//  1999/May/27        S.B.    - Added the use file
//  def_clmhdr_status.def to 
//  prevent hardcoding of clmhdr-status.
//  2000/dec/13 B.E. - don`t update with  R esubmit if the claim is already
//  marked as  deleted  or  ignore 

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U714 : BaseClassControl
{
    private U714 m_U714;
    
    public U714(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public U714(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose()
    {
        if (!(m_U714 == null))
        {
            m_U714.CloseTransactionObjects();
            m_U714 = null;
        }
    }
    
    public U714 GetU714(int Level)
    {
        if ((m_U714 == null))
        {
            m_U714 = new U714("U714", Level);
        }
        else {
            m_U714.ResetValues();
        }
        
        return m_U714;
    }

    #region "Renaissance Architect Migration Services Default Regions"

    #region "Declarations (Variables, Files and Transactions)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.

    protected SqlConnection m_cnnQUERY = new SqlConnection();
    protected SqlConnection m_cnnTRANS_UPDATE = new SqlConnection();
    protected SqlTransaction m_trnTRANS_UPDATE;

    #endregion

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)"

    public override bool RunQTP()
    {
        try
        {
            U714_UPDATE_STATUS_1 UPDATE_STATUS_1 = new U714_UPDATE_STATUS_1(Name, Level);
            UPDATE_STATUS_1.Run();
            UPDATE_STATUS_1.Dispose();
            UPDATE_STATUS_1 = null;

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
public class U714_UPDATE_STATUS_1 : U714
{
    public U714_UPDATE_STATUS_1(string Name, int Level)
        : base(Name, Level, true) {
        this.ScreenType = ScreenTypes.QTP;

        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF071_CLIENT_RMA_CLAIM_NBR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F071_CLIENT_RMA_CLAIM_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF002_SUSPEND_HDR.SetItemFinals += fleF002_SUSPEND_HDR_SetItemFinals;

        CLMHDR_STATUS_COMPLETE.GetValue += CLMHDR_STATUS_COMPLETE_GetValue;
        CLMHDR_STATUS_DELETE.GetValue += CLMHDR_STATUS_DELETE_GetValue;
        CLMHDR_STATUS_CANCEL.GetValue += CLMHDR_STATUS_CANCEL_GetValue;
        CLMHDR_STATUS_RESUBMIT.GetValue += CLMHDR_STATUS_RESUBMIT_GetValue;
        CLMHDR_STATUS_ERROR.GetValue += CLMHDR_STATUS_ERROR_GetValue;
        CLMHDR_STATUS_NOT_COMPLETE.GetValue += CLMHDR_STATUS_NOT_COMPLETE_GetValue;
        CLMHDR_STATUS_DEFAULT.GetValue += CLMHDR_STATUS_DEFAULT_GetValue;
        UPDATED.GetValue += UPDATED_GetValue;
        CLMHDR_STATUS_IGNOR.GetValue += CLMHDR_STATUS_IGNOR_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(UPDATE_STATUS_1)"

    private SqlFileObject fleF002_SUSPEND_HDR;
    private void fleF002_SUSPEND_HDR_SetItemFinals()
    {
        try
        {
            fleF002_SUSPEND_HDR.set_SetValue("CLMHDR_STATUS", CLMHDR_STATUS_RESUBMIT.Value);
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

    private SqlFileObject fleF071_CLIENT_RMA_CLAIM_NBR;
    
    private DCharacter CLMHDR_STATUS_COMPLETE = new DCharacter("CLMHDR_STATUS_COMPLETE", 1);
    private void CLMHDR_STATUS_COMPLETE_GetValue(ref string Value)
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
    
    private DCharacter CLMHDR_STATUS_DELETE = new DCharacter("CLMHDR_STATUS_DELETE", 1);
    private void CLMHDR_STATUS_DELETE_GetValue(ref string Value)
    {
        try
        {
            Value = "D";
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
    
    private DCharacter CLMHDR_STATUS_CANCEL = new DCharacter("CLMHDR_STATUS_CANCEL", 1);
    private void CLMHDR_STATUS_CANCEL_GetValue(ref string Value)
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
    
    private DCharacter CLMHDR_STATUS_RESUBMIT = new DCharacter("CLMHDR_STATUS_RESUBMIT", 1);
    private void CLMHDR_STATUS_RESUBMIT_GetValue(ref string Value)
    {
        try
        {
            Value = "R";
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
    
    private DCharacter CLMHDR_STATUS_ERROR = new DCharacter("CLMHDR_STATUS_ERROR", 1);
    private void CLMHDR_STATUS_ERROR_GetValue(ref string Value)
    {
        try
        {
            Value = "X";
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
    
    private DCharacter CLMHDR_STATUS_NOT_COMPLETE = new DCharacter("CLMHDR_STATUS_NOT_COMPLETE", 1);
    private void CLMHDR_STATUS_NOT_COMPLETE_GetValue(ref string Value)
    {
        try
        {
            Value = "N";
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
    
    private DCharacter CLMHDR_STATUS_DEFAULT = new DCharacter("CLMHDR_STATUS_DEFAULT", 1);
    private void CLMHDR_STATUS_DEFAULT_GetValue(ref string Value)
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
    
    private DCharacter UPDATED = new DCharacter("UPDATED", 1);
    private void UPDATED_GetValue(ref string Value)
    {
        try
        {
            Value = "U";
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
    
    private DCharacter CLMHDR_STATUS_IGNOR = new DCharacter("CLMHDR_STATUS_IGNOR", 1);
    private void CLMHDR_STATUS_IGNOR_GetValue(ref string Value)
    {
        try
        {
            Value = "I";
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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_DELETE.Value) && QDesign.NULL(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_STATUS")) != QDesign.NULL(CLMHDR_STATUS_IGNOR.Value))
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

    #endregion

    #region "Standard Generated Procedures(UPDATE_STATUS_1)"

    #region "Automatic Item Initialization(UPDATE_STATUS_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(UPDATE_STATUS_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:29 AM
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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF071_CLIENT_RMA_CLAIM_NBR.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(UPDATE_STATUS_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:29 AM
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
            fleF002_SUSPEND_HDR.Dispose();
            fleF071_CLIENT_RMA_CLAIM_NBR.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(UPDATE_STATUS_1)"

    public void Run()
    {
        try
        {
            Request("UPDATE_STATUS_1");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                //  --> GET F002_SUSPEND_HDR <--
                fleF002_SUSPEND_HDR.GetData();
                //  --> End GET F002_SUSPEND_HDR <--

                while (fleF071_CLIENT_RMA_CLAIM_NBR.QTPForMissing("1"))
                {
                    //  --> GET F071_CLIENT_RMA_CLAIM_NBR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(fleF071_CLIENT_RMA_CLAIM_NBR.ElementOwner("CLAIM_NBR_CLIENT")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.ASCII(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR"), 6) + fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                    fleF071_CLIENT_RMA_CLAIM_NBR.GetData(m_strWhere.ToString());
                    //  --> End GET F071_CLIENT_RMA_CLAIM_NBR <--

                    if (Transaction())
                    {
                        if (Select_If())
                        {
                            fleF002_SUSPEND_HDR.OutPut(OutPutType.Update);
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
            EndRequest("UPDATE_STATUS_1");
        }
    }

    #endregion
}
// UPDATE_STATUS_1