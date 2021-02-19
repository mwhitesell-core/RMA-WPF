//  doc     : g271_g271.qts
//  purpose : Medicine docs that bill g271 codes - dept 04  clinics 22/34/44/98- include adjustments
//  by ped  20120701 to 20130630
//  who     : Department managers  
//  *************************************************************
//  2013/06/23     Yasemin         original
//  2013/06/24     Moira           modified 2nd pass access and select

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class G271_CODE : BaseClassControl
{
    private G271_CODE m_G271_CODE;
    
    public G271_CODE(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public G271_CODE(string Name, int Level, bool Request)
        : base(Name, Level, Request) {
        this.ScreenType = ScreenTypes.QTP;
    }
    
    public override void Dispose()
    {
        if (!(m_G271_CODE == null))
        {
            m_G271_CODE.CloseTransactionObjects();
            m_G271_CODE = null;
        }
    }
    
    public G271_CODE GetG271_CODE(int Level)
    {
        if ((m_G271_CODE == null))
        {
            m_G271_CODE = new G271_CODE("G271_CODE", Level);
        }
        else
        {
            m_G271_CODE.ResetValues();
        }
        
        return m_G271_CODE;
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
            G271_CODE_ONE_1 ONE_1 = new G271_CODE_ONE_1(Name, Level);
            ONE_1.Run();
            ONE_1.Dispose();
            ONE_1 = null;

            G271_CODE_TWO_2 TWO_2 = new G271_CODE_TWO_2(Name, Level);
            TWO_2.Run();
            TWO_2.Dispose();
            TWO_2 = null;

            G271_CODE_THREE_3 THREE_3 = new G271_CODE_THREE_3(Name, Level);
            THREE_3.Run();
            THREE_3.Dispose();
            THREE_3 = null;
            return true;
        }

        catch (CustomApplicationException ex) {
            WriteError(ex);
            return false;
        }

        catch (Exception ex) {
            WriteError(ex);
            return false;
        }
    }

    #endregion

    #endregion
}
public class G271_CODE_ONE_1 : G271_CODE
{
    public G271_CODE_ONE_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleG271 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "G271", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;
        fleF002_CLAIMS_MSTR.Choose += fleF002_CLAIMS_MSTR_Choose;
        CLMHDR_CLAIM_ID.GetValue += CLMHDR_CLAIM_ID_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(G271_CODE_1)"

