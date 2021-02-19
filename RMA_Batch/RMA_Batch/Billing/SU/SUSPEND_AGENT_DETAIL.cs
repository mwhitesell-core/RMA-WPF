#region "Screen Comments"

// PURPOSE: REPORT AGENT 6 or 9 suspend claims  
// first pass of 2 programs
// DATE:  WHO:  MODIFICATION
// 2011/apr/07    M.C.  ORIGINAL
// 2011/jul/20    MC1  include new fields as dr name, cpso#, referring dr name, chart #   
// include f020 & f020-extra in the access statement
// include diagnostic & oma description
// 2017/Apr/06    MC2             include clmhdr-pat-ohip-id-or-chart in the subfile for debugging purpose
// to tell why patient information is blank for the report (suspend_agent_detail.txt)
// which is generated from suspend_agent_detail.qzs

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class SUSPEND_AGENT_DETAIL : BaseClassControl
{
    private SUSPEND_AGENT_DETAIL m_SUSPEND_AGENT_DETAIL;

    public SUSPEND_AGENT_DETAIL(string Name, int Level)
        : base(Name, Level)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public SUSPEND_AGENT_DETAIL(string Name, int Level, bool Request)
        : base(Name, Level, Request)
    {
        this.ScreenType = ScreenTypes.QTP;
    }

    public override void Dispose()
    {
        if ((m_SUSPEND_AGENT_DETAIL != null))
        {
            m_SUSPEND_AGENT_DETAIL.CloseTransactionObjects();
            m_SUSPEND_AGENT_DETAIL = null;
        }
    }

    public SUSPEND_AGENT_DETAIL GetSUSPEND_AGENT_DETAIL(int Level)
    {
        if (m_SUSPEND_AGENT_DETAIL == null)
        {
            m_SUSPEND_AGENT_DETAIL = new SUSPEND_AGENT_DETAIL("SUSPEND_AGENT_DETAIL", Level);
        }
        else
        {
            m_SUSPEND_AGENT_DETAIL.ResetValues();
        }
        return m_SUSPEND_AGENT_DETAIL;
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
            SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DETAIL_1 EXTRACT_SUSPEND_DETAIL_1 = new SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DETAIL_1(Name, Level);
            EXTRACT_SUSPEND_DETAIL_1.Run();
            EXTRACT_SUSPEND_DETAIL_1.Dispose();
            EXTRACT_SUSPEND_DETAIL_1 = null;

            SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DESC_2 EXTRACT_SUSPEND_DESC_2 = new SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DESC_2(Name, Level);
            EXTRACT_SUSPEND_DESC_2.Run();
            EXTRACT_SUSPEND_DESC_2.Dispose();
            EXTRACT_SUSPEND_DESC_2 = null;

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

public class SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DETAIL_1 : SUSPEND_AGENT_DETAIL
{
    public SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DETAIL_1(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "F002_SUSPEND_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF091_DIAG_CODES_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F091_DIAG_CODES_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        X_SEQ = new CoreDecimal("X_SEQ", 2, this);
        fleSUSP_AGENT_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SUSP_AGENT_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleSUSP_OMA_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SUSP_AGENT_DTL", "SUSP_OMA_DESC", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleSUSP_DIAG_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SUSP_AGENT_DTL", "SUSP_DIAG_DESC", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_TYPE.GetValue += X_TYPE_GetValue;
        X_LINE.GetValue += X_LINE_GetValue;
        X_LINE_OMA.GetValue += X_LINE_OMA_GetValue;
        X_LINE_DIAG.GetValue += X_LINE_DIAG_GetValue;
        X_CHART_KEY.GetValue += X_CHART_KEY_GetValue;
        PAT_OHIP_MMYY.GetValue += PAT_OHIP_MMYY_GetValue;
        CLMHDR_CLINIC_NBR_1_2.GetValue += CLMHDR_CLINIC_NBR_1_2_GetValue;
        CLMHDR_DOC_NBR.GetValue += CLMHDR_DOC_NBR_GetValue;  
        fleSUSP_OMA_DESC.SetItemFinals += fleSUSP_OMA_DESC_SetItemFinals;
        fleSUSP_DIAG_DESC.SetItemFinals += fleSUSP_DIAG_DESC_SetItemFinals;
        fleF010_PAT_MSTR.InitializeItems += fleF010_PAT_MSTR_AutomaticItemInitialization;
        fleF040_OMA_FEE_MSTR.InitializeItems += fleF040_OMA_FEE_MSTR_AutomaticItemInitialization;
        fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;
    }

    #region "Declarations (Variables, Files and Transactions)(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DETAIL_1)"

    private SqlFileObject fleF002_SUSPEND_HDR;
    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleF002_SUSPEND_DTL;
    private SqlFileObject fleF040_OMA_FEE_MSTR;
    private SqlFileObject fleF091_DIAG_CODES_MSTR;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_DOCTOR_EXTRA;

    public override bool SelectIf()
    {
        try
        {
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6 | QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9)
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

    private CoreDecimal X_SEQ;

    private DCharacter X_LINE = new DCharacter("X_LINE", 70);
    private void X_LINE_GetValue(ref string Value)
    {
        try
        {
            Value = fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD") + fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_SUFF") + "     " + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_NBR_SERV"), 2) + "     " + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_DIAG_CD"), 3) + "     " + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_YY"), 4) + "/" + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_MM"), 2) + "/" + QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_SV_DD"), 2);
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

    private DCharacter X_LINE_OMA = new DCharacter("X_LINE_OMA", 70);
    private void X_LINE_OMA_GetValue(ref string Value)
    {
        try
        {
            Value = fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD") + " : " + fleF040_OMA_FEE_MSTR.GetStringValue("FEE_DESC");
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

    private DCharacter X_LINE_DIAG = new DCharacter("X_LINE_DIAG", 70);
    private void X_LINE_DIAG_GetValue(ref string Value)
    {
        try
        {
            Value = fleF091_DIAG_CODES_MSTR.GetStringValue("DIAG_CD") + " : " + fleF091_DIAG_CODES_MSTR.GetStringValue("DIAG_CD_DESC");
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

    private DCharacter X_CHART_KEY = new DCharacter("X_CHART_KEY", 11);
    private void X_CHART_KEY_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR"), 1, 1)) == "M")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR");
            }
            else if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_2"), 1, 1)) == "K")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_2");
            }
            else if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_3"), 1, 1)) == "H")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_3");
            }
            else if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_5"), 1, 1)) == "J")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_5");
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_4")) != QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 6, 10)))
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_4");
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

    private SqlFileObject fleSUSP_AGENT_DTL;
    private SqlFileObject fleSUSP_OMA_DESC;

    private void fleSUSP_OMA_DESC_SetItemFinals()
    {
        try
        {
            fleSUSP_OMA_DESC.set_SetValue("X_TYPE", 3);
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

    private SqlFileObject fleSUSP_DIAG_DESC;

    private void fleSUSP_DIAG_DESC_SetItemFinals()
    {
        try
        {
            fleSUSP_DIAG_DESC.set_SetValue("X_TYPE", 4);
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

    private DCharacter PAT_OHIP_MMYY = new DCharacter("PAT_OHIP_MMYY", 15);
    private void PAT_OHIP_MMYY_GetValue(ref string Value)
    {
        try
        {
            Value = fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_ALPHA") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_YY")) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_MM"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_DIRECT_DD"), 2) + fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_LAST_6");
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

    private DDecimal CLMHDR_CLINIC_NBR_1_2 = new DDecimal("CLMHDR_CLINIC_NBR_1_2", 2);
    private void CLMHDR_CLINIC_NBR_1_2_GetValue(ref decimal Value)
    {
        try
        {
            Value = QDesign.NConvert(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2));
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

    private DCharacter CLMHDR_DOC_NBR = new DCharacter("CLMHDR_DOC_NBR", 3);
    private void CLMHDR_DOC_NBR_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 3, 3);
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

    #region "Standard Generated Procedures(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DETAIL_1)"

    #region "Automatic Item Initialization(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DETAIL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:03 PM

    //#-----------------------------------------
    //# fleF010_PAT_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:04:50 PM
    //#-----------------------------------------
    private void fleF010_PAT_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            fleF010_PAT_MSTR.set_SetValue("FILLER", !Fixed, fleF002_SUSPEND_HDR.GetStringValue("FILLER"));
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
    //# fleF040_OMA_FEE_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:04:50 PM
    //#-----------------------------------------
    private void fleF040_OMA_FEE_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            fleF040_OMA_FEE_MSTR.set_SetValue("FILLER", !Fixed, fleF002_SUSPEND_HDR.GetStringValue("FILLER"));
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
    //# fleF020_DOCTOR_EXTRA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:04:51 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_EXTRA_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            fleF020_DOCTOR_EXTRA.set_SetValue("FILLER", !Fixed, fleF002_SUSPEND_HDR.GetStringValue("FILLER"));
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
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
    
    #region "Transaction Management Procedures(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DETAIL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:50 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DTL.Transaction = m_trnTRANS_UPDATE;
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF091_DIAG_CODES_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleSUSP_AGENT_DTL.Transaction = m_trnTRANS_UPDATE;
        fleSUSP_OMA_DESC.Transaction = m_trnTRANS_UPDATE;
        fleSUSP_DIAG_DESC.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion
    
    #region "FILE Management Procedures(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DETAIL_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:50 PM

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
            fleF002_SUSPEND_HDR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleF002_SUSPEND_DTL.Dispose();
            fleF040_OMA_FEE_MSTR.Dispose();
            fleF091_DIAG_CODES_MSTR.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF020_DOCTOR_EXTRA.Dispose();
            fleSUSP_AGENT_DTL.Dispose();
            fleSUSP_OMA_DESC.Dispose();
            fleSUSP_DIAG_DESC.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DETAIL_1)"

    public void Run()
    {
        try
        {
            Request("EXTRACT_SUSPEND_DETAIL_1");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--

                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA").PadRight(15).Substring(0, 2)));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA").PadRight(15).Substring(2, 12)));
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA").PadRight(15).Substring(14, 1)));

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F010_PAT_MSTR <--

                    while (fleF002_SUSPEND_DTL.QTPForMissing("2"))
                    {
                        // --> GET F002_SUSPEND_DTL <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                        m_strWhere.Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DTL.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                        fleF002_SUSPEND_DTL.GetData(m_strWhere.ToString());
                        // --> End GET F002_SUSPEND_DTL <--

                        while (fleF040_OMA_FEE_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F040_OMA_FEE_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                            m_strWhere.Append(Common.StringToField((fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(0, 1)));

                            m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                            m_strWhere.Append(Common.StringToField((fleF002_SUSPEND_DTL.GetStringValue("CLMDTL_OMA_CD")).Substring(1, 3)));

                            fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F040_OMA_FEE_MSTR <--

                            while (fleF091_DIAG_CODES_MSTR.QTPForMissing("4"))
                            {
                                // --> GET F091_DIAG_CODES_MSTR <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF091_DIAG_CODES_MSTR.ElementOwner("DIAG_CD")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(QDesign.ASCII(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_DIAG_CD"), 3)));

                                fleF091_DIAG_CODES_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F091_DIAG_CODES_MSTR <--

                                while (fleF020_DOCTOR_MSTR.QTPForMissing("5"))
                                {
                                    // --> GET F020_DOCTOR_MSTR <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 3, 3)));

                                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET F020_DOCTOR_MSTR <--

                                    while (fleF020_DOCTOR_EXTRA.QTPForMissing("6"))
                                    {
                                        // --> GET F020_DOCTOR_EXTRA <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 3, 3)));

                                        fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET F020_DOCTOR_EXTRA <--

                                        if (Transaction())
                                        {
                                             if (Select_If())
                                            {
                                                Sort(fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_OHIP_NBR"), fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_ACCOUNTING_NBR"));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            while (Sort(fleF002_SUSPEND_HDR, fleF010_PAT_MSTR, fleF002_SUSPEND_DTL, fleF040_OMA_FEE_MSTR, fleF091_DIAG_CODES_MSTR, fleF020_DOCTOR_MSTR, fleF020_DOCTOR_EXTRA))
            {
                X_SEQ.Value = X_SEQ.Value + 1;

                SubFile(ref m_trnTRANS_UPDATE, ref fleSUSP_AGENT_DTL, SubFileType.Keep, fleF002_SUSPEND_HDR, "CLMHDR_DOC_OHIP_NBR", "CLMHDR_ACCOUNTING_NBR", CLMHDR_CLINIC_NBR_1_2, CLMHDR_DOC_NBR, "CLMHDR_DOC_SPEC_CD", "CLMHDR_REFER_DOC_NBR", "CLMHDR_LOC", "CLMHDR_AGENT_CD", "CLMHDR_I_O_PAT_IND", "CLMHDR_DOC_DEPT",
                "CLMHDR_DATE_ADMIT", "CLMHDR_CONFIDENTIAL_FLAG", fleF010_PAT_MSTR, "PAT_SURNAME_FIRST3", "PAT_SURNAME_LAST22", "PAT_GIVEN_NAME_FIRST1", "FILLER3", "PAT_HEALTH_NBR", "PAT_VERSION_CD", PAT_OHIP_MMYY,
                "PAT_BIRTH_DATE_YY", "PAT_BIRTH_DATE_MM", "PAT_BIRTH_DATE_DD", "PAT_SEX", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POST_CD1", "SUBSCR_POST_CD2", "SUBSCR_POST_CD3", "SUBSCR_POST_CD4", "SUBSCR_POST_CD5", "SUBSCR_POST_CD6", "FILLER", "SUBSCR_PROV_CD", "PAT_PHONE_NBR", X_TYPE, X_SEQ,
                X_LINE, fleF020_DOCTOR_MSTR, "DOC_NAME", fleF020_DOCTOR_EXTRA, "CPSO_NBR", X_CHART_KEY);

                SubFile(ref m_trnTRANS_UPDATE, ref fleSUSP_OMA_DESC, SubFileType.Keep, SubFileMode.Append, fleF002_SUSPEND_HDR, "CLMHDR_DOC_OHIP_NBR", "CLMHDR_ACCOUNTING_NBR", CLMHDR_CLINIC_NBR_1_2, CLMHDR_DOC_NBR, "CLMHDR_DOC_SPEC_CD", "CLMHDR_REFER_DOC_NBR", "CLMHDR_LOC", "CLMHDR_AGENT_CD", "CLMHDR_I_O_PAT_IND", "CLMHDR_DOC_DEPT",
                "CLMHDR_DATE_ADMIT", "CLMHDR_CONFIDENTIAL_FLAG", fleF010_PAT_MSTR, "PAT_SURNAME_FIRST3", "PAT_SURNAME_LAST22", "PAT_GIVEN_NAME_FIRST1", "FILLER3", "PAT_HEALTH_NBR", "PAT_VERSION_CD", PAT_OHIP_MMYY,
                "PAT_BIRTH_DATE_YY", "PAT_BIRTH_DATE_MM", "PAT_BIRTH_DATE_DD", "PAT_SEX", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POST_CD1", "SUBSCR_POST_CD2", "SUBSCR_POST_CD3", "SUBSCR_POST_CD4", "SUBSCR_POST_CD5", "SUBSCR_POST_CD6", "FILLER", "SUBSCR_PROV_CD", "PAT_PHONE_NBR", X_TYPE, X_SEQ,
                X_LINE_OMA, fleF020_DOCTOR_MSTR, "DOC_NAME", fleF020_DOCTOR_EXTRA, "CPSO_NBR", X_CHART_KEY);

                SubFile(ref m_trnTRANS_UPDATE, ref fleSUSP_DIAG_DESC, QDesign.NULL(fleF002_SUSPEND_DTL.GetDecimalValue("CLMDTL_DIAG_CD")) != 0, SubFileType.Keep, SubFileMode.Append, fleF002_SUSPEND_HDR, "CLMHDR_DOC_OHIP_NBR", "CLMHDR_ACCOUNTING_NBR", CLMHDR_CLINIC_NBR_1_2, CLMHDR_DOC_NBR, "CLMHDR_DOC_SPEC_CD", "CLMHDR_REFER_DOC_NBR", "CLMHDR_LOC", "CLMHDR_AGENT_CD", "CLMHDR_I_O_PAT_IND", "CLMHDR_DOC_DEPT",
                "CLMHDR_DATE_ADMIT", "CLMHDR_CONFIDENTIAL_FLAG", fleF010_PAT_MSTR, "PAT_SURNAME_FIRST3", "PAT_SURNAME_LAST22", "PAT_GIVEN_NAME_FIRST1", "FILLER3", "PAT_HEALTH_NBR", "PAT_VERSION_CD",
                PAT_OHIP_MMYY, "PAT_BIRTH_DATE_YY", "PAT_BIRTH_DATE_MM", "PAT_BIRTH_DATE_DD", "PAT_SEX", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POST_CD1", "SUBSCR_POST_CD2", "SUBSCR_POST_CD3", "SUBSCR_POST_CD4", "SUBSCR_POST_CD5", "SUBSCR_POST_CD6", "FILLER", "SUBSCR_PROV_CD", "PAT_PHONE_NBR", X_TYPE,
                X_SEQ, X_LINE_DIAG, fleF020_DOCTOR_MSTR, "DOC_NAME", fleF020_DOCTOR_EXTRA, "CPSO_NBR", X_CHART_KEY);

                Reset(ref X_SEQ, fleF002_SUSPEND_HDR.At("CLMHDR_DOC_OHIP_NBR") || fleF002_SUSPEND_HDR.At("CLMHDR_ACCOUNTING_NBR"));
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
            EndRequest("EXTRACT_SUSPEND_DETAIL_1");
        }
    }

    #endregion
}
//EXTRACT_SUSPEND_DETAIL_1

public class SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DESC_2 : SUSPEND_AGENT_DETAIL
{
    public SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DESC_2(string Name, int Level)
        : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleF002_SUSPEND_HDR = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "F002_SUSPEND_HDR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF010_PAT_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F010_PAT_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF002_SUSPEND_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "F002_SUSPEND_DESC", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_EXTRA = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_EXTRA", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleSUSP_AGENT_DESC = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "SUSP_AGENT_DTL", "SUSP_AGENT_DESC", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        X_TYPE.GetValue += X_TYPE_GetValue;
        X_SEQ.GetValue += X_SEQ_GetValue;
        X_LINE.GetValue += X_LINE_GetValue;
        CLMHDR_DOC_NBR.GetValue += CLMHDR_DOC_NBR_GetValue;
        CLMHDR_CLINIC_NBR_1_2.GetValue += CLMHDR_CLINIC_NBR_1_2_GetValue;
        X_CHART_KEY.GetValue += X_CHART_KEY_GetValue;
        fleF010_PAT_MSTR.InitializeItems += fleF010_PAT_MSTR_AutomaticItemInitialization;
        fleF020_DOCTOR_EXTRA.InitializeItems += fleF020_DOCTOR_EXTRA_AutomaticItemInitialization;
        PAT_OHIP_MMYY.GetValue += PAT_OHIP_MMYY_GetValue;
    }

    #region "Declarations (Variables, Files and Transactions)(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DESC_2)"

    private SqlFileObject fleF002_SUSPEND_HDR;
    private SqlFileObject fleF010_PAT_MSTR;
    private SqlFileObject fleF002_SUSPEND_DESC;
    private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleF020_DOCTOR_EXTRA;

    private DCharacter PAT_OHIP_MMYY = new DCharacter("PAT_OHIP_MMYY", 15);
    private void PAT_OHIP_MMYY_GetValue(ref string Value)
    {
        try
        {
            Value = fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_ALPHA") + fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_YY") + fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_MM") + fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_DD") + fleF010_PAT_MSTR.GetStringValue("PAT_DIRECT_LAST_6");
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
            if (QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 6 | QDesign.NULL(fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_AGENT_CD")) == 9)
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

    private DDecimal X_SEQ = new DDecimal("X_SEQ", 2);
    private void X_SEQ_GetValue(ref decimal Value)
    {
        try
        {
            Value = fleF002_SUSPEND_DESC.GetDecimalValue("CLMDTL_LINE_NO");
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

    private DCharacter X_LINE = new DCharacter("X_LINE", 70);
    private void X_LINE_GetValue(ref string Value)
    {
        try
        {
            Value = fleF002_SUSPEND_DESC.GetStringValue("CLMDTL_SUSPEND_DESC");
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

    private DCharacter X_CHART_KEY = new DCharacter("X_CHART_KEY", 11);
    private void X_CHART_KEY_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR"), 1, 1)) == "M")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR");
            }
            else if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_2"), 1, 1)) == "K")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_2");
            }
            else if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_3"), 1, 1)) == "H")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_3");
            }
            else if (QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_5"), 1, 1)) == "J")
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_5");
            }
            else if (QDesign.NULL(fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_4")) != QDesign.NULL(QDesign.Substring(fleF010_PAT_MSTR.GetStringValue("PAT_I_KEY") + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_CON_NBR"), 2) + QDesign.ASCII(fleF010_PAT_MSTR.GetDecimalValue("PAT_I_NBR"), 12) + fleF010_PAT_MSTR.GetStringValue("FILLER4"), 6, 10)))
            {
                CurrentValue = fleF010_PAT_MSTR.GetStringValue("PAT_CHART_NBR_4");
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

    private SqlFileObject fleSUSP_AGENT_DESC;

    private DDecimal CLMHDR_CLINIC_NBR_1_2 = new DDecimal("CLMHDR_CLINIC_NBR_1_2", 2);
    private void CLMHDR_CLINIC_NBR_1_2_GetValue(ref decimal Value)
    {
        try
        {
            Value = QDesign.NConvert(QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 1, 2));
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

    private DCharacter CLMHDR_DOC_NBR = new DCharacter("CLMHDR_DOC_NBR", 3);
    private void CLMHDR_DOC_NBR_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.Substring(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_BATCH_NBR"), 3, 3);
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

    #region "Standard Generated Procedures(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DESC_2)"

    #region "Automatic Item Initialization(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DESC_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:05:06 PM

    //#-----------------------------------------
    //# fleF010_PAT_MSTR_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:05:03 PM
    //#-----------------------------------------
    private void fleF010_PAT_MSTR_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            fleF010_PAT_MSTR.set_SetValue("FILLER", !Fixed, fleF002_SUSPEND_HDR.GetStringValue("FILLER"));
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
    //# fleF020_DOCTOR_EXTRA_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.24052  Generated on: 6/27/2017 3:05:03 PM
    //#-----------------------------------------
    private void fleF020_DOCTOR_EXTRA_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            fleF020_DOCTOR_EXTRA.set_SetValue("FILLER", !Fixed, fleF002_SUSPEND_HDR.GetStringValue("FILLER"));
            fleF020_DOCTOR_EXTRA.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
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

    #region "Transaction Management Procedures(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DESC_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:50 PM

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
        fleF002_SUSPEND_HDR.Transaction = m_trnTRANS_UPDATE;
        fleF010_PAT_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF002_SUSPEND_DESC.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleF020_DOCTOR_EXTRA.Transaction = m_trnTRANS_UPDATE;
        fleSUSP_AGENT_DESC.Transaction = m_trnTRANS_UPDATE;
    }

    #endregion

    #region "FILE Management Procedures(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DESC_2)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 3:04:50 PM

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
            fleF002_SUSPEND_HDR.Dispose();
            fleF010_PAT_MSTR.Dispose();
            fleF002_SUSPEND_DESC.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleF020_DOCTOR_EXTRA.Dispose();
            fleSUSP_AGENT_DESC.Dispose();
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

    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(SUSPEND_AGENT_DETAIL_EXTRACT_SUSPEND_DESC_2)"

    public void Run()
    {
        try
        {
            Request("EXTRACT_SUSPEND_DESC_2");

            while (fleF002_SUSPEND_HDR.QTPForMissing())
            {
                // --> GET F002_SUSPEND_HDR <--
                fleF002_SUSPEND_HDR.GetData();
                // --> End GET F002_SUSPEND_HDR <--

                while (fleF010_PAT_MSTR.QTPForMissing("1"))
                {
                    // --> GET F010_PAT_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_KEY")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE")));
                    //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_CON_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert((fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(1, 2)));
                    //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("PAT_I_NBR")).Append(" = ");
                    m_strWhere.Append(QDesign.NConvert((fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(3, 12)));
                    //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR
                    m_strWhere.Append(" AND ").Append(" ").Append(fleF010_PAT_MSTR.ElementOwner("FILLER4")).Append(" = ");
                    m_strWhere.Append(Common.StringToField((fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_TYPE") + fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_PAT_KEY_DATA")).PadRight(16).Substring(15, 1)));
                    //Parent:CLMHDR_PAT_OHIP_ID_OR_CHART    'Parent:KEY_PAT_MSTR

                    fleF010_PAT_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F010_PAT_MSTR <--

                    while (fleF002_SUSPEND_DESC.QTPForMissing("2"))
                    {
                        // --> GET F002_SUSPEND_DESC <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_DOC_OHIP_NBR")).Append(" = ");
                        m_strWhere.Append((fleF002_SUSPEND_HDR.GetDecimalValue("CLMHDR_DOC_OHIP_NBR")));
                        m_strWhere.Append(" And ").Append(fleF002_SUSPEND_DESC.ElementOwner("CLMDTL_ACCOUNTING_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("CLMHDR_ACCOUNTING_NBR")));

                        fleF002_SUSPEND_DESC.GetData(m_strWhere.ToString());
                        // --> End GET F002_SUSPEND_DESC <--

                        while (fleF020_DOCTOR_MSTR.QTPForMissing("3"))
                        {
                            // --> GET F020_DOCTOR_MSTR <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("SUSP_HDR_DOC_NBR")));

                            fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET F020_DOCTOR_MSTR <--

                            while (fleF020_DOCTOR_EXTRA.QTPForMissing("4"))
                            {
                                // --> GET F020_DOCTOR_EXTRA <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleF020_DOCTOR_EXTRA.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF002_SUSPEND_HDR.GetStringValue("SUSP_HDR_DOC_NBR")));

                                fleF020_DOCTOR_EXTRA.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET F020_DOCTOR_EXTRA <--

                                if (Transaction())
                                {
                                     if (Select_If())
                                    {
                                        Sort(fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_DOC_OHIP_NBR"), fleF002_SUSPEND_HDR.GetSortValue("CLMHDR_ACCOUNTING_NBR"));
                                    }
                                }
                            }
                        }
                    }
                }
            }

            while (Sort(fleF002_SUSPEND_HDR, fleF010_PAT_MSTR, fleF002_SUSPEND_DESC, fleF020_DOCTOR_MSTR, fleF020_DOCTOR_EXTRA))
            {
                SubFile(ref m_trnTRANS_UPDATE, ref fleSUSP_AGENT_DESC, SubFileType.Keep, SubFileMode.Append, fleF002_SUSPEND_HDR, "CLMHDR_DOC_OHIP_NBR", "CLMHDR_ACCOUNTING_NBR", CLMHDR_CLINIC_NBR_1_2, CLMHDR_DOC_NBR, "CLMHDR_DOC_SPEC_CD", "CLMHDR_REFER_DOC_NBR", "CLMHDR_LOC", "CLMHDR_AGENT_CD", "CLMHDR_I_O_PAT_IND", "CLMHDR_DOC_DEPT",
                "CLMHDR_DATE_ADMIT", "CLMHDR_CONFIDENTIAL_FLAG", fleF010_PAT_MSTR, "PAT_SURNAME_FIRST3", "PAT_SURNAME_LAST22", "PAT_GIVEN_NAME_FIRST1", "FILLER3", "PAT_HEALTH_NBR", "PAT_VERSION_CD", PAT_OHIP_MMYY,
                "PAT_BIRTH_DATE_YY", "PAT_BIRTH_DATE_MM", "PAT_BIRTH_DATE_DD", "PAT_SEX", "SUBSCR_ADDR1", "SUBSCR_ADDR2", "SUBSCR_ADDR3", "SUBSCR_POST_CD1", "SUBSCR_POST_CD2", "SUBSCR_POST_CD3", "SUBSCR_POST_CD4", "SUBSCR_POST_CD5", "SUBSCR_POST_CD6", "FILLER", "SUBSCR_PROV_CD", "PAT_PHONE_NBR", X_TYPE, X_SEQ,
                X_LINE, fleF020_DOCTOR_MSTR, "DOC_NAME", fleF020_DOCTOR_EXTRA, "CPSO_NBR", X_CHART_KEY);
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
            EndRequest("EXTRACT_SUSPEND_DESC_2");
        }
    }

    #endregion
}
//EXTRACT_SUSPEND_DESC_2
