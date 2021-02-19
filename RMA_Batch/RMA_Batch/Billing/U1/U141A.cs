
#region "Screen Comments"

// #> PROGRAM-ID.     u141a.qts
// ((C)) Dyad Infosys LTD   
// PURPOSE:   Create miscellaneous payment  batches/claims from a `text` file.
// First pass to validate the data from the incoming file
// MODIFICATION HISTORY
// DATE     WHO     DESCRIPTION
// 2015/Nov/09 MC      - original   
// 2016/Feb/22 MC1     - Yasemin requests to create the record for error 4 and bypass has provided in the text file
// 2016/May/31 MC2     - Yasemin requests to add edit check for amount >= -99,999.99 and <= 99,999.99
// 2017/Feb/13 MC3     - Yasemin requests to add edit check for doc nbr from f040-dtl
// -------------------------------------------------------------------------------
// verify transaction contain valid data

#endregion

using Core.ExceptionManagement;
using Core.Framework;
using Core.Framework.Core.Framework;
using Core.Windows.UI.Core.Windows;
using System;
using System.Data.SqlClient;
using System.Text;

public class U141A : BaseClassControl
{
	private U141A m_U141A;

	public U141A(string Name, int Level) : base(Name, Level)
	{
		this.ScreenType = ScreenTypes.QTP;
	}

	public U141A(string Name, int Level, bool Request) : base(Name, Level, Request)
	{
		this.ScreenType = ScreenTypes.QTP;
	}

    public override void Dispose()
    {
        if ((m_U141A != null))
        {
            m_U141A.CloseTransactionObjects();
            m_U141A = null;
        }
    }