    private SqlFileObject fleF002_CLAIMS_MSTR;
    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_BATCH_TYPE")).Append(" = 'C') AND ");
            strSQL.Append(" (").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMHDR_DOC_DEPT")).Append(" =  4)");
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
    
    private void fleF002_CLAIMS_MSTR_Choose(ref string ChooseClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
            strSQL.Append(Common.StringToField("B"));
            strSQL.Append(" AND (");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("22%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("34%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("44%"));
            strSQL.Append(" OR ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" LIKE ");
            strSQL.Append(Common.StringToField("98%"));
            strSQL.Append(") AND ");
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

    private SqlFileObject fleG271;

    private DCharacter CLMHDR_CLAIM_ID = new DCharacter("CLMHDR_CLAIM_ID", 16);
    private void CLMHDR_CLAIM_ID_GetValue(ref string Value)
    {
        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMHDR_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_OMA_SUFF") + fleF002_CLAIMS_MSTR.GetStringValue("CLMHDR_ADJ_ADJ_NBR");
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

    #region "Standard Generated Procedures(G271_CODE_1)"

    #region "Automatic Item Initialization(G271_CODE_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:10 PM

    #endregion

    #region "Transaction Management Procedures(G271_CODE_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:33 AM
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
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleG271.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(G271_CODE_1)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:33 AM
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
            fleF002_CLAIMS_MSTR.Dispose();
            fleG271.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(G271_CODE_1)"
    public void Run()
    {
        try
        {
            Request("ONE_1");

            while (fleF002_CLAIMS_MSTR.QTPForMissing())
            {
                //  --> GET F002_CLAIMS_MSTR <--
                fleF002_CLAIMS_MSTR.GetData();
                //  --> End GET F002_CLAIMS_MSTR <--

                if (Transaction())
                {
                    SubFile(ref m_trnTRANS_UPDATE, "G271", SubFileType.Keep, CLMHDR_CLAIM_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", "CLMHDR_AGENT_CD", "CLMHDR_BATCH_TYPE");
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

        finally {
            EndRequest("ONE_1");
        }
    }

    #endregion
}
// ONE_1
public class G271_CODE_TWO_2 : G271_CODE
{
    public G271_CODE_TWO_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;

        fleG271 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "G271", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF002_CLAIMS_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F002_CLAIMS_MSTR_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleG2711 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "G2711", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleGERIATRIC_SVC2 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "G2711", "GERIATRIC_SVC2", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleGERIATRIC_SVC3 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "G2711", "GERIATRIC_SVC3", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleGERIATRIC_SVC4 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "G2711", "GERIATRIC_SVC4", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        fleF002_CLAIMS_MSTR.SelectIf += fleF002_CLAIMS_MSTR_SelectIf;

        CONSEC_FLAG.GetValue += CONSEC_FLAG_GetValue;
        X_SV_NBR1.GetValue += X_SV_NBR1_GetValue;
        X_SV_NBR2.GetValue += X_SV_NBR2_GetValue;
        X_SV_NBR3.GetValue += X_SV_NBR3_GetValue;
        X_SV_NBR4.GetValue += X_SV_NBR4_GetValue;
        X_NBR_SVCS.GetValue += X_NBR_SVCS_GetValue;
        X_FEE.GetValue += X_FEE_GetValue;
        X_CLMDTL_FEE_OHIP_1.GetValue += X_CLMDTL_FEE_OHIP_1_GetValue;
        X_CLMDTL_FEE_OHIP_2.GetValue += X_CLMDTL_FEE_OHIP_2_GetValue;
        X_CLMDTL_FEE_OHIP_3.GetValue += X_CLMDTL_FEE_OHIP_3_GetValue;
        X_CLMDTL_FEE_OHIP_4.GetValue += X_CLMDTL_FEE_OHIP_4_GetValue;
        X_SV_DATE_1.GetValue += X_SV_DATE_1_GetValue;
        X_SV_DATE_2.GetValue += X_SV_DATE_2_GetValue;
        X_SV_DATE_3.GetValue += X_SV_DATE_3_GetValue;
        X_SV_DATE_4.GetValue += X_SV_DATE_4_GetValue;
        CLMDTL_ID.GetValue += CLMDTL_ID_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(G040_CODE_2)"

    private SqlFileObject fleG271;

    private SqlFileObject fleF002_CLAIMS_MSTR;
    private void fleF002_CLAIMS_MSTR_SelectIf(ref string SelectIfClause)
    {
        try
        {
            StringBuilder strSQL = new StringBuilder("");

            strSQL.Append(" (").Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_DATE_PERIOD_END")).Append(" >= 20160701 AND ");
            strSQL.Append(fleF002_CLAIMS_MSTR.ElementOwner("CLMDTL_DATE_PERIOD_END")).Append(" <= 20170630)");

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
    
    private DCharacter CONSEC_FLAG = new DCharacter("CONSEC_FLAG", 1);
    private void CONSEC_FLAG_GetValue(ref string Value)
    {
        try {
            string CurrentValue = String.Empty;
            if (QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0OP" &&
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0MR" &&
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0BI" &&
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "0  " &&
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != " 00" &&
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "000" &&
                QDesign.NULL(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 3)) != "   ")
            {
                CurrentValue = "Y";
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
    
    private DDecimal X_SV_NBR1 = new DDecimal("X_SV_NBR1", 2);
    private void X_SV_NBR1_GetValue(ref Decimal Value)
    {
        try
        {
            Value = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_NBR_SERV");
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
    
    private DDecimal X_SV_NBR2 = new DDecimal("X_SV_NBR2", 2);
    private void X_SV_NBR2_GetValue(ref Decimal Value)
    {
        try
        {
            Decimal CurrentValue;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 1, 1));
            }
            else
            {
                CurrentValue = 0;
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
    
    private DDecimal X_SV_NBR3 = new DDecimal("X_SV_NBR3", 2);
    private void X_SV_NBR3_GetValue(ref Decimal Value)
    {
        try
        {
            Decimal CurrentValue;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 4, 1));
            }
            else
            {
                CurrentValue = 0;
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
    
    private DDecimal X_SV_NBR4 = new DDecimal("X_SV_NBR4", 2);
    private void X_SV_NBR4_GetValue(ref Decimal Value)
    {
        try
        {
            Decimal CurrentValue;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.NConvert(QDesign.Substring(fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_CONSEC_DATES_R"), 7, 1));
            }
            else
            {
                CurrentValue = 0;
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
    
    private DDecimal X_NBR_SVCS = new DDecimal("X_NBR_SVCS", 2);
    private void X_NBR_SVCS_GetValue(ref Decimal Value)
    {
        try
        {
            Value = X_SV_NBR1.Value + X_SV_NBR2.Value + X_SV_NBR3.Value + X_SV_NBR4.Value;
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
    
    private DDecimal X_FEE = new DDecimal("X_FEE", 6);
    private void X_FEE_GetValue(ref Decimal Value)
    {
        try
        {
            Decimal CurrentValue;

            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = QDesign.Divide(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP"), X_NBR_SVCS.Value);
            }
            else
            {
                CurrentValue = fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_FEE_OHIP");
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
    
    private DDecimal X_CLMDTL_FEE_OHIP_1 = new DDecimal("X_CLMDTL_FEE_OHIP_1", 7);
    private void X_CLMDTL_FEE_OHIP_1_GetValue(ref Decimal Value)
    {
        try
        {
            Decimal CurrentValue;

            if (QDesign.NULL(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR")) == 0)
            {
                CurrentValue = (X_SV_NBR1.Value * X_FEE.Value);
            }
            else
            {
                CurrentValue = X_FEE.Value;
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
    
    private DDecimal X_CLMDTL_FEE_OHIP_2 = new DDecimal("X_CLMDTL_FEE_OHIP_2", 7);
    private void X_CLMDTL_FEE_OHIP_2_GetValue(ref Decimal Value)
    {
        try
        {
            Value = (X_SV_NBR2.Value * X_FEE.Value);
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
    
    private DDecimal X_CLMDTL_FEE_OHIP_3 = new DDecimal("X_CLMDTL_FEE_OHIP_3", 7);
    private void X_CLMDTL_FEE_OHIP_3_GetValue(ref Decimal Value)
    {
        try
        {
            Value = (X_SV_NBR3.Value * X_FEE.Value);
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
    
    private DDecimal X_CLMDTL_FEE_OHIP_4 = new DDecimal("X_CLMDTL_FEE_OHIP_4", 7);
    private void X_CLMDTL_FEE_OHIP_4_GetValue(ref Decimal Value)
    {
        try
        {
            Value = (X_SV_NBR4.Value * X_FEE.Value);
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
    
    private DCharacter X_SV_DATE_1 = new DCharacter("X_SV_DATE_1", 8);
    private void X_SV_DATE_1_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2);
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
    
    private DCharacter X_SV_DATE_2 = new DCharacter("X_SV_DATE_2", 8);
    private void X_SV_DATE_2_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 2, 2);
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
    
    private DCharacter X_SV_DATE_3 = new DCharacter("X_SV_DATE_3", 8);
    private void X_SV_DATE_3_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 5, 2);
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
    
    private DCharacter X_SV_DATE_4 = new DCharacter("X_SV_DATE_4", 8);
    private void X_SV_DATE_4_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = String.Empty;

            if (QDesign.NULL(CONSEC_FLAG.Value) == "Y")
            {
                CurrentValue = QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_YY"), 4) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_MM"), 2) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DD"), 2), 1, 6) + QDesign.Substring(QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_NBR"), 1) + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_SV_DAY"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_SV_DAY_ALPHA_1"), 8, 2);
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

    private SqlFileObject fleG2711;
    private SqlFileObject fleGERIATRIC_SVC2;
    private SqlFileObject fleGERIATRIC_SVC3;
    private SqlFileObject fleGERIATRIC_SVC4;

    private DCharacter CLMDTL_ID = new DCharacter("CLMDTL_ID", 16);
    private void CLMDTL_ID_GetValue(ref string Value)
    {
        try
        {
            Value = fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_BATCH_NBR") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_CLAIM_NBR"), 2) + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_CD") + fleF002_CLAIMS_MSTR.GetStringValue("CLMDTL_OMA_SUFF") + QDesign.ASCII(fleF002_CLAIMS_MSTR.GetDecimalValue("CLMDTL_ADJ_NBR"), 1);
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

    #region "Standard Generated Procedures(G040_CODE_2)"

    #region "Automatic Item Initialization(G040_CODE_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:06:10 PM

    #endregion

    #region "Transaction Management Procedures(G040_CODE_2)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:33 AM
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
        if (Method == TransactionMethods.Rollback)
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
        fleG271.Transaction = m_trnTRANS_UPDATE;
        fleF002_CLAIMS_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleG2711.Transaction = m_trnTRANS_UPDATE;
        fleGERIATRIC_SVC2.Transaction = m_trnTRANS_UPDATE;
        fleGERIATRIC_SVC3.Transaction = m_trnTRANS_UPDATE;
        fleGERIATRIC_SVC4.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(G040_CODE_2)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:33 AM
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
            fleG271.Dispose();
            fleF002_CLAIMS_MSTR.Dispose();
            fleG2711.Dispose();
            fleGERIATRIC_SVC2.Dispose();
            fleGERIATRIC_SVC3.Dispose();
            fleGERIATRIC_SVC4.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(G040_CODE_2)"
    public void Run()
    {
        try
        {
            Request("TWO_2");

            while (fleG271.QTPForMissing())
            {
                //  --> GET G271 <--
                fleG271.GetData();
                //  --> End GET G271 <--

                while (fleF002_CLAIMS_MSTR.QTPForMissing("1"))
                {
                    //  --> GET F002_CLAIMS_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_TYPE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("B"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_BATCH_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleG271.GetStringValue("KEY_CLM_BATCH_NBR")));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_CLAIM_NBR")).Append(" = ");
                    m_strWhere.Append(fleG271.GetDecimalValue("KEY_CLM_CLAIM_NBR"));
                    m_strWhere.Append(" And ").Append(fleF002_CLAIMS_MSTR.ElementOwner("KEY_CLM_SERV_CODE")).Append(" = ");
                    m_strWhere.Append(Common.StringToField("G271A"));

                    fleF002_CLAIMS_MSTR.GetData(m_strWhere.ToString());
                    //  --> End GET F002_CLAIMS_MSTR <--

                    if (Transaction())
                    {
                        SubFile(ref m_trnTRANS_UPDATE, "G2711", SubFileType.Keep, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_1, X_SV_DATE_1, "CLMDTL_OMA_CD");
                        SubFile(ref m_trnTRANS_UPDATE, "GERIATRIC_SVC2", QDesign.NULL(X_SV_NBR2.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_2, X_SV_DATE_2, "CLMDTL_OMA_CD");
                        SubFile(ref m_trnTRANS_UPDATE, "GERIATRIC_SVC3", QDesign.NULL(X_SV_NBR3.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_3, X_SV_DATE_3, "CLMDTL_OMA_CD");
                        SubFile(ref m_trnTRANS_UPDATE, "GERIATRIC_SVC4", QDesign.NULL(X_SV_NBR4.Value) != 0, SubFileType.Keep, SubFileMode.Append, CLMDTL_ID, fleF002_CLAIMS_MSTR, "KEY_CLM_BATCH_NBR", "KEY_CLM_CLAIM_NBR", X_CLMDTL_FEE_OHIP_4, X_SV_DATE_4, "CLMDTL_OMA_CD");
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
            EndRequest("TWO_2");
        }
    }

    #endregion
}
// TWO_2
public class G271_CODE_THREE_3 : G271_CODE
{
    public G271_CODE_THREE_3(string Name, int Level)
        : base(Name, Level, true) {
        this.ScreenType = ScreenTypes.QTP;

        fleG2711 = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "G2711", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleG271A = new SqlFileObject(this, FileTypes.Primary, 0, "TemporaryData", "G271A", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_G271 = new CoreDecimal("X_G271", 8, this);
        X_G271_COUNT = new CoreDecimal("X_G271_COUNT", 8, this);

        X_CLINIC.GetValue += X_CLINIC_GetValue;
        X_DOC.GetValue += X_DOC_GetValue;
        COMMA.GetValue += COMMA_GetValue;
        DOC_INITS.GetValue += DOC_INITS_GetValue;
        DETAIL_LINE.GetValue += DETAIL_LINE_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(G040_CODE_3)"

    private SqlFileObject fleG2711;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    
    private DCharacter X_CLINIC = new DCharacter("X_CLINIC", 2);
    private void X_CLINIC_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleG2711.GetStringValue("CLMDTL_ID"), 1, 2);
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
    
    private DCharacter X_DOC = new DCharacter("X_DOC", 3);
    private void X_DOC_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleG2711.GetStringValue("CLMDTL_ID"), 3, 3);
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

    private CoreDecimal X_G271;
    private CoreDecimal X_G271_COUNT;
    
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
    private void X_NUM_CR_GetValue(ref Decimal Value)
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

    private SqlFileObject fleG271A;

    private DCharacter DOC_INITS = new DCharacter("DOC_INITS", 3);
    private void DOC_INITS_GetValue(ref string Value)
    {
        try
        {
            Value = fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT1") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT2") + fleF020_DOCTOR_MSTR.GetStringValue("DOC_INIT3");
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

    private DCharacter DETAIL_LINE = new DCharacter("DETAIL_LINE", 70);
    private void DETAIL_LINE_GetValue(ref string Value)
    {
        try
        {
            Value = X_CLINIC.Value + COMMA.Value + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT"), 2) + COMMA.Value + X_DOC.Value + COMMA.Value + fleF020_DOCTOR_MSTR.GetStringValue("DOC_NAME") + COMMA.Value + DOC_INITS.Value + COMMA.Value + QDesign.ASCII(X_G271.Value, 8) + COMMA.Value + X_G271_COUNT.Value;
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

    #region "Standard Generated Procedures(G040_CODE_3)"

    #region "Automatic Item Initialization(G040_CODE_3)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:01:47 PM

    //#-----------------------------------------
    //# fleF001_ADD_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:01:47 PM
    //#-----------------------------------------

    #endregion

    #region "Transaction Management Procedures(G040_CODE_3)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:33 AM
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
        fleG2711.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleG271A.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(G040_CODE_3)"

    // # NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    // # Do not delete, modify or move it.  Updated: 2019-01-31 8:40:33 AM
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
            fleG2711.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleG271A.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(G040_CODE_3)"
    public void Run()
    {
        try
        {
            Request("THREE_3");

            while (fleG2711.QTPForMissing())
            {
                //  --> GET G2711 <--
                fleG2711.GetData();
                //  --> End GET G2711 <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    //  --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleG2711.GetStringValue("CLMDTL_ID"), 3, 3)));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    //  --> End GET F020_DOCTOR_MSTR <--

                    if (Transaction()) {
                        Sort(X_DOC.Value, fleG2711.GetSortValue("X_SV_DATE_1"));
                    }
                }
            }
            
            while (Sort(fleG2711, fleF020_DOCTOR_MSTR))
            {
                X_G271.Value = (X_G271.Value + fleG2711.GetDecimalValue("X_CLMDTL_FEE_OHIP_1"));
                X_G271_COUNT.Value = (X_G271_COUNT.Value + 1);

                SubFile(ref m_trnTRANS_UPDATE, "G271A", At(X_DOC), SubFileType.Keep, DETAIL_LINE);

                Reset(ref X_G271, At(X_DOC));
                Reset(ref X_G271_COUNT, At(X_DOC));
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
// THREE_3