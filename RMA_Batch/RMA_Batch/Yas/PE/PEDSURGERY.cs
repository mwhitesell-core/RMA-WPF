
#region "Screen Comments"

// doc     : afp_pedsurgery
// purpose : create report for AFP ped surgery docs                       
// by doctor by month by agent (0and4)seperate HCP and RMA for 0/4, 
// 2, 6 and 9 include  B  adjustments and misc payments
// who     : send to Dr. Cameron, Walton , Fitzgerald, Hollenburg
// *************************************************************
// Date  Who  Description
// 2003/10/10 Yasemin         original
// 2004/01/13 Yasemin         modify it jan - dec 2004
// 2005/01/31     Yas  modify for jan-dec 2005
// 2006/02/20     Yas  modify for jan-dec 2006
// 2007/09/25     MC  modify the first request not to select `B  Adjustment
// or `Misc` Payment
// 2009/02/11     yas             modify for 2009
// 2010/02/17     yas             modify for 2010  - comment out Dr. Al-Harbi terminated
// 2011/02/17     yas             modify for 2011  
// 2012/01/05     yas             modify for 2012
// 2013/08/26     yas             Add new dow 29E Dr. Shawyer as per Dr. Fitzgerald 
// 2015/02/20     yas             modify for 2016 and take out Dr. Shawyer                      
// 2015/03/16     yas  Dr. Cameron will like the report to be from July to June instead of Jan to Dec   
// 2016/08/17     yas  Modify for 2017                                                     

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class PEDSURGERY : BaseClassControl
{
    private PEDSURGERY m_PEDSURGERY;

    public PEDSURGERY(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public PEDSURGERY(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if ((m_PEDSURGERY != null))
        {
            m_PEDSURGERY.CloseTransactionObjects();
            m_PEDSURGERY = null;
        }
    }

    public PEDSURGERY GetPEDSURGERY(int Level)
    {
        if (m_PEDSURGERY == null)
        {
            m_PEDSURGERY = new PEDSURGERY("PEDSURGERY", Level);
        }
        else
        {
            m_PEDSURGERY.ResetValues();
        }
        return m_PEDSURGERY;
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
            PEDSURGERY_ONE_1 ONE_1 = new PEDSURGERY_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            PEDSURGERY_TWO_2 TWO_2 = new PEDSURGERY_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            PEDSURGERY_THREE_3 THREE_3 = new PEDSURGERY_THREE_3(Name, Level);
            THREE_3.Run();
            THREE_3.Dispose();
            THREE_3 = null;

            PEDSURGERY_FOUR_4 FOUR_4 = new PEDSURGERY_FOUR_4(Name, Level);
            FOUR_4.Run();
            FOUR_4.Dispose();
            FOUR_4 = null;

            PEDSURGERY_FIVE_5 FIVE_5 = new PEDSURGERY_FIVE_5(Name, Level);
            FIVE_5.Run();
            FIVE_5.Dispose();
            FIVE_5 = null;

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

public class PEDSURGERY_ONE_1 : PEDSURGERY
{
    public PEDSURGERY_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePEDSURGERY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSURGERY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        X_PAYMENT.GetValue += X_PAYMENT_GetValue;
        X_CLINIC.GetValue += X_CLINIC_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;
    }

    #region "Declarations (Variables, Files and Transactions)(PEDSURGERY_ONE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;
    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_AGENT_CD")).Append(" <> 1 AND ");
            strSQL.Append("((").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" = 'C')))");

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

    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("B"));
            strSQL.Append(" AND (");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("22909%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("91909%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("94909%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("22F54%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("91F54%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("94F54%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("22G44%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("91G44%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("94G44%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("22J31%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("91J31%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("94J31%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("96J31%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("22929%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("91929%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("94929%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("96929%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("22T64%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("91T64%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("94T64%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("2229E%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("9129E%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("9429E%")).Append(")");
            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("00000"));
            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField("0"));

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

    private DCharacter X_PAYMENT = new DCharacter("X_PAYMENT", 3);
    private void X_PAYMENT_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "ON")
            {
                CurrentValue = "HCP";
            }
            else
            {
                CurrentValue = "RMB";
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

    private DCharacter X_CLINIC = new DCharacter("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 2);
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

    private SqlFileObject flePEDSURGERY;

    #endregion
    
    #region "Standard Generated Procedures(PEDSURGERY_ONE_1)"
    
    #region "Automatic Item Initialization(PEDSURGERY_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion
        
    #region "Transaction Management Procedures(PEDSURGERY_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:06 PM

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
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePEDSURGERY.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion
    
    #region "FILE Management Procedures(PEDSURGERY_ONE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:06 PM

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
            fleF002_CLAIMS_MSTR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            flePEDSURGERY.Dispose();
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
    
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PEDSURGERY_ONE_1)"
    
    public void Run()
    {
        try
        {
            Request("ONE_1");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F010_PAT_MSTR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 3, 3))));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--

                        if (Transaction())
                        {
                            SubFile(ref m_trnTRANS_UPDATE, ref flePEDSURGERY, SubFileType.Keep, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_AGENT_CD", "CLMHDR_BATCH_TYPE", "CLMHDR_HOSP", fleF020_DOCTOR_MSTR,
                            "DOC_NAME", X_CLINIC, X_PAYMENT, fleF002_CLAIMS_MSTR, "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", "CLMHDR_SERV_DATE");
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
            EndRequest("ONE_1");
        }
    }

    #endregion
}
//ONE_1

public class PEDSURGERY_TWO_2 : PEDSURGERY
{
    public PEDSURGERY_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePEDSURGERY = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSURGERY", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_JUL_2016_0H = new CoreDecimal("X_JUL_2016_0H", 7, this);
        X_JUL_2016_0R = new CoreDecimal("X_JUL_2016_0R", 7, this);
        X_JUL_2016_2 = new CoreDecimal("X_JUL_2016_2", 7, this);
        X_JUL_2016_6 = new CoreDecimal("X_JUL_2016_6", 7, this);
        X_JUL_2016_9 = new CoreDecimal("X_JUL_2016_9", 7, this);
        X_JUL_2016_P = new CoreDecimal("X_JUL_2016_P", 7, this);
        X_AUG_2016_0H = new CoreDecimal("X_AUG_2016_0H", 7, this);
        X_AUG_2016_0R = new CoreDecimal("X_AUG_2016_0R", 7, this);
        X_AUG_2016_2 = new CoreDecimal("X_AUG_2016_2", 7, this);
        X_AUG_2016_6 = new CoreDecimal("X_AUG_2016_6", 7, this);
        X_AUG_2016_9 = new CoreDecimal("X_AUG_2016_9", 7, this);
        X_AUG_2016_P = new CoreDecimal("X_AUG_2016_P", 7, this);
        X_SEP_2016_0H = new CoreDecimal("X_SEP_2016_0H", 7, this);
        X_SEP_2016_0R = new CoreDecimal("X_SEP_2016_0R", 7, this);
        X_SEP_2016_2 = new CoreDecimal("X_SEP_2016_2", 7, this);
        X_SEP_2016_6 = new CoreDecimal("X_SEP_2016_6", 7, this);
        X_SEP_2016_9 = new CoreDecimal("X_SEP_2016_9", 7, this);
        X_SEP_2016_P = new CoreDecimal("X_SEP_2016_P", 7, this);
        X_OCT_2016_0H = new CoreDecimal("X_OCT_2016_0H", 7, this);
        X_OCT_2016_0R = new CoreDecimal("X_OCT_2016_0R", 7, this);
        X_OCT_2016_2 = new CoreDecimal("X_OCT_2016_2", 7, this);
        X_OCT_2016_6 = new CoreDecimal("X_OCT_2016_6", 7, this);
        X_OCT_2016_9 = new CoreDecimal("X_OCT_2016_9", 7, this);
        X_OCT_2016_P = new CoreDecimal("X_OCT_2016_P", 7, this);
        X_NOV_2016_0H = new CoreDecimal("X_NOV_2016_0H", 7, this);
        X_NOV_2016_0R = new CoreDecimal("X_NOV_2016_0R", 7, this);
        X_NOV_2016_2 = new CoreDecimal("X_NOV_2016_2", 7, this);
        X_NOV_2016_6 = new CoreDecimal("X_NOV_2016_6", 7, this);
        X_NOV_2016_9 = new CoreDecimal("X_NOV_2016_9", 7, this);
        X_NOV_2016_P = new CoreDecimal("X_NOV_2016_P", 7, this);
        X_DEC_2016_0H = new CoreDecimal("X_DEC_2016_0H", 7, this);
        X_DEC_2016_0R = new CoreDecimal("X_DEC_2016_0R", 7, this);
        X_DEC_2016_2 = new CoreDecimal("X_DEC_2016_2", 7, this);
        X_DEC_2016_6 = new CoreDecimal("X_DEC_2016_6", 7, this);
        X_DEC_2016_9 = new CoreDecimal("X_DEC_2016_9", 7, this);
        X_DEC_2016_P = new CoreDecimal("X_DEC_2016_P", 7, this);
        X_JAN_2017_0H = new CoreDecimal("X_JAN_2017_0H", 7, this);
        X_JAN_2017_0R = new CoreDecimal("X_JAN_2017_0R", 7, this);
        X_JAN_2017_2 = new CoreDecimal("X_JAN_2017_2", 7, this);
        X_JAN_2017_6 = new CoreDecimal("X_JAN_2017_6", 7, this);
        X_JAN_2017_9 = new CoreDecimal("X_JAN_2017_9", 7, this);
        X_JAN_2017_P = new CoreDecimal("X_JAN_2017_P", 7, this);
        X_FEB_2017_0H = new CoreDecimal("X_FEB_2017_0H", 7, this);
        X_FEB_2017_0R = new CoreDecimal("X_FEB_2017_0R", 7, this);
        X_FEB_2017_2 = new CoreDecimal("X_FEB_2017_2", 7, this);
        X_FEB_2017_6 = new CoreDecimal("X_FEB_2017_6", 7, this);
        X_FEB_2017_9 = new CoreDecimal("X_FEB_2017_9", 7, this);
        X_FEB_2017_P = new CoreDecimal("X_FEB_2017_P", 7, this);
        X_MAR_2017_0H = new CoreDecimal("X_MAR_2017_0H", 7, this);
        X_MAR_2017_0R = new CoreDecimal("X_MAR_2017_0R", 7, this);
        X_MAR_2017_2 = new CoreDecimal("X_MAR_2017_2", 7, this);
        X_MAR_2017_6 = new CoreDecimal("X_MAR_2017_6", 7, this);
        X_MAR_2017_9 = new CoreDecimal("X_MAR_2017_9", 7, this);
        X_MAR_2017_P = new CoreDecimal("X_MAR_2017_P", 7, this);
        X_APR_2017_0H = new CoreDecimal("X_APR_2017_0H", 7, this);
        X_APR_2017_0R = new CoreDecimal("X_APR_2017_0R", 7, this);
        X_APR_2017_2 = new CoreDecimal("X_APR_2017_2", 7, this);
        X_APR_2017_6 = new CoreDecimal("X_APR_2017_6", 7, this);
        X_APR_2017_9 = new CoreDecimal("X_APR_2017_9", 7, this);
        X_APR_2017_P = new CoreDecimal("X_APR_2017_P", 7, this);
        X_MAY_2017_0H = new CoreDecimal("X_MAY_2017_0H", 7, this);
        X_MAY_2017_0R = new CoreDecimal("X_MAY_2017_0R", 7, this);
        X_MAY_2017_2 = new CoreDecimal("X_MAY_2017_2", 7, this);
        X_MAY_2017_6 = new CoreDecimal("X_MAY_2017_6", 7, this);
        X_MAY_2017_9 = new CoreDecimal("X_MAY_2017_9", 7, this);
        X_MAY_2017_P = new CoreDecimal("X_MAY_2017_P", 7, this);
        X_JUN_2017_0H = new CoreDecimal("X_JUN_2017_0H", 7, this);
        X_JUN_2017_0R = new CoreDecimal("X_JUN_2017_0R", 7, this);
        X_JUN_2017_2 = new CoreDecimal("X_JUN_2017_2", 7, this);
        X_JUN_2017_6 = new CoreDecimal("X_JUN_2017_6", 7, this);
        X_JUN_2017_9 = new CoreDecimal("X_JUN_2017_9", 7, this);
        X_JUN_2017_P = new CoreDecimal("X_JUN_2017_P", 7, this);
        X_TOT_2017_0H = new CoreDecimal("X_TOT_2017_0H", 7, this);
        X_TOT_2017_0R = new CoreDecimal("X_TOT_2017_0R", 7, this);
        X_TOT_2017_2 = new CoreDecimal("X_TOT_2017_2", 7, this);
        X_TOT_2017_6 = new CoreDecimal("X_TOT_2017_6", 7, this);
        X_TOT_2017_9 = new CoreDecimal("X_TOT_2017_9", 7, this);
        X_TOT_2017_P = new CoreDecimal("X_TOT_2017_P", 7, this);
        X_TOT_2017_6_PAY = new CoreDecimal("X_TOT_2017_6_PAY", 7, this);
        flePEDSURGERY1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSURGERY1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_DOC_NBR.GetValue += X_DOC_NBR_GetValue;
        X_YYYYMM.GetValue += X_YYYYMM_GetValue;
        X_CODE.GetValue += X_CODE_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

        fleF002_CLAIMS_MSTR_HDR.SelectIf += fleF002_CLAIMS_MSTR_HDR_SelectIf;
        fleF002_CLAIMS_MSTR_DTL.SelectIf += fleF002_CLAIMS_MSTR_DTL_SelectIf;
    }

    #region "Declarations (Variables, Files and Transactions)(PEDSURGERY_TWO_2)"

    private SqlFileObject flePEDSURGERY;
    private SqlFileObject fleF002_CLAIMS_MSTR_HDR;
    private SqlFileObject fleF002_CLAIMS_MSTR_DTL;

    private void fleF002_CLAIMS_MSTR_HDR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" = 'C')");

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

    private void fleF002_CLAIMS_MSTR_DTL_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (RIGHT('0000' + CONVERT(varchar(4), CLMDTL_SV_YY), 4) + RIGHT('00' + CONVERT(varchar(2), CLMDTL_SV_MM), 2) + RIGHT('00' + CONVERT(varchar(2), CLMDTL_SV_DD), 2) >= '20160701' AND ");
            strSQL.Append("RIGHT('0000' + CONVERT(varchar(4), CLMDTL_SV_YY), 4) + RIGHT('00' + CONVERT(varchar(2), CLMDTL_SV_MM), 2) + RIGHT('00' + CONVERT(varchar(2), CLMDTL_SV_DD), 2) <= '201700630' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_OMA_CD")).Append(" <> '0000' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_OMA_CD")).Append(" <> 'ZZZZ' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_OMA_CD")).Append(" <> 'PAID' AND ");
            strSQL.Append("(").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_ADJ_NBR")).Append(" = 0 OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_ADJ_NBR")).Append(" = 1))");

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

    private DCharacter X_DOC_NBR = new DCharacter("X_DOC_NBR", 3);
    private void X_DOC_NBR_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD") + fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_SUFF") + QDesign.ASCII(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_ADJ_NBR"), 1), 3, 3);
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

    private DCharacter X_YYYYMM = new DCharacter("X_YYYYMM", 6);
    private void X_YYYYMM_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6);
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

    private DCharacter X_CODE = new DCharacter("X_CODE", 4);
    private void X_CODE_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "DHSC" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "AGEP")
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

    private CoreDecimal X_JUL_2016_0H;
    private CoreDecimal X_JUL_2016_0R;
    private CoreDecimal X_JUL_2016_2;
    private CoreDecimal X_JUL_2016_6;
    private CoreDecimal X_JUL_2016_9;
    private CoreDecimal X_JUL_2016_P;
    private CoreDecimal X_AUG_2016_0H;
    private CoreDecimal X_AUG_2016_0R;
    private CoreDecimal X_AUG_2016_2;
    private CoreDecimal X_AUG_2016_6;
    private CoreDecimal X_AUG_2016_9;
    private CoreDecimal X_AUG_2016_P;
    private CoreDecimal X_SEP_2016_0H;
    private CoreDecimal X_SEP_2016_0R;
    private CoreDecimal X_SEP_2016_2;
    private CoreDecimal X_SEP_2016_6;
    private CoreDecimal X_SEP_2016_9;
    private CoreDecimal X_SEP_2016_P;
    private CoreDecimal X_OCT_2016_0H;
    private CoreDecimal X_OCT_2016_0R;
    private CoreDecimal X_OCT_2016_2;
    private CoreDecimal X_OCT_2016_6;
    private CoreDecimal X_OCT_2016_9;
    private CoreDecimal X_OCT_2016_P;
    private CoreDecimal X_NOV_2016_0H;
    private CoreDecimal X_NOV_2016_0R;
    private CoreDecimal X_NOV_2016_2;
    private CoreDecimal X_NOV_2016_6;
    private CoreDecimal X_NOV_2016_9;
    private CoreDecimal X_NOV_2016_P;
    private CoreDecimal X_DEC_2016_0H;
    private CoreDecimal X_DEC_2016_0R;
    private CoreDecimal X_DEC_2016_2;
    private CoreDecimal X_DEC_2016_6;
    private CoreDecimal X_DEC_2016_9;
    private CoreDecimal X_DEC_2016_P;
    private CoreDecimal X_JAN_2017_0H;
    private CoreDecimal X_JAN_2017_0R;
    private CoreDecimal X_JAN_2017_2;
    private CoreDecimal X_JAN_2017_6;
    private CoreDecimal X_JAN_2017_9;
    private CoreDecimal X_JAN_2017_P;
    private CoreDecimal X_FEB_2017_0H;
    private CoreDecimal X_FEB_2017_0R;
    private CoreDecimal X_FEB_2017_2;
    private CoreDecimal X_FEB_2017_6;
    private CoreDecimal X_FEB_2017_9;
    private CoreDecimal X_FEB_2017_P;
    private CoreDecimal X_MAR_2017_0H;
    private CoreDecimal X_MAR_2017_0R;
    private CoreDecimal X_MAR_2017_2;
    private CoreDecimal X_MAR_2017_6;
    private CoreDecimal X_MAR_2017_9;
    private CoreDecimal X_MAR_2017_P;
    private CoreDecimal X_APR_2017_0H;
    private CoreDecimal X_APR_2017_0R;
    private CoreDecimal X_APR_2017_2;
    private CoreDecimal X_APR_2017_6;
    private CoreDecimal X_APR_2017_9;
    private CoreDecimal X_APR_2017_P;
    private CoreDecimal X_MAY_2017_0H;
    private CoreDecimal X_MAY_2017_0R;
    private CoreDecimal X_MAY_2017_2;
    private CoreDecimal X_MAY_2017_6;
    private CoreDecimal X_MAY_2017_9;
    private CoreDecimal X_MAY_2017_P;
    private CoreDecimal X_JUN_2017_0H;
    private CoreDecimal X_JUN_2017_0R;
    private CoreDecimal X_JUN_2017_2;
    private CoreDecimal X_JUN_2017_6;
    private CoreDecimal X_JUN_2017_9;
    private CoreDecimal X_JUN_2017_P;
    private CoreDecimal X_TOT_2017_0H;
    private CoreDecimal X_TOT_2017_0R;
    private CoreDecimal X_TOT_2017_2;
    private CoreDecimal X_TOT_2017_6;
    private CoreDecimal X_TOT_2017_9;
    private CoreDecimal X_TOT_2017_P;
    private CoreDecimal X_TOT_2017_6_PAY;

    private DCharacter COMMA = new DCharacter("COMMA", 1);
    private void COMMA_GetValue(ref string Value)
    {
        try
        {
            Value = "~";
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

    private DInteger X_NUM_CR = new DInteger("X_NUM_CR", 4);
    private void X_NUM_CR_GetValue(ref decimal Value)
    {
        try
        {
            Value = 13;
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

    private DCharacter X_CR = new DCharacter("X_CR", 2);
    private void X_CR_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Characters(X_NUM_CR.Value);
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

    private SqlFileObject flePEDSURGERY1;

    #endregion
    
    #region "Standard Generated Procedures(PEDSURGERY_TWO_2)"
    
    #region "Automatic Item Initialization(PEDSURGERY_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion
        
    #region "Transaction Management Procedures(PEDSURGERY_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:06 PM

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
        flePEDSURGERY.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_DTL.Transaction = m_trnTRANS_UPDATE;
        flePEDSURGERY1.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion
    
    #region "FILE Management Procedures(PEDSURGERY_TWO_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:06 PM

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
            flePEDSURGERY.Dispose();
            fleF002_CLAIMS_MSTR_HDR.Dispose();
            fleF002_CLAIMS_MSTR_DTL.Dispose();
            flePEDSURGERY1.Dispose();
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
    
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PEDSURGERY_TWO_2)"
    
    public void Run()
    {
        try
        {
            Request("TWO_2");

            while (flePEDSURGERY.QTPForMissing())
            {
                // --> GET PEDSURGERY <--

                flePEDSURGERY.GetData();
                // --> End GET PEDSURGERY <--

                while (fleF002_CLAIMS_MSTR_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(flePEDSURGERY.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((flePEDSURGERY.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR_HDR <--

                    while (fleF002_CLAIMS_MSTR_DTL.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_MSTR_DTL <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(flePEDSURGERY.GetStringValue("KEY_CLM_BATCH_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((flePEDSURGERY.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                        fleF002_CLAIMS_MSTR_DTL.GetData(m_strWhere.ToString());
                        // --> End GET F002_CLAIMS_MSTR_DTL <--

                        if (Transaction())
                        {
                            Sort(X_DOC_NBR.Value, fleF002_CLAIMS_MSTR_HDR.GetSortValue("KEY_CLM_BATCH_NBR"), fleF002_CLAIMS_MSTR_HDR.GetSortValue("KEY_CLM_CLAIM_NBR"));
                        }
                    }
                }
            }

            while (Sort(flePEDSURGERY, fleF002_CLAIMS_MSTR_HDR, fleF002_CLAIMS_MSTR_DTL))
            {
                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JUL_2016_0H.Value = X_JUL_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JUL_2016_0R.Value = X_JUL_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_JUL_2016_2.Value = X_JUL_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_JUL_2016_6.Value = X_JUL_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_JUL_2016_9.Value = X_JUL_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_JUL_2016_P.Value = X_JUL_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_AUG_2016_0H.Value = X_AUG_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_AUG_2016_0R.Value = X_AUG_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_AUG_2016_2.Value = X_AUG_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_AUG_2016_6.Value = X_AUG_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_AUG_2016_9.Value = X_AUG_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_AUG_2016_P.Value = X_AUG_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_SEP_2016_0H.Value = X_SEP_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_SEP_2016_0R.Value = X_SEP_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_SEP_2016_2.Value = X_SEP_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_SEP_2016_6.Value = X_SEP_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_SEP_2016_9.Value = X_SEP_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_SEP_2016_P.Value = X_SEP_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_OCT_2016_0H.Value = X_OCT_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_OCT_2016_0R.Value = X_OCT_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_OCT_2016_2.Value = X_OCT_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_OCT_2016_6.Value = X_OCT_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_OCT_2016_9.Value = X_OCT_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_OCT_2016_P.Value = X_OCT_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_NOV_2016_0H.Value = X_NOV_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_NOV_2016_0R.Value = X_NOV_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_NOV_2016_2.Value = X_NOV_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_NOV_2016_6.Value = X_NOV_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_NOV_2016_9.Value = X_NOV_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_NOV_2016_P.Value = X_NOV_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_DEC_2016_0H.Value = X_DEC_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_DEC_2016_0R.Value = X_DEC_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_DEC_2016_2.Value = X_DEC_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_DEC_2016_6.Value = X_DEC_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_DEC_2016_9.Value = X_DEC_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_DEC_2016_P.Value = X_DEC_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JAN_2017_0H.Value = X_JAN_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JAN_2017_0R.Value = X_JAN_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_JAN_2017_2.Value = X_JAN_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_JAN_2017_6.Value = X_JAN_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_JAN_2017_9.Value = X_JAN_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_JAN_2017_P.Value = X_JAN_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_FEB_2017_0H.Value = X_FEB_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_FEB_2017_0R.Value = X_FEB_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_FEB_2017_2.Value = X_FEB_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_FEB_2017_6.Value = X_FEB_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_FEB_2017_9.Value = X_FEB_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_FEB_2017_P.Value = X_FEB_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_MAR_2017_0H.Value = X_MAR_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_MAR_2017_0R.Value = X_MAR_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_MAR_2017_2.Value = X_MAR_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_MAR_2017_6.Value = X_MAR_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_MAR_2017_9.Value = X_MAR_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_MAR_2017_P.Value = X_MAR_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_APR_2017_0H.Value = X_APR_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_APR_2017_0R.Value = X_APR_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_APR_2017_2.Value = X_APR_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_APR_2017_6.Value = X_APR_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_APR_2017_9.Value = X_APR_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_APR_2017_P.Value = X_APR_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_MAY_2017_0H.Value = X_MAY_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_MAY_2017_0R.Value = X_MAY_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_MAY_2017_2.Value = X_MAY_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_MAY_2017_6.Value = X_MAY_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_MAY_2017_9.Value = X_MAY_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_MAY_2017_P.Value = X_MAY_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JUN_2017_0H.Value = X_JUN_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JUN_2017_0R.Value = X_JUN_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_JUN_2017_2.Value = X_JUN_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_JUN_2017_6.Value = X_JUN_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_JUN_2017_9.Value = X_JUN_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_JUN_2017_P.Value = X_JUN_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >=0 & string.Compare(X_YYYYMM.Value , "201706")<=0) & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_TOT_2017_0H.Value = X_TOT_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >= 0 & string.Compare(X_YYYYMM.Value, "201706") <= 0) & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_TOT_2017_0R.Value = X_TOT_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >=0 & string.Compare(X_YYYYMM.Value , "201706")<=0) & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_TOT_2017_2.Value = X_TOT_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >=0 & string.Compare(X_YYYYMM.Value , "201706")<=0) & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_TOT_2017_6.Value = X_TOT_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >=0 & string.Compare(X_YYYYMM.Value , "201706")<=0) & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_TOT_2017_9.Value = X_TOT_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >=0 & string.Compare(X_YYYYMM.Value , "201706")<=0) & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_TOT_2017_P.Value = X_TOT_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6)
                {
                    X_TOT_2017_6_PAY.Value = X_TOT_2017_6_PAY.Value + fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS") / 100;
                }

                SubFile(ref m_trnTRANS_UPDATE, ref flePEDSURGERY1, At(X_DOC_NBR), SubFileType.Keep, X_DOC_NBR, COMMA, flePEDSURGERY, "DOC_NAME", COMMA, X_JUL_2016_0H, COMMA, X_JUL_2016_0R, COMMA,
                X_JUL_2016_6, COMMA, X_AUG_2016_0H, COMMA, X_AUG_2016_0R, COMMA, X_AUG_2016_6, COMMA, X_SEP_2016_0H, COMMA, X_SEP_2016_0R, COMMA, X_SEP_2016_6, COMMA, X_OCT_2016_0H, COMMA, X_OCT_2016_0R, COMMA, X_OCT_2016_6, COMMA,
                X_NOV_2016_0H, COMMA, X_NOV_2016_0R, COMMA, X_NOV_2016_6, COMMA, X_DEC_2016_0H, COMMA, X_DEC_2016_0R, COMMA, X_DEC_2016_6, COMMA, X_JAN_2017_0H, COMMA, X_JAN_2017_0R, COMMA, X_JAN_2017_6, COMMA, X_FEB_2017_0H, COMMA,
                X_FEB_2017_0R, COMMA, X_FEB_2017_6, COMMA, X_MAR_2017_0H, COMMA, X_MAR_2017_0R, COMMA, X_MAR_2017_6, COMMA, X_APR_2017_0H, COMMA, X_APR_2017_0R, COMMA, X_APR_2017_6, COMMA, X_MAY_2017_0H, COMMA, X_MAY_2017_0R, COMMA,
                X_MAY_2017_6, COMMA, X_JUN_2017_0H, COMMA, X_JUN_2017_0R, COMMA, X_JUN_2017_6, COMMA, X_TOT_2017_0H, COMMA, X_TOT_2017_0R, COMMA, X_TOT_2017_6, COMMA, X_TOT_2017_6_PAY, COMMA, X_TOT_2017_2, COMMA, X_TOT_2017_9, COMMA,
                X_TOT_2017_P);

                Reset(ref X_JUL_2016_0H, At(X_DOC_NBR));
                Reset(ref X_JUL_2016_0R, At(X_DOC_NBR));
                Reset(ref X_JUL_2016_2, At(X_DOC_NBR));
                Reset(ref X_JUL_2016_6, At(X_DOC_NBR));
                Reset(ref X_JUL_2016_9, At(X_DOC_NBR));
                Reset(ref X_JUL_2016_P, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_0H, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_0R, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_2, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_6, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_9, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_P, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_0H, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_0R, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_2, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_6, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_9, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_P, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_0H, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_0R, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_2, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_6, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_9, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_P, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_0H, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_0R, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_2, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_6, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_9, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_P, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_0H, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_0R, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_2, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_6, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_9, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_P, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_0H, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_0R, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_2, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_6, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_9, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_P, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_0H, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_0R, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_2, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_6, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_9, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_P, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_0H, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_0R, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_2, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_6, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_9, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_P, At(X_DOC_NBR));
                Reset(ref X_APR_2017_0H, At(X_DOC_NBR));
                Reset(ref X_APR_2017_0R, At(X_DOC_NBR));
                Reset(ref X_APR_2017_2, At(X_DOC_NBR));
                Reset(ref X_APR_2017_6, At(X_DOC_NBR));
                Reset(ref X_APR_2017_9, At(X_DOC_NBR));
                Reset(ref X_APR_2017_P, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_0H, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_0R, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_2, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_6, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_9, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_P, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_0H, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_0R, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_2, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_6, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_9, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_P, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_0H, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_0R, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_2, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_6, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_9, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_P, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_6_PAY, At(X_DOC_NBR));
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
            EndRequest("TWO_2");
        }
    }

    #endregion
}
//TWO_2

public class PEDSURGERY_THREE_3 : PEDSURGERY
{
    public PEDSURGERY_THREE_3(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        flePEDSURGERY2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSURGERY2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        X_PAYMENT.GetValue += X_PAYMENT_GetValue;
        X_CLINIC.GetValue += X_CLINIC_GetValue;

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;
    }

    #region "Declarations (Variables, Files and Transactions)(PEDSURGERY_THREE_3)"

    private SqlFileObject fleF002_CLAIMS_MSTR;
    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_AGENT_CD")).Append(" <> 1 AND ");
            strSQL.Append("((").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" = 'C')))");

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

    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;

    private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("B"));
            strSQL.Append(" AND (");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("98909%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("98F54%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("98G44%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("98J31%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("98929%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("98T64%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("9829E%")).Append(")");
            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
            strSQL.Append(Common.StringToField("00000"));
            strSQL.Append(" AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_ADJ_NBR")).Append(" = ");
            strSQL.Append(Common.StringToField("0"));

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

    private DCharacter X_PAYMENT = new DCharacter("X_PAYMENT", 3);
    private void X_PAYMENT_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_PROV_CD")) == "ON")
            {
                CurrentValue = "HCP";
            }
            else
            {
                CurrentValue = "RMB";
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

    private DCharacter X_CLINIC = new DCharacter("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 1, 2);
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

    private SqlFileObject flePEDSURGERY2;

    #endregion
    
    #region "Standard Generated Procedures(PEDSURGERY_THREE_3)"
    
    #region "Automatic Item Initialization(PEDSURGERY_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(PEDSURGERY_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:07 PM

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
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        flePEDSURGERY2.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion
    
    #region "FILE Management Procedures(PEDSURGERY_THREE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:07 PM

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
            fleF002_CLAIMS_MSTR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            flePEDSURGERY2.Dispose();
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
    
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PEDSURGERY_THREE_3)"
    
    public void Run()
    {
        try
        {
            Request("THREE_3");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                // --> GET F002_CLAIMS_MSTR <--

                fleF002_CLAIMS_MSTR.GetData();
                // --> End GET F002_CLAIMS_MSTR <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F010_PAT_MSTR <--

                    while (fleF020_DOCTOR_MSTR.QTPForMissing("2"))
                    {
                        // --> GET F020_DOCTOR_MSTR <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField((QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR"), 3, 3))));

                        fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET F020_DOCTOR_MSTR <--


                        if (Transaction())
                        {
                            SubFile(ref m_trnTRANS_UPDATE, ref flePEDSURGERY2, SubFileType.Keep, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_AGENT_CD", "CLMHDR_BATCH_TYPE", "CLMHDR_HOSP", fleF020_DOCTOR_MSTR,
                            "DOC_NAME", X_CLINIC, X_PAYMENT, fleF002_CLAIMS_MSTR, "CLMHDR_MANUAL_AND_TAPE_PAYMENTS", "CLMHDR_SERV_DATE");
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
            EndRequest("THREE_3");
        }
    }

    #endregion
}
//THREE_3

public class PEDSURGERY_FOUR_4 : PEDSURGERY
{
    public PEDSURGERY_FOUR_4(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePEDSURGERY2 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSURGERY2", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_CLAIMS_MSTR_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_JUL_2016_0H = new CoreDecimal("X_JUL_2016_0H", 7, this);
        X_JUL_2016_0R = new CoreDecimal("X_JUL_2016_0R", 7, this);
        X_JUL_2016_2 = new CoreDecimal("X_JUL_2016_2", 7, this);
        X_JUL_2016_6 = new CoreDecimal("X_JUL_2016_6", 7, this);
        X_JUL_2016_9 = new CoreDecimal("X_JUL_2016_9", 7, this);
        X_JUL_2016_P = new CoreDecimal("X_JUL_2016_P", 7, this);
        X_AUG_2016_0H = new CoreDecimal("X_AUG_2016_0H", 7, this);
        X_AUG_2016_0R = new CoreDecimal("X_AUG_2016_0R", 7, this);
        X_AUG_2016_2 = new CoreDecimal("X_AUG_2016_2", 7, this);
        X_AUG_2016_6 = new CoreDecimal("X_AUG_2016_6", 7, this);
        X_AUG_2016_9 = new CoreDecimal("X_AUG_2016_9", 7, this);
        X_AUG_2016_P = new CoreDecimal("X_AUG_2016_P", 7, this);
        X_SEP_2016_0H = new CoreDecimal("X_SEP_2016_0H", 7, this);
        X_SEP_2016_0R = new CoreDecimal("X_SEP_2016_0R", 7, this);
        X_SEP_2016_2 = new CoreDecimal("X_SEP_2016_2", 7, this);
        X_SEP_2016_6 = new CoreDecimal("X_SEP_2016_6", 7, this);
        X_SEP_2016_9 = new CoreDecimal("X_SEP_2016_9", 7, this);
        X_SEP_2016_P = new CoreDecimal("X_SEP_2016_P", 7, this);
        X_OCT_2016_0H = new CoreDecimal("X_OCT_2016_0H", 7, this);
        X_OCT_2016_0R = new CoreDecimal("X_OCT_2016_0R", 7, this);
        X_OCT_2016_2 = new CoreDecimal("X_OCT_2016_2", 7, this);
        X_OCT_2016_6 = new CoreDecimal("X_OCT_2016_6", 7, this);
        X_OCT_2016_9 = new CoreDecimal("X_OCT_2016_9", 7, this);
        X_OCT_2016_P = new CoreDecimal("X_OCT_2016_P", 7, this);
        X_NOV_2016_0H = new CoreDecimal("X_NOV_2016_0H", 7, this);
        X_NOV_2016_0R = new CoreDecimal("X_NOV_2016_0R", 7, this);
        X_NOV_2016_2 = new CoreDecimal("X_NOV_2016_2", 7, this);
        X_NOV_2016_6 = new CoreDecimal("X_NOV_2016_6", 7, this);
        X_NOV_2016_9 = new CoreDecimal("X_NOV_2016_9", 7, this);
        X_NOV_2016_P = new CoreDecimal("X_NOV_2016_P", 7, this);
        X_DEC_2016_0H = new CoreDecimal("X_DEC_2016_0H", 7, this);
        X_DEC_2016_0R = new CoreDecimal("X_DEC_2016_0R", 7, this);
        X_DEC_2016_2 = new CoreDecimal("X_DEC_2016_2", 7, this);
        X_DEC_2016_6 = new CoreDecimal("X_DEC_2016_6", 7, this);
        X_DEC_2016_9 = new CoreDecimal("X_DEC_2016_9", 7, this);
        X_DEC_2016_P = new CoreDecimal("X_DEC_2016_P", 7, this);
        X_JAN_2017_0H = new CoreDecimal("X_JAN_2017_0H", 7, this);
        X_JAN_2017_0R = new CoreDecimal("X_JAN_2017_0R", 7, this);
        X_JAN_2017_2 = new CoreDecimal("X_JAN_2017_2", 7, this);
        X_JAN_2017_6 = new CoreDecimal("X_JAN_2017_6", 7, this);
        X_JAN_2017_9 = new CoreDecimal("X_JAN_2017_9", 7, this);
        X_JAN_2017_P = new CoreDecimal("X_JAN_2017_P", 7, this);
        X_FEB_2017_0H = new CoreDecimal("X_FEB_2017_0H", 7, this);
        X_FEB_2017_0R = new CoreDecimal("X_FEB_2017_0R", 7, this);
        X_FEB_2017_2 = new CoreDecimal("X_FEB_2017_2", 7, this);
        X_FEB_2017_6 = new CoreDecimal("X_FEB_2017_6", 7, this);
        X_FEB_2017_9 = new CoreDecimal("X_FEB_2017_9", 7, this);
        X_FEB_2017_P = new CoreDecimal("X_FEB_2017_P", 7, this);
        X_MAR_2017_0H = new CoreDecimal("X_MAR_2017_0H", 7, this);
        X_MAR_2017_0R = new CoreDecimal("X_MAR_2017_0R", 7, this);
        X_MAR_2017_2 = new CoreDecimal("X_MAR_2017_2", 7, this);
        X_MAR_2017_6 = new CoreDecimal("X_MAR_2017_6", 7, this);
        X_MAR_2017_9 = new CoreDecimal("X_MAR_2017_9", 7, this);
        X_MAR_2017_P = new CoreDecimal("X_MAR_2017_P", 7, this);
        X_APR_2017_0H = new CoreDecimal("X_APR_2017_0H", 7, this);
        X_APR_2017_0R = new CoreDecimal("X_APR_2017_0R", 7, this);
        X_APR_2017_2 = new CoreDecimal("X_APR_2017_2", 7, this);
        X_APR_2017_6 = new CoreDecimal("X_APR_2017_6", 7, this);
        X_APR_2017_9 = new CoreDecimal("X_APR_2017_9", 7, this);
        X_APR_2017_P = new CoreDecimal("X_APR_2017_P", 7, this);
        X_MAY_2017_0H = new CoreDecimal("X_MAY_2017_0H", 7, this);
        X_MAY_2017_0R = new CoreDecimal("X_MAY_2017_0R", 7, this);
        X_MAY_2017_2 = new CoreDecimal("X_MAY_2017_2", 7, this);
        X_MAY_2017_6 = new CoreDecimal("X_MAY_2017_6", 7, this);
        X_MAY_2017_9 = new CoreDecimal("X_MAY_2017_9", 7, this);
        X_MAY_2017_P = new CoreDecimal("X_MAY_2017_P", 7, this);
        X_JUN_2017_0H = new CoreDecimal("X_JUN_2017_0H", 7, this);
        X_JUN_2017_0R = new CoreDecimal("X_JUN_2017_0R", 7, this);
        X_JUN_2017_2 = new CoreDecimal("X_JUN_2017_2", 7, this);
        X_JUN_2017_6 = new CoreDecimal("X_JUN_2017_6", 7, this);
        X_JUN_2017_9 = new CoreDecimal("X_JUN_2017_9", 7, this);
        X_JUN_2017_P = new CoreDecimal("X_JUN_2017_P", 7, this);
        X_TOT_2017_0H = new CoreDecimal("X_TOT_2017_0H", 7, this);
        X_TOT_2017_0R = new CoreDecimal("X_TOT_2017_0R", 7, this);
        X_TOT_2017_2 = new CoreDecimal("X_TOT_2017_2", 7, this);
        X_TOT_2017_6 = new CoreDecimal("X_TOT_2017_6", 7, this);
        X_TOT_2017_9 = new CoreDecimal("X_TOT_2017_9", 7, this);
        X_TOT_2017_P = new CoreDecimal("X_TOT_2017_P", 7, this);
        X_TOT_2017_6_PAY = new CoreDecimal("X_TOT_2017_6_PAY", 7, this);
        flePEDSURGERY1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSURGERY1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_DOC_NBR.GetValue += X_DOC_NBR_GetValue;
        X_YYYYMM.GetValue += X_YYYYMM_GetValue;
        X_CODE.GetValue += X_CODE_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;

        fleF002_CLAIMS_MSTR_DTL.SelectIf += fleF002_CLAIMS_MSTR_DTL_SelectIf;
    }

    #region "Declarations (Variables, Files and Transactions)(PEDSURGERY_FOUR_4)"

    private SqlFileObject flePEDSURGERY2;
    private SqlFileObject fleF002_CLAIMS_MSTR_HDR;

    private SqlFileObject fleF002_CLAIMS_MSTR_DTL;
    private void fleF002_CLAIMS_MSTR_DTL_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_SV_YY")).Append(" >= 2016 AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_SV_MM")).Append(" >= 7 AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_SV_DD")).Append(" >= 1 AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_SV_YY")).Append(" <= 2017 AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_SV_MM")).Append(" <= 6 AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_SV_DD")).Append(" <= 30 AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_OMA_CD")).Append(" <> '0000' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_OMA_CD")).Append(" <> 'ZZZZ' AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_OMA_CD")).Append(" <> 'PAID' AND ");
            strSQL.Append("(").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("CLMDTL_ADJ_NBR")).Append(" = 0 AND ");
            strSQL.Append(Common.StringToField(flePEDSURGERY2.GetStringValue("CLMHDR_BATCH_TYPE"))).Append(" = 'C'))");

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

    private DCharacter X_DOC_NBR = new DCharacter("X_DOC_NBR", 3);
    private void X_DOC_NBR_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD") + fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_SUFF") + QDesign.ASCII(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_ADJ_NBR"), 1), 3, 3);
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

    private DCharacter X_YYYYMM = new DCharacter("X_YYYYMM", 6);
    private void X_YYYYMM_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6);
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

    private DCharacter X_CODE = new DCharacter("X_CODE", 4);
    private void X_CODE_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "MICM" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "MISJ" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "MISC" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "MICV" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "MISP" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "MICB" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "MIBR" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "MINH" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "MHSC" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "NHSC" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "DHSC" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "MOHR" | QDesign.NULL(fleF002_CLAIMS_MSTR_DTL.GetStringValue("CLMDTL_OMA_CD")) == "AGEP")
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

    private CoreDecimal X_JUL_2016_0H;
    private CoreDecimal X_JUL_2016_0R;
    private CoreDecimal X_JUL_2016_2;
    private CoreDecimal X_JUL_2016_6;
    private CoreDecimal X_JUL_2016_9;
    private CoreDecimal X_JUL_2016_P;
    private CoreDecimal X_AUG_2016_0H;
    private CoreDecimal X_AUG_2016_0R;
    private CoreDecimal X_AUG_2016_2;
    private CoreDecimal X_AUG_2016_6;
    private CoreDecimal X_AUG_2016_9;
    private CoreDecimal X_AUG_2016_P;
    private CoreDecimal X_SEP_2016_0H;
    private CoreDecimal X_SEP_2016_0R;
    private CoreDecimal X_SEP_2016_2;
    private CoreDecimal X_SEP_2016_6;
    private CoreDecimal X_SEP_2016_9;
    private CoreDecimal X_SEP_2016_P;
    private CoreDecimal X_OCT_2016_0H;
    private CoreDecimal X_OCT_2016_0R;
    private CoreDecimal X_OCT_2016_2;
    private CoreDecimal X_OCT_2016_6;
    private CoreDecimal X_OCT_2016_9;
    private CoreDecimal X_OCT_2016_P;
    private CoreDecimal X_NOV_2016_0H;
    private CoreDecimal X_NOV_2016_0R;
    private CoreDecimal X_NOV_2016_2;
    private CoreDecimal X_NOV_2016_6;
    private CoreDecimal X_NOV_2016_9;
    private CoreDecimal X_NOV_2016_P;
    private CoreDecimal X_DEC_2016_0H;
    private CoreDecimal X_DEC_2016_0R;
    private CoreDecimal X_DEC_2016_2;
    private CoreDecimal X_DEC_2016_6;
    private CoreDecimal X_DEC_2016_9;
    private CoreDecimal X_DEC_2016_P;
    private CoreDecimal X_JAN_2017_0H;
    private CoreDecimal X_JAN_2017_0R;
    private CoreDecimal X_JAN_2017_2;
    private CoreDecimal X_JAN_2017_6;
    private CoreDecimal X_JAN_2017_9;
    private CoreDecimal X_JAN_2017_P;
    private CoreDecimal X_FEB_2017_0H;
    private CoreDecimal X_FEB_2017_0R;
    private CoreDecimal X_FEB_2017_2;
    private CoreDecimal X_FEB_2017_6;
    private CoreDecimal X_FEB_2017_9;
    private CoreDecimal X_FEB_2017_P;
    private CoreDecimal X_MAR_2017_0H;
    private CoreDecimal X_MAR_2017_0R;
    private CoreDecimal X_MAR_2017_2;
    private CoreDecimal X_MAR_2017_6;
    private CoreDecimal X_MAR_2017_9;
    private CoreDecimal X_MAR_2017_P;
    private CoreDecimal X_APR_2017_0H;
    private CoreDecimal X_APR_2017_0R;
    private CoreDecimal X_APR_2017_2;
    private CoreDecimal X_APR_2017_6;
    private CoreDecimal X_APR_2017_9;
    private CoreDecimal X_APR_2017_P;
    private CoreDecimal X_MAY_2017_0H;
    private CoreDecimal X_MAY_2017_0R;
    private CoreDecimal X_MAY_2017_2;
    private CoreDecimal X_MAY_2017_6;
    private CoreDecimal X_MAY_2017_9;
    private CoreDecimal X_MAY_2017_P;
    private CoreDecimal X_JUN_2017_0H;
    private CoreDecimal X_JUN_2017_0R;
    private CoreDecimal X_JUN_2017_2;
    private CoreDecimal X_JUN_2017_6;
    private CoreDecimal X_JUN_2017_9;
    private CoreDecimal X_JUN_2017_P;
    private CoreDecimal X_TOT_2017_0H;
    private CoreDecimal X_TOT_2017_0R;
    private CoreDecimal X_TOT_2017_2;
    private CoreDecimal X_TOT_2017_6;
    private CoreDecimal X_TOT_2017_9;
    private CoreDecimal X_TOT_2017_P;
    private CoreDecimal X_TOT_2017_6_PAY;

    private DCharacter COMMA = new DCharacter("COMMA", 1);
    private void COMMA_GetValue(ref string Value)
    {
        try
        {
            Value = "~";
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

    private DInteger X_NUM_CR = new DInteger("X_NUM_CR", 4);
    private void X_NUM_CR_GetValue(ref decimal Value)
    {
        try
        {
            Value = 13;
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

    private DCharacter X_CR = new DCharacter("X_CR", 2);
    private void X_CR_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Characters(X_NUM_CR.Value);
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

    private SqlFileObject flePEDSURGERY1;

    #endregion
    
    #region "Standard Generated Procedures(PEDSURGERY_FOUR_4)"
    
    #region "Automatic Item Initialization(PEDSURGERY_FOUR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion
        
    #region "Transaction Management Procedures(PEDSURGERY_FOUR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:07 PM

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
        flePEDSURGERY2.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR_DTL.Transaction = m_trnTRANS_UPDATE;
        flePEDSURGERY1.Transaction = m_trnTRANS_UPDATE;
    }
    
    #endregion

    #region "FILE Management Procedures(PEDSURGERY_FOUR_4)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:07 PM

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
            flePEDSURGERY2.Dispose();
            fleF002_CLAIMS_MSTR_HDR.Dispose();
            fleF002_CLAIMS_MSTR_DTL.Dispose();
            flePEDSURGERY1.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PEDSURGERY_FOUR_4)"
    
    public void Run()
    {
        try
        {
            Request("FOUR_4");

            while (flePEDSURGERY2.QTPForMissing())
            {
                // --> GET PEDSURGERY2 <--

                flePEDSURGERY2.GetData();
                // --> End GET PEDSURGERY2 <--

                while (fleF002_CLAIMS_MSTR_HDR.QTPForMissing("1"))
                {
                    // --> GET F002_CLAIMS_MSTR_HDR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(flePEDSURGERY2.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_HDR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append((flePEDSURGERY2.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                    fleF002_CLAIMS_MSTR_HDR.GetData(m_strWhere.ToString());
                    // --> End GET F002_CLAIMS_MSTR_HDR <--

                    while (fleF002_CLAIMS_MSTR_DTL.QTPForMissing("2"))
                    {
                        // --> GET F002_CLAIMS_MSTR_DTL <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                        m_strWhere.Append(Common.StringToField("B"));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(flePEDSURGERY2.GetStringValue("KEY_CLM_BATCH_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR_DTL.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                        m_strWhere.Append((flePEDSURGERY2.GetDecimalValue("KEY_CLM_CLAIM_NBR")));

                        fleF002_CLAIMS_MSTR_DTL.GetData(m_strWhere.ToString());
                        // --> End GET F002_CLAIMS_MSTR_DTL <--

                        if (Transaction())
                        {
                            Sort(X_DOC_NBR.Value, fleF002_CLAIMS_MSTR_HDR.GetSortValue("KEY_CLM_BATCH_NBR"), fleF002_CLAIMS_MSTR_HDR.GetSortValue("KEY_CLM_CLAIM_NBR"));
                        }
                    }
                }
            }

            while (Sort(flePEDSURGERY2, fleF002_CLAIMS_MSTR_HDR, fleF002_CLAIMS_MSTR_DTL))
            {
                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JUL_2016_0H.Value = X_JUL_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JUL_2016_0R.Value = X_JUL_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_JUL_2016_2.Value = X_JUL_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_JUL_2016_6.Value = X_JUL_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_JUL_2016_9.Value = X_JUL_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201607" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_JUL_2016_P.Value = X_JUL_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_AUG_2016_0H.Value = X_AUG_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_AUG_2016_0R.Value = X_AUG_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_AUG_2016_2.Value = X_AUG_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_AUG_2016_6.Value = X_AUG_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_AUG_2016_9.Value = X_AUG_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201608" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_AUG_2016_P.Value = X_AUG_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_SEP_2016_0H.Value = X_SEP_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_SEP_2016_0R.Value = X_SEP_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_SEP_2016_2.Value = X_SEP_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_SEP_2016_6.Value = X_SEP_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_SEP_2016_9.Value = X_SEP_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201609" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_SEP_2016_P.Value = X_SEP_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_OCT_2016_0H.Value = X_OCT_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_OCT_2016_0R.Value = X_OCT_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_OCT_2016_2.Value = X_OCT_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_OCT_2016_6.Value = X_OCT_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_OCT_2016_9.Value = X_OCT_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201610" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_OCT_2016_P.Value = X_OCT_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_NOV_2016_0H.Value = X_NOV_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_NOV_2016_0R.Value = X_NOV_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_NOV_2016_2.Value = X_NOV_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_NOV_2016_6.Value = X_NOV_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_NOV_2016_9.Value = X_NOV_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201611" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_NOV_2016_P.Value = X_NOV_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_DEC_2016_0H.Value = X_DEC_2016_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_DEC_2016_0R.Value = X_DEC_2016_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_DEC_2016_2.Value = X_DEC_2016_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_DEC_2016_6.Value = X_DEC_2016_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_DEC_2016_9.Value = X_DEC_2016_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201612" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_DEC_2016_P.Value = X_DEC_2016_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JAN_2017_0H.Value = X_JAN_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JAN_2017_0R.Value = X_JAN_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_JAN_2017_2.Value = X_JAN_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_JAN_2017_6.Value = X_JAN_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_JAN_2017_9.Value = X_JAN_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201701" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_JAN_2017_P.Value = X_JAN_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_FEB_2017_0H.Value = X_FEB_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_FEB_2017_0R.Value = X_FEB_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_FEB_2017_2.Value = X_FEB_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_FEB_2017_6.Value = X_FEB_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_FEB_2017_9.Value = X_FEB_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201702" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_FEB_2017_P.Value = X_FEB_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_MAR_2017_0H.Value = X_MAR_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_MAR_2017_0R.Value = X_MAR_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_MAR_2017_2.Value = X_MAR_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_MAR_2017_6.Value = X_MAR_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_MAR_2017_9.Value = X_MAR_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201703" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_MAR_2017_P.Value = X_MAR_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_APR_2017_0H.Value = X_APR_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_APR_2017_0R.Value = X_APR_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_APR_2017_2.Value = X_APR_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_APR_2017_6.Value = X_APR_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_APR_2017_9.Value = X_APR_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201704" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_APR_2017_P.Value = X_APR_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_MAY_2017_0H.Value = X_MAY_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_MAY_2017_0R.Value = X_MAY_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_MAY_2017_2.Value = X_MAY_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_MAY_2017_6.Value = X_MAY_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_MAY_2017_9.Value = X_MAY_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201705" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_MAY_2017_P.Value = X_MAY_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JUN_2017_0H.Value = X_JUN_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_JUN_2017_0R.Value = X_JUN_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_JUN_2017_2.Value = X_JUN_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_JUN_2017_6.Value = X_JUN_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_JUN_2017_9.Value = X_JUN_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if ((QDesign.NULL(X_YYYYMM.Value) == "201706" & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_JUN_2017_P.Value = X_JUN_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >=0 & string.Compare(X_YYYYMM.Value , "201706")<=0) & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "HCP" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_TOT_2017_0H.Value = X_TOT_2017_0H.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >=0 & string.Compare(X_YYYYMM.Value , "201706")<=0) & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(flePEDSURGERY2.GetStringValue("X_PAYMENT")) == "RMB" & (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 0 | QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 4)))
                {
                    X_TOT_2017_0R.Value = X_TOT_2017_0R.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >=0 & string.Compare(X_YYYYMM.Value , "201706")<=0) & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 2))
                {
                    X_TOT_2017_2.Value = X_TOT_2017_2.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >=0 &string.Compare(X_YYYYMM.Value, "201706") <= 0) & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6))
                {
                    X_TOT_2017_6.Value = X_TOT_2017_6.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >= 0 & string.Compare(X_YYYYMM.Value, "201706") <= 0) & QDesign.NULL(X_CODE.Value) == "N" & QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9))
                {
                    X_TOT_2017_9.Value = X_TOT_2017_9.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (((string.Compare(X_YYYYMM.Value, "201607") >= 0 & string.Compare(X_YYYYMM.Value, "201706") <= 0) & QDesign.NULL(X_CODE.Value) == "Y"))
                {
                    X_TOT_2017_P.Value = X_TOT_2017_P.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMDTL_FEE_OHIP") / 100;
                }

                if (QDesign.NULL(fleF002_CLAIMS_MSTR_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6)
                {
                    X_TOT_2017_6_PAY.Value = X_TOT_2017_6_PAY.Value + fleF002_CLAIMS_MSTR_DTL.GetDecimalValue("CLMHDR_MANUAL_AND_TAPE_PAYMENTS") / 100;
                }

                SubFile(ref m_trnTRANS_UPDATE, ref flePEDSURGERY1, At(X_DOC_NBR), SubFileType.Keep, SubFileMode.Append, X_DOC_NBR, COMMA, flePEDSURGERY2, "DOC_NAME", COMMA, X_JUL_2016_0H, COMMA, X_JUL_2016_0R, COMMA,
                X_JUL_2016_6, COMMA, X_AUG_2016_0H, COMMA, X_AUG_2016_0R, COMMA, X_AUG_2016_6, COMMA, X_SEP_2016_0H, COMMA, X_SEP_2016_0R, COMMA, X_SEP_2016_6, COMMA, X_OCT_2016_0H, COMMA, X_OCT_2016_0R, COMMA, X_OCT_2016_6, COMMA,
                X_NOV_2016_0H, COMMA, X_NOV_2016_0R, COMMA, X_NOV_2016_6, COMMA, X_DEC_2016_0H, COMMA, X_DEC_2016_0R, COMMA, X_DEC_2016_6, COMMA, X_JAN_2017_0H, COMMA, X_JAN_2017_0R, COMMA, X_JAN_2017_6, COMMA, X_FEB_2017_0H, COMMA,
                X_FEB_2017_0R, COMMA, X_FEB_2017_6, COMMA, X_MAR_2017_0H, COMMA, X_MAR_2017_0R, COMMA, X_MAR_2017_6, COMMA, X_APR_2017_0H, COMMA, X_APR_2017_0R, COMMA, X_APR_2017_6, COMMA, X_MAY_2017_0H, COMMA, X_MAY_2017_0R, COMMA,
                X_MAY_2017_6, COMMA, X_JUN_2017_0H, COMMA, X_JUN_2017_0R, COMMA, X_JUN_2017_6, COMMA, X_TOT_2017_0H, COMMA, X_TOT_2017_0R, COMMA, X_TOT_2017_6, COMMA, X_TOT_2017_6_PAY, COMMA, X_TOT_2017_2, COMMA, X_TOT_2017_9, COMMA,
                X_TOT_2017_P);

                Reset(ref X_JUL_2016_0H, At(X_DOC_NBR));
                Reset(ref X_JUL_2016_0R, At(X_DOC_NBR));
                Reset(ref X_JUL_2016_2, At(X_DOC_NBR));
                Reset(ref X_JUL_2016_6, At(X_DOC_NBR));
                Reset(ref X_JUL_2016_9, At(X_DOC_NBR));
                Reset(ref X_JUL_2016_P, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_0H, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_0R, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_2, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_6, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_9, At(X_DOC_NBR));
                Reset(ref X_AUG_2016_P, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_0H, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_0R, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_2, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_6, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_9, At(X_DOC_NBR));
                Reset(ref X_SEP_2016_P, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_0H, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_0R, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_2, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_6, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_9, At(X_DOC_NBR));
                Reset(ref X_OCT_2016_P, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_0H, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_0R, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_2, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_6, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_9, At(X_DOC_NBR));
                Reset(ref X_NOV_2016_P, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_0H, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_0R, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_2, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_6, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_9, At(X_DOC_NBR));
                Reset(ref X_DEC_2016_P, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_0H, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_0R, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_2, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_6, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_9, At(X_DOC_NBR));
                Reset(ref X_JAN_2017_P, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_0H, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_0R, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_2, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_6, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_9, At(X_DOC_NBR));
                Reset(ref X_FEB_2017_P, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_0H, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_0R, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_2, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_6, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_9, At(X_DOC_NBR));
                Reset(ref X_MAR_2017_P, At(X_DOC_NBR));
                Reset(ref X_APR_2017_0H, At(X_DOC_NBR));
                Reset(ref X_APR_2017_0R, At(X_DOC_NBR));
                Reset(ref X_APR_2017_2, At(X_DOC_NBR));
                Reset(ref X_APR_2017_6, At(X_DOC_NBR));
                Reset(ref X_APR_2017_9, At(X_DOC_NBR));
                Reset(ref X_APR_2017_P, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_0H, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_0R, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_2, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_6, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_9, At(X_DOC_NBR));
                Reset(ref X_MAY_2017_P, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_0H, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_0R, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_2, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_6, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_9, At(X_DOC_NBR));
                Reset(ref X_JUN_2017_P, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_0H, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_0R, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_2, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_6, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_9, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_P, At(X_DOC_NBR));
                Reset(ref X_TOT_2017_6_PAY, At(X_DOC_NBR));
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
            EndRequest("FOUR_4");
        }
    }

    #endregion
}
//FOUR_4