    public U141A GetU141A(int Level)
    {
        if (m_U141A == null)
        {
            m_U141A = new U141A("U141A", Level);
        }
        else
        {
            m_U141A.ResetValues();
        }
        return m_U141A;
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
            U141A_U141_VERIFY_DATA_1 U141_VERIFY_DATA_1 = new U141A_U141_VERIFY_DATA_1(Name, Level);
            U141_VERIFY_DATA_1.Run();
            U141_VERIFY_DATA_1.Dispose();
            U141_VERIFY_DATA_1 = null;

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

public class U141A_U141_VERIFY_DATA_1 : U141A
{
    public U141A_U141_VERIFY_DATA_1(string Name, int Level) : base(Name, Level, true)
    {
        this.ScreenType = ScreenTypes.QTP;
        fleMISC_PAYMENT_FILE = new SqlFileObject(this, FileTypes.Primary, 0, "SEQUENTIAL", "MISC_PAYMENT_FILE", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF020_DOCTOR_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020_DOCTOR_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDOC_CLINIC_NBR1 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDOC_CLINIC_NBR2 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDOC_CLINIC_NBR3 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDOC_CLINIC_NBR4 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDOC_CLINIC_NBR5 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleDOC_CLINIC_NBR6 = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F020C_DOC_CLINIC_NEXT_BATCH_NBR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_OMA_FEE_MSTR = new SqlFileObject(this, FileTypes.Primary, 0, "[101C].INDEXED", "F040_OMA_FEE_MSTR", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_DTL = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_DTL", "", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleF040_DTL_DOC = new SqlFileObject(this, FileTypes.Primary, 0, "INDEXED", "F040_DTL", "F040_DTL_DOC", false, false, false, 0, "m_trnTRANS_UPDATE");
        fleU141A_VALID = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141A_VALID", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);
        fleU141A_ERROR = new SqlFileObject(this, FileTypes.Primary, 0, "TEMPORARYDATA", "U141A_ERROR", "", false, false, false, 0, "m_trnTRANS_UPDATE", FileType.SubFile);

        UP_BYPASS.GetValue += UP_BYPASS_GetValue;
        VALID_DOC.GetValue += VALID_DOC_GetValue;
        VALID_CLINIC.GetValue += VALID_CLINIC_GetValue;
        VALID_OMA_CD.GetValue += VALID_OMA_CD_GetValue;
        VALID_DATA_ENTRY.GetValue += VALID_DATA_ENTRY_GetValue;
        VALID_AGENT.GetValue += VALID_AGENT_GetValue;
        VALID_NOTE.GetValue += VALID_NOTE_GetValue;
        TERM_DAYS.GetValue += TERM_DAYS_GetValue;
        VALID_TERMINATE.GetValue += VALID_TERMINATE_GetValue;
        VALID_AMT.GetValue += VALID_AMT_GetValue;
        VALID_REC.GetValue += VALID_REC_GetValue;
        ERROR_CD.GetValue += ERROR_CD_GetValue;
        fleF040_DTL.InitializeItems += fleF040_DTL_AutomaticItemInitialization;
        fleF040_DTL_DOC.InitializeItems += fleF040_DTL_DOC_AutomaticItemInitialization;
    }

	#region "Declarations (Variables, Files and Transactions)(U141A_U141_VERIFY_DATA_1)"

	private SqlFileObject fleMISC_PAYMENT_FILE;
	private SqlFileObject fleF020_DOCTOR_MSTR;
    private SqlFileObject fleDOC_CLINIC_NBR1;
    private SqlFileObject fleDOC_CLINIC_NBR2;
    private SqlFileObject fleDOC_CLINIC_NBR3;
    private SqlFileObject fleDOC_CLINIC_NBR4;
    private SqlFileObject fleDOC_CLINIC_NBR5;
    private SqlFileObject fleDOC_CLINIC_NBR6;
    private SqlFileObject fleF040_OMA_FEE_MSTR;
	private SqlFileObject fleF040_DTL;
	private SqlFileObject fleF040_DTL_DOC;
	private DCharacter UP_BYPASS = new DCharacter("UP_BYPASS", 6);

    private void UP_BYPASS_GetValue(ref string Value)
    {
        try
        {
            Value = QDesign.UCase(fleMISC_PAYMENT_FILE.GetStringValue("BYPASS_EDIT"));
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

    private DCharacter VALID_DOC = new DCharacter("VALID_DOC", 1);
    private void VALID_DOC_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;
            if (fleF020_DOCTOR_MSTR.Exists())
            {
                CurrentValue = "Y";
            }
            else if (!fleF020_DOCTOR_MSTR.Exists())
            {
                CurrentValue = "1";
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

    private DCharacter VALID_CLINIC = new DCharacter("VALID_CLINIC", 1);
    private void VALID_CLINIC_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;
            if ((QDesign.NULL(fleMISC_PAYMENT_FILE.GetDecimalValue("CLINIC_NBR")) == QDesign.NULL(fleDOC_CLINIC_NBR1.GetDecimalValue("DOC_CLINIC_NBR")) | QDesign.NULL(fleMISC_PAYMENT_FILE.GetDecimalValue("CLINIC_NBR")) == QDesign.NULL(fleDOC_CLINIC_NBR2.GetDecimalValue("DOC_CLINIC_NBR")) | QDesign.NULL(fleMISC_PAYMENT_FILE.GetDecimalValue("CLINIC_NBR")) == QDesign.NULL(fleDOC_CLINIC_NBR3.GetDecimalValue("DOC_CLINIC_NBR")) | QDesign.NULL(fleMISC_PAYMENT_FILE.GetDecimalValue("CLINIC_NBR")) == QDesign.NULL(fleDOC_CLINIC_NBR4.GetDecimalValue("DOC_CLINIC_NBR")) | QDesign.NULL(fleMISC_PAYMENT_FILE.GetDecimalValue("CLINIC_NBR")) == QDesign.NULL(fleDOC_CLINIC_NBR5.GetDecimalValue("DOC_CLINIC_NBR")) | QDesign.NULL(fleMISC_PAYMENT_FILE.GetDecimalValue("CLINIC_NBR")) == QDesign.NULL(fleDOC_CLINIC_NBR6.GetDecimalValue("DOC_CLINIC_NBR"))))
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "2";
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

    private DCharacter VALID_OMA_CD = new DCharacter("VALID_OMA_CD", 1);
    private void VALID_OMA_CD_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (fleF040_OMA_FEE_MSTR.Exists())
            {
                CurrentValue = "Y";
            }
            else if (!fleF040_OMA_FEE_MSTR.Exists())
            {
                CurrentValue = "3";
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

    private DCharacter VALID_DATA_ENTRY = new DCharacter("VALID_DATA_ENTRY", 1);
    private void VALID_DATA_ENTRY_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (fleF040_DTL.Exists() & QDesign.NULL(fleF040_DTL.GetStringValue("DATA_ENTRY_FLAG")) == "V" & !fleF040_DTL_DOC.Exists())
            {
                CurrentValue = "Y";
            }
            else if (!fleF040_DTL.Exists() & !fleF040_DTL_DOC.Exists())
            {
                CurrentValue = "Y";
            }
            else if (fleF040_DTL.Exists() & QDesign.NULL(fleF040_DTL.GetStringValue("DATA_ENTRY_FLAG")) != "V" & QDesign.NULL(UP_BYPASS.Value) == "BYPASS" & !fleF040_DTL_DOC.Exists())
            {
                CurrentValue = "Y";
            }
            else if (!fleF040_DTL.Exists() & (fleF040_DTL_DOC.Exists() & QDesign.NULL(fleF040_DTL_DOC.GetStringValue("DATA_ENTRY_FLAG")) == "V"))
            {
                CurrentValue = "Y";
            }
            else if (!fleF040_DTL.Exists() & (fleF040_DTL_DOC.Exists() & QDesign.NULL(fleF040_DTL_DOC.GetStringValue("DATA_ENTRY_FLAG")) != "V" & QDesign.NULL(UP_BYPASS.Value) == "BYPASS"))
            {
                CurrentValue = "Y";
            }
            else if (fleF040_DTL.Exists() & QDesign.NULL(fleF040_DTL.GetStringValue("DATA_ENTRY_FLAG")) != "V" & fleF040_DTL_DOC.Exists() & QDesign.NULL(fleF040_DTL_DOC.GetStringValue("DATA_ENTRY_FLAG")) == "V")
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "4";
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

    private DCharacter VALID_AGENT = new DCharacter("VALID_AGENT", 1);
    private void VALID_AGENT_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (string.Compare(fleMISC_PAYMENT_FILE.GetStringValue("HDR_AGENT_CD"), "0") >= 0 & string.Compare(fleMISC_PAYMENT_FILE.GetStringValue("HDR_AGENT_CD"), "9") <= 0)
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "5";
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

    private DCharacter VALID_NOTE = new DCharacter("VALID_NOTE", 1);
    private void VALID_NOTE_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(fleMISC_PAYMENT_FILE.GetStringValue("CLMHDR_REFERENCE")) != QDesign.NULL(" "))
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "6";
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

    private DDecimal TERM_DAYS = new DDecimal("TERM_DAYS", 6);
    private void TERM_DAYS_GetValue(ref decimal Value)
    {
        try
        {
            Value = QDesign.Days(QDesign.SysDate(ref m_cnnQUERY)) - QDesign.Days(QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"), 2)));
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

    private DCharacter VALID_TERMINATE = new DCharacter("VALID_TERMINATE", 1);
    private void VALID_TERMINATE_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"), 2)) != 0 & TERM_DAYS.Value <= 180 & QDesign.NULL(UP_BYPASS.Value) != "BYPASS")
            {
                CurrentValue = "W";
            }
            else if (QDesign.NConvert(QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_YY"), 4) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_MM"), 2) + QDesign.ASCII(fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DATE_FAC_TERM_DD"), 2)) != 0 & QDesign.NULL(TERM_DAYS.Value) > 180 & QDesign.NULL(UP_BYPASS.Value) != "BYPASS")
            {
                CurrentValue = "E";
            }
            else
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

    private DCharacter VALID_AMT = new DCharacter("VALID_AMT", 1);
    private void VALID_AMT_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (fleMISC_PAYMENT_FILE.GetDecimalValue("SIGNED_AMT_NET") >= -9999999 & fleMISC_PAYMENT_FILE.GetDecimalValue("SIGNED_AMT_NET") <= 9999999)
            {
                CurrentValue = "Y";
            }
            else
            {
                CurrentValue = "7";
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

    private DCharacter VALID_REC = new DCharacter("VALID_REC", 1);
    private void VALID_REC_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(VALID_DOC.Value) != "Y" | QDesign.NULL(VALID_CLINIC.Value) != "Y" | QDesign.NULL(VALID_OMA_CD.Value) != "Y" | QDesign.NULL(VALID_DATA_ENTRY.Value) != "Y" | QDesign.NULL(VALID_AGENT.Value) != "Y" | QDesign.NULL(VALID_NOTE.Value) != "Y" | QDesign.NULL(VALID_AMT.Value) != "Y" | QDesign.NULL(VALID_TERMINATE.Value) != "Y")
            {
                CurrentValue = "N";
            }
            else
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

    private DCharacter ERROR_CD = new DCharacter("ERROR_CD", 1);
    private void ERROR_CD_GetValue(ref string Value)
    {
        try
        {
            string CurrentValue = string.Empty;

            if (QDesign.NULL(VALID_DOC.Value) != "Y")
            {
                CurrentValue = VALID_DOC.Value;
            }
            else if (QDesign.NULL(VALID_CLINIC.Value) != "Y")
            {
                CurrentValue = VALID_CLINIC.Value;
            }
            else if (QDesign.NULL(VALID_OMA_CD.Value) != "Y")
            {
                CurrentValue = VALID_OMA_CD.Value;
            }
            else if (QDesign.NULL(VALID_DATA_ENTRY.Value) != "Y")
            {
                CurrentValue = VALID_DATA_ENTRY.Value;
            }
            else if (QDesign.NULL(VALID_AGENT.Value) != "Y")
            {
                CurrentValue = VALID_AGENT.Value;
            }
            else if (QDesign.NULL(VALID_NOTE.Value) != "Y")
            {
                CurrentValue = VALID_NOTE.Value;
            }
            else if (QDesign.NULL(VALID_AMT.Value) != "Y")
            {
                CurrentValue = VALID_AMT.Value;
            }
            else if (QDesign.NULL(VALID_TERMINATE.Value) != "Y")
            {
                CurrentValue = VALID_TERMINATE.Value;
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

	private SqlFileObject fleU141A_VALID;
	private SqlFileObject fleU141A_ERROR;

    #endregion


    #region "Standard Generated Procedures(U141A_U141_VERIFY_DATA_1)"

    #region "Automatic Item Initialization(U141A_U141_VERIFY_DATA_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:10:14 PM

    //#-----------------------------------------
    //# fleF040_DTL_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:08 PM
    //#-----------------------------------------
    private void fleF040_DTL_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            fleF040_DTL.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
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
    //# fleF040_DTL_DOC_AutomaticItemInitialization Procedure
    //# Precompiler Ver.: 1.0.6387.27217  Generated on: 6/27/2017 4:10:08 PM
    //#-----------------------------------------
    private void fleF040_DTL_DOC_AutomaticItemInitialization(bool Fixed)
    {
        try
        {
            fleF040_DTL_DOC.set_SetValue("DOC_NBR", !Fixed, fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR"));
            fleF040_DTL_DOC.set_SetValue("FEE_OMA_CD", !Fixed, fleF040_DTL.GetStringValue("FEE_OMA_CD"));
            fleF040_DTL_DOC.set_SetValue("DEPT_NBR", !Fixed, fleF040_DTL.GetDecimalValue("DEPT_NBR"));
            fleF040_DTL_DOC.set_SetValue("DATA_ENTRY_FLAG", !Fixed, fleF040_DTL.GetStringValue("DATA_ENTRY_FLAG"));
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

    #region "Transaction Management Procedures(U141A_U141_VERIFY_DATA_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:09:55 PM

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
		fleMISC_PAYMENT_FILE.Transaction = m_trnTRANS_UPDATE;
		fleF020_DOCTOR_MSTR.Transaction = m_trnTRANS_UPDATE;
        fleDOC_CLINIC_NBR1.Transaction = m_trnTRANS_UPDATE;
        fleDOC_CLINIC_NBR2.Transaction = m_trnTRANS_UPDATE;
        fleDOC_CLINIC_NBR3.Transaction = m_trnTRANS_UPDATE;
        fleDOC_CLINIC_NBR4.Transaction = m_trnTRANS_UPDATE;
        fleDOC_CLINIC_NBR5.Transaction = m_trnTRANS_UPDATE;
        fleDOC_CLINIC_NBR6.Transaction = m_trnTRANS_UPDATE;
        fleF040_OMA_FEE_MSTR.Transaction = m_trnTRANS_UPDATE;
		fleF040_DTL.Transaction = m_trnTRANS_UPDATE;
		fleF040_DTL_DOC.Transaction = m_trnTRANS_UPDATE;
		fleU141A_VALID.Transaction = m_trnTRANS_UPDATE;
		fleU141A_ERROR.Transaction = m_trnTRANS_UPDATE;
	}

    #endregion

    #region "FILE Management Procedures(U141A_U141_VERIFY_DATA_1)"

    //# NOTE: This region is placeholder and is required by the RenaissanceArchitectPreCompilerAddIn.
    //# Do not delete, modify or move it.  Updated: 6/27/2017 4:09:55 PM

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
            fleMISC_PAYMENT_FILE.Dispose();
            fleF020_DOCTOR_MSTR.Dispose();
            fleDOC_CLINIC_NBR1.Dispose();
            fleDOC_CLINIC_NBR2.Dispose();
            fleDOC_CLINIC_NBR3.Dispose();
            fleDOC_CLINIC_NBR4.Dispose();
            fleDOC_CLINIC_NBR5.Dispose();
            fleDOC_CLINIC_NBR6.Dispose();
            fleF040_OMA_FEE_MSTR.Dispose();
            fleF040_DTL.Dispose();
            fleF040_DTL_DOC.Dispose();
            fleU141A_VALID.Dispose();
            fleU141A_ERROR.Dispose();
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
    
    #region "Local Procedures (DESIGNERS, INTERNAL and INPUT, EDIT, PROCESS and OUTPUT)(U141A_U141_VERIFY_DATA_1)"
    
    public void Run()
    {
        try
        {
            Request("U141_VERIFY_DATA_1");

            while (fleMISC_PAYMENT_FILE.QTPForMissing())
            {
                // --> GET MISC_PAYMENT_FILE <--

                fleMISC_PAYMENT_FILE.GetData();
                // --> End GET MISC_PAYMENT_FILE <--

                while (fleF020_DOCTOR_MSTR.QTPForMissing("1"))
                {
                    // --> GET F020_DOCTOR_MSTR <--
                    m_strWhere = new StringBuilder(" WHERE ");
                    m_strWhere.Append(" ").Append(fleF020_DOCTOR_MSTR.ElementOwner("DOC_NBR")).Append(" = ");
                    m_strWhere.Append(Common.StringToField(fleMISC_PAYMENT_FILE.GetStringValue("DOC_NBR")));

                    fleF020_DOCTOR_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                    // --> End GET F020_DOCTOR_MSTR <--

                    while (fleDOC_CLINIC_NBR1.QTPForMissing("2"))
                    {
                        // --> GET fleDOC_CLINIC_NBR1 <--
                        m_strWhere = new StringBuilder(" WHERE ");
                        m_strWhere.Append(" ").Append(fleDOC_CLINIC_NBR1.ElementOwner("DOC_NBR")).Append(" = ");
                        m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                        m_strWhere.Append(" And ").Append(fleDOC_CLINIC_NBR1.ElementOwner("SEQ_NO")).Append(" = 1");

                        fleDOC_CLINIC_NBR1.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                        // --> End GET fleDOC_CLINIC_NBR1 <--

                        while (fleDOC_CLINIC_NBR2.QTPForMissing("3"))
                        {
                            // --> GET fleDOC_CLINIC_NBR2 <--
                            m_strWhere = new StringBuilder(" WHERE ");
                            m_strWhere.Append(" ").Append(fleDOC_CLINIC_NBR2.ElementOwner("DOC_NBR")).Append(" = ");
                            m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                            m_strWhere.Append(" And ").Append(fleDOC_CLINIC_NBR2.ElementOwner("SEQ_NO")).Append(" = 2");

                            fleDOC_CLINIC_NBR2.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                            // --> End GET fleDOC_CLINIC_NBR2 <--

                            while (fleDOC_CLINIC_NBR3.QTPForMissing("4"))
                            {
                                // --> GET fleDOC_CLINIC_NBR3 <--
                                m_strWhere = new StringBuilder(" WHERE ");
                                m_strWhere.Append(" ").Append(fleDOC_CLINIC_NBR3.ElementOwner("DOC_NBR")).Append(" = ");
                                m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                                m_strWhere.Append(" And ").Append(fleDOC_CLINIC_NBR3.ElementOwner("SEQ_NO")).Append(" = 3");

                                fleDOC_CLINIC_NBR3.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                // --> End GET fleDOC_CLINIC_NBR3 <--

                                while (fleDOC_CLINIC_NBR4.QTPForMissing("5"))
                                {
                                    // --> GET fleDOC_CLINIC_NBR4 <--
                                    m_strWhere = new StringBuilder(" WHERE ");
                                    m_strWhere.Append(" ").Append(fleDOC_CLINIC_NBR4.ElementOwner("DOC_NBR")).Append(" = ");
                                    m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                                    m_strWhere.Append(" And ").Append(fleDOC_CLINIC_NBR4.ElementOwner("SEQ_NO")).Append(" = 4");

                                    fleDOC_CLINIC_NBR4.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                    // --> End GET fleDOC_CLINIC_NBR4 <--

                                    while (fleDOC_CLINIC_NBR5.QTPForMissing("6"))
                                    {
                                        // --> GET fleDOC_CLINIC_NBR5 <--
                                        m_strWhere = new StringBuilder(" WHERE ");
                                        m_strWhere.Append(" ").Append(fleDOC_CLINIC_NBR5.ElementOwner("DOC_NBR")).Append(" = ");
                                        m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                                        m_strWhere.Append(" And ").Append(fleDOC_CLINIC_NBR5.ElementOwner("SEQ_NO")).Append(" = 5");

                                        fleDOC_CLINIC_NBR5.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                        // --> End GET fleDOC_CLINIC_NBR5 <--

                                        while (fleDOC_CLINIC_NBR6.QTPForMissing("7"))
                                        {
                                            // --> GET fleDOC_CLINIC_NBR6 <--
                                            m_strWhere = new StringBuilder(" WHERE ");
                                            m_strWhere.Append(" ").Append(fleDOC_CLINIC_NBR6.ElementOwner("DOC_NBR")).Append(" = ");
                                            m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                                            m_strWhere.Append(" And ").Append(fleDOC_CLINIC_NBR6.ElementOwner("SEQ_NO")).Append(" = 6");

                                            fleDOC_CLINIC_NBR6.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                            // --> End GET fleDOC_CLINIC_NBR6 <--

                                            while (fleF040_OMA_FEE_MSTR.QTPForMissing("8"))
                                            {
                                                // --> GET F040_OMA_FEE_MSTR <--
                                                m_strWhere = new StringBuilder(" WHERE ");
                                                m_strWhere.Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FEE_OMA_CD_LTR1")).Append(" = ");
                                                m_strWhere.Append(Common.StringToField((fleMISC_PAYMENT_FILE.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(0, 1)));

                                                m_strWhere.Append(" AND ").Append(" ").Append(fleF040_OMA_FEE_MSTR.ElementOwner("FILLER_NUMERIC")).Append(" = ");
                                                m_strWhere.Append(Common.StringToField((fleMISC_PAYMENT_FILE.GetStringValue("CLMDTL_OMA_CD")).PadRight(4).Substring(1, 3)));

                                                fleF040_OMA_FEE_MSTR.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                // --> End GET F040_OMA_FEE_MSTR <--

                                                while (fleF040_DTL.QTPForMissing("9"))
                                                {
                                                    // --> GET F040_DTL <--
                                                    m_strWhere = new StringBuilder(" WHERE ");
                                                    m_strWhere.Append(" ").Append(fleF040_DTL.ElementOwner("DOC_NBR")).Append(" = ");
                                                    m_strWhere.Append(Common.StringToField("000"));
                                                    m_strWhere.Append(" And ").Append(fleF040_DTL.ElementOwner("FEE_OMA_CD")).Append(" = ");
                                                    m_strWhere.Append(Common.StringToField(fleMISC_PAYMENT_FILE.GetStringValue("CLMDTL_OMA_CD")));
                                                    m_strWhere.Append(" And ").Append(fleF040_DTL.ElementOwner("DEPT_NBR")).Append(" = ");
                                                    m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")));

                                                    fleF040_DTL.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                    // --> End GET F040_DTL <--

                                                    while (fleF040_DTL_DOC.QTPForMissing("10"))
                                                    {
                                                        // --> GET F040_DTL_DOC <--
                                                        m_strWhere = new StringBuilder(" WHERE ");
                                                        m_strWhere.Append(" ").Append(fleF040_DTL_DOC.ElementOwner("DOC_NBR")).Append(" = ");
                                                        m_strWhere.Append(Common.StringToField(fleF020_DOCTOR_MSTR.GetStringValue("DOC_NBR")));
                                                        m_strWhere.Append(" And ").Append(fleF040_DTL_DOC.ElementOwner("FEE_OMA_CD")).Append(" = ");
                                                        m_strWhere.Append(Common.StringToField(fleMISC_PAYMENT_FILE.GetStringValue("CLMDTL_OMA_CD")));
                                                        m_strWhere.Append(" And ").Append(fleF040_DTL_DOC.ElementOwner("DEPT_NBR")).Append(" = ");
                                                        m_strWhere.Append((fleF020_DOCTOR_MSTR.GetDecimalValue("DOC_DEPT")));

                                                        fleF040_DTL_DOC.GetData(m_strWhere.ToString(), GetDataOptions.IsOptional);
                                                        // --> End GET F040_DTL_DOC <--


                                                        if (Transaction())
                                                        {
                                                            SubFile(ref m_trnTRANS_UPDATE, ref fleU141A_VALID, QDesign.NULL(VALID_REC.Value) == "Y", SubFileType.Keep, fleF020_DOCTOR_MSTR, "DOC_DEPT", fleMISC_PAYMENT_FILE);
                                                            SubFile(ref m_trnTRANS_UPDATE, ref fleU141A_ERROR, QDesign.NULL(VALID_REC.Value) != "Y", SubFileType.Keep, ERROR_CD, fleMISC_PAYMENT_FILE);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
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
            EndRequest("U141_VERIFY_DATA_1");
        }
    }

	#endregion
}
//U141_VERIFY_DATA_1




