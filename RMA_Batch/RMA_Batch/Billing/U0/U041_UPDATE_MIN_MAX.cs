#region "Screen Comments"

//  Program:
//  Purpose: when the MOH releases new fees u041.cbl updates a- and h- fee-1/2 but it doens`t look at min/max values
//  this program will update any code that already have min/max defined if the new fee $ don`t match them min max
//  This is SIMPLISTIC solution in that the min/max may be multiples of the base fee but it works in 2010

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U041_UPDATE_MIN_MAX : BaseClassControl 
{
    private U041_UPDATE_MIN_MAX m_U041_UPDATE_MIN_MAX;
    
    public U041_UPDATE_MIN_MAX(string Name, int Level) : 
            base(Name, Level) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public U041_UPDATE_MIN_MAX(string Name, int Level, bool Request) : 
            base(Name, Level, Request) 
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose() 
    {
        if (!(m_U041_UPDATE_MIN_MAX == null)) 
        {
            m_U041_UPDATE_MIN_MAX.CloseTransactionObjects();
            m_U041_UPDATE_MIN_MAX = null;
        }
    }
    
    public U041_UPDATE_MIN_MAX GetU041_UPDATE_MIN_MAX(int Level) 
    {
        if ((m_U041_UPDATE_MIN_MAX == null)) 
        {
            m_U041_UPDATE_MIN_MAX = new U041_UPDATE_MIN_MAX("U041_UPDATE_MIN_MAX", Level);
        }
        else 
        {
            m_U041_UPDATE_MIN_MAX.ResetValues();
        }
        
        return m_U041_UPDATE_MIN_MAX;
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
            U041_UPDATE_MIN_MAX_ONE_1 ONE_1 = new U041_UPDATE_MIN_MAX_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

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

public class U041_UPDATE_MIN_MAX_ONE_1 : U041_UPDATE_MIN_MAX
{
    public U041_UPDATE_MIN_MAX_ONE_1(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");

        fleF040_OMA_FEE_MSTR.SetItemFinals += fleF040_OMA_FEE_MSTR_SetItemFinals;
    }

    #region "Declarations (Variables, Files and Transactions)(COSTING6_NOWEB_COSTING5_1_2)"

    private SqlFileObject fleF040_OMA_FEE_MSTR;
    
    private void fleF040_OMA_FEE_MSTR_SetItemFinals() 
    {
        try 
        {
            fleF040_OMA_FEE_MSTR.set_SetValue("FEE_CURR_H_MIN", fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_FEE_1"));
            fleF040_OMA_FEE_MSTR.set_SetValue("FEE_CURR_H_MAX", fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_FEE_1"));
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

    private DDecimal X_20_PERCENT = new DDecimal("X_20_PERCENT", 6);
    
    private void X_20_PERCENT_GetValue(ref Decimal Value) 
    {

        try 
        {
            Value = fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_MIN") * 2;
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
    
    private DDecimal X_TEST_AMT = new DDecimal("X_TEST_AMT", 6);
    
    private void X_TEST_AMT_GetValue(ref Decimal Value) 
    {
        try 
        {
            Value = (fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_MIN") + X_20_PERCENT.Value);
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
    
    private DCharacter X_FLAG = new DCharacter("X_FLAG", 1);
    
    private void X_FLAG_GetValue(ref string Value) 
    {
        try 
        {
            string CurrentValue = String.Empty;

            if (QDesign.NULL(X_TEST_AMT.Value) < QDesign.NULL(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_A_FEE_1")) && QDesign.NULL(fleF040_OMA_FEE_MSTR.GetStringValue("FEE_OMA_CD_LTR1")) + QDesign.ASCII(fleF040_OMA_FEE_MSTR.GetDecimalValue("FILLER_NUMERIC")) != "C183")
            {
                CurrentValue = "*";
            }
            else 
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
    
    public override bool SelectIf() 
    {
        try 
        {
            if (QDesign.NULL(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_A_FEE_1")) == QDesign.NULL(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_FEE_1")) && QDesign.NULL(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_MIN")) != QDesign.NULL(0d) && QDesign.NULL(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_MAX")) != QDesign.NULL(0d) && QDesign.NULL(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_MIN")) == QDesign.NULL(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_MAX")) && QDesign.NULL(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_A_FEE_1")) != QDesign.NULL(fleF040_OMA_FEE_MSTR.GetDecimalValue("FEE_CURR_H_MIN")) && QDesign.NULL(X_FLAG.Value) != "*") 
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

    #region "Standard Generated Procedures(U041_UPDATE_MIN_MAX)"

    #region "Automatic Item Initialization(U041_UPDATE_MIN_MAX)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(U041_UPDATE_MIN_MAX)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:00 PM

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
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(U041_UPDATE_MIN_MAX)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:00 PM

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
            fleF040_OMA_FEE_MSTR.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U041_UPDATE_MIN_MAX)"

     public void Run() 
     {
        try 
        {
            Request("ONE_1");

            while (fleF040_OMA_FEE_MSTR.QTPForMissing()) 
            {
                //  --> GET F040_OMA_FEE_MSTR <--
                fleF040_OMA_FEE_MSTR.GetData();
                //  --> End GET F040_OMA_FEE_MSTR <--

                if (Transaction()) 
                {
                    if (Select_If()) 
                    {
                        fleF040_OMA_FEE_MSTR.OutPut(OutPutType.Update);
                        // Parent:FEE_OMA_CD
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
            EndRequest("U041_UPDATE_MIN_MAX");
        }
    }

    #endregion   
}