public class PEDSURGERY_FIVE_5 : PEDSURGERY
{
    public PEDSURGERY_FIVE_5(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        flePEDSURGERY1 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSURGERY1", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        DOC_JUL_2016_0H = new CoreDecimal("DOC_JUL_2016_0H", 7, this);
        DOC_JUL_2016_0R = new CoreDecimal("DOC_JUL_2016_0R", 7, this);
        DOC_JUL_2016_6 = new CoreDecimal("DOC_JUL_2016_6", 7, this);
        DOC_AUG_2016_0H = new CoreDecimal("DOC_AUG_2016_0H", 7, this);
        DOC_AUG_2016_0R = new CoreDecimal("DOC_AUG_2016_0R", 7, this);
        DOC_AUG_2016_6 = new CoreDecimal("DOC_AUG_2016_6", 7, this);
        DOC_SEP_2016_0H = new CoreDecimal("DOC_SEP_2016_0H", 7, this);
        DOC_SEP_2016_0R = new CoreDecimal("DOC_SEP_2016_0R", 7, this);
        DOC_SEP_2016_6 = new CoreDecimal("DOC_SEP_2016_6", 7, this);
        DOC_OCT_2016_0H = new CoreDecimal("DOC_OCT_2016_0H", 7, this);
        DOC_OCT_2016_0R = new CoreDecimal("DOC_OCT_2016_0R", 7, this);
        DOC_OCT_2016_6 = new CoreDecimal("DOC_OCT_2016_6", 7, this);
        DOC_NOV_2016_0H = new CoreDecimal("DOC_NOV_2016_0H", 7, this);
        DOC_NOV_2016_0R = new CoreDecimal("DOC_NOV_2016_0R", 7, this);
        DOC_NOV_2016_6 = new CoreDecimal("DOC_NOV_2016_6", 7, this);
        DOC_DEC_2016_0H = new CoreDecimal("DOC_DEC_2016_0H", 7, this);
        DOC_DEC_2016_0R = new CoreDecimal("DOC_DEC_2016_0R", 7, this);
        DOC_DEC_2016_6 = new CoreDecimal("DOC_DEC_2016_6", 7, this);
        DOC_JAN_2017_0H = new CoreDecimal("DOC_JAN_2017_0H", 7, this);
        DOC_JAN_2017_0R = new CoreDecimal("DOC_JAN_2017_0R", 7, this);
        DOC_JAN_2017_6 = new CoreDecimal("DOC_JAN_2017_6", 7, this);
        DOC_FEB_2017_0H = new CoreDecimal("DOC_FEB_2017_0H", 7, this);
        DOC_FEB_2017_0R = new CoreDecimal("DOC_FEB_2017_0R", 7, this);
        DOC_FEB_2017_6 = new CoreDecimal("DOC_FEB_2017_6", 7, this);
        DOC_MAR_2017_0H = new CoreDecimal("DOC_MAR_2017_0H", 7, this);
        DOC_MAR_2017_0R = new CoreDecimal("DOC_MAR_2017_0R", 7, this);
        DOC_MAR_2017_6 = new CoreDecimal("DOC_MAR_2017_6", 7, this);
        DOC_APR_2017_0H = new CoreDecimal("DOC_APR_2017_0H", 7, this);
        DOC_APR_2017_0R = new CoreDecimal("DOC_APR_2017_0R", 7, this);
        DOC_APR_2017_6 = new CoreDecimal("DOC_APR_2017_6", 7, this);
        DOC_MAY_2017_0H = new CoreDecimal("DOC_MAY_2017_0H", 7, this);
        DOC_MAY_2017_0R = new CoreDecimal("DOC_MAY_2017_0R", 7, this);
        DOC_MAY_2017_6 = new CoreDecimal("DOC_MAY_2017_6", 7, this);
        DOC_JUN_2017_0H = new CoreDecimal("DOC_JUN_2017_0H", 7, this);
        DOC_JUN_2017_0R = new CoreDecimal("DOC_JUN_2017_0R", 7, this);
        DOC_JUN_2017_6 = new CoreDecimal("DOC_JUN_2017_6", 7, this);
        DOC_TOT_2017_0H = new CoreDecimal("DOC_TOT_2017_0H", 7, this);
        DOC_TOT_2017_0R = new CoreDecimal("DOC_TOT_2017_0R", 7, this);
        DOC_TOT_2017_2 = new CoreDecimal("DOC_TOT_2017_2", 7, this);
        DOC_TOT_2017_6 = new CoreDecimal("DOC_TOT_2017_6", 7, this);
        DOC_TOT_2017_9 = new CoreDecimal("DOC_TOT_2017_9", 7, this);
        DOC_TOT_2017_P = new CoreDecimal("DOC_TOT_2017_P", 7, this);
        DOC_TOT_2017_6_PAY = new CoreDecimal("DOC_TOT_2017_6_PAY", 7, this);
        flePEDSURGERY3 = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "PEDSURGERY3", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        COMMA.GetValue += COMMA_GetValue;
        X_NUM_CR.GetValue += X_NUM_CR_GetValue;
        X_CR.GetValue += X_CR_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(PEDSURGERY_FIVE_5)"

    private SqlFileObject flePEDSURGERY1;
    private CoreDecimal DOC_JUL_2016_0H;
    private CoreDecimal DOC_JUL_2016_0R;
    private CoreDecimal DOC_JUL_2016_6;
    private CoreDecimal DOC_AUG_2016_0H;
    private CoreDecimal DOC_AUG_2016_0R;
    private CoreDecimal DOC_AUG_2016_6;
    private CoreDecimal DOC_SEP_2016_0H;
    private CoreDecimal DOC_SEP_2016_0R;
    private CoreDecimal DOC_SEP_2016_6;
    private CoreDecimal DOC_OCT_2016_0H;
    private CoreDecimal DOC_OCT_2016_0R;
    private CoreDecimal DOC_OCT_2016_6;
    private CoreDecimal DOC_NOV_2016_0H;
    private CoreDecimal DOC_NOV_2016_0R;
    private CoreDecimal DOC_NOV_2016_6;
    private CoreDecimal DOC_DEC_2016_0H;
    private CoreDecimal DOC_DEC_2016_0R;
    private CoreDecimal DOC_DEC_2016_6;
    private CoreDecimal DOC_JAN_2017_0H;
    private CoreDecimal DOC_JAN_2017_0R;
    private CoreDecimal DOC_JAN_2017_6;
    private CoreDecimal DOC_FEB_2017_0H;
    private CoreDecimal DOC_FEB_2017_0R;
    private CoreDecimal DOC_FEB_2017_6;
    private CoreDecimal DOC_MAR_2017_0H;
    private CoreDecimal DOC_MAR_2017_0R;
    private CoreDecimal DOC_MAR_2017_6;
    private CoreDecimal DOC_APR_2017_0H;
    private CoreDecimal DOC_APR_2017_0R;
    private CoreDecimal DOC_APR_2017_6;
    private CoreDecimal DOC_MAY_2017_0H;
    private CoreDecimal DOC_MAY_2017_0R;
    private CoreDecimal DOC_MAY_2017_6;
    private CoreDecimal DOC_JUN_2017_0H;
    private CoreDecimal DOC_JUN_2017_0R;
    private CoreDecimal DOC_JUN_2017_6;
    private CoreDecimal DOC_TOT_2017_0H;
    private CoreDecimal DOC_TOT_2017_0R;
    private CoreDecimal DOC_TOT_2017_2;
    private CoreDecimal DOC_TOT_2017_6;
    private CoreDecimal DOC_TOT_2017_9;
    private CoreDecimal DOC_TOT_2017_P;
    private CoreDecimal DOC_TOT_2017_6_PAY;

    private DCharacter COMMA = new DCharacter("COMMA", 1);
    private void COMMA_GetValue(ref string Value)
    {
        try
        {
            Value = "~";
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

    private DInteger X_NUM_CR = new DInteger("X_NUM_CR", 4);
    private void X_NUM_CR_GetValue(ref decimal Value)
    {
        try
        {
            Value = 13;
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

    private DCharacter X_CR = new DCharacter("X_CR", 2);
    private void X_CR_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Characters(X_NUM_CR.Value);
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

    private SqlFileObject flePEDSURGERY3;

    #endregion

    #region "Standard Generated Procedures(PEDSURGERY_FIVE_5)"
    
    #region "Automatic Item Initialization(PEDSURGERY_FIVE_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.

    #endregion

    #region "Transaction Management Procedures(PEDSURGERY_FIVE_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:07 PM

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
        flePEDSURGERY1.Transaction = m_trnTRANS_UPDATE;
        flePEDSURGERY3.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion
    
    #region "FILE Management Procedures(PEDSURGERY_FIVE_5)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 2:37:07 PM

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
            flePEDSURGERY1.Dispose();
            flePEDSURGERY3.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(PEDSURGERY_FIVE_5)"
    
    public void Run()
    {
        try
        {
            Request("FIVE_5");

            while (flePEDSURGERY1.QTPForMissing())
            {
                // --> GET PEDSURGERY1 <--
                flePEDSURGERY1.GetData();
                // --> End GET PEDSURGERY1 <--

                if (Transaction())
                {
                    Sort(flePEDSURGERY1.GetSortValue("X_DOC_NBR"));
                }
            }

            while (Sort(flePEDSURGERY1))
            {
                DOC_JUL_2016_0H.Value = DOC_JUL_2016_0H.Value + flePEDSURGERY1.GetDecimalValue("X_JUL_2016_0H");
                DOC_JUL_2016_0R.Value = DOC_JUL_2016_0R.Value + flePEDSURGERY1.GetDecimalValue("X_JUL_2016_0R");
                DOC_JUL_2016_6.Value = DOC_JUL_2016_6.Value + flePEDSURGERY1.GetDecimalValue("X_JUL_2016_6");
                DOC_AUG_2016_0H.Value = DOC_AUG_2016_0H.Value + flePEDSURGERY1.GetDecimalValue("X_AUG_2016_0H");
                DOC_AUG_2016_0R.Value = DOC_AUG_2016_0R.Value + flePEDSURGERY1.GetDecimalValue("X_AUG_2016_0R");
                DOC_AUG_2016_6.Value = DOC_AUG_2016_6.Value + flePEDSURGERY1.GetDecimalValue("X_AUG_2016_6");
                DOC_SEP_2016_0H.Value = DOC_SEP_2016_0H.Value + flePEDSURGERY1.GetDecimalValue("X_SEP_2016_0H");
                DOC_SEP_2016_0R.Value = DOC_SEP_2016_0R.Value + flePEDSURGERY1.GetDecimalValue("X_SEP_2016_0R");
                DOC_SEP_2016_6.Value = DOC_SEP_2016_6.Value + flePEDSURGERY1.GetDecimalValue("X_SEP_2016_6");
                DOC_OCT_2016_0H.Value = DOC_OCT_2016_0H.Value + flePEDSURGERY1.GetDecimalValue("X_OCT_2016_0H");
                DOC_OCT_2016_0R.Value = DOC_OCT_2016_0R.Value + flePEDSURGERY1.GetDecimalValue("X_OCT_2016_0R");
                DOC_OCT_2016_6.Value = DOC_OCT_2016_6.Value + flePEDSURGERY1.GetDecimalValue("X_OCT_2016_6");
                DOC_NOV_2016_0H.Value = DOC_NOV_2016_0H.Value + flePEDSURGERY1.GetDecimalValue("X_NOV_2016_0H");
                DOC_NOV_2016_0R.Value = DOC_NOV_2016_0R.Value + flePEDSURGERY1.GetDecimalValue("X_NOV_2016_0R");
                DOC_NOV_2016_6.Value = DOC_NOV_2016_6.Value + flePEDSURGERY1.GetDecimalValue("X_NOV_2016_6");
                DOC_DEC_2016_0H.Value = DOC_DEC_2016_0H.Value + flePEDSURGERY1.GetDecimalValue("X_DEC_2016_0H");
                DOC_DEC_2016_0R.Value = DOC_DEC_2016_0R.Value + flePEDSURGERY1.GetDecimalValue("X_DEC_2016_0R");
                DOC_DEC_2016_6.Value = DOC_DEC_2016_6.Value + flePEDSURGERY1.GetDecimalValue("X_DEC_2016_6");
                DOC_JAN_2017_0H.Value = DOC_JAN_2017_0H.Value + flePEDSURGERY1.GetDecimalValue("X_JAN_2017_0H");
                DOC_JAN_2017_0R.Value = DOC_JAN_2017_0R.Value + flePEDSURGERY1.GetDecimalValue("X_JAN_2017_0R");
                DOC_JAN_2017_6.Value = DOC_JAN_2017_6.Value + flePEDSURGERY1.GetDecimalValue("X_JAN_2017_6");
                DOC_FEB_2017_0H.Value = DOC_FEB_2017_0H.Value + flePEDSURGERY1.GetDecimalValue("X_FEB_2017_0H");
                DOC_FEB_2017_0R.Value = DOC_FEB_2017_0R.Value + flePEDSURGERY1.GetDecimalValue("X_FEB_2017_0R");
                DOC_FEB_2017_6.Value = DOC_FEB_2017_6.Value + flePEDSURGERY1.GetDecimalValue("X_FEB_2017_6");
                DOC_MAR_2017_0H.Value = DOC_MAR_2017_0H.Value + flePEDSURGERY1.GetDecimalValue("X_MAR_2017_0H");
                DOC_MAR_2017_0R.Value = DOC_MAR_2017_0R.Value + flePEDSURGERY1.GetDecimalValue("X_MAR_2017_0R");
                DOC_MAR_2017_6.Value = DOC_MAR_2017_6.Value + flePEDSURGERY1.GetDecimalValue("X_MAR_2017_6");
                DOC_APR_2017_0H.Value = DOC_APR_2017_0H.Value + flePEDSURGERY1.GetDecimalValue("X_APR_2017_0H");
                DOC_APR_2017_0R.Value = DOC_APR_2017_0R.Value + flePEDSURGERY1.GetDecimalValue("X_APR_2017_0R");
                DOC_APR_2017_6.Value = DOC_APR_2017_6.Value + flePEDSURGERY1.GetDecimalValue("X_APR_2017_6");
                DOC_MAY_2017_0H.Value = DOC_MAY_2017_0H.Value + flePEDSURGERY1.GetDecimalValue("X_MAY_2017_0H");
                DOC_MAY_2017_0R.Value = DOC_MAY_2017_0R.Value + flePEDSURGERY1.GetDecimalValue("X_MAY_2017_0R");
                DOC_MAY_2017_6.Value = DOC_MAY_2017_6.Value + flePEDSURGERY1.GetDecimalValue("X_MAY_2017_6");
                DOC_JUN_2017_0H.Value = DOC_JUN_2017_0H.Value + flePEDSURGERY1.GetDecimalValue("X_JUN_2017_0H");
                DOC_JUN_2017_0R.Value = DOC_JUN_2017_0R.Value + flePEDSURGERY1.GetDecimalValue("X_JUN_2017_0R");
                DOC_JUN_2017_6.Value = DOC_JUN_2017_6.Value + flePEDSURGERY1.GetDecimalValue("X_JUN_2017_6");
                DOC_TOT_2017_0H.Value = DOC_TOT_2017_0H.Value + flePEDSURGERY1.GetDecimalValue("X_TOT_2017_0H");
                DOC_TOT_2017_0R.Value = DOC_TOT_2017_0R.Value + flePEDSURGERY1.GetDecimalValue("X_TOT_2017_0R");
                DOC_TOT_2017_2.Value = DOC_TOT_2017_2.Value + flePEDSURGERY1.GetDecimalValue("X_TOT_2017_2");
                DOC_TOT_2017_6.Value = DOC_TOT_2017_6.Value + flePEDSURGERY1.GetDecimalValue("X_TOT_2017_6");
                DOC_TOT_2017_9.Value = DOC_TOT_2017_9.Value + flePEDSURGERY1.GetDecimalValue("X_TOT_2017_9");
                DOC_TOT_2017_P.Value = DOC_TOT_2017_P.Value + flePEDSURGERY1.GetDecimalValue("X_TOT_2017_P");
                DOC_TOT_2017_6_PAY.Value = DOC_TOT_2017_6_PAY.Value + flePEDSURGERY1.GetDecimalValue("X_TOT_2017_6_PAY");

                SubFile(ref m_trnTRANS_UPDATE, ref flePEDSURGERY3, flePEDSURGERY1.At("X_DOC_NBR"), SubFileType.Keep, flePEDSURGERY1, "DOC_NAME", COMMA, DOC_JUL_2016_0H, COMMA, DOC_JUL_2016_0R, COMMA, DOC_JUL_2016_6, COMMA,
                DOC_AUG_2016_0H, COMMA, DOC_AUG_2016_0R, COMMA, DOC_AUG_2016_6, COMMA, DOC_SEP_2016_0H, COMMA, DOC_SEP_2016_0R, COMMA, DOC_SEP_2016_6, COMMA, DOC_OCT_2016_0H, COMMA, DOC_OCT_2016_0R, COMMA, DOC_OCT_2016_6, COMMA, DOC_NOV_2016_0H, COMMA,
                DOC_NOV_2016_0R, COMMA, DOC_NOV_2016_6, COMMA, DOC_DEC_2016_0H, COMMA, DOC_DEC_2016_0R, COMMA, DOC_DEC_2016_6, COMMA, DOC_JAN_2017_0H, COMMA, DOC_JAN_2017_0R, COMMA, DOC_JAN_2017_6, COMMA, DOC_FEB_2017_0H, COMMA, DOC_FEB_2017_0R, COMMA,
                DOC_FEB_2017_6, COMMA, DOC_MAR_2017_0H, COMMA, DOC_MAR_2017_0R, COMMA, DOC_MAR_2017_6, COMMA, DOC_APR_2017_0H, COMMA, DOC_APR_2017_0R, COMMA, DOC_APR_2017_6, COMMA, DOC_MAY_2017_0H, COMMA, DOC_MAY_2017_0R, COMMA, DOC_MAY_2017_6, COMMA,
                DOC_JUN_2017_0H, COMMA, DOC_JUN_2017_0R, COMMA, DOC_JUN_2017_6, COMMA, DOC_TOT_2017_0H, COMMA, DOC_TOT_2017_0R, COMMA, DOC_TOT_2017_6, COMMA, DOC_TOT_2017_6_PAY);

                Reset(ref DOC_JUL_2016_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_JUL_2016_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_JUL_2016_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_AUG_2016_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_AUG_2016_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_AUG_2016_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_SEP_2016_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_SEP_2016_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_SEP_2016_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_OCT_2016_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_OCT_2016_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_OCT_2016_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_NOV_2016_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_NOV_2016_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_NOV_2016_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_DEC_2016_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_DEC_2016_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_DEC_2016_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_JAN_2017_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_JAN_2017_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_JAN_2017_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_FEB_2017_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_FEB_2017_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_FEB_2017_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_MAR_2017_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_MAR_2017_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_MAR_2017_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_APR_2017_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_APR_2017_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_APR_2017_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_MAY_2017_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_MAY_2017_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_MAY_2017_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_JUN_2017_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_JUN_2017_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_JUN_2017_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_TOT_2017_0H, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_TOT_2017_0R, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_TOT_2017_2, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_TOT_2017_6, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_TOT_2017_9, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_TOT_2017_P, flePEDSURGERY1.At("X_DOC_NBR"));
                Reset(ref DOC_TOT_2017_6_PAY, flePEDSURGERY1.At("X_DOC_NBR"));
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
            EndRequest("FIVE_5");
        }
    }

    #endregion
}
//FIVE_5
