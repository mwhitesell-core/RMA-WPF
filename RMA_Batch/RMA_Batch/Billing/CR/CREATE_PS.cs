
#region "Screen Comments"

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class CREATE_PS : BaseClassControl
{
    private CREATE_PS m_CREATE_PS;

    public CREATE_PS(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public CREATE_PS(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if ((m_CREATE_PS != null))
        {
            m_CREATE_PS.CloseTransactionObjects();
            m_CREATE_PS = null;
        }
    }

    public CREATE_PS GetCREATE_PS(int Level)
    {
        if (m_CREATE_PS == null)
        {
            m_CREATE_PS = new CREATE_PS("CREATE_PS", Level);
        }
        else
        {
            m_CREATE_PS.ResetValues();
        }
        return m_CREATE_PS;
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
            CREATE_PS_ONE_1 ONE_1 = new CREATE_PS_ONE_1(Name, Level);
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

public class CREATE_PS_ONE_1 : CREATE_PS
{
    public CREATE_PS_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePORTABLE_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PORTABLE_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        flePORTABLE_CLAIMS_MSTR_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PORTABLE_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR_HDR.Choose += fleF002_CLAIMS_MSTR_HDR_Choose;
    }

    #region "Declarations (Variables, Files and Transactions)(CREATE_PS_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR_HDR;
    private SqlFileObject fleF002_CLAIMS_MSTR_DTL;

    private void fleF002_CLAIMS_MSTR_HDR_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("CLMHDR_BATCH_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField("34D09570"));
            strSQL.Append(" AND ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("CLMHDR_CLAIM_NBR")).Append(" = ");
            strSQL.Append("51");

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

    private SqlFileObject flePORTABLE_CLAIMS_MSTR_HDR;
    private SqlFileObject flePORTABLE_CLAIMS_MSTR_DTL;

    #endregion
    
    #region "Standard Generated Procedures(CREATE_PS_ONE_1)"

    #region "Automatic Item Initialization(CREATE_PS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:07 PM

    #endregion

    #region "Transaction Management Procedures(CREATE_PS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
        fleF002_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_DTL.Transaction = m_trnTRANS_UPDATE;
        flePORTABLE_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        flePORTABLE_CLAIMS_MSTR_DTL.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion
    
    #region "FILE Management Procedures(CREATE_PS_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:05 PM

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
            fleF002_CLAIMS_MSTR_HDR.Dispose();
            fleF002_CLAIMS_MSTR_DTL.Dispose();
            flePORTABLE_CLAIMS_MSTR_HDR.Dispose();
            flePORTABLE_CLAIMS_MSTR_DTL.Dispose();
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
    
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(CREATE_PS_ONE_1)"

    public void Run()
    {
        try
        {
            Request("ONE_1");

            while (fleF002_CLAIMS_MSTR_HDR.QTPForMissing())
            {
                fleF002_CLAIMS_MSTR_HDR.GetData();

                while (fleF002_CLAIMS_MSTR_DTL.QTPForMissing("1"))
                {
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR_HDR.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" AND ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("KEY_CLM_CLAIM_NBR"));

                    fleF002_CLAIMS_MSTR_DTL.GetData(m_strWhere.ToString());

                    if (Transaction())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, ref flePORTABLE_CLAIMS_MSTR_HDR, SubFileType.Portable, fleF002_CLAIMS_MSTR_HDR);
                        SubFile(ref m_trnTRANS_UPDATE, ref flePORTABLE_CLAIMS_MSTR_DTL, SubFileType.Portable, fleF002_CLAIMS_MSTR_DTL);
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
            EndRequest("ONE_1");
        }
    }

    #endregion
}
//ONE_1